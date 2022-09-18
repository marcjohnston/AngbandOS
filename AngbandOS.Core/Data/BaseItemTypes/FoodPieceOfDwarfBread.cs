using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodPieceOfDwarfBread : FoodItemCategory
    {
        public override char Character => ',';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Food:Piece of Dwarf Bread";

        public override int Chance1 => 1;
        public override int Cost => 16;
        public override int Dd => 1;
        public override int Ds => 6;
        public override string FriendlyName => "& Piece~ of Dwarf Bread";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int Pval => 7500;
        public override int SubCategory => 41;
        public override int Weight => 3;
    }
}
