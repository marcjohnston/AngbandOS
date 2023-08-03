// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawBlindFlaggedAction : FlaggedAction
{
    private const int ColBlind = 8;
    private const int RowBlind = 44;
    private RedrawBlindFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        if (SaveGame.TimedBlindness.TurnsRemaining > 0)
        {
            SaveGame.Screen.Print(ColourEnum.Orange, "Blind", RowBlind, ColBlind);
        }
        else
        {
            SaveGame.Screen.Print("     ", RowBlind, ColBlind);
        }
    }
}
