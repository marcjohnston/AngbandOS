using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(Title = "Label Widget", EntityNoun = "label widget")]
public class LabelWidgetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Text",
        Summary = "Specifies the text to be rendered for the widget.",
        DataType = "string")]
    public virtual string Text { get; set; }

    [ConfigurationMetadata(
        Title = "Color",
        Summary = "Specifies the color used to draw the widget text. Defaults to white.",
        DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    [ConfigurationMetadata(
        Title = "X",
        Summary = "Specifies the x-coordinate on the form where the widget will be drawn.",
        DataType = "int")]
    public virtual int X { get; set; }

    [ConfigurationMetadata(
        Title = "Y",
        Summary = "Specifies the y-coordinate on the form where the widget will be drawn.",
        DataType = "int")]
    public virtual int Y { get; set; }

    [ConfigurationMetadata(
        Title = "Width",
        Summary = "Specifies the width of the widget. When null, the width defaults to the length of the text.",
        DataType = "int?")]
    public virtual int? Width { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Justification Name",
        Summary = "Specifies the name of the justification used to justify the text within the widget width. Defaults to LeftJustification.",
        DataType = "string")]
    public virtual string JustificationName { get; set; } = nameof(JustificationsEnum.LeftJustification);

    [ConfigurationMetadata(
        Title = "Change Tracker Names",
        Summary = "Specifies the names of the properties that participate in change tracking.",
        DataType = "string[]?")]
    public virtual string[]? ChangeTrackerNames { get; set; }
}