using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingIce : RingItemClass
    {
        public RingIce(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '=';
        public override string Name => "Ice";

        public override bool Activate => true;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 3000;
        public override string FriendlyName => "Ice";
        public override bool IgnoreCold => true;
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override bool ResCold => true;
        public override int? SubCategory => 19;
        public override int ToA => 15;
        public override int Weight => 2;
    }
}
