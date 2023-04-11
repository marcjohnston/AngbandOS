namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StarEssenceElendilLightSourceItem : LightSourceItem
    {
        public StarEssenceElendilLightSourceItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StarEssenceElendilLightSourceItemFactory>()) { }
    }
}