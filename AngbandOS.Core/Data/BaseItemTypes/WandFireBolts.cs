using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandFireBolts : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Fire Bolts";

        public override int Chance1 => 1;
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Fire Bolts";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int? SubCategory => 18;
        public override int Weight => 10;
    }
}
