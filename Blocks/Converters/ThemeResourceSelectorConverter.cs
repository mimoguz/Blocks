using System;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Styling;

namespace Blocks.Converters;

public class ThemeResourceSelectorConverter : ResourceDictionary, IValueConverter
{
    public object? Convert(object? key, Type targetType, object? parameter, CultureInfo culture)
    {
        var themeKey = $"{Application.Current?.ActualThemeVariant ?? ThemeVariant.Light}_{key!}";
        TryGetResource(themeKey, null, out var value);
        return value;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}