using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionRuination : PotionItemCategory
    {
        public override char Character => '!';
        public override Colour Colour => Colour.Background;
        public override string Name => "Potion:Ruination";

        public override int Chance1 => 8;
        public override int Dd => 20;
        public override int Ds => 20;
        public override string FriendlyName => "Ruination";
        public override int Level => 40;
        public override int Locale1 => 40;
        public override int SubCategory => 15;
        public override int Weight => 4;
    }
}
