// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawPoisonedFlaggedAction : FlaggedAction
{
    private const int ColPoisoned = 33;
    private const int RowPoisoned = 44;
    private RedrawPoisonedFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        if (SaveGame.PoisonTimer.Value > 0)
        {
            SaveGame.Screen.Print(ColorEnum.Orange, "Poisoned", RowPoisoned, ColPoisoned);
        }
        else
        {
            SaveGame.Screen.Print("        ", RowPoisoned, ColPoisoned);
        }
    }
}
