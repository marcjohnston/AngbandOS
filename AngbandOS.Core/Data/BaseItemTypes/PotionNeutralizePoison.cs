using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionNeutralizePoison : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Neutralize Poison";

        public override int Chance1 => 1;
        public override int Cost => 75;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Neutralize Poison";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int SubCategory => 27;
        public override int Weight => 4;
    }
}
