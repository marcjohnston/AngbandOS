namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SpecialEnchantArmorScrollItem : ScrollItem
    {
        public SpecialEnchantArmorScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollSpecialEnchantArmor>()) { }
    }
}