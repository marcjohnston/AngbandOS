namespace AngbandOS.Core.Items;

[Serializable]
internal class ResistAcidAmuletJeweleryItem : AmuletJeweleryItem
{
    public ResistAcidAmuletJeweleryItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ResistAcidAmuletJeweleryItemFactory>()) { }
}