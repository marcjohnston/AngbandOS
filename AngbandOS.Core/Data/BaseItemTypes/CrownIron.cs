using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class CrownIron : CrownItemCategory
    {
        public override char Character => ']';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Crown:Iron Crown";

        public override int Chance1 => 1;
        public override int Cost => 500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Iron Crown~";
        public override int Level => 45;
        public override int Locale1 => 45;
        public override int SubCategory => 10;
        public override int Weight => 20;
    }
}
