using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionHeroism : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Heroism";

        public override int Chance1 => 1;
        public override int Cost => 35;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Heroism";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int SubCategory => 32;
        public override int Weight => 4;
    }
}
