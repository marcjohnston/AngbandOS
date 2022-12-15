using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HelmSteelHelm : HelmItemClass
    {
        public override char Character => ']';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Steel Helm";

        public override int Ac => 6;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 200;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Steel Helm~";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => 6;
        public override int Weight => 60;
    }
}
