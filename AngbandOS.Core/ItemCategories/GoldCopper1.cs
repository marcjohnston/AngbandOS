using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldCopper1 : GoldItemClass
    {
        private GoldCopper1(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '$';
        public override Colour Colour => Colour.Copper;
        public override string Name => "copper*";

        public override int Cost => 4;
        public override string FriendlyName => "copper";
        public override int Level => 1;
    }
}
