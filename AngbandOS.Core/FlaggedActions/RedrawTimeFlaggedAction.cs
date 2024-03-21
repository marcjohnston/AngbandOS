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
    private RedrawTimeFlaggedAction(Game game) : base(game) { }
    protected override void Execute()
    {
        Game.Screen.Print(ColorEnum.White, "Time", RowTime, ColTime);
        Game.Screen.Print(ColorEnum.White, "Day", RowDate, ColDate);
        Game.Screen.Print(ColorEnum.BrightGreen, Game.GameTime.TimeText.PadLeft(8), RowTime, ColTime + 4);
        Game.Screen.Print(ColorEnum.BrightGreen, Game.GameTime.DateText.PadLeft(8), RowDate, ColDate + 4);
    }
}
