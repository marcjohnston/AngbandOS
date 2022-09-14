using AngbandOS.Core.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class BowShort : BowItemCategory
    {
        public override char Character => '}';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Bow:Short Bow";

        public override int Chance1 => 1;
        public override int Cost => 50;
        public override string FriendlyName => "& Short Bow~";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override bool ShowMods => true;
        public override int SubCategory => 12;
        public override int Weight => 30;
    }
}
