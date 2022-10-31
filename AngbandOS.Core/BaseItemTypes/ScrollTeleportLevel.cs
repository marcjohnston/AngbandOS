using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollTeleportLevel : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Teleport Level";

        public override int Chance1 => 1;
        public override int Cost => 50;
        public override string FriendlyName => "Teleport Level";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int? SubCategory => 10;
        public override int Weight => 5;
        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.TeleportPlayerLevel();
            eventArgs.Identified = true;
        }
    }
}
