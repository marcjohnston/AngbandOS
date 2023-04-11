namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StarEssenceGaladrielLightSourceItem : LightSourceItem
    {
        public StarEssenceGaladrielLightSourceItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StarEssenceGaladrielLightSourceItemFactory>()) { }
    }
}