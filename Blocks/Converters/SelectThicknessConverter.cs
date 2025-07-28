using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Blocks.Converters;

public abstract class SelectThicknessConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is not Thickness thickness ? null : Select(thickness);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }

    protected abstract Thickness Select(Thickness thickness);
}

public class LeftThicknessConverter : SelectThicknessConverter
{
    protected override Thickness Select(Thickness thickness) => new(thickness.Left, 0, 0, 0);
}

public class RightThicknessConverter : SelectThicknessConverter
{
    protected override Thickness Select(Thickness thickness) => new(0, 0, thickness.Right, 0);
}

public class TopThicknessConverter : SelectThicknessConverter
{
    protected override Thickness Select(Thickness thickness) => new(0, thickness.Top, 0, 0);
}

public class BottomThicknessConverter : SelectThicknessConverter
{
    protected override Thickness Select(Thickness thickness) => new(0, 0, 0, thickness.Bottom);
}

public class HorizontalThicknessConverter : SelectThicknessConverter
{
    protected override Thickness Select(Thickness thickness) => new(thickness.Left, 0, thickness.Right, 0);
}

public class VerticalThicknessConverter : SelectThicknessConverter
{
    protected override Thickness Select(Thickness thickness) => new(0, thickness.Top, 0, thickness.Bottom);
}

public class ClearBottomThicknessConverter : SelectThicknessConverter
{
    protected override Thickness Select(Thickness thickness) => new(thickness.Left, thickness.Top, thickness.Right, 0.0);
}

public class ClearLeftThicknessConverter : SelectThicknessConverter
{
    protected override Thickness Select(Thickness thickness) => new(0, thickness.Top, thickness.Right, thickness.Bottom);
}