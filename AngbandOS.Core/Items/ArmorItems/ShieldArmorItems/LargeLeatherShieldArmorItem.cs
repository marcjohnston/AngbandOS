namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LargeLeatherShieldArmorItem : ShieldArmorItem
    {
        public LargeLeatherShieldArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ShieldLargeLeatherShield>()) { }
    }
}