using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class GoldDiamonds : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Diamond;
        public override string Name => "diamonds";

        public override int Cost => 28;
        public override string FriendlyName => "diamonds";
        public override int Level => 1;
        public override int? SubCategory => 15;
    }
}
