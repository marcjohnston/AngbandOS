using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandLightningBalls : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Wand:Lightning Balls";

        public override int Chance1 => 1;
        public override int Cost => 1200;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Lightning Balls";
        public override bool IgnoreElec => true;
        public override int Level => 35;
        public override int Locale1 => 35;
        public override int? SubCategory => 21;
        public override int Weight => 10;
    }
}
