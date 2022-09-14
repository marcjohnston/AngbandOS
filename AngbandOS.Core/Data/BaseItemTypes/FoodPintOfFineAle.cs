using AngbandOS.Core.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class FoodPintOfFineAle : FoodItemCategory
    {
        public override char Character => ',';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Food:Pint of Fine Ale";

        public override int Cost => 1;
        public override string FriendlyName => "& Pint~ of Fine Ale";
        public override int Pval => 500;
        public override int SubCategory => 38;
        public override int Weight => 5;
    }
}
