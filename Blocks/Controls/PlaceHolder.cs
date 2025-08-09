using System;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace Blocks.Controls;

public class PlaceHolder : Control
{
    public static readonly StyledProperty<IBrush?> StrokeBrushProperty =
        AvaloniaProperty.Register<PlaceHolder, IBrush?>(nameof(StrokeBrush));

    public static readonly StyledProperty<double> StrokeThicknessProperty =
        AvaloniaProperty.Register<PlaceHolder, double>(nameof(StrokeThickness), 1.0);

    public static readonly StyledProperty<string?> TextProperty =
        AvaloniaProperty.Register<PlaceHolder, string?>(nameof(Text));

    public IBrush? StrokeBrush
    {
        get => GetValue(StrokeBrushProperty);
        set => SetValue(StrokeBrushProperty, value);
    }

    public double StrokeThickness
    {
        get => GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }

    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);
        var thickness = Math.Max(StrokeThickness, 1.0);
        var brush = StrokeBrush ?? Brushes.Black;
        var bounding = new Rect(Bounds.Size);
        var rect = bounding.Deflate(thickness * 0.5);
        var geometry = new StreamGeometry();

        using (var ctx = geometry.Open())
        {
            ctx.BeginFigure(rect.TopLeft, false);
            ctx.LineTo(rect.TopRight);
            ctx.LineTo(rect.BottomRight);
            ctx.LineTo(rect.BottomLeft);
            ctx.EndFigure(true);

            ctx.BeginFigure(rect.TopLeft, false);
            ctx.LineTo(rect.BottomRight);
            ctx.EndFigure(false);

            ctx.BeginFigure(rect.TopRight, false);
            ctx.LineTo(rect.BottomLeft);
            ctx.EndFigure(false);
        }

        var pen = new Pen(brush, thickness);
        context.DrawGeometry(pen.Brush, pen, geometry);

        // Draw text  --------------------------------------------------------------

        if (string.IsNullOrEmpty(Text))
        {
            return;
        }

        var text = Text ?? "";
        
        var formatted = new FormattedText(
            text, CultureInfo.CurrentCulture,
            CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
                ? FlowDirection.RightToLeft
                : FlowDirection.LeftToRight,
            Typeface.Default,
            13,
            brush
        );
        
        var textRect = new Rect(
            (rect.Width - formatted.Width) * 0.5, 4.0,
            formatted.Width, formatted.Height
        );
        
        context.DrawGeometry(pen.Brush, pen, geometry);
        context.DrawText(formatted, textRect.TopLeft);
    }
}