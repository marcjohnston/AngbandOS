namespace AngbandOS.Core.Items;

[Serializable]
internal class AdornmentAmuletJeweleryItem : AmuletJeweleryItem
{
    public AdornmentAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AdornmentAmuletJeweleryItemFactory>()) { }
}