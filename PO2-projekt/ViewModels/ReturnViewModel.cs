using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using PO2_projekt.Data;
using PO2_projekt.Models;
using System.Linq;
using System.Collections.Generic;

namespace PO2_projekt.ViewModels;

public partial class ReturnViewModel : PageViewModel
{
    private readonly LibraryDbContext _context;
    public ObservableCollection<Borrowing> ActiveBorrowings { get; } = new();
    [ObservableProperty] private Borrowing _selectedBorrowing;

    // Nowe właściwości do filtrowania i wyszukiwania
    [ObservableProperty] private string _searchText;
    public List<string> ReturnDateFilters { get; } = new() { "Wszystkie", "Przeterminowane", "Do zwrotu w tym tygodniu" };
    [ObservableProperty] private string _selectedReturnDateFilter = "Wszystkie";
    public ObservableCollection<Reader> UserFilters { get; } = new();
    [ObservableProperty] private Reader _selectedUserFilter;
    public ObservableCollection<BorrowingViewModel> ActiveBorrowingsFiltered { get; } = new();

    public ReturnViewModel(LibraryDbContext context)
    {
        _context = context;
        PageName = ApplicationPageNames.Return;
    }

    public async Task InitializeAsync()
    {
        await LoadActiveBorrowingsAsync();
        await LoadUserFiltersAsync();
        UpdateFiltered();
    }

    [RelayCommand]
    private async Task LoadActiveBorrowingsAsync()
    {
        var borrowings = await _context.Borrowings
            .Include(b => b.Book)
            .Include(b => b.User)
            .Where(b => !b.Returned)
            .ToListAsync();
        ActiveBorrowings.Clear();
        foreach (var b in borrowings)
            ActiveBorrowings.Add(b);
        UpdateFiltered();
    }

    private async Task LoadUserFiltersAsync()
    {
        var users = await _context.Readers.AsNoTracking().ToListAsync();
        UserFilters.Clear();
        UserFilters.Add(new Reader { FirstName = "Wszyscy", LastName = "" });
        foreach (var u in users)
            UserFilters.Add(u);
    }

    partial void OnSearchTextChanged(string value) => UpdateFiltered();
    partial void OnSelectedReturnDateFilterChanged(string value) => UpdateFiltered();
    partial void OnSelectedUserFilterChanged(Reader value) => UpdateFiltered();

    private void UpdateFiltered()
    {
        ActiveBorrowingsFiltered.Clear();
        var now = DateTime.UtcNow;
        var weekEnd = now.AddDays(7);
        var filtered = ActiveBorrowings.Select(b => new BorrowingViewModel(b)).ToList();
        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            var lower = SearchText.ToLower();
            filtered = filtered.Where(bvm =>
                (bvm.BookTitle?.ToLower().Contains(lower) ?? false) ||
                (bvm.UserFullName?.ToLower().Contains(lower) ?? false)
            ).ToList();
        }
        if (SelectedReturnDateFilter == "Przeterminowane")
        {
            filtered = filtered.Where(bvm => bvm.IsOverdue).ToList();
        }
        else if (SelectedReturnDateFilter == "Do zwrotu w tym tygodniu")
        {
            filtered = filtered.Where(bvm => bvm.ReturnDate.HasValue && bvm.ReturnDate.Value > now && bvm.ReturnDate.Value <= weekEnd).ToList();
        }
        if (SelectedUserFilter != null && SelectedUserFilter.FirstName != "Wszyscy")
        {
            filtered = filtered.Where(bvm => bvm.UserId == SelectedUserFilter.Id).ToList();
        }
        foreach (var bvm in filtered)
            ActiveBorrowingsFiltered.Add(bvm);
    }

    [RelayCommand]
    private async Task ReturnBookAsync()
    {
        if (SelectedBorrowing == null) return;
        var borrowing = await _context.Borrowings.FindAsync(SelectedBorrowing.Id);
        if (borrowing != null)
        {
            borrowing.Returned = true;
            borrowing.ReturnDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            ActiveBorrowings.Remove(SelectedBorrowing);
            SelectedBorrowing = null;
            UpdateFiltered();
        }
    }

    // ViewModel dla Borrowing z dodatkowymi polami do widoku
    public class BorrowingViewModel : ObservableObject
    {
        private readonly Borrowing _borrowing;
        public BorrowingViewModel(Borrowing borrowing) { _borrowing = borrowing; }
        public int Id => _borrowing.Id;
        public string BookTitle => _borrowing.Book?.Title;
        public string UserFullName => _borrowing.User?.FullName;
        public int UserId => _borrowing.User?.Id ?? 0;
        public DateTime BorrowDate => _borrowing.BorrowDate;
        public DateTime? ReturnDate => _borrowing.ReturnDate;
        public bool IsOverdue => (_borrowing.ReturnDate.HasValue && _borrowing.ReturnDate.Value < DateTime.UtcNow);
        public string DaysLateText
        {
            get
            {
                if (!IsOverdue || !_borrowing.ReturnDate.HasValue) return "";
                var days = (DateTime.UtcNow - _borrowing.ReturnDate.Value).Days;
                return $"+{days} dni";
            }
        }
    }
}