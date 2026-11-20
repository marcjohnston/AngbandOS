using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class TextWidgetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty(
        Title = "Nullable Strings Value Name",
        Summary = "Specifies the name of the nullable strings value displayed by the widget.",
        DataType = "string")]
    public virtual string NullableStringsValueName { get; set; }

    [ConfigurationProperty(
        Title = "Color",
        Summary = "Specifies the color used to draw the widget text.",
        DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; }

    [ConfigurationProperty(
        Title = "X",
        Summary = "Specifies the horizontal coordinate where the widget is drawn.",
        DataType = "int")]
    public virtual int X { get; set; }

    [ConfigurationProperty(
        Title = "Y",
        Summary = "Specifies the vertical coordinate where the widget is drawn.",
        DataType = "int")]
    public virtual int Y { get; set; }

    [ConfigurationProperty(
        Title = "Width",
        Summary = "Specifies the width of the widget.",
        DataType = "int")]
    public virtual int Width { get; set; }

    [ConfigurationProperty(
        Title = "Height",
        Summary = "Specifies the height of the widget.",
        DataType = "int")]
    public virtual int Height { get; set; }

    [ConfigurationProperty(
        Title = "Justification",
        Summary = "Specifies the name of the justification used to lay out the widget text.",
        DataType = "JustificationsEnum")]
    public virtual JustificationsEnum JustificationEnumValue { get; set; } = JustificationsEnum.LeftJustification;

    [ConfigurationProperty(
        Title = "Alignment Name",
        Summary = "Specifies the name of the alignment used to align the widget text.",
        DataType = "AlignmentsEnum")]
    public virtual AlignmentsEnum AlignmentEnumValue { get; set; }

    [ConfigurationProperty(
        Title = "Change Tracker Names",
        Summary = "Specifies the property names that participate in change tracking.",
        DataType = "string[]?")]
    public virtual string[]? ChangeTrackerNames { get; set; }
}
