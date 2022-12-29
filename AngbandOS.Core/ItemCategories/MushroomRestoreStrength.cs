namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class MushroomRestoreStrength : MushroomFoodItemClass
    {
        private MushroomRestoreStrength(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ',';
        public override string Name => "Restore Strength";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 350;
        public override string FriendlyName => "Restore Strength";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 17;
        public override int Weight => 1;
        public override bool Eat(SaveGame saveGame)
        {
            if (saveGame.Player.TryRestoringAbilityScore(Ability.Strength))
            {
                return true;
            }
            return false;
        }
    }
}
