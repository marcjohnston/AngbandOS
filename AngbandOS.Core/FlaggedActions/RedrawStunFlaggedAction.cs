// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawStunFlaggedAction : FlaggedAction
{
    private const int ColStun = 0;
    private const int RowStun = 43;
    public RedrawStunFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        int s = SaveGame.Player.TimedStun.TurnsRemaining;
        if (s > 100)
        {
            SaveGame.Screen.Print(Colour.Red, "Knocked out ", RowStun, ColStun);
        }
        else if (s > 50)
        {
            SaveGame.Screen.Print(Colour.Orange, "Heavy stun  ", RowStun, ColStun);
        }
        else if (s > 0)
        {
            SaveGame.Screen.Print(Colour.Orange, "Stun        ", RowStun, ColStun);
        }
        else
        {
            SaveGame.Screen.Print("            ", RowStun, ColStun);
        }
    }
}
