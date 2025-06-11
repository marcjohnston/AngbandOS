namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class MaxRangedWidgetGameConfiguration
{
    /// <summary>
    /// Returns an array of tuples that specify a range factor and color to render for a range of values.  The <param name="startValue"></param> specifies the smallest (or start) value of the range.  Ranges must be sorted in
    /// descending order.  This sorting is validated once upon first usage.  If the value is larger than the first range, the first range will match.  If the value is smaller than the last range specified, the
    /// <see cref="DefaultText"/> and <see cref="DefaultColor"/> will be used.  Duplicate startValues cannot be used and will fail the sort validation.
    /// 
    /// The factor
    /// </summary>
    public virtual (int percentage, string? text, ColorEnum color)[] Ranges { get; set; }

    /// <summary>
    /// Returns the color for the <see cref="Text"/> to be rendered in when none of the ranges apply.  Returns the color white, by default.
    /// </summary>
    public virtual ColorEnum DefaultColor { get; set; }

    public virtual string MaxIntValueName { get; set; }

    public virtual string IntValueName { get; set; }

    /// <summary>
    /// Returns the x-coordinate on the <see cref="Form"/> where the widget will be drawn.
    /// </summary>
    public virtual int X { get; set; }

    /// <summary>
    /// Returns the y-coordinate on the <see cref="Form"/> where the widget will be drawn.
    /// </summary>
    public virtual int Y { get; set; }

    /// <summary>
    /// Returns the width of the widget.  A width that is equal to the length of the <see cref="Text"/> property is returned by default.
    /// </summary>
    public virtual int? Width { get; set; } = null;

    /// <summary>
    /// Returns the name of the <see cref="Justification"/> object to be used to justify the text within the <see cref="Width"/> of the <see cref="TextWidget" />.  This property
    /// is used to bind the <see cref="Justification"/> property.  Defaults to <see cref="LeftJustification"/>.
    /// </summary>
    public virtual string JustificationName { get; set; } = nameof(JustificationsEnum.LeftJustification);

    /// <summary>
    /// Returns the name of the property that participates in change tracking.  This property is used to bind the <see cref="ChangeTrackers"/> property during the bind phase.
    /// </summary>
    public virtual string[]? ChangeTrackerNames { get; set; }
    public virtual string? Key { get; set; } = null;
}


