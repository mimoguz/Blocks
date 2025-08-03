using System;
using System.Linq;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.LogicalTree;
using Avalonia.VisualTree;

namespace Blocks.Controls;

[PseudoClasses(CommandTilePressed)]
public sealed class CommandTile : Tile, ICommandSource
{
    private const string CommandTilePressed = ":pressed";
    
    private EventHandler? canExecuteChangeHandler;
    private EventHandler CanExecuteChangedHandler => canExecuteChangeHandler ??= new(CanExecuteChanged);
    
    public static readonly StyledProperty<ICommand?> CommandProperty =
        AvaloniaProperty.Register<CommandTile, ICommand?>(nameof(Command), enableDataValidation: true);

    public static readonly StyledProperty<object?> CommandParameterProperty =
        AvaloniaProperty.Register<CommandTile, object?>(nameof(CommandParameter));
    
    public static readonly RoutedEvent<RoutedEventArgs> ClickEvent =
        RoutedEvent.Register<CommandTile, RoutedEventArgs>(nameof(Click), RoutingStrategies.Bubble);

    public static readonly DirectProperty<CommandTile, bool> IsPressedProperty =
        AvaloniaProperty.RegisterDirect<CommandTile, bool>(nameof(IsPressed), b => b.IsPressed);

    private bool commandCanExecute = true;
    private bool isPressed = false;

    static CommandTile()
    {
        FocusableProperty.OverrideDefaultValue(typeof(CommandTile), true);
    }
    
    public event EventHandler<RoutedEventArgs>? Click
    {
        add => AddHandler(ClickEvent, value);
        remove => RemoveHandler(ClickEvent, value);
    }
    
    public ICommand? Command
    {
        get => GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
    
    public object? CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }
    
    public bool IsPressed
    {
        get => isPressed;
        private set => SetAndRaise(IsPressedProperty, ref isPressed, value);
    }

    /// <inheritdoc/>
    protected override bool IsEnabledCore => base.IsEnabledCore && commandCanExecute;

    /// <inheritdoc/>
    protected override void OnAttachedToLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        base.OnAttachedToLogicalTree(e);
        var command = Command;
        var parameter = CommandParameter;
        if (command is not null)
        {
            command.CanExecuteChanged += CanExecuteChangedHandler;
            CanExecuteChanged(command, parameter);
        }
    }

    /// <inheritdoc/>
    protected override void OnDetachedFromLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromLogicalTree(e);
        if (Command is { } command)
        {
            command.CanExecuteChanged -= CanExecuteChangedHandler;
        }
    }

    /// <inheritdoc/>
    protected override void OnKeyDown(KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Enter:
                OnClick();
                e.Handled = true;
                break;
            case Key.Space:
                // Avoid handling Space if the button isn't focused: a child TextBox might need it for text input
                if (IsFocused)
                {
                    IsPressed = true;
                    e.Handled = true;
                }
                break;
        }

        base.OnKeyDown(e);
    }

    /// <inheritdoc/>
    protected override void OnKeyUp(KeyEventArgs e)
    {
        // Avoid handling Space if the button isn't focused: a child TextBox might need it for text input
        if (e.Key == Key.Space && IsFocused)
        {
            OnClick();
            IsPressed = false;
            e.Handled = true;
        }

        base.OnKeyUp(e);
    }

    private void OnClick()
    {
        if (!IsEffectivelyEnabled)
        {
            return;
        }

        var e = new RoutedEventArgs(ClickEvent);
        RaiseEvent(e);

        var command = Command;
        var parameter = CommandParameter;
        if (!e.Handled && command is not null && command.CanExecute(parameter))
        {
            command.Execute(parameter);
            e.Handled = true;
        }
    }

    /// <inheritdoc/>
    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            IsPressed = true;
            e.Handled = true;
        }
    }

    /// <inheritdoc/>
    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);
        if (IsPressed && e.InitialPressMouseButton == MouseButton.Left)
        {
            IsPressed = false;
            e.Handled = true;
            if (this.GetVisualsAt(e.GetPosition(this)).Any(c => this == c || this.IsVisualAncestorOf(c)))
            {
                OnClick();
            }
        }
    }

    /// <inheritdoc/>
    protected override void OnPointerCaptureLost(PointerCaptureLostEventArgs e)
    {
        base.OnPointerCaptureLost(e);
        IsPressed = false;
    }

    /// <inheritdoc/>
    protected override void OnLostFocus(RoutedEventArgs e)
    {
        base.OnLostFocus(e);
        IsPressed = false;
    }

    /// <inheritdoc/>
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        UpdatePseudoClasses();
    }

    /// <inheritdoc/>
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == CommandProperty)
        {
            var (oldValue, newValue) = change.GetOldAndNewValue<ICommand?>();
            if (((ILogical)this).IsAttachedToLogicalTree)
            {
                if (oldValue != null)
                {
                    oldValue.CanExecuteChanged -= CanExecuteChangedHandler;
                }

                if (newValue != null)
                {
                    newValue.CanExecuteChanged += CanExecuteChangedHandler;
                }
            }

            CanExecuteChanged(newValue, CommandParameter);
        }
        else if (change.Property == CommandParameterProperty)
        {
            CanExecuteChanged(Command, change.NewValue);
        }
        else if (change.Property == IsPressedProperty)
        {
            PseudoClasses.Set(CommandTilePressed, IsPressed);
        }
    }

    // protected override AutomationPeer OnCreateAutomationPeer() => new ButtonAutomationPeer(this);

    /// <inheritdoc/>
    protected override void UpdateDataValidation(
        AvaloniaProperty property,
        BindingValueType state,
        Exception? error)
    {
        base.UpdateDataValidation(property, state, error);
        if (property == CommandProperty)
        {
            if (state == BindingValueType.BindingError)
            {
                if (commandCanExecute)
                {
                    commandCanExecute = false;
                    UpdateIsEffectivelyEnabled();
                }
            }
        }
    }
    
    private void CanExecuteChanged(object? sender, EventArgs e)
    {
        CanExecuteChanged(Command, CommandParameter);
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    private void CanExecuteChanged(ICommand? command, object? parameter)
    {
        if (!((ILogical)this).IsAttachedToLogicalTree)
        {
            return;
        }
        var canExecute = command == null || command.CanExecute(parameter);
        if (canExecute != commandCanExecute)
        {
            commandCanExecute = canExecute;
            UpdateIsEffectivelyEnabled();
        }
    }
    
    protected override void UpdatePseudoClasses()
    {
        base.UpdatePseudoClasses();
        PseudoClasses.Set(CommandTilePressed, IsPressed);
    }

    void ICommandSource.CanExecuteChanged(object sender, EventArgs e) => this.CanExecuteChanged(sender, e);
}