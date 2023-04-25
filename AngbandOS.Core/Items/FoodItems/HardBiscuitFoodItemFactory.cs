namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HardBiscuitFoodItemFactory : FoodItemFactory
    {
        private HardBiscuitFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ',';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Hard Biscuit";

        public override int Cost => 1;
        public override string FriendlyName => "& Hard Biscuit~";
        public override int Pval => 500;
        public override int? SubCategory => 32;
        public override int Weight => 2;
        public override bool Eat(SaveGame saveGame)
        {
            saveGame.MsgPrint("That tastes good.");
            return true;
        }

        public override void ApplyFlavourVisuals()
        {
            base.ApplyFlavourVisuals();
        }

        public override Item CreateItem() => new HardBiscuitFoodItem(SaveGame);
    }
}
