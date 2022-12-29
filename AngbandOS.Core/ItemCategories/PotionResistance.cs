namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionResistance : PotionItemClass
    {
        private PotionResistance(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Resistance";

        public override int[] Chance => new int[] { 1, 1, 1, 1 };
        public override int Cost => 250;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Resistance";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 45, 80, 100 };
        public override int Pval => 100;
        public override int? SubCategory => (int)PotionType.Resistance;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Resistance gives you all timed resistances
            saveGame.Player.SetTimedAcidResistance(saveGame.Player.TimedAcidResistance + Program.Rng.DieRoll(20) + 20);
            saveGame.Player.SetTimedLightningResistance(saveGame.Player.TimedLightningResistance + Program.Rng.DieRoll(20) + 20);
            saveGame.Player.SetTimedFireResistance(saveGame.Player.TimedFireResistance + Program.Rng.DieRoll(20) + 20);
            saveGame.Player.SetTimedColdResistance(saveGame.Player.TimedColdResistance + Program.Rng.DieRoll(20) + 20);
            saveGame.Player.SetTimedPoisonResistance(saveGame.Player.TimedPoisonResistance + Program.Rng.DieRoll(20) + 20);
            return true;
        }
    }
}
