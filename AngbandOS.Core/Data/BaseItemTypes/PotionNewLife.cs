using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionNewLife : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:New Life";

        public override int Chance1 => 20;
        public override int Chance2 => 10;
        public override int Chance3 => 5;
        public override int Cost => 750000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "New Life";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int Locale2 => 100;
        public override int Locale3 => 120;
        public override int Pval => 100;
        public override int SubCategory => 63;
        public override int Weight => 4;
    }
}
