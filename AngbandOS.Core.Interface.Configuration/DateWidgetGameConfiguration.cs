using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntityAttribute(
    Title = "Date Widget",
    EntityNoun = "Date Widget")]
public class DateWidgetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Date Value Name",
        Summary = "The name of the date value displayed by the widget.",
        DataType = "string")]
    public virtual string DateValueName { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Color",
        Summary = "The color used to draw the widget text.",
        DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; }

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
        Summary = "The width of the widget, or null to use the default width.",
        DataType = "int?")]
    public virtual int? Width { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Justification Name",
        Summary = "The name of the justification used to position the widget text within its width.",
        DataType = "string")]
    public virtual string JustificationName { get; set; } = nameof(JustificationsEnum.LeftJustification);

    [ConfigurationMetadataAttribute(
        Title = "Change Tracker Names",
        Summary = "The names of the properties that participate in change tracking.",
        DataType = "string[]?")]
    public virtual string[]? ChangeTrackerNames { get; set; }
}

