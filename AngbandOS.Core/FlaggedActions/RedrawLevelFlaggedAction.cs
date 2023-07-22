// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawLevelFlaggedAction : FlaggedAction
{
    private const int RowLevel = 5;
    private const int ColLevel = 0;
    public RedrawLevelFlaggedAction(SaveGame saveGame) : base (saveGame) { }
    protected override void Execute()
    {
        string tmp = SaveGame.ExperienceLevel.ToString().PadLeft(6);
        if (SaveGame.ExperienceLevel >= SaveGame.MaxLevelGained)
        {
            SaveGame.Screen.Print("LEVEL ", RowLevel, 0);
            SaveGame.Screen.Print(ColourEnum.BrightGreen, tmp, RowLevel, ColLevel + 6);
        }
        else
        {
            SaveGame.Screen.Print("Level ", RowLevel, 0);
            SaveGame.Screen.Print(ColourEnum.Yellow, tmp, RowLevel, ColLevel + 6);
        }
    }
}
