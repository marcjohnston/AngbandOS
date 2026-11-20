using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ConditionalWidgetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty(
        Title = "Conditional Key",
        Summary = "The key identifying the conditional that determines which widgets are enabled.",
        DataType = "string")]
    public virtual string ConditionalKey { get; set; }

    [ConfigurationProperty(
        Title = "True Widget Names",
        Summary = "The names of the widgets to invalidate when the conditional evaluates to true.",
        DataType = "string[]?")]
    public virtual string[]? TrueWidgetNames { get; set; } = null;

    [ConfigurationProperty(
        Title = "False Widget Names",
        Summary = "The names of the widgets to invalidate when the conditional evaluates to false.",
        DataType = "string[]?")]
    public virtual string[]? FalseWidgetNames { get; set; } = null;

    [ConfigurationProperty(
        Title = "Color",
        Summary = "The color used to draw the widget text.",
        DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    [ConfigurationProperty(
        Title = "X",
        Summary = "The x-coordinate on the form where the widget is drawn.",
        DataType = "int")]
    public virtual int X { get; set; }

    [ConfigurationProperty(
        Title = "Y",
        Summary = "The y-coordinate on the form where the widget is drawn.",
        DataType = "int")]
    public virtual int Y { get; set; }

    [ConfigurationProperty(
        Title = "Width",
        Summary = "The width of the widget.",
        DataType = "int")]
    public virtual int Width { get; set; }

    [ConfigurationProperty(
        Title = "Justification",
        Summary = "The name of the justification used to position the widget text within its width.",
        DataType = "JustificationsEnum")]
    public virtual JustificationsEnum JustificationEnumValue { get; set; } = JustificationsEnum.LeftJustification;

    [ConfigurationProperty(
        Title = "Change Tracker Names",
        Summary = "The names of the properties that participate in change tracking.",
        DataType = "string[]?")]
    public virtual string[]? ChangeTrackerNames { get; set; } = null;
}