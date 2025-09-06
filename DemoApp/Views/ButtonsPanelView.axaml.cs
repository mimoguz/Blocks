using Avalonia.Controls;
using Blocks.DemoApp.ViewModels;

namespace Blocks.DemoApp.Views;

public partial class ButtonsPanelView : UserControl
{
    public ButtonsPanelView()
    {
        InitializeComponent();
        DataContext ??= new ButtonsPanelViewModel();
    }
}