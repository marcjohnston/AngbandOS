// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal class GenericMapWidget : MapWidget
{
    public GenericMapWidget(Game game, MapWidgetGameConfiguration mapWidgetGameConfiguration) : base(game)
    {
        Key = mapWidgetGameConfiguration.Key ?? mapWidgetGameConfiguration.GetType().Name;
        X = mapWidgetGameConfiguration.X;
        Y = mapWidgetGameConfiguration.Y;
        ChangeTrackerNames = mapWidgetGameConfiguration.ChangeTrackerNames;
    }

    /// <summary>
    /// Returns the x-coordinate on the <see cref="View"/> where the widget will be drawn.
    /// </summary>
    public override int X { get; }

    /// <summary>
    /// Returns the y-coordinate on the <see cref="View"/> where the widget will be drawn.
    /// </summary>
    public override int Y { get; }

    /// <summary>
    /// Returns the name of the property that participates in change tracking.  This property is used to bind the <see cref="ChangeTrackers"/> property during the bind phase.
    /// </summary>
    public override string[]? ChangeTrackerNames { get; }
    public override string Key { get; }
}


