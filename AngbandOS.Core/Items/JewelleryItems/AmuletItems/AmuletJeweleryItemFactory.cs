namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class AmuletJeweleryItemFactory : JewelleryItemFactory, IFlavour
    {
        public AmuletJeweleryItemFactory(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<NeckInventorySlot>();
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Amulet;
        public override int PackSort => 17;
        public override int BaseValue => 45;
        public override Colour Colour => Colour.Orange;
        public override int? SubCategory => null; // All amulet subcategories have been refactored.

        /// <summary>
        /// Returns the amulet flavours repository because amulets have flavours that need to be identified.
        /// </summary>
        public IEnumerable<Flavour> Flavours => SaveGame.SingletonRepository.AmuletFlavours;
    }
}
