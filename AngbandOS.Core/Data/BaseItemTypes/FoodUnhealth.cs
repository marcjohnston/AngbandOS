using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class FoodUnhealth : FoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Food:Unhealth";

        public override int Chance1 => 1;
        public override int Cost => 50;
        public override int Dd => 10;
        public override int Ds => 10;
        public override string FriendlyName => "Unhealth";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int Pval => 500;
        public override int SubCategory => 10;
        public override int Weight => 1;
    }
}
