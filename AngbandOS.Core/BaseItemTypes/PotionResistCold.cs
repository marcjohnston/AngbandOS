using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionResistCold : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Resist Cold";

        public override int Chance1 => 1;
        public override int Cost => 30;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Resist Cold";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int? SubCategory => 31;
        public override int Weight => 4;
    }
}
