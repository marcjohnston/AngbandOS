namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HardLeatherArmourSoftArmorItem : SoftArmorItem
    {
        public HardLeatherArmourSoftArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SoftArmorHardLeatherArmour>()) { }
    }
}