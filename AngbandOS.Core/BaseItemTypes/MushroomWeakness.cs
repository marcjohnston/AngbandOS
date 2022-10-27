using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomWeakness : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Weakness";

        public override int Chance1 => 1;
        public override int Dd => 5;
        public override int Ds => 5;
        public override string FriendlyName => "Weakness";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Pval => 500;
        public override int? SubCategory => 6;
        public override int Weight => 1;
    }
}
