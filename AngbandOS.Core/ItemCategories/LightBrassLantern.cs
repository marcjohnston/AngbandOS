using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class LightBrassLantern : LightSourceItemClass
    {
        public override char Character => '~';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Brass Lantern";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 35;
        public override int Dd => 1;
        public override int Ds => 1;
        public override bool EasyKnow => true;
        public override string FriendlyName => "& Brass Lantern~";
        public override bool IgnoreFire => true;
        public override int Level => 3;
        public override int[] Locale => new int[] { 3, 0, 0, 0 };
        public override int Pval => 7500;
        public override int? SubCategory => 1;
        public override int Weight => 50;
    }
}
