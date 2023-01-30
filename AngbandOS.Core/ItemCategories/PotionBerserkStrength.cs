namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionBerserkStrength : PotionItemClass
    {
        private PotionBerserkStrength(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Berserk Strength";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Berserk Strength";
        public override int Level => 3;
        public override int[] Locale => new int[] { 3, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.BeserkStrength;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            bool identified = false;

            // Berserk strength removes fear, heals 30 health, and gives you timed super heroism
            if (saveGame.Player.TimedFear.ResetTimer())
            {
                identified = true;
            }
            if (saveGame.Player.TimedSuperheroism.AddTimer(Program.Rng.DieRoll(25) + 25))
            {
                identified = true;
            }
            if (saveGame.Player.RestoreHealth(30))
            {
                identified = true;
            }
            return identified;
        }
    }
}
