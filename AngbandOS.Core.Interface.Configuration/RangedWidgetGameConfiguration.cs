using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Ranged Widget",
    EntityNoun = "ranged widget")]
public class RangedWidgetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationTupleItem(
        "startValue",
        Title = "Start Value")]
    [ConfigurationTupleItem(
        "textToRender",
        Title = "Text To Render")]
    [ConfigurationTupleItem(
        "color",
        Title = "Color")]
    [ConfigurationMetadata(
        Title = "Ranges",
        Summary = "Specifies the value ranges, display text, and colors used to render the widget.",
        DataType = "(int startValue, string textToRender, ColorEnum color)[]")]
    public virtual (int startValue, string textToRender, ColorEnum color)[] Ranges { get; set; }

    [ConfigurationMetadata(
        Title = "Integer Value Name",
        Summary = "Specifies the name of the integer value displayed by the widget.",
        DataType = "string")]
    public virtual string IntValueName { get; set; }

    [ConfigurationMetadata(
        Title = "Default Text",
        Summary = "Specifies the text rendered when none of the ranges apply.",
        DataType = "string")]
    public virtual string DefaultText { get; set; } = "";

    [ConfigurationMetadata(
        Title = "Default Color",
        Summary = "Specifies the color used when none of the ranges apply.",
        DataType = "ColorEnum")]
    public virtual ColorEnum DefaultColor { get; set; } = ColorEnum.White;

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


