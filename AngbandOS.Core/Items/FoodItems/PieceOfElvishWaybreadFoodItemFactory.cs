namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PieceOfElvishWaybreadFoodItemFactory : FoodItemFactory
    {
        private PieceOfElvishWaybreadFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ',';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Piece of Elvish Waybread";

        public override int[] Chance => new int[] { 1, 1, 1, 0 };
        public override int Cost => 10;
        public override string FriendlyName => "& Piece~ of Elvish Waybread";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 10, 20, 0 };
        public override int Pval => 7500;
        public override int? SubCategory => 37;
        public override int Weight => 3;
        public override bool Eat()
        {
            SaveGame.MsgPrint("That tastes good.");
            SaveGame.Player.TimedPoison.ResetTimer();
            SaveGame.Player.RestoreHealth(Program.Rng.DiceRoll(4, 8));
            return true;
        }

        /// <summary>
        /// Returns true because waybread vanishes when a skeleton tries to eat it.
        /// </summary>
        public override bool VanishesWhenEatenBySkeletons => true;
        
        public override Item CreateItem() => new PieceOfElvishWaybreadFoodItem(SaveGame);
    }
}
