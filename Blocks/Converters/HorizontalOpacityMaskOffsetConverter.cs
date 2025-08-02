using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Blocks.Converters;

public class HorizontalOpacityMaskOffsetConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not Rect bounds)
        {
            return null;
        }

        var absoluteOffset = parameter switch
        {
            double d => d,
            string s when double.TryParse(s, out var d) => d,
            _ => 0.0
        };
        
        var relativeOffset = Math.Abs(absoluteOffset) / bounds.Width;
        return absoluteOffset > 0 ? relativeOffset : 1 - relativeOffset;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
    
    public static HorizontalOpacityMaskOffsetConverter Instance { get; } = new();
}