using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using PO2_projekt.Data;
using PO2_projekt.Models;
using System.Linq;

namespace PO2_projekt.ViewModels;

public partial class ReturnViewModel : PageViewModel
{
    private readonly LibraryDbContext _context;
    public ObservableCollection<Borrowing> ActiveBorrowings { get; } = new();
    [ObservableProperty] private Borrowing _selectedBorrowing;

    public ReturnViewModel(LibraryDbContext context)
    {
        _context = context;
        PageName = ApplicationPageNames.Return;
    }

    public async Task InitializeAsync()
    {
        await LoadActiveBorrowingsAsync();
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
        }
    }
}