namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class StaffItem : Item
    {
        public StaffItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int? GetBonusRealValue(int value)
        {
            return value / 20 * TypeSpecificValue;
        }
        protected override bool FactoryCanAbsorbItem(Item other)
        {
            if (!IsKnown() || !other.IsKnown())
            {
                return false;
            }
            if (TypeSpecificValue != other.TypeSpecificValue)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns the factory that this item was created by; casted as an IFlavour.
        /// </summary>
        public IFlavour FlavourFactory => (IFlavour)Factory;

        public override string GetDescription(bool includeCountPrefix)
        {
            string flavour = IdentStoreb ? "" : $"{FlavourFactory.Flavour.Name} ";
            string ofName = IsFlavourAware() ? $" of {Factory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Staff", Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, Count, IsKnownArtifact) : name;
        }
        public override string GetVerboseDescription()
        {
            string s = "";
            if (IsKnown())
            {
                s += $" ({TypeSpecificValue} {Pluralize("charge", TypeSpecificValue)})";
            }
            s += base.GetVerboseDescription();
            return s;
        }
    }
}