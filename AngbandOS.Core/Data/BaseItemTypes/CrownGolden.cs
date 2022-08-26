using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class CrownGolden : CrownItemCategory
    {
        public override char Character => ']';
        public override Colour Colour => Colour.Gold;
        public override string Name => "Crown:Golden Crown";

        public override int Chance1 => 1;
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Golden Crown~";
        public override bool IgnoreAcid => true;
        public override int Level => 45;
        public override int Locale1 => 45;
        public override int SubCategory => 11;
        public override int Weight => 30;
    }
}
