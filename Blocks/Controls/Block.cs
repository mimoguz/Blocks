using Avalonia;
using Avalonia.Controls;

namespace Blocks.Controls;

public abstract class Block : AvaloniaObject
{
    public static readonly AttachedProperty<Thickness?> GapProperty =
        AvaloniaProperty.RegisterAttached<Block, Control, Thickness?>("Gap");

    public static Thickness? GetGap(Control control) => control.GetValue(GapProperty);
    public static void SetGap(Control control, Thickness? value) => control.SetValue(GapProperty, value);
}