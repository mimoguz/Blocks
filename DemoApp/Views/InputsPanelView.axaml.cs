using Avalonia.Controls;
using InputsPanelViewModel = Blocks.DemoApp.ViewModels.InputsPanelViewModel;

namespace Blocks.DemoApp.Views;

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