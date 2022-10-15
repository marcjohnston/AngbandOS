using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandTeleportOther : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Teleport Other";

        public override int Chance1 => 1;
        public override int Cost => 350;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Teleport Other";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int? SubCategory => WandType.TeleportAway;
        public override int Weight => 10;
    }
}
