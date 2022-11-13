using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodSlowMonster : RodItemCategory
    {
        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Slow Monster";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Slow Monster";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 17;
        public override int Weight => 15;
    }
}
