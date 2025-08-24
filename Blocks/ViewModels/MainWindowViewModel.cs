using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.Input;

namespace Blocks.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [RelayCommand]
    private void OpenFile()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow?.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions()
            {
                AllowMultiple = true,
                Title = "File Picker",
                FileTypeFilter = [FilePickerFileTypes.TextPlain, FilePickerFileTypes.Pdf]
            });
        }
    }
}