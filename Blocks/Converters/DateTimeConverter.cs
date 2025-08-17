using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Blocks.Converters;

public class DateTimeConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value is DateTime dt ? new DateTimeOffset(dt) : null;

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value is DateTimeOffset dto ? dto.DateTime : null;
}