namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HardStuddedLeatherSoftArmorItem : SoftArmorItem
    {
        public HardStuddedLeatherSoftArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SoftArmorHardStuddedLeather>()) { }
    }
}