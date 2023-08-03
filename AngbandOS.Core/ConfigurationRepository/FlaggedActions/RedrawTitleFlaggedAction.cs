// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawTitleFlaggedAction : FlaggedAction
{
    private const int RowTitle = 4;
    private const int ColTitle = 0;
    private RedrawTitleFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    private void PrtField(string info, int row, int col) // TODO: Duplicate with PrPlayerRedrawAction
    {
        SaveGame.Screen.Print(ColourEnum.White, "             ", row, col);
        SaveGame.Screen.Print(ColourEnum.BrightBlue, info, row, col);
    }
    protected override void Execute()
    {
        if (SaveGame.IsWizard)
        {
            PrtField("-=<WIZARD>=-", RowTitle, ColTitle);
        }
        else if (SaveGame.IsWinner || SaveGame.ExperienceLevel > Constants.PyMaxLevel)
        {
            PrtField("***WINNER***", RowTitle, ColTitle);
        }
    }
}
