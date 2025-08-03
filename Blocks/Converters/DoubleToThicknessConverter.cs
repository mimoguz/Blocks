using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Blocks.Converters;

public class DoubleToThicknessConverter(Func<double, Thickness> toThickness): IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is double d ? toThickness(d) : null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}