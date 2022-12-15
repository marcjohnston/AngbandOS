using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingAggravateMonster : RingItemClass
    {
        public override char Character => '=';
        public override string Name => "Aggravate Monster";

        public override bool Aggravate => true;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override bool Cursed => true;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Aggravate Monster";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 1;
        public override int Weight => 2;
    }
}
