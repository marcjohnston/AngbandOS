using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class AmuletBrilliance : AmuletItemCategory
    {
        public override char Character => '"';
        public override Colour Colour => Colour.Background;
        public override string Name => "Amulet:Brilliance";

        public override int Chance1 => 1;
        public override int Cost => 500;
        public override string FriendlyName => "Brilliance";
        public override bool HideType => true;
        public override bool Int => true;
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int SubCategory => 6;
        public override int Weight => 3;
        public override bool Wis => true;
    }
}
