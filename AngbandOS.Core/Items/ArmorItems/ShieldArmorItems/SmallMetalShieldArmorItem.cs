namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SmallMetalShieldArmorItem : ShieldArmorItem
    {
        public SmallMetalShieldArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ShieldSmallMetalShield>()) { }
    }
}