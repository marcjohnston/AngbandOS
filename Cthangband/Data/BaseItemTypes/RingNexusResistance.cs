using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingNexusResistance : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Nexus Resistance";

        public override int Chance1 => 2;
        public override int Cost => 3000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Nexus Resistance";
        public override int Level => 24;
        public override int Locale1 => 24;
        public override bool ResNexus => true;
        public override int SubCategory => 41;
        public override int Weight => 2;
    }
}
