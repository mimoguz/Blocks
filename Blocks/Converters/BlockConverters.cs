using System;
using Avalonia;
using Avalonia.Data.Converters;

namespace Blocks.Converters;

public static class BlockConverters
{
    
    /// <summary>
    /// A multi-value converter that takes multiple 'double' parameters and returns the sum of them.
    /// </summary>
    public static readonly MathConverter Sum = new MathConverter((a, b) => a + b);
    
    /// <summary>
    /// A multi-value converter that takes a CornerRadius and then a series of Thickness parameters
    /// to calculate the corner radius of a control inside another.
    /// </summary>
    public static readonly InnerRadiusConverter InnerRadius = new InnerRadiusConverter();
    
    /// <summary>
    /// A multi-value converter that takes a bool parameter and then two object parameters and returns
    /// the first object if the bool value is true, the second if false.
    /// </summary>
    public static readonly TernaryConverter Ternary = new TernaryConverter();
    
    /// <summary>
    /// A value converter that takes a CornerRadius and leaves only the top radius values, clearing the others.
    /// </summary>
    public static readonly SelectRadiusConverter SelectTopRadius = new((r) => new CornerRadius(r.TopLeft, r.TopRight, 0.0, 0.0));
    
    /// <summary>
    /// A value converter that takes a CornerRadius and leaves only the bottom radius values, clearing the others.
    /// </summary>
    public static readonly SelectRadiusConverter SelectBottomRadius = new((r) => new CornerRadius(0.0, 0.0, r.BottomLeft, r.BottomRight));
    
    /// <summary>
    /// A value converter that takes a CornerRadius and leaves only the top left values, clearing the others.
    /// </summary>
    public static readonly SelectRadiusConverter SelectLeftRadius = new((r) => new CornerRadius(r.TopLeft, 0.0, 0.0, r.BottomLeft));
    
    /// <summary>
    /// A value converter that takes a CornerRadius and leaves only the right radius values, clearing the others.
    /// </summary>
    public static readonly SelectRadiusConverter SelectRightRadius = new((r) => new CornerRadius(0.0, r.TopRight, r.BottomRight, 0.0));
    
    /// <summary>
    /// A value converter that takes a Thickness and leaves only the top values, clearing the others.
    /// </summary>
    public static readonly SelectThicknessConverter SelectTopThickness = new((t) => new Thickness(0.0, t.Top, 0.0, 0.0));
    
    /// <summary>
    /// A value converter that takes a Thickness and leaves only the bottom values, clearing the others.
    /// </summary>
    public static readonly SelectThicknessConverter SelectBottomThickness = new((t) => new Thickness(0.0, t.Top, 0.0, 0.0));
    
    /// <summary>
    /// A value converter that takes a Thickness and leaves only the left values, clearing the others.
    /// </summary>
    public static readonly SelectThicknessConverter SelectLeftThickness = new((t) => new Thickness(t.Left, 0.0, 0.0, 0.0));
    
    /// <summary>
    /// A value converter that takes a Thickness and leaves only the right values, clearing the others.
    /// </summary>
    public static readonly SelectThicknessConverter SelectRightThickness = new((t) => new Thickness(0.0, 0.0, t.Right, 0.0));
    
    /// <summary>
    /// A value converter that takes a Thickness and leaves the top and the bottom values, clearing the others.
    /// </summary>
    public static readonly SelectThicknessConverter SelectVerticalThickness = new((t) => new Thickness(0.0, t.Top, 0.0, t.Bottom));
    
    /// <summary>
    /// A value converter that takes a Thickness and leaves the left and the right values, clearing the others.
    /// </summary>
    public static readonly SelectThicknessConverter SelectHorizontalThickness = new((t) => new Thickness(t.Left, 0.0, t.Right, 0.0));
    
    /// <summary>
    /// A value converter that takes a Thickness and clears the top value.
    /// </summary>
    public static readonly SelectThicknessConverter ClearTopThickness = new((t) => new Thickness(t.Left, 0.0, t.Right, t.Bottom));
    
    /// <summary>
    /// A value converter that takes a Thickness and clears the bottom value.
    /// </summary>
    public static readonly SelectThicknessConverter ClearBottomThickness = new((t) => new Thickness(t.Left, t.Top, t.Right, 0.0));
    
    /// <summary>
    /// A value converter that takes a Thickness and clears the left value.
    /// </summary>
    public static readonly SelectThicknessConverter ClearLeftThickness = new((t) => new Thickness(0.0, t.Top, t.Right, t.Bottom));
    
    /// <summary>
    /// A value converter that takes a Thickness and clears the right value.
    /// </summary>
    public static readonly SelectThicknessConverter ClearRightThickness = new((t) => new Thickness(t.Left, t.Top, 0.0, t.Bottom));
    
    /// <summary>
    /// A value converter that takes a double and returns a Thickness with the left set to that value.
    /// </summary>
    public static readonly DoubleToThicknessConverter MakeLeftThickness = new((d) => new Thickness(d, 0.0, 0.0, 0.0));
    
    /// <summary>
    /// A value converter that takes a double and returns a Thickness with the right set to that value.
    /// </summary>
    public static readonly DoubleToThicknessConverter MakeRightThickness = new((d) => new Thickness(0.0, 0.0, d, 0.0));
    
    /// <summary>
    /// A multi-value converter to calculate tree view item margins.
    /// </summary>
    public static readonly IndentConverter Indent = new();
}