using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;

namespace Blocks.Converters;

public abstract class MathConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        return values.Aggregate(0.0, (d, o) => o is double n ? Op(d, n) : d);
    }
    
    protected abstract double Op(double a, double b);
}

public class AddConverter : MathConverter
{
    protected override double Op(double a, double b) => a + b;
}