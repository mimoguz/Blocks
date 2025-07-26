using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace Blocks.Controls;

public class AnimatedMenuIcon : TemplatedControl
{
    public static readonly StyledProperty<bool> DrawExpandedProperty =
        AvaloniaProperty.Register<AnimatedMenuIcon, bool>(nameof(DrawExpanded));

    public bool DrawExpanded
    {
        get => GetValue(DrawExpandedProperty);
        set => SetValue(DrawExpandedProperty, value);
    }

    public static readonly StyledProperty<IconStyle> MenuIconStyleProperty =
        AvaloniaProperty.Register<AnimatedMenuIcon, IconStyle>(nameof(MenuIconStyle));

    public IconStyle MenuIconStyle
    {
        get => GetValue(MenuIconStyleProperty);
        set => SetValue(MenuIconStyleProperty, value);
    }

    public enum IconStyle
    {
        Burger,
        Chevron
    }
}