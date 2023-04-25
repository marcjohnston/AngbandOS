namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RestoringMushroomFoodItemFactory : MushroomFoodItemFactory
    {
        private RestoringMushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ',';
        public override string Name => "Restoring";

        public override int[] Chance => new int[] { 8, 4, 1, 0 };
        public override int Cost => 1000;
        public override string FriendlyName => "Restoring";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 30, 40, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 19;
        public override int Weight => 1;
        public override bool Eat(SaveGame saveGame)
        {
            bool ident = false;
            if (saveGame.Player.TryRestoringAbilityScore(Ability.Strength))
            {
                ident = true;
            }
            if (saveGame.Player.TryRestoringAbilityScore(Ability.Intelligence))
            {
                ident = true;
            }
            if (saveGame.Player.TryRestoringAbilityScore(Ability.Wisdom))
            {
                ident = true;
            }
            if (saveGame.Player.TryRestoringAbilityScore(Ability.Dexterity))
            {
                ident = true;
            }
            if (saveGame.Player.TryRestoringAbilityScore(Ability.Constitution))
            {
                ident = true;
            }
            if (saveGame.Player.TryRestoringAbilityScore(Ability.Charisma))
            {
                ident = true;
            }
            return ident;
        }
        public override Item CreateItem() => new RestoringMushroomFoodItem(SaveGame);
    }
}
