using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodTrapLocation : RodItemCategory
    {
        public override bool RequiresAiming => false;
        public override char Character => '-';
        public override string Name => "Trap Location";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Trap Location";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 0;
        public override int Weight => 15;
    }
}
