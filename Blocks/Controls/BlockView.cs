using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace Blocks.Controls;

public class BlockView : TemplatedControl
{
    public static readonly StyledProperty<bool> HighlightedProperty =
        AvaloniaProperty.Register<BlockView, bool>(nameof(Highlighted));

    public bool Highlighted
    {
        get => GetValue(HighlightedProperty);
        set => SetValue(HighlightedProperty, value);
    }
    
    public static readonly StyledProperty<bool> FocusedProperty =
        AvaloniaProperty.Register<BlockView, bool>(nameof(Focused));

    public bool Focused
    {
        get => GetValue(FocusedProperty);
        set => SetValue(FocusedProperty, value);
    }
    
    public static readonly StyledProperty<bool> ErrorProperty =
        AvaloniaProperty.Register<BlockView, bool>(nameof(Error));

    public bool Error
    {
        get => GetValue(ErrorProperty);
        set => SetValue(ErrorProperty, value);
    }
}