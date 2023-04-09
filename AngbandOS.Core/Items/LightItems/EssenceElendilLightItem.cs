namespace AngbandOS.Core.Items
{
[Serializable]
    internal class EssenceElendilLightItem : LightItem
    {
        public EssenceElendilLightItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<LightStarEssenceElendil>()) { }
        public override bool InstaArt => true;
    }
}