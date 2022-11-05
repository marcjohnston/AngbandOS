using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomSickness : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Sickness";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 4;
        public override int Ds => 4;
        public override string FriendlyName => "Sickness";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 7;
        public override int Weight => 1;
    }
}
