using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionCureLightWounds : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Cure Light Wounds";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Chance3 => 1;
        public override int Cost => 15;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Cure Light Wounds";
        public override int Locale2 => 1;
        public override int Locale3 => 3;
        public override int Pval => 50;
        public override int SubCategory => 34;
        public override int Weight => 4;
    }
}
