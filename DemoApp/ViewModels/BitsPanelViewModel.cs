using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Blocks.DemoApp.ViewModels;

public partial class BitsPanelViewModel : ViewModelBase
{
    [ObservableProperty] private bool allEnabled = true;
    [ObservableProperty] private double progress = 20.0;
    [ObservableProperty] private bool active;

    private string commandOutput = "Click me";

    public string CommandOutput
    {
        get => commandOutput;
        private set => SetProperty(ref commandOutput, value);
    }

    [RelayCommand]
    private void TileAction()
    {
        CommandOutput = $"The tile clicked at {DateTime.Now:HH:mm:ss}";
    }
}