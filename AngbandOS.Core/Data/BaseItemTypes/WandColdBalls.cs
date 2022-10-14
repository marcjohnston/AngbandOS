using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandColdBalls : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Wand:Cold Balls";

        public override int Chance1 => 1;
        public override int Cost => 1500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Cold Balls";
        public override bool IgnoreCold => true;
        public override int Level => 40;
        public override int Locale1 => 40;
        public override int? SubCategory => 23;
        public override int Weight => 10;
    }
}
