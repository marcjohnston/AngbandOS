using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class GoldCopper1 : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Copper;
        public override string Name => "Gold:copper*";

        public override int Cost => 4;
        public override string FriendlyName => "copper";
        public override int Level => 1;
        public override int SubCategory => 2;
    }
}
