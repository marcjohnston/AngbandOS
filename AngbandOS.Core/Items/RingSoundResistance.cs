using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingSoundResistance : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Sound Resistance";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 3000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Sound Resistance";
        public override int Level => 26;
        public override int[] Locale => new int[] { 26, 0, 0, 0 };
        public override bool ResSound => true;
        public override int? SubCategory => 42;
        public override int Weight => 2;
    }
}