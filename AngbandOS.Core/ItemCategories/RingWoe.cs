using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingWoe : RingItemClass
    {
        private RingWoe(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Woe";

        public override bool Cha => true;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override bool Cursed => true;
        public override string FriendlyName => "Woe";
        public override bool HideType => true;
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int Pval => -5;
        public override bool Teleport => true;
        public override int Weight => 2;
        public override int? SubCategory => 0;
        public override bool Wis => true;
    }
}
