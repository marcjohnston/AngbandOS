namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ConfusionMushroomFoodItemFactory : MushroomFoodItemFactory
    {
        private ConfusionMushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ',';
        public override string Name => "Confusion";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Confusion";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 3;
        public override int Weight => 1;

        public override bool Eat(SaveGame saveGame)
        {
            if (!saveGame.Player.HasConfusionResistance)
            {
                if (saveGame.Player.TimedConfusion.AddTimer(Program.Rng.RandomLessThan(10) + 10))
                {
                    return true;
                }
            }
            return false;
        }
        public override Item CreateItem() => new ConfusionMushroomFoodItem(SaveGame);
    }
}