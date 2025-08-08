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

    public static readonly StyledProperty<AnimatedMenuIconStyle> MenuIconStyleProperty =
        AvaloniaProperty.Register<AnimatedMenuIcon, AnimatedMenuIconStyle>(nameof(MenuIconStyle));

    public AnimatedMenuIconStyle MenuIconStyle
    {
        get => GetValue(MenuIconStyleProperty);
        set => SetValue(MenuIconStyleProperty, value);
    }

    
}

public enum AnimatedMenuIconStyle
{
    Burger,
    Chevron,
    RightChevron,
}