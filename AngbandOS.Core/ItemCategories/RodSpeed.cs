using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodSpeed : RodItemClass
    {
        public override bool RequiresAiming => false;
        public override char Character => '-';
        public override string Name => "Speed";

        public override int[] Chance => new int[] { 16, 0, 0, 0 };
        public override int Cost => 50000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Speed";
        public override int Level => 95;
        public override int[] Locale => new int[] { 95, 0, 0, 0 };
        public override int? SubCategory => 11;
        public override int Weight => 15;
    }
}