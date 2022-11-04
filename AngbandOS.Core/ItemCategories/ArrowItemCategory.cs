using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class ArrowItemCategory : AmmunitionItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.Arrow;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;
        public override int GetBonusRealValue(Item item, int value)
        {
            int bonusValue = 0;
            bonusValue = (item.BonusToHit + item.BonusDamage) * 5;
            if (item.DamageDice > item.ItemType.Dd && item.DamageDiceSides == item.ItemType.Ds)
            {
                bonusValue += (item.DamageDice - item.ItemType.Dd) * item.DamageDiceSides * 5;
            }
            bonusValue += GetTypeSpecificValue(item, value); // Apply type specific values;
            return bonusValue;
        }

        /// <summary>
        /// Returns true, for all arrows.
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

        public override Colour Colour => Colour.BrightBrown;

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
