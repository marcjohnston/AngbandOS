using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class WandCloneMonster : WandItemCategory
    {
        public override char Character => '-';
        public override Colour Colour => Colour.Background;
        public override string Name => "Wand:Clone Monster";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Clone Monster";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int Locale2 => 50;
        public override int SubCategory => 2;
        public override int Weight => 10;
    }
}
