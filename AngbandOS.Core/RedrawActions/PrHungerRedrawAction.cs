
namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrHungerRedrawAction : RedrawAction
    {
        private const int ColHungry = 0;
        private const int RowHungry = 44;
        public PrHungerRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Draw()
        {
            if (SaveGame.Player.Food < Constants.PyFoodFaint)
            {
                SaveGame.Print(Colour.Red, "Weak  ", RowHungry, ColHungry);
            }
            else if (SaveGame.Player.Food < Constants.PyFoodWeak)
            {
                SaveGame.Print(Colour.Orange, "Weak  ", RowHungry, ColHungry);
            }
            else if (SaveGame.Player.Food < Constants.PyFoodAlert)
            {
                SaveGame.Print(Colour.Yellow, "Hungry", RowHungry, ColHungry);
            }
            else if (SaveGame.Player.Food < Constants.PyFoodFull)
            {
                SaveGame.Print(Colour.BrightGreen, "      ", RowHungry, ColHungry);
            }
            else if (SaveGame.Player.Food < Constants.PyFoodMax)
            {
                SaveGame.Print(Colour.BrightGreen, "Full  ", RowHungry, ColHungry);
            }
            else
            {
                SaveGame.Print(Colour.Green, "Gorged", RowHungry, ColHungry);
            }
        }
    }
}
