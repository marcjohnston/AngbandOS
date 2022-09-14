using AngbandOS.Core.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class BowLong : BowItemCategory
    {
        public override char Character => '}';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Bow:Long Bow";

        public override int Chance1 => 1;
        public override int Cost => 120;
        public override string FriendlyName => "& Long Bow~";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override bool ShowMods => true;
        public override int SubCategory => 13;
        public override int Weight => 40;
    }
}
