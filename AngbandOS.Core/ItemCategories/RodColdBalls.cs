namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodColdBalls : RodItemClass
    {
        private RodColdBalls(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Cold Balls";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 4500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Cold Balls";
        public override int Level => 60;
        public override int[] Locale => new int[] { 60, 0, 0, 0 };
        public override int? SubCategory => 27;
        public override int Weight => 15;
    }
}
