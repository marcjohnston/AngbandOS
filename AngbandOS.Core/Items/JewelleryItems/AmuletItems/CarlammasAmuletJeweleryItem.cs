namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CarlammasAmuletJeweleryItem : AmuletJeweleryItem
    {
        public CarlammasAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<CarlammasAmuletJeweleryItemFactory>()) { }
    }
}