using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;

namespace Blocks.Converters;

public class MathConverter(Func<double, double, double> op) : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        return values.Aggregate(0.0, (d, o) => o is double n ? op(d, n) : d);
    }
    
}
