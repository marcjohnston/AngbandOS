namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StrengthPotionItemFactory : PotionItemFactory
    {
        private StrengthPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Strength";

        public override int[] Chance => new int[] { 6, 3, 1, 0 };
        public override int Cost => 8000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Strength";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 25, 30, 0 };
        public override int? SubCategory => (int)PotionType.IncStr;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Strength increases your strength
            return saveGame.Player.TryIncreasingAbilityScore(Ability.Strength);
        }
        public override Item CreateItem() => new StrengthPotionItem(SaveGame);
    }
}
