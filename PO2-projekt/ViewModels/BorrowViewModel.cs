using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using PO2_projekt.Data;
using PO2_projekt.Models;

namespace PO2_projekt.ViewModels;

public partial class BorrowViewModel : PageViewModel, INotifyDataErrorInfo
{
    private readonly LibraryDbContext _context;
    private readonly Dictionary<string, string> _errors = new();

    public BorrowViewModel(LibraryDbContext context)
    {
        _context = context;
        Borrowings = new ObservableCollection<Borrowing>();
        Books = new ObservableCollection<Book>();
        Readers = new ObservableCollection<Reader>();
        SelectedBorrowing = new Borrowing { BorrowDate = DateTime.Now };
        PageName = ApplicationPageNames.Borrow;
    }

    public ObservableCollection<Borrowing> Borrowings { get; }
    public ObservableCollection<Book> Books { get; }
    public ObservableCollection<Reader> Readers { get; }

    [ObservableProperty] private Borrowing _selectedBorrowing;
    [ObservableProperty] private Book _selectedBook;
    [ObservableProperty] private Reader _selectedReader;
    [ObservableProperty] private string _bookFilter;
    [ObservableProperty] private string _readerFilter;
    public ObservableCollection<Book> BooksFiltered { get; } = new();
    public ObservableCollection<Reader> ReadersFiltered { get; } = new();
    [ObservableProperty] private bool _readerDropdownOpen;
    [ObservableProperty] private bool _bookDropdownOpen;

    [RelayCommand]
    private async Task LoadBorrowingsAsync()
    {
        var borrowings = await _context.Borrowings
            .Include(b => b.Book)
            .Include(b => b.User)
            .AsNoTracking()
            .ToListAsync();
        Borrowings.Clear();
        foreach (var b in borrowings)
            Borrowings.Add(b);
    }

    [RelayCommand]
    private async Task LoadBooksAsync()
    {
        var books = await _context.Books.AsNoTracking().ToListAsync();
        Books.Clear();
        foreach (var b in books)
            Books.Add(b);
        UpdateBooksFiltered();
    }

    [RelayCommand]
    private async Task LoadReadersAsync()
    {
        var readers = await _context.Readers.AsNoTracking().ToListAsync();
        Readers.Clear();
        foreach (var r in readers)
            Readers.Add(r);
        UpdateReadersFiltered();
    }

    [RelayCommand]
    private async Task AddBorrowingAsync()
    {
        Validate();
        if (HasErrors) return;
        if (SelectedBorrowing.Id != 0) return;
        SelectedBorrowing.BookId = SelectedBook?.Id ?? 0;
        SelectedBorrowing.UserId = SelectedReader?.Id ?? 0;
        SelectedBorrowing.BorrowDate = DateTime.UtcNow;
        if (!SelectedBorrowing.ReturnDate.HasValue)
            SelectedBorrowing.ReturnDate = SelectedBorrowing.BorrowDate.AddMonths(2);
        else
            SelectedBorrowing.ReturnDate = DateTime.SpecifyKind(SelectedBorrowing.ReturnDate.Value, DateTimeKind.Utc);
        _context.Borrowings.Add(SelectedBorrowing);
        await _context.SaveChangesAsync();
        Borrowings.Add(SelectedBorrowing);
        SelectedBorrowing = new Borrowing { BorrowDate = DateTime.Now, ReturnDate = DateTime.Now.AddMonths(2) };
    }

    [RelayCommand]
    private async Task UpdateBorrowingAsync()
    {
        Validate();
        if (HasErrors || SelectedBorrowing?.Id == 0) return;
        var borrowing = await _context.Borrowings.FindAsync(SelectedBorrowing.Id);
        if (borrowing != null)
        {
            borrowing.BookId = SelectedBook?.Id ?? 0;
            borrowing.UserId = SelectedReader?.Id ?? 0;
            borrowing.BorrowDate = SelectedBorrowing.BorrowDate;
            borrowing.ReturnDate = SelectedBorrowing.ReturnDate;
            await _context.SaveChangesAsync();
            await LoadBorrowingsAsync();
        }
    }

    [RelayCommand]
    private async Task DeleteBorrowingAsync()
    {
        if (SelectedBorrowing?.Id == 0) return;
        var borrowing = await _context.Borrowings.FindAsync(SelectedBorrowing.Id);
        if (borrowing != null)
        {
            _context.Borrowings.Remove(borrowing);
            await _context.SaveChangesAsync();
            Borrowings.Remove(SelectedBorrowing);
            SelectedBorrowing = new Borrowing { BorrowDate = DateTime.Now, ReturnDate = DateTime.Now.AddMonths(2) };
        }
    }

    #region Walidacja
    public bool HasErrors => _errors.Count > 0;
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
    public System.Collections.IEnumerable GetErrors(string? propertyName)
    {
        if (propertyName == null || !_errors.ContainsKey(propertyName))
            return Enumerable.Empty<string>();
        return new[] { _errors[propertyName] };
    }
    private void Validate()
    {
        _errors.Clear();
        if (SelectedBook == null)
            _errors[nameof(SelectedBook)] = "Wybierz książkę";
        else if (Borrowings.Any(b => b.BookId == SelectedBook.Id && !b.Returned && b.Id != SelectedBorrowing.Id))
            _errors[nameof(SelectedBook)] = "Ta książka jest już wypożyczona i nie została zwrócona.";
        if (SelectedReader == null)
            _errors[nameof(SelectedReader)] = "Wybierz czytelnika";
        OnErrorsChanged(nameof(SelectedBook));
        OnErrorsChanged(nameof(SelectedReader));
        OnPropertyChanged(nameof(BookError));
        OnPropertyChanged(nameof(ReaderError));
    }
    private void OnErrorsChanged(string propertyName)
        => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    public string BookError => _errors.ContainsKey(nameof(SelectedBook)) ? _errors[nameof(SelectedBook)] : string.Empty;
    public string ReaderError => _errors.ContainsKey(nameof(SelectedReader)) ? _errors[nameof(SelectedReader)] : string.Empty;
    public string BorrowDateError => string.Empty;
    #endregion

    public async Task InitializeAsync()
    {
        await LoadBooksAsync();
        await LoadReadersAsync();
        await LoadBorrowingsAsync();
    }

    partial void OnSelectedBorrowingChanged(Borrowing? oldValue, Borrowing? newValue)
    {
        if (newValue != null)
        {
            SelectedBook = Books.FirstOrDefault(b => b.Id == newValue.BookId);
            SelectedReader = Readers.FirstOrDefault(r => r.Id == newValue.UserId);
        }
        else
        {
            SelectedBook = null;
            SelectedReader = null;
        }
    }

    partial void OnReaderFilterChanged(string value)
    {
        UpdateReadersFiltered();
        ReaderDropdownOpen = !string.IsNullOrWhiteSpace(value) && ReadersFiltered.Count > 0;
    }

    private void UpdateReadersFiltered()
    {
        ReadersFiltered.Clear();
        var filter = ReaderFilter?.ToLower() ?? string.Empty;
        foreach (var reader in Readers)
        {
            if (string.IsNullOrWhiteSpace(filter) || reader.FullName.ToLower().Contains(filter))
                ReadersFiltered.Add(reader);
        }
    }

    partial void OnBookFilterChanged(string value)
    {
        UpdateBooksFiltered();
        BookDropdownOpen = !string.IsNullOrWhiteSpace(value) && BooksFiltered.Count > 0;
    }

    private void UpdateBooksFiltered()
    {
        BooksFiltered.Clear();
        var filter = BookFilter?.ToLower() ?? string.Empty;
        foreach (var book in Books)
        {
            if (string.IsNullOrWhiteSpace(filter) || book.Title.ToLower().Contains(filter))
                BooksFiltered.Add(book);
        }
    }
}