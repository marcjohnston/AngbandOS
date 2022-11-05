using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class SpikeItemCategory : BaseItemCategory
    {
        public override bool EasyKnow => true;
        public override ItemCategory CategoryEnum => ItemCategory.Spike;
        public override Colour Colour => Colour.Grey;
        public override int MakeObjectCount => Program.Rng.DiceRoll(6, 7);

        public override int GetAdditionalMassProduceCount(Item item)
        {
            int cost = item.Value();
            if (cost <= 5)
            {
                return MassRoll(5, 5);
            }
            if (cost <= 50)
            {
                return MassRoll(5, 5);
            }
            if (cost <= 500)
            {
                return MassRoll(5, 5);
            }
            return 0;
        }
    }
}
