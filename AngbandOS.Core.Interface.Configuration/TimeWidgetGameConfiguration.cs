using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class TimeWidgetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Date And Time Value Name",
        Summary = "Specifies the name of the date and time value displayed by the widget.")]
    public virtual string DateAndTimeValueName { get; set; }

    [ConfigurationProperty("ColorEnum",
        Title = "Color",
        Summary = "Specifies the color used to draw the widget text.")]
    public virtual ColorEnum Color { get; set; }

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


