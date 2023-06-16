namespace AngbandOS.Core.Items;

[Serializable]
internal class AntiTheftAmuletJeweleryItem : AmuletJeweleryItem
{
    public AntiTheftAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AntiTheftAmuletJeweleryItemFactory>()) { }
}