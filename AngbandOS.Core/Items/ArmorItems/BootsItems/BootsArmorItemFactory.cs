namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class BootsArmorItemFactory : ArmourItemFactory
    {
        public BootsArmorItemFactory(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<FeetInventorySlot>();
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Boots;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;
        public override int PackSort => 27;

        public override Colour Colour => Colour.BrightBrown;
    }
}
