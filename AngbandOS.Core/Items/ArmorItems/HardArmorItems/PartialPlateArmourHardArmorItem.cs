namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PartialPlateArmourHardArmorItem : HardArmorItem
    {
        public PartialPlateArmourHardArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HardArmorPartialPlateArmour>()) { }
    }
}