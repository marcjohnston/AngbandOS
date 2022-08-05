using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class FoodRation : FoodItemCategory
    {
        public override char Character => ',';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Food:Ration of Food";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Chance3 => 1;
        public override int Cost => 3;
        public override string FriendlyName => "& Ration~ of Food";
        public override int Locale2 => 5;
        public override int Locale3 => 10;
        public override int Pval => 5000;
        public override int SubCategory => 35;
        public override int Weight => 10;
    }
}
