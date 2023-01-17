namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodFireBalls : RodItemClass
    {
        private RodFireBalls(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Fire Balls";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 5000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Fire Balls";
        public override int Level => 75;
        public override int[] Locale => new int[] { 75, 0, 0, 0 };
        public override int? SubCategory => 26;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            SaveGame.FireBall(new ProjectFire(SaveGame), zapRodEvent.Dir.Value, 72, 2);
            zapRodEvent.Identified = true;
            zapRodEvent.Item.TypeSpecificValue = 30;
        }
    }
}
