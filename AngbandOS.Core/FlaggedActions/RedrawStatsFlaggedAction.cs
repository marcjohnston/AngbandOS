
namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawStatsFlaggedAction : FlaggedAction
{
    private const int RowStat = 15;
    private const int ColStat = 6;
    public RedrawStatsFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    private void PrtStat(int stat)
    {
        if (SaveGame.Player.AbilityScores[stat].Innate < SaveGame.Player.AbilityScores[stat].InnateMax)
        {
            SaveGame.Screen.Print(Constants.StatNamesReduced[stat], RowStat + stat, 0);
            string tmp = SaveGame.Player.AbilityScores[stat].Adjusted.StatToString();
            SaveGame.Screen.Print(Colour.Yellow, tmp, RowStat + stat, ColStat);
        }
        else
        {
            SaveGame.Screen.Print(Constants.StatNames[stat], RowStat + stat, 0);
            string tmp = SaveGame.Player.AbilityScores[stat].Adjusted.StatToString();
            SaveGame.Screen.Print(Colour.BrightGreen, tmp, RowStat + stat, ColStat);
        }
        if (SaveGame.Player.AbilityScores[stat].InnateMax == 18 + 100)
        {
            SaveGame.Screen.Print("!", RowStat + stat, 3);
        }
    }

    protected override void Execute()
    {
        PrtStat(Ability.Strength);
        PrtStat(Ability.Intelligence);
        PrtStat(Ability.Wisdom);
        PrtStat(Ability.Dexterity);
        PrtStat(Ability.Constitution);
        PrtStat(Ability.Charisma);
    }
}
