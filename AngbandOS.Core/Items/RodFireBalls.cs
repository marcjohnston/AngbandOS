using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodFireBalls : RodItemCategory
    {
        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Fire Balls";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 5000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Fire Balls";
        public override int Level => 75;
        public override int[] Locale => new int[] { 75, 0, 0, 0 };
        public override int? SubCategory => 26;
        public override int Weight => 15;
    }
}
