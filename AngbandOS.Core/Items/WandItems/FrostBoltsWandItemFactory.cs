namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class FrostBoltsWandItemFactory : WandItemFactory
    {
        private FrostBoltsWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Frost Bolts";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 800;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Frost Bolts";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => WandType.ColdBolt;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            saveGame.FireBoltOrBeam(20, saveGame.SingletonRepository.Projectiles.Get<ColdProjectile>(), dir, Program.Rng.DiceRoll(3, 8));
            return true;
        }
        public override Item CreateItem() => new FrostBoltsWandItem(SaveGame);
    }
}