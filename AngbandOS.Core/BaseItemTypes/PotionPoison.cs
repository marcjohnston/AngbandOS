using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionPoison : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Poison";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Poison";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override int? SubCategory => 6;
        public override int Weight => 4;
    }
}
