using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class WandAcidBalls : WandItemCategory
    {
        public override char Character => '-';
        public override Colour Colour => Colour.Background;
        public override string Name => "Wand:Acid Balls";

        public override int Chance1 => 1;
        public override int Cost => 1650;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Acid Balls";
        public override bool IgnoreAcid => true;
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int SubCategory => 20;
        public override int Weight => 10;
    }
}
