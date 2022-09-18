using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingFearResistance : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Fear Resistance";

        public override int Chance1 => 2;
        public override int Cost => 300;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Fear Resistance";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override bool ResFear => true;
        public override int SubCategory => 38;
        public override int Weight => 2;
    }
}
