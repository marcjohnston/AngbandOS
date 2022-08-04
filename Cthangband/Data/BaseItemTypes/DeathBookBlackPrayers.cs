using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class DeathBookBlackPrayers : DeathBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Grey;
        public override string Name => "DeathBook:[Black Prayers]";

        public override int Chance1 => 1;
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Black Prayers]";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Weight => 30;
    }
}
