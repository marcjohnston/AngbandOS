using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionRestoreStrength : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Restore Strength";

        public override int Chance1 => 1;
        public override int Cost => 300;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Restore Strength";
        public override int Level => 25;
        public override int Locale1 => 25;
        public override int? SubCategory => 42;
        public override int Weight => 4;
    }
}
