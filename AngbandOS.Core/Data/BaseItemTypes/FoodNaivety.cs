using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodNaivety : FoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Food:Naivety";

        public override int Chance1 => 1;
        public override string FriendlyName => "Naivety";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int Pval => 500;
        public override int? SubCategory => 9;
        public override int Weight => 1;
    }
}
