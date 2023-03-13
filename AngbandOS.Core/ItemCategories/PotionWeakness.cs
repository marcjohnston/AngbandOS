namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionWeakness : PotionItemClass
    {
        private PotionWeakness(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Weakness";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 3;
        public override int Ds => 12;
        public override string FriendlyName => "Weakness";
        public override int Level => 3;
        public override int[] Locale => new int[] { 3, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.DecStr;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Weakness tries to reduce your strength
            return saveGame.Player.TryDecreasingAbilityScore(Ability.Strength);
        }
        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            return true;
        }
        public override Item CreateItem(SaveGame saveGame) => new WeaknessPotionItem(saveGame);
    }
}
