
namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrStatsRedrawAction : RedrawAction
    {
        private const int RowStat = 15;
        private const int ColStat = 6;
        public PrStatsRedrawAction(SaveGame saveGame) : base(saveGame) { }
        private void PrtStat(int stat)
        {
            if (SaveGame.Player.AbilityScores[stat].Innate < SaveGame.Player.AbilityScores[stat].InnateMax)
            {
                SaveGame.Print(GlobalData.StatNamesReduced[stat], RowStat + stat, 0);
                string tmp = SaveGame.Player.AbilityScores[stat].Adjusted.StatToString();
                SaveGame.Print(Colour.Yellow, tmp, RowStat + stat, ColStat);
            }
            else
            {
                SaveGame.Print(GlobalData.StatNames[stat], RowStat + stat, 0);
                string tmp = SaveGame.Player.AbilityScores[stat].Adjusted.StatToString();
                SaveGame.Print(Colour.BrightGreen, tmp, RowStat + stat, ColStat);
            }
            if (SaveGame.Player.AbilityScores[stat].InnateMax == 18 + 100)
            {
                SaveGame.Print("!", RowStat + stat, 3);
            }
        }

        protected override void Draw()
        {
            PrtStat(Ability.Strength);
            PrtStat(Ability.Intelligence);
            PrtStat(Ability.Wisdom);
            PrtStat(Ability.Dexterity);
            PrtStat(Ability.Constitution);
            PrtStat(Ability.Charisma);
        }
    }
}
