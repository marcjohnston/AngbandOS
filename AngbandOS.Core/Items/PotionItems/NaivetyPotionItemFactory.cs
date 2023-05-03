namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class NaivetyPotionItemFactory : PotionItemFactory
    {
        private NaivetyPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Naivety";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Naivety";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.DecWis;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Naivety tries to reduce your wisdom
            return saveGame.Player.TryDecreasingAbilityScore(Ability.Wisdom);
        }
        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            return true;
        }
        public override Item CreateItem() => new NaivetyPotionItem(SaveGame);
    }
}
