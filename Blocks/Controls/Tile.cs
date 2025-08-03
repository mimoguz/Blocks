using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Layout;

namespace Blocks.Controls;

[TemplatePart("PART_LeftContent", typeof(ContentPresenter), IsRequired = false)]
[TemplatePart("PART_RightContent", typeof(ContentPresenter), IsRequired = false)]
[PseudoClasses(TileEmpty, TileEmptyLeft, TileEmptyRight)]
public class Tile : HeaderedContentControl
{
    private const string TileEmpty = ":empty";
    private const string TileEmptyLeft = ":emptyLeft";
    private const string TileEmptyRight = ":emptyRight";
    
    public static readonly StyledProperty<object?> LeftContentProperty =
        AvaloniaProperty.Register<CommandTile, object?>(nameof(LeftContent));
    
    public static readonly StyledProperty<object?> RightContentProperty =
        AvaloniaProperty.Register<CommandTile, object?>(nameof(RightContent));
    
    public static readonly StyledProperty<IDataTemplate?> LeftContentTemplateProperty =
        AvaloniaProperty.Register<CommandTile, IDataTemplate?>(nameof(LeftContentTemplate));
    
    public static readonly StyledProperty<IDataTemplate?> RightContentTemplateProperty =
        AvaloniaProperty.Register<CommandTile, IDataTemplate?>(nameof(RightContentTemplate));
    
    public static readonly StyledProperty<HorizontalAlignment> HorizontalHeaderAlignmentProperty =
        AvaloniaProperty.Register<CommandTile, HorizontalAlignment>(nameof(HorizontalHeaderAlignment));
    
    public static readonly StyledProperty<VerticalAlignment> VerticalHeaderAlignmentProperty =
        AvaloniaProperty.Register<CommandTile, VerticalAlignment>(nameof(VerticalHeaderAlignment));
    
    public object? LeftContent
    {
        get => GetValue(LeftContentProperty);
        set => SetValue(LeftContentProperty, value);
    }
    
    public object? RightContent
    {
        get => GetValue(RightContentProperty);
        set => SetValue(RightContentProperty, value);
    }
    
    public IDataTemplate? LeftContentTemplate
    {
        get => GetValue(LeftContentTemplateProperty);
        set => SetValue(LeftContentTemplateProperty, value);
    }
    
    public IDataTemplate? RightContentTemplate
    {
        get => GetValue(RightContentTemplateProperty);
        set => SetValue(RightContentTemplateProperty, value);
    }
    
    public VerticalAlignment VerticalHeaderAlignment
    {
        get => GetValue(VerticalHeaderAlignmentProperty);
        set => SetValue(VerticalHeaderAlignmentProperty, value);
    }
    
    public HorizontalAlignment HorizontalHeaderAlignment
    {
        get => GetValue(HorizontalHeaderAlignmentProperty);
        set => SetValue(HorizontalHeaderAlignmentProperty, value);
    }
    
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);
        if (change.Property == ContentProperty)
        {
            PseudoClasses.Set(TileEmpty, Content == null);;
        }
        else if (change.Property == LeftContentProperty)
        {
             PseudoClasses.Set(TileEmptyLeft, LeftContent == null);
        } else if (change.Property == RightContentProperty)
        {
            PseudoClasses.Set(TileEmptyRight, RightContent == null);
        }
    }
    
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        UpdatePseudoClasses();
    }
    
    protected virtual void UpdatePseudoClasses()
    {
        PseudoClasses.Set(TileEmpty, Content == null);
        PseudoClasses.Set(TileEmptyLeft, LeftContent == null);
        PseudoClasses.Set(TileEmptyRight, RightContent == null);
    }
}