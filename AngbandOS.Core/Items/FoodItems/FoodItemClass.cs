namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class FoodItemClass : ItemFactory
    {
        public FoodItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool EasyKnow => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Food;
        public override int PackSort => 9;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            if (item.ItemSubCategory >= FoodType.MinFood)
            {
                return base.GetDescription(item, includeCountPrefix);
            }
            string flavour = item.IdentStoreb ? "" : $"{item.SaveGame.SingletonRepository.MushroomFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.Factory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Mushroom", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 5;
        //public override bool CanBeConsumed => true;
        public override Colour Colour => Colour.Green;


        public abstract bool Eat(SaveGame saveGame);
    }
}
