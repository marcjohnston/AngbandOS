
namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrBlindRedrawAction : RedrawAction
    {
        private const int ColBlind = 8;
        private const int RowBlind = 44;
        public PrBlindRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Draw()
        {
            if (SaveGame.Player.TimedBlindness.TimeRemaining > 0)
            {
                SaveGame.Print(Colour.Orange, "Blind", RowBlind, ColBlind);
            }
            else
            {
                SaveGame.Print("     ", RowBlind, ColBlind);
            }
        }
    }
}
