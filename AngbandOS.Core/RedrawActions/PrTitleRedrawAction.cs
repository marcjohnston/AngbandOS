namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrTitleRedrawAction : RedrawAction
    {
        private const int RowTitle = 4;
        private const int ColTitle = 0;
        public PrTitleRedrawAction(SaveGame saveGame) : base(saveGame) { }
        private void PrtField(string info, int row, int col) // TODO: Duplicate with PrPlayerRedrawAction
        {
            SaveGame.Print(Colour.White, "             ", row, col);
            SaveGame.Print(Colour.BrightBlue, info, row, col);
        }
        protected override void Draw()
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
