using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionLife : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Life";

        public override int Chance1 => 4;
        public override int Chance2 => 2;
        public override int Cost => 5000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Life";
        public override int Level => 60;
        public override int Locale1 => 60;
        public override int Locale2 => 100;
        public override int? SubCategory => 39;
        public override int Weight => 4;
    }
}
