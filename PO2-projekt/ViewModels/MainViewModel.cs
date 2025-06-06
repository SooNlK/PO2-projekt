using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PO2_projekt.Data;
using PO2_projekt.Factories;

namespace PO2_projekt.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private PageFactory _pageFactory;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomeIsActive))]
    [NotifyPropertyChangedFor(nameof(AddItemIsActive))]
    [NotifyPropertyChangedFor(nameof(AddMemberIsActive))]
    [NotifyPropertyChangedFor(nameof(BorrowIsActive))]
    [NotifyPropertyChangedFor(nameof(ReturnIsActive))]
    [NotifyPropertyChangedFor(nameof(SearchIsActive))]
    private PageViewModel _currentPage;
    
    public bool HomeIsActive => CurrentPage.PageName == ApplicationPageNames.Dashboard;
    public bool AddItemIsActive => CurrentPage.PageName == ApplicationPageNames.AddItem;
    public bool AddMemberIsActive => CurrentPage.PageName == ApplicationPageNames.AddMember;
    public bool BorrowIsActive => CurrentPage.PageName == ApplicationPageNames.Borrow;
    public bool ReturnIsActive => CurrentPage.PageName == ApplicationPageNames.Return;
    public bool SearchIsActive => CurrentPage.PageName == ApplicationPageNames.Search;
    
    public MainViewModel(PageFactory pageFactory)
    {
        _pageFactory = pageFactory;
        
        GoToHome();
    }

    [RelayCommand]
    private void GoToHome() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Dashboard);
    
    [RelayCommand]
    private void GoToAddItem() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.AddItem);
    
    [RelayCommand]
    private void GoToAddMember() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.AddMember);
    
    [RelayCommand]
    private void GoToBorrow() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Borrow);
    
    [RelayCommand]
    private void GoToReturn() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Return);
    
    [RelayCommand]
    private async void GoToSearch()
    {
        var vm = _pageFactory.GetPageViewModel(ApplicationPageNames.Search);
        if (vm is SearchViewModel svm)
            await svm.InitializeAsync();
        CurrentPage = vm;
    }
    
    [RelayCommand]
    private void GoToReports() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Reports);
}