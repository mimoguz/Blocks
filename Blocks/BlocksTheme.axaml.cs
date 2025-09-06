using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace Blocks;

public class BlocksTheme : Style
{
    public BlocksTheme()
    {
        AvaloniaXamlLoader.Load(this);
    }
}