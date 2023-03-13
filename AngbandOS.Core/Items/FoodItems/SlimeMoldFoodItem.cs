namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlimeMoldFoodItem : FoodItem
    {
        public SlimeMoldFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<FoodSlimeMold>()) { }
    }
}