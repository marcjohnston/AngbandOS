using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodProbing : RodItemClass
    {
        public override bool RequiresAiming => false;
        public override char Character => '-';
        public override string Name => "Probing";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 4000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Probing";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => 7;
        public override int Weight => 15;
    }
}