// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawExperiencePointsFlaggedAction : FlaggedAction
{
    private const int RowExp = 6;
    private const int ColExp = 0;
    private RedrawExperiencePointsFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        ColorEnum color = ColorEnum.BrightGreen;
        if (SaveGame.ExperiencePoints.Value < SaveGame.MaxExperienceGained)
        {
            color = ColorEnum.Yellow;
        }
        SaveGame.Screen.Print("NEXT", RowExp, 0);
        if (SaveGame.ExperienceLevel.Value >= Constants.PyMaxLevel)
        {
            SaveGame.Screen.Print(ColorEnum.BrightGreen, "   *****", RowExp, ColExp + 4);
        }
        else
        {
            string outVal = ((Constants.PlayerExp[SaveGame.ExperienceLevel.Value - 1] * SaveGame.ExperienceMultiplier / 100) - SaveGame.ExperiencePoints.Value).ToString()
                .PadLeft(8);
            SaveGame.Screen.Print(color, outVal, RowExp, ColExp + 4);
        }
    }
}
