using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingTeleportation : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Teleportation";

        public override int Chance1 => 1;
        public override int Cost => 250;
        public override bool Cursed => true;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Teleportation";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int SubCategory => 4;
        public override bool Teleport => true;
        public override int Weight => 2;
    }
}
