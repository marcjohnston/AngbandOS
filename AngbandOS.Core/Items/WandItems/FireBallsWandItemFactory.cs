namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class FireBallsWandItemFactory : WandItemFactory
    {
        private FireBallsWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Fire Balls";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1800;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Fire Balls";
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int? SubCategory => WandType.FireBall;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<FireProjectile>(), dir, 72, 2);
            return true;
        }
        public override Item CreateItem() => new FireBallsWandItem(SaveGame);
    }
}