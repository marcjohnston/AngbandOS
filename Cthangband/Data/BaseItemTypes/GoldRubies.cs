using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class GoldRubies : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Red;
        public override string Name => "Gold:rubies";

        public override int Cost => 24;
        public override string FriendlyName => "rubies";
        public override int Level => 1;
        public override int SubCategory => 14;
    }
}
