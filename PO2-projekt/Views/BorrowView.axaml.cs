using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PO2_projekt.Views;

public partial class BorrowView : UserControl
{
    public BorrowView()
    {
        InitializeComponent();
        this.AttachedToVisualTree += async (s, e) =>
        {
            if (DataContext is PO2_projekt.ViewModels.BorrowViewModel vm)
            {
                await vm.InitializeAsync();
            }
        };
    }
}