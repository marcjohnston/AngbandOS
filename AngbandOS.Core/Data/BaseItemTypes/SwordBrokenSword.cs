using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SwordBrokenSword : SwordItemCategory
    {
        public override char Character => '|';
        public override Colour Colour => Colour.Black;
        public override string Name => "Sword:Broken Sword";

        public override int Chance1 => 1;
        public override int Cost => 2;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "& Broken Sword~";
        public override bool ShowMods => true;
        public override int SubCategory => 2;
        public override int ToD => -4;
        public override int ToH => -2;
        public override int Weight => 30;
    }
}
