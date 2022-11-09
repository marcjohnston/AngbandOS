using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomPoison : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Poison";

        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Dd => 4;
        public override int Ds => 4;
        public override string FriendlyName => "Poison";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 5, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 0;
        public override int Weight => 1;
    }
}
