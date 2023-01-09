namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrTitleRedrawAction : RedrawAction
    {
        private const int RowTitle = 4;
        private const int ColTitle = 0;
        public PrTitleRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Draw()
        {
            string p;
            if (SaveGame.Player.IsWizard)
            {
                p = "-=<WIZARD>=-";
                SaveGame.PrtField(p, RowTitle, ColTitle);
            }
            else if (SaveGame.Player.IsWinner || SaveGame.Player.Level > Constants.PyMaxLevel)
            {
                p = "***WINNER***";
                SaveGame.PrtField(p, RowTitle, ColTitle);
            }
        }
    }
}
