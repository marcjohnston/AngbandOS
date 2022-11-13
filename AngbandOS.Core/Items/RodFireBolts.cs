using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodFireBolts : RodItemClass
    {
        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Fire Bolts";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 3000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Fire Bolts";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 22;
        public override int Weight => 15;
    }
}
