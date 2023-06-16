namespace AngbandOS.Core.Items;

[Serializable]
internal class TeleportationAmuletJeweleryItem : AmuletJeweleryItem
{
    public TeleportationAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<TeleportationAmuletJeweleryItemFactory>()) { }
}