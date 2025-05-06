// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents a widget that displays an afraid status for when the player is tracking a monster and the monster is afraid.
/// player is hallucinating.
/// </summary>
[Serializable]
public class TrackedMonsterHealthIsAfraidTextWidget : TextWidgetGameConfiguration
{
    public override int X => 0;
    public override int Y => 32;
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Text => "[AFRAID****]";
}
