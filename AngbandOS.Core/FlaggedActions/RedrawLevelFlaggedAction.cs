namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawLevelFlaggedAction : FlaggedAction
    {
        private const int RowLevel = 5;
        private const int ColLevel = 0;
        public RedrawLevelFlaggedAction(SaveGame saveGame) : base (saveGame) { }
        protected override void Execute()
        {
            string tmp = SaveGame.Player.Level.ToString().PadLeft(6);
            if (SaveGame.Player.Level >= SaveGame.Player.MaxLevelGained)
            {
                SaveGame.Print("LEVEL ", RowLevel, 0);
                SaveGame.Print(Colour.BrightGreen, tmp, RowLevel, ColLevel + 6);
            }
            else
            {
                SaveGame.Print("Level ", RowLevel, 0);
                SaveGame.Print(Colour.Yellow, tmp, RowLevel, ColLevel + 6);
            }
        }
    }
}
