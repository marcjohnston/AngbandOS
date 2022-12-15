using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ChaosBookGharneFragments : ChaosBookItemClass
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Red;
        public override string Name => "[G'harne Fragments]";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 25000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[G'harne Fragments]";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int? SubCategory => 2;
        public override int Weight => 30;
        public override bool KindIsGood => true;
    }
}
