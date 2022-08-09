using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ChaosBookChaosMastery : ChaosBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "ChaosBook:[Chaos Mastery]";

        public override int Chance1 => 1;
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Chaos Mastery]";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int SubCategory => 1;
        public override int Weight => 30;
    }
}
