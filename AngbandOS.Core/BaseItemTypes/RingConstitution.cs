using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingConstitution : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Constitution";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override bool Con => true;
        public override int Cost => 500;
        public override string FriendlyName => "Constitution";
        public override bool HideType => true;
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 27;
        public override int Weight => 2;
    }
}
