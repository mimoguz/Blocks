using CommunityToolkit.Mvvm.ComponentModel;

namespace Blocks.DemoApp.ViewModels;

public partial class ButtonsPanelViewModel : ViewModelBase
{
    [ObservableProperty] private bool allEnabled = true;
    [ObservableProperty] private bool? allChecked = false;
}