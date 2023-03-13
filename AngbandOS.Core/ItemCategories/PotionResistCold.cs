namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionResistCold : PotionItemClass
    {
        private PotionResistCold(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Resist Cold";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 30;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Resist Cold";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.ResistCold;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Resist cold gives you timed frost resistance
            return saveGame.Player.TimedColdResistance.AddTimer(Program.Rng.DieRoll(10) + 10);
        }
        public override Item CreateItem(SaveGame saveGame) => new ResistColdPotionItem(saveGame);
    }
}
