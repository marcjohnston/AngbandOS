using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionAppleJuice : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Apple Juice";

        public override int Chance1 => 1;
        public override int Cost => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Apple Juice";
        public override int Pval => 250;
        public override int SubCategory => 1;
        public override int Weight => 4;
    }
}
