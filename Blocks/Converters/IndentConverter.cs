using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Blocks.Converters;

public class IndentConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values is not [int level, double indent, ..])
        {
            return null;
        }

        return new Thickness(indent * level, 0.0, 0.0, 0.0);
    }
}