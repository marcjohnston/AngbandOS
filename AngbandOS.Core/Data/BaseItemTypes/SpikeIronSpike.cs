using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SpikeIronSpike : SpikeItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Black;
        public override string Name => "Spike:Iron Spike";

        public override int Chance1 => 1;
        public override int Cost => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Iron Spike~";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int Weight => 10;
    }
}
