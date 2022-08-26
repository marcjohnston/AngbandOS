using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ShieldSmallMetalShield : ShieldItemCategory
    {
        public override char Character => ')';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Shield:Small Metal Shield";

        public override int Ac => 3;
        public override int Chance1 => 1;
        public override int Cost => 50;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "& Small Metal Shield~";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int SubCategory => 3;
        public override int Weight => 65;
    }
}
