namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StinkingCloudWandItemFactory : WandItemFactory
    {
        private StinkingCloudWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Stinking Cloud";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 400;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Stinking Cloud";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => WandType.StinkingCloud;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<PoisProjectile>(), dir, 12, 2);
            return true;
        }
        public override Item CreateItem() => new StinkingCloudWandItem(SaveGame);
    }
}
