namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class FoodRation : FoodItemClass
    {
        private FoodRation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ',';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Ration of Food";

        public override int[] Chance => new int[] { 1, 1, 1, 0 };
        public override int Cost => 3;
        public override string FriendlyName => "& Ration~ of Food";
        public override int[] Locale => new int[] { 0, 5, 10, 0 };
        public override int Pval => 5000;
        public override int? SubCategory => 35;
        public override int Weight => 10;

        public override bool Eat(SaveGame saveGame)
        {
            saveGame.MsgPrint("That tastes good.");
            return true;
        }
    }
}
