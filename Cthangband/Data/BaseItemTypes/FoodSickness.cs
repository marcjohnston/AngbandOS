using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class FoodSickness : FoodItemCategory
    {
        public override char Character => ',';
        public override Colour Colour => Colour.Background;
        public override string Name => "Food:Sickness";

        public override int Chance1 => 1;
        public override int Dd => 4;
        public override int Ds => 4;
        public override string FriendlyName => "Sickness";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Pval => 500;
        public override int SubCategory => 7;
        public override int Weight => 1;
    }
}
