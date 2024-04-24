// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

/// <summary>
/// Represents a widget that detects when the dungeon map has changed and renders the dungeon map widget when the value changes.
/// </summary>
[Serializable]
internal class DungeonMapChangeTrackingWidget : ChangeTrackingWidget
{
    private DungeonMapChangeTrackingWidget(Game game) : base(game) { } // This object is a singleton.
    public override string[] ChangeTrackerNames => new string[] { nameof(RefreshMapFunction) };
    public override string[] WidgetNames => new string[] { nameof(DungeonMapWidget) };
}
