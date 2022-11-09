using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodPieceOfElvishWaybread : FoodItemCategory
    {
        public override char Character => ',';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Piece of Elvish Waybread";

        public override int[] Chance => new int[] { 1, 1, 1, 0 };
        public override int Cost => 10;
        public override string FriendlyName => "& Piece~ of Elvish Waybread";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 10, 20, 0 };
        public override int Pval => 7500;
        public override int? SubCategory => 37;
        public override int Weight => 3;
    }
}
