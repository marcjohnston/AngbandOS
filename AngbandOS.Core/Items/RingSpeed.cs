using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingSpeed : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Speed";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 100000;
        public override string FriendlyName => "Speed";
        public override bool HideType => true;
        public override int Level => 80;
        public override int[] Locale => new int[] { 80, 0, 0, 0 };
        public override bool Speed => true;
        public override int? SubCategory => 31;
        public override int Weight => 2;
    }
}