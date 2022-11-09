using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ShieldShieldofDeflection : ShieldItemCategory
    {
        public override char Character => '[';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Shield of Deflection";

        public override int Ac => 10;
        public override int[] Chance => new int[] { 8, 0, 0, 0 };
        public override int Cost => 10000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Shield~ of Deflection";
        public override bool IgnoreAcid => true;
        public override int Level => 70;
        public override int[] Locale => new int[] { 70, 0, 0, 0 };
        public override int? SubCategory => 10;
        public override int ToA => 10;
        public override int Weight => 100;
    }
}
