using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionStupidity : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Stupidity";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Stupidity";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int SubCategory => 17;
        public override int Weight => 4;
    }
}
