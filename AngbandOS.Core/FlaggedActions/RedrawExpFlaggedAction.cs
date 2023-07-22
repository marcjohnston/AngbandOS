// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawExpFlaggedAction : FlaggedAction
{
    private const int RowExp = 6;
    private const int ColExp = 0;
    public RedrawExpFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        ColourEnum colour = ColourEnum.BrightGreen;
        if (SaveGame.ExperiencePoints < SaveGame.MaxExperienceGained)
        {
            colour = ColourEnum.Yellow;
        }
        SaveGame.Screen.Print("NEXT", RowExp, 0);
        if (SaveGame.ExperienceLevel >= Constants.PyMaxLevel)
        {
            SaveGame.Screen.Print(ColourEnum.BrightGreen, "   *****", RowExp, ColExp + 4);
        }
        else
        {
            string outVal = ((Constants.PlayerExp[SaveGame.ExperienceLevel - 1] * SaveGame.ExperienceMultiplier / 100) - SaveGame.ExperiencePoints).ToString()
                .PadLeft(8);
            SaveGame.Screen.Print(colour, outVal, RowExp, ColExp + 4);
        }
    }
}
