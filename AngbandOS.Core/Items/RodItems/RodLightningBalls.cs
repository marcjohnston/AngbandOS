namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodLightningBalls : RodItemClass
    {
        private RodLightningBalls(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Lightning Balls";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 4000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Lightning Balls";
        public override int Level => 55;
        public override int[] Locale => new int[] { 55, 0, 0, 0 };
        public override int? SubCategory => 25;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            SaveGame.FireBall(new ElecProjectile(SaveGame), zapRodEvent.Dir.Value, 32, 2);
            zapRodEvent.Identified = true;
            zapRodEvent.Item.TypeSpecificValue = 23;
        }
        public override Item CreateItem() => new LightningBallsRodItem(SaveGame);
    }
}
