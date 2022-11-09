using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomConfusion : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Confusion";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Confusion";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 3;
        public override int Weight => 1;
    }
}
