namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class WandLightningBalls : WandItemClass
    {
        private WandLightningBalls(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Lightning Balls";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1200;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Lightning Balls";
        public override bool IgnoreElec => true;
        public override int Level => 35;
        public override int[] Locale => new int[] { 35, 0, 0, 0 };
        public override int? SubCategory => WandType.ElecBall;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            saveGame.FireBall(new ElecProjectile(saveGame), dir, 32, 2);
            return true;
        }
        public override Item CreateItem() => new LightningBallsWandItem(SaveGame);
    }
}