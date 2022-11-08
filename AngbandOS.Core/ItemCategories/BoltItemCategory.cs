using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class BoltItemCategory : AmmunitionItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.Bolt;
        public override Colour Colour => Colour.BrightBrown;

        /// <summary>
        /// Returns true for all bolts.
        /// </summary>
        public override bool KindIsGood => true;

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

        public override bool HatesAcid => true;

        public override bool CanAbsorb(Item item, Item other)
        {
            if (!item.StatsAreSame(other))
            {
                return false;
            }
            return true;
        }
        public override int MakeObjectCount => Program.Rng.DiceRoll(6, 7);

        public override bool GetsDamageMultiplier => true;
        public override int PercentageBreakageChance => 25;
    }
}
