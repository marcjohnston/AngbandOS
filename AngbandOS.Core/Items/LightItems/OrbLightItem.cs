namespace AngbandOS.Core.Items
{
[Serializable]
    internal class OrbLightItem : LightItem
    {
        public OrbLightItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<LightOrb>()) { }
    }
}