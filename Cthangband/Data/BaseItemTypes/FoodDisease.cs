using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class FoodDisease : FoodItemCategory
    {
        public override char Character => ',';
        public override Colour Colour => Colour.Background;
        public override string Name => "Food:Disease";

        public override int Chance1 => 1;
        public override int Cost => 50;
        public override int Dd => 10;
        public override int Ds => 10;
        public override string FriendlyName => "Disease";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int Pval => 500;
        public override int SubCategory => 11;
        public override int Weight => 1;
    }
}
