using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class FoodBlindness : FoodItemCategory
    {
        public override char Character => ',';
        public override Colour Colour => Colour.Background;
        public override string Name => "Food:Blindness";

        public override int Chance1 => 1;
        public override string FriendlyName => "Blindness";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int Pval => 500;
        public override int SubCategory => 1;
        public override int Weight => 1;
    }
}
