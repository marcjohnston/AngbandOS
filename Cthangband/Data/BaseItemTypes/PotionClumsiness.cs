using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionClumsiness : PotionItemCategory
    {
        public override char Character => '!';
        public override Colour Colour => Colour.Background;
        public override string Name => "Potion:Clumsiness";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Clumsiness";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int SubCategory => 19;
        public override int Weight => 4;
    }
}
