namespace AngbandOS.Core.Items
{
[Serializable]
    internal class NecklaceAmuletJeweleryItem : AmuletJeweleryItem
    {
        public NecklaceAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<NecklaceAmuletJeweleryItemFactory>()) { }
    }
}