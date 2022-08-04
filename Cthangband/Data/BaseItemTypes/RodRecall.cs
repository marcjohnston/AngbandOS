using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RodRecall : RodItemCategory
    {
        public override char Character => '-';
        public override Colour Colour => Colour.Background;
        public override string Name => "Rod:Recall";

        public override int Chance1 => 4;
        public override int Cost => 4000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Recall";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int SubCategory => 3;
        public override int Weight => 15;
    }
}
