using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomCureConfusion : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Cure Confusion";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 50;
        public override string FriendlyName => "Cure Confusion";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 15;
        public override int Weight => 1;
    }
}
