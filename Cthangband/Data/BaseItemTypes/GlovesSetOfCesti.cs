using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class GlovesSetOfCesti : GlovesItemCategory
    {
        public override char Character => ']';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Gloves:Set of Cesti";

        public override int Ac => 5;
        public override int Chance1 => 1;
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Set~ of Cesti";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int SubCategory => 5;
        public override int Weight => 40;
    }
}
