using Cthangband.ArtifactBiases;
using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;
using static Cthangband.Extensions;

namespace Cthangband.ItemCategories
{
    [Serializable]
    /// <summary>
    /// Represents weapon items.  Arrow, bolt, bow, digging, hafted, polearm, shot and swords are all weapon classes.
    /// </summary>
    internal class WeaponItemCategory : BaseItemCategory
    {
        public WeaponItemCategory(ItemCategory itemCategory) : base(itemCategory)
        {
        }
        //    public override bool CanSlay => true;

        public override bool CanApplyBonusArmourClassMiscPower => true;

        public override bool CanApplySlayingBonus => true; 

        public override string GetDetailedDescription(Item item)
        {
            string s = "";
            s += $" ({item.DamageDice}d{item.DamageDiceSides})";
            if (item.IsKnown())
            {
                FlagSet f1 = new FlagSet();
                FlagSet f2 = new FlagSet();
                FlagSet f3 = new FlagSet();
                item.GetMergedFlags(f1, f2, f3);
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

        public override int GetBonusRealValue(Item item, int value)
        {
            int bonusValue = 0;
            bonusValue += (item.BonusToHit + item.BonusDamage + item.BonusArmourClass) * 100;
            if (item.DamageDice > item.ItemType.Dd && item.DamageDiceSides == item.ItemType.Ds)
            {
                bonusValue += (item.DamageDice - item.ItemType.Dd) * item.DamageDiceSides * 100;
            }
            bonusValue += GetTypeSpecificValue(item, value); // Apply type specific values;
            return bonusValue;
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
            IArtifactBias artifactBias = null;
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
                    item.IdentifyFlags.Set(Constants.IdentCursed);
                }
            }
            switch (item.Category)
            {
                case ItemCategory.Digging:
                    {
                        if (power > 1)
                        {
                            item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfDigging;
                        }
                        else if (power < -1)
                        {
                            item.TypeSpecificValue = 0 - (5 + Program.Rng.DieRoll(5));
                        }
                        else if (power < 0)
                        {
                            item.TypeSpecificValue = 0 - item.TypeSpecificValue;
                        }
                        break;
                    }
                case ItemCategory.Hafted:
                case ItemCategory.Polearm:
                case ItemCategory.Sword:
                    {
                        if (power > 1)
                        {
                            switch (Program.Rng.DieRoll(item.Category == ItemCategory.Polearm ? 40 : 42))
                            {
                                case 1:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponElderSign;
                                        if (Program.Rng.DieRoll(4) == 1)
                                        {
                                            item.RandartFlags1.Set(ItemFlag1.Blows);
                                            if (item.TypeSpecificValue > 2)
                                            {
                                                item.TypeSpecificValue -= Program.Rng.DieRoll(2);
                                            }
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponDefender;
                                        if (Program.Rng.DieRoll(3) == 1)
                                        {
                                            item.RandartFlags2.Set(ItemFlag2.ResPois);
                                        }
                                        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                                        break;
                                    }
                                case 3:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfVitriol;
                                        break;
                                    }
                                case 4:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfShocking;
                                        break;
                                    }
                                case 5:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfBurning;
                                        break;
                                    }
                                case 6:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfFreezing;
                                        break;
                                    }
                                case 7:
                                case 8:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayAnimal;
                                        if (Program.Rng.RandomLessThan(100) < 20)
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfAnimalBane;
                                        }
                                        break;
                                    }
                                case 9:
                                case 10:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayDragon;
                                        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(12) + 4);
                                        if (Program.Rng.RandomLessThan(100) < 20)
                                        {
                                            if (Program.Rng.DieRoll(3) == 1)
                                            {
                                                item.RandartFlags2.Set(ItemFlag2.ResPois);
                                            }
                                            item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(14) + 4);
                                            item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfDragonBane;
                                        }
                                        break;
                                    }
                                case 11:
                                case 12:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayEvil;
                                        if (Program.Rng.RandomLessThan(100) < 20)
                                        {
                                            item.RandartFlags2.Set(ItemFlag2.ResFear);
                                            item.RandartFlags3.Set(ItemFlag3.Blessed);
                                            item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfEvilBane;
                                        }
                                        break;
                                    }
                                case 13:
                                case 14:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayUndead;
                                        item.RandartFlags2.Set(ItemFlag2.HoldLife);
                                        if (Program.Rng.RandomLessThan(100) < 20)
                                        {
                                            item.RandartFlags2.Set(ItemFlag2.ResNether);
                                            item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfUndeadBane;
                                        }
                                        break;
                                    }
                                case 15:
                                case 16:
                                case 17:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayOrc;
                                        break;
                                    }
                                case 18:
                                case 19:
                                case 20:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayTroll;
                                        break;
                                    }
                                case 21:
                                case 22:
                                case 23:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayGiant;
                                        break;
                                    }
                                case 24:
                                case 25:
                                case 26:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayDemon;
                                        break;
                                    }
                                case 27:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfKadath;
                                        if (Program.Rng.DieRoll(3) == 1)
                                        {
                                            item.RandartFlags2.Set(ItemFlag2.ResFear);
                                        }
                                        break;
                                    }
                                case 28:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponBlessed;
                                        break;
                                    }
                                case 29:
                                case 30:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfExtraAttacks;
                                        break;
                                    }
                                case 31:
                                case 32:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponVampiric;
                                        break;
                                    }
                                case 33:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfPoisoning;
                                        break;
                                    }
                                case 34:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponChaotic;
                                        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
                                        break;
                                    }
                                case 35:
                                    {
                                        item.CreateRandart(false);
                                        break;
                                    }
                                case 36:
                                case 37:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlaying;
                                        if (Program.Rng.DieRoll(3) == 1)
                                        {
                                            item.DamageDice *= 2;
                                        }
                                        else
                                        {
                                            do
                                            {
                                                item.DamageDice++;
                                            } while (Program.Rng.DieRoll(item.DamageDice) == 1);
                                            do
                                            {
                                                item.DamageDiceSides++;
                                            } while (Program.Rng.DieRoll(item.DamageDiceSides) == 1);
                                        }
                                        if (Program.Rng.DieRoll(5) == 1)
                                        {
                                            item.RandartFlags1.Set(ItemFlag1.BrandPois);
                                        }
                                        if (item.Category == ItemCategory.Sword && Program.Rng.DieRoll(3) == 1)
                                        {
                                            item.RandartFlags1.Set(ItemFlag1.Vorpal);
                                        }
                                        break;
                                    }
                                case 38:
                                case 39:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponPlanarWeapon;
                                        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                                        if (Program.Rng.DieRoll(5) == 1)
                                        {
                                            item.RandartFlags1.Set(ItemFlag1.SlayDemon);
                                        }
                                        break;
                                    }
                                case 40:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfLaw;
                                        if (Program.Rng.DieRoll(3) == 1)
                                        {
                                            item.RandartFlags2.Set(ItemFlag2.HoldLife);
                                        }
                                        if (Program.Rng.DieRoll(3) == 1)
                                        {
                                            item.RandartFlags1.Set(ItemFlag1.Dex);
                                        }
                                        if (Program.Rng.DieRoll(5) == 1)
                                        {
                                            item.RandartFlags2.Set(ItemFlag2.ResFear);
                                        }
                                        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                                        break;
                                    }
                                default:
                                    {
                                        if (item.Category == ItemCategory.Sword)
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSharpness;
                                            item.TypeSpecificValue = GetBonusValue(5, level) + 1;
                                        }
                                        else
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfEarthquakes;
                                            if (Program.Rng.DieRoll(3) == 1)
                                            {
                                                item.RandartFlags1.Set(ItemFlag1.Blows);
                                            }
                                            item.TypeSpecificValue = GetBonusValue(3, level);
                                        }
                                        break;
                                    }
                            }
                            while (Program.Rng.RandomLessThan(10 * item.DamageDice * item.DamageDiceSides) == 0)
                            {
                                item.DamageDice++;
                            }
                            if (item.DamageDice > 9)
                            {
                                item.DamageDice = 9;
                            }
                        }
                        else if (power < -1)
                        {
                            if (Program.Rng.RandomLessThan(Constants.MaxDepth) < level)
                            {
                                item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfLeng;
                                if (Program.Rng.DieRoll(6) == 1)
                                {
                                    item.RandartFlags3.Set(ItemFlag3.DreadCurse);
                                }
                            }
                        }
                        break;
                    }
                case ItemCategory.Bow:
                    {
                        if (power > 1)
                        {
                            switch (Program.Rng.DieRoll(21))
                            {
                                case 1:
                                case 11:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.BowOfExtraMight;
                                        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
                                        break;
                                    }
                                case 2:
                                case 12:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.BowOfExtraShots;
                                        break;
                                    }
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                case 13:
                                case 14:
                                case 15:
                                case 16:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.BowOfVelocity;
                                        break;
                                    }
                                case 7:
                                case 8:
                                case 9:
                                case 10:
                                case 17:
                                case 18:
                                case 19:
                                case 20:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.BowOfAccuracy;
                                        break;
                                    }
                                default:
                                    {
                                        item.CreateRandart(false);
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case ItemCategory.Bolt:
                case ItemCategory.Arrow:
                case ItemCategory.Shot:
                    {
                        if (power > 1)
                        {
                            switch (Program.Rng.DieRoll(12))
                            {
                                case 1:
                                case 2:
                                case 3:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfWounding;
                                        break;
                                    }
                                case 4:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfFlame;
                                        break;
                                    }
                                case 5:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfFrost;
                                        break;
                                    }
                                case 6:
                                case 7:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfHurtAnimal;
                                        break;
                                    }
                                case 8:
                                case 9:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfHurtEvil;
                                        break;
                                    }
                                case 10:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfHurtDragon;
                                        break;
                                    }
                                case 11:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfShocking;
                                        break;
                                    }
                                case 12:
                                    {
                                        item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfSlaying;
                                        item.DamageDice++;
                                        break;
                                    }
                            }
                            while (Program.Rng.RandomLessThan(10 * item.DamageDice * item.DamageDiceSides) == 0)
                            {
                                item.DamageDice++;
                            }
                            if (item.DamageDice > 9)
                            {
                                item.DamageDice = 9;
                            }
                        }
                        else if (power < -1)
                        {
                            if (Program.Rng.RandomLessThan(Constants.MaxDepth) < level)
                            {
                                item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfBackbiting;
                            }
                        }
                        break;
                    }
            }
        }
    }
}
