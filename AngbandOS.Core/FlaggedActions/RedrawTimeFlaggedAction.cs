// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawTimeFlaggedAction : FlaggedAction
{
    private const int ColDate = 0;
    private const int RowDate = 9;
    private const int ColTime = 0;
    private const int RowTime = 8;
    private RedrawTimeFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        SaveGame.Screen.Print(ColorEnum.White, "Time", RowTime, ColTime);
        SaveGame.Screen.Print(ColorEnum.White, "Day", RowDate, ColDate);
        SaveGame.Screen.Print(ColorEnum.BrightGreen, SaveGame.GameTime.TimeText.PadLeft(8), RowTime, ColTime + 4);
        SaveGame.Screen.Print(ColorEnum.BrightGreen, SaveGame.GameTime.DateText.PadLeft(8), RowDate, ColDate + 4);
    }
}
