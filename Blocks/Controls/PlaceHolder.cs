using System;
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

    public override void Render(DrawingContext context)
    {
        base.Render(context);
        var thickness = Math.Max(StrokeThickness, 1.0);
        var brush = StrokeBrush ?? Brushes.Black;
        var rect = new Rect(Bounds.Size).Deflate(thickness * 0.5);
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
    }
}