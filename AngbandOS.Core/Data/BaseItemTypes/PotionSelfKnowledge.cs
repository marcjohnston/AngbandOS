using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionSelfKnowledge : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Self Knowledge";

        public override int Chance1 => 1;
        public override int Cost => 2000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Self Knowledge";
        public override int Level => 40;
        public override int Locale1 => 40;
        public override int? SubCategory => 58;
        public override int Weight => 4;
    }
}
