namespace AngbandOS.Core.Items
{
[Serializable]
    internal class EnchantArmorScrollItem : ScrollItem
    {
        public EnchantArmorScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollEnchantArmor>()) { }
    }
}