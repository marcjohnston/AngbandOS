using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodCureBlindness : FoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Cure Blindness";

        public override int Chance1 => 1;
        public override int Cost => 50;
        public override string FriendlyName => "Cure Blindness";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Pval => 500;
        public override int? SubCategory => 13;
        public override int Weight => 1;
    }
}
