using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingWeakness : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Weakness";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override bool Cursed => true;
        public override string FriendlyName => "Weakness";
        public override bool HideType => true;
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int Pval => -5;
        public override bool Str => true;
        public override int? SubCategory => 2;
        public override int Weight => 2;
    }
}
