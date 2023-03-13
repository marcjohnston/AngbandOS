namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BrassLanternLightItem : LightItem
    {
        public BrassLanternLightItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<LightBrassLantern>()) { }
    }
}