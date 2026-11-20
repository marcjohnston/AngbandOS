using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class LabelWidgetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Text",
        Summary = "Specifies the text to be rendered for the widget.")]
    public virtual string Text { get; set; }

    [ConfigurationProperty("ColorEnum",
        Title = "Color",
        Summary = "Specifies the color used to draw the widget text. Defaults to white.")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    [ConfigurationProperty("int",
        Title = "X",
        Summary = "Specifies the x-coordinate on the form where the widget will be drawn.")]
    public virtual int X { get; set; }

    [ConfigurationProperty("int",
        Title = "Y",
        Summary = "Specifies the y-coordinate on the form where the widget will be drawn.")]
    public virtual int Y { get; set; }

    [ConfigurationProperty("int?",
        Title = "Width",
        Summary = "Specifies the width of the widget. When null, the width defaults to the length of the text.")]
    public virtual int? Width { get; set; } = null;

    [ConfigurationProperty("JustificationsEnum",
        Title = "Justification",
        Summary = "Specifies the name of the justification used to justify the text within the widget width. Defaults to LeftJustification.")]
    public virtual JustificationsEnum JustificationEnumValue { get; set; } = JustificationsEnum.LeftJustification;

    [ConfigurationProperty("string[]?",
        Title = "Change Tracker Names",
        Summary = "Specifies the names of the properties that participate in change tracking.")]
    public virtual string[]? ChangeTrackerNames { get; set; }
}