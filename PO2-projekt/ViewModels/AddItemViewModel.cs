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
        Authors = new ObservableCollection<Author>();
        SelectedAuthors = new ObservableCollection<Author>();
        PageName = ApplicationPageNames.AddItem;
    }

    [ObservableProperty] private Book _selectedBook;

    [ObservableProperty] private Category _selectedCategory;

    public ObservableCollection<Book> Books { get; }
    public ObservableCollection<Category> Categories { get; }
    public ObservableCollection<Author> Authors { get; } = new();
    public ObservableCollection<Author> SelectedAuthors { get; set; } = new();

    [ObservableProperty] private string _newAuthorFirstName;
    [ObservableProperty] private string _newAuthorLastName;

    [ObservableProperty] private Author _selectedAuthor;
    [ObservableProperty] private string _newCategoryName;

    [ObservableProperty] private string _authorFilter;
    public ObservableCollection<Author> AuthorsFiltered { get; } = new();

    [ObservableProperty] private bool _authorDropdownOpen;

    [ObservableProperty] private string _categoryFilter;
    public ObservableCollection<Category> CategoriesFiltered { get; } = new();

    [ObservableProperty] private bool _categoryDropdownOpen;

    [RelayCommand]
    private async Task LoadBooksAsync()
    {
        var books = await _context.Books
            .Include(b => b.Category)
            .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
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

        UpdateCategoriesFiltered();

        if (Categories.Any() && SelectedBook != null)
        {
            SelectedCategory = Categories.FirstOrDefault(c => c.Id == SelectedBook.CategoryId) ?? Categories.First();
        }
    }

    [RelayCommand]
    private async Task LoadAuthorsAsync()
    {
        var authors = await _context.Authors.AsNoTracking().ToListAsync();
        Authors.Clear();
        foreach (var author in authors)
            Authors.Add(author);
        UpdateAuthorsFiltered();
    }

    partial void OnSelectedBookChanged(Book? oldValue, Book? newValue)
    {
        if (newValue != null)
        {
            SelectedCategory = Categories.FirstOrDefault(c => c.Id == newValue.CategoryId);
            var firstBookAuthor = newValue.BookAuthors.FirstOrDefault();
            SelectedAuthor = firstBookAuthor?.Author != null
                ? Authors.FirstOrDefault(a => a.Id == firstBookAuthor.Author.Id)
                : null;
            NewAuthorFirstName = string.Empty;
            NewAuthorLastName = string.Empty;
            NewCategoryName = string.Empty;
        }
        else
        {
            SelectedCategory = null;
            SelectedAuthor = null;
            NewAuthorFirstName = string.Empty;
            NewAuthorLastName = string.Empty;
            NewCategoryName = string.Empty;
        }
    }

    partial void OnSelectedCategoryChanged(Category? oldValue, Category? newValue)
    {
        if (SelectedBook != null)
        {
            SelectedBook.CategoryId = newValue?.Id;
        }
    }

    partial void OnSelectedAuthorChanged(Author? oldValue, Author? newValue)
    {
        if (newValue != null && !SelectedAuthors.Contains(newValue))
            SelectedAuthors.Add(newValue);
    }

    [RelayCommand]
    private async Task AddBookAsync()
    {
        Validate();
        if (HasErrors) return;
        if (SelectedBook.Id != 0) return;
        _context.Books.Add(SelectedBook);
        await _context.SaveChangesAsync();

        // Dodaj powiązania BookAuthor
        foreach (var author in SelectedAuthors)
        {
            _context.Set<PO2_projekt.Models.BookAuthor>().Add(new PO2_projekt.Models.BookAuthor
            {
                BookId = SelectedBook.Id,
                AuthorId = author.Id
            });
        }
        await _context.SaveChangesAsync();

        await LoadBooksAsync();
        SelectedBook = new Book();
    }

    [RelayCommand]
    private async Task UpdateBookAsync()
    {
        Validate();
        if (HasErrors || SelectedBook?.Id == 0) return;

        // Pobierz książkę z bazy wraz z powiązaniami
        var book = await _context.Books
            .Include(b => b.BookAuthors)
            .FirstOrDefaultAsync(b => b.Id == SelectedBook.Id);

        if (book != null)
        {
            // Zaktualizuj właściwości
            book.Title = SelectedBook.Title;
            book.YearPublished = SelectedBook.YearPublished;
            book.Copies = SelectedBook.Copies;
            book.CategoryId = SelectedCategory?.Id;

            // Zaktualizuj autorów
            book.BookAuthors.Clear();
            foreach (var author in SelectedAuthors)
            {
                book.BookAuthors.Add(new PO2_projekt.Models.BookAuthor { BookId = book.Id, AuthorId = author.Id });
            }

            await _context.SaveChangesAsync();
            await LoadBooksAsync();
        }
    }

    [RelayCommand]
    private async Task DeleteBookAsync()
    {
        if (SelectedBook?.Id == 0) return;
        var isBorrowed = await _context.Borrowings.AnyAsync(b => b.BookId == SelectedBook.Id && !b.Returned);
        if (isBorrowed)
        {
            AddError(nameof(SelectedBook), "Nie można usunąć książki, która jest wypożyczona.");
            OnErrorsChanged(nameof(SelectedBook));
            return;
        }
        var book = await _context.Books.FindAsync(SelectedBook.Id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            await LoadBooksAsync();
            SelectedBook = new Book();
        }
    }

    [RelayCommand]
    private async Task AddAuthorAsync()
    {
        if (string.IsNullOrWhiteSpace(NewAuthorFirstName) || string.IsNullOrWhiteSpace(NewAuthorLastName))
            return;
        var existing = Authors.FirstOrDefault(a =>
            a.FirstName.Equals(NewAuthorFirstName, StringComparison.OrdinalIgnoreCase) &&
            a.LastName.Equals(NewAuthorLastName, StringComparison.OrdinalIgnoreCase));
        if (existing != null)
        {
            if (!SelectedAuthors.Contains(existing))
                SelectedAuthors.Add(existing);
            NewAuthorFirstName = string.Empty;
            NewAuthorLastName = string.Empty;
            return;
        }
        var author = new Author { FirstName = NewAuthorFirstName, LastName = NewAuthorLastName };
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
        Authors.Add(author);
        SelectedAuthors.Add(author);
        NewAuthorFirstName = string.Empty;
        NewAuthorLastName = string.Empty;
    }

    [RelayCommand]
    private async Task AddCategoryAsync()
    {
        if (string.IsNullOrWhiteSpace(NewCategoryName)) return;
        var existing = Categories.FirstOrDefault(c => c.Name.Equals(NewCategoryName, StringComparison.OrdinalIgnoreCase));
        if (existing != null)
        {
            SelectedCategory = existing;
            NewCategoryName = string.Empty;
            return;
        }
        var category = new Category { Name = NewCategoryName };
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        Categories.Add(category);
        SelectedCategory = category;
        NewCategoryName = string.Empty;
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

        if (SelectedBook == null)
        {
            AddError(nameof(SelectedBook), "Brak wybranej książki");
            OnErrorsChanged(nameof(SelectedBook));
            OnPropertyChanged(nameof(TitleError));
            OnPropertyChanged(nameof(YearPublishedError));
            OnPropertyChanged(nameof(CopiesError));
            OnPropertyChanged(nameof(AuthorError));
            OnPropertyChanged(nameof(CategoryError));
            return;
        }

        if (string.IsNullOrWhiteSpace(SelectedBook.Title))
            AddError(nameof(SelectedBook.Title), "Tytuł jest wymagany");

        if (SelectedBook.YearPublished < 1800 || SelectedBook.YearPublished > DateTime.Now.Year)
            AddError(nameof(SelectedBook.YearPublished), $"Rok musi być między 1800 a {DateTime.Now.Year}");

        if (SelectedBook.Copies < 1)
            AddError(nameof(SelectedBook.Copies), "Liczba kopii musi być ≥ 1");

        if (SelectedAuthors == null || SelectedAuthors.Count == 0)
            AddError("Authors", "Wymagany jest co najmniej jeden autor");

        if (SelectedCategory == null)
            AddError("Category", "Kategoria jest wymagana");

        OnErrorsChanged(nameof(SelectedBook));
        OnPropertyChanged(nameof(TitleError));
        OnPropertyChanged(nameof(YearPublishedError));
        OnPropertyChanged(nameof(CopiesError));
        OnPropertyChanged(nameof(AuthorError));
        OnPropertyChanged(nameof(CategoryError));
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

    public string TitleError => _errors.ContainsKey(nameof(SelectedBook.Title))
        ? string.Join(", ", _errors[nameof(SelectedBook.Title)])
        : string.Empty;

    public string YearPublishedError => _errors.ContainsKey(nameof(SelectedBook.YearPublished))
        ? string.Join(", ", _errors[nameof(SelectedBook.YearPublished)])
        : string.Empty;

    public string CopiesError => _errors.ContainsKey(nameof(SelectedBook.Copies))
        ? string.Join(", ", _errors[nameof(SelectedBook.Copies)])
        : string.Empty;

    public string AuthorError => _errors.ContainsKey("Authors") ? string.Join(", ", _errors["Authors"]) : string.Empty;
    public string CategoryError => _errors.ContainsKey("Category") ? string.Join(", ", _errors["Category"]) : string.Empty;

    #endregion

    public async Task InitializeAsync()
    {
        await LoadBooksAsync();
        await LoadCategoriesAsync();
        await LoadAuthorsAsync();
    }

    partial void OnAuthorFilterChanged(string value)
    {
        UpdateAuthorsFiltered();
        AuthorDropdownOpen = !string.IsNullOrWhiteSpace(value) && AuthorsFiltered.Count > 0;
    }

    private void UpdateAuthorsFiltered()
    {
        AuthorsFiltered.Clear();
        var filter = AuthorFilter?.ToLower() ?? string.Empty;
        foreach (var author in Authors)
        {
            if (string.IsNullOrWhiteSpace(filter) || author.FullName.ToLower().Contains(filter))
                AuthorsFiltered.Add(author);
        }
    }

    partial void OnCategoryFilterChanged(string value)
    {
        UpdateCategoriesFiltered();
        CategoryDropdownOpen = !string.IsNullOrWhiteSpace(value) && CategoriesFiltered.Count > 0;
    }

    private void UpdateCategoriesFiltered()
    {
        CategoriesFiltered.Clear();
        var filter = CategoryFilter?.ToLower() ?? string.Empty;
        foreach (var category in Categories)
        {
            if (string.IsNullOrWhiteSpace(filter) || category.Name.ToLower().Contains(filter))
                CategoriesFiltered.Add(category);
        }
    }

    [RelayCommand]
    private void NewBook()
    {
        SelectedBook = new Book();
        SelectedAuthor = null;
        SelectedCategory = null;
        NewAuthorFirstName = string.Empty;
        NewAuthorLastName = string.Empty;
        NewCategoryName = string.Empty;
    }
}