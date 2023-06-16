namespace AngbandOS.Core.Items;

[Serializable]
internal class ReflectionAmuletJeweleryItem : AmuletJeweleryItem
{
    public ReflectionAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ReflectionAmuletJeweleryItemFactory>()) { }
}