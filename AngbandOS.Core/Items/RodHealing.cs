using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodHealing : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Healing";

        public override int[] Chance => new int[] { 8, 0, 0, 0 };
        public override int Cost => 20000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Healing";
        public override int Level => 80;
        public override int[] Locale => new int[] { 80, 0, 0, 0 };
        public override int? SubCategory => 9;
        public override int Weight => 15;
    }
}