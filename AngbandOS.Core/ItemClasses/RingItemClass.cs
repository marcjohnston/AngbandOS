namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class RingItemClass : JewelleryItemClass
    {
        public RingItemClass(SaveGame saveGame) : base(saveGame) { }
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
        public override bool HasFlavor => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Ring;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            if (item.FixedArtifact != null && item.IsFlavourAware())
            {
                return base.GetDescription(item, includeCountPrefix);
            }
            string flavour = item.IdentStoreb ? "" : $"{item.SaveGame.SingletonRepository.RingFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.Factory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Ring", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 45;
        public override bool HatesElectricity => true;
        public override Colour Colour => Colour.Gold;

        public override string DescribeActivationEffect(Item item)
        {
            switch (item.ItemSubCategory)
            {
                case RingType.Flames:
                    return "ball of fire and resist fire";

                case RingType.Ice:
                    return "ball of cold and resist cold";

                case RingType.Acid:
                    return "ball of acid and resist acid";

                default:
                    return null;
            }
        }
    }
}
