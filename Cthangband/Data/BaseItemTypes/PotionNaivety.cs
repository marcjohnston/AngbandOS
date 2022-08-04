using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionNaivety : PotionItemCategory
    {
        public override char Character => '!';
        public override Colour Colour => Colour.Background;
        public override string Name => "Potion:Naivety";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Naivety";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int SubCategory => 18;
        public override int Weight => 4;
    }
}
