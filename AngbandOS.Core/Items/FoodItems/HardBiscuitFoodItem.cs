namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HardBiscuitFoodItem : FoodItem
    {
        public HardBiscuitFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HardBiscuitFoodItemFactory>()) { }
    }
}