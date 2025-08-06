using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace Blocks.Controls;

public class AnimatedTreeIcon : TemplatedControl
{
    public static readonly StyledProperty<bool> DrawExpandedProperty =
        AvaloniaProperty.Register<AnimatedDot, bool>(nameof(DrawExpanded));

    public bool DrawExpanded
    {
        get => GetValue(DrawExpandedProperty);
        set => SetValue(DrawExpandedProperty, value);
    }
}