using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomBlindness : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Blindness";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Blindness";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 1;
        public override int Weight => 1;
    }
}