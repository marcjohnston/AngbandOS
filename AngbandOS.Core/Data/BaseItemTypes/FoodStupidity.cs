using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodStupidity : FoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Food:Stupidity";

        public override int Chance1 => 1;
        public override string FriendlyName => "Stupidity";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int Pval => 500;
        public override int? SubCategory => 8;
        public override int Weight => 1;
    }
}
