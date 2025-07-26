using Avalonia;
using Avalonia.Controls;

namespace Blocks.Controls;

public abstract class Block : AvaloniaObject
{
    public static readonly AttachedProperty<Thickness?> GapProperty =
        AvaloniaProperty.RegisterAttached<Block, Control, Thickness?>("Gap");

    public static Thickness? GetGap(Control control) => control.GetValue(GapProperty);
    public static void SetGap(Control control, Thickness? value) => control.SetValue(GapProperty, value);

    public static readonly AttachedProperty<bool> CheckedProperty =
        AvaloniaProperty.RegisterAttached<Block, Control, bool>("Checked");

    public static bool GetChecked(Control control) => control.GetValue(CheckedProperty);
    public static void SetChecked(Control control, bool value) => control.SetValue(CheckedProperty, value);

    public static readonly AttachedProperty<AnimatedMenuIcon.IconStyle> MenuIconStyleProperty =
        AvaloniaProperty.RegisterAttached<Block, Control, AnimatedMenuIcon.IconStyle>("MenuIconStyle");

    public static AnimatedMenuIcon.IconStyle GetMenuIconStyle(Control control) =>
        control.GetValue(MenuIconStyleProperty);

    public static void SetMenuIconStyle(Control control, AnimatedMenuIcon.IconStyle value) =>
        control.SetValue(MenuIconStyleProperty, value);
}