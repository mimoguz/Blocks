using CommunityToolkit.Mvvm.ComponentModel;

namespace Blocks.ViewModels;

public partial class BitsPanelViewModel : ViewModelBase
{
    [ObservableProperty] bool allEnabled = true;
    [ObservableProperty] private double progress = 20.0;
}