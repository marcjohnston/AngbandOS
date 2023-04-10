namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ScrollItem : Item
    {
        public ScrollItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PercentageBreakageChance => 50;
        protected override bool FactoryCanAbsorbItem(Item other)
        {
            return true;
        }
        public override int GetAdditionalMassProduceCount()
        {
            int cost = Value();
            if (cost <= 60)
            {
                return MassRoll(3, 5);
            }
            if (cost <= 240)
            {
                return MassRoll(1, 5);
            }
            return 0;
        }
        public override string GetDescription(bool includeCountPrefix)
        {
            string flavour = IdentStoreb ? "" : $" titled \"{SaveGame.ScrollFlavours[ItemSubCategory].Name}\"";
            string ofName = IsFlavourAware() ? $" of {Factory.FriendlyName}" : "";
            string name = $"{Pluralize("Scroll", Count)}{flavour}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, Count, IsKnownArtifact) : name;
        }
    }
}