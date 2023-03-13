namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StripOfVenisonFoodItem : FoodItem
    {
        public StripOfVenisonFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<FoodStripOfVenison>()) { }
    }
}