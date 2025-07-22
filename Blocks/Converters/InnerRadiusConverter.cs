using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Blocks.Converters;

public class InnerRadiusConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values is not [CornerRadius outer, ..])
        {
            return null;
        }

        var collected = outer;
        for (var i = 1; i < values.Count; i++)
        {
            collected = values[i] switch
            {
                Thickness t => collected = new CornerRadius(
                    collected.TopLeft - t.Left,
                    collected.TopRight - t.Right,
                    collected.BottomRight - t.Right,
                    collected.BottomLeft - t.Left
                ),
                double n => collected = new CornerRadius(
                    collected.TopLeft - n,
                    collected.TopRight - n,
                    collected.BottomRight - n,
                    collected.BottomLeft - n
                    ),
                int n => collected = new CornerRadius(
                    collected.TopLeft - n,
                    collected.TopRight - n,
                    collected.BottomRight - n,
                    collected.BottomLeft - n
                ),
                string s when double.TryParse(s, out var n) => collected = new CornerRadius(
                collected.TopLeft - n,
                collected.TopRight - n,
                collected.BottomRight - n,
                collected.BottomLeft - n
            ),
                _ => collected
            };
        }
        return collected;
    }
}