namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SoftStuddedLeatherSoftArmorItem : SoftArmorItem
    {
        public SoftStuddedLeatherSoftArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SoftArmorSoftStuddedLeather>()) { }
    }
}