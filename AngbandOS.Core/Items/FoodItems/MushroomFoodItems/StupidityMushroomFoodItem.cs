namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StupidityMushroomFoodItem : MushroomFoodItem
    {
        public StupidityMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StupidityMushroomFoodItemFactory>()) { }
    }
}