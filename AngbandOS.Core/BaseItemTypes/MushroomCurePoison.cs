using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomCurePoison : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Cure Poison";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 60;
        public override string FriendlyName => "Cure Poison";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 12;
        public override int Weight => 1;
    }
}
