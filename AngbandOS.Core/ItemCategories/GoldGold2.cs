using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldGold2 : GoldItemClass
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Gold;
        public override string Name => "gold**";

        public override int Cost => 16;
        public override string FriendlyName => "gold";
        public override int Level => 1;
    }
}
