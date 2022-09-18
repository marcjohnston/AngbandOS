using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodPieceOfElvishWaybread : FoodItemCategory
    {
        public override char Character => ',';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Food:Piece of Elvish Waybread";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Chance3 => 1;
        public override int Cost => 10;
        public override string FriendlyName => "& Piece~ of Elvish Waybread";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int Locale2 => 10;
        public override int Locale3 => 20;
        public override int Pval => 7500;
        public override int SubCategory => 37;
        public override int Weight => 3;
    }
}
