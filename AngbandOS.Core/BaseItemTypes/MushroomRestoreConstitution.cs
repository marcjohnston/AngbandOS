using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomRestoreConstitution : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Restore Constitution";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 350;
        public override string FriendlyName => "Restore Constitution";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 18;
        public override int Weight => 1;
    }
}
