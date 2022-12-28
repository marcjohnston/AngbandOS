using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldGarnets : GoldItemClass
    {
        private GoldGarnets(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '$';
        public override Colour Colour => Colour.Red;
        public override string Name => "garnets";

        public override int Cost => 9;
        public override string FriendlyName => "garnets";
        public override int Level => 1;
    }
}
