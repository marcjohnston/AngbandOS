namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class FireBoltsWandItemFactory : WandItemFactory
    {
        private FireBoltsWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Fire Bolts";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Fire Bolts";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => WandType.FireBolt;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            saveGame.FireBoltOrBeam(20, saveGame.SingletonRepository.Projectiles.Get<FireProjectile>(), dir, Program.Rng.DiceRoll(6, 8));
            return true;
        }
        public override Item CreateItem() => new FireBoltsWandItem(SaveGame);
    }
}