// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawStatsFlaggedAction : FlaggedAction
{
    private const int RowStat = 15;
    private const int ColStat = 6;
    private RedrawStatsFlaggedAction(Game game) : base(game) { }
    private void PrtStat(int stat)
    {
        if (Game.AbilityScores[stat].Innate < Game.AbilityScores[stat].InnateMax)
        {
            Game.Screen.Print(Constants.StatNamesReduced[stat], RowStat + stat, 0);
            string tmp = Game.AbilityScores[stat].Adjusted.StatToString();
            Game.Screen.Print(ColorEnum.Yellow, tmp, RowStat + stat, ColStat);
        }
        else
        {
            Game.Screen.Print(Constants.StatNames[stat], RowStat + stat, 0);
            string tmp = Game.AbilityScores[stat].Adjusted.StatToString();
            Game.Screen.Print(ColorEnum.BrightGreen, tmp, RowStat + stat, ColStat);
        }
        if (Game.AbilityScores[stat].InnateMax == 18 + 100)
        {
            Game.Screen.Print("!", RowStat + stat, 3);
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
