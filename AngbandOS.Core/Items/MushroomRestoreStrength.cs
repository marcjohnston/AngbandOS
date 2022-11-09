using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomRestoreStrength : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Restore Strength";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 350;
        public override string FriendlyName => "Restore Strength";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 17;
        public override int Weight => 1;
    }
}
