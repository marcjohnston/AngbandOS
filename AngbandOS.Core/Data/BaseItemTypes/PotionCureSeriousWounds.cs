using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionCureSeriousWounds : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Cure Serious Wounds";

        public override int Chance1 => 1;
        public override int Cost => 40;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Cure Serious Wounds";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override int Pval => 100;
        public override int? SubCategory => 35;
        public override int Weight => 4;
    }
}
