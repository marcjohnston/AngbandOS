using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class FoodPieceOfWarpstone : FoodItemCategory
    {
        public override char Character => '*';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Food:piece of Warpstone";

        public override int Chance1 => 1;
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& piece~ of Warpstone";
        public override int Level => 30;
        public override int Locale1 => 50;
        public override int SubCategory => 40;
        public override int Weight => 1;
    }
}
