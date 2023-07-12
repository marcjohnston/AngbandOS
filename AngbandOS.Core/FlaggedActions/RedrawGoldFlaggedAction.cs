// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawGoldFlaggedAction : FlaggedAction
{
    private const int ColGold = 0;
    private const int RowGold = 11;
    public RedrawGoldFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        SaveGame.Screen.Print("GP ", RowGold, ColGold);
        string tmp = SaveGame.Player.Gold.ToString().PadLeft(9);
        SaveGame.Screen.Print(ColourEnum.BrightGreen, tmp, RowGold, ColGold + 3);
    }
}
