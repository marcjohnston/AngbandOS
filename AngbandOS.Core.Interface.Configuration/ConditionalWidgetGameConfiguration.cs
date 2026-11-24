using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ConditionalWidgetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Conditional Key",
        Description = "The key identifying the conditional that determines which widgets are enabled.")]
    public virtual string ConditionalKey { get; set; }

    [ConfigurationProperty("string[]?",
        Title = "True Widget Names",
        Description = "The names of the widgets to invalidate when the conditional evaluates to true.")]
    public virtual string[]? TrueWidgetNames { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "False Widget Names",
        Description = "The names of the widgets to invalidate when the conditional evaluates to false.")]
    public virtual string[]? FalseWidgetNames { get; set; } = null;

    [ConfigurationProperty("ColorEnum",
        Title = "Color",
        Description = "The color used to draw the widget text.")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    [ConfigurationProperty("int",
        Title = "X",
        Description = "The x-coordinate on the form where the widget is drawn.")]
    public virtual int X { get; set; }

    [ConfigurationProperty("int",
        Title = "Y",
        Description = "The y-coordinate on the form where the widget is drawn.")]
    public virtual int Y { get; set; }

    [ConfigurationProperty("int",
        Title = "Width",
        Description = "The width of the widget.")]
    public virtual int Width { get; set; }

    [ConfigurationProperty("JustificationsEnum",
        Title = "Justification",
        Description = "The name of the justification used to position the widget text within its width.")]
    public virtual JustificationsEnum JustificationEnumValue { get; set; } = JustificationsEnum.LeftJustification;

    [ConfigurationProperty("string[]?",
        Title = "Change Tracker Names",
        Description = "The names of the properties that participate in change tracking.")]
    public virtual string[]? ChangeTrackerNames { get; set; } = null;
}