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

public partial class AddMemberViewModel : PageViewModel, INotifyDataErrorInfo
{
    private readonly LibraryDbContext _context;
    private readonly Dictionary<string, string> _errors = new();

    public AddMemberViewModel(LibraryDbContext context)
    {
        _context = context;
        Readers = new ObservableCollection<Reader>();
        SelectedReader = new Reader();
        PageName = ApplicationPageNames.AddMember;
    }

    public ObservableCollection<Reader> Readers { get; }

    [ObservableProperty] private Reader _selectedReader;

    [RelayCommand]
    private async Task LoadReadersAsync()
    {
        var readers = await _context.Readers.AsNoTracking().ToListAsync();
        Readers.Clear();
        foreach (var reader in readers)
            Readers.Add(reader);
    }

    [RelayCommand]
    private async Task AddReaderAsync()
    {
        Validate();
        if (HasErrors) return;
        if (SelectedReader.Id != 0) return;
        _context.Readers.Add(SelectedReader);
        await _context.SaveChangesAsync();
        Readers.Add(SelectedReader);
        SelectedReader = new Reader();
    }

    [RelayCommand]
    private async Task UpdateReaderAsync()
    {
        Validate();
        if (HasErrors || SelectedReader?.Id == 0) return;
        _context.Readers.Update(SelectedReader);
        await _context.SaveChangesAsync();
        await LoadReadersAsync();
    }

    [RelayCommand]
    private async Task DeleteReaderAsync()
    {
        if (SelectedReader?.Id == 0) return;
        _context.Readers.Remove(SelectedReader);
        await _context.SaveChangesAsync();
        Readers.Remove(SelectedReader);
        SelectedReader = new Reader();
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
        if (string.IsNullOrWhiteSpace(SelectedReader.FirstName))
            _errors[nameof(SelectedReader.FirstName)] = "Imię jest wymagane";
        if (string.IsNullOrWhiteSpace(SelectedReader.LastName))
            _errors[nameof(SelectedReader.LastName)] = "Nazwisko jest wymagane";
        if (string.IsNullOrWhiteSpace(SelectedReader.Email) || !SelectedReader.Email.Contains("@"))
            _errors[nameof(SelectedReader.Email)] = "Email jest wymagany i musi być poprawny";
        OnErrorsChanged(nameof(SelectedReader.FirstName));
        OnErrorsChanged(nameof(SelectedReader.LastName));
        OnErrorsChanged(nameof(SelectedReader.Email));
        OnPropertyChanged(nameof(FirstNameError));
        OnPropertyChanged(nameof(LastNameError));
        OnPropertyChanged(nameof(EmailError));
    }
    private void OnErrorsChanged(string propertyName)
        => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    public string FirstNameError => _errors.ContainsKey(nameof(SelectedReader.FirstName)) ? _errors[nameof(SelectedReader.FirstName)] : string.Empty;
    public string LastNameError => _errors.ContainsKey(nameof(SelectedReader.LastName)) ? _errors[nameof(SelectedReader.LastName)] : string.Empty;
    public string EmailError => _errors.ContainsKey(nameof(SelectedReader.Email)) ? _errors[nameof(SelectedReader.Email)] : string.Empty;
    #endregion

    public async Task InitializeAsync()
    {
        await LoadReadersAsync();
    }

    partial void OnSelectedReaderChanged(Reader? oldValue, Reader? newValue)
    {
        // Możesz dodać dodatkową logikę przy zmianie zaznaczonego czytelnika
    }
}