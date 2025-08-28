using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
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

    public void ShowInformationNotification(object? sender, RoutedEventArgs e) => ShowNotification(NotificationType.Information);
    public void ShowSuccessNotification(object? sender, RoutedEventArgs e) => ShowNotification(NotificationType.Success);
    public void ShowWarningNotification(object? sender, RoutedEventArgs e) => ShowNotification(NotificationType.Warning);
    public void ShowErrorNotification(object? sender, RoutedEventArgs e) => ShowNotification(NotificationType.Error);

    private void ShowNotification(NotificationType notificationType)
    {
        var wm = new WindowNotificationManager(TopLevel.GetTopLevel(this)!);
        var content = new TextBlock
        {
            Text = "Notification Card"
        };
        wm.Show(content, notificationType);
    }
}