using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "String Widget",
    EntityNoun = "string widget")]
public class StringWidgetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "String Value Name",
        Summary = "Specifies the name of the string value displayed by the widget.",
        DataType = "string")]
    public virtual string StringValueName { get; set; }

    [ConfigurationMetadata(
        Title = "Color",
        Summary = "Specifies the color used to draw the widget text.",
        DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

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