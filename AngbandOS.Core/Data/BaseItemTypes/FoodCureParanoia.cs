using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodCureParanoia : FoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Food:Cure Paranoia";

        public override int Chance1 => 1;
        public override int Cost => 25;
        public override string FriendlyName => "Cure Paranoia";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Pval => 500;
        public override int? SubCategory => 14;
        public override int Weight => 1;
    }
}
