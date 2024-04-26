// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

/// <summary>
/// Represents a widget that displays blank for the tracked monster health.  This widget is rendered when the player is not tracking a monster.
/// </summary>
[Serializable]
internal class NoTrackedMonsterHealthTextWidget : TextWidget
{
    private NoTrackedMonsterHealthTextWidget(Game game) : base(game) { } // This object is a singleton.
    public override int X => 0;
    public override int Y => 32;
    public override int Width => 12;
    public override string Text => "";
}
