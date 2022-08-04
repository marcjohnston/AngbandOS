using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class GoldGold2 : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Gold;
        public override string Name => "Gold:gold**";

        public override int Cost => 16;
        public override string FriendlyName => "gold";
        public override int Level => 1;
        public override int SubCategory => 11;
    }
}
