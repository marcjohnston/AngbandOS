namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionNeutralizePoison : PotionItemClass
    {
        private PotionNeutralizePoison(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Neutralize Poison";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 75;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Neutralize Poison";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.CurePoison;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Cure poison removes any poison you have
            return saveGame.Player.TimedPoison.ResetTimer();
        }
        public override Item CreateItem() => new NeutralizePoisonPotionItem(SaveGame);
    }
}