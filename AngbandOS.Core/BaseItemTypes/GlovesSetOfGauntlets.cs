using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class GlovesSetOfGauntlets : GlovesItemCategory
    {
        public override char Character => ']';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Set of Gauntlets";

        public override int Ac => 2;
        public override int Chance1 => 1;
        public override int Cost => 35;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Set~ of Gauntlets";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Weight => 25;
    }
}
