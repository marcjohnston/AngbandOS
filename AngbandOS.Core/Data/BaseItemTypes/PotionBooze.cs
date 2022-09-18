using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionBooze : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Booze";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Booze";
        public override int Pval => 50;
        public override int SubCategory => 9;
        public override int Weight => 4;
    }
}
