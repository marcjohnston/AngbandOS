using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class LifeBookBookofCommonPrayer : LifeBookItemCategory
    {
        public override char Character => '?';
        public override string Name => "LifeBook:[Book of Common Prayer]";

        public override int Chance1 => 1;
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Book of Common Prayer]";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int? SubCategory => 0;
        public override int Weight => 30;
    }
}
