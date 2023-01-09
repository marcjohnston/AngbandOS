
namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrConfusedRedrawAction : RedrawAction
    {
        private const int ColConfused = 15;
        private const int RowConfused = 44;
        public PrConfusedRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Draw()
        {
            if (SaveGame.Player.TimedConfusion.TimeRemaining > 0)
            {
                SaveGame.Print(Colour.Orange, "Confused", RowConfused, ColConfused);
            }
            else
            {
                SaveGame.Print("        ", RowConfused, ColConfused);
            }
        }
    }
}
