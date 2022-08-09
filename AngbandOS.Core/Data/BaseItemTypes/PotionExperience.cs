using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionExperience : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Experience";

        public override int Chance1 => 1;
        public override int Cost => 25000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Experience";
        public override int Level => 65;
        public override int Locale1 => 65;
        public override int SubCategory => 59;
        public override int Weight => 4;
    }
}
