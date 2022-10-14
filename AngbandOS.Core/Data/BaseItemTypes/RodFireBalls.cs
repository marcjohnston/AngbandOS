using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodFireBalls : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Fire Balls";

        public override int Chance1 => 1;
        public override int Cost => 5000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Fire Balls";
        public override int Level => 75;
        public override int Locale1 => 75;
        public override int? SubCategory => 26;
        public override int Weight => 15;
    }
}
