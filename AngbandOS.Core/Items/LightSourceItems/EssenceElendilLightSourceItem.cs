namespace AngbandOS.Core.Items
{
[Serializable]
    internal class EssenceElendilLightSourceItem : LightSourceItem
    {
        public EssenceElendilLightSourceItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<LightStarEssenceElendil>()) { }
    }
}