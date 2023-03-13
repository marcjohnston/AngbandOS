namespace AngbandOS.Core.Items
{
[Serializable]
    internal class EnchantWeaponToHitScrollItem : ScrollItem
    {
        public EnchantWeaponToHitScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollEnchantWeaponToHit>()) { }
    }
}