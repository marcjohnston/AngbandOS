using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingExtraAttacks : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Extra Attacks";

        public override bool Blows => true;
        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 100000;
        public override string FriendlyName => "Extra Attacks";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int? SubCategory => 49;
        public override int Weight => 2;
    }
}