using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodSlimeMold : FoodItemCategory
    {
        public override char Character => ',';
        public override Colour Colour => Colour.Green;
        public override string Name => "Slime Mold";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 2;
        public override string FriendlyName => "& Slime Mold~";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int Pval => 3000;
        public override int? SubCategory => 36;
        public override int Weight => 5;
    }
}