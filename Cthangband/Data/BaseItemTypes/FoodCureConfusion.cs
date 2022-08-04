using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class FoodCureConfusion : FoodItemCategory
    {
        public override char Character => ',';
        public override Colour Colour => Colour.Background;
        public override string Name => "Food:Cure Confusion";

        public override int Chance1 => 1;
        public override int Cost => 50;
        public override string FriendlyName => "Cure Confusion";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Pval => 500;
        public override int SubCategory => 15;
        public override int Weight => 1;
    }
}
