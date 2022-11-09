using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomCureSeriousWounds : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Cure Serious Wounds";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 75;
        public override string FriendlyName => "Cure Serious Wounds";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 16;
        public override int Weight => 2;
    }
}
