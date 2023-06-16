namespace AngbandOS.Core.Items;

[Serializable]
internal class BrillianceAmuletJeweleryItem : AmuletJeweleryItem
{
    public BrillianceAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BrillianceAmuletJeweleryItemFactory>()) { }
}