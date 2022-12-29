namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class WandShardBalls : WandItemClass
    {
        private WandShardBalls(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Shard Balls";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 95000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Shard Balls";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 75;
        public override int[] Locale => new int[] { 75, 0, 0, 0 };
        public override int? SubCategory => WandType.Shard;
        public override int Weight => 10;

        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            saveGame.FireBall(new ProjectShard(saveGame), dir, 75 + Program.Rng.DieRoll(50), 2);
            return true;
        }
        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
        }
    }
}
