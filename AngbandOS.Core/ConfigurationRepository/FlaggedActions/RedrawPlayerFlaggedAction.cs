// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawPlayerFlaggedAction : FlaggedAction
{
    private const int ColRace = 0;
    private const int RowRace = 2;
    private const int ColClass = 0;
    private const int RowClass = 3;
    private RedrawPlayerFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    private void PrtField(string info, int row, int col) // TODO: Duplicate with PrTitleRedrawAction
    {
        SaveGame.Screen.Print(ColorEnum.White, "             ", row, col);
        SaveGame.Screen.Print(ColorEnum.BrightBlue, info, row, col);
    }
    protected override void Execute()
    {
        PrtField(SaveGame.Race.Title, RowRace, ColRace);
        PrtField(SaveGame.BaseCharacterClass.ClassSubName(SaveGame.PrimaryRealm), RowClass, ColClass);
    }
}
