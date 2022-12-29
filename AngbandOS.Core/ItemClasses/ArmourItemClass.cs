using AngbandOS.ArtifactBiases;
using static AngbandOS.Extensions;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    /// <summary>
    /// Represents armour items.  Boots, clocks, crowns, dragon armour, gloves, hard armour, helm, shield and soft armour are all armour classes.
    /// </summary>
    internal abstract class ArmourItemClass : ItemClass
    {
        public ArmourItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool HasQuality => true;

        public override void ApplyRandartBonus(Item item)
        {
            item.BonusArmourClass += Program.Rng.DieRoll(item.BonusArmourClass > 19 ? 1 : 20 - item.BonusArmourClass);
        }

        public override int RandartActivationChance => base.RandartActivationChance * 2;
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

        /// <summary>
        /// Returns true, for all armour where the armour class (ToA) is greater than or equal to zero.
        /// </summary>
        public override bool KindIsGood => ToA >= 0;

        public override int? GetBonusRealValue(Item item, int value)
        {
            if (item.BonusArmourClass < 0)
                return null;

            return (item.BonusToHit + item.BonusDamage + item.BonusArmourClass) * 100;
        }

        public override int? GetTypeSpecificRealValue(Item item, int value)
        {
            return ComputeTypeSpecificRealValue(item, value);
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

        public override bool IsWorthless(Item item)
        {
            if (item.TypeSpecificValue < 0)
            {
                return true;
            }
            if (item.BonusArmourClass < 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Applies a good random rare characteristics to an item of armour.
        /// </summary>
        /// <param name="item"></param>
        protected virtual void ApplyRandomGoodRareCharacteristics(Item item)
        {
            switch (Program.Rng.DieRoll(21))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistAcid;
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                    item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistLightning;
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                    item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistFire;
                    break;
                case 13:
                case 14:
                case 15:
                case 16:
                    item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistCold;
                    break;
                case 17:
                case 18:
                    IArtifactBias artifactBias = null;
                    item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistance;
                    if (Program.Rng.DieRoll(4) == 1)
                    {
                        item.RandartItemCharacteristics.ResPois = true;
                    }
                    item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                    break;
                case 19:
                    item.CreateRandart(false);
                    break;
                case 20:
                case 21:
                    item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfYith;
                    break;
            }
        }


        /// <summary>
        /// Applies a poor random rare characteristics to an item of armour.  Does nothing by default.  Various derived class may override
        /// this method and apply a random poor characteristic to the item.
        /// </summary>
        /// <param name="item"></param>
        protected virtual void ApplyRandomPoorRareCharacteristics(Item item)
        {
        }

        protected void ApplyDragonscaleResistance(Item item)
        {
            do
            {
                if (Program.Rng.DieRoll(4) == 1)
                {
                    IArtifactBias artifactBias = null;
                    item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(14) + 4);
                }
                else
                {
                    IArtifactBias artifactBias = null;
                    item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                }
            } while (Program.Rng.DieRoll(2) == 1);
        }

        /// <summary>
        /// Applies a standard BonusArmourClass and IdentCursed to armour class items.  Derived items must call this base to have these
        /// standard characteristics applied, when needed.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="level"></param>
        /// <param name="power"></param>
        public override void ApplyMagic(Item item, int level, int power)
        {
            int toac1 = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            int toac2 = GetBonusValue(10, level);
            if (power > 0)
            {
                item.BonusArmourClass += toac1;
                if (power > 1)
                {
                    item.BonusArmourClass += toac2;
                }
            }
            else if (power < 0)
            {
                item.BonusArmourClass -= toac1;
                if (power < -1)
                {
                    item.BonusArmourClass -= toac2;
                }
                if (item.BonusArmourClass < 0)
                {
                    item.IdentCursed = true;
                }
            }
        }

        public override string GetDetailedDescription(Item item)
        {
            string s = "";
            if (item.IsKnown())
            {
                item.RefreshFlagBasedProperties();
                if (ShowMods || item.BonusToHit != 0 && item.BonusDamage != 0)
                {
                    s += $" ({GetSignedValue(item.BonusToHit)},{GetSignedValue(item.BonusDamage)})";
                }
                else if (item.BonusToHit != 0)
                {
                    s += $" ({GetSignedValue(item.BonusToHit)})";
                }
                else if (item.BonusDamage != 0)
                {
                    s += $" ({GetSignedValue(item.BonusDamage)})";
                }

                // Add base armour class for all types of armour and when the base armour class is greater than zero.
                s += $" [{item.BaseArmourClass},{GetSignedValue(item.BonusArmourClass)}]";
            }
            else if (item.BaseArmourClass != 0)
            {
                s += $" [{item.BaseArmourClass}]";
            }
            return s;
        }
    }
}
