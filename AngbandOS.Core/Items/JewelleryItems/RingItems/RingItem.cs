namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class RingItem : JewelleryItem
    {
        public override int WieldSlot
        {
            get
            {
                if (SaveGame.GetInventoryItem(InventorySlot.RightHand) == null)
                {
                    return InventorySlot.RightHand;
                }
                return InventorySlot.LeftHand;
            }
        }
        public RingItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override string GetDescription(bool includeCountPrefix)
        {
            if (FixedArtifact != null && IsFlavourAware())
            {
                return base.GetDescription(includeCountPrefix);
            }
            string flavour = IdentStoreb ? "" : $"{SaveGame.SingletonRepository.RingFlavours[ItemSubCategory].Name} ";
            string ofName = IsFlavourAware() ? $" of {Factory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Ring", Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, Count, IsKnownArtifact) : name;
        }

        public override string? FactoryDescribeActivationEffect()
        {
            switch (ItemSubCategory)
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