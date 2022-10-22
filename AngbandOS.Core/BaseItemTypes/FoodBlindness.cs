using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodBlindness : FoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Blindness";

        public override int Chance1 => 1;
        public override string FriendlyName => "Blindness";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int Pval => 500;
        public override int? SubCategory => 1;
        public override int Weight => 1;
    }
}
