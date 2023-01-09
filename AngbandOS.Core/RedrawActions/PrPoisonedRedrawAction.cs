
namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrPoisonedRedrawAction : RedrawAction
    {
        private const int ColPoisoned = 33;
        private const int RowPoisoned = 44;
        public PrPoisonedRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Draw()
        {
            if (SaveGame.Player.TimedPoison.TimeRemaining > 0)
            {
                SaveGame.Print(Colour.Orange, "Poisoned", RowPoisoned, ColPoisoned);
            }
            else
            {
                SaveGame.Print("        ", RowPoisoned, ColPoisoned);
            }
        }
    }
}
