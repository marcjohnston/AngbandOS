using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionCuring : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Curing";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Cost => 250;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Curing";
        public override int Level => 18;
        public override int Locale1 => 18;
        public override int Locale2 => 40;
        public override int Pval => 100;
        public override int? SubCategory => 61;
        public override int Weight => 4;
    }
}
