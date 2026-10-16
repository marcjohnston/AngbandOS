using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntityAttribute(
    Title = "Conditional Widget",
    EntityNoun = "Conditional Widget")]
public class ConditionalWidgetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Conditional Key",
        Summary = "The key identifying the conditional that determines which widgets are enabled.",
        DataType = "string")]
    public virtual string ConditionalKey { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "True Widget Names",
        Summary = "The names of the widgets to invalidate when the conditional evaluates to true.",
        DataType = "string[]?")]
    public virtual string[]? TrueWidgetNames { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "False Widget Names",
        Summary = "The names of the widgets to invalidate when the conditional evaluates to false.",
        DataType = "string[]?")]
    public virtual string[]? FalseWidgetNames { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Color",
        Summary = "The color used to draw the widget text.",
        DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    [ConfigurationMetadataAttribute(
        Title = "X",
        Summary = "The x-coordinate on the form where the widget is drawn.",
        DataType = "int")]
    public virtual int X { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Y",
        Summary = "The y-coordinate on the form where the widget is drawn.",
        DataType = "int")]
    public virtual int Y { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Width",
        Summary = "The width of the widget.",
        DataType = "int")]
    public virtual int Width { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Justification Name",
        Summary = "The name of the justification used to position the widget text within its width.",
        DataType = "string")]
    public virtual string JustificationName { get; set; } = nameof(JustificationsEnum.LeftJustification);

    [ConfigurationMetadataAttribute(
        Title = "Change Tracker Names",
        Summary = "The names of the properties that participate in change tracking.",
        DataType = "string[]?")]
    public virtual string[]? ChangeTrackerNames { get; set; } = null;
}