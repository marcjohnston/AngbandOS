using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionCureCriticalWounds : PotionItemCategory
    {
        public override char Character => '!';
        public override Colour Colour => Colour.Background;
        public override string Name => "Potion:Cure Critical Wounds";

        public override int Chance1 => 1;
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Cure Critical Wounds";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int Pval => 100;
        public override int SubCategory => 36;
        public override int Weight => 4;
    }
}
