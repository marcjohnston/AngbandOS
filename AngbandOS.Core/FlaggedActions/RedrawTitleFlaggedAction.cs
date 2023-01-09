namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawTitleFlaggedAction : FlaggedAction
    {
        private const int RowTitle = 4;
        private const int ColTitle = 0;
        public RedrawTitleFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        private void PrtField(string info, int row, int col) // TODO: Duplicate with PrPlayerRedrawAction
        {
            SaveGame.Print(Colour.White, "             ", row, col);
            SaveGame.Print(Colour.BrightBlue, info, row, col);
        }
        protected override void Execute()
        {
            if (SaveGame.Player.IsWizard)
            {
                PrtField("-=<WIZARD>=-", RowTitle, ColTitle);
            }
            else if (SaveGame.Player.IsWinner || SaveGame.Player.Level > Constants.PyMaxLevel)
            {
                PrtField("***WINNER***", RowTitle, ColTitle);
            }
        }
    }
}
