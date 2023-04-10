namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class GlovesItemClass : ArmourItemClass
    {
        public GlovesItemClass(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<HandsInventorySlot>();
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Gloves;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBrown;

        public override int? SubCategory => null; // No longer being used
    }
}
