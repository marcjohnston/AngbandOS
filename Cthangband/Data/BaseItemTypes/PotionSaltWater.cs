using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionSaltWater : PotionItemCategory
    {
        public override char Character => '!';
        public override Colour Colour => Colour.Background;
        public override string Name => "Potion:Salt Water";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Salt Water";
        public override int SubCategory => 5;
        public override int Weight => 4;
    }
}
