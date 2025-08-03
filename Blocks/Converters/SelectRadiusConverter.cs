using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Blocks.Converters;

public class SelectRadiusConverter(Func<CornerRadius, CornerRadius> select) : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is  CornerRadius radius ? select(radius) : null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
