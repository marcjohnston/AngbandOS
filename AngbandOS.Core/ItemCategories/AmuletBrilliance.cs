using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class AmuletBrilliance : AmuletItemClass
    {
        private AmuletBrilliance(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '"';
        public override string Name => "Brilliance";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override string FriendlyName => "Brilliance";
        public override bool HideType => true;
        public override bool Int => true;
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int Weight => 3;
        public override bool Wis => true;
    }
}
