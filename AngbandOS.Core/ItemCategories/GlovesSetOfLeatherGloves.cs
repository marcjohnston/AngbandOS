using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GlovesSetOfLeatherGloves : GlovesItemClass
    {
        private GlovesSetOfLeatherGloves(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => ']';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Set of Leather Gloves";

        public override int Ac => 1;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 3;
        public override string FriendlyName => "& Set~ of Leather Gloves";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int Weight => 5;
    }
}
