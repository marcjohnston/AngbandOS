using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodLightningBalls : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Lightning Balls";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 4000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Lightning Balls";
        public override int Level => 55;
        public override int[] Locale => new int[] { 55, 0, 0, 0 };
        public override int? SubCategory => 25;
        public override int Weight => 15;
    }
}