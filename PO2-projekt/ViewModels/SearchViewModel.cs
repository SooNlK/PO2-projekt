using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using PO2_projekt.Data;
using PO2_projekt.Models;

namespace PO2_projekt.ViewModels;

public partial class SearchViewModel : PageViewModel
{
    private readonly LibraryDbContext _context;
    [ObservableProperty] private string _searchTitle;
    [ObservableProperty] private string _searchAuthor;
    [ObservableProperty] private Category _searchCategory;
    [ObservableProperty] private bool _onlyAvailable;
    public ObservableCollection<Category> Categories { get; } = new();
    public ObservableCollection<Book> SearchResults { get; } = new();

    public SearchViewModel(LibraryDbContext context)
    {
        _context = context;
        PageName = ApplicationPageNames.Search;
    }

    public async Task InitializeAsync()
    {
        await LoadCategoriesAsync();
        await SearchAsync();
    }

    [RelayCommand]
    private async Task LoadCategoriesAsync()
    {
        var categories = await _context.Categories.AsNoTracking().ToListAsync();
        Categories.Clear();
        foreach (var c in categories)
            Categories.Add(c);
    }

    [RelayCommand]
    public async Task SearchAsync()
    {
        var query = _context.Books
            .Include(b => b.Category)
            .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(SearchTitle))
            query = query.Where(b => b.Title.ToLower().Contains(SearchTitle.ToLower()));
        if (!string.IsNullOrWhiteSpace(SearchAuthor))
            query = query.Where(b => b.BookAuthors.Any(ba => (ba.Author.FirstName + " " + ba.Author.LastName).ToLower().Contains(SearchAuthor.ToLower())));
        if (SearchCategory != null)
            query = query.Where(b => b.CategoryId == SearchCategory.Id);
        if (OnlyAvailable)
            query = query.Where(b => b.Copies > 0);

        var results = await query.ToListAsync();
        SearchResults.Clear();
        foreach (var b in results)
            SearchResults.Add(b);
    }

    [RelayCommand]
    public async Task ClearFiltersAsync()
    {
        SearchTitle = string.Empty;
        SearchAuthor = string.Empty;
        SearchCategory = null;
        OnlyAvailable = false;
        await SearchAsync();
    }
}