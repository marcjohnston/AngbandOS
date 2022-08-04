using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class WandDragonsFrost : WandItemCategory
    {
        public override char Character => '-';
        public override Colour Colour => Colour.Background;
        public override string Name => "Wand:Dragon's Frost";

        public override int Chance1 => 4;
        public override int Cost => 2400;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Dragon's Frost";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int SubCategory => 27;
        public override int Weight => 10;
    }
}
