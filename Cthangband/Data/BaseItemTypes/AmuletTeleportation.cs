using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class AmuletTeleportation : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Amulet:Teleportation";

        public override int Chance1 => 1;
        public override int Cost => 250;
        public override bool Cursed => true;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Teleportation";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int SubCategory => 1;
        public override bool Teleport => true;
        public override int Weight => 3;
    }
}
