namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class AmuletItemClass : JewelleryItemClass
    {
        public AmuletItemClass(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<NeckInventorySlot>();
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Amulet;
        public override int PackSort => 17;
        public override int BaseValue => 45;
        public override Colour Colour => Colour.Orange;
        public override int? SubCategory => null; // All amulet subcategories have been refactored.
        public override bool HasFlavor => true;
    }
}
