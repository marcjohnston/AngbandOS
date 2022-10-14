using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionSpeed : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Speed";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Chance3 => 1;
        public override int Cost => 75;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Speed";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int Locale2 => 40;
        public override int Locale3 => 60;
        public override int? SubCategory => 29;
        public override int Weight => 4;
    }
}
