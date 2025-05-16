using CommunityToolkit.Mvvm.ComponentModel;
using PO2_projekt.Data;

namespace PO2_projekt.ViewModels;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty]
    private ApplicationPageNames _pageName;
}