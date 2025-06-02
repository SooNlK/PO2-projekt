using PO2_projekt.Data;
using System.Linq;
using System;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PO2_projekt.ViewModels;

public partial class DashboardViewModel : PageViewModel
{
    private readonly LibraryDbContext _dbContext;

    public int BooksCount { get; }
    public int ReadersCount { get; }
    public int BorrowingsCount { get; }

    public IEnumerable<ISeries> TodayBorrowingsSeries { get; }
    public IEnumerable<ISeries> TodayNewReadersSeries { get; }
    public IEnumerable<ISeries> MonthBorrowingsSeries { get; }
    public IEnumerable<ISeries> MonthNewReadersSeries { get; }
    public IEnumerable<ISeries> YearBorrowingsSeries { get; }
    public IEnumerable<ISeries> YearNewReadersSeries { get; }
    public IEnumerable<ISeries> TodayNewReadersColumnSeries { get; }
    public IEnumerable<ISeries> MonthNewReadersColumnSeries { get; }
    public IEnumerable<ISeries> YearNewReadersColumnSeries { get; }
    public IEnumerable<ISeries> TopCategoriesSeries { get; }
    public IEnumerable<ISeries> BorrowingsTrendSeries { get; }
    public string[] BorrowingsTrendLabels { get; }
    public IEnumerable<ISeries> NewReadersTrendSeries { get; }

    public List<TopBookDto> TopBooks { get; }
    public List<TopReaderDto> TopReaders { get; }
    public int OverdueCount { get; }
    public int DueThisWeekCount { get; }

    public DashboardViewModel(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
        PageName = ApplicationPageNames.Dashboard;
        BooksCount = _dbContext.Books.Count();
        ReadersCount = _dbContext.Readers.Count();
        BorrowingsCount = _dbContext.Borrowings.Count();

        var today = DateTime.UtcNow.Date;
        var weekEnd = today.AddDays(7);
        var monthStart = new DateTime(today.Year, today.Month, 1, 0, 0, 0, DateTimeKind.Utc);
        var yearStart = new DateTime(today.Year, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        // Borrowings
        int borrowingsToday = _dbContext.Borrowings.Count(b => b.BorrowDate.Date == today);
        int borrowingsMonth = _dbContext.Borrowings.Count(b => b.BorrowDate >= monthStart && b.BorrowDate <= today);
        int borrowingsYear = _dbContext.Borrowings.Count(b => b.BorrowDate >= yearStart && b.BorrowDate <= today);
        int borrowingsTotal = _dbContext.Borrowings.Count();

        // New Readers
        int newReadersToday = _dbContext.Readers.Count(r => r.CreateAt.Date == today);
        int newReadersMonth = _dbContext.Readers.Count(r => r.CreateAt >= monthStart && r.CreateAt <= today);
        int newReadersYear = _dbContext.Readers.Count(r => r.CreateAt >= yearStart && r.CreateAt <= today);
        int readersTotal = _dbContext.Readers.Count();

        // Najpopularniejsze książki (top 5)
        TopBooks = _dbContext.Borrowings
            .Include(b => b.Book)
            .Where(b => b.Book != null)
            .GroupBy(b => b.Book.Title)
            .Select(g => new TopBookDto { Title = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(5)
            .ToList();

        // Najaktywniejsi czytelnicy (top 5)
        TopReaders = _dbContext.Borrowings
            .Include(b => b.User)
            .Where(b => b.User != null)
            .ToList()
            .GroupBy(b => b.User.FullName)
            .Select(g => new TopReaderDto { Name = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(5)
            .ToList();

        // Liczba przeterminowanych wypożyczeń
        OverdueCount = _dbContext.Borrowings.Count(b => !b.Returned && b.ReturnDate.HasValue && b.ReturnDate.Value < DateTime.UtcNow);
        // Liczba wypożyczeń do zwrotu w tym tygodniu
        DueThisWeekCount = _dbContext.Borrowings.Count(b => !b.Returned && b.ReturnDate.HasValue && b.ReturnDate.Value >= today && b.ReturnDate.Value <= weekEnd);

        TodayBorrowingsSeries = new ISeries[]
        {
            new PieSeries<int> { Values = new[] { borrowingsToday }, Name = "Dziś" },
            new PieSeries<int> { Values = new[] { borrowingsTotal - borrowingsToday }, Name = "Reszta" }
        };
        TodayNewReadersSeries = new ISeries[]
        {
            new PieSeries<int> { Values = new[] { newReadersToday }, Name = "Dziś" },
            new PieSeries<int> { Values = new[] { readersTotal - newReadersToday }, Name = "Reszta" }
        };
        MonthBorrowingsSeries = new ISeries[]
        {
            new PieSeries<int> { Values = new[] { borrowingsMonth }, Name = "Ten miesiąc" },
            new PieSeries<int> { Values = new[] { borrowingsTotal - borrowingsMonth }, Name = "Reszta" }
        };
        MonthNewReadersSeries = new ISeries[]
        {
            new PieSeries<int> { Values = new[] { newReadersMonth }, Name = "Ten miesiąc" },
            new PieSeries<int> { Values = new[] { readersTotal - newReadersMonth }, Name = "Reszta" }
        };
        YearBorrowingsSeries = new ISeries[]
        {
            new PieSeries<int> { Values = new[] { borrowingsYear }, Name = "Ten rok" },
            new PieSeries<int> { Values = new[] { borrowingsTotal - borrowingsYear }, Name = "Reszta" }
        };
        YearNewReadersSeries = new ISeries[]
        {
            new PieSeries<int> { Values = new[] { newReadersYear }, Name = "Ten rok" },
            new PieSeries<int> { Values = new[] { readersTotal - newReadersYear }, Name = "Reszta" }
        };
        TodayNewReadersColumnSeries = new ISeries[]
        {
            new ColumnSeries<int> { Values = new[] { newReadersToday }, Name = "Dziś" },
            new ColumnSeries<int> { Values = new[] { readersTotal - newReadersToday }, Name = "Reszta" }
        };
        MonthNewReadersColumnSeries = new ISeries[]
        {
            new ColumnSeries<int> { Values = new[] { newReadersMonth }, Name = "Ten miesiąc" },
            new ColumnSeries<int> { Values = new[] { readersTotal - newReadersMonth }, Name = "Reszta" }
        };
        YearNewReadersColumnSeries = new ISeries[]
        {
            new ColumnSeries<int> { Values = new[] { newReadersYear }, Name = "Ten rok" },
            new ColumnSeries<int> { Values = new[] { readersTotal - newReadersYear }, Name = "Reszta" }
        };

        // Najpopularniejsze kategorie (top 5)
        var topCategories = _dbContext.Borrowings
            .Include(b => b.Book).ThenInclude(book => book.Category)
            .Where(b => b.Book != null && b.Book.Category != null)
            .GroupBy(b => b.Book.Category.Name)
            .Select(g => new { Category = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(5)
            .ToList();
        TopCategoriesSeries = topCategories
            .Select(cat => new PieSeries<int> { Values = new[] { cat.Count }, Name = cat.Category })
            .ToArray();

        // Trend wypożyczeń z ostatnich 14 dni
        var last14Days = Enumerable.Range(0, 14)
            .Select(i => DateTime.UtcNow.Date.AddDays(-13 + i))
            .ToList();
        var borrowingsPerDay = last14Days
            .Select(day => _dbContext.Borrowings.Count(b => b.BorrowDate.Date == day))
            .ToArray();
        BorrowingsTrendSeries = new ISeries[]
        {
            new LineSeries<int> { Values = borrowingsPerDay, Name = "Wypożyczenia" }
        };
        BorrowingsTrendLabels = last14Days.Select(d => d.ToString("dd.MM")).ToArray();

        // Trend nowych czytelników z ostatnich 14 dni
        var newReadersPerDay = last14Days
            .Select(day => _dbContext.Readers.Count(r => r.CreateAt.Date == day))
            .ToArray();
        NewReadersTrendSeries = new ISeries[]
        {
            new ColumnSeries<int> { Values = newReadersPerDay, Name = "Nowi czytelnicy" }
        };
    }    
}

public class TopBookDto
{
    public string Title { get; set; }
    public int Count { get; set; }
}
public class TopReaderDto
{
    public string Name { get; set; }
    public int Count { get; set; }
}