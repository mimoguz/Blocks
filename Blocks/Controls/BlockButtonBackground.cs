using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace Blocks.Controls;

public class BlockButtonBackground : TemplatedControl
{
    public static readonly StyledProperty<bool> HighlightedProperty =
        AvaloniaProperty.Register<BlockButton, bool>(nameof(Highlighted));

    public bool Highlighted
    {
        get => GetValue(HighlightedProperty);
        set => SetValue(HighlightedProperty, value);
    }
    
    public static readonly StyledProperty<bool> ShadedProperty =
        AvaloniaProperty.Register<BlockButton, bool>(nameof(Shaded));

    public bool Shaded
    {
        get => GetValue(ShadedProperty);
        set => SetValue(ShadedProperty, value);
    }
    
    public static readonly StyledProperty<bool> SelectedProperty =
        AvaloniaProperty.Register<BlockButton, bool>(nameof(Selected));
    
    public bool Selected
    {
        get => GetValue(SelectedProperty);
        set => SetValue(SelectedProperty, value);
    }
    
    public static readonly StyledProperty<bool> FocusedProperty =
        AvaloniaProperty.Register<BlockButton, bool>(nameof(Focused));

    public bool Focused
    {
        get => GetValue(FocusedProperty);
        set => SetValue(FocusedProperty, value);
    }
    
    public static readonly StyledProperty<IBrush?> FocusBrushProperty =
        AvaloniaProperty.Register<BlockButton, IBrush?>(nameof(FocusBrush));

    public IBrush? FocusBrush
    {
        get => GetValue(FocusBrushProperty);
        set => SetValue(FocusBrushProperty, value);
    }
    
    public static readonly StyledProperty<IBrush?> SelectedBackgroundBrushProperty =
        AvaloniaProperty.Register<BlockButton, IBrush?>(nameof(SelectedBackgroundBrush));

    public IBrush? SelectedBackgroundBrush
    {
        get => GetValue(SelectedBackgroundBrushProperty);
        set => SetValue(SelectedBackgroundBrushProperty, value);
    }
    
    public static readonly StyledProperty<IBrush?> SelectedFocusBrushProperty =
        AvaloniaProperty.Register<BlockButton, IBrush?>(nameof(SelectedFocusBrush));

    public IBrush? SelectedFocusBrush
    {
        get => GetValue(SelectedFocusBrushProperty);
        set => SetValue(SelectedFocusBrushProperty, value);
    }
    
    public static readonly StyledProperty<BlockButtonStyle> ButtonStyleProperty =
        AvaloniaProperty.Register<BlockButton, BlockButtonStyle>(nameof(ButtonStyle));

    public BlockButtonStyle ButtonStyle
    {
        get => GetValue(ButtonStyleProperty);
        set => SetValue(ButtonStyleProperty, value);
    }
}

public enum BlockButtonStyle
{
    Semitransparent,
    Flat,
    Opaque,
    Outlined
}