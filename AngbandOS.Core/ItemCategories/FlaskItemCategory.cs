using AngbandOS.Interface;
using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal abstract class FlaskItemCategory : BaseItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.Flask;
        public override bool HatesCold => true;
        public override Colour Colour => Colour.Yellow;
        public override int PercentageBreakageChance => 100;
        public override int GetAdditionalMassProduceCount(Item item)
        {
            int cost = item.Value();
            if (cost <= 5)
            {
                return MassRoll(3, 5);
            }
            if (cost <= 20)
            {
                return MassRoll(3, 5);
            }
            return 0;
        }
    }
}
