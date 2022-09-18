using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandShardBalls : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Wand:Shard Balls";

        public override int Chance1 => 4;
        public override int Cost => 95000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Shard Balls";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 75;
        public override int Locale1 => 75;
        public override int SubCategory => 29;
        public override int Weight => 10;
    }
}
