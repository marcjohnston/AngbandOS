// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal class GenericMaxRangedWidget : MaxRangedWidget
{
    public GenericMaxRangedWidget(Game game, MaxRangedWidgetGameConfiguration maxRangedWidgetGameConfiguration) : base(game)
    {
        Key = maxRangedWidgetGameConfiguration.Key ?? maxRangedWidgetGameConfiguration.GetType().Name;
        Ranges = maxRangedWidgetGameConfiguration.Ranges;
        DefaultColor = maxRangedWidgetGameConfiguration.DefaultColor;
        MaxIntValueName = maxRangedWidgetGameConfiguration.MaxIntValueName;
        IntValueName = maxRangedWidgetGameConfiguration.IntValueName;
        X = maxRangedWidgetGameConfiguration.X;
        Y = maxRangedWidgetGameConfiguration.Y;
        Width = maxRangedWidgetGameConfiguration.Width;
        JustificationName = maxRangedWidgetGameConfiguration.JustificationName;
        ChangeTrackerNames = maxRangedWidgetGameConfiguration.ChangeTrackerNames;
    }

    /// <summary>
    /// Returns an array of tuples that specify a range factor and color to render for a range of values.  The <param name="startValue"></param> specifies the smallest (or start) value of the range.  Ranges must be sorted in
    /// descending order.  This sorting is validated once upon first usage.  If the value is larger than the first range, the first range will match.  If the value is smaller than the last range specified, the
    /// <see cref="DefaultText"/> and <see cref="DefaultColor"/> will be used.  Duplicate startValues cannot be used and will fail the sort validation.
    /// 
    /// The factor
    /// </summary>
    public override (int percentage, string? text, ColorEnum color)[] Ranges { get; }

    /// <summary>
    /// Returns the color for the <see cref="Text"/> to be rendered in when none of the ranges apply.  Returns the color white, by default.
    /// </summary>
    protected override ColorEnum DefaultColor { get; }

    public override string MaxIntValueName { get; }

    public override string IntValueName { get; }

    /// <summary>
    /// Returns the x-coordinate on the <see cref="View"/> where the widget will be drawn.
    /// </summary>
    public override int X { get; }

    /// <summary>
    /// Returns the y-coordinate on the <see cref="View"/> where the widget will be drawn.
    /// </summary>
    public override int Y { get; }

    /// <summary>
    /// Returns the width of the widget.  A width that is equal to the length of the <see cref="Text"/> property is returned by default.
    /// </summary>
    public override int? Width { get; } = null;

    /// <summary>
    /// Returns the name of the <see cref="Justification"/> object to be used to justify the text within the <see cref="Width"/> of the <see cref="TextWidget" />.  This property
    /// is used to bind the <see cref="Justification"/> property.  Defaults to <see cref="LeftJustification"/>.
    /// </summary>
    public override string JustificationName { get; }

    /// <summary>
    /// Returns the name of the property that participates in change tracking.  This property is used to bind the <see cref="ChangeTrackers"/> property during the bind phase.
    /// </summary>
    public override string[]? ChangeTrackerNames { get; }
    public override string Key { get; }
}


