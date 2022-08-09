using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class GoldEmeralds : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Green;
        public override string Name => "Gold:emeralds";

        public override int Cost => 32;
        public override string FriendlyName => "emeralds";
        public override int Level => 1;
        public override int SubCategory => 16;
    }
}
