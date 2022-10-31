using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollTeleportation : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Teleportation";

        public override int Chance1 => 1;
        public override int Cost => 40;
        public override string FriendlyName => "Teleportation";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int? SubCategory => 9;
        public override int Weight => 5;
        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.TeleportPlayer(100);
            eventArgs.Identified = true;
        }
    }
}
