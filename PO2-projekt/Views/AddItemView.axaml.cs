using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PO2_projekt.Views;

public partial class AddItemView : UserControl
{
    public AddItemView()
    {
        InitializeComponent();
        this.AttachedToVisualTree += async (s, e) =>
        {
            if (DataContext is PO2_projekt.ViewModels.AddItemViewModel vm)
            {
                await vm.InitializeAsync();
            }
        };
    }
}