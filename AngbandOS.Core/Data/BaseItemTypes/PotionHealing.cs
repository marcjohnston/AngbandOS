using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionHealing : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Healing";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Chance3 => 1;
        public override int Cost => 300;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Healing";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int Locale2 => 30;
        public override int Locale3 => 60;
        public override int Pval => 200;
        public override int SubCategory => 37;
        public override int Weight => 4;
    }
}
