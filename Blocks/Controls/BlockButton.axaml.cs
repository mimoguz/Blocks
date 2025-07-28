using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace Blocks.Controls;

public class BlockButton : TemplatedControl
{
    public static readonly StyledProperty<bool> HighlightedProperty =
        AvaloniaProperty.Register<AnimatedDot, bool>(nameof(Highlighted));

    public bool Highlighted
    {
        get => GetValue(HighlightedProperty);
        set => SetValue(HighlightedProperty, value);
    }
    
    public static readonly StyledProperty<bool> ShadedProperty =
        AvaloniaProperty.Register<AnimatedDot, bool>(nameof(Shaded));

    public bool Shaded
    {
        get => GetValue(ShadedProperty);
        set => SetValue(ShadedProperty, value);
    }
    
    public static readonly StyledProperty<bool> FocusedProperty =
        AvaloniaProperty.Register<AnimatedDot, bool>(nameof(Focused));

    public bool Focused
    {
        get => GetValue(FocusedProperty);
        set => SetValue(FocusedProperty, value);
    }
    
    public static readonly StyledProperty<bool> OpaqueProperty =
        AvaloniaProperty.Register<AnimatedDot, bool>(nameof(Opaque));

    public bool Opaque
    {
        get => GetValue(OpaqueProperty);
        set => SetValue(OpaqueProperty, value);
    }
    
    public static readonly StyledProperty<bool> FlatProperty =
        AvaloniaProperty.Register<AnimatedDot, bool>(nameof(Flat));

    public bool Flat
    {
        get => GetValue(FlatProperty);
        set => SetValue(FlatProperty, value);
    }
}