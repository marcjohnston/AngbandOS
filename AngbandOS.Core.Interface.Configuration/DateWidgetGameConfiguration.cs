using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class DateWidgetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Date Value Name",
        Description = "The name of the date value displayed by the widget.")]
    public virtual string DateValueName { get; set; }

    [ConfigurationProperty("ColorEnum",
        Title = "Color",
        Description = "The color used to draw the widget text.")]
    public virtual ColorEnum Color { get; set; }

    [ConfigurationProperty("int",
        Title = "X",
        Description = "The x-coordinate on the form where the widget is drawn.")]
    public virtual int X { get; set; }

    [ConfigurationProperty("int",
        Title = "Y",
        Description = "The y-coordinate on the form where the widget is drawn.")]
    public virtual int Y { get; set; }

    [ConfigurationProperty("int?",
        Title = "Width",
        Description = "The width of the widget, or null to use the default width.")]
    public virtual int? Width { get; set; } = null;

    [ConfigurationProperty("JustificationsEnum",
        Title = "Justification",
        Description = "The name of the justification used to position the widget text within its width.")]
    public virtual JustificationsEnum JustificationEnumValue { get; set; } = JustificationsEnum.LeftJustification;

    [ConfigurationProperty("string[]?",
        Title = "Change Tracker Names",
        Description = "The names of the properties that participate in change tracking.")]
    public virtual string[]? ChangeTrackerNames { get; set; }
}

