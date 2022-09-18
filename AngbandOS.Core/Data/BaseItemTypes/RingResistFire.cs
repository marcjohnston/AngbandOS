using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingResistFire : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Resist Fire";

        public override int Chance1 => 1;
        public override int Cost => 250;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Resist Fire";
        public override bool IgnoreFire => true;
        public override int Level => 10;
        public override int Locale1 => 10;
        public override bool ResFire => true;
        public override int SubCategory => 8;
        public override int Weight => 2;
    }
}
