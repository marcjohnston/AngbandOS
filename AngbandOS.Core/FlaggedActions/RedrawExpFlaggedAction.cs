namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawExpFlaggedAction : FlaggedAction
    {
        private const int RowExp = 6;
        private const int ColExp = 0;
        public RedrawExpFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            Colour colour = Colour.BrightGreen;
            if (SaveGame.Player.ExperiencePoints < SaveGame.Player.MaxExperienceGained)
            {
                colour = Colour.Yellow;
            }
            SaveGame.Screen.Print("NEXT", RowExp, 0);
            if (SaveGame.Player.Level >= Constants.PyMaxLevel)
            {
                SaveGame.Screen.Print(Colour.BrightGreen, "   *****", RowExp, ColExp + 4);
            }
            else
            {
                string outVal = ((Constants.PlayerExp[SaveGame.Player.Level - 1] * SaveGame.Player.ExperienceMultiplier / 100) - SaveGame.Player.ExperiencePoints).ToString()
                    .PadLeft(8);
                SaveGame.Screen.Print(colour, outVal, RowExp, ColExp + 4);
            }
        }
    }
}
