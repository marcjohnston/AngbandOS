// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using Cthangband.ActivationPowers;
using Cthangband.Enumerations;
using Cthangband.StaticData;
using Cthangband.UI;

namespace Cthangband
{
    internal class ItemForge
    {
        private readonly Item _item;

        public ItemForge(Item item)
        {
            _item = item;
        }

        private delegate bool GetObjNumHookDelegate(int kIdx);

        public void ApplyMagic(int lev, bool okay, bool good, bool great)
        {
            if (lev > Constants.MaxDepth - 1)
            {
                lev = Constants.MaxDepth - 1;
            }
            int f1 = lev + 10;
            if (f1 > 75)
            {
                f1 = 75;
            }
            int f2 = f1 / 2;
            if (f2 > 20)
            {
                f2 = 20;
            }
            int power = 0;
            if (good || Program.Rng.PercentileRoll(f1))
            {
                power = 1;
                if (great || Program.Rng.PercentileRoll(f2))
                {
                    power = 2;
                }
            }
            else if (Program.Rng.PercentileRoll(f1))
            {
                power = -1;
                if (Program.Rng.PercentileRoll(f2))
                {
                    power = -2;
                }
            }
            int rolls = 0;
            if (power >= 2)
            {
                rolls = 1;
            }
            if (great)
            {
                rolls = 4;
            }
            if (!okay || _item.FixedArtifactIndex != 0)
            {
                rolls = 0;
            }
            for (int i = 0; i < rolls; i++)
            {
                if (ApplyFixedArtifact())
                {
                    break;
                }
            }
            if (_item.FixedArtifactIndex != 0)
            {
                FixedArtifact aPtr = Profile.Instance.FixedArtifacts[_item.FixedArtifactIndex];
                aPtr.CurNum = 1;
                _item.TypeSpecificValue = aPtr.Pval;
                _item.BaseArmourClass = aPtr.Ac;
                _item.DamageDice = aPtr.Dd;
                _item.DamageDiceSides = aPtr.Ds;
                _item.BonusArmourClass = aPtr.ToA;
                _item.BonusToHit = aPtr.ToH;
                _item.BonusDamage = aPtr.ToD;
                _item.Weight = aPtr.Weight;
                if (aPtr.Cost == 0)
                {
                    _item.IdentifyFlags.Set(Constants.IdentBroken);
                }
                if (aPtr.Flags3.IsSet(ItemFlag3.Cursed))
                {
                    _item.IdentifyFlags.Set(Constants.IdentCursed);
                }
                if (SaveGame.Instance.Level != null)
                {
                    SaveGame.Instance.Level.TreasureRating += 10;
                    if (aPtr.Cost > 50000)
                    {
                        SaveGame.Instance.Level.TreasureRating += 10;
                    }
                    SaveGame.Instance.Level.SpecialTreasure = true;
                }
                return;
            }
            switch (_item.Category)
            {
                case ItemCategory.Digging:
                case ItemCategory.Hafted:
                case ItemCategory.Polearm:
                case ItemCategory.Sword:
                case ItemCategory.Bow:
                case ItemCategory.Shot:
                case ItemCategory.Arrow:
                case ItemCategory.Bolt:
                    {
                        if (power != 0)
                        {
                            ApplyMagicToWeapon(lev, power);
                        }
                        break;
                    }
                case ItemCategory.DragArmor:
                case ItemCategory.HardArmor:
                case ItemCategory.SoftArmor:
                case ItemCategory.Shield:
                case ItemCategory.Helm:
                case ItemCategory.Crown:
                case ItemCategory.Cloak:
                case ItemCategory.Gloves:
                case ItemCategory.Boots:
                    {
                        if (power != 0 ||
                            (_item.Category == ItemCategory.Helm && _item.ItemSubCategory == HelmType.SvDragonHelm) ||
                            (_item.Category == ItemCategory.Shield && _item.ItemSubCategory == ShieldType.SvDragonShield) ||
                            (_item.Category == ItemCategory.Cloak && _item.ItemSubCategory == CloakType.SvElvenCloak))
                        {
                            ApplyMagicToArmour(lev, power);
                        }
                        break;
                    }
                case ItemCategory.Ring:
                case ItemCategory.Amulet:
                    {
                        if (power == 0 && Program.Rng.RandomLessThan(100) < 50)
                        {
                            power = -1;
                        }
                        ApplyMagicToJewellery(lev, power);
                        break;
                    }
                case ItemCategory.Light:
                    {
                        ApplyMagicToLightSource(power);
                        break;
                    }
                default:
                    {
                        ApplyMagicToMiscItem();
                        break;
                    }
            }
            if (!string.IsNullOrEmpty(_item.RandartName))
            {
                if (SaveGame.Instance.Level != null)
                {
                    SaveGame.Instance.Level.TreasureRating += 40;
                }
            }
            else if (_item.RareItemTypeIndex != Enumerations.RareItemType.None)
            {
                RareItemType ePtr = Profile.Instance.RareItemTypes[_item.RareItemTypeIndex];
                switch (_item.RareItemTypeIndex)
                {
                    case Enumerations.RareItemType.WeaponElderSign:
                        {
                            _item.BonusPowerType = Enumerations.RareItemType.SpecialSustain;
                            break;
                        }
                    case Enumerations.RareItemType.WeaponDefender:
                        {
                            _item.BonusPowerType = Enumerations.RareItemType.SpecialSustain;
                            break;
                        }
                    case Enumerations.RareItemType.WeaponBlessed:
                        {
                            _item.BonusPowerType = Enumerations.RareItemType.SpecialAbility;
                            break;
                        }
                    case Enumerations.RareItemType.WeaponPlanarWeapon:
                        {
                            if (Program.Rng.DieRoll(7) == 1)
                            {
                                _item.BonusPowerType = Enumerations.RareItemType.SpecialAbility;
                            }
                            break;
                        }
                    case Enumerations.RareItemType.ArmourOfPermanence:
                        {
                            _item.BonusPowerType = Enumerations.RareItemType.SpecialPower;
                            break;
                        }
                    case Enumerations.RareItemType.ArmourOfYith:
                        {
                            _item.BonusPowerType = Enumerations.RareItemType.SpecialPower;
                            break;
                        }
                    case Enumerations.RareItemType.HatOfTheMagi:
                        {
                            _item.BonusPowerType = Enumerations.RareItemType.SpecialAbility;
                            break;
                        }
                    case Enumerations.RareItemType.CloakOfAman:
                        {
                            _item.BonusPowerType = Enumerations.RareItemType.SpecialPower;
                            break;
                        }
                }
                if (_item.BonusPowerType != 0 && string.IsNullOrEmpty(_item.RandartName))
                {
                    _item.BonusPowerSubType = ActivationPowerManager.GetRandom();
                }
                if (ePtr.Cost == 0)
                {
                    _item.IdentifyFlags.Set(Constants.IdentBroken);
                }
                if (ePtr.Flags3.IsSet(ItemFlag3.Cursed))
                {
                    _item.IdentifyFlags.Set(Constants.IdentCursed);
                }
                if (_item.IsCursed() || _item.IsBroken())
                {
                    if (ePtr.MaxToH != 0)
                    {
                        _item.BonusToHit -= Program.Rng.DieRoll(ePtr.MaxToH);
                    }
                    if (ePtr.MaxToD != 0)
                    {
                        _item.BonusDamage -= Program.Rng.DieRoll(ePtr.MaxToD);
                    }
                    if (ePtr.MaxToA != 0)
                    {
                        _item.BonusArmourClass -= Program.Rng.DieRoll(ePtr.MaxToA);
                    }
                    if (ePtr.MaxPval != 0)
                    {
                        _item.TypeSpecificValue -= Program.Rng.DieRoll(ePtr.MaxPval);
                    }
                }
                else
                {
                    if (ePtr.MaxToH != 0)
                    {
                        _item.BonusToHit += Program.Rng.DieRoll(ePtr.MaxToH);
                    }
                    if (ePtr.MaxToD != 0)
                    {
                        _item.BonusDamage += Program.Rng.DieRoll(ePtr.MaxToD);
                    }
                    if (ePtr.MaxToA != 0)
                    {
                        _item.BonusArmourClass += Program.Rng.DieRoll(ePtr.MaxToA);
                    }
                    if (ePtr.MaxPval != 0)
                    {
                        _item.TypeSpecificValue += Program.Rng.DieRoll(ePtr.MaxPval);
                    }
                }
                if (SaveGame.Instance.Level != null)
                {
                    SaveGame.Instance.Level.TreasureRating += ePtr.Rating;
                }
                return;
            }
            if (_item.ItemType != null)
            {
                ItemType kPtr = _item.ItemType;
                if (kPtr.Cost == 0)
                {
                    _item.IdentifyFlags.Set(Constants.IdentBroken);
                }
                if (kPtr.Flags3.IsSet(ItemFlag3.Cursed))
                {
                    _item.IdentifyFlags.Set(Constants.IdentCursed);
                }
            }
        }

        public void ApplyRandomResistance(int artifactBias, int specific)
        {
            if (specific == 0)
            {
                if (artifactBias == ArtifactBias.Acid)
                {
                    if (_item.RandartFlags2.IsClear(ItemFlag2.ResAcid))
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ResAcid);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                    if (Program.Rng.DieRoll(ArtifactBias.Luck) == 1 && _item.RandartFlags2.IsClear(ItemFlag2.ImAcid))
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ImAcid);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                }
                else if (artifactBias == ArtifactBias.Electricity)
                {
                    if (_item.RandartFlags2.IsClear(ItemFlag2.ResElec))
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ResElec);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                    if (_item.Category >= ItemCategory.Cloak &&
                        _item.Category <= ItemCategory.HardArmor &&
                        _item.RandartFlags3.IsClear(ItemFlag3.ShElec))
                    {
                        _item.RandartFlags2.Set(ItemFlag3.ShElec);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                    if (Program.Rng.DieRoll(ArtifactBias.Luck) == 1 && _item.RandartFlags2.IsClear(ItemFlag2.ImElec))
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ImElec);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                }
                else if (artifactBias == ArtifactBias.Fire)
                {
                    if (_item.RandartFlags2.IsClear(ItemFlag2.ResFire))
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ResFire);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                    if (_item.Category >= ItemCategory.Cloak &&
                        _item.Category <= ItemCategory.HardArmor &&
                        _item.RandartFlags3.IsClear(ItemFlag3.ShFire))
                    {
                        _item.RandartFlags2.Set(ItemFlag3.ShFire);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                    if (Program.Rng.DieRoll(ArtifactBias.Luck) == 1 && _item.RandartFlags2.IsClear(ItemFlag2.ImFire))
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ImFire);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                }
                else if (artifactBias == ArtifactBias.Cold)
                {
                    if (_item.RandartFlags2.IsClear(ItemFlag2.ResCold))
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ResCold);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                    if (Program.Rng.DieRoll(ArtifactBias.Luck) == 1 && _item.RandartFlags2.IsClear(ItemFlag2.ImCold))
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ImCold);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                }
                else if (artifactBias == ArtifactBias.Poison)
                {
                    if (_item.RandartFlags2.IsClear(ItemFlag2.ResPois))
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ResPois);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                }
                else if (artifactBias == ArtifactBias.Warrior)
                {
                    if (Program.Rng.DieRoll(3) != 1 && _item.RandartFlags2.IsClear(ItemFlag2.ResFear))
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ResFear);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                    if (Program.Rng.DieRoll(3) == 1 && _item.RandartFlags3.IsClear(ItemFlag3.NoMagic))
                    {
                        _item.RandartFlags3.Set(ItemFlag3.NoMagic);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                }
                else if (artifactBias == ArtifactBias.Necromantic)
                {
                    if (_item.RandartFlags2.IsClear(ItemFlag2.ResNether))
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ResNether);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                    if (_item.RandartFlags2.IsClear(ItemFlag2.ResPois))
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ResPois);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                    if (_item.RandartFlags2.IsClear(ItemFlag2.ResDark))
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ResDark);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                }
                else if (artifactBias == ArtifactBias.Chaos)
                {
                    if (_item.RandartFlags2.IsClear(ItemFlag2.ResChaos))
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ResChaos);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                    if (_item.RandartFlags2.IsClear(ItemFlag2.ResConf))
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ResConf);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                    if (_item.RandartFlags2.IsClear(ItemFlag2.ResDisen))
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ResDisen);
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            return;
                        }
                    }
                }
            }
            switch (specific != 0 ? specific : Program.Rng.DieRoll(41))
            {
                case 1:
                    if (Program.Rng.DieRoll(Constants.WeirdLuck) != 1)
                    {
                        ApplyRandomResistance(artifactBias, specific);
                    }
                    else
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ImAcid);
                        if (artifactBias == 0)
                        {
                            artifactBias = ArtifactBias.Acid;
                        }
                    }
                    break;

                case 2:
                    if (Program.Rng.DieRoll(Constants.WeirdLuck) != 1)
                    {
                        ApplyRandomResistance(artifactBias, specific);
                    }
                    else
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ImElec);
                        if (artifactBias == 0)
                        {
                            artifactBias = ArtifactBias.Electricity;
                        }
                    }
                    break;

                case 3:
                    if (Program.Rng.DieRoll(Constants.WeirdLuck) != 1)
                    {
                        ApplyRandomResistance(artifactBias, specific);
                    }
                    else
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ImCold);
                        if (artifactBias == 0)
                        {
                            artifactBias = ArtifactBias.Cold;
                        }
                    }
                    break;

                case 4:
                    if (Program.Rng.DieRoll(Constants.WeirdLuck) != 1)
                    {
                        ApplyRandomResistance(artifactBias, specific);
                    }
                    else
                    {
                        _item.RandartFlags2.Set(ItemFlag2.ImFire);
                        if (artifactBias == 0)
                        {
                            artifactBias = ArtifactBias.Fire;
                        }
                    }
                    break;

                case 5:
                case 6:
                case 13:
                    _item.RandartFlags2.Set(ItemFlag2.ResAcid);
                    if (artifactBias == 0)
                    {
                        artifactBias = ArtifactBias.Acid;
                    }
                    break;

                case 7:
                case 8:
                case 14:
                    _item.RandartFlags2.Set(ItemFlag2.ResElec);
                    if (artifactBias == 0)
                    {
                        artifactBias = ArtifactBias.Electricity;
                    }
                    break;

                case 9:
                case 10:
                case 15:
                    _item.RandartFlags2.Set(ItemFlag2.ResFire);
                    if (artifactBias == 0)
                    {
                        artifactBias = ArtifactBias.Fire;
                    }
                    break;

                case 11:
                case 12:
                case 16:
                    _item.RandartFlags2.Set(ItemFlag2.ResCold);
                    if (artifactBias == 0)
                    {
                        artifactBias = ArtifactBias.Cold;
                    }
                    break;

                case 17:
                case 18:
                    _item.RandartFlags2.Set(ItemFlag2.ResPois);
                    if (artifactBias == 0 && Program.Rng.DieRoll(4) != 1)
                    {
                        artifactBias = ArtifactBias.Poison;
                    }
                    else if (artifactBias == 0 && Program.Rng.DieRoll(2) == 1)
                    {
                        artifactBias = ArtifactBias.Necromantic;
                    }
                    else if (artifactBias == 0 && Program.Rng.DieRoll(2) == 1)
                    {
                        artifactBias = ArtifactBias.Rogue;
                    }
                    break;

                case 19:
                case 20:
                    _item.RandartFlags2.Set(ItemFlag2.ResFear);
                    if (artifactBias == 0 && Program.Rng.DieRoll(3) == 1)
                    {
                        artifactBias = ArtifactBias.Warrior;
                    }
                    break;

                case 21:
                    _item.RandartFlags2.Set(ItemFlag2.ResLight);
                    break;

                case 22:
                    _item.RandartFlags2.Set(ItemFlag2.ResDark);
                    break;

                case 23:
                case 24:
                    _item.RandartFlags2.Set(ItemFlag2.ResBlind);
                    break;

                case 25:
                case 26:
                    _item.RandartFlags2.Set(ItemFlag2.ResConf);
                    if (artifactBias == 0 && Program.Rng.DieRoll(6) == 1)
                    {
                        artifactBias = ArtifactBias.Chaos;
                    }
                    break;

                case 27:
                case 28:
                    _item.RandartFlags2.Set(ItemFlag2.ResSound);
                    break;

                case 29:
                case 30:
                    _item.RandartFlags2.Set(ItemFlag2.ResShards);
                    break;

                case 31:
                case 32:
                    _item.RandartFlags2.Set(ItemFlag2.ResNether);
                    if (artifactBias == 0 && Program.Rng.DieRoll(3) == 1)
                    {
                        artifactBias = ArtifactBias.Necromantic;
                    }
                    break;

                case 33:
                case 34:
                    _item.RandartFlags2.Set(ItemFlag2.ResNexus);
                    break;

                case 35:
                case 36:
                    _item.RandartFlags2.Set(ItemFlag2.ResChaos);
                    if (artifactBias == 0 && Program.Rng.DieRoll(2) == 1)
                    {
                        artifactBias = ArtifactBias.Chaos;
                    }
                    break;

                case 37:
                case 38:
                    _item.RandartFlags2.Set(ItemFlag2.ResDisen);
                    break;

                case 39:
                    if (_item.Category >= ItemCategory.Cloak &&
                        _item.Category <= ItemCategory.HardArmor)
                    {
                        _item.RandartFlags3.Set(ItemFlag3.ShElec);
                    }
                    else
                    {
                        ApplyRandomResistance(artifactBias, specific);
                    }
                    if (artifactBias == 0)
                    {
                        artifactBias = ArtifactBias.Electricity;
                    }
                    break;

                case 40:
                    if (_item.Category >= ItemCategory.Cloak &&
                        _item.Category <= ItemCategory.HardArmor)
                    {
                        _item.RandartFlags3.Set(ItemFlag3.ShFire);
                    }
                    else
                    {
                        ApplyRandomResistance(artifactBias, specific);
                    }
                    if (artifactBias == 0)
                    {
                        artifactBias = ArtifactBias.Fire;
                    }
                    break;

                case 41:
                    if (_item.Category == ItemCategory.Shield ||
                        _item.Category == ItemCategory.Cloak || _item.Category == ItemCategory.Helm ||
                        _item.Category == ItemCategory.HardArmor)
                    {
                        _item.RandartFlags2.Set(ItemFlag2.Reflect);
                    }
                    else
                    {
                        ApplyRandomResistance(artifactBias, specific);
                    }
                    break;
            }
        }

        public bool CreateRandart(bool fromScroll)
        {
            bool hasPval = false;
            int powers = Program.Rng.DieRoll(5) + 1;
            int maxType = _item.Category < ItemCategory.Boots ? 7 : 5;
            bool aCursed = false;
            int warriorArtifactBias = 0;
            int artifactBias = 0;
            if (fromScroll && Program.Rng.DieRoll(4) == 1)
            {
                switch (SaveGame.Instance.Player.ProfessionIndex)
                {
                    case CharacterClass.Warrior:
                    case CharacterClass.ChosenOne:
                        artifactBias = ArtifactBias.Warrior;
                        break;

                    case CharacterClass.Mage:
                    case CharacterClass.HighMage:
                    case CharacterClass.Cultist:
                    case CharacterClass.Channeler:
                        artifactBias = ArtifactBias.Mage;
                        break;

                    case CharacterClass.Priest:
                    case CharacterClass.Druid:
                        artifactBias = ArtifactBias.Priestly;
                        break;

                    case CharacterClass.Rogue:
                        artifactBias = ArtifactBias.Rogue;
                        warriorArtifactBias = 25;
                        break;

                    case CharacterClass.Ranger:
                        artifactBias = ArtifactBias.Ranger;
                        warriorArtifactBias = 30;
                        break;

                    case CharacterClass.Paladin:
                        artifactBias = ArtifactBias.Priestly;
                        warriorArtifactBias = 40;
                        break;

                    case CharacterClass.WarriorMage:
                        artifactBias = ArtifactBias.Mage;
                        warriorArtifactBias = 40;
                        break;

                    case CharacterClass.Fanatic:
                        artifactBias = ArtifactBias.Chaos;
                        warriorArtifactBias = 40;
                        break;

                    case CharacterClass.Monk:
                    case CharacterClass.Mystic:
                        artifactBias = ArtifactBias.Priestly;
                        break;

                    case CharacterClass.Mindcrafter:
                        if (Program.Rng.DieRoll(5) > 2)
                        {
                            artifactBias = ArtifactBias.Priestly;
                        }
                        break;
                }
            }
            if (Program.Rng.DieRoll(100) <= warriorArtifactBias && fromScroll)
            {
                artifactBias = ArtifactBias.Warrior;
            }
            string newName;
            if (!fromScroll && Program.Rng.DieRoll(Constants.ArifactCurseChance) == 1)
            {
                aCursed = true;
            }
            while (Program.Rng.DieRoll(powers) == 1 || Program.Rng.DieRoll(7) == 1 || Program.Rng.DieRoll(10) == 1)
            {
                powers++;
            }
            if (!aCursed && Program.Rng.DieRoll(Constants.WeirdLuck) == 1)
            {
                powers *= 2;
            }
            if (aCursed)
            {
                powers /= 2;
            }
            while (powers-- != 0)
            {
                switch (Program.Rng.DieRoll(maxType))
                {
                    case 1:
                    case 2:
                        ApplyRandomBonuses(artifactBias);
                        hasPval = true;
                        break;

                    case 3:
                    case 4:
                        ApplyRandomResistance(artifactBias, 0);
                        break;

                    case 5:
                        ApplyRandomMiscPower(artifactBias);
                        break;

                    case 6:
                    case 7:
                        ApplyRandomSlaying(artifactBias);
                        break;

                    default:
                        powers++;
                        break;
                }
            }
            if (hasPval)
            {
                if (_item.RandartFlags1.IsSet(ItemFlag1.Blows))
                {
                    _item.TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
                }
                else
                {
                    do
                    {
                        _item.TypeSpecificValue++;
                    } while (_item.TypeSpecificValue < Program.Rng.DieRoll(5) ||
                             Program.Rng.DieRoll(_item.TypeSpecificValue) == 1);
                }
                if (_item.TypeSpecificValue > 4 && Program.Rng.DieRoll(Constants.WeirdLuck) != 1)
                {
                    _item.TypeSpecificValue = 4;
                }
            }
            if (_item.Category >= ItemCategory.Boots)
            {
                _item.BonusArmourClass +=
                    Program.Rng.DieRoll(_item.BonusArmourClass > 19 ? 1 : 20 - _item.BonusArmourClass);
            }
            else
            {
                _item.BonusToHit += Program.Rng.DieRoll(_item.BonusToHit > 19 ? 1 : 20 - _item.BonusToHit);
                _item.BonusDamage += Program.Rng.DieRoll(_item.BonusDamage > 19 ? 1 : 20 - _item.BonusDamage);
            }
            _item.RandartFlags3.Set(ItemFlag3.IgnoreAcid | ItemFlag3.IgnoreElec | ItemFlag3.IgnoreFire |
                                    ItemFlag3.IgnoreCold);
            int totalFlags = _item.FlagBasedCost(_item.TypeSpecificValue);
            if (aCursed)
            {
                CurseRandart();
            }
            if (!aCursed && Program.Rng.DieRoll(_item.Category >= ItemCategory.Boots
                    ? Constants.ActivationChance * 2
                    : Constants.ActivationChance) == 1)
            {
                _item.BonusPowerSubType = null;
                GiveActivationPower(artifactBias);
            }
            if (fromScroll)
            {
                _item.IdentifyFully();
                _item.IdentifyFlags.Set(Constants.IdentStoreb);
                if (!Gui.GetString("What do you want to call the artifact? ", out string dummyName, "(a DIY artifact)",
                    80))
                {
                    newName = "(a DIY artifact)";
                }
                else
                {
                    newName = "called '" + dummyName + "'";
                }
                _item.BecomeFlavourAware();
                _item.BecomeKnown();
                _item.IdentifyFlags.Set(Constants.IdentMental);
            }
            else
            {
                newName = GetTableName();
            }
            _item.RandartName = newName;
            return true;
        }

        public void GetFixedArtifactResistances()
        {
            bool giveResistance = false, givePower = false;
            if (_item.FixedArtifactIndex == FixedArtifactId.HelmTerrorMask)
            {
                if (SaveGame.Instance.Player.ProfessionIndex == CharacterClass.Warrior)
                {
                    givePower = true;
                    giveResistance = true;
                }
                else
                {
                    _item.RandartFlags3.Set(ItemFlag3.Cursed | ItemFlag3.HeavyCurse | ItemFlag3.Aggravate |
                                            ItemFlag3.DreadCurse);
                    _item.IdentifyFlags.Set(Constants.IdentCursed);
                    return;
                }
            }
            switch (_item.FixedArtifactIndex)
            {
                case FixedArtifactId.ArmourOfTheOrcs:
                case FixedArtifactId.ChainMailHeartguard:
                case FixedArtifactId.ArmourOfTheOgreLords:
                case FixedArtifactId.ArmourOfTheKoboldChief:
                case FixedArtifactId.ArmourOfSerpents:
                case FixedArtifactId.ShieldRawhide:
                case FixedArtifactId.ShieldOfStability:
                case FixedArtifactId.CapOfTheMindcrafter:
                case FixedArtifactId.ShadowCloakOfNyogtha:
                case FixedArtifactId.BootsOfTheBlackReaver:
                case FixedArtifactId.ShieldVitriol:
                case FixedArtifactId.DaggerOfHope:
                case FixedArtifactId.DaggerOfCharity:
                case FixedArtifactId.DaggerOfFaith:
                case FixedArtifactId.SmallSwordSting:
                case FixedArtifactId.HammerJustice:
                case FixedArtifactId.ScaleMailWyvernscale:
                    {
                        giveResistance = true;
                    }
                    break;

                case FixedArtifactId.MainGaucheOfDefence:
                case FixedArtifactId.SwordBrightblade:
                case FixedArtifactId.SwordBlackIce:
                case FixedArtifactId.SwordOfEverflame:
                case FixedArtifactId.SwordFiretongue:
                case FixedArtifactId.SwordDragonSlayer:
                case FixedArtifactId.ScimitarSoulsword:
                case FixedArtifactId.BowOfSerpents:
                case FixedArtifactId.CrossbowOfDeath:
                    {
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            giveResistance = true;
                        }
                        else
                        {
                            givePower = true;
                        }
                    }
                    break;

                case FixedArtifactId.RingOfElementalPowerIce:
                case FixedArtifactId.RingOfElementalPowerStorm:
                case FixedArtifactId.CrownOfMisery:
                case FixedArtifactId.CestiOfCombat:
                case FixedArtifactId.CloakOfTheSwashbuckler:
                case FixedArtifactId.TridentOfTheGnorri:
                case FixedArtifactId.QuarterstaffOfAtal:
                    {
                        givePower = true;
                    }
                    break;

                case FixedArtifactId.RingOfSet:
                case FixedArtifactId.CrownOfTheSun:
                case FixedArtifactId.HammerMjolnir:
                    {
                        givePower = true;
                        giveResistance = true;
                    }
                    break;
            }
            if (givePower)
            {
                _item.BonusPowerType = Enumerations.RareItemType.SpecialAbility;
                if (_item.BonusPowerType != 0)
                {
                    _item.BonusPowerSubType = ActivationPowerManager.GetRandom();
                }
            }
            int artifactBias = 0;
            if (giveResistance)
            {
                ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(22) + 16);
            }
        }

        public bool MakeObject(bool good, bool great)
        {
            int prob = good ? 10 : 1000;
            int baselevel = good ? SaveGame.Instance.Level.ObjectLevel + 10 : SaveGame.Instance.Level.ObjectLevel;
            if (Program.Rng.RandomLessThan(prob) != 0 || !MakeFixedArtifact())
            {
                if (good)
                {
                    PrepareAllocationTable(ItemType.KindIsGood);
                }
                ItemType kIdx = ItemType.RandomItemType(baselevel);
                if (good)
                {
                    PrepareAllocationTable(null);
                }
                if (kIdx == null)
                {
                    return false;
                }
                _item.AssignItemType(kIdx);
            }
            ApplyMagic(SaveGame.Instance.Level.ObjectLevel, true, good, great);
            switch (_item.Category)
            {
                case ItemCategory.Spike:
                case ItemCategory.Shot:
                case ItemCategory.Arrow:
                case ItemCategory.Bolt:
                    {
                        _item.Count = Program.Rng.DiceRoll(6, 7);
                        break;
                    }
            }
            if (!_item.IsCursed() && !_item.IsBroken() &&
                _item.ItemType.Level > SaveGame.Instance.Difficulty)
            {
                if (SaveGame.Instance.Level != null)
                {
                    SaveGame.Instance.Level.TreasureRating +=
                        _item.ItemType.Level - SaveGame.Instance.Difficulty;
                }
            }
            return true;
        }

        private void ApplyDragonscaleResistance()
        {
            do
            {
                int artifactBias = 0;
                if (Program.Rng.DieRoll(4) == 1)
                {
                    ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(14) + 4);
                }
                else
                {
                    ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(22) + 16);
                }
            } while (Program.Rng.DieRoll(2) == 1);
        }

        private bool ApplyFixedArtifact()
        {
            if (_item.Count != 1)
            {
                return false;
            }
            foreach (System.Collections.Generic.KeyValuePair<FixedArtifactId, FixedArtifact> pair in Profile.Instance.FixedArtifacts)
            {
                FixedArtifact aPtr = pair.Value;
                if (aPtr.HasOwnType)
                {
                    continue;
                }
                if (aPtr.CurNum != 0)
                {
                    continue;
                }
                if (aPtr.Tval != _item.Category)
                {
                    continue;
                }
                if (aPtr.Sval != _item.ItemSubCategory)
                {
                    continue;
                }
                if (aPtr.Level > SaveGame.Instance.Difficulty)
                {
                    int d = (aPtr.Level - SaveGame.Instance.Difficulty) * 2;
                    if (Program.Rng.RandomLessThan(d) != 0)
                    {
                        continue;
                    }
                }
                if (Program.Rng.RandomLessThan(aPtr.Rarity) != 0)
                {
                    continue;
                }
                _item.FixedArtifactIndex = pair.Key;
                GetFixedArtifactResistances();
                return true;
            }
            return false;
        }

        private void ApplyMagicToArmour(int level, int power)
        {
            int toac1 = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            int toac2 = GetBonusValue(10, level);
            int artifactBias = 0;
            if (power > 0)
            {
                _item.BonusArmourClass += toac1;
                if (power > 1)
                {
                    _item.BonusArmourClass += toac2;
                }
            }
            else if (power < 0)
            {
                _item.BonusArmourClass -= toac1;
                if (power < -1)
                {
                    _item.BonusArmourClass -= toac2;
                }
                if (_item.BonusArmourClass < 0)
                {
                    _item.IdentifyFlags.Set(Constants.IdentCursed);
                }
            }
            switch (_item.Category)
            {
                case ItemCategory.DragArmor:
                    {
                        if (SaveGame.Instance.Level != null)
                        {
                            SaveGame.Instance.Level.TreasureRating += 30;
                        }
                        break;
                    }
                case ItemCategory.HardArmor:
                case ItemCategory.SoftArmor:
                    {
                        if (power > 1)
                        {
                            if (_item.Category == ItemCategory.SoftArmor &&
                                _item.ItemSubCategory == SoftArmourType.SvRobe && Program.Rng.RandomLessThan(100) < 10)
                            {
                                _item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfPermanence;
                                break;
                            }
                            switch (Program.Rng.DieRoll(21))
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistAcid;
                                        break;
                                    }
                                case 5:
                                case 6:
                                case 7:
                                case 8:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistLightning;
                                        break;
                                    }
                                case 9:
                                case 10:
                                case 11:
                                case 12:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistFire;
                                        break;
                                    }
                                case 13:
                                case 14:
                                case 15:
                                case 16:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistCold;
                                        break;
                                    }
                                case 17:
                                case 18:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistance;
                                        if (Program.Rng.DieRoll(4) == 1)
                                        {
                                            _item.RandartFlags2.Set(ItemFlag2.ResPois);
                                        }
                                        ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(22) + 16);
                                        break;
                                    }
                                case 20:
                                case 21:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfYith;
                                        break;
                                    }
                                default:
                                    {
                                        CreateRandart(false);
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case ItemCategory.Shield:
                    {
                        if (_item.ItemSubCategory == ShieldType.SvDragonShield)
                        {
                            if (SaveGame.Instance.Level != null)
                            {
                                SaveGame.Instance.Level.TreasureRating += 5;
                            }
                            ApplyDragonscaleResistance();
                        }
                        else
                        {
                            if (power > 1)
                            {
                                switch (Program.Rng.DieRoll(23))
                                {
                                    case 1:
                                    case 11:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistAcid;
                                            break;
                                        }
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 12:
                                    case 13:
                                    case 14:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistLightning;
                                            break;
                                        }
                                    case 5:
                                    case 6:
                                    case 15:
                                    case 16:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistFire;
                                            break;
                                        }
                                    case 7:
                                    case 8:
                                    case 9:
                                    case 17:
                                    case 18:
                                    case 19:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistCold;
                                            break;
                                        }
                                    case 10:
                                    case 20:
                                        {
                                            ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(34) + 4);
                                            if (Program.Rng.DieRoll(4) == 1)
                                            {
                                                _item.RandartFlags2.Set(ItemFlag2.ResPois);
                                            }
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistance;
                                            break;
                                        }
                                    case 21:
                                    case 22:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfReflection;
                                            break;
                                        }
                                    default:
                                        {
                                            CreateRandart(false);
                                            break;
                                        }
                                }
                            }
                        }
                        break;
                    }
                case ItemCategory.Gloves:
                    {
                        if (power > 1)
                        {
                            if (Program.Rng.DieRoll(20) == 1)
                            {
                                CreateRandart(false);
                            }
                            else
                            {
                                switch (Program.Rng.DieRoll(10))
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfFreeAction;
                                            break;
                                        }
                                    case 5:
                                    case 6:
                                    case 7:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfSlaying;
                                            break;
                                        }
                                    case 8:
                                    case 9:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfAgility;
                                            break;
                                        }
                                    case 10:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfPower;
                                            ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(22) + 16);
                                            break;
                                        }
                                }
                            }
                        }
                        else if (power < -1)
                        {
                            switch (Program.Rng.DieRoll(2))
                            {
                                case 1:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfClumsiness;
                                        break;
                                    }
                                default:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfWeakness;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case ItemCategory.Boots:
                    {
                        if (power > 1)
                        {
                            if (Program.Rng.DieRoll(20) == 1)
                            {
                                CreateRandart(false);
                            }
                            else
                            {
                                switch (Program.Rng.DieRoll(24))
                                {
                                    case 1:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfSpeed;
                                            break;
                                        }
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfFreeAction;
                                            break;
                                        }
                                    case 6:
                                    case 7:
                                    case 8:
                                    case 9:
                                    case 10:
                                    case 11:
                                    case 12:
                                    case 13:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfStealth;
                                            break;
                                        }
                                    default:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.BootsWinged;
                                            if (Program.Rng.DieRoll(2) == 1)
                                            {
                                                ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(22) + 16);
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else if (power < -1)
                        {
                            switch (Program.Rng.DieRoll(3))
                            {
                                case 1:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfNoise;
                                        break;
                                    }
                                case 2:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfSlowness;
                                        break;
                                    }
                                case 3:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfAnnoyance;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case ItemCategory.Crown:
                    {
                        if (power > 1)
                        {
                            if (Program.Rng.DieRoll(20) == 1)
                            {
                                CreateRandart(false);
                            }
                            else
                            {
                                switch (Program.Rng.DieRoll(8))
                                {
                                    case 1:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfTheMagi;
                                            ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(22) + 16);
                                            break;
                                        }
                                    case 2:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfMight;
                                            ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(22) + 16);
                                            break;
                                        }
                                    case 3:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfTelepathy;
                                            break;
                                        }
                                    case 4:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfRegeneration;
                                            break;
                                        }
                                    case 5:
                                    case 6:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfLordliness;
                                            ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(22) + 16);
                                            break;
                                        }
                                    default:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfSeeing;
                                            if (Program.Rng.DieRoll(3) == 1)
                                            {
                                                _item.RandartFlags3.Set(ItemFlag3.Telepathy);
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else if (power < -1)
                        {
                            switch (Program.Rng.DieRoll(7))
                            {
                                case 1:
                                case 2:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfStupidity;
                                        break;
                                    }
                                case 3:
                                case 4:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfNaivety;
                                        break;
                                    }
                                case 5:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfUgliness;
                                        break;
                                    }
                                case 6:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfSickliness;
                                        break;
                                    }
                                case 7:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfTeleportation;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case ItemCategory.Helm:
                    {
                        if (_item.ItemSubCategory == HelmType.SvDragonHelm)
                        {
                            if (SaveGame.Instance.Level != null)
                            {
                                SaveGame.Instance.Level.TreasureRating += 5;
                            }
                            ApplyDragonscaleResistance();
                        }
                        else
                        {
                            if (power > 1)
                            {
                                if (Program.Rng.DieRoll(20) == 1)
                                {
                                    CreateRandart(false);
                                }
                                else
                                {
                                    switch (Program.Rng.DieRoll(14))
                                    {
                                        case 1:
                                        case 2:
                                            {
                                                _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfIntelligence;
                                                break;
                                            }
                                        case 3:
                                        case 4:
                                            {
                                                _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfWisdom;
                                                break;
                                            }
                                        case 5:
                                        case 6:
                                            {
                                                _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfBeauty;
                                                break;
                                            }
                                        case 7:
                                        case 8:
                                            {
                                                _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfSeeing;
                                                if (Program.Rng.DieRoll(7) == 1)
                                                {
                                                    _item.RandartFlags3.Set(ItemFlag3.Telepathy);
                                                }
                                                break;
                                            }
                                        case 9:
                                        case 10:
                                            {
                                                _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfLight;
                                                break;
                                            }
                                        default:
                                            {
                                                _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfInfravision;
                                                break;
                                            }
                                    }
                                }
                            }
                            else if (power < -1)
                            {
                                switch (Program.Rng.DieRoll(7))
                                {
                                    case 1:
                                    case 2:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfStupidity;
                                            break;
                                        }
                                    case 3:
                                    case 4:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfNaivety;
                                            break;
                                        }
                                    case 5:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfUgliness;
                                            break;
                                        }
                                    case 6:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfSickliness;
                                            break;
                                        }
                                    case 7:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.HatOfTeleportation;
                                            break;
                                        }
                                }
                            }
                        }
                        break;
                    }
                case ItemCategory.Cloak:
                    {
                        if (_item.ItemSubCategory == CloakType.SvElvenCloak)
                        {
                            _item.TypeSpecificValue = Program.Rng.DieRoll(4);
                        }
                        if (power > 1)
                        {
                            if (Program.Rng.DieRoll(20) == 1)
                            {
                                CreateRandart(false);
                            }
                            else
                            {
                                switch (Program.Rng.DieRoll(19))
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                    case 6:
                                    case 7:
                                    case 8:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfProtection;
                                            break;
                                        }
                                    case 9:
                                    case 10:
                                    case 11:
                                    case 12:
                                    case 13:
                                    case 14:
                                    case 15:
                                    case 16:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfStealth;
                                            break;
                                        }
                                    case 17:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfAman;
                                            break;
                                        }
                                    case 18:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfElectricity;
                                            break;
                                        }
                                    default:
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfImmolation;
                                            break;
                                        }
                                }
                            }
                        }
                        else if (power < -1)
                        {
                            switch (Program.Rng.DieRoll(3))
                            {
                                case 1:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfIrritation;
                                        break;
                                    }
                                case 2:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfVulnerability;
                                        break;
                                    }
                                case 3:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfEnveloping;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }
        }

        private void ApplyMagicToJewellery(int level, int power)
        {
            int artifactBias = 0;
            switch (_item.Category)
            {
                case ItemCategory.Ring:
                    {
                        switch (_item.ItemSubCategory)
                        {
                            case RingType.Attacks:
                                {
                                    _item.TypeSpecificValue = GetBonusValue(3, level);
                                    if (_item.TypeSpecificValue < 1)
                                    {
                                        _item.TypeSpecificValue = 1;
                                    }
                                    if (power < 0)
                                    {
                                        _item.IdentifyFlags.Set(Constants.IdentBroken);
                                        _item.IdentifyFlags.Set(Constants.IdentCursed);
                                        _item.TypeSpecificValue = 0 - _item.TypeSpecificValue;
                                    }
                                    break;
                                }
                            case RingType.Str:
                            case RingType.Con:
                            case RingType.Dex:
                            case RingType.Int:
                                {
                                    _item.TypeSpecificValue = 1 + GetBonusValue(5, level);
                                    if (power < 0)
                                    {
                                        _item.IdentifyFlags.Set(Constants.IdentBroken);
                                        _item.IdentifyFlags.Set(Constants.IdentCursed);
                                        _item.TypeSpecificValue = 0 - _item.TypeSpecificValue;
                                    }
                                    break;
                                }
                            case RingType.Speed:
                                {
                                    _item.TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
                                    while (Program.Rng.RandomLessThan(100) < 50)
                                    {
                                        _item.TypeSpecificValue++;
                                    }
                                    if (power < 0)
                                    {
                                        _item.IdentifyFlags.Set(Constants.IdentBroken);
                                        _item.IdentifyFlags.Set(Constants.IdentCursed);
                                        _item.TypeSpecificValue = 0 - _item.TypeSpecificValue;
                                        break;
                                    }
                                    if (SaveGame.Instance.Level != null)
                                    {
                                        SaveGame.Instance.Level.TreasureRating += 25;
                                    }
                                    break;
                                }
                            case RingType.Lordly:
                                {
                                    do
                                    {
                                        ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(20) + 18);
                                    } while (Program.Rng.DieRoll(4) == 1);
                                    _item.BonusArmourClass = 10 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
                                    if (SaveGame.Instance.Level != null)
                                    {
                                        SaveGame.Instance.Level.TreasureRating += 5;
                                    }
                                }
                                break;

                            case RingType.Searching:
                                {
                                    _item.TypeSpecificValue = 1 + GetBonusValue(5, level);
                                    if (power < 0)
                                    {
                                        _item.IdentifyFlags.Set(Constants.IdentBroken);
                                        _item.IdentifyFlags.Set(Constants.IdentCursed);
                                        _item.TypeSpecificValue = 0 - _item.TypeSpecificValue;
                                    }
                                    break;
                                }
                            case RingType.Flames:
                            case RingType.Acid:
                            case RingType.Ice:
                                {
                                    _item.BonusArmourClass = 5 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
                                    break;
                                }
                            case RingType.Weakness:
                            case RingType.Stupidity:
                                {
                                    _item.IdentifyFlags.Set(Constants.IdentBroken);
                                    _item.IdentifyFlags.Set(Constants.IdentCursed);
                                    _item.TypeSpecificValue = 0 - (1 + GetBonusValue(5, level));
                                    break;
                                }
                            case RingType.Woe:
                                {
                                    _item.IdentifyFlags.Set(Constants.IdentBroken);
                                    _item.IdentifyFlags.Set(Constants.IdentCursed);
                                    _item.BonusArmourClass = 0 - (5 + GetBonusValue(10, level));
                                    _item.TypeSpecificValue = 0 - (1 + GetBonusValue(5, level));
                                    break;
                                }
                            case RingType.Damage:
                                {
                                    _item.BonusDamage = 5 + Program.Rng.DieRoll(8) + GetBonusValue(10, level);
                                    if (power < 0)
                                    {
                                        _item.IdentifyFlags.Set(Constants.IdentBroken);
                                        _item.IdentifyFlags.Set(Constants.IdentCursed);
                                        _item.BonusDamage = 0 - _item.BonusDamage;
                                    }
                                    break;
                                }
                            case RingType.Accuracy:
                                {
                                    _item.BonusToHit = 5 + Program.Rng.DieRoll(8) + GetBonusValue(10, level);
                                    if (power < 0)
                                    {
                                        _item.IdentifyFlags.Set(Constants.IdentBroken);
                                        _item.IdentifyFlags.Set(Constants.IdentCursed);
                                        _item.BonusToHit = 0 - _item.BonusToHit;
                                    }
                                    break;
                                }
                            case RingType.Protection:
                                {
                                    _item.BonusArmourClass = 5 + Program.Rng.DieRoll(8) + GetBonusValue(10, level);
                                    if (power < 0)
                                    {
                                        _item.IdentifyFlags.Set(Constants.IdentBroken);
                                        _item.IdentifyFlags.Set(Constants.IdentCursed);
                                        _item.BonusArmourClass = 0 - _item.BonusArmourClass;
                                    }
                                    break;
                                }
                            case RingType.Slaying:
                                {
                                    _item.BonusDamage = Program.Rng.DieRoll(7) + GetBonusValue(10, level);
                                    _item.BonusToHit = Program.Rng.DieRoll(7) + GetBonusValue(10, level);
                                    if (power < 0)
                                    {
                                        _item.IdentifyFlags.Set(Constants.IdentBroken);
                                        _item.IdentifyFlags.Set(Constants.IdentCursed);
                                        _item.BonusToHit = 0 - _item.BonusToHit;
                                        _item.BonusDamage = 0 - _item.BonusDamage;
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case ItemCategory.Amulet:
                    {
                        switch (_item.ItemSubCategory)
                        {
                            case AmuletType.Wisdom:
                            case AmuletType.Charisma:
                                {
                                    _item.TypeSpecificValue = 1 + GetBonusValue(5, level);
                                    if (power < 0)
                                    {
                                        _item.IdentifyFlags.Set(Constants.IdentBroken);
                                        _item.IdentifyFlags.Set(Constants.IdentCursed);
                                        _item.TypeSpecificValue = 0 - _item.TypeSpecificValue;
                                    }
                                    break;
                                }
                            case AmuletType.NoMagic:
                            case AmuletType.NoTele:
                                {
                                    if (power < 0)
                                    {
                                        _item.IdentifyFlags.Set(Constants.IdentCursed);
                                    }
                                    break;
                                }
                            case AmuletType.Resistance:
                                {
                                    if (Program.Rng.DieRoll(3) == 1)
                                    {
                                        ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(34) + 4);
                                    }
                                    if (Program.Rng.DieRoll(5) == 1)
                                    {
                                        _item.RandartFlags2.Set(ItemFlag2.ResPois);
                                    }
                                }
                                break;

                            case AmuletType.Searching:
                                {
                                    _item.TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
                                    if (power < 0)
                                    {
                                        _item.IdentifyFlags.Set(Constants.IdentBroken);
                                        _item.IdentifyFlags.Set(Constants.IdentCursed);
                                        _item.TypeSpecificValue = 0 - _item.TypeSpecificValue;
                                    }
                                    break;
                                }
                            case AmuletType.TheMagi:
                                {
                                    _item.TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
                                    _item.BonusArmourClass = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
                                    if (Program.Rng.DieRoll(3) == 1)
                                    {
                                        _item.RandartFlags3.Set(ItemFlag3.SlowDigest);
                                    }
                                    if (SaveGame.Instance.Level != null)
                                    {
                                        SaveGame.Instance.Level.TreasureRating += 25;
                                    }
                                    break;
                                }
                            case AmuletType.Doom:
                                {
                                    _item.IdentifyFlags.Set(Constants.IdentBroken);
                                    _item.IdentifyFlags.Set(Constants.IdentCursed);
                                    _item.TypeSpecificValue = 0 - (Program.Rng.DieRoll(5) + GetBonusValue(5, level));
                                    _item.BonusArmourClass = 0 - (Program.Rng.DieRoll(5) + GetBonusValue(5, level));
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        private void ApplyMagicToLightSource(int power)
        {
            if (_item.ItemSubCategory == LightType.Torch)
            {
                if (_item.TypeSpecificValue != 0)
                {
                    _item.TypeSpecificValue = Program.Rng.DieRoll(_item.TypeSpecificValue);
                }
                return;
            }
            if (_item.ItemSubCategory == LightType.Lantern)
            {
                if (_item.TypeSpecificValue != 0)
                {
                    _item.TypeSpecificValue = Program.Rng.DieRoll(_item.TypeSpecificValue);
                }
                return;
            }
            if (power < 0) // Cursed
            {
                switch (Program.Rng.DieRoll(2)) // Cursed
                {
                    case 1:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfIrritation;
                            _item.IdentifyFlags.Set(Constants.IdentBroken);
                            _item.IdentifyFlags.Set(Constants.IdentCursed);
                            break;
                        }
                    case 2:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfInstability;
                            _item.IdentifyFlags.Set(Constants.IdentBroken);
                            _item.IdentifyFlags.Set(Constants.IdentCursed);
                            break;
                        }
                }
            }
            else if (power == 1) // Good
            {
                switch (Program.Rng.DieRoll(30))
                {
                    case 1:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfFlame;
                            break;
                        }
                    case 2:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfFrost;
                            break;
                        }
                    case 3:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfAcid;
                            break;
                        }
                    case 4:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfLightning;
                            break;
                        }
                    case 5:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfLight;
                            break;
                        }
                    case 6:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfDarkness;
                            break;
                        }
                    case 7:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfLife;
                            break;
                        }
                    case 8:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfSight;
                            break;
                        }
                    case 9:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfCourage;
                            break;
                        }
                    case 10:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfCourage;
                            break;
                        }
                    case 11:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfVenom;
                            break;
                        }
                    case 12:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfClarity;
                            break;
                        }
                    case 13:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfSound;
                            break;
                        }
                    case 14:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfChaos;
                            break;
                        }
                    case 15:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfShards;
                            break;
                        }
                    case 16:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfUnlife;
                            break;
                        }
                    case 17:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfStability;
                            break;
                        }
                    case 18:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfMagic;
                            break;
                        }
                    case 19:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfFreedom;
                            break;
                        }
                    case 20:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfStrength;
                            break;
                        }
                    case 21:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfIntelligence;
                            break;
                        }
                    case 22:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfWisdom;
                            break;
                        }
                    case 23:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfDexterity;
                            break;
                        }
                    case 24:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfConstitution;
                            break;
                        }
                    case 25:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfCharisma;
                            break;
                        }
                    case 26:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfLightness;
                            break;
                        }
                    case 27:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfInsight;
                            break;
                        }
                    case 28:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfTheMind;
                            break;
                        }
                    case 29:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfSustenance;
                            break;
                        }
                    case 30:
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfHealth;
                            break;
                        }
                }
            }
            else if (power == 2) // Great
            {
                _item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfPower;
                for (int i = 0; i < 3; i++)
                {
                    switch (Program.Rng.DieRoll(30))
                    {
                        case 1:
                        case 2:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.ResDark);
                                break;
                            }
                        case 3:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.ResLight);
                                break;
                            }
                        case 4:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.ResBlind);
                                break;
                            }
                        case 5:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.ResFear);
                                break;
                            }
                        case 6:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.ResAcid);
                                break;
                            }
                        case 7:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.ResElec);
                                break;
                            }
                        case 8:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.ResFire);
                                break;
                            }
                        case 9:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.ResCold);
                                break;
                            }
                        case 10:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.ResPois);
                                break;
                            }
                        case 11:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.ResConf);
                                break;
                            }
                        case 12:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.ResSound);
                                break;
                            }
                        case 13:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.ResShards);
                                break;
                            }
                        case 14:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.ResNether);
                                break;
                            }
                        case 15:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.ResNexus);
                                break;
                            }
                        case 16:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.ResChaos);
                                break;
                            }
                        case 17:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.ResDisen);
                                break;
                            }
                        case 18:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.FreeAct);
                                break;
                            }
                        case 19:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.HoldLife);
                                break;
                            }
                        case 20:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.SustStr);
                                break;
                            }
                        case 21:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.SustInt);
                                break;
                            }
                        case 22:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.SustWis);
                                break;
                            }
                        case 23:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.SustDex);
                                break;
                            }
                        case 24:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.SustCon);
                                break;
                            }
                        case 25:
                            {
                                _item.RandartFlags2.Set(ItemFlag2.SustCha);
                                break;
                            }
                        case 26:
                            {
                                _item.RandartFlags3.Set(ItemFlag3.Feather);
                                break;
                            }
                        case 27:
                            {
                                _item.RandartFlags3.Set(ItemFlag3.SeeInvis);
                                break;
                            }
                        case 28:
                            {
                                _item.RandartFlags3.Set(ItemFlag3.Telepathy);
                                break;
                            }
                        case 29:
                            {
                                _item.RandartFlags3.Set(ItemFlag3.SlowDigest);
                                break;
                            }
                        case 30:
                            {
                                _item.RandartFlags3.Set(ItemFlag3.Regen);
                                break;
                            }
                    }
                }
            }
        }

        private void ApplyMagicToMiscItem()
        {
            switch (_item.Category)
            {
                case ItemCategory.Wand:
                    {
                        ChargeWand();
                        break;
                    }
                case ItemCategory.Staff:
                    {
                        ChargeStaff();
                        break;
                    }
                case ItemCategory.Chest:
                    {
                        if (_item.ItemType.Level <= 0)
                        {
                            break;
                        }
                        _item.TypeSpecificValue =
                            Program.Rng.DieRoll(_item.ItemType.Level);
                        if (_item.TypeSpecificValue > 55)
                        {
                            _item.TypeSpecificValue = (short)(55 + Program.Rng.RandomLessThan(5));
                        }
                        break;
                    }
            }
        }

        private void ApplyMagicToWeapon(int level, int power)
        {
            int tohit1 = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            int todam1 = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            int tohit2 = GetBonusValue(10, level);
            int todam2 = GetBonusValue(10, level);
            int artifactBias = 0;
            if (power > 0)
            {
                _item.BonusToHit += tohit1;
                _item.BonusDamage += todam1;
                if (power > 1)
                {
                    _item.BonusToHit += tohit2;
                    _item.BonusDamage += todam2;
                }
            }
            else if (power < 0)
            {
                _item.BonusToHit -= tohit1;
                _item.BonusDamage -= todam1;
                if (power < -1)
                {
                    _item.BonusToHit -= tohit2;
                    _item.BonusDamage -= todam2;
                }
                if (_item.BonusToHit + _item.BonusDamage < 0)
                {
                    _item.IdentifyFlags.Set(Constants.IdentCursed);
                }
            }
            switch (_item.Category)
            {
                case ItemCategory.Digging:
                    {
                        if (power > 1)
                        {
                            _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfDigging;
                        }
                        else if (power < -1)
                        {
                            _item.TypeSpecificValue = 0 - (5 + Program.Rng.DieRoll(5));
                        }
                        else if (power < 0)
                        {
                            _item.TypeSpecificValue = 0 - _item.TypeSpecificValue;
                        }
                        break;
                    }
                case ItemCategory.Hafted:
                case ItemCategory.Polearm:
                case ItemCategory.Sword:
                    {
                        if (power > 1)
                        {
                            switch (Program.Rng.DieRoll(_item.Category == ItemCategory.Polearm ? 40 : 42))
                            {
                                case 1:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponElderSign;
                                        if (Program.Rng.DieRoll(4) == 1)
                                        {
                                            _item.RandartFlags1.Set(ItemFlag1.Blows);
                                            if (_item.TypeSpecificValue > 2)
                                            {
                                                _item.TypeSpecificValue -= Program.Rng.DieRoll(2);
                                            }
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponDefender;
                                        if (Program.Rng.DieRoll(3) == 1)
                                        {
                                            _item.RandartFlags2.Set(ItemFlag2.ResPois);
                                        }
                                        ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(22) + 16);
                                        break;
                                    }
                                case 3:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfVitriol;
                                        break;
                                    }
                                case 4:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfShocking;
                                        break;
                                    }
                                case 5:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfBurning;
                                        break;
                                    }
                                case 6:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfFreezing;
                                        break;
                                    }
                                case 7:
                                case 8:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayAnimal;
                                        if (Program.Rng.RandomLessThan(100) < 20)
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfAnimalBane;
                                        }
                                        break;
                                    }
                                case 9:
                                case 10:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayDragon;
                                        ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(12) + 4);
                                        if (Program.Rng.RandomLessThan(100) < 20)
                                        {
                                            if (Program.Rng.DieRoll(3) == 1)
                                            {
                                                _item.RandartFlags2.Set(ItemFlag2.ResPois);
                                            }
                                            ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(14) + 4);
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfDragonBane;
                                        }
                                        break;
                                    }
                                case 11:
                                case 12:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayEvil;
                                        if (Program.Rng.RandomLessThan(100) < 20)
                                        {
                                            _item.RandartFlags2.Set(ItemFlag2.ResFear);
                                            _item.RandartFlags3.Set(ItemFlag3.Blessed);
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfEvilBane;
                                        }
                                        break;
                                    }
                                case 13:
                                case 14:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayUndead;
                                        _item.RandartFlags2.Set(ItemFlag2.HoldLife);
                                        if (Program.Rng.RandomLessThan(100) < 20)
                                        {
                                            _item.RandartFlags2.Set(ItemFlag2.ResNether);
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfUndeadBane;
                                        }
                                        break;
                                    }
                                case 15:
                                case 16:
                                case 17:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayOrc;
                                        break;
                                    }
                                case 18:
                                case 19:
                                case 20:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayTroll;
                                        break;
                                    }
                                case 21:
                                case 22:
                                case 23:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayGiant;
                                        break;
                                    }
                                case 24:
                                case 25:
                                case 26:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayDemon;
                                        break;
                                    }
                                case 27:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfKadath;
                                        if (Program.Rng.DieRoll(3) == 1)
                                        {
                                            _item.RandartFlags2.Set(ItemFlag2.ResFear);
                                        }
                                        break;
                                    }
                                case 28:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponBlessed;
                                        break;
                                    }
                                case 29:
                                case 30:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfExtraAttacks;
                                        break;
                                    }
                                case 31:
                                case 32:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponVampiric;
                                        break;
                                    }
                                case 33:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfPoisoning;
                                        break;
                                    }
                                case 34:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponChaotic;
                                        ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(34) + 4);
                                        break;
                                    }
                                case 35:
                                    {
                                        CreateRandart(false);
                                        break;
                                    }
                                case 36:
                                case 37:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlaying;
                                        if (Program.Rng.DieRoll(3) == 1)
                                        {
                                            _item.DamageDice *= 2;
                                        }
                                        else
                                        {
                                            do
                                            {
                                                _item.DamageDice++;
                                            } while (Program.Rng.DieRoll(_item.DamageDice) == 1);
                                            do
                                            {
                                                _item.DamageDiceSides++;
                                            } while (Program.Rng.DieRoll(_item.DamageDiceSides) == 1);
                                        }
                                        if (Program.Rng.DieRoll(5) == 1)
                                        {
                                            _item.RandartFlags1.Set(ItemFlag1.BrandPois);
                                        }
                                        if (_item.Category == ItemCategory.Sword && Program.Rng.DieRoll(3) == 1)
                                        {
                                            _item.RandartFlags1.Set(ItemFlag1.Vorpal);
                                        }
                                        break;
                                    }
                                case 38:
                                case 39:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponPlanarWeapon;
                                        ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(22) + 16);
                                        if (Program.Rng.DieRoll(5) == 1)
                                        {
                                            _item.RandartFlags1.Set(ItemFlag1.SlayDemon);
                                        }
                                        break;
                                    }
                                case 40:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfLaw;
                                        if (Program.Rng.DieRoll(3) == 1)
                                        {
                                            _item.RandartFlags2.Set(ItemFlag2.HoldLife);
                                        }
                                        if (Program.Rng.DieRoll(3) == 1)
                                        {
                                            _item.RandartFlags1.Set(ItemFlag1.Dex);
                                        }
                                        if (Program.Rng.DieRoll(5) == 1)
                                        {
                                            _item.RandartFlags2.Set(ItemFlag2.ResFear);
                                        }
                                        ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(22) + 16);
                                        break;
                                    }
                                default:
                                    {
                                        if (_item.Category == ItemCategory.Sword)
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSharpness;
                                            _item.TypeSpecificValue = GetBonusValue(5, level) + 1;
                                        }
                                        else
                                        {
                                            _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfEarthquakes;
                                            if (Program.Rng.DieRoll(3) == 1)
                                            {
                                                _item.RandartFlags1.Set(ItemFlag1.Blows);
                                            }
                                            _item.TypeSpecificValue = GetBonusValue(3, level);
                                        }
                                        break;
                                    }
                            }
                            while (Program.Rng.RandomLessThan(10 * _item.DamageDice * _item.DamageDiceSides) == 0)
                            {
                                _item.DamageDice++;
                            }
                            if (_item.DamageDice > 9)
                            {
                                _item.DamageDice = 9;
                            }
                        }
                        else if (power < -1)
                        {
                            if (Program.Rng.RandomLessThan(Constants.MaxDepth) < level)
                            {
                                _item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfLeng;
                                if (Program.Rng.DieRoll(6) == 1)
                                {
                                    _item.RandartFlags3.Set(ItemFlag3.DreadCurse);
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
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.BowOfExtraMight;
                                        ApplyRandomResistance(artifactBias, Program.Rng.DieRoll(34) + 4);
                                        break;
                                    }
                                case 2:
                                case 12:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.BowOfExtraShots;
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
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.BowOfVelocity;
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
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.BowOfAccuracy;
                                        break;
                                    }
                                default:
                                    {
                                        CreateRandart(false);
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
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfWounding;
                                        break;
                                    }
                                case 4:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfFlame;
                                        break;
                                    }
                                case 5:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfFrost;
                                        break;
                                    }
                                case 6:
                                case 7:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfHurtAnimal;
                                        break;
                                    }
                                case 8:
                                case 9:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfHurtEvil;
                                        break;
                                    }
                                case 10:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfHurtDragon;
                                        break;
                                    }
                                case 11:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfShocking;
                                        break;
                                    }
                                case 12:
                                    {
                                        _item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfSlaying;
                                        _item.DamageDice++;
                                        break;
                                    }
                            }
                            while (Program.Rng.RandomLessThan(10 * _item.DamageDice * _item.DamageDiceSides) == 0)
                            {
                                _item.DamageDice++;
                            }
                            if (_item.DamageDice > 9)
                            {
                                _item.DamageDice = 9;
                            }
                        }
                        else if (power < -1)
                        {
                            if (Program.Rng.RandomLessThan(Constants.MaxDepth) < level)
                            {
                                _item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfBackbiting;
                            }
                        }
                        break;
                    }
            }
        }

        private void ApplyRandomBonuses(int artifactBias)
        {
            int thisType = _item.Category < ItemCategory.Boots ? 23 : 19;
            if (artifactBias == ArtifactBias.Warrior)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.Str))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Str);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
                if (_item.RandartFlags1.IsClear(ItemFlag1.Con))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Con);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
                if (_item.RandartFlags1.IsClear(ItemFlag1.Dex))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Dex);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Mage)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.Int))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Int);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Priestly)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.Wis))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Wis);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Ranger)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.Con))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Con);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
                if (_item.RandartFlags1.IsClear(ItemFlag1.Dex))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Dex);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
                if (_item.RandartFlags1.IsClear(ItemFlag1.Str))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Str);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Rogue)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.Stealth))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Stealth);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
                if (_item.RandartFlags1.IsClear(ItemFlag1.Search))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Search);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Strength)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.Str))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Str);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Wisdom)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.Wis))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Wis);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Intelligence)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.Int))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Int);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Dexterity)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.Dex))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Dex);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Constitution)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.Con))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Con);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Charisma)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.Cha))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Cha);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            switch (Program.Rng.DieRoll(thisType))
            {
                case 1:
                case 2:
                    _item.RandartFlags1.Set(ItemFlag1.Str);
                    if (artifactBias == 0 && Program.Rng.DieRoll(13) != 1)
                    {
                        artifactBias = ArtifactBias.Strength;
                    }
                    else if (artifactBias == 0 && Program.Rng.DieRoll(7) == 1)
                    {
                        artifactBias = ArtifactBias.Warrior;
                    }
                    break;

                case 3:
                case 4:
                    _item.RandartFlags1.Set(ItemFlag1.Int);
                    if (artifactBias == 0 && Program.Rng.DieRoll(13) != 1)
                    {
                        artifactBias = ArtifactBias.Intelligence;
                    }
                    else if (artifactBias == 0 && Program.Rng.DieRoll(7) == 1)
                    {
                        artifactBias = ArtifactBias.Mage;
                    }
                    break;

                case 5:
                case 6:
                    _item.RandartFlags1.Set(ItemFlag1.Wis);
                    if (artifactBias == 0 && Program.Rng.DieRoll(13) != 1)
                    {
                        artifactBias = ArtifactBias.Wisdom;
                    }
                    else if (artifactBias == 0 && Program.Rng.DieRoll(7) == 1)
                    {
                        artifactBias = ArtifactBias.Priestly;
                    }
                    break;

                case 7:
                case 8:
                    _item.RandartFlags1.Set(ItemFlag1.Dex);
                    if (artifactBias == 0 && Program.Rng.DieRoll(13) != 1)
                    {
                        artifactBias = ArtifactBias.Dexterity;
                    }
                    else if (artifactBias == 0 && Program.Rng.DieRoll(7) == 1)
                    {
                        artifactBias = ArtifactBias.Rogue;
                    }
                    break;

                case 9:
                case 10:
                    _item.RandartFlags1.Set(ItemFlag1.Con);
                    if (artifactBias == 0 && Program.Rng.DieRoll(13) != 1)
                    {
                        artifactBias = ArtifactBias.Constitution;
                    }
                    else if (artifactBias == 0 && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = ArtifactBias.Ranger;
                    }
                    break;

                case 11:
                case 12:
                    _item.RandartFlags1.Set(ItemFlag1.Cha);
                    if (artifactBias == 0 && Program.Rng.DieRoll(13) != 1)
                    {
                        artifactBias = ArtifactBias.Charisma;
                    }
                    break;

                case 13:
                case 14:
                    _item.RandartFlags1.Set(ItemFlag1.Stealth);
                    if (artifactBias == 0 && Program.Rng.DieRoll(3) == 1)
                    {
                        artifactBias = ArtifactBias.Rogue;
                    }
                    break;

                case 15:
                case 16:
                    _item.RandartFlags1.Set(ItemFlag1.Search);
                    if (artifactBias == 0 && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = ArtifactBias.Ranger;
                    }
                    break;

                case 17:
                case 18:
                    _item.RandartFlags1.Set(ItemFlag1.Infra);
                    break;

                case 19:
                    _item.RandartFlags1.Set(ItemFlag1.Speed);
                    if (artifactBias == 0 && Program.Rng.DieRoll(11) == 1)
                    {
                        artifactBias = ArtifactBias.Rogue;
                    }
                    break;

                case 20:
                case 21:
                    _item.RandartFlags1.Set(ItemFlag1.Tunnel);
                    break;

                case 22:
                case 23:
                    if (_item.Category == ItemCategory.Bow)
                    {
                        ApplyRandomBonuses(artifactBias);
                    }
                    else
                    {
                        _item.RandartFlags1.Set(ItemFlag1.Blows);
                        if (artifactBias == 0 && Program.Rng.DieRoll(11) == 1)
                        {
                            artifactBias = ArtifactBias.Warrior;
                        }
                    }
                    break;
            }
        }

        private void ApplyRandomMiscPower(int artifactBias)
        {
            if (artifactBias == ArtifactBias.Ranger)
            {
                if (_item.RandartFlags2.IsClear(ItemFlag2.SustCon))
                {
                    _item.RandartFlags2.Set(ItemFlag2.SustCon);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Strength)
            {
                if (_item.RandartFlags2.IsClear(ItemFlag2.SustStr))
                {
                    _item.RandartFlags2.Set(ItemFlag2.SustStr);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Wisdom)
            {
                if (_item.RandartFlags2.IsClear(ItemFlag2.SustWis))
                {
                    _item.RandartFlags2.Set(ItemFlag2.SustWis);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Intelligence)
            {
                if (_item.RandartFlags2.IsClear(ItemFlag2.SustInt))
                {
                    _item.RandartFlags2.Set(ItemFlag2.SustInt);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Dexterity)
            {
                if (_item.RandartFlags2.IsClear(ItemFlag2.SustDex))
                {
                    _item.RandartFlags2.Set(ItemFlag2.SustDex);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Constitution)
            {
                if (_item.RandartFlags2.IsClear(ItemFlag2.SustCon))
                {
                    _item.RandartFlags2.Set(ItemFlag2.SustCon);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Charisma)
            {
                if (_item.RandartFlags2.IsClear(ItemFlag2.SustCha))
                {
                    _item.RandartFlags2.Set(ItemFlag2.SustCha);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Chaos)
            {
                if (_item.RandartFlags3.IsClear(ItemFlag3.Teleport))
                {
                    _item.RandartFlags3.Set(ItemFlag3.Teleport);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Fire)
            {
                if (_item.RandartFlags3.IsClear(ItemFlag3.Lightsource))
                {
                    _item.RandartFlags3.Set(ItemFlag3.Lightsource);
                }
            }
            switch (Program.Rng.DieRoll(31))
            {
                case 1:
                    _item.RandartFlags2.Set(ItemFlag2.SustStr);
                    if (artifactBias == 0)
                    {
                        artifactBias = ArtifactBias.Strength;
                    }
                    break;

                case 2:
                    _item.RandartFlags2.Set(ItemFlag2.SustInt);
                    if (artifactBias == 0)
                    {
                        artifactBias = ArtifactBias.Intelligence;
                    }
                    break;

                case 3:
                    _item.RandartFlags2.Set(ItemFlag2.SustWis);
                    if (artifactBias == 0)
                    {
                        artifactBias = ArtifactBias.Wisdom;
                    }
                    break;

                case 4:
                    _item.RandartFlags2.Set(ItemFlag2.SustDex);
                    if (artifactBias == 0)
                    {
                        artifactBias = ArtifactBias.Dexterity;
                    }
                    break;

                case 5:
                    _item.RandartFlags2.Set(ItemFlag2.SustCon);
                    if (artifactBias == 0)
                    {
                        artifactBias = ArtifactBias.Constitution;
                    }
                    break;

                case 6:
                    _item.RandartFlags2.Set(ItemFlag2.SustCha);
                    if (artifactBias == 0)
                    {
                        artifactBias = ArtifactBias.Charisma;
                    }
                    break;

                case 7:
                case 8:
                case 14:
                    _item.RandartFlags2.Set(ItemFlag2.FreeAct);
                    break;

                case 9:
                    _item.RandartFlags2.Set(ItemFlag2.HoldLife);
                    if (artifactBias == 0 && Program.Rng.DieRoll(5) == 1)
                    {
                        artifactBias = ArtifactBias.Priestly;
                    }
                    else if (artifactBias == 0 && Program.Rng.DieRoll(6) == 1)
                    {
                        artifactBias = ArtifactBias.Necromantic;
                    }
                    break;

                case 10:
                case 11:
                    _item.RandartFlags3.Set(ItemFlag3.Lightsource);
                    break;

                case 12:
                case 13:
                    _item.RandartFlags3.Set(ItemFlag3.Feather);
                    break;

                case 15:
                case 16:
                case 17:
                    _item.RandartFlags3.Set(ItemFlag3.SeeInvis);
                    break;

                case 18:
                    _item.RandartFlags3.Set(ItemFlag3.Telepathy);
                    if (artifactBias == 0 && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = ArtifactBias.Mage;
                    }
                    break;

                case 19:
                case 20:
                    _item.RandartFlags3.Set(ItemFlag3.SlowDigest);
                    break;

                case 21:
                case 22:
                    _item.RandartFlags3.Set(ItemFlag3.Regen);
                    break;

                case 23:
                    _item.RandartFlags3.Set(ItemFlag3.Teleport);
                    break;

                case 24:
                case 25:
                case 26:
                    if (_item.Category >= ItemCategory.Boots)
                    {
                        ApplyRandomMiscPower(artifactBias);
                    }
                    else
                    {
                        _item.RandartFlags3.Set(ItemFlag3.ShowMods);
                        _item.BonusArmourClass = 4 + Program.Rng.DieRoll(11);
                    }
                    break;

                case 27:
                case 28:
                case 29:
                    _item.RandartFlags3.Set(ItemFlag3.ShowMods);
                    _item.BonusToHit += 4 + Program.Rng.DieRoll(11);
                    _item.BonusDamage += 4 + Program.Rng.DieRoll(11);
                    break;

                case 30:
                    _item.RandartFlags3.Set(ItemFlag3.NoMagic);
                    break;

                case 31:
                    _item.RandartFlags3.Set(ItemFlag3.NoTele);
                    break;
            }
        }

        private void ApplyRandomSlaying(int artifactBias)
        {
            if (artifactBias == ArtifactBias.Chaos && _item.Category != ItemCategory.Bow)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.Chaotic))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Chaotic);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Priestly &&
                     (_item.Category == ItemCategory.Sword ||
                      _item.Category == ItemCategory.Polearm) &&
                     _item.RandartFlags3.IsClear(ItemFlag3.Blessed))
            {
                _item.RandartFlags3.Set(ItemFlag3.Blessed);
            }
            else if (artifactBias == ArtifactBias.Necromantic && _item.Category != ItemCategory.Bow)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.Vampiric))
                {
                    _item.RandartFlags1.Set(ItemFlag1.Vampiric);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
                if (_item.RandartFlags1.IsClear(ItemFlag1.BrandPois) && Program.Rng.DieRoll(2) == 1)
                {
                    _item.RandartFlags1.Set(ItemFlag1.BrandPois);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Ranger && _item.Category != ItemCategory.Bow)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.SlayAnimal))
                {
                    _item.RandartFlags1.Set(ItemFlag1.SlayAnimal);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Rogue && _item.Category != ItemCategory.Bow)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.BrandPois))
                {
                    _item.RandartFlags1.Set(ItemFlag1.BrandPois);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Poison && _item.Category != ItemCategory.Bow)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.BrandPois))
                {
                    _item.RandartFlags1.Set(ItemFlag1.BrandPois);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Fire && _item.Category != ItemCategory.Bow)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.BrandFire))
                {
                    _item.RandartFlags1.Set(ItemFlag1.BrandFire);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Cold && _item.Category != ItemCategory.Bow)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.BrandCold))
                {
                    _item.RandartFlags1.Set(ItemFlag1.BrandCold);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Electricity && _item.Category != ItemCategory.Bow)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.BrandElec))
                {
                    _item.RandartFlags1.Set(ItemFlag1.BrandElec);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Acid && _item.Category != ItemCategory.Bow)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.BrandAcid))
                {
                    _item.RandartFlags1.Set(ItemFlag1.BrandAcid);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            else if (artifactBias == ArtifactBias.Law && _item.Category != ItemCategory.Bow)
            {
                if (_item.RandartFlags1.IsClear(ItemFlag1.SlayEvil))
                {
                    _item.RandartFlags1.Set(ItemFlag1.SlayEvil);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
                if (_item.RandartFlags1.IsClear(ItemFlag1.SlayUndead))
                {
                    _item.RandartFlags1.Set(ItemFlag1.SlayUndead);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
                if (_item.RandartFlags1.IsClear(ItemFlag1.SlayDemon))
                {
                    _item.RandartFlags1.Set(ItemFlag1.SlayDemon);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return;
                    }
                }
            }
            if (_item.Category != ItemCategory.Bow)
            {
                switch (Program.Rng.DieRoll(34))
                {
                    case 1:
                    case 2:
                        _item.RandartFlags1.Set(ItemFlag1.SlayAnimal);
                        break;

                    case 3:
                    case 4:
                        _item.RandartFlags1.Set(ItemFlag1.SlayEvil);
                        if (artifactBias == 0 && Program.Rng.DieRoll(2) == 1)
                        {
                            artifactBias = ArtifactBias.Law;
                        }
                        else if (artifactBias == 0 && Program.Rng.DieRoll(9) == 1)
                        {
                            artifactBias = ArtifactBias.Priestly;
                        }
                        break;

                    case 5:
                    case 6:
                        _item.RandartFlags1.Set(ItemFlag1.SlayUndead);
                        if (artifactBias == 0 && Program.Rng.DieRoll(9) == 1)
                        {
                            artifactBias = ArtifactBias.Priestly;
                        }
                        break;

                    case 7:
                    case 8:
                        _item.RandartFlags1.Set(ItemFlag1.SlayDemon);
                        if (artifactBias == 0 && Program.Rng.DieRoll(9) == 1)
                        {
                            artifactBias = ArtifactBias.Priestly;
                        }
                        break;

                    case 9:
                    case 10:
                        _item.RandartFlags1.Set(ItemFlag1.SlayOrc);
                        break;

                    case 11:
                    case 12:
                        _item.RandartFlags1.Set(ItemFlag1.SlayTroll);
                        break;

                    case 13:
                    case 14:
                        _item.RandartFlags1.Set(ItemFlag1.SlayGiant);
                        break;

                    case 15:
                    case 16:
                        _item.RandartFlags1.Set(ItemFlag1.SlayDragon);
                        break;

                    case 17:
                        _item.RandartFlags1.Set(ItemFlag1.KillDragon);
                        break;

                    case 18:
                    case 19:
                        if (_item.Category == ItemCategory.Sword)
                        {
                            _item.RandartFlags1.Set(ItemFlag1.Vorpal);
                            if (artifactBias == 0 && Program.Rng.DieRoll(9) == 1)
                            {
                                artifactBias = ArtifactBias.Warrior;
                            }
                        }
                        else
                        {
                            ApplyRandomSlaying(artifactBias);
                        }
                        break;

                    case 20:
                        _item.RandartFlags1.Set(ItemFlag1.Impact);
                        break;

                    case 21:
                    case 22:
                        _item.RandartFlags1.Set(ItemFlag1.BrandFire);
                        if (artifactBias == 0)
                        {
                            artifactBias = ArtifactBias.Fire;
                        }
                        break;

                    case 23:
                    case 24:
                        _item.RandartFlags1.Set(ItemFlag1.BrandCold);
                        if (artifactBias == 0)
                        {
                            artifactBias = ArtifactBias.Cold;
                        }
                        break;

                    case 25:
                    case 26:
                        _item.RandartFlags1.Set(ItemFlag1.BrandElec);
                        if (artifactBias == 0)
                        {
                            artifactBias = ArtifactBias.Electricity;
                        }
                        break;

                    case 27:
                    case 28:
                        _item.RandartFlags1.Set(ItemFlag1.BrandAcid);
                        if (artifactBias == 0)
                        {
                            artifactBias = ArtifactBias.Acid;
                        }
                        break;

                    case 29:
                    case 30:
                        _item.RandartFlags1.Set(ItemFlag1.BrandPois);
                        if (artifactBias == 0 && Program.Rng.DieRoll(3) != 1)
                        {
                            artifactBias = ArtifactBias.Poison;
                        }
                        else if (artifactBias == 0 && Program.Rng.DieRoll(6) == 1)
                        {
                            artifactBias = ArtifactBias.Necromantic;
                        }
                        else if (artifactBias == 0)
                        {
                            artifactBias = ArtifactBias.Rogue;
                        }
                        break;

                    case 31:
                    case 32:
                        _item.RandartFlags1.Set(ItemFlag1.Vampiric);
                        if (artifactBias == 0)
                        {
                            artifactBias = ArtifactBias.Necromantic;
                        }
                        break;

                    default:
                        _item.RandartFlags1.Set(ItemFlag1.Chaotic);
                        if (artifactBias == 0)
                        {
                            artifactBias = ArtifactBias.Chaos;
                        }
                        break;
                }
            }
            else
            {
                switch (Program.Rng.DieRoll(6))
                {
                    case 1:
                    case 2:
                    case 3:
                        _item.RandartFlags3.Set(ItemFlag3.XtraMight);
                        if (artifactBias == 0 && Program.Rng.DieRoll(9) == 1)
                        {
                            artifactBias = ArtifactBias.Ranger;
                        }
                        break;

                    default:
                        _item.RandartFlags3.Set(ItemFlag3.XtraShots);
                        if (artifactBias == 0 && Program.Rng.DieRoll(9) == 1)
                        {
                            artifactBias = ArtifactBias.Ranger;
                        }
                        break;
                }
            }
        }

        private void ChargeStaff()
        {
            switch (_item.ItemSubCategory)
            {
                case StaffType.Darkness:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
                    break;

                case StaffType.Slowness:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
                    break;

                case StaffType.HasteMonsters:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
                    break;

                case StaffType.Summoning:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;

                case StaffType.Teleportation:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(4) + 5;
                    break;

                case StaffType.Identify:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(15) + 5;
                    break;

                case StaffType.RemoveCurse:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
                    break;

                case StaffType.Starlight:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.Light:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
                    break;

                case StaffType.Mapping:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(5) + 5;
                    break;

                case StaffType.DetectGold:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
                    break;

                case StaffType.DetectItem:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(15) + 6;
                    break;

                case StaffType.DetectTrap:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.DetectDoor:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
                    break;

                case StaffType.DetectInvis:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
                    break;

                case StaffType.DetectEvil:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
                    break;

                case StaffType.CureLight:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.Curing:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
                    break;

                case StaffType.Healing:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
                    break;

                case StaffType.TheMagi:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(2) + 2;
                    break;

                case StaffType.SleepMonsters:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.SlowMonsters:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.Speed:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
                    break;

                case StaffType.Probing:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(6) + 2;
                    break;

                case StaffType.DispelEvil:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
                    break;

                case StaffType.Power:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;

                case StaffType.Holiness:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(2) + 2;
                    break;

                case StaffType.Carnage:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
                    break;

                case StaffType.Earthquakes:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
                    break;

                case StaffType.Destruction:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;
            }
        }

        private void ChargeWand()
        {
            switch (_item.ItemSubCategory)
            {
                case WandType.HealMonster:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
                    break;

                case WandType.HasteMonster:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
                    break;

                case WandType.CloneMonster:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
                    break;

                case WandType.TeleportAway:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case WandType.Disarming:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(5) + 4;
                    break;

                case WandType.TrapDoorDest:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
                    break;

                case WandType.StoneToMud:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(8) + 3;
                    break;

                case WandType.Light:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(10) + 6;
                    break;

                case WandType.SleepMonster:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
                    break;

                case WandType.SlowMonster:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(10) + 6;
                    break;

                case WandType.ConfuseMonster:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(12) + 6;
                    break;

                case WandType.FearMonster:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
                    break;

                case WandType.DrainLife:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(3) + 3;
                    break;

                case WandType.Polymorph:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
                    break;

                case WandType.StinkingCloud:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
                    break;

                case WandType.MagicMissile:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(10) + 6;
                    break;

                case WandType.AcidBolt:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
                    break;

                case WandType.CharmMonster:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(6) + 2;
                    break;

                case WandType.FireBolt:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
                    break;

                case WandType.ColdBolt:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case WandType.AcidBall:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(5) + 2;
                    break;

                case WandType.ElecBall:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(8) + 4;
                    break;

                case WandType.FireBall:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(4) + 2;
                    break;

                case WandType.ColdBall:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(6) + 2;
                    break;

                case WandType.Wonder:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
                    break;

                case WandType.Annihilation:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
                    break;

                case WandType.DragonFire:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;

                case WandType.DragonCold:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;

                case WandType.DragonBreath:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;

                case WandType.Shard:
                    _item.TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
                    break;
            }
        }

        private void CurseRandart()
        {
            if (_item.TypeSpecificValue != 0)
            {
                _item.TypeSpecificValue = 0 - (_item.TypeSpecificValue + Program.Rng.DieRoll(4));
            }
            if (_item.BonusArmourClass != 0)
            {
                _item.BonusArmourClass = 0 - (_item.BonusArmourClass + Program.Rng.DieRoll(4));
            }
            if (_item.BonusToHit != 0)
            {
                _item.BonusToHit = 0 - (_item.BonusToHit + Program.Rng.DieRoll(4));
            }
            if (_item.BonusDamage != 0)
            {
                _item.BonusDamage = 0 - (_item.BonusDamage + Program.Rng.DieRoll(4));
            }
            _item.RandartFlags3.Set(ItemFlag3.HeavyCurse | ItemFlag3.Cursed);
            if (Program.Rng.DieRoll(4) == 1)
            {
                _item.RandartFlags3.Set(ItemFlag3.PermaCurse);
            }
            if (Program.Rng.DieRoll(3) == 1)
            {
                _item.RandartFlags3.Set(ItemFlag3.DreadCurse);
            }
            if (Program.Rng.DieRoll(2) == 1)
            {
                _item.RandartFlags3.Set(ItemFlag3.Aggravate);
            }
            if (Program.Rng.DieRoll(3) == 1)
            {
                _item.RandartFlags3.Set(ItemFlag3.DrainExp);
            }
            if (Program.Rng.DieRoll(2) == 1)
            {
                _item.RandartFlags3.Set(ItemFlag3.Teleport);
            }
            else if (Program.Rng.DieRoll(3) == 1)
            {
                _item.RandartFlags3.Set(ItemFlag3.NoTele);
            }
            if (SaveGame.Instance.Player.ProfessionIndex != CharacterClass.Warrior && Program.Rng.DieRoll(3) == 1)
            {
                _item.RandartFlags3.Set(ItemFlag3.NoMagic);
            }
            _item.IdentifyFlags.Set(Constants.IdentCursed);
        }

        private int GetBonusValue(int max, int level)
        {
            if (level > Constants.MaxDepth - 1)
            {
                level = Constants.MaxDepth - 1;
            }
            int bonus = max * level / Constants.MaxDepth;
            int extra = max * level % Constants.MaxDepth;
            if (Program.Rng.RandomLessThan(Constants.MaxDepth) < extra)
            {
                bonus++;
            }
            int stand = max / 4;
            extra = max % 4;
            if (Program.Rng.RandomLessThan(4) < extra)
            {
                stand++;
            }
            int value = Program.Rng.RandomNormal(bonus, stand);
            if (value < 0)
            {
                return 0;
            }
            if (value > max)
            {
                return max;
            }
            return value;
        }

        private string GetRndLineInternal(string[] list)
        {
            return list[Program.Rng.RandomLessThan(list.Length)];
        }

        private string GetTableName()
        {
            int testcounter = Program.Rng.DieRoll(3) + 1;
            string outString = "";
            if (Program.Rng.DieRoll(3) == 2)
            {
                while (testcounter-- != 0)
                {
                    outString += ScrollFlavour.Syllables[Program.Rng.RandomLessThan(ScrollFlavour.Syllables.Length)];
                }
            }
            else
            {
                testcounter = Program.Rng.DieRoll(2) + 1;
                while (testcounter-- != 0)
                {
                    outString += GetRndLineInternal(GlobalData.TextElvish);
                }
            }
            return "'" + outString.Substring(0, 1).ToUpper() + outString.Substring(1) + "'";
        }

        private void GiveActivationPower(int artifactBias)
        {
            IActivationPower type = null;
            int chance = 0;
            if (artifactBias != 0)
            {
                if (artifactBias == ArtifactBias.Electricity)
                {
                    if (Program.Rng.DieRoll(3) != 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(BoElec1ActivationPower));
                    }
                    else if (Program.Rng.DieRoll(5) != 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(BaElec2ActivationPower));
                    }
                    else
                    {
                        type = ActivationPowerManager.FindByType(typeof(BaElec3ActivationPower));
                    }
                    chance = 101;
                }
                else if (artifactBias == ArtifactBias.Poison)
                {
                    type = ActivationPowerManager.FindByType(typeof(BaPois1ActivationPower));
                    chance = 101;
                }
                else if (artifactBias == ArtifactBias.Fire)
                {
                    if (Program.Rng.DieRoll(3) != 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(BoFire1ActivationPower));
                    }
                    else if (Program.Rng.DieRoll(5) != 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(BaFire1ActivationPower));
                    }
                    else
                    {
                        type = ActivationPowerManager.FindByType(typeof(BaFire2ActivationPower));
                    }
                    chance = 101;
                }
                else if (artifactBias == ArtifactBias.Cold)
                {
                    chance = 101;
                    if (Program.Rng.DieRoll(3) != 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(BoCold1ActivationPower));
                    }
                    else if (Program.Rng.DieRoll(3) != 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(BaCold1ActivationPower));
                    }
                    else if (Program.Rng.DieRoll(3) != 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(BaCold2ActivationPower));
                    }
                    else
                    {
                        type = ActivationPowerManager.FindByType(typeof(BaCold3ActivationPower));
                    }
                }
                else if (artifactBias == ArtifactBias.Chaos)
                {
                    chance = 50;
                    if (Program.Rng.DieRoll(6) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(SummonDemonActivationPower));
                    }
                    else
                    {
                        type = ActivationPowerManager.FindByType(typeof(CallChaosActivationPower));
                    }
                }
                else if (artifactBias == ArtifactBias.Priestly)
                {
                    chance = 101;
                    if (Program.Rng.DieRoll(13) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(CharmUndeadActivationPower));
                    }
                    else if (Program.Rng.DieRoll(12) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(BanishEvilActivationPower));
                    }
                    else if (Program.Rng.DieRoll(11) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(DispEvilActivationPower));
                    }
                    else if (Program.Rng.DieRoll(10) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(ProtEvilActivationPower));
                    }
                    else if (Program.Rng.DieRoll(9) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(Cure1000ActivationPower));
                    }
                    else if (Program.Rng.DieRoll(8) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(Cure700ActivationPower));
                    }
                    else if (Program.Rng.DieRoll(7) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(RestAllActivationPower));
                    }
                    else if (Program.Rng.DieRoll(6) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(RestLifeActivationPower));
                    }
                    else
                    {
                        type = ActivationPowerManager.FindByType(typeof(CureMwActivationPower));
                    }
                }
                else if (artifactBias == ArtifactBias.Necromantic)
                {
                    chance = 101;
                    if (Program.Rng.DieRoll(66) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(WraithActivationPower));
                    }
                    else if (Program.Rng.DieRoll(13) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(DispGoodActivationPower));
                    }
                    else if (Program.Rng.DieRoll(9) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(MassGenoActivationPower));
                    }
                    else if (Program.Rng.DieRoll(8) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(CarnageActivationPower));
                    }
                    else if (Program.Rng.DieRoll(13) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(SummonUndeadActivationPower));
                    }
                    else if (Program.Rng.DieRoll(9) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(Vampire2ActivationPower));
                    }
                    else if (Program.Rng.DieRoll(6) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(CharmUndeadActivationPower));
                    }
                    else
                    {
                        type = ActivationPowerManager.FindByType(typeof(Vampire1ActivationPower));
                    }
                }
                else if (artifactBias == ArtifactBias.Law)
                {
                    chance = 101;
                    if (Program.Rng.DieRoll(8) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(BanishEvilActivationPower));
                    }
                    else if (Program.Rng.DieRoll(4) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(DispEvilActivationPower));
                    }
                    else
                    {
                        type = ActivationPowerManager.FindByType(typeof(ProtEvilActivationPower));
                    }
                }
                else if (artifactBias == ArtifactBias.Rogue)
                {
                    chance = 101;
                    if (Program.Rng.DieRoll(50) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(SpeedActivationPower));
                    }
                    else if (Program.Rng.DieRoll(4) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(SleepActivationPower));
                    }
                    else if (Program.Rng.DieRoll(3) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(DetectAllActivationPower));
                    }
                    else if (Program.Rng.DieRoll(8) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(IdFullActivationPower));
                    }
                    else
                    {
                        type = ActivationPowerManager.FindByType(typeof(IdPlainActivationPower));
                    }
                }
                else if (artifactBias == ArtifactBias.Mage)
                {
                    chance = 66;
                    if (Program.Rng.DieRoll(20) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(SummonElementalActivationPower));
                    }
                    else if (Program.Rng.DieRoll(10) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(SummonPhantomActivationPower));
                    }
                    else if (Program.Rng.DieRoll(5) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(RuneExploActivationPower));
                    }
                    else
                    {
                        type = ActivationPowerManager.FindByType(typeof(EspActivationPower));
                    }
                }
                else if (artifactBias == ArtifactBias.Warrior)
                {
                    chance = 80;
                    if (Program.Rng.DieRoll(100) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(InvulnActivationPower));

                    }
                    else
                    {
                        type = ActivationPowerManager.FindByType(typeof(BerserkActivationPower));
                    }
                }
                else if (artifactBias == ArtifactBias.Ranger)
                {
                    chance = 101;
                    if (Program.Rng.DieRoll(20) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(CharmAnimalsActivationPower));
                    }
                    else if (Program.Rng.DieRoll(7) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(SummonAnimalActivationPower));
                    }
                    else if (Program.Rng.DieRoll(6) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(CharmAnimalActivationPower));
                    }
                    else if (Program.Rng.DieRoll(4) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(ResistAllActivationPower));
                    }
                    else if (Program.Rng.DieRoll(3) == 1)
                    {
                        type = ActivationPowerManager.FindByType(typeof(SatiateActivationPower));
                    }
                    else
                    {
                        type = ActivationPowerManager.FindByType(typeof(CurePoisonActivationPower));
                    }
                }
            }
            while (type == null || Program.Rng.DieRoll(100) >= chance)
            {
                type = ActivationPowerManager.GetRandom();
                chance = type.RandomChance;
            }
            _item.BonusPowerSubType = type;
            _item.RandartFlags3.Set(ItemFlag3.Activate);
            _item.RechargeTimeLeft = 0;
        }

        private bool MakeFixedArtifact()
        {
            foreach (System.Collections.Generic.KeyValuePair<FixedArtifactId, FixedArtifact> pair in Profile.Instance.FixedArtifacts)
            {
                FixedArtifact aPtr = pair.Value;
                if (!aPtr.HasOwnType)
                {
                    continue;
                }
                if (aPtr.CurNum != 0)
                {
                    continue;
                }
                if (aPtr.Level > SaveGame.Instance.Difficulty)
                {
                    int d = (aPtr.Level - SaveGame.Instance.Difficulty) * 2;
                    if (Program.Rng.RandomLessThan(d) != 0)
                    {
                        continue;
                    }
                }
                if (Program.Rng.RandomLessThan(aPtr.Rarity) != 0)
                {
                    return false;
                }
                ItemType kIdx = Profile.Instance.ItemTypes.LookupKind(aPtr.Tval, aPtr.Sval);
                if (kIdx.Level > SaveGame.Instance.Level.ObjectLevel)
                {
                    int d = (kIdx.Level - SaveGame.Instance.Level.ObjectLevel) * 5;
                    if (Program.Rng.RandomLessThan(d) != 0)
                    {
                        continue;
                    }
                }
                _item.AssignItemType(kIdx);
                _item.FixedArtifactIndex = pair.Key;
                return true;
            }
            return false;
        }

        private void PrepareAllocationTable(GetObjNumHookDelegate getObjNumHook)
        {
            AllocationEntry[] table = SaveGame.Instance.AllocKindTable;
            for (int i = 0; i < SaveGame.Instance.AllocKindSize; i++)
            {
                if (getObjNumHook == null || getObjNumHook(table[i].Index))
                {
                    table[i].FilteredProbabiity = table[i].BaseProbability;
                }
                else
                {
                    table[i].FilteredProbabiity = 0;
                }
            }
        }
    }
}