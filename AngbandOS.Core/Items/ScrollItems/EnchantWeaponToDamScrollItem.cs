namespace AngbandOS.Core.Items
{
[Serializable]
    internal class EnchantWeaponToDamScrollItem : ScrollItem
    {
        public EnchantWeaponToDamScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollEnchantWeaponToDam>()) { }
    }
}