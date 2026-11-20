using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

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
    [ConfigurationProperty("(int percentage, string? text, ColorEnum color)[]",
        Title = "Ranges",
        Summary = "Specifies the percentage ranges, display text, and colors used to render the widget.")]
    public virtual (int percentage, string? text, ColorEnum color)[] Ranges { get; set; }

    [ConfigurationProperty("ColorEnum",
        Title = "Default Color",
        Summary = "Specifies the color used when none of the ranges apply.")]
    public virtual ColorEnum DefaultColor { get; set; }

    [ConfigurationProperty("string",
        Title = "Maximum Integer Value Name",
        Summary = "Specifies the name of the maximum integer value displayed by the widget.")]
    public virtual string MaxIntValueName { get; set; }

    [ConfigurationProperty("string",
        Title = "Integer Value Name",
        Summary = "Specifies the name of the integer value displayed by the widget.")]
    public virtual string IntValueName { get; set; }

    [ConfigurationProperty("int",
        Title = "X",
        Summary = "Specifies the horizontal coordinate where the widget is drawn.")]
    public virtual int X { get; set; }

    [ConfigurationProperty("int",
        Title = "Y",
        Summary = "Specifies the vertical coordinate where the widget is drawn.")]
    public virtual int Y { get; set; }

    [ConfigurationProperty("int?",
        Title = "Width",
        Summary = "Specifies the width of the widget. When null, the width is based on the text length.")]
    public virtual int? Width { get; set; } = null;

    [ConfigurationProperty("JustificationsEnum",
        Title = "Justification",
        Summary = "Specifies the name of the justification used to lay out the widget text.")]
    public virtual JustificationsEnum JustificationEnumValue { get; set; } = JustificationsEnum.LeftJustification;

    [ConfigurationProperty("string[]?",
        Title = "Change Tracker Names",
        Summary = "Specifies the property names that participate in change tracking.")]
    public virtual string[]? ChangeTrackerNames { get; set; }
}
