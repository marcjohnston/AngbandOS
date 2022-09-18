using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionSlimeMoldJuice : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Slime Mold Juice";

        public override int Chance1 => 1;
        public override int Cost => 2;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Slime Mold Juice";
        public override int Pval => 400;
        public override int SubCategory => 2;
        public override int Weight => 4;
    }
}
