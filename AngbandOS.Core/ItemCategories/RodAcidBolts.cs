using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodAcidBolts : RodItemClass
    {
        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Acid Bolts";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 3500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Acid Bolts";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => 20;
        public override int Weight => 15;
    }
}