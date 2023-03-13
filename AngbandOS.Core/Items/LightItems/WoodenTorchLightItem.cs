namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WoodenTorchLightItem : LightItem
    {
        public WoodenTorchLightItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<LightWoodenTorch>()) { }
    }
}