using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class FoodPoison : FoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Food:Poison";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Dd => 4;
        public override int Ds => 4;
        public override string FriendlyName => "Poison";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int Locale2 => 5;
        public override int Pval => 500;
        public override int Weight => 1;
    }
}
