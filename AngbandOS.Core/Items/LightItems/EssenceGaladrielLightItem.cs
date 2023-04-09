namespace AngbandOS.Core.Items
{
[Serializable]
    internal class EssenceGaladrielLightItem : LightItem
    {
        public EssenceGaladrielLightItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<LightStarEssenceGaladriel>()) { }
    }
}