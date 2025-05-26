using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PO2_projekt.Views;

public partial class AddMemberView : UserControl
{
    public AddMemberView()
    {
        InitializeComponent();
        this.AttachedToVisualTree += async (s, e) =>
        {
            if (DataContext is PO2_projekt.ViewModels.AddMemberViewModel vm)
            {
                await vm.InitializeAsync();
            }
        };
    }
}