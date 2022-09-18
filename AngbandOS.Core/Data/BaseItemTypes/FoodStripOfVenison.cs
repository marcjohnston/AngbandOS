using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodStripOfVenison : FoodItemCategory
    {
        public override char Character => ',';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Food:Strip of Venison";

        public override int Cost => 2;
        public override string FriendlyName => "& Strip~ of Venison";
        public override int Pval => 1500;
        public override int SubCategory => 33;
        public override int Weight => 2;
    }
}
