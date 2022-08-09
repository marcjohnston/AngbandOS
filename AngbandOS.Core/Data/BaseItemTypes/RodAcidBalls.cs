using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RodAcidBalls : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Rod:Acid Balls";

        public override int Chance1 => 1;
        public override int Cost => 5500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Acid Balls";
        public override int Level => 70;
        public override int Locale1 => 70;
        public override int SubCategory => 24;
        public override int Weight => 15;
    }
}
