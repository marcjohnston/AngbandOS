using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class GoldSapphires : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Gold:sapphires";

        public override int Cost => 20;
        public override string FriendlyName => "sapphires";
        public override int Level => 1;
        public override int SubCategory => 13;
    }
}
