using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomStupidity : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Stupidity";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Stupidity";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 8;
        public override int Weight => 1;
    }
}
