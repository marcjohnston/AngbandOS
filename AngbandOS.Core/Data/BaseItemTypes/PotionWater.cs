using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionWater : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Water";

        public override int Chance1 => 1;
        public override int Cost => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Water";
        public override int Pval => 200;
        public override int? SubCategory => 0;
        public override int Weight => 4;
    }
}
