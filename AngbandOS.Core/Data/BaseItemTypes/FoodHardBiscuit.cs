using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class FoodHardBiscuit : FoodItemCategory
    {
        public override char Character => ',';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Food:Hard Biscuit";

        public override int Cost => 1;
        public override string FriendlyName => "& Hard Biscuit~";
        public override int Pval => 500;
        public override int SubCategory => 32;
        public override int Weight => 2;
    }
}
