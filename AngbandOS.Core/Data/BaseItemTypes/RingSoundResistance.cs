using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingSoundResistance : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Sound Resistance";

        public override int Chance1 => 2;
        public override int Cost => 3000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Sound Resistance";
        public override int Level => 26;
        public override int Locale1 => 26;
        public override bool ResSound => true;
        public override int SubCategory => 42;
        public override int Weight => 2;
    }
}
