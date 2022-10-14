using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodConfusion : FoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Food:Confusion";

        public override int Chance1 => 1;
        public override string FriendlyName => "Confusion";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int Pval => 500;
        public override int? SubCategory => 3;
        public override int Weight => 1;
    }
}
