using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodRestoration : RodItemClass
    {
        public override bool RequiresAiming => false;
        public override char Character => '-';
        public override string Name => "Restoration";

        public override int[] Chance => new int[] { 16, 0, 0, 0 };
        public override int Cost => 25000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Restoration";
        public override int Level => 80;
        public override int[] Locale => new int[] { 80, 0, 0, 0 };
        public override int? SubCategory => 10;
        public override int Weight => 15;
    }
}