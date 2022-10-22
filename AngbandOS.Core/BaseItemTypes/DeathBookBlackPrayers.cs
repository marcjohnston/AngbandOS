using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class DeathBookBlackPrayers : DeathBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Grey;
        public override string Name => "[Black Prayers]";

        public override int Chance1 => 1;
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Black Prayers]";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int? SubCategory => 0;
        public override int Weight => 30;
    }
}
