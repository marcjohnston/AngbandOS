namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionSlowPoison : PotionItemClass
    {
        private PotionSlowPoison(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Slow Poison";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 25;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Slow Poison";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.SlowPoison;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Slow poison halves the remaining duration of any poison you have
            return saveGame.Player.TimedPoison.SetTimer(saveGame.Player.TimedPoison.TurnsRemaining / 2);
        }
        public override Item CreateItem() => new SlowPoisonPotionItem(SaveGame);
    }
}