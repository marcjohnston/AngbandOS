using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class GoldOpals : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "opals";

        public override int Cost => 18;
        public override string FriendlyName => "opals";
        public override int Level => 1;
    }
}
