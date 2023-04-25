namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StripOfVenisonFoodItemFactory : FoodItemFactory
    {
        private StripOfVenisonFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ',';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Strip of Venison";

        public override int Cost => 2;
        public override string FriendlyName => "& Strip~ of Venison";
        public override int Pval => 1500;
        public override int? SubCategory => 33;
        public override int Weight => 2;
        public override bool Eat(SaveGame saveGame)
        {
            saveGame.MsgPrint("That tastes good.");
            return true;
        }
        public override Item CreateItem() => new StripOfVenisonFoodItem(SaveGame);
    }
}
