using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodDetection : RodItemClass
    {
        public RodDetection(SaveGame saveGame) : base(saveGame) { }

        public override bool RequiresAiming => false;
        public override char Character => '-';
        public override string Name => "Detection";

        public override int[] Chance => new int[] { 8, 0, 0, 0 };
        public override int Cost => 5000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Detection";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 6;
        public override int Weight => 15;
    }
}
