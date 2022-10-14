using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodDoorStairLocation : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Rod:Door/Stair Location";

        public override int Chance1 => 1;
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Door/Stair Location";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int? SubCategory => 1;
        public override int Weight => 15;
    }
}
