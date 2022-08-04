using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SpikeItemCategory : BaseItemCategory
    {
        public override Colour Colour => Colour.Grey;
        public override int MakeObjectCount => Program.Rng.DiceRoll(6, 7);
    }
}
