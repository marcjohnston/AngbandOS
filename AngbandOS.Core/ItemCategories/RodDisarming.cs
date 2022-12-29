namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodDisarming : RodItemClass
    {
        private RodDisarming(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Disarming";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 2100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Disarming";
        public override int Level => 35;
        public override int[] Locale => new int[] { 35, 0, 0, 0 };
        public override int? SubCategory => 14;
        public override int Weight => 15;
    }
}
