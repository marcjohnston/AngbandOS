using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class TextWidgetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Nullable Strings Value Name",
        Description = "Specifies the name of the nullable strings value displayed by the widget.")]
    public virtual string NullableStringsValueName { get; set; }

    [ConfigurationProperty("ColorEnum",
        Title = "Color",
        Description = "Specifies the color used to draw the widget text.")]
    public virtual ColorEnum Color { get; set; }

    [ConfigurationProperty("int",
        Title = "X",
        Description = "Specifies the horizontal coordinate where the widget is drawn.")]
    public virtual int X { get; set; }

    [ConfigurationProperty("int",
        Title = "Y",
        Description = "Specifies the vertical coordinate where the widget is drawn.")]
    public virtual int Y { get; set; }

    [ConfigurationProperty("int",
        Title = "Width",
        Description = "Specifies the width of the widget.")]
    public virtual int Width { get; set; }

    [ConfigurationProperty("int",
        Title = "Height",
        Description = "Specifies the height of the widget.")]
    public virtual int Height { get; set; }

    [ConfigurationProperty("JustificationsEnum",
        Title = "Justification",
        Description = "Specifies the name of the justification used to lay out the widget text.")]
    public virtual JustificationsEnum JustificationEnumValue { get; set; } = JustificationsEnum.LeftJustification;

    [ConfigurationProperty("AlignmentsEnum",
        Title = "Alignment Name",
        Description = "Specifies the name of the alignment used to align the widget text.")]
    public virtual AlignmentsEnum AlignmentEnumValue { get; set; }

    [ConfigurationProperty("string[]?",
        Title = "Change Tracker Names",
        Description = "Specifies the property names that participate in change tracking.")]
    public virtual string[]? ChangeTrackerNames { get; set; }
}
