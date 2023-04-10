namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class ShieldItemClass : ArmourItemClass
    {
        public ShieldItemClass(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<ArmInventorySlot>();
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Shield;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBrown;

        public override bool CanReflectBoltsAndArrows => true;
    }
}
