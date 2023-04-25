namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RibbedPlateArmourHardArmorItem : HardArmorItem
    {
        public RibbedPlateArmourHardArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HardArmorRibbedPlateArmour>()) { }
    }
}