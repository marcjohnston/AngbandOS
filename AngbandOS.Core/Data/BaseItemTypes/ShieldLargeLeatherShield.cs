using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ShieldLargeLeatherShield : ShieldItemCategory
    {
        public override char Character => ')';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Shield:Large Leather Shield";

        public override int Ac => 4;
        public override int Chance1 => 1;
        public override int Cost => 120;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "& Large Leather Shield~";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int SubCategory => 4;
        public override int Weight => 100;
    }
}
