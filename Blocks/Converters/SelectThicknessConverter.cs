using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Blocks.Converters;

public class SelectThicknessConverter(Func<Thickness, Thickness> select) : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is not Thickness thickness ? null : select(thickness);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
