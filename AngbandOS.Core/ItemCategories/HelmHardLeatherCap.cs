using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HelmHardLeatherCap : HelmItemClass
    {
        public override char Character => ']';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Hard Leather Cap";

        public override int Ac => 2;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 12;
        public override string FriendlyName => "& Hard Leather Cap~";
        public override int Level => 3;
        public override int[] Locale => new int[] { 3, 0, 0, 0 };
        public override int? SubCategory => 2;
        public override int Weight => 15;
    }
}
