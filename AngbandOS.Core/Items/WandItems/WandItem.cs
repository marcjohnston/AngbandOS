namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class WandItem : Item
    {
        public WandItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PercentageBreakageChance => 25;
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
        public override string GetDescription(bool includeCountPrefix)
        {
            string flavour = IdentStoreb ? "" : $"{SaveGame.SingletonRepository.WandFlavours[ItemSubCategory].Name} ";
            string ofName = IsFlavourAware() ? $" of {Factory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Wand", Count)}{ofName}";
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