using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ChaosBookSignofChaos : ChaosBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "ChaosBook:[Sign of Chaos]";

        public override int Chance1 => 1;
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Sign of Chaos]";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Weight => 30;
    }
}
