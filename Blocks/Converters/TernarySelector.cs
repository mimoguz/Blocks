using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Blocks.Converters;

public class TernarySelector : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values is not [bool condition, var a, var b, ..])
        {
            return null;
        }
        return condition ? a : b;
    }
    
    public static TernarySelector Instance { get; } = new();
}