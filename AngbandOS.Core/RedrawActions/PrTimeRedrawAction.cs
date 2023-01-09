
namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrTimeRedrawAction : RedrawAction
    {
        private const int ColDate = 0;
        private const int RowDate = 9;
        private const int ColTime = 0;
        private const int RowTime = 8;
        public PrTimeRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Draw()
        {
            SaveGame.Print(Colour.White, "Time", RowTime, ColTime);
            SaveGame.Print(Colour.White, "Day", RowDate, ColDate);
            SaveGame.Print(Colour.BrightGreen, SaveGame.Player.GameTime.TimeText.PadLeft(8), RowTime, ColTime + 4);
            SaveGame.Print(Colour.BrightGreen, SaveGame.Player.GameTime.DateText.PadLeft(8), RowDate, ColDate + 4);
        }
    }
}
