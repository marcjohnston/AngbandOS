using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class GoldSilver1 : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Silver;
        public override string Name => "Gold:silver*";

        public override int Cost => 7;
        public override string FriendlyName => "silver";
        public override int Level => 1;
        public override int SubCategory => 5;
    }
}
