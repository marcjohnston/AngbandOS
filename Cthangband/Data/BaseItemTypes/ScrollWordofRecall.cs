using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollWordofRecall : ScrollItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Background;
        public override string Name => "Scroll:Word of Recall";

        public override int Chance1 => 1;
        public override int Cost => 150;
        public override string FriendlyName => "Word of Recall";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int SubCategory => 11;
        public override int Weight => 5;
    }
}
