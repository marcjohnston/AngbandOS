using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingDisenchantmentResistance : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Disenchantment Resistance";

        public override int Chance1 => 10;
        public override int Cost => 15000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Disenchantment Resistance";
        public override int Level => 90;
        public override int Locale1 => 90;
        public override bool ResDisen => true;
        public override int? SubCategory => 45;
        public override int Weight => 2;
    }
}
