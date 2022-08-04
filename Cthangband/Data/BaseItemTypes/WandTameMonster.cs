using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class WandTameMonster : WandItemCategory
    {
        public override char Character => '-';
        public override Colour Colour => Colour.Background;
        public override string Name => "Wand:Tame Monster";

        public override int Chance1 => 2;
        public override int Cost => 1500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Tame Monster";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int SubCategory => 17;
        public override int Weight => 10;
    }
}
