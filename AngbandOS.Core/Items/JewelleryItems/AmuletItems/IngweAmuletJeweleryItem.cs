namespace AngbandOS.Core.Items;

[Serializable]
internal class IngweAmuletJeweleryItem : AmuletJeweleryItem
{
    public IngweAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<IngweAmuletJeweleryItemFactory>()) { }
}