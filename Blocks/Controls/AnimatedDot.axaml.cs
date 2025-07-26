using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace Blocks.Controls;

public class AnimatedDot : TemplatedControl
{
    public static readonly StyledProperty<bool> DrawExpandedProperty =
        AvaloniaProperty.Register<AnimatedDot, bool>(nameof(DrawExpanded));

    public bool DrawExpanded
    {
        get => GetValue(DrawExpandedProperty);
        set => SetValue(DrawExpandedProperty, value);
    }
    
    public static readonly StyledProperty<double> BackgroundOpacityProperty =
        AvaloniaProperty.Register<AnimatedDot, double>(nameof(BackgroundOpacity));

    public double BackgroundOpacity
    {
        get => GetValue(BackgroundOpacityProperty);
        set => SetValue(BackgroundOpacityProperty, value);
    }
}