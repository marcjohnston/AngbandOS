using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class GoldSilver2 : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Silver;
        public override string Name => "Gold:silver**";

        public override int Cost => 8;
        public override string FriendlyName => "silver";
        public override int Level => 1;
        public override int SubCategory => 6;
    }
}
