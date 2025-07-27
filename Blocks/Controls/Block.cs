using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace Blocks.Controls;

public abstract class Block : AvaloniaObject
{
    public static readonly AttachedProperty<Thickness?> GapProperty = AvaloniaProperty.RegisterAttached<Block, Control, Thickness?>("Gap");
    public static readonly AttachedProperty<IBrush?> ScrollBarBackgroundProperty = AvaloniaProperty.RegisterAttached<Block, Control, IBrush?>("ScrollBarBackground");
    public static readonly AttachedProperty<IBrush?> ScrollBarForegroundProperty = AvaloniaProperty.RegisterAttached<Block, Control, IBrush?>("ScrollBarForeground");
    public static readonly AttachedProperty<AnimatedMenuIcon.IconStyle> MenuIconStyleProperty = AvaloniaProperty.RegisterAttached<Block, Control, AnimatedMenuIcon.IconStyle>("MenuIconStyle");
    public static readonly AttachedProperty<Stretch> StretchProperty = AvaloniaProperty.RegisterAttached<Block, Control, Stretch>("Stretch");
    public static readonly AttachedProperty<ScrollBarVisibility> ScrollBarVisibilityProperty = AvaloniaProperty.RegisterAttached<Block, Control, ScrollBarVisibility>("ScrollBarVisibility");

    public static Thickness? GetGap(Control control) => control.GetValue(GapProperty);
    public static void SetGap(Control control, Thickness? value) => control.SetValue(GapProperty, value);

    public static IBrush? GetScrollBarBackground(Control control) => control.GetValue(ScrollBarBackgroundProperty);
    public static void SetScrollBarBackground(Control control, IBrush? value) => control.SetValue(ScrollBarBackgroundProperty, value);

    public static IBrush? GetScrollBarForeground(Control control) => control.GetValue(ScrollBarForegroundProperty);
    public static void SetScrollBarForeground(Control control, IBrush? value) => control.SetValue(ScrollBarForegroundProperty, value);

    public static AnimatedMenuIcon.IconStyle GetMenuIconStyle(Control control) => control.GetValue(MenuIconStyleProperty);
    public static void SetMenuIconStyle(Control control, AnimatedMenuIcon.IconStyle value) => control.SetValue(MenuIconStyleProperty, value);

    public static Stretch GetStretch(Control control) => control.GetValue(StretchProperty);
    public static void SetStretch(Control control, Stretch value) => control.SetValue(StretchProperty, value);

    public static ScrollBarVisibility GetScrollBarVisibility(Control control) => control.GetValue(ScrollBarVisibilityProperty);
    public static void SetScrollBarVisibility(Control control, ScrollBarVisibility value) => control.SetValue(ScrollBarVisibilityProperty, value);
}