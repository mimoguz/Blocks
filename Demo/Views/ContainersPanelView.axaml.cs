using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Blocks.ViewModels;

namespace Blocks.Views;

public partial class ContainersPanelView : UserControl
{
    public ContainersPanelView()
    {
        InitializeComponent();
        DataContext ??= new ContainersPanelViewModel();
    }
}