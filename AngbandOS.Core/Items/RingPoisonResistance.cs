using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingPoisonResistance : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Poison Resistance";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 16000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Poison Resistance";
        public override int Level => 60;
        public override int[] Locale => new int[] { 60, 0, 0, 0 };
        public override bool ResPois => true;
        public override int? SubCategory => 20;
        public override int Weight => 2;
    }
}