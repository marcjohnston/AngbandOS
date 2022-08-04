using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class WandHasteMonster : WandItemCategory
    {
        public override char Character => '-';
        public override Colour Colour => Colour.Background;
        public override string Name => "Wand:Haste Monster";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Haste Monster";
        public override int Level => 2;
        public override int Locale1 => 2;
        public override int SubCategory => 1;
        public override int Weight => 10;
    }
}
