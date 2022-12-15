using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldSilver1 : GoldItemClass
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Silver;
        public override string Name => "silver*";

        public override int Cost => 7;
        public override string FriendlyName => "silver";
        public override int Level => 1;
    }
}
