// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal class GenericNullableStringsTextAreaWidget : NullableStringsTextAreaWidget
{
    public GenericNullableStringsTextAreaWidget(Game game, NullableStringsTextAreaWidgetGameConfiguration nullableStringsTextAreaWidgetGameConfiguration) : base(game)
    {
        Key = nullableStringsTextAreaWidgetGameConfiguration.Key ?? nullableStringsTextAreaWidgetGameConfiguration.GetType().Name;
        NullableTextAreaValueName = nullableStringsTextAreaWidgetGameConfiguration.NullableTextAreaValueName;
        NullableText = nullableStringsTextAreaWidgetGameConfiguration.NullableText;
        Color = nullableStringsTextAreaWidgetGameConfiguration.Color;
        X = nullableStringsTextAreaWidgetGameConfiguration.X;
        Y = nullableStringsTextAreaWidgetGameConfiguration.Y;
        Width = nullableStringsTextAreaWidgetGameConfiguration.Width;
        Height = nullableStringsTextAreaWidgetGameConfiguration.Height;
        JustificationName = nullableStringsTextAreaWidgetGameConfiguration.JustificationName;
        AlignmentName = nullableStringsTextAreaWidgetGameConfiguration.AlignmentName;
        ChangeTrackerNames = nullableStringsTextAreaWidgetGameConfiguration.ChangeTrackerNames;
    }

    public override string NullableTextAreaValueName { get; }
    public override string[]? NullableText { get; }

    /// <summary>
    /// Returns the color that the widget <see cref="Text"/> will be drawn.  Returns the color white by default.
    /// </summary>
    public override ColorEnum Color { get; }

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
    public override int Width { get; }

    /// <summary>
    /// Returns the height of the widget.  If the height provided is less than the number of lines in the <see cref="Text"/> property, remaining lines will not be rendered.
    /// </summary>
    public override int Height { get; }

    /// <summary>
    /// Returns the name of the <see cref="Justification"/> object to be used to justify the text within the <see cref="Width"/> of the <see cref="TextWidget" />.  This property
    /// is used to bind the <see cref="Justification"/> property.  Defaults to <see cref="LeftJustification"/>.
    /// </summary>
    public override string JustificationName { get; }

    /// <summary>
    /// Returns the name of the <see cref="Alignment"/> object to be used to align the text in the <see cref="Height"/> specified.  This property is used to bind the <see cref="Alignment"/>
    /// property during the bind phase.
    /// </summary>
    public override string AlignmentName { get; }

    /// <summary>
    /// Returns the name of the property that participates in change tracking.  This property is used to bind the <see cref="ChangeTrackers"/> property during the bind phase.
    /// </summary>
    public override string[]? ChangeTrackerNames { get; }
    public override string Key { get; }
}


