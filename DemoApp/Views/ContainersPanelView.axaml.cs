using Avalonia.Controls;
using ContainersPanelViewModel = Blocks.DemoApp.ViewModels.ContainersPanelViewModel;

namespace Blocks.DemoApp.Views;

public partial class ContainersPanelView : UserControl
{
    public ContainersPanelView()
    {
        InitializeComponent();
        DataContext ??= new ContainersPanelViewModel();
    }
}