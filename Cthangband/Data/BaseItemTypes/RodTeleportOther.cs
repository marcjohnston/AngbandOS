using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RodTeleportOther : RodItemCategory
    {
        public override char Character => '-';
        public override Colour Colour => Colour.Background;
        public override string Name => "Rod:Teleport Other";

        public override int Chance1 => 2;
        public override int Cost => 1400;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Teleport Other";
        public override int Level => 45;
        public override int Locale1 => 45;
        public override int SubCategory => 13;
        public override int Weight => 15;
    }
}
