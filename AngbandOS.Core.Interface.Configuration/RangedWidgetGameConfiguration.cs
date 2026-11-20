using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

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
    [ConfigurationProperty("(int startValue, string textToRender, ColorEnum color)[]",
        Title = "Ranges",
        Summary = "Specifies the value ranges, display text, and colors used to render the widget.")]
    public virtual (int startValue, string textToRender, ColorEnum color)[] Ranges { get; set; }

    [ConfigurationProperty("string",
        Title = "Integer Value Name",
        Summary = "Specifies the name of the integer value displayed by the widget.")]
    public virtual string IntValueName { get; set; }

    [ConfigurationProperty("string",
        Title = "Default Text",
        Summary = "Specifies the text rendered when none of the ranges apply.")]
    public virtual string DefaultText { get; set; } = "";

    [ConfigurationProperty("ColorEnum",
        Title = "Default Color",
        Summary = "Specifies the color used when none of the ranges apply.")]
    public virtual ColorEnum DefaultColor { get; set; } = ColorEnum.White;

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


