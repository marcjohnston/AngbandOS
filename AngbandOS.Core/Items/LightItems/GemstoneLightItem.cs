namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GemstoneLightItem : LightItem
    {
        public GemstoneLightItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<LightGemstone>()) { }
    }
}