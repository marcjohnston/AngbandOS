using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodCurePoison : FoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Food:Cure Poison";

        public override int Chance1 => 1;
        public override int Cost => 60;
        public override string FriendlyName => "Cure Poison";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Pval => 500;
        public override int? SubCategory => 12;
        public override int Weight => 1;
    }
}
