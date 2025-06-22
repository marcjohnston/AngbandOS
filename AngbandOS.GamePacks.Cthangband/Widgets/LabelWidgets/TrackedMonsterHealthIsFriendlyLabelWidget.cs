// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents a widget that displays a friendly status for when the player is tracking a monster and the monster is friendly.
/// </summary>
[Serializable]
public class TrackedMonsterHealthIsFriendlyLabelWidget : LabelWidgetGameConfiguration
{
    public override int X => 0;
    public override int Y => 32;
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Text => "[FRIENDLY**]";
}
