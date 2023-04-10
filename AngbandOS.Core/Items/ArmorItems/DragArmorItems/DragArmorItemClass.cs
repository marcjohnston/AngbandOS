namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class DragArmorItemClass : ArmourItemClass
    {
        public DragArmorItemClass(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<BodyInventorySlot>();
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.DragArmor;
        public override int PackSort => 19;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.Grey;
    }
}
