using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollSpecialAcquirement : ScrollItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Background;
        public override string Name => "Scroll:*Acquirement*";

        public override int Chance1 => 16;
        public override int Cost => 200000;
        public override string FriendlyName => "*Acquirement*";
        public override int Level => 60;
        public override int Locale1 => 60;
        public override int SubCategory => 47;
        public override int Weight => 5;
    }
}
