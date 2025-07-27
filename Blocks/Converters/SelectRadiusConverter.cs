using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Blocks.Converters;

public abstract class SelectRadiusConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is  CornerRadius radius ? Select(radius) : null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }

    protected abstract CornerRadius Select(CornerRadius radius);
}

public class LeftRadiusConverter : SelectRadiusConverter
{
    protected override CornerRadius Select(CornerRadius radius) => new(radius.TopLeft, 0, 0, radius.BottomLeft);
}

public class RightRadiusConverter : SelectRadiusConverter
{
    protected override CornerRadius Select(CornerRadius radius) => new(0, radius.TopRight, radius.BottomRight, 0.0);
}

public class TopRadiusConverter : SelectRadiusConverter
{
    protected override CornerRadius Select(CornerRadius radius) => new(radius.TopLeft, radius.TopRight, 0, 0);
}

public class BottomRadiusConverter : SelectRadiusConverter
{
    protected override CornerRadius Select(CornerRadius radius) => new(0, 0, radius.BottomLeft, radius.BottomRight);
}