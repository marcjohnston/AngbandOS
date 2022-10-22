using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionSlowness : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Slowness";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Slowness";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int Pval => 50;
        public override int? SubCategory => 4;
        public override int Weight => 4;
    }
}
