using AngbandOS.Core.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ShieldSmallLeatherShield : ShieldItemCategory
    {
        public override char Character => ')';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Shield:Small Leather Shield";

        public override int Ac => 2;
        public override int Chance1 => 1;
        public override int Cost => 30;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Small Leather Shield~";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override int SubCategory => 2;
        public override int Weight => 50;
    }
}
