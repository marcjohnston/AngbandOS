using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class GoldOpals : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Gold:opals";

        public override int Cost => 18;
        public override string FriendlyName => "opals";
        public override int Level => 1;
        public override int SubCategory => 12;
    }
}
