using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingStrength : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Strength";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override string FriendlyName => "Strength";
        public override bool HideType => true;
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override bool Str => true;
        public override int? SubCategory => 24;
        public override int Weight => 2;
    }
}
