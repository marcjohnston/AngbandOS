using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingPoisonResistance : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Poison Resistance";

        public override int Chance1 => 2;
        public override int Cost => 16000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Poison Resistance";
        public override int Level => 60;
        public override int Locale1 => 60;
        public override bool ResPois => true;
        public override int? SubCategory => 20;
        public override int Weight => 2;
    }
}
