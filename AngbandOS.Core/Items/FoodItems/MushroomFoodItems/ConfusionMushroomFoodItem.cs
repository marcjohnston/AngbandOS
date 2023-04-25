namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ConfusionMushroomFoodItem : MushroomFoodItem
    {
        public ConfusionMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ConfusionMushroomFoodItemFactory>()) { }
    }
}