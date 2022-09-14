using AngbandOS.Core.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ShieldLargeMetalShield : ShieldItemCategory
    {
        public override char Character => ')';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Shield:Large Metal Shield";

        public override int Ac => 5;
        public override int Chance1 => 1;
        public override int Cost => 200;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Large Metal Shield~";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int SubCategory => 5;
        public override int Weight => 120;
    }
}
