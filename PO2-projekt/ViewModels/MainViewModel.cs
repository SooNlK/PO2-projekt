using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PO2_projekt.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomeIsActive))]
    [NotifyPropertyChangedFor(nameof(AddItemIsActive))]
    [NotifyPropertyChangedFor(nameof(AddMemberIsActive))]
    [NotifyPropertyChangedFor(nameof(BorrowIsActive))]
    [NotifyPropertyChangedFor(nameof(ReturnIsActive))]
    [NotifyPropertyChangedFor(nameof(SearchIsActive))]
    [NotifyPropertyChangedFor(nameof(ReportsIsActive))]
    private ViewModelBase _currentPage;
    
    public bool HomeIsActive => CurrentPage == _dashboardPage;
    public bool AddItemIsActive => CurrentPage == _addItemPage;
    public bool AddMemberIsActive => CurrentPage == _addMemberPage;
    public bool BorrowIsActive => CurrentPage == _borrowPage;
    public bool ReturnIsActive => CurrentPage == _returnPage;
    public bool SearchIsActive => CurrentPage == _searchPage;
    public bool ReportsIsActive => CurrentPage == _reportsPage;
    
    private readonly DashboardViewModel _dashboardPage = new ();
    private readonly AddItemViewModel _addItemPage = new ();
    private readonly AddItemViewModel _addMemberPage = new ();
    private readonly AddItemViewModel _borrowPage = new ();
    private readonly AddItemViewModel _returnPage = new ();
    private readonly AddItemViewModel _searchPage = new ();
    private readonly AddItemViewModel _reportsPage = new ();

    public MainViewModel()
    {
        CurrentPage = _dashboardPage;
    }

    [RelayCommand]
    private void GoToHome() => CurrentPage = _dashboardPage;
    
    [RelayCommand]
    private void GoToAddItem() => CurrentPage = _addItemPage;
    
    [RelayCommand]
    private void GoToAddMember() => CurrentPage = _addMemberPage;
    
    [RelayCommand]
    private void GoToBorrowr() => CurrentPage = _borrowPage;
    
    [RelayCommand]
    private void GoToReturn() => CurrentPage = _returnPage;
    
    [RelayCommand]
    private void GoToSearch() => CurrentPage = _searchPage;
    
    [RelayCommand]
    private void GoToReports() => CurrentPage = _reportsPage;
}