using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingChaosResistance : RingItemClass
    {
        public override char Character => '=';
        public override string Name => "Chaos Resistance";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 13000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Chaos Resistance";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override bool ResChaos => true;
        public override bool ResConf => true;
        public override int? SubCategory => 46;
        public override int Weight => 2;
    }
}
