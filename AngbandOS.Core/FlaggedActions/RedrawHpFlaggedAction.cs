namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawHpFlaggedAction : FlaggedAction
    {
        private const int RowMaxhp = 23;
        private const int RowCurhp = 24;
        private const int ColMaxhp = 0;
        private const int ColCurhp = 0;
        public RedrawHpFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            SaveGame.Print("Max HP ", RowMaxhp, ColMaxhp);
            string tmp = SaveGame.Player.MaxHealth.ToString().PadLeft(5);
            Colour colour = Colour.BrightGreen;
            SaveGame.Print(colour, tmp, RowMaxhp, ColMaxhp + 7);
            SaveGame.Print("Cur HP ", RowCurhp, ColCurhp);
            tmp = SaveGame.Player.Health.ToString().PadLeft(5);
            if (SaveGame.Player.Health >= SaveGame.Player.MaxHealth)
            {
                colour = Colour.BrightGreen;
            }
            else if (SaveGame.Player.Health > SaveGame.Player.MaxHealth * GlobalData.HitpointWarn / 5)
            {
                colour = Colour.BrightYellow;
            }
            else if (SaveGame.Player.Health > SaveGame.Player.MaxHealth * GlobalData.HitpointWarn / 10)
            {
                colour = Colour.Orange;
            }
            else
            {
                colour = Colour.BrightRed;
            }
            SaveGame.Print(colour, tmp, RowCurhp, ColCurhp + 7);
        }
    }
}
