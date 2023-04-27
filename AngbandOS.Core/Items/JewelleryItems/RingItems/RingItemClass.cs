namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class RingItemClass : JewelleryItemFactory, IFlavour
    {
        public RingItemClass(SaveGame saveGame) : base(saveGame) { }

        /// <summary>
        /// Returns the ring flavours repository because rings have flavours that need to be identified.
        /// </summary>
        public IEnumerable<Flavour> Flavours => SaveGame.SingletonRepository.RingFlavours;

        public override BaseInventorySlot BaseWieldSlot
        {
            get
            {
                BaseInventorySlot rightHand = SaveGame.SingletonRepository.InventorySlots.Get<RightHandInventorySlot>();
                if (rightHand.Count == 0)
                {
                    return rightHand;
                }
                return SaveGame.SingletonRepository.InventorySlots.Get<LeftHandInventorySlot>();
            }
        }
        public override int PackSort => 16;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Ring;
        public override int BaseValue => 45;
        public override bool HatesElectricity => true;
        public override Colour Colour => Colour.Gold;
    }
}
