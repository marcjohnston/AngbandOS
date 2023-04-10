namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class RodItem : Item
    {
        public RodItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        protected override bool FactoryCanAbsorbItem(Item other)
        {
            if (TypeSpecificValue != other.TypeSpecificValue)
            {
                return false;
            }
            return true;
        }
        public override string GetDescription(bool includeCountPrefix)
        {
            string flavour = IdentStoreb ? "" : $"{SaveGame.SingletonRepository.RodFlavours[ItemSubCategory].Name} ";
            string ofName = IsFlavourAware() ? $" of {Factory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Rod", Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, Count, IsKnownArtifact) : name;
        }
        public override string GetVerboseDescription()
        {
            string s = "";
            if (IsKnown() && TypeSpecificValue != 0)
            {
                s += $" (charging)";
            }
            s += base.GetVerboseDescription();
            return s;
        }
    }
}