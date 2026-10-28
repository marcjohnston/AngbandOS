using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Maximum Ranged Widget",
    EntityNoun = "maximum ranged widget")]
public class MaxRangedWidgetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationTupleItem(
        "percentage",
        Title = "Percentage")]
    [ConfigurationTupleItem(
        "text",
        Title = "Text")]
    [ConfigurationTupleItem(
        "color",
        Title = "Color")]
    [ConfigurationMetadata(
        Title = "Ranges",
        Summary = "Specifies the percentage ranges, display text, and colors used to render the widget.",
        DataType = "(int percentage, string? text, ColorEnum color)[]")]
    public virtual (int percentage, string? text, ColorEnum color)[] Ranges { get; set; }

    [ConfigurationMetadata(
        Title = "Default Color",
        Summary = "Specifies the color used when none of the ranges apply.",
        DataType = "ColorEnum")]
    public virtual ColorEnum DefaultColor { get; set; }

    [ConfigurationMetadata(
        Title = "Maximum Integer Value Name",
        Summary = "Specifies the name of the maximum integer value displayed by the widget.",
        DataType = "string")]
    public virtual string MaxIntValueName { get; set; }

    [ConfigurationMetadata(
        Title = "Integer Value Name",
        Summary = "Specifies the name of the integer value displayed by the widget.",
        DataType = "string")]
    public virtual string IntValueName { get; set; }

    [ConfigurationMetadata(
        Title = "X",
        Summary = "Specifies the horizontal coordinate where the widget is drawn.",
        DataType = "int")]
    public virtual int X { get; set; }

    [ConfigurationMetadata(
        Title = "Y",
        Summary = "Specifies the vertical coordinate where the widget is drawn.",
        DataType = "int")]
    public virtual int Y { get; set; }

    [ConfigurationMetadata(
        Title = "Width",
        Summary = "Specifies the width of the widget. When null, the width is based on the text length.",
        DataType = "int?")]
    public virtual int? Width { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Justification Name",
        Summary = "Specifies the name of the justification used to lay out the widget text.",
        DataType = "string")]
    public virtual string JustificationName { get; set; } = nameof(JustificationsEnum.LeftJustification);

    [ConfigurationMetadata(
        Title = "Change Tracker Names",
        Summary = "Specifies the property names that participate in change tracking.",
        DataType = "string[]?")]
    public virtual string[]? ChangeTrackerNames { get; set; }
}
