namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ColdBallsWandItemFactory : WandItemFactory
    {
        private ColdBallsWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Cold Balls";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Cold Balls";
        public override bool IgnoreCold => true;
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => WandType.ColdBall;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<ColdProjectile>(), dir, 48, 2);
            return true;
        }
        public override Item CreateItem() => new ColdBallsWandItem(SaveGame);
    }
}