using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionDetonations : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Detonations";

        public override int Chance1 => 8;
        public override int Cost => 10000;
        public override int Dd => 25;
        public override int Ds => 25;
        public override string FriendlyName => "Detonations";
        public override int Level => 60;
        public override int Locale1 => 60;
        public override int? SubCategory => 22;
        public override int Weight => 4;
    }
}
