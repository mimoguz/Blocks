using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Blocks.DemoApp.ViewModels;

public partial class ContainersPanelViewModel : ViewModelBase
{
    [ObservableProperty] private bool allEnabled = true;
    [ObservableProperty] private Dock dock = Dock.Top;
    [ObservableProperty] private SplitViewDisplayMode splitViewDisplayMode = SplitViewDisplayMode.Inline;
    [ObservableProperty] private SplitViewPanePlacement splitViewPanePlacement = SplitViewPanePlacement.Left;
    
    public List<Dock> DockOptions { get; } = Enum.GetValues<Dock>().ToList();
    public List<SplitViewDisplayMode> SplitViewDisplayModes { get; } = Enum.GetValues<SplitViewDisplayMode>().ToList();
    public List<SplitViewPanePlacement> SplitViewPanePlacements { get; } = Enum.GetValues<SplitViewPanePlacement>().ToList();
}