using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodHallucination : FoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Food:Hallucination";

        public override int Chance1 => 1;
        public override string FriendlyName => "Hallucination";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Pval => 500;
        public override int SubCategory => 4;
        public override int Weight => 1;
    }
}
