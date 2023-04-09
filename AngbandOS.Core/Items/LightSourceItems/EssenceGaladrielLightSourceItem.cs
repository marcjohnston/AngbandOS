namespace AngbandOS.Core.Items
{
[Serializable]
    internal class EssenceGaladrielLightSourceItem : LightSourceItem
    {
        public EssenceGaladrielLightSourceItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<LightStarEssenceGaladriel>()) { }
    }
}