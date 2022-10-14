using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionSaltWater : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Salt Water";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Salt Water";
        public override int? SubCategory => 5;
        public override int Weight => 4;
    }
}
