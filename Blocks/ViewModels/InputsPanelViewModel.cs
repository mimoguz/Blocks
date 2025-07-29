using System.Collections.Generic;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Blocks.ViewModels;

public partial class InputsPanelViewModel : ViewModelBase
{
    [ObservableProperty] private bool allEnabled = true;
    [ObservableProperty] private bool allChecked;
    [ObservableProperty] private string text = "";
    [ObservableProperty] private double currentDoubleValue = 5.0;

    private string? currentStringValue;

    public string? CurrentStringValue
    {
        get => currentStringValue;
        set
        {
            SetProperty(ref currentStringValue, value);
            CheckValidDirections();
        }
    }

    private ValidSpinDirections spin = ValidSpinDirections.Increase;

    public ValidSpinDirections Spin
    {
        get => spin;
        private set => SetProperty(ref spin, value);
    }

    public List<string> StringValues { get; } =
    [
        "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen",
        "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen", "Twenty"
    ];

    public double MinDoubleValue { get; } = 0.0;
    public double MaxDoubleValue { get; } = 10.0;

    public void NextStringValue()
    {
        var index = CurrentStringValue is null ? -1 : StringValues.IndexOf(CurrentStringValue);
        if (index < StringValues.Count - 1)
        {
            index++;
            CurrentStringValue = StringValues[index];
        }

    }

    public void PreviousStringValue()
    {
        var index = CurrentStringValue is null ? StringValues.Count : StringValues.IndexOf(CurrentStringValue);
        if (index > 0)
        {
            index--;
            CurrentStringValue = StringValues[index];
        }
    }

    private void CheckValidDirections()
    {
        var index = CurrentStringValue is null ? -1 : StringValues.IndexOf(CurrentStringValue);
        Spin = (index > 0 ? ValidSpinDirections.Decrease : ValidSpinDirections.None) |
               (index < StringValues.Count - 1 ? ValidSpinDirections.Increase : ValidSpinDirections.None);
    }
}