using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldDiamonds : GoldItemClass
    {
        public GoldDiamonds(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '$';
        public override Colour Colour => Colour.Diamond;
        public override string Name => "diamonds";

        public override int Cost => 28;
        public override string FriendlyName => "diamonds";
        public override int Level => 1;
    }
}
