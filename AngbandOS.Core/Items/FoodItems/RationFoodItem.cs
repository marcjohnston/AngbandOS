namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RationFoodItem : FoodItem
    {
        public RationFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<FoodRation>()) { }
    }
}