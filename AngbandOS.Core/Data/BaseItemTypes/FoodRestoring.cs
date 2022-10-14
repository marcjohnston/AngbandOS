using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodRestoring : FoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Food:Restoring";

        public override int Chance1 => 8;
        public override int Chance2 => 4;
        public override int Chance3 => 1;
        public override int Cost => 1000;
        public override string FriendlyName => "Restoring";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int Locale2 => 30;
        public override int Locale3 => 40;
        public override int Pval => 500;
        public override int? SubCategory => 19;
        public override int Weight => 1;
    }
}
