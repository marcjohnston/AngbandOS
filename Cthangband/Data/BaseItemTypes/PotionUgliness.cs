using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionUgliness : PotionItemCategory
    {
        public override char Character => '!';
        public override Colour Colour => Colour.Background;
        public override string Name => "Potion:Ugliness";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Ugliness";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int SubCategory => 21;
        public override int Weight => 4;
    }
}
