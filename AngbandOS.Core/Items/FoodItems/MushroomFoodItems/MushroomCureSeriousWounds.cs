namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class MushroomCureSeriousWounds : MushroomFoodItemClass
    {
        private MushroomCureSeriousWounds(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ',';
        public override string Name => "Cure Serious Wounds";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 75;
        public override string FriendlyName => "Cure Serious Wounds";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 16;
        public override int Weight => 2;
        public override bool Eat(SaveGame saveGame)
        {
            if (saveGame.Player.RestoreHealth(Program.Rng.DiceRoll(4, 8)))
            {
                return true;
            }
            return false;
        }
        public override Item CreateItem() => new CureSeriousWoundsMushroomItem(SaveGame);
    }
}
