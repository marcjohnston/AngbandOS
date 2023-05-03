namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SlimeMoldFoodItemFactory : FoodItemFactory
    {
        private SlimeMoldFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ',';
        public override Colour Colour => Colour.Green;
        public override string Name => "Slime Mold";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 2;
        public override string FriendlyName => "& Slime Mold~";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int Pval => 3000;
        public override int? SubCategory => 36;
        public override int Weight => 5;
        public override bool Eat()
        {
            PotionItemFactory slimeMold = (PotionItemFactory)SaveGame.SingletonRepository.ItemFactories.Get<SlimeMoldJuicePotionItemFactory>();
            slimeMold.Quaff(SaveGame);
            return true;
        }
        public override Item CreateItem() => new SlimeMoldFoodItem(SaveGame);
    }
}
