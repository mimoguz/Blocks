using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Blocks.ViewModels;

namespace Blocks.Views;

public partial class BitsPanelView : UserControl
{
    public BitsPanelView()
    {
        InitializeComponent();
        DataContext ??= new BitsPanelViewModel();
    }
}