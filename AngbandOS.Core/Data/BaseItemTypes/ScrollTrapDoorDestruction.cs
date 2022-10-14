using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollTrapDoorDestruction : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Trap/Door Destruction";

        public override int Chance1 => 1;
        public override int Cost => 50;
        public override string FriendlyName => "Trap/Door Destruction";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int? SubCategory => 39;
        public override int Weight => 5;
    }
}
