using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Blocks.ViewModels;

namespace Blocks.Views;

public partial class ButtonsPanelView : UserControl
{
    public ButtonsPanelView()
    {
        InitializeComponent();
        DataContext ??= new ButtonsPanelViewModel();
    }
}