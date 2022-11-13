// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Spells;
using System;
using AngbandOS.Core.ItemClasses;

namespace AngbandOS
{
    internal class PlayerStatus
    {
        private static readonly int[][] _blowsTable =
        {
            new[] {1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3},
            new[] {1, 1, 1, 1, 2, 2, 3, 3, 3, 4, 4, 4},
            new[] {1, 1, 2, 2, 3, 3, 4, 4, 4, 5, 5, 5},
            new[] {1, 2, 2, 3, 3, 4, 4, 4, 5, 5, 5, 5},
            new[] {1, 2, 2, 3, 3, 4, 4, 5, 5, 5, 5, 5},
            new[] {2, 2, 3, 3, 4, 4, 5, 5, 5, 5, 5, 6},
            new[] {2, 2, 3, 3, 4, 4, 5, 5, 5, 5, 5, 6},
            new[] {2, 3, 3, 4, 4, 4, 5, 5, 5, 5, 5, 6},
            new[] {3, 3, 3, 4, 4, 4, 5, 5, 5, 5, 6, 6},
            new[] {3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6},
            new[] {3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6},
            new[] {3, 3, 4, 4, 4, 4, 5, 5, 6, 6, 6, 6}
        };

        private readonly SaveGame SaveGame;

        public PlayerStatus(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }

        public void CalcBonuses()
        {
            int i;
            int extraShots;
            Item oPtr;
            int oldSpeed = SaveGame.Player.Speed;
            bool oldTelepathy = SaveGame.Player.HasTelepathy;
            bool oldSeeInv = SaveGame.Player.HasSeeInvisibility;
            int oldDisAc = SaveGame.Player.DisplayedBaseArmourClass;
            int oldDisToA = SaveGame.Player.DisplayedArmourClassBonus;
            int extraBlows = extraShots = 0;
            for (i = 0; i < 6; i++)
            {
                SaveGame.Player.AbilityScores[i].Bonus = 0;
            }
            SaveGame.Player.DisplayedBaseArmourClass = 0;
            SaveGame.Player.BaseArmourClass = 0;
            SaveGame.Player.DisplayedAttackBonus = 0;
            SaveGame.Player.AttackBonus = 0;
            SaveGame.Player.DisplayedDamageBonus = 0;
            SaveGame.Player.DamageBonus = 0;
            SaveGame.Player.DisplayedArmourClassBonus = 0;
            SaveGame.Player.ArmourClassBonus = 0;
            SaveGame.Player.HasAggravation = false;
            SaveGame.Player.HasRandomTeleport = false;
            SaveGame.Player.HasExperienceDrain = false;
            SaveGame.Player.HasBlessedBlade = false;
            SaveGame.Player.HasExtraMight = false;
            SaveGame.Player.HasQuakeWeapon = false;
            SaveGame.Player.HasSeeInvisibility = false;
            SaveGame.Player.HasFreeAction = false;
            SaveGame.Player.HasSlowDigestion = false;
            SaveGame.Player.HasRegeneration = false;
            SaveGame.Player.HasFeatherFall = false;
            SaveGame.Player.HasHoldLife = false;
            SaveGame.Player.HasTelepathy = false;
            SaveGame.Player.HasGlow = false;
            SaveGame.Player.HasSustainStrength = false;
            SaveGame.Player.HasSustainIntelligence = false;
            SaveGame.Player.HasSustainWisdom = false;
            SaveGame.Player.HasSustainConstitution = false;
            SaveGame.Player.HasSustainDexterity = false;
            SaveGame.Player.HasSustainCharisma = false;
            SaveGame.Player.HasAcidResistance = false;
            SaveGame.Player.HasLightningResistance = false;
            SaveGame.Player.HasFireResistance = false;
            SaveGame.Player.HasColdResistance = false;
            SaveGame.Player.HasPoisonResistance = false;
            SaveGame.Player.HasConfusionResistance = false;
            SaveGame.Player.HasSoundResistance = false;
            SaveGame.Player.HasTimeResistance = false;
            SaveGame.Player.HasLightResistance = false;
            SaveGame.Player.HasDarkResistance = false;
            SaveGame.Player.HasChaosResistance = false;
            SaveGame.Player.HasDisenchantResistance = false;
            SaveGame.Player.HasShardResistance = false;
            SaveGame.Player.HasNexusResistance = false;
            SaveGame.Player.HasBlindnessResistance = false;
            SaveGame.Player.HasNetherResistance = false;
            SaveGame.Player.HasFearResistance = false;
            SaveGame.Player.HasElementalVulnerability = false;
            SaveGame.Player.HasReflection = false;
            SaveGame.Player.HasFireShield = false;
            SaveGame.Player.HasLightningShield = false;
            SaveGame.Player.HasAntiMagic = false;
            SaveGame.Player.HasAntiTeleport = false;
            SaveGame.Player.HasAntiTheft = false;
            SaveGame.Player.HasAcidImmunity = false;
            SaveGame.Player.HasLightningImmunity = false;
            SaveGame.Player.HasFireImmunity = false;
            SaveGame.Player.HasColdImmunity = false;
            SaveGame.Player.InfravisionRange = SaveGame.Player.Race.Infravision;
            SaveGame.Player.SkillDisarmTraps = SaveGame.Player.Race.BaseDisarmBonus + SaveGame.Player.Profession.BaseDisarmBonus;
            SaveGame.Player.SkillUseDevice = SaveGame.Player.Race.BaseDeviceBonus + SaveGame.Player.Profession.BaseDeviceBonus;
            SaveGame.Player.SkillSavingThrow = SaveGame.Player.Race.BaseSaveBonus + SaveGame.Player.Profession.BaseSaveBonus;
            SaveGame.Player.SkillStealth = SaveGame.Player.Race.BaseStealthBonus + SaveGame.Player.Profession.BaseStealthBonus;
            SaveGame.Player.SkillSearching = SaveGame.Player.Race.BaseSearchBonus + SaveGame.Player.Profession.BaseSearchBonus;
            SaveGame.Player.SkillSearchFrequency = SaveGame.Player.Race.BaseSearchFrequency + SaveGame.Player.Profession.BaseSearchFrequency;
            SaveGame.Player.SkillMelee = SaveGame.Player.Race.BaseMeleeAttackBonus + SaveGame.Player.Profession.BaseMeleeAttackBonus;
            SaveGame.Player.SkillRanged = SaveGame.Player.Race.BaseRangedAttackBonus + SaveGame.Player.Profession.BaseRangedAttackBonus;
            SaveGame.Player.SkillThrowing = SaveGame.Player.Race.BaseRangedAttackBonus + SaveGame.Player.Profession.BaseRangedAttackBonus;
            SaveGame.Player.SkillDigging = 0;
            if ((SaveGame.Player.ProfessionIndex == CharacterClass.Warrior && SaveGame.Player.Level > 29) ||
                (SaveGame.Player.ProfessionIndex == CharacterClass.Paladin && SaveGame.Player.Level > 39) ||
                (SaveGame.Player.ProfessionIndex == CharacterClass.Fanatic && SaveGame.Player.Level > 39))
            {
                SaveGame.Player.HasFearResistance = true;
            }
            if (SaveGame.Player.ProfessionIndex == CharacterClass.Fanatic && SaveGame.Player.Level > 29)
            {
                SaveGame.Player.HasChaosResistance = true;
            }
            if (SaveGame.Player.ProfessionIndex == CharacterClass.Cultist && SaveGame.Player.Level > 19)
            {
                SaveGame.Player.HasChaosResistance = true;
            }
            if (SaveGame.Player.ProfessionIndex == CharacterClass.Mindcrafter)
            {
                if (SaveGame.Player.Level > 9)
                {
                    SaveGame.Player.HasFearResistance = true;
                }
                if (SaveGame.Player.Level > 19)
                {
                    SaveGame.Player.HasSustainWisdom = true;
                }
                if (SaveGame.Player.Level > 29)
                {
                    SaveGame.Player.HasConfusionResistance = true;
                }
                if (SaveGame.Player.Level > 39)
                {
                    SaveGame.Player.HasTelepathy = true;
                }
            }
            if (SaveGame.Player.ProfessionIndex == CharacterClass.Monk && SaveGame.Player.Level > 24 && !MartialArtistHeavyArmour())
            {
                SaveGame.Player.HasFreeAction = true;
            }
            if (SaveGame.Player.ProfessionIndex == CharacterClass.Mystic)
            {
                if (SaveGame.Player.Level > 9)
                {
                    SaveGame.Player.HasConfusionResistance = true;
                }
                if (SaveGame.Player.Level > 24)
                {
                    SaveGame.Player.HasFearResistance = true;
                }
                if (SaveGame.Player.Level > 29 && !MartialArtistHeavyArmour())
                {
                    SaveGame.Player.HasFreeAction = true;
                }
                if (SaveGame.Player.Level > 39)
                {
                    SaveGame.Player.HasTelepathy = true;
                }
            }
            if (SaveGame.Player.ProfessionIndex == CharacterClass.ChosenOne)
            {
                SaveGame.Player.HasGlow = true;
                if (SaveGame.Player.Level >= 2)
                {
                    SaveGame.Player.HasConfusionResistance = true;
                }
                if (SaveGame.Player.Level >= 4)
                {
                    SaveGame.Player.HasFearResistance = true;
                }
                if (SaveGame.Player.Level >= 6)
                {
                    SaveGame.Player.HasBlindnessResistance = true;
                }
                if (SaveGame.Player.Level >= 8)
                {
                    SaveGame.Player.HasFeatherFall = true;
                }
                if (SaveGame.Player.Level >= 10)
                {
                    SaveGame.Player.HasSeeInvisibility = true;
                }
                if (SaveGame.Player.Level >= 12)
                {
                    SaveGame.Player.HasSlowDigestion = true;
                }
                if (SaveGame.Player.Level >= 14)
                {
                    SaveGame.Player.HasSustainConstitution = true;
                }
                if (SaveGame.Player.Level >= 16)
                {
                    SaveGame.Player.HasPoisonResistance = true;
                }
                if (SaveGame.Player.Level >= 18)
                {
                    SaveGame.Player.HasSustainDexterity = true;
                }
                if (SaveGame.Player.Level >= 20)
                {
                    SaveGame.Player.HasSustainStrength = true;
                }
                if (SaveGame.Player.Level >= 22)
                {
                    SaveGame.Player.HasHoldLife = true;
                }
                if (SaveGame.Player.Level >= 24)
                {
                    SaveGame.Player.HasFreeAction = true;
                }
                if (SaveGame.Player.Level >= 26)
                {
                    SaveGame.Player.HasTelepathy = true;
                }
                if (SaveGame.Player.Level >= 28)
                {
                    SaveGame.Player.HasDarkResistance = true;
                }
                if (SaveGame.Player.Level >= 30)
                {
                    SaveGame.Player.HasLightResistance = true;
                }
                if (SaveGame.Player.Level >= 32)
                {
                    SaveGame.Player.HasSustainCharisma = true;
                }
                if (SaveGame.Player.Level >= 34)
                {
                    SaveGame.Player.HasSoundResistance = true;
                }
                if (SaveGame.Player.Level >= 36)
                {
                    SaveGame.Player.HasDisenchantResistance = true;
                }
                if (SaveGame.Player.Level >= 38)
                {
                    SaveGame.Player.HasRegeneration = true;
                }
                if (SaveGame.Player.Level >= 40)
                {
                    SaveGame.Player.HasSustainIntelligence = true;
                }
                if (SaveGame.Player.Level >= 42)
                {
                    SaveGame.Player.HasChaosResistance = true;
                }
                if (SaveGame.Player.Level >= 44)
                {
                    SaveGame.Player.HasSustainWisdom = true;
                }
                if (SaveGame.Player.Level >= 46)
                {
                    SaveGame.Player.HasNexusResistance = true;
                }
                if (SaveGame.Player.Level >= 48)
                {
                    SaveGame.Player.HasShardResistance = true;
                }
                if (SaveGame.Player.Level >= 50)
                {
                    SaveGame.Player.HasNetherResistance = true;
                }
            }
            SaveGame.Player.Race.CalcBonuses(SaveGame); 
            SaveGame.Player.Speed = 110;
            SaveGame.Player.MeleeAttacksPerRound = 1;
            SaveGame.Player.MissileAttacksPerRound = 1;
            SaveGame.Player.AmmunitionItemCategory = 0;
            for (i = 0; i < 6; i++)
            {
                SaveGame.Player.AbilityScores[i].Bonus += SaveGame.Player.Race.AbilityBonus[i] + SaveGame.Player.Profession.AbilityBonus[i];
            }
            SaveGame.Player.AbilityScores[Ability.Strength].Bonus += SaveGame.Player.Dna.StrengthBonus;
            SaveGame.Player.AbilityScores[Ability.Intelligence].Bonus += SaveGame.Player.Dna.IntelligenceBonus;
            SaveGame.Player.AbilityScores[Ability.Wisdom].Bonus += SaveGame.Player.Dna.WisdomBonus;
            SaveGame.Player.AbilityScores[Ability.Dexterity].Bonus += SaveGame.Player.Dna.DexterityBonus;
            SaveGame.Player.AbilityScores[Ability.Constitution].Bonus += SaveGame.Player.Dna.ConstitutionBonus;
            SaveGame.Player.AbilityScores[Ability.Charisma].Bonus += SaveGame.Player.Dna.CharismaBonus;
            SaveGame.Player.Speed += SaveGame.Player.Dna.SpeedBonus;
            SaveGame.Player.HasRegeneration |= SaveGame.Player.Dna.Regen;
            SaveGame.Player.SkillSearchFrequency += SaveGame.Player.Dna.SearchBonus;
            SaveGame.Player.SkillSearching += SaveGame.Player.Dna.SearchBonus;
            SaveGame.Player.InfravisionRange += SaveGame.Player.Dna.InfravisionBonus;
            SaveGame.Player.HasLightningShield |= SaveGame.Player.Dna.ElecHit;
            SaveGame.Player.HasFireShield |= SaveGame.Player.Dna.FireHit;
            SaveGame.Player.HasGlow |= SaveGame.Player.Dna.FireHit;
            SaveGame.Player.ArmourClassBonus += SaveGame.Player.Dna.ArmourClassBonus;
            SaveGame.Player.DisplayedArmourClassBonus += SaveGame.Player.Dna.ArmourClassBonus;
            SaveGame.Player.HasFeatherFall |= SaveGame.Player.Dna.FeatherFall;
            SaveGame.Player.HasFearResistance |= SaveGame.Player.Dna.ResFear;
            SaveGame.Player.HasTimeResistance |= SaveGame.Player.Dna.ResTime;
            SaveGame.Player.HasTelepathy |= SaveGame.Player.Dna.Esp;
            SaveGame.Player.SkillStealth += SaveGame.Player.Dna.StealthBonus;
            SaveGame.Player.HasFreeAction |= SaveGame.Player.Dna.FreeAction;
            SaveGame.Player.HasElementalVulnerability |= SaveGame.Player.Dna.Vulnerable;
            if (SaveGame.Player.Dna.MagicResistance)
            {
                SaveGame.Player.SkillSavingThrow += 15 + (SaveGame.Player.Level / 5);
            }
            if (SaveGame.Player.Dna.SuppressRegen)
            {
                SaveGame.Player.HasRegeneration = false;
            }
            if (SaveGame.Player.Dna.CharismaOverride)
            {
                SaveGame.Player.AbilityScores[Ability.Charisma].Bonus = 0;
            }
            if (SaveGame.Player.Dna.SustainAll)
            {
                SaveGame.Player.HasSustainConstitution = true;
                if (SaveGame.Player.Level > 9)
                {
                    SaveGame.Player.HasSustainStrength = true;
                }
                if (SaveGame.Player.Level > 19)
                {
                    SaveGame.Player.HasSustainDexterity = true;
                }
                if (SaveGame.Player.Level > 29)
                {
                    SaveGame.Player.HasSustainWisdom = true;
                }
                if (SaveGame.Player.Level > 39)
                {
                    SaveGame.Player.HasSustainIntelligence = true;
                }
                if (SaveGame.Player.Level > 49)
                {
                    SaveGame.Player.HasSustainCharisma = true;
                }
            }
            for (i = InventorySlot.MeleeWeapon; i < InventorySlot.Total; i++)
            {
                oPtr = SaveGame.Player.Inventory[i];
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                oPtr.RefreshFlagBasedProperties();
                if (oPtr.Characteristics.Str)
                {
                    SaveGame.Player.AbilityScores[Ability.Strength].Bonus += oPtr.TypeSpecificValue;
                }
                if (oPtr.Characteristics.Int)
                {
                    SaveGame.Player.AbilityScores[Ability.Intelligence].Bonus += oPtr.TypeSpecificValue;
                }
                if (oPtr.Characteristics.Wis)
                {
                    SaveGame.Player.AbilityScores[Ability.Wisdom].Bonus += oPtr.TypeSpecificValue;
                }
                if (oPtr.Characteristics.Dex)
                {
                    SaveGame.Player.AbilityScores[Ability.Dexterity].Bonus += oPtr.TypeSpecificValue;
                }
                if (oPtr.Characteristics.Con)
                {
                    SaveGame.Player.AbilityScores[Ability.Constitution].Bonus += oPtr.TypeSpecificValue;
                }
                if (oPtr.Characteristics.Cha)
                {
                    SaveGame.Player.AbilityScores[Ability.Charisma].Bonus += oPtr.TypeSpecificValue;
                }
                if (oPtr.Characteristics.Stealth)
                {
                    SaveGame.Player.SkillStealth += oPtr.TypeSpecificValue;
                }
                if (oPtr.Characteristics.Search)
                {
                    SaveGame.Player.SkillSearching += oPtr.TypeSpecificValue * 5;
                }
                if (oPtr.Characteristics.Search)
                {
                    SaveGame.Player.SkillSearchFrequency += oPtr.TypeSpecificValue * 5;
                }
                if (oPtr.Characteristics.Infra)
                {
                    SaveGame.Player.InfravisionRange += oPtr.TypeSpecificValue;
                }
                if (oPtr.Characteristics.Tunnel)
                {
                    SaveGame.Player.SkillDigging += oPtr.TypeSpecificValue * 20;
                }
                if (oPtr.Characteristics.Speed)
                {
                    SaveGame.Player.Speed += oPtr.TypeSpecificValue;
                }
                if (oPtr.Characteristics.Blows)
                {
                    extraBlows += oPtr.TypeSpecificValue;
                }
                if (oPtr.Characteristics.Impact)
                {
                    SaveGame.Player.HasQuakeWeapon = true;
                }
                if (oPtr.Characteristics.AntiTheft)
                {
                    SaveGame.Player.HasAntiTheft = true;
                }
                if (oPtr.Characteristics.XtraShots)
                {
                    extraShots++;
                }
                if (oPtr.Characteristics.Aggravate)
                {
                    SaveGame.Player.HasAggravation = true;
                }
                if (oPtr.Characteristics.Teleport)
                {
                    SaveGame.Player.HasRandomTeleport = true;
                }
                if (oPtr.Characteristics.DrainExp)
                {
                    SaveGame.Player.HasExperienceDrain = true;
                }
                if (oPtr.Characteristics.Blessed)
                {
                    SaveGame.Player.HasBlessedBlade = true;
                }
                if (oPtr.Characteristics.XtraMight)
                {
                    SaveGame.Player.HasExtraMight = true;
                }
                if (oPtr.Characteristics.SlowDigest)
                {
                    SaveGame.Player.HasSlowDigestion = true;
                }
                if (oPtr.Characteristics.Regen)
                {
                    SaveGame.Player.HasRegeneration = true;
                }
                if (oPtr.Characteristics.Telepathy)
                {
                    SaveGame.Player.HasTelepathy = true;
                }
                if (oPtr.Characteristics.Lightsource)
                {
                    SaveGame.Player.HasGlow = true;
                }
                if (oPtr.Characteristics.SeeInvis)
                {
                    SaveGame.Player.HasSeeInvisibility = true;
                }
                if (oPtr.Characteristics.Feather)
                {
                    SaveGame.Player.HasFeatherFall = true;
                }
                if (oPtr.Characteristics.FreeAct)
                {
                    SaveGame.Player.HasFreeAction = true;
                }
                if (oPtr.Characteristics.HoldLife)
                {
                    SaveGame.Player.HasHoldLife = true;
                }
                if (oPtr.Characteristics.Wraith)
                {
                    SaveGame.Player.TimedEtherealness = Math.Max(SaveGame.Player.TimedEtherealness, 20);
                }
                if (oPtr.Characteristics.ImFire)
                {
                    SaveGame.Player.HasFireImmunity = true;
                }
                if (oPtr.Characteristics.ImAcid)
                {
                    SaveGame.Player.HasAcidImmunity = true;
                }
                if (oPtr.Characteristics.ImCold)
                {
                    SaveGame.Player.HasColdImmunity = true;
                }
                if (oPtr.Characteristics.ImElec)
                {
                    SaveGame.Player.HasLightningImmunity = true;
                }
                if (oPtr.Characteristics.ResAcid)
                {
                    SaveGame.Player.HasAcidResistance = true;
                }
                if (oPtr.Characteristics.ResElec)
                {
                    SaveGame.Player.HasLightningResistance = true;
                }
                if (oPtr.Characteristics.ResFire)
                {
                    SaveGame.Player.HasFireResistance = true;
                }
                if (oPtr.Characteristics.ResCold)
                {
                    SaveGame.Player.HasColdResistance = true;
                }
                if (oPtr.Characteristics.ResPois)
                {
                    SaveGame.Player.HasPoisonResistance = true;
                }
                if (oPtr.Characteristics.ResFear)
                {
                    SaveGame.Player.HasFearResistance = true;
                }
                if (oPtr.Characteristics.ResConf)
                {
                    SaveGame.Player.HasConfusionResistance = true;
                }
                if (oPtr.Characteristics.ResSound)
                {
                    SaveGame.Player.HasSoundResistance = true;
                }
                if (oPtr.Characteristics.ResLight)
                {
                    SaveGame.Player.HasLightResistance = true;
                }
                if (oPtr.Characteristics.ResDark)
                {
                    SaveGame.Player.HasDarkResistance = true;
                }
                if (oPtr.Characteristics.ResChaos)
                {
                    SaveGame.Player.HasChaosResistance = true;
                }
                if (oPtr.Characteristics.ResDisen)
                {
                    SaveGame.Player.HasDisenchantResistance = true;
                }
                if (oPtr.Characteristics.ResShards)
                {
                    SaveGame.Player.HasShardResistance = true;
                }
                if (oPtr.Characteristics.ResNexus)
                {
                    SaveGame.Player.HasNexusResistance = true;
                }
                if (oPtr.Characteristics.ResBlind)
                {
                    SaveGame.Player.HasBlindnessResistance = true;
                }
                if (oPtr.Characteristics.ResNether)
                {
                    SaveGame.Player.HasNetherResistance = true;
                }
                if (oPtr.Characteristics.Reflect)
                {
                    SaveGame.Player.HasReflection = true;
                }
                if (oPtr.Characteristics.ShFire)
                {
                    SaveGame.Player.HasFireShield = true;
                }
                if (oPtr.Characteristics.ShElec)
                {
                    SaveGame.Player.HasLightningShield = true;
                }
                if (oPtr.Characteristics.NoMagic)
                {
                    SaveGame.Player.HasAntiMagic = true;
                }
                if (oPtr.Characteristics.NoTele)
                {
                    SaveGame.Player.HasAntiTeleport = true;
                }
                if (oPtr.Characteristics.SustStr)
                {
                    SaveGame.Player.HasSustainStrength = true;
                }
                if (oPtr.Characteristics.SustInt)
                {
                    SaveGame.Player.HasSustainIntelligence = true;
                }
                if (oPtr.Characteristics.SustWis)
                {
                    SaveGame.Player.HasSustainWisdom = true;
                }
                if (oPtr.Characteristics.SustDex)
                {
                    SaveGame.Player.HasSustainDexterity = true;
                }
                if (oPtr.Characteristics.SustCon)
                {
                    SaveGame.Player.HasSustainConstitution = true;
                }
                if (oPtr.Characteristics.SustCha)
                {
                    SaveGame.Player.HasSustainCharisma = true;
                }
                SaveGame.Player.BaseArmourClass += oPtr.BaseArmourClass;
                SaveGame.Player.DisplayedBaseArmourClass += oPtr.BaseArmourClass;
                SaveGame.Player.ArmourClassBonus += oPtr.BonusArmourClass;
                if (oPtr.IsKnown())
                {
                    SaveGame.Player.DisplayedArmourClassBonus += oPtr.BonusArmourClass;
                }
                if (i == InventorySlot.MeleeWeapon)
                {
                    continue;
                }
                if (i == InventorySlot.RangedWeapon)
                {
                    continue;
                }
                SaveGame.Player.AttackBonus += oPtr.BonusToHit;
                SaveGame.Player.DamageBonus += oPtr.BonusDamage;
                if (oPtr.IsKnown())
                {
                    SaveGame.Player.DisplayedAttackBonus += oPtr.BonusToHit;
                }
                if (oPtr.IsKnown())
                {
                    SaveGame.Player.DisplayedDamageBonus += oPtr.BonusDamage;
                }
            }
            if ((SaveGame.Player.ProfessionIndex == CharacterClass.Monk || SaveGame.Player.ProfessionIndex == CharacterClass.Mystic) && !MartialArtistHeavyArmour())
            {
                if (SaveGame.Player.Inventory[InventorySlot.Body].BaseItemCategory == null)
                {
                    SaveGame.Player.ArmourClassBonus += SaveGame.Player.Level * 3 / 2;
                    SaveGame.Player.DisplayedArmourClassBonus += SaveGame.Player.Level * 3 / 2;
                }
                if (SaveGame.Player.Inventory[InventorySlot.Cloak].BaseItemCategory == null && SaveGame.Player.Level > 15)
                {
                    SaveGame.Player.ArmourClassBonus += (SaveGame.Player.Level - 13) / 3;
                    SaveGame.Player.DisplayedArmourClassBonus += (SaveGame.Player.Level - 13) / 3;
                }
                if (SaveGame.Player.Inventory[InventorySlot.Arm].BaseItemCategory == null && SaveGame.Player.Level > 10)
                {
                    SaveGame.Player.ArmourClassBonus += (SaveGame.Player.Level - 8) / 3;
                    SaveGame.Player.DisplayedArmourClassBonus += (SaveGame.Player.Level - 8) / 3;
                }
                if (SaveGame.Player.Inventory[InventorySlot.Head].BaseItemCategory == null && SaveGame.Player.Level > 4)
                {
                    SaveGame.Player.ArmourClassBonus += (SaveGame.Player.Level - 2) / 3;
                    SaveGame.Player.DisplayedArmourClassBonus += (SaveGame.Player.Level - 2) / 3;
                }
                if (SaveGame.Player.Inventory[InventorySlot.Hands].BaseItemCategory == null)
                {
                    SaveGame.Player.ArmourClassBonus += SaveGame.Player.Level / 2;
                    SaveGame.Player.DisplayedArmourClassBonus += SaveGame.Player.Level / 2;
                }
                if (SaveGame.Player.Inventory[InventorySlot.Feet].BaseItemCategory == null)
                {
                    SaveGame.Player.ArmourClassBonus += SaveGame.Player.Level / 3;
                    SaveGame.Player.DisplayedArmourClassBonus += SaveGame.Player.Level / 3;
                }
            }
            if (SaveGame.Player.HasFireShield)
            {
                SaveGame.Player.HasGlow = true;
            }
            for (i = 0; i < 6; i++)
            {
                int ind;
                int top = SaveGame.Player.AbilityScores[i]
                    .ModifyStatValue(SaveGame.Player.AbilityScores[i].InnateMax, SaveGame.Player.AbilityScores[i].Bonus);
                if (SaveGame.Player.AbilityScores[i].AdjustedMax != top)
                {
                    SaveGame.Player.AbilityScores[i].AdjustedMax = top;
                    SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrStats);
                }
                int use = SaveGame.Player.AbilityScores[i]
                    .ModifyStatValue(SaveGame.Player.AbilityScores[i].Innate, SaveGame.Player.AbilityScores[i].Bonus);
                if (i == Ability.Charisma && SaveGame.Player.Dna.CharismaOverride)
                {
                    if (use < 8 + (2 * SaveGame.Player.Level))
                    {
                        use = 8 + (2 * SaveGame.Player.Level);
                    }
                }
                if (SaveGame.Player.AbilityScores[i].Adjusted != use)
                {
                    SaveGame.Player.AbilityScores[i].Adjusted = use;
                    SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrStats);
                }
                if (use <= 18)
                {
                    ind = use - 3;
                }
                else if (use <= 18 + 219)
                {
                    ind = 15 + ((use - 18) / 10);
                }
                else
                {
                    ind = 37;
                }
                if (SaveGame.Player.AbilityScores[i].TableIndex != ind)
                {
                    SaveGame.Player.AbilityScores[i].TableIndex = ind;
                    if (i == Ability.Constitution)
                    {
                        SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateHealth);
                    }
                    else if (i == Ability.Intelligence)
                    {
                        if (SaveGame.Player.Spellcasting.SpellStat == Ability.Intelligence)
                        {
                            SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMana | UpdateFlags.UpdateSpells);
                        }
                    }
                    else if (i == Ability.Wisdom)
                    {
                        if (SaveGame.Player.Spellcasting.SpellStat == Ability.Wisdom)
                        {
                            SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMana | UpdateFlags.UpdateSpells);
                        }
                    }
                    else if (i == Ability.Charisma)
                    {
                        if (SaveGame.Player.Spellcasting.SpellStat == Ability.Charisma)
                        {
                            SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMana | UpdateFlags.UpdateSpells);
                        }
                    }
                }
            }
            if (SaveGame.Player.TimedStun > 50)
            {
                SaveGame.Player.AttackBonus -= 20;
                SaveGame.Player.DisplayedAttackBonus -= 20;
                SaveGame.Player.DamageBonus -= 20;
                SaveGame.Player.DisplayedDamageBonus -= 20;
            }
            else if (SaveGame.Player.TimedStun != 0)
            {
                SaveGame.Player.AttackBonus -= 5;
                SaveGame.Player.DisplayedAttackBonus -= 5;
                SaveGame.Player.DamageBonus -= 5;
                SaveGame.Player.DisplayedDamageBonus -= 5;
            }
            if (SaveGame.Player.TimedInvulnerability != 0)
            {
                SaveGame.Player.ArmourClassBonus += 100;
                SaveGame.Player.DisplayedArmourClassBonus += 100;
            }
            if (SaveGame.Player.TimedEtherealness != 0)
            {
                SaveGame.Player.ArmourClassBonus += 100;
                SaveGame.Player.DisplayedArmourClassBonus += 100;
                SaveGame.Player.HasReflection = true;
            }
            if (SaveGame.Player.TimedBlessing != 0)
            {
                SaveGame.Player.ArmourClassBonus += 5;
                SaveGame.Player.DisplayedArmourClassBonus += 5;
                SaveGame.Player.AttackBonus += 10;
                SaveGame.Player.DisplayedAttackBonus += 10;
            }
            if (SaveGame.Player.TimedStoneskin != 0)
            {
                SaveGame.Player.ArmourClassBonus += 50;
                SaveGame.Player.DisplayedArmourClassBonus += 50;
            }
            if (SaveGame.Player.TimedHeroism != 0)
            {
                SaveGame.Player.AttackBonus += 12;
                SaveGame.Player.DisplayedAttackBonus += 12;
            }
            if (SaveGame.Player.TimedSuperheroism != 0)
            {
                SaveGame.Player.AttackBonus += 24;
                SaveGame.Player.DisplayedAttackBonus += 24;
                SaveGame.Player.ArmourClassBonus -= 10;
                SaveGame.Player.DisplayedArmourClassBonus -= 10;
            }
            if (SaveGame.Player.TimedHaste != 0)
            {
                SaveGame.Player.Speed += 10;
            }
            if (SaveGame.Player.TimedSlow != 0)
            {
                SaveGame.Player.Speed -= 10;
            }
            if ((SaveGame.Player.ProfessionIndex == CharacterClass.Monk || SaveGame.Player.ProfessionIndex == CharacterClass.Mystic) && !MartialArtistHeavyArmour())
            {
                SaveGame.Player.Speed += SaveGame.Player.Level / 10;
            }
            if (SaveGame.Player.TimedTelepathy != 0)
            {
                SaveGame.Player.HasTelepathy = true;
            }
            if (SaveGame.Player.TimedSeeInvisibility != 0)
            {
                SaveGame.Player.HasSeeInvisibility = true;
            }
            if (SaveGame.Player.TimedInfravision != 0)
            {
                SaveGame.Player.InfravisionRange++;
            }
            if (SaveGame.Player.HasChaosResistance)
            {
                SaveGame.Player.HasConfusionResistance = true;
            }
            if (SaveGame.Player.TimedHeroism != 0 || SaveGame.Player.TimedSuperheroism != 0)
            {
                SaveGame.Player.HasFearResistance = true;
            }
            if (SaveGame.Player.HasTelepathy != oldTelepathy)
            {
                SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
            }
            if (SaveGame.Player.HasSeeInvisibility != oldSeeInv)
            {
                SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
            }
            int j = SaveGame.Player.WeightCarried;
            i = WeightLimit();
            if (j > i / 2)
            {
                SaveGame.Player.Speed -= (j - (i / 2)) / (i / 10);
            }
            if (SaveGame.Player.Food >= Constants.PyFoodMax)
            {
                SaveGame.Player.Speed -= 10;
            }
            if (SaveGame.Player.IsSearching)
            {
                SaveGame.Player.Speed -= 10;
            }
            if (SaveGame.Player.Speed != oldSpeed)
            {
                SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrSpeed);
            }
            SaveGame.Player.ArmourClassBonus += SaveGame.Player.AbilityScores[Ability.Dexterity].DexArmourClassBonus;
            SaveGame.Player.DamageBonus += SaveGame.Player.AbilityScores[Ability.Strength].StrDamageBonus;
            SaveGame.Player.AttackBonus += SaveGame.Player.AbilityScores[Ability.Dexterity].DexAttackBonus;
            SaveGame.Player.AttackBonus += SaveGame.Player.AbilityScores[Ability.Strength].StrAttackBonus;
            SaveGame.Player.DisplayedArmourClassBonus += SaveGame.Player.AbilityScores[Ability.Dexterity].DexArmourClassBonus;
            SaveGame.Player.DisplayedDamageBonus += SaveGame.Player.AbilityScores[Ability.Strength].StrDamageBonus;
            SaveGame.Player.DisplayedAttackBonus += SaveGame.Player.AbilityScores[Ability.Dexterity].DexAttackBonus;
            SaveGame.Player.DisplayedAttackBonus += SaveGame.Player.AbilityScores[Ability.Strength].StrAttackBonus;
            if (SaveGame.Player.DisplayedBaseArmourClass != oldDisAc || SaveGame.Player.DisplayedArmourClassBonus != oldDisToA)
            {
                SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrArmor);
            }
            int hold = SaveGame.Player.AbilityScores[Ability.Strength].StrMaxWeaponWeight;
            oPtr = SaveGame.Player.Inventory[InventorySlot.RangedWeapon];
            SaveGame.Player.HasHeavyBow = false;
            if (hold < oPtr.Weight / 10)
            {
                SaveGame.Player.AttackBonus += 2 * (hold - (oPtr.Weight / 10));
                SaveGame.Player.DisplayedAttackBonus += 2 * (hold - (oPtr.Weight / 10));
                SaveGame.Player.HasHeavyBow = true;
            }
            if (oPtr.BaseItemCategory != null && !SaveGame.Player.HasHeavyBow)
            {
                // Since this came from the ranged weapon, we know it is a missile weapon type/bow.
                BowWeaponItemClass missileWeaponItemCategory = (BowWeaponItemClass)oPtr.BaseItemCategory;
                SaveGame.Player.AmmunitionItemCategory = missileWeaponItemCategory.AmmunitionItemCategory;
                if (SaveGame.Player.ProfessionIndex == CharacterClass.Ranger && SaveGame.Player.AmmunitionItemCategory == ItemTypeEnum.Arrow)
                {
                    if (SaveGame.Player.Level >= 20)
                    {
                        SaveGame.Player.MissileAttacksPerRound++;
                    }
                    if (SaveGame.Player.Level >= 40)
                    {
                        SaveGame.Player.MissileAttacksPerRound++;
                    }
                }
                if (SaveGame.Player.ProfessionIndex == CharacterClass.Warrior && SaveGame.Player.AmmunitionItemCategory <= ItemTypeEnum.Bolt &&
                    SaveGame.Player.AmmunitionItemCategory >= ItemTypeEnum.Shot)
                {
                    if (SaveGame.Player.Level >= 25)
                    {
                        SaveGame.Player.MissileAttacksPerRound++;
                    }
                    if (SaveGame.Player.Level >= 50)
                    {
                        SaveGame.Player.MissileAttacksPerRound++;
                    }
                }
                SaveGame.Player.MissileAttacksPerRound += extraShots;
                if (SaveGame.Player.MissileAttacksPerRound < 1)
                {
                    SaveGame.Player.MissileAttacksPerRound = 1;
                }
            }
            oPtr = SaveGame.Player.Inventory[InventorySlot.MeleeWeapon];
            SaveGame.Player.HasHeavyWeapon = false;
            if (hold < oPtr.Weight / 10)
            {
                SaveGame.Player.AttackBonus += 2 * (hold - (oPtr.Weight / 10));
                SaveGame.Player.DisplayedAttackBonus += 2 * (hold - (oPtr.Weight / 10));
                SaveGame.Player.HasHeavyWeapon = true;
            }
            if (oPtr.BaseItemCategory != null && !SaveGame.Player.HasHeavyWeapon)
            {
                int num = 0, wgt = 0, mul = 0;
                switch (SaveGame.Player.ProfessionIndex)
                {
                    case CharacterClass.Warrior:
                        num = 6;
                        wgt = 30;
                        mul = 5;
                        break;

                    case CharacterClass.Mage:
                    case CharacterClass.HighMage:
                    case CharacterClass.Cultist:
                    case CharacterClass.Channeler:
                        num = 4;
                        wgt = 40;
                        mul = 2;
                        break;

                    case CharacterClass.Priest:
                    case CharacterClass.Mindcrafter:
                    case CharacterClass.Druid:
                    case CharacterClass.ChosenOne:
                        num = 5;
                        wgt = 35;
                        mul = 3;
                        break;

                    case CharacterClass.Rogue:
                        num = 5;
                        wgt = 30;
                        mul = 3;
                        break;

                    case CharacterClass.Ranger:
                        num = 5;
                        wgt = 35;
                        mul = 4;
                        break;

                    case CharacterClass.Paladin:
                        num = 5;
                        wgt = 30;
                        mul = 4;
                        break;

                    case CharacterClass.WarriorMage:
                        num = 5;
                        wgt = 35;
                        mul = 3;
                        break;

                    case CharacterClass.Fanatic:
                        num = 5;
                        wgt = 30;
                        mul = 4;
                        break;

                    case CharacterClass.Monk:
                    case CharacterClass.Mystic:
                        num = SaveGame.Player.Level < 40 ? 3 : 4;
                        wgt = 40;
                        mul = 4;
                        break;
                }
                int div = oPtr.Weight < wgt ? wgt : oPtr.Weight;
                int strIndex = SaveGame.Player.AbilityScores[Ability.Strength].StrAttackSpeedComponent * mul / div;
                if (strIndex > 11)
                {
                    strIndex = 11;
                }
                int dexIndex = SaveGame.Player.AbilityScores[Ability.Dexterity].DexAttackSpeedComponent;
                if (dexIndex > 11)
                {
                    dexIndex = 11;
                }
                SaveGame.Player.MeleeAttacksPerRound = _blowsTable[strIndex][dexIndex];
                if (SaveGame.Player.MeleeAttacksPerRound > num)
                {
                    SaveGame.Player.MeleeAttacksPerRound = num;
                }
                SaveGame.Player.MeleeAttacksPerRound += extraBlows;
                if (SaveGame.Player.ProfessionIndex == CharacterClass.Warrior)
                {
                    SaveGame.Player.MeleeAttacksPerRound += SaveGame.Player.Level / 15;
                }
                if (SaveGame.Player.MeleeAttacksPerRound < 1)
                {
                    SaveGame.Player.MeleeAttacksPerRound = 1;
                }
                SaveGame.Player.SkillDigging += oPtr.Weight / 10;
            }
            else if ((SaveGame.Player.ProfessionIndex == CharacterClass.Monk || SaveGame.Player.ProfessionIndex == CharacterClass.Mystic) && MartialArtistEmptyHands())
            {
                SaveGame.Player.MeleeAttacksPerRound = 0;
                if (SaveGame.Player.Level > 9)
                {
                    SaveGame.Player.MeleeAttacksPerRound++;
                }
                if (SaveGame.Player.Level > 19)
                {
                    SaveGame.Player.MeleeAttacksPerRound++;
                }
                if (SaveGame.Player.Level > 29)
                {
                    SaveGame.Player.MeleeAttacksPerRound++;
                }
                if (SaveGame.Player.Level > 34)
                {
                    SaveGame.Player.MeleeAttacksPerRound++;
                }
                if (SaveGame.Player.Level > 39)
                {
                    SaveGame.Player.MeleeAttacksPerRound++;
                }
                if (SaveGame.Player.Level > 44)
                {
                    SaveGame.Player.MeleeAttacksPerRound++;
                }
                if (SaveGame.Player.Level > 49)
                {
                    SaveGame.Player.MeleeAttacksPerRound++;
                }
                if (MartialArtistHeavyArmour())
                {
                    SaveGame.Player.MeleeAttacksPerRound /= 2;
                }
                SaveGame.Player.MeleeAttacksPerRound += 1 + extraBlows;
                if (!MartialArtistHeavyArmour())
                {
                    SaveGame.Player.AttackBonus += SaveGame.Player.Level / 3;
                    SaveGame.Player.DamageBonus += SaveGame.Player.Level / 3;
                    SaveGame.Player.DisplayedAttackBonus += SaveGame.Player.Level / 3;
                    SaveGame.Player.DisplayedDamageBonus += SaveGame.Player.Level / 3;
                }
            }
            SaveGame.Player.HasUnpriestlyWeapon = false;
            SaveGame.MartialArtistArmourAux = false;
            if (SaveGame.Player.ProfessionIndex == CharacterClass.Warrior)
            {
                SaveGame.Player.AttackBonus += SaveGame.Player.Level / 5;
                SaveGame.Player.DamageBonus += SaveGame.Player.Level / 5;
                SaveGame.Player.DisplayedAttackBonus += SaveGame.Player.Level / 5;
                SaveGame.Player.DisplayedDamageBonus += SaveGame.Player.Level / 5;
            }
            if ((SaveGame.Player.ProfessionIndex == CharacterClass.Priest || SaveGame.Player.ProfessionIndex == CharacterClass.Druid) &&
                !SaveGame.Player.HasBlessedBlade && (oPtr.Category == ItemTypeEnum.Sword ||
                                        oPtr.Category == ItemTypeEnum.Polearm))
            {
                SaveGame.Player.AttackBonus -= 2;
                SaveGame.Player.DamageBonus -= 2;
                SaveGame.Player.DisplayedAttackBonus -= 2;
                SaveGame.Player.DisplayedDamageBonus -= 2;
                SaveGame.Player.HasUnpriestlyWeapon = true;
            }
            
            // Cultists that are NOT wielding the blade of chaos lose bonuses for being an unpriestly weapon.
            // todo: this should by characterclass
            if (SaveGame.Player.ProfessionIndex == CharacterClass.Cultist &&
                SaveGame.Player.Inventory[InventorySlot.MeleeWeapon].BaseItemCategory != null &&
                !typeof(SwordBladeofChaos).IsAssignableFrom(oPtr.BaseItemCategory.GetType()))
            {
                oPtr.RefreshFlagBasedProperties();
                if (!oPtr.Characteristics.Chaotic)
                {
                    SaveGame.Player.AttackBonus -= 10;
                    SaveGame.Player.DamageBonus -= 10;
                    SaveGame.Player.DisplayedAttackBonus -= 10;
                    SaveGame.Player.DisplayedDamageBonus -= 10;
                    SaveGame.Player.HasUnpriestlyWeapon = true;
                }
            }
            if (MartialArtistHeavyArmour())
            {
                SaveGame.MartialArtistArmourAux = true;
            }
            SaveGame.Player.SkillStealth++;
            SaveGame.Player.SkillDisarmTraps += SaveGame.Player.AbilityScores[Ability.Dexterity].DexDisarmBonus;
            SaveGame.Player.SkillDisarmTraps += SaveGame.Player.AbilityScores[Ability.Intelligence].IntDisarmBonus;
            SaveGame.Player.SkillUseDevice += SaveGame.Player.AbilityScores[Ability.Intelligence].IntUseDeviceBonus;
            SaveGame.Player.SkillSavingThrow += SaveGame.Player.AbilityScores[Ability.Wisdom].WisSavingThrowBonus;
            SaveGame.Player.SkillDigging += SaveGame.Player.AbilityScores[Ability.Strength].StrDiggingBonus;
            SaveGame.Player.SkillDisarmTraps += (SaveGame.Player.Profession.DisarmBonusPerLevel * SaveGame.Player.Level) / 10;
            SaveGame.Player.SkillUseDevice += (SaveGame.Player.Profession.DeviceBonusPerLevel * SaveGame.Player.Level) / 10;
            SaveGame.Player.SkillSavingThrow += (SaveGame.Player.Profession.SaveBonusPerLevel * SaveGame.Player.Level) / 10;
            SaveGame.Player.SkillStealth += (SaveGame.Player.Profession.StealthBonusPerLevel * SaveGame.Player.Level) / 10;
            SaveGame.Player.SkillSearching += (SaveGame.Player.Profession.SearchBonusPerLevel * SaveGame.Player.Level) / 10;
            SaveGame.Player.SkillSearchFrequency += (SaveGame.Player.Profession.SearchFrequencyPerLevel * SaveGame.Player.Level) / 10;
            SaveGame.Player.SkillMelee += (SaveGame.Player.Profession.MeleeAttackBonusPerLevel * SaveGame.Player.Level) / 10;
            SaveGame.Player.SkillRanged += (SaveGame.Player.Profession.RangedAttackBonusPerLevel * SaveGame.Player.Level) / 10;
            SaveGame.Player.SkillThrowing += (SaveGame.Player.Profession.RangedAttackBonusPerLevel * SaveGame.Player.Level) / 10;
            if (SaveGame.Player.SkillStealth > 30)
            {
                SaveGame.Player.SkillStealth = 30;
            }
            if (SaveGame.Player.SkillStealth < 0)
            {
                SaveGame.Player.SkillStealth = 0;
            }
            if (SaveGame.Player.SkillDigging < 1)
            {
                SaveGame.Player.SkillDigging = 1;
            }
            if (SaveGame.Player.HasAntiMagic && SaveGame.Player.SkillSavingThrow < 95)
            {
                SaveGame.Player.SkillSavingThrow = 95;
            }
            if (SaveGame.CharacterXtra)
            {
                return;
            }
            if (SaveGame.Player.OldHeavyBow != SaveGame.Player.HasHeavyBow)
            {
                if (SaveGame.Player.HasHeavyBow)
                {
                    SaveGame.MsgPrint("You have trouble wielding such a heavy bow.");
                }
                else if (SaveGame.Player.Inventory[InventorySlot.RangedWeapon].BaseItemCategory != null)
                {
                    SaveGame.MsgPrint("You have no trouble wielding your bow.");
                }
                else
                {
                    SaveGame.MsgPrint("You feel relieved to put down your heavy bow.");
                }
                SaveGame.Player.OldHeavyBow = SaveGame.Player.HasHeavyBow;
            }
            if (SaveGame.Player.OldHeavyWeapon != SaveGame.Player.HasHeavyWeapon)
            {
                if (SaveGame.Player.HasHeavyWeapon)
                {
                    SaveGame.MsgPrint("You have trouble wielding such a heavy weapon.");
                }
                else if (SaveGame.Player.Inventory[InventorySlot.MeleeWeapon].BaseItemCategory != null)
                {
                    SaveGame.MsgPrint("You have no trouble wielding your weapon.");
                }
                else
                {
                    SaveGame.MsgPrint("You feel relieved to put down your heavy weapon.");
                }
                SaveGame.Player.OldHeavyWeapon = SaveGame.Player.HasHeavyWeapon;
            }
            if (SaveGame.Player.OldUnpriestlyWeapon != SaveGame.Player.HasUnpriestlyWeapon)
            {
                if (SaveGame.Player.HasUnpriestlyWeapon)
                {
                    SaveGame.MsgPrint(SaveGame.Player.ProfessionIndex == CharacterClass.Cultist
                        ? "Your weapon restricts the flow of chaos through you."
                        : "You do not feel comfortable with your weapon.");
                }
                else if (SaveGame.Player.Inventory[InventorySlot.MeleeWeapon].BaseItemCategory != null)
                {
                    SaveGame.MsgPrint("You feel comfortable with your weapon.");
                }
                else
                {
                    SaveGame.MsgPrint(SaveGame.Player.ProfessionIndex == CharacterClass.Cultist
                        ? "Chaos flows freely through you again."
                        : "You feel more comfortable after removing your weapon.");
                }
                SaveGame.Player.OldUnpriestlyWeapon = SaveGame.Player.HasUnpriestlyWeapon;
            }
            if ((SaveGame.Player.ProfessionIndex == CharacterClass.Monk || SaveGame.Player.ProfessionIndex == CharacterClass.Mystic) && SaveGame.MartialArtistArmourAux !=
                SaveGame.MartialArtistNotifyAux)
            {
                SaveGame.MsgPrint(MartialArtistHeavyArmour()
                    ? "The weight of your armour disrupts your balance."
                    : "You regain your balance.");
                SaveGame.MartialArtistNotifyAux = SaveGame.MartialArtistArmourAux;
            }
        }

        public void CalcHitpoints()
        {
            int bonus = SaveGame.Player.AbilityScores[Ability.Constitution].ConHealthBonus;
            int mhp = SaveGame.Player.PlayerHp[SaveGame.Player.Level - 1] + (bonus * SaveGame.Player.Level / 2);
            if (mhp < SaveGame.Player.Level + 1)
            {
                mhp = SaveGame.Player.Level + 1;
            }
            if (SaveGame.Player.TimedHeroism != 0)
            {
                mhp += 10;
            }
            if (SaveGame.Player.TimedSuperheroism != 0)
            {
                mhp += 30;
            }
            var mult = SaveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Nath_Horthah).AdjustedFavour + 10;
            mhp *= mult;
            mhp /= 10;
            if (SaveGame.Player.MaxHealth != mhp)
            {
                if (SaveGame.Player.Health >= mhp)
                {
                    SaveGame.Player.Health = mhp;
                    SaveGame.Player.FractionalHealth = 0;
                }
                SaveGame.Player.MaxHealth = mhp;
                SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrHp);
            }
        }

        public void CalcMana()
        {
            int levels;
            switch (SaveGame.Player.Spellcasting.Type)
            {
                case CastingType.None:
                    return;

                case CastingType.Arcane:
                case CastingType.Divine:
                    levels = SaveGame.Player.Level - SaveGame.Player.Spellcasting.SpellFirst + 1;
                    break;

                case CastingType.Mentalism:
                case CastingType.Channeling:
                    levels = SaveGame.Player.Level;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (levels < 0)
            {
                levels = 0;
            }
            int msp = SaveGame.Player.AbilityScores[SaveGame.Player.Spellcasting.SpellStat].ManaBonus * levels / 2;
            if (msp != 0)
            {
                msp++;
            }
            if (msp != 0 && SaveGame.Player.ProfessionIndex == CharacterClass.HighMage)
            {
                msp += msp / 4;
            }
            if (SaveGame.Player.Spellcasting.Type == CastingType.Arcane)
            {
                SaveGame.Player.HasRestrictingGloves = false;
                Item oPtr = SaveGame.Player.Inventory[InventorySlot.Hands];
                oPtr.RefreshFlagBasedProperties();
                if (oPtr.BaseItemCategory != null && !oPtr.Characteristics.FreeAct && !oPtr.Characteristics.Dex && oPtr.TypeSpecificValue > 0)
                {
                    SaveGame.Player.HasRestrictingGloves = true;
                    msp = 3 * msp / 4;
                }
                SaveGame.Player.HasRestrictingArmour = false;
                int curWgt = 0;
                curWgt += SaveGame.Player.Inventory[InventorySlot.Body].Weight;
                curWgt += SaveGame.Player.Inventory[InventorySlot.Head].Weight;
                curWgt += SaveGame.Player.Inventory[InventorySlot.Arm].Weight;
                curWgt += SaveGame.Player.Inventory[InventorySlot.Cloak].Weight;
                curWgt += SaveGame.Player.Inventory[InventorySlot.Hands].Weight;
                curWgt += SaveGame.Player.Inventory[InventorySlot.Feet].Weight;
                int maxWgt = SaveGame.Player.Spellcasting.SpellWeight;
                if ((curWgt - maxWgt) / 10 > 0)
                {
                    SaveGame.Player.HasRestrictingArmour = true;
                    msp -= (curWgt - maxWgt) / 10;
                }
            }
            if (msp < 0)
            {
                msp = 0;
            }
            var mult = SaveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Tamash).AdjustedFavour + 10;
            msp *= mult;
            msp /= 10;
            if (SaveGame.Player.MaxMana != msp)
            {
                if (SaveGame.Player.Mana >= msp)
                {
                    SaveGame.Player.Mana = msp;
                    SaveGame.Player.FractionalMana = 0;
                }
                SaveGame.Player.MaxMana = msp;
                SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrMana);
            }
            if (SaveGame.CharacterXtra)
            {
                return;
            }
            if (SaveGame.Player.OldRestrictingGloves != SaveGame.Player.HasRestrictingGloves)
            {
                SaveGame.MsgPrint(SaveGame.Player.HasRestrictingGloves
                    ? "Your covered hands feel unsuitable for spellcasting."
                    : "Your hands feel more suitable for spellcasting.");
                SaveGame.Player.OldRestrictingGloves = SaveGame.Player.HasRestrictingGloves;
            }
            if (SaveGame.Player.OldRestrictingArmour != SaveGame.Player.HasRestrictingArmour)
            {
                SaveGame.MsgPrint(SaveGame.Player.HasRestrictingArmour
                    ? "The weight of your armour encumbers your movement."
                    : "You feel able to move more freely.");
                SaveGame.Player.OldRestrictingArmour = SaveGame.Player.HasRestrictingArmour;
            }
        }

        public void CalcSpells()
        {
            int i, j;
            Spell sPtr;
            if (SaveGame.Player == null)
            {
                return;
            }
            string p = SaveGame.Player.Spellcasting.Type == CastingType.Arcane ? "spell" : "prayer";
            if (SaveGame.Player.Spellcasting.Type == CastingType.None)
            {
                return;
            }
            if (SaveGame.Player.Realm1 == Realm.None)
            {
                return;
            }
            if (SaveGame.CharacterXtra)
            {
                return;
            }
            int levels = SaveGame.Player.Level - SaveGame.Player.Spellcasting.SpellFirst + 1;
            if (levels < 0)
            {
                levels = 0;
            }
            int numAllowed = SaveGame.Player.AbilityScores[SaveGame.Player.Spellcasting.SpellStat].HalfSpellsPerLevel * levels / 2;
            int numKnown = 0;
            for (j = 0; j < 64; j++)
            {
                if (SaveGame.Player.Spellcasting.Spells[j / 32][j % 32].Learned)
                {
                    numKnown++;
                }
            }
            SaveGame.Player.SpareSpellSlots = numAllowed - numKnown;
            for (i = 63; i >= 0; i--)
            {
                if (numKnown == 0)
                {
                    break;
                }
                j = SaveGame.Player.Spellcasting.SpellOrder[i];
                if (j >= 99)
                {
                    continue;
                }
                sPtr = SaveGame.Player.Spellcasting.Spells[j / 32][j % 32];
                if (sPtr.Level <= SaveGame.Player.Level)
                {
                    continue;
                }
                if (!sPtr.Learned)
                {
                    continue;
                }
                sPtr.Forgotten = true;
                sPtr.Learned = false;
                numKnown--;
                SaveGame.MsgPrint($"You have forgotten the {p} of {sPtr.Name}.");
                SaveGame.Player.SpareSpellSlots++;
            }
            for (i = 63; i >= 0; i--)
            {
                if (SaveGame.Player.SpareSpellSlots >= 0)
                {
                    break;
                }
                if (numKnown == 0)
                {
                    break;
                }
                j = SaveGame.Player.Spellcasting.SpellOrder[i];
                if (j >= 99)
                {
                    continue;
                }
                sPtr = SaveGame.Player.Spellcasting.Spells[j / 32][j % 32];
                if (!sPtr.Learned)
                {
                    continue;
                }
                sPtr.Forgotten = true;
                sPtr.Learned = false;
                numKnown--;
                SaveGame.MsgPrint($"You have forgotten the {p} of {sPtr.Name}.");
                SaveGame.Player.SpareSpellSlots++;
            }
            int forgottenTotal = 0;
            for (int l = 0; l < 64; l++)
            {
                if (SaveGame.Player.Spellcasting.Spells[l / 32][l % 32].Forgotten)
                {
                    forgottenTotal++;
                }
            }
            for (i = 0; i < 64; i++)
            {
                if (SaveGame.Player.SpareSpellSlots <= 0)
                {
                    break;
                }
                if (forgottenTotal == 0)
                {
                    break;
                }
                j = SaveGame.Player.Spellcasting.SpellOrder[i];
                if (j >= 99)
                {
                    break;
                }
                sPtr = SaveGame.Player.Spellcasting.Spells[j / 32][j % 32];
                if (sPtr.Level > SaveGame.Player.Level)
                {
                    continue;
                }
                if (!sPtr.Forgotten)
                {
                    continue;
                }
                sPtr.Forgotten = false;
                sPtr.Learned = true;
                forgottenTotal--;
                if (!SaveGame.FullScreenOverlay)
                {
                    SaveGame.MsgPrint($"You have remembered the {p} of {sPtr.Name}.");
                }
                SaveGame.Player.SpareSpellSlots--;
            }
            int k = 0;
            int limit = SaveGame.Player.Realm2 == Realm.None ? 32 : 64;
            for (j = 0; j < limit; j++)
            {
                sPtr = SaveGame.Player.Spellcasting.Spells[j / 32][j % 32];
                if (sPtr.Level > SaveGame.Player.Level)
                {
                    continue;
                }
                if (sPtr.Learned)
                {
                    continue;
                }
                k++;
            }
            if (SaveGame.Player.Realm2 == 0)
            {
                if (k > 32)
                {
                    k = 32;
                }
            }
            else
            {
                if (k > 64)
                {
                    k = 64;
                }
            }
            if (SaveGame.Player.SpareSpellSlots > k)
            {
                SaveGame.Player.SpareSpellSlots = k;
            }
            if (SaveGame.Player.OldSpareSpellSlots != SaveGame.Player.SpareSpellSlots)
            {
                if (SaveGame.Player.SpareSpellSlots != 0)
                {
                    if (!SaveGame.FullScreenOverlay)
                    {
                        string suffix = SaveGame.Player.SpareSpellSlots != 1 ? "s" : "";
                        SaveGame.MsgPrint($"You can learn {SaveGame.Player.SpareSpellSlots} more {p}{suffix}.");
                    }
                }
                SaveGame.Player.OldSpareSpellSlots = SaveGame.Player.SpareSpellSlots;
                SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrStudy);
            }
        }

        public void CalcTorch()
        {
            SaveGame.Player.LightLevel = 0;
            for (int i = InventorySlot.MeleeWeapon; i < InventorySlot.Total; i++)
            {
                Item oPtr = SaveGame.Player.Inventory[i];
                if (i == InventorySlot.Lightsource && oPtr.BaseItemCategory != null &&
                    oPtr.Category == ItemTypeEnum.Light)
                {
                    if (oPtr.ItemSubCategory == LightType.Torch && oPtr.TypeSpecificValue > 0)
                    {
                        SaveGame.Player.LightLevel++;
                        continue;
                    }
                    if (oPtr.ItemSubCategory == LightType.Lantern && oPtr.TypeSpecificValue > 0)
                    {
                        SaveGame.Player.LightLevel += 2;
                        continue;
                    }
                    if (oPtr.ItemSubCategory == LightType.Orb)
                    {
                        SaveGame.Player.LightLevel += 2;
                        continue;
                    }
                    if (oPtr.IsFixedArtifact())
                    {
                        SaveGame.Player.LightLevel += 3;
                    }
                }
                else
                {
                    if (oPtr.BaseItemCategory == null)
                    {
                        continue;
                    }
                    oPtr.RefreshFlagBasedProperties();
                    if (oPtr.Characteristics.Lightsource)
                    {
                        SaveGame.Player.LightLevel++;
                    }
                }
            }
            if (SaveGame.Player.LightLevel > 5)
            {
                SaveGame.Player.LightLevel = 5;
            }
            if (SaveGame.Player.LightLevel == 0 && SaveGame.Player.HasGlow)
            {
                SaveGame.Player.LightLevel = 1;
            }
            if (SaveGame.Player.OldLightLevel != SaveGame.Player.LightLevel)
            {
                SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateLight);
                SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
                SaveGame.Player.OldLightLevel = SaveGame.Player.LightLevel;
            }
        }

        public void HealthRedraw()
        {
            if (SaveGame.TrackedMonsterIndex == 0)
            {
                SaveGame.Erase(ScreenLocation.RowInfo, ScreenLocation.ColInfo, 12);
                SaveGame.Erase(ScreenLocation.RowInfo - 3, ScreenLocation.ColInfo, 12);
                SaveGame.Erase(ScreenLocation.RowInfo - 2, ScreenLocation.ColInfo, 12);
                SaveGame.Erase(ScreenLocation.RowInfo - 1, ScreenLocation.ColInfo, 12);
            }
            else if (!SaveGame.Level.Monsters[SaveGame.TrackedMonsterIndex].IsVisible)
            {
                SaveGame.Print(Colour.White, "[----------]", ScreenLocation.RowInfo, ScreenLocation.ColInfo, 12);
            }
            else if (SaveGame.Player.TimedHallucinations != 0)
            {
                SaveGame.Print(Colour.White, "[----------]", ScreenLocation.RowInfo, ScreenLocation.ColInfo, 12);
            }
            else if (SaveGame.Level.Monsters[SaveGame.TrackedMonsterIndex].Health < 0)
            {
                SaveGame.Print(Colour.White, "[----------]", ScreenLocation.RowInfo, ScreenLocation.ColInfo, 12);
            }
            else
            {
                Monster mPtr = SaveGame.Level.Monsters[SaveGame.TrackedMonsterIndex];
                Colour attr = Colour.Red;
                string smb = "**********";
                int pct = 100 * mPtr.Health / mPtr.MaxHealth;
                if (pct >= 10)
                {
                    attr = Colour.BrightRed;
                }
                if (pct >= 25)
                {
                    attr = Colour.Orange;
                }
                if (pct >= 60)
                {
                    attr = Colour.Yellow;
                }
                if (pct >= 100)
                {
                    attr = Colour.BrightGreen;
                }
                if (mPtr.FearLevel != 0)
                {
                    attr = Colour.Purple;
                    smb = "AFRAID****";
                }
                if (mPtr.SleepLevel != 0)
                {
                    attr = Colour.Blue;
                    smb = "SLEEPING**";
                }
                if ((mPtr.Mind & Constants.SmFriendly) != 0)
                {
                    attr = Colour.BrightBrown;
                    smb = "FRIENDLY**";
                }
                int len = pct < 10 ? 1 : pct < 90 ? (pct / 10) + 1 : 10;
                SaveGame.Print(Colour.White, "[----------]", ScreenLocation.RowInfo, ScreenLocation.ColInfo);
                SaveGame.Print(attr, smb, ScreenLocation.RowInfo, ScreenLocation.ColInfo + 1, len);
                SaveGame.Print(Colour.White, mPtr.Race.SplitName1, ScreenLocation.RowInfo - 3, ScreenLocation.ColInfo, 12);
                SaveGame.Print(Colour.White, mPtr.Race.SplitName2, ScreenLocation.RowInfo - 2, ScreenLocation.ColInfo, 12);
                SaveGame.Print(Colour.White, mPtr.Race.SplitName3, ScreenLocation.RowInfo - 1, ScreenLocation.ColInfo, 12);
            }
        }

        public bool MartialArtistEmptyHands()
        {
            if (SaveGame.Player.ProfessionIndex != CharacterClass.Monk && SaveGame.Player.ProfessionIndex != CharacterClass.Mystic)
            {
                return false;
            }
            return SaveGame.Player.Inventory[InventorySlot.MeleeWeapon].BaseItemCategory == null;
        }

        public bool MartialArtistHeavyArmour()
        {
            int martialArtistArmWgt = 0;
            if (SaveGame.Player.ProfessionIndex != CharacterClass.Monk && SaveGame.Player.ProfessionIndex != CharacterClass.Mystic)
            {
                return false;
            }
            martialArtistArmWgt += SaveGame.Player.Inventory[InventorySlot.Body].Weight;
            martialArtistArmWgt += SaveGame.Player.Inventory[InventorySlot.Head].Weight;
            martialArtistArmWgt += SaveGame.Player.Inventory[InventorySlot.Arm].Weight;
            martialArtistArmWgt += SaveGame.Player.Inventory[InventorySlot.Cloak].Weight;
            martialArtistArmWgt += SaveGame.Player.Inventory[InventorySlot.Hands].Weight;
            martialArtistArmWgt += SaveGame.Player.Inventory[InventorySlot.Feet].Weight;
            return martialArtistArmWgt > 100 + (SaveGame.Player.Level * 4);
        }

        public void PrtAc()
        {
            SaveGame.Print("Cur AC ", ScreenLocation.RowAc, ScreenLocation.ColAc);
            string tmp = (SaveGame.Player.DisplayedBaseArmourClass + SaveGame.Player.DisplayedArmourClassBonus).ToString().PadLeft(5);
            SaveGame.Print(Colour.BrightGreen, tmp, ScreenLocation.RowAc, ScreenLocation.ColAc + 7);
        }

        public void PrtAfraid()
        {
            if (SaveGame.Player.TimedFear > 0)
            {
                SaveGame.Print(Colour.Orange, "Afraid", ScreenLocation.RowAfraid, ScreenLocation.ColAfraid);
            }
            else
            {
                SaveGame.Print("      ", ScreenLocation.RowAfraid, ScreenLocation.ColAfraid);
            }
        }

        public void PrtBlind()
        {
            if (SaveGame.Player.TimedBlindness > 0)
            {
                SaveGame.Print(Colour.Orange, "Blind", ScreenLocation.RowBlind, ScreenLocation.ColBlind);
            }
            else
            {
                SaveGame.Print("     ", ScreenLocation.RowBlind, ScreenLocation.ColBlind);
            }
        }

        public void PrtConfused()
        {
            if (SaveGame.Player.TimedConfusion > 0)
            {
                SaveGame.Print(Colour.Orange, "Confused", ScreenLocation.RowConfused, ScreenLocation.ColConfused);
            }
            else
            {
                SaveGame.Print("        ", ScreenLocation.RowConfused, ScreenLocation.ColConfused);
            }
        }

        public void PrtCut()
        {
            int c = SaveGame.Player.TimedBleeding;
            if (c > 1000)
            {
                SaveGame.Print(Colour.BrightRed, "Mortal wound", ScreenLocation.RowCut, ScreenLocation.ColCut);
            }
            else if (c > 200)
            {
                SaveGame.Print(Colour.Red, "Deep gash   ", ScreenLocation.RowCut, ScreenLocation.ColCut);
            }
            else if (c > 100)
            {
                SaveGame.Print(Colour.Red, "Severe cut  ", ScreenLocation.RowCut, ScreenLocation.ColCut);
            }
            else if (c > 50)
            {
                SaveGame.Print(Colour.Orange, "Nasty cut   ", ScreenLocation.RowCut, ScreenLocation.ColCut);
            }
            else if (c > 25)
            {
                SaveGame.Print(Colour.Orange, "Bad cut     ", ScreenLocation.RowCut, ScreenLocation.ColCut);
            }
            else if (c > 10)
            {
                SaveGame.Print(Colour.Yellow, "Light cut   ", ScreenLocation.RowCut, ScreenLocation.ColCut);
            }
            else if (c > 0)
            {
                SaveGame.Print(Colour.Yellow, "Graze       ", ScreenLocation.RowCut, ScreenLocation.ColCut);
            }
            else
            {
                SaveGame.Print("            ", ScreenLocation.RowCut, ScreenLocation.ColCut);
            }
        }

        public void PrtDepth()
        {
            string depths;
            if (SaveGame.CurrentDepth == 0)
            {
                if (SaveGame.Wilderness[SaveGame.Player.WildernessY][SaveGame.Player.WildernessX].Dungeon != null)
                {
                    depths = SaveGame.Wilderness[SaveGame.Player.WildernessY][SaveGame.Player.WildernessX].Dungeon.Shortname;
                    SaveGame.Wilderness[SaveGame.Player.WildernessY][SaveGame.Player.WildernessX].Dungeon.Visited = true;
                }
                else
                {
                    depths = $"Wild ({SaveGame.Player.WildernessX},{SaveGame.Player.WildernessY})";
                }
            }
            else
            {
                depths = $"lvl {SaveGame.CurrentDepth}+{SaveGame.DungeonDifficulty}";
                SaveGame.CurDungeon.KnownOffset = true;
                if (SaveGame.CurrentDepth == SaveGame.CurDungeon.MaxLevel)
                {
                    SaveGame.CurDungeon.KnownDepth = true;
                }
            }
            SaveGame.PrintLine(depths.PadLeft(9), ScreenLocation.RowDepth, ScreenLocation.ColDepth);
        }

        public void PrtDtrap()
        {
            int count = 0;
            if (SaveGame.Level.Grid[SaveGame.Player.MapY][SaveGame.Player.MapX].TileFlags.IsClear(GridTile.TrapsDetected))
            {
                SaveGame.Print(Colour.Green, "     ", ScreenLocation.RowDtrap, ScreenLocation.ColDtrap);
                return;
            }
            if (SaveGame.Level.Grid[SaveGame.Player.MapY - 1][SaveGame.Player.MapX].TileFlags.IsSet(GridTile.TrapsDetected))
            {
                count++;
            }
            if (SaveGame.Level.Grid[SaveGame.Player.MapY + 1][SaveGame.Player.MapX].TileFlags.IsSet(GridTile.TrapsDetected))
            {
                count++;
            }
            if (SaveGame.Level.Grid[SaveGame.Player.MapY][SaveGame.Player.MapX - 1].TileFlags.IsSet(GridTile.TrapsDetected))
            {
                count++;
            }
            if (SaveGame.Level.Grid[SaveGame.Player.MapY][SaveGame.Player.MapX + 1].TileFlags.IsSet(GridTile.TrapsDetected))
            {
                count++;
            }
            if (count == 4)
            {
                SaveGame.Print(Colour.Green, "DTrap", ScreenLocation.RowDtrap, ScreenLocation.ColDtrap);
            }
            else
            {
                SaveGame.Print(Colour.Yellow, "DTRAP", ScreenLocation.RowDtrap, ScreenLocation.ColDtrap);
            }
        }

        public void PrtExp()
        {
            Colour colour = Colour.BrightGreen;
            if (SaveGame.Player.ExperiencePoints < SaveGame.Player.MaxExperienceGained)
            {
                colour = Colour.Yellow;
            }
            SaveGame.Print("NEXT", ScreenLocation.RowExp, 0);
            if (SaveGame.Player.Level >= Constants.PyMaxLevel)
            {
                SaveGame.Print(Colour.BrightGreen, "   *****", ScreenLocation.RowExp, ScreenLocation.ColExp + 4);
            }
            else
            {
                string outVal = ((GlobalData.PlayerExp[SaveGame.Player.Level - 1] * SaveGame.Player.ExperienceMultiplier / 100) - SaveGame.Player.ExperiencePoints).ToString()
                    .PadLeft(8);
                SaveGame.Print(colour, outVal, ScreenLocation.RowExp, ScreenLocation.ColExp + 4);
            }
        }

        public void PrtField(string info, int row, int col)
        {
            SaveGame.Print(Colour.White, "             ", row, col);
            SaveGame.Print(Colour.BrightBlue, info, row, col);
        }

        public void PrtFrameBasic()
        {
            PrtField(SaveGame.Player.Name, ScreenLocation.RowName, ScreenLocation.ColName);
            PrtField(SaveGame.Player.Race.Title, ScreenLocation.RowRace, ScreenLocation.ColRace);
            PrtField(Profession.ClassSubName(SaveGame.Player.ProfessionIndex, SaveGame.Player.Realm1), ScreenLocation.RowClass, ScreenLocation.ColClass);
            PrtTitle();
            PrtLevel();
            PrtExp();
            for (int i = 0; i < 6; i++)
            {
                PrtStat(i);
            }
            PrtAc();
            PrtHp();
            PrtSp();
            PrtGold();
            PrtDepth();
            HealthRedraw();
        }

        public void PrtFrameExtra()
        {
            PrtCut();
            PrtStun();
            PrtHunger();
            PrtDtrap();
            PrtBlind();
            PrtConfused();
            PrtAfraid();
            PrtPoisoned();
            PrtState();
            PrtSpeed();
            PrtStudy();
        }

        public void PrtGold()
        {
            SaveGame.Print("GP ", ScreenLocation.RowGold, ScreenLocation.ColGold);
            string tmp = SaveGame.Player.Gold.ToString().PadLeft(9);
            SaveGame.Print(Colour.BrightGreen, tmp, ScreenLocation.RowGold, ScreenLocation.ColGold + 3);
        }

        public void PrtHp()
        {
            SaveGame.Print("Max HP ", ScreenLocation.RowMaxhp, ScreenLocation.ColMaxhp);
            string tmp = SaveGame.Player.MaxHealth.ToString().PadLeft(5);
            Colour colour = Colour.BrightGreen;
            SaveGame.Print(colour, tmp, ScreenLocation.RowMaxhp, ScreenLocation.ColMaxhp + 7);
            SaveGame.Print("Cur HP ", ScreenLocation.RowCurhp, ScreenLocation.ColCurhp);
            tmp = SaveGame.Player.Health.ToString().PadLeft(5);
            if (SaveGame.Player.Health >= SaveGame.Player.MaxHealth)
            {
                colour = Colour.BrightGreen;
            }
            else if (SaveGame.Player.Health > SaveGame.Player.MaxHealth * GlobalData.HitpointWarn / 5)
            {
                colour = Colour.BrightYellow;
            }
            else if (SaveGame.Player.Health > SaveGame.Player.MaxHealth * GlobalData.HitpointWarn / 10)
            {
                colour = Colour.Orange;
            }
            else
            {
                colour = Colour.BrightRed;
            }
            SaveGame.Print(colour, tmp, ScreenLocation.RowCurhp, ScreenLocation.ColCurhp + 7);
        }

        public void PrtHunger()
        {
            if (SaveGame.Player.Food < Constants.PyFoodFaint)
            {
                SaveGame.Print(Colour.Red, "Weak  ", ScreenLocation.RowHungry, ScreenLocation.ColHungry);
            }
            else if (SaveGame.Player.Food < Constants.PyFoodWeak)
            {
                SaveGame.Print(Colour.Orange, "Weak  ", ScreenLocation.RowHungry, ScreenLocation.ColHungry);
            }
            else if (SaveGame.Player.Food < Constants.PyFoodAlert)
            {
                SaveGame.Print(Colour.Yellow, "Hungry", ScreenLocation.RowHungry, ScreenLocation.ColHungry);
            }
            else if (SaveGame.Player.Food < Constants.PyFoodFull)
            {
                SaveGame.Print(Colour.BrightGreen, "      ", ScreenLocation.RowHungry, ScreenLocation.ColHungry);
            }
            else if (SaveGame.Player.Food < Constants.PyFoodMax)
            {
                SaveGame.Print(Colour.BrightGreen, "Full  ", ScreenLocation.RowHungry, ScreenLocation.ColHungry);
            }
            else
            {
                SaveGame.Print(Colour.Green, "Gorged", ScreenLocation.RowHungry, ScreenLocation.ColHungry);
            }
        }

        public void PrtLevel()
        {
            string tmp = SaveGame.Player.Level.ToString().PadLeft(6);
            if (SaveGame.Player.Level >= SaveGame.Player.MaxLevelGained)
            {
                SaveGame.Print("LEVEL ", ScreenLocation.RowLevel, 0);
                SaveGame.Print(Colour.BrightGreen, tmp, ScreenLocation.RowLevel, ScreenLocation.ColLevel + 6);
            }
            else
            {
                SaveGame.Print("Level ", ScreenLocation.RowLevel, 0);
                SaveGame.Print(Colour.Yellow, tmp, ScreenLocation.RowLevel, ScreenLocation.ColLevel + 6);
            }
        }

        public void PrtPoisoned()
        {
            if (SaveGame.Player.TimedPoison > 0)
            {
                SaveGame.Print(Colour.Orange, "Poisoned", ScreenLocation.RowPoisoned, ScreenLocation.ColPoisoned);
            }
            else
            {
                SaveGame.Print("        ", ScreenLocation.RowPoisoned, ScreenLocation.ColPoisoned);
            }
        }

        public void PrtSp()
        {
            if (SaveGame.Player.Spellcasting.Type == CastingType.None)
            {
                return;
            }
            SaveGame.Print("Max SP ", ScreenLocation.RowMaxsp, ScreenLocation.ColMaxsp);
            string tmp = SaveGame.Player.MaxMana.ToString().PadLeft(5);
            Colour colour = Colour.BrightGreen;
            SaveGame.Print(colour, tmp, ScreenLocation.RowMaxsp, ScreenLocation.ColMaxsp + 7);
            SaveGame.Print("Cur SP ", ScreenLocation.RowCursp, ScreenLocation.ColCursp);
            tmp = SaveGame.Player.Mana.ToString().PadLeft(5);
            if (SaveGame.Player.Mana >= SaveGame.Player.MaxMana)
            {
                colour = Colour.BrightGreen;
            }
            else if (SaveGame.Player.Mana > SaveGame.Player.MaxMana * GlobalData.HitpointWarn / 5)
            {
                colour = Colour.BrightYellow;
            }
            else if (SaveGame.Player.Mana > SaveGame.Player.MaxMana * GlobalData.HitpointWarn / 10)
            {
                colour = Colour.Orange;
            }
            else
            {
                colour = Colour.BrightRed;
            }
            SaveGame.Print(colour, tmp, ScreenLocation.RowCursp, ScreenLocation.ColCursp + 7);
        }

        public void PrtSpeed()
        {
            int i = SaveGame.Player.Speed;
            Colour attr = Colour.White;
            string buf = "";
            if (SaveGame.Player.IsSearching)
            {
                i += 10;
            }
            int energy = GlobalData.ExtractEnergy[i];
            if (i > 110)
            {
                attr = Colour.BrightGreen;
                buf = $"Fast {energy / 10.0}";
            }
            else if (i < 110)
            {
                attr = Colour.BrightBrown;
                buf = $"Slow {energy / 10.0}";
            }
            SaveGame.Print(attr, buf.PadRight(14), ScreenLocation.RowSpeed, ScreenLocation.ColSpeed);
        }

        public void PrtStat(int stat)
        {
            string tmp;
            if (SaveGame.Player.AbilityScores[stat].Innate < SaveGame.Player.AbilityScores[stat].InnateMax)
            {
                SaveGame.Print(GlobalData.StatNamesReduced[stat], ScreenLocation.RowStat + stat, 0);
                tmp = SaveGame.Player.AbilityScores[stat].Adjusted.StatToString();
                SaveGame.Print(Colour.Yellow, tmp, ScreenLocation.RowStat + stat, ScreenLocation.ColStat + 6);
            }
            else
            {
                SaveGame.Print(GlobalData.StatNames[stat], ScreenLocation.RowStat + stat, 0);
                tmp = SaveGame.Player.AbilityScores[stat].Adjusted.StatToString();
                SaveGame.Print(Colour.BrightGreen, tmp, ScreenLocation.RowStat + stat, ScreenLocation.ColStat + 6);
            }
            if (SaveGame.Player.AbilityScores[stat].InnateMax == 18 + 100)
            {
                SaveGame.Print("!", ScreenLocation.RowStat + stat, 3);
            }
        }

        public void PrtState()
        {
            Colour attr = Colour.White;
            string text;
            if (SaveGame.Player.TimedParalysis > 0)
            {
                attr = Colour.Red;
                text = "Paralyzed!";
            }
            else if (SaveGame.Resting != 0)
            {
                text = "Rest ";
                if (SaveGame.Resting > 0)
                {
                    text += SaveGame.Resting.ToString().PadLeft(5);
                }
                else if (SaveGame.Resting == -1)
                {
                    text += "*****";
                }
                else if (SaveGame.Resting == -2)
                {
                    text += "&&&&&";
                }
                else
                {
                    text += "?????";
                }
            }
            else if (SaveGame.CommandRepeat != 0)
            {
                if (SaveGame.CommandRepeat > 999)
                {
                    text = "Rep. " + SaveGame.CommandRepeat.ToString().PadRight(5);
                }
                else
                {
                    text = "Repeat " + SaveGame.CommandRepeat.ToString().PadRight(3);
                }
            }
            else if (SaveGame.Player.IsSearching)
            {
                text = "Searching ";
            }
            else
            {
                text = "          ";
            }
            SaveGame.Print(attr, text, ScreenLocation.RowState, ScreenLocation.ColState);
        }

        public void PrtStudy()
        {
            SaveGame.Print(SaveGame.Player.SpareSpellSlots != 0 ? "Study" : "     ", ScreenLocation.RowStudy, ScreenLocation.ColStudy);
        }

        public void PrtStun()
        {
            int s = SaveGame.Player.TimedStun;
            if (s > 100)
            {
                SaveGame.Print(Colour.Red, "Knocked out ", ScreenLocation.RowStun, ScreenLocation.ColStun);
            }
            else if (s > 50)
            {
                SaveGame.Print(Colour.Orange, "Heavy stun  ", ScreenLocation.RowStun, ScreenLocation.ColStun);
            }
            else if (s > 0)
            {
                SaveGame.Print(Colour.Orange, "Stun        ", ScreenLocation.RowStun, ScreenLocation.ColStun);
            }
            else
            {
                SaveGame.Print("            ", ScreenLocation.RowStun, ScreenLocation.ColStun);
            }
        }

        public void PrtTime()
        {
            SaveGame.Print(Colour.White, "Time", ScreenLocation.RowTime, ScreenLocation.ColTime);
            SaveGame.Print(Colour.White, "Day", ScreenLocation.RowDate, ScreenLocation.colDate);
            SaveGame.Print(Colour.BrightGreen, SaveGame.Player.GameTime.TimeText.PadLeft(8), ScreenLocation.RowTime, ScreenLocation.ColTime + 4);
            SaveGame.Print(Colour.BrightGreen, SaveGame.Player.GameTime.DateText.PadLeft(8), ScreenLocation.RowDate, ScreenLocation.colDate + 4);
        }

        public void PrtTitle()
        {
            string p;
            if (SaveGame.Player.IsWizard)
            {
                p = "-=<WIZARD>=-";
                PrtField(p, ScreenLocation.RowTitle, ScreenLocation.ColTitle);
            }
            else if (SaveGame.Player.IsWinner || SaveGame.Player.Level > Constants.PyMaxLevel)
            {
                p = "***WINNER***";
                PrtField(p, ScreenLocation.RowTitle, ScreenLocation.ColTitle);
            }
        }

        private int WeightLimit()
        {
            int i = SaveGame.Player.AbilityScores[Ability.Strength].StrCarryingCapacity * 100;
            return i;
        }
    }
}