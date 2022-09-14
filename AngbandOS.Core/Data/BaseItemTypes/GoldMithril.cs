using AngbandOS.Core.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class GoldMithril : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Gold:mithril";

        public override int Cost => 40;
        public override string FriendlyName => "mithril";
        public override int Level => 1;
        public override int SubCategory => 17;
    }
}
