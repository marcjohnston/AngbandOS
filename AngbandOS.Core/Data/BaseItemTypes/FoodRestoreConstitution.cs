using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodRestoreConstitution : FoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Food:Restore Constitution";

        public override int Chance1 => 1;
        public override int Cost => 350;
        public override string FriendlyName => "Restore Constitution";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int Pval => 500;
        public override int? SubCategory => 18;
        public override int Weight => 1;
    }
}
