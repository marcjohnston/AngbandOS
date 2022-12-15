using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HaftedMorningStar : HaftedItemClass
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Black;
        public override string Name => "Morning Star";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 396;
        public override int Dd => 2;
        public override int Ds => 6;
        public override string FriendlyName => "& Morning Star~";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 12;
        public override int Weight => 150;
    }
}
