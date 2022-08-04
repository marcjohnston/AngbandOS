using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionBerserkStrength : PotionItemCategory
    {
        public override char Character => '!';
        public override Colour Colour => Colour.Background;
        public override string Name => "Potion:Berserk Strength";

        public override int Chance1 => 1;
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Berserk Strength";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override int SubCategory => 33;
        public override int Weight => 4;
    }
}
