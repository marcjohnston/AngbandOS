using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodAcidBalls : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Acid Balls";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 5500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Acid Balls";
        public override int Level => 70;
        public override int[] Locale => new int[] { 70, 0, 0, 0 };
        public override int? SubCategory => 24;
        public override int Weight => 15;
    }
}
