using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;

namespace Blocks.Controls;

[TemplatePart("PART_DescriptionPresenter", typeof(ContentPresenter), IsRequired = false)]
public class Group : HeaderedContentControl
{
    public static readonly StyledProperty<object?> DescriptionProperty =
        AvaloniaProperty.Register<Group, object?>(nameof(Description));
    
    public object? Description
    {
        get => GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public static readonly StyledProperty<IDataTemplate?> DescriptionTemplateProperty =
        AvaloniaProperty.Register<Group, IDataTemplate?>(nameof(DescriptionTemplate));
    
    public IDataTemplate? DescriptionTemplate
    {
        get => GetValue(DescriptionTemplateProperty);
        set => SetValue(DescriptionTemplateProperty, value);
    }
}