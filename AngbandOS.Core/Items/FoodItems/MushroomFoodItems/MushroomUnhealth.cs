namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class MushroomUnhealth : MushroomFoodItemClass
    {
        private MushroomUnhealth(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ',';
        public override string Name => "Unhealth";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 50;
        public override int Dd => 10;
        public override int Ds => 10;
        public override string FriendlyName => "Unhealth";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 10;
        public override int Weight => 1;
        public override bool Eat(SaveGame saveGame)
        {
            saveGame.Player.TakeHit(Program.Rng.DiceRoll(10, 10), "poisonous food.");
            saveGame.Player.TryDecreasingAbilityScore(Ability.Constitution);
            return true;
        }
        public override Item CreateItem() => new UnhealthMushroomItem(SaveGame);
    }
}
