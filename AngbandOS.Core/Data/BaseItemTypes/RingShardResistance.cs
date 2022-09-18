using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingShardResistance : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Shard Resistance";

        public override int Chance1 => 2;
        public override int Cost => 3000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Shard Resistance";
        public override int Level => 25;
        public override int Locale1 => 25;
        public override bool ResShards => true;
        public override int SubCategory => 44;
        public override int Weight => 2;
    }
}
