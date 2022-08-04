using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionWater : PotionItemCategory
    {
        public override char Character => '!';
        public override Colour Colour => Colour.Background;
        public override string Name => "Potion:Water";

        public override int Chance1 => 1;
        public override int Cost => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Water";
        public override int Pval => 200;
        public override int Weight => 4;
    }
}
