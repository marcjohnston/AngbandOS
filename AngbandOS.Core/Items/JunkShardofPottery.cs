using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class JunkShardofPottery : JunkItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Red;
        public override string Name => "Shard of Pottery";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Shard~ of Pottery";
        public override int? SubCategory => 3;
        public override int Weight => 5;
    }
}
