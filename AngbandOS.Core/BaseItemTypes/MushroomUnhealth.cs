using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomUnhealth : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Unhealth";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 50;
        public override int Dd => 10;
        public override int Ds => 10;
        public override string FriendlyName => "Unhealth";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 10;
        public override int Weight => 1;
    }
}
