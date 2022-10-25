using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class GoldSapphires : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Blue;
        public override string Name => "sapphires";

        public override int Cost => 20;
        public override string FriendlyName => "sapphires";
        public override int Level => 1;
        public override int? SubCategory => null;
    }
}
