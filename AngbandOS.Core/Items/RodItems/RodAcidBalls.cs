namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodAcidBalls : RodItemClass
    {
        private RodAcidBalls(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Acid Balls";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 5500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Acid Balls";
        public override int Level => 70;
        public override int[] Locale => new int[] { 70, 0, 0, 0 };
        public override int? SubCategory => 24;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            SaveGame.FireBall(new AcidProjectile(SaveGame), zapRodEvent.Dir.Value, 60, 2);
            zapRodEvent.Identified = true;
            zapRodEvent.Item.TypeSpecificValue = 27;
        }
        public override Item CreateItem() => new AcidBallsRodItem(SaveGame);
    }
}
