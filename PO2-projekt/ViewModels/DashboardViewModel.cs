using PO2_projekt.Data;
using System.Linq;
using System;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.Generic;

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

    public DashboardViewModel(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
        PageName = ApplicationPageNames.Dashboard;
        BooksCount = _dbContext.Books.Count();
        ReadersCount = _dbContext.Readers.Count();
        BorrowingsCount = _dbContext.Borrowings.Count();

        var today = DateTime.UtcNow.Date;
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
    }    
}