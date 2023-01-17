namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodLightningBolts : RodItemClass
    {
        private RodLightningBolts(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Lightning Bolts";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 2000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Lightning Bolts";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => 21;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            SaveGame.FireBoltOrBeam(10, new ProjectElec(SaveGame), zapRodEvent.Dir.Value, Program.Rng.DiceRoll(3, 8));
            zapRodEvent.Identified = true;
            zapRodEvent.Item.TypeSpecificValue = 11;
        }
    }
}
