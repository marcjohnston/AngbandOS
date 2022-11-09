using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomRestoring : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Restoring";

        public override int[] Chance => new int[] { 8, 4, 1, 0 };
        public override int Cost => 1000;
        public override string FriendlyName => "Restoring";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 30, 40, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 19;
        public override int Weight => 1;
    }
}
