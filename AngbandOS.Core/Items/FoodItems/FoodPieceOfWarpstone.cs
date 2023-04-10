namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class FoodPieceOfWarpstone : FoodItemClass
    {
        private FoodPieceOfWarpstone(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '*';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Piece of Warpstone";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Piece~ of Warpstone";
        public override int Level => 30;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int? SubCategory => 40;
        public override int Weight => 1;
        public override bool Eat(SaveGame saveGame)
        {
            saveGame.MsgPrint("That tastes... funky.");
            saveGame.Player.Dna.GainMutation();
            if (Program.Rng.DieRoll(3) == 1)
            {
                saveGame.Player.Dna.GainMutation();
            }
            if (Program.Rng.DieRoll(3) == 1)
            {
                saveGame.Player.Dna.GainMutation();
            }
            return true;
        }
        public override Item CreateItem() => new PieceOfWarpstoneFoodItem(SaveGame);
    }
}
