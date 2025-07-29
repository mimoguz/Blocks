using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Blocks.ViewModels;

namespace Blocks.Views;

public partial class InputsPanelView : UserControl
{
    public InputsPanelView()
    {
        InitializeComponent();
        DataContext ??= new InputsPanelViewModel();
    }
    

    private void Spinner_OnSpin(object? sender, SpinEventArgs e)
    {
        var vm = (InputsPanelViewModel)DataContext!;
        if (e.Direction == SpinDirection.Increase)
        {
            vm.NextStringValue();
        } else
        {
            vm.PreviousStringValue();
        }
    }
}