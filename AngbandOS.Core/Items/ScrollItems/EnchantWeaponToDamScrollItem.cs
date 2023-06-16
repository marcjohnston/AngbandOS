namespace AngbandOS.Core.Items;

[Serializable]
internal class EnchantWeaponToDamScrollItem : ScrollItem
{
    public EnchantWeaponToDamScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollEnchantWeaponToDam>()) { }
}