using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionBoldness : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Boldness";

        public override int Chance1 => 1;
        public override int Cost => 10;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Boldness";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int SubCategory => 28;
        public override int Weight => 4;
    }
}
