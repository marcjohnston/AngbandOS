using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomParalysis : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Paralysis";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Paralysis";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 5;
        public override int Weight => 1;
    }
}
