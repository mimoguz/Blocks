using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Blocks.ViewModels;

public partial class ContainersPageViewModel : ViewModelBase
{
    [ObservableProperty] private bool allEnabled = true;
    [ObservableProperty] private Dock dock = Dock.Top;
    
    
}