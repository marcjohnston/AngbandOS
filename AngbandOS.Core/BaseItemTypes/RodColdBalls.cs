using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodColdBalls : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Cold Balls";

        public override int Chance1 => 1;
        public override int Cost => 4500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Cold Balls";
        public override int Level => 60;
        public override int Locale1 => 60;
        public override int? SubCategory => 27;
        public override int Weight => 15;
    }
}
