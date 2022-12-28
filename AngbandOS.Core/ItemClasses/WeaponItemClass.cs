using static AngbandOS.Extensions;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    /// <summary>
    /// Represents weapon items.  Arrow, bolt, bow, digging, hafted, polearm, shot and swords are all weapon classes.
    /// </summary>
    internal abstract class WeaponItemClass : ItemClass
    {
        public override bool HasQuality => true;

        public override void ApplyRandartBonus(Item item)
        {
            item.BonusToHit += Program.Rng.DieRoll(item.BonusToHit > 19 ? 1 : 20 - item.BonusToHit);
            item.BonusDamage += Program.Rng.DieRoll(item.BonusDamage > 19 ? 1 : 20 - item.BonusDamage);
        }

        public override bool CanApplyBonusArmourClassMiscPower => true;

        /// <summary>
        /// Returns true, for all weapons where both the hit (ToH) and damage (ToD) are equal to or greater than zero.  False, for all weapons with either stat less than 0.
        /// </summary>
        public override bool KindIsGood
        {
            get
            {
                if (ToH < 0)
                {
                    return false;
                }
                if (ToD < 0)
                {
                    return false;
                }
                return true;
            }
        }

        public override int GetAdditionalMassProduceCount(Item item)
        {
            int cost = item.Value();
            if (item.RareItemTypeIndex != 0)
            {
                return 0;
            }
            if (cost <= 10)
            {
                return MassRoll(3, 5);
            }
            if (cost <= 100)
            {
                return MassRoll(3, 5);
            }
            return 0;
        }

        public override bool CanAbsorb(Item item, Item other)
        {
            if (!item.IsKnown() || !other.IsKnown())
            {
                return false;
            }
            if (!item.StatsAreSame(other))
            {
                return false;
            }
            return true;
        }

        public override bool CanApplySlayingBonus => true;

        public override string GetDetailedDescription(Item item)
        {
            string s = "";
            s += $" ({item.DamageDice}d{item.DamageDiceSides})";
            if (item.IsKnown())
            {
                s += $" ({GetSignedValue(item.BonusToHit)},{GetSignedValue(item.BonusDamage)})";

                if (item.BaseArmourClass != 0)
                {
                    // Add base armour class for all types of armour and when the base armour class is greater than zero.
                    s += $" [{item.BaseArmourClass},{GetSignedValue(item.BonusArmourClass)}]";
                }
                else if (item.BonusArmourClass != 0)
                {
                    // This is not armour, only show bonus armour class, if it is not zero and we know about it.
                    s += $" [{GetSignedValue(item.BonusArmourClass)}]";
                }
            }
            else if (item.BaseArmourClass != 0)
            {
                s += $" [{item.BaseArmourClass}]";
            }
            return s;
        }

        public override bool CanApplyTunnelBonus => true;
        public override bool CanApplyBlowsBonus => true;

        public override int? GetBonusRealValue(Item item, int value)
        {
            if (item.BonusToHit + item.BonusDamage < 0)
                return null;

            int bonusValue = 0;
            bonusValue += (item.BonusToHit + item.BonusDamage + item.BonusArmourClass) * 100;
            if (item.DamageDice > item.BaseItemCategory.Dd && item.DamageDiceSides == item.BaseItemCategory.Ds)
            {
                bonusValue += (item.DamageDice - item.BaseItemCategory.Dd) * item.DamageDiceSides * 100;
            }
            return bonusValue;
        }
        public override int? GetTypeSpecificRealValue(Item item, int value)
        {
            return ComputeTypeSpecificRealValue(item, value);
        }

        public override bool IsWorthless(Item item)
        {
            if (item.TypeSpecificValue < 0)
            {
                return true;
            }
            if (item.BonusToHit + item.BonusDamage < 0)
            {
                return true;
            }
            return false;
        }

        public override void ApplyMagic(Item item, int level, int power)
        {
            if (power == 0)
            {
                return;
            }

            int tohit1 = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            int todam1 = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            int tohit2 = GetBonusValue(10, level);
            int todam2 = GetBonusValue(10, level);
            if (power > 0)
            {
                item.BonusToHit += tohit1;
                item.BonusDamage += todam1;
                if (power > 1)
                {
                    item.BonusToHit += tohit2;
                    item.BonusDamage += todam2;
                }
            }
            else if (power < 0)
            {
                item.BonusToHit -= tohit1;
                item.BonusDamage -= todam1;
                if (power < -1)
                {
                    item.BonusToHit -= tohit2;
                    item.BonusDamage -= todam2;
                }
                if (item.BonusToHit + item.BonusDamage < 0)
                {
                    item.IdentCursed = true;
                }
            }
        }
    }
}
