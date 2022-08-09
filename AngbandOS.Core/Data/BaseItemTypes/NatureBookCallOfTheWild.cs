using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class NatureBookCallOfTheWild : NatureBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "NatureBook:[Call of the Wild]";

        public override int Chance1 => 1;
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Call of the Wild]";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Weight => 30;
    }
}
