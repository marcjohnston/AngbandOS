using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionWeakness : PotionItemCategory
    {
        public override char Character => '!';
        public override Colour Colour => Colour.Background;
        public override string Name => "Potion:Weakness";

        public override int Chance1 => 1;
        public override int Dd => 3;
        public override int Ds => 12;
        public override string FriendlyName => "Weakness";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override int SubCategory => 16;
        public override int Weight => 4;
    }
}
