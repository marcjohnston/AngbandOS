using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HaftedWarHammer : HaftedItemClass
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Black;
        public override string Name => "War Hammer";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 225;
        public override int Dd => 3;
        public override int Ds => 3;
        public override string FriendlyName => "& War Hammer~";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 8;
        public override int Weight => 120;
    }
}
