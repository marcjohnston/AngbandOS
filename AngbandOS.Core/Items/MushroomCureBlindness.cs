using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomCureBlindness : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Cure Blindness";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 50;
        public override string FriendlyName => "Cure Blindness";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 13;
        public override int Weight => 1;
    }
}
