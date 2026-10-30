using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class TextWidgetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Nullable Strings Value Name",
        Summary = "Specifies the name of the nullable strings value displayed by the widget.",
        DataType = "string")]
    public virtual string NullableStringsValueName { get; set; }

    [ConfigurationMetadata(
        Title = "Color",
        Summary = "Specifies the color used to draw the widget text.",
        DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; }

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
        Summary = "Specifies the width of the widget.",
        DataType = "int")]
    public virtual int Width { get; set; }

    [ConfigurationMetadata(
        Title = "Height",
        Summary = "Specifies the height of the widget.",
        DataType = "int")]
    public virtual int Height { get; set; }

    [ConfigurationMetadata(
        Title = "Justification Name",
        Summary = "Specifies the name of the justification used to lay out the widget text.",
        DataType = "string")]
    public virtual string JustificationName { get; set; } = nameof(JustificationsEnum.LeftJustification);

    [ConfigurationMetadata(
        Title = "Alignment Name",
        Summary = "Specifies the name of the alignment used to align the widget text.",
        DataType = "string")]
    public virtual string AlignmentName { get; set; }

    [ConfigurationMetadata(
        Title = "Change Tracker Names",
        Summary = "Specifies the property names that participate in change tracking.",
        DataType = "string[]?")]
    public virtual string[]? ChangeTrackerNames { get; set; }
}
