namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodFrostBolts : RodItemClass
    {
        private RodFrostBolts(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Frost Bolts";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 2500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Frost Bolts";
        public override int Level => 25;
        public override int[] Locale => new int[] { 25, 0, 0, 0 };
        public override int? SubCategory => 23;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            SaveGame.FireBoltOrBeam(10, new ColdProjectile(SaveGame), zapRodEvent.Dir.Value, Program.Rng.DiceRoll(5, 8));
            zapRodEvent.Identified = true;
            zapRodEvent.Item.TypeSpecificValue = 13;
        }
        public override Item CreateItem() => new FrostBoltsRodItem(SaveGame);
    }
}