// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawHealthPointsFlaggedAction : FlaggedAction
{
    private const int RowMaxhp = 23;
    private const int RowCurhp = 24;
    private const int ColMaxhp = 0;
    private const int ColCurhp = 0;
    private RedrawHealthPointsFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        SaveGame.Screen.Print("Max HP ", RowMaxhp, ColMaxhp);
        string tmp = SaveGame.MaxHealth.ToString().PadLeft(5);
        ColorEnum color = ColorEnum.BrightGreen;
        SaveGame.Screen.Print(color, tmp, RowMaxhp, ColMaxhp + 7);
        SaveGame.Screen.Print("Cur HP ", RowCurhp, ColCurhp);
        tmp = SaveGame.Health.Value.ToString().PadLeft(5);
        if (SaveGame.Health.Value >= SaveGame.MaxHealth)
        {
            color = ColorEnum.BrightGreen;
        }
        else if (SaveGame.Health.Value > SaveGame.MaxHealth * Constants.HitpointWarn / 5)
        {
            color = ColorEnum.BrightYellow;
        }
        else if (SaveGame.Health.Value > SaveGame.MaxHealth * Constants.HitpointWarn / 10)
        {
            color = ColorEnum.Orange;
        }
        else
        {
            color = ColorEnum.BrightRed;
        }
        SaveGame.Screen.Print(color, tmp, RowCurhp, ColCurhp + 7);
    }
}
