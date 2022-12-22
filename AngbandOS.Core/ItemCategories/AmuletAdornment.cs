using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class AmuletAdornment : AmuletItemClass
    {
        private AmuletAdornment(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '"';
        public override string Name => "Adornment";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 20;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Adornment";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override int Weight => 3;
    }
}
