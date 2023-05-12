namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodAcidBolts : RodItemFactory
    {
        private RodAcidBolts(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Acid Bolts";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 3500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Acid Bolts";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => 20;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            SaveGame.FireBoltOrBeam(10, SaveGame.SingletonRepository.Projectiles.Get<AcidProjectile>(), zapRodEvent.Dir.Value, Program.Rng.DiceRoll(6, 8));
            zapRodEvent.Identified = true;
            zapRodEvent.Item.TypeSpecificValue = 12;
        }
        public override Item CreateItem() => new AcidBoltsRodItem(SaveGame);
    }
}
