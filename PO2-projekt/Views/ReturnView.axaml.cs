using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PO2_projekt.Views;

public partial class ReturnView : UserControl
{
    public ReturnView()
    {
        InitializeComponent();
        this.AttachedToVisualTree += async (s, e) =>
        {
            if (DataContext is PO2_projekt.ViewModels.ReturnViewModel vm)
            {
                await vm.InitializeAsync();
            }
        };
    }
}