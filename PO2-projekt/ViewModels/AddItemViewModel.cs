using System;
using System.Collections;
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

public partial class AddItemViewModel : PageViewModel, INotifyDataErrorInfo
{
    private readonly LibraryDbContext _context;
    private readonly Dictionary<string, List<string>> _errors = new();

    public AddItemViewModel(LibraryDbContext context)
    {
        _context = context;
        Books = new ObservableCollection<Book>();
        Categories = new ObservableCollection<Category>();
        SelectedBook = new Book();
    }

    [ObservableProperty] private Book _selectedBook;

    [ObservableProperty] private Category _selectedCategory;

    public ObservableCollection<Book> Books { get; }
    public ObservableCollection<Category> Categories { get; }

    [RelayCommand]
    private async Task LoadBooksAsync()
    {
        var books = await _context.Books
            .Include(b => b.Category)
            .AsNoTracking()
            .ToListAsync();

        Books.Clear();
        foreach (var book in books)
            Books.Add(book);
    }

    [RelayCommand]
    private async Task LoadCategoriesAsync()
    {
        var categories = await _context.Categories
            .AsNoTracking()
            .ToListAsync();

        Categories.Clear();
        foreach (var category in categories)
            Categories.Add(category);

// Ustaw domyślną kategorię jeśli jest dostępna i SelectedBook nie jest null
        if (Categories.Any() && SelectedBook != null)
        {
            SelectedCategory = Categories.FirstOrDefault(c => c.Id == SelectedBook.CategoryId) ?? Categories.First();
        }
    }


    partial void OnSelectedBookChanged(Book? oldValue, Book? newValue)
    {
        if (newValue != null && Categories.Any())
        {
            SelectedCategory = Categories.FirstOrDefault(c => c.Id == newValue.CategoryId);
        }
        else
        {
            SelectedCategory = null;
        }
    }


    partial void OnSelectedCategoryChanged(Category? oldValue, Category? newValue)
    {
        if (SelectedBook != null)
        {
            SelectedBook.CategoryId = newValue?.Id;
            SelectedBook.Category = newValue;
        }
    }

    [RelayCommand]
    private async Task AddBookAsync()
    {
        Validate();
        if (HasErrors) return;

        if (SelectedBook.Id != 0)
        {
            return;
        }

        _context.Books.Add(SelectedBook);
        await _context.SaveChangesAsync();
        Books.Add(SelectedBook);

        SelectedBook = new Book();
// Ustaw domyślną kategorię po dodaniu książki
        if (Categories.Any())
            SelectedCategory = Categories.First();
    }


    [RelayCommand]
    private async Task UpdateBookAsync()
    {
        Validate();
        if (HasErrors || SelectedBook?.Id == 0) return;

        _context.Books.Update(SelectedBook);
        await _context.SaveChangesAsync();
        await LoadBooksAsync();
    }

    [RelayCommand]
    private async Task DeleteBookAsync()
    {
        if (SelectedBook?.Id == 0) return;

        _context.Books.Remove(SelectedBook);
        await _context.SaveChangesAsync();
        Books.Remove(SelectedBook);
        SelectedBook = new Book();
    }

    #region Walidacja

    public bool HasErrors => _errors.Count > 0;
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public IEnumerable GetErrors(string? propertyName)
    {
        if (propertyName == null || !_errors.ContainsKey(propertyName))
            return Enumerable.Empty<string>();

        return _errors[propertyName];
    }

    private void Validate()
    {
        _errors.Clear();

        if (string.IsNullOrWhiteSpace(SelectedBook.Title))
            AddError(nameof(SelectedBook.Title), "Tytuł jest wymagany");

        if (SelectedBook.YearPublished < 1800 || SelectedBook.YearPublished > DateTime.Now.Year)
            AddError(nameof(SelectedBook.YearPublished), $"Rok musi być między 1800 a {DateTime.Now.Year}");

        if (SelectedBook.Copies < 1)
            AddError(nameof(SelectedBook.Copies), "Liczba kopii musi być ≥ 1");

        OnErrorsChanged(nameof(SelectedBook));

// Powiadomienie o zmianach właściwości błędów do bindowania w XAML
        OnPropertyChanged(nameof(TitleError));
        OnPropertyChanged(nameof(YearPublishedError));
        OnPropertyChanged(nameof(CopiesError));
    }

    private void AddError(string propertyName, string error)
    {
        if (!_errors.ContainsKey(propertyName))
            _errors[propertyName] = new List<string>();

        _errors[propertyName].Add(error);
        OnErrorsChanged(propertyName);
    }

    private void OnErrorsChanged(string propertyName)
        => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

// Właściwości błędów do bindowania w XAML
    public string TitleError => _errors.ContainsKey(nameof(SelectedBook.Title))
        ? string.Join(", ", _errors[nameof(SelectedBook.Title)])
        : string.Empty;

    public string YearPublishedError => _errors.ContainsKey(nameof(SelectedBook.YearPublished))
        ? string.Join(", ", _errors[nameof(SelectedBook.YearPublished)])
        : string.Empty;

    public string CopiesError => _errors.ContainsKey(nameof(SelectedBook.Copies))
        ? string.Join(", ", _errors[nameof(SelectedBook.Copies)])
        : string.Empty;

    #endregion

    public async Task InitializeAsync()
    {
        await LoadBooksAsync();
        await LoadCategoriesAsync();
    }
}