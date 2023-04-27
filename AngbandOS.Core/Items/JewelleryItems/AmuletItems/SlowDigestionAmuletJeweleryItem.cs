namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlowDigestionAmuletJeweleryItem : AmuletJeweleryItem
    {
        public SlowDigestionAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SlowDigestionAmuletJeweleryItemFactory>()) { }
    }
}