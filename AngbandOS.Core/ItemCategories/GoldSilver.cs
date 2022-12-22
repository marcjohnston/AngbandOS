using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldSilver : GoldItemClass
    {
        private GoldSilver(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '$';
        public override Colour Colour => Colour.Silver;
        public override string Name => "silver";

        public override int Cost => 6;
        public override string FriendlyName => "silver";
        public override int Level => 1;
    }
}
