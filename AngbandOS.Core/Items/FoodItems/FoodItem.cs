namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class FoodItem : Item
    {
        public FoodItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PercentageBreakageChance => 100;
        protected override bool FactoryCanAbsorbItem(Item other)
        {
            return true;
        }
        public override int GetAdditionalMassProduceCount()
        {
            int cost = Value();
            if (cost <= 5)
            {
                return MassRoll(3, 5);
            }
            if (cost <= 20)
            {
                return MassRoll(3, 5);
            }
            return 0;
        }
        public override string GetDescription(bool includeCountPrefix)
        {
            if (ItemSubCategory >= FoodType.MinFood)
            {
                return base.GetDescription(includeCountPrefix);
            }
            string flavour = IdentStoreb ? "" : $"{SaveGame.SingletonRepository.MushroomFlavours[ItemSubCategory].Name} ";
            string ofName = IsFlavourAware() ? $" of {Factory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Mushroom", Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, Count, IsKnownArtifact) : name;
        }
    }
}