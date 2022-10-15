using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandAcidBolts : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Acid Bolts";

        public override int Chance1 => 1;
        public override int Cost => 950;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Acid Bolts";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int? SubCategory => WandType.AcidBolt;
        public override int Weight => 10;
    }
}
