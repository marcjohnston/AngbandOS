using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingTeleportation : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Teleportation";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 250;
        public override bool Cursed => true;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Teleportation";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 4;
        public override bool Teleport => true;
        public override int Weight => 2;
    }
}
