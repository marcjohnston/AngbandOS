namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SpecialEnchantWeaponScrollItem : ScrollItem
    {
        public SpecialEnchantWeaponScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollSpecialEnchantWeapon>()) { }
    }
}