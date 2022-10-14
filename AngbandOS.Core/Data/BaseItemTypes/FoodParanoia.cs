using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodParanoia : FoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Food:Paranoia";

        public override int Chance1 => 1;
        public override string FriendlyName => "Paranoia";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int Pval => 500;
        public override int? SubCategory => 2;
        public override int Weight => 1;
    }
}
