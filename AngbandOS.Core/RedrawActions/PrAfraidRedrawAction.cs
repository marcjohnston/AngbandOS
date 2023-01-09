
namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrAfraidRedrawAction : RedrawAction
    {
        private const int ColAfraid = 25;
        private const int RowAfraid = 44;
        public PrAfraidRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Draw()
        {
            if (SaveGame.Player.TimedFear.TimeRemaining > 0)
            {
                SaveGame.Print(Colour.Orange, "Afraid", RowAfraid, ColAfraid);
            }
            else
            {
                SaveGame.Print("      ", RowAfraid, ColAfraid);
            }
        }
    }
}
