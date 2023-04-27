namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class NaivetyMushroomFoodItemFactory : MushroomFoodItemFactory
    {
        private NaivetyMushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ',';
        public override string Name => "Naivety";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Naivety";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 9;
        public override int Weight => 1;
        public override bool Eat()
        {
            SaveGame.Player.TakeHit(Program.Rng.DiceRoll(8, 8), "poisonous food.");
            SaveGame.Player.TryDecreasingAbilityScore(Ability.Wisdom);
            return true;
        }
        public override Item CreateItem() => new NaivetyMushroomFoodItem(SaveGame);
    }
}
