using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionInfravision : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Infra-vision";

        public override int Chance1 => 1;
        public override int Cost => 20;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Infra-vision";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override int SubCategory => 24;
        public override int Weight => 4;
    }
}
