using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollDoorStairLocation : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Door/Stair Location";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Chance3 => 1;
        public override int Cost => 35;
        public override string FriendlyName => "Door/Stair Location";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int Locale2 => 10;
        public override int Locale3 => 15;
        public override int? SubCategory => 29;
        public override int Weight => 5;
    }
}
