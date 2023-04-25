namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SicknessMushroomFoodItem : MushroomFoodItem
    {
        public SicknessMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SicknessMushroomFoodItemFactory>()) { }
    }
}