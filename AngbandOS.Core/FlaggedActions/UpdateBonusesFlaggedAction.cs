﻿
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateBonusesFlaggedAction : FlaggedAction
    {
        private readonly int[][] _blowsTable =
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

        private bool MartialArtistArmourAux;
        private bool MartialArtistNotifyAux;
        private bool OldUnpriestlyWeapon;
        private bool OldHeavyBow;
        private bool OldHeavyWeapon;

        public UpdateBonusesFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
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
            if (SaveGame.Player.ProfessionIndex == CharacterClass.Monk && SaveGame.Player.Level > 24 && !SaveGame.MartialArtistHeavyArmour())
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
                if (SaveGame.Player.Level > 29 && !SaveGame.MartialArtistHeavyArmour())
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
                    SaveGame.Player.TimedEtherealness.Reset(Math.Max(SaveGame.Player.TimedEtherealness.TimeRemaining, 20));
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
            if ((SaveGame.Player.ProfessionIndex == CharacterClass.Monk || SaveGame.Player.ProfessionIndex == CharacterClass.Mystic) && !SaveGame.MartialArtistHeavyArmour())
            {
                foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots)
                {
                    if (inventorySlot.Count == 0)
                    {
                        int bareArmourBonus = inventorySlot.BareArmourClassBonus;
                        SaveGame.Player.ArmourClassBonus += bareArmourBonus;
                        SaveGame.Player.DisplayedArmourClassBonus += bareArmourBonus;
                    }
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
                    SaveGame.RedrawStatsFlaggedAction.Set();
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
                    SaveGame.RedrawStatsFlaggedAction.Set();
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
                        SaveGame.UpdateHealthFlaggedAction.Set();
                    }
                    else if (i == Ability.Intelligence)
                    {
                        if (SaveGame.Player.Spellcasting.SpellStat == Ability.Intelligence)
                        {
                            SaveGame.UpdateManaFlaggedAction.Set();
                            SaveGame.UpdateSpellsFlaggedAction.Set();
                        }
                    }
                    else if (i == Ability.Wisdom)
                    {
                        if (SaveGame.Player.Spellcasting.SpellStat == Ability.Wisdom)
                        {
                            SaveGame.UpdateManaFlaggedAction.Set();
                            SaveGame.UpdateSpellsFlaggedAction.Set();
                        }
                    }
                    else if (i == Ability.Charisma)
                    {
                        if (SaveGame.Player.Spellcasting.SpellStat == Ability.Charisma)
                        {
                            SaveGame.UpdateManaFlaggedAction.Set();
                            SaveGame.UpdateSpellsFlaggedAction.Set();
                        }
                    }
                }
            }
            if (SaveGame.Player.TimedStun.TimeRemaining > 50)
            {
                SaveGame.Player.AttackBonus -= 20;
                SaveGame.Player.DisplayedAttackBonus -= 20;
                SaveGame.Player.DamageBonus -= 20;
                SaveGame.Player.DisplayedDamageBonus -= 20;
            }
            else if (SaveGame.Player.TimedStun.TimeRemaining != 0)
            {
                SaveGame.Player.AttackBonus -= 5;
                SaveGame.Player.DisplayedAttackBonus -= 5;
                SaveGame.Player.DamageBonus -= 5;
                SaveGame.Player.DisplayedDamageBonus -= 5;
            }
            if (SaveGame.Player.TimedInvulnerability.TimeRemaining != 0)
            {
                SaveGame.Player.ArmourClassBonus += 100;
                SaveGame.Player.DisplayedArmourClassBonus += 100;
            }
            if (SaveGame.Player.TimedEtherealness.TimeRemaining != 0)
            {
                SaveGame.Player.ArmourClassBonus += 100;
                SaveGame.Player.DisplayedArmourClassBonus += 100;
                SaveGame.Player.HasReflection = true;
            }
            if (SaveGame.Player.TimedBlessing.TimeRemaining != 0)
            {
                SaveGame.Player.ArmourClassBonus += 5;
                SaveGame.Player.DisplayedArmourClassBonus += 5;
                SaveGame.Player.AttackBonus += 10;
                SaveGame.Player.DisplayedAttackBonus += 10;
            }
            if (SaveGame.Player.TimedStoneskin.TimeRemaining != 0)
            {
                SaveGame.Player.ArmourClassBonus += 50;
                SaveGame.Player.DisplayedArmourClassBonus += 50;
            }
            if (SaveGame.Player.TimedHeroism.TimeRemaining != 0)
            {
                SaveGame.Player.AttackBonus += 12;
                SaveGame.Player.DisplayedAttackBonus += 12;
            }
            if (SaveGame.Player.TimedSuperheroism.TimeRemaining != 0)
            {
                SaveGame.Player.AttackBonus += 24;
                SaveGame.Player.DisplayedAttackBonus += 24;
                SaveGame.Player.ArmourClassBonus -= 10;
                SaveGame.Player.DisplayedArmourClassBonus -= 10;
            }
            if (SaveGame.Player.TimedHaste.TimeRemaining != 0)
            {
                SaveGame.Player.Speed += 10;
            }
            if (SaveGame.Player.TimedSlow.TimeRemaining != 0)
            {
                SaveGame.Player.Speed -= 10;
            }
            if ((SaveGame.Player.ProfessionIndex == CharacterClass.Monk || SaveGame.Player.ProfessionIndex == CharacterClass.Mystic) && !SaveGame.MartialArtistHeavyArmour())
            {
                SaveGame.Player.Speed += SaveGame.Player.Level / 10;
            }
            if (SaveGame.Player.TimedTelepathy.TimeRemaining != 0)
            {
                SaveGame.Player.HasTelepathy = true;
            }
            if (SaveGame.Player.TimedSeeInvisibility.TimeRemaining != 0)
            {
                SaveGame.Player.HasSeeInvisibility = true;
            }
            if (SaveGame.Player.TimedInfravision.TimeRemaining != 0)
            {
                SaveGame.Player.InfravisionRange++;
            }
            if (SaveGame.Player.HasChaosResistance)
            {
                SaveGame.Player.HasConfusionResistance = true;
            }
            if (SaveGame.Player.TimedHeroism.TimeRemaining != 0 || SaveGame.Player.TimedSuperheroism.TimeRemaining != 0)
            {
                SaveGame.Player.HasFearResistance = true;
            }
            if (SaveGame.Player.HasTelepathy != oldTelepathy)
            {
                SaveGame.UpdateMonstersFlaggedAction.Set();
            }
            if (SaveGame.Player.HasSeeInvisibility != oldSeeInv)
            {
                SaveGame.UpdateMonstersFlaggedAction.Set();
            }
            int j = SaveGame.Player.WeightCarried;

            // Compute the weight limit.
            i = SaveGame.Player.AbilityScores[Ability.Strength].StrCarryingCapacity * 100;

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
                SaveGame.RedrawSpeedFlaggedAction.Set();
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
                SaveGame.RedrawArmorFlaggedAction.Set();
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
            else if ((SaveGame.Player.ProfessionIndex == CharacterClass.Monk || SaveGame.Player.ProfessionIndex == CharacterClass.Mystic) && SaveGame.MartialArtistEmptyHands())
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
                if (SaveGame.MartialArtistHeavyArmour())
                {
                    SaveGame.Player.MeleeAttacksPerRound /= 2;
                }
                SaveGame.Player.MeleeAttacksPerRound += 1 + extraBlows;
                if (!SaveGame.MartialArtistHeavyArmour())
                {
                    SaveGame.Player.AttackBonus += SaveGame.Player.Level / 3;
                    SaveGame.Player.DamageBonus += SaveGame.Player.Level / 3;
                    SaveGame.Player.DisplayedAttackBonus += SaveGame.Player.Level / 3;
                    SaveGame.Player.DisplayedDamageBonus += SaveGame.Player.Level / 3;
                }
            }
            SaveGame.Player.HasUnpriestlyWeapon = false;
            MartialArtistArmourAux = false;
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
            if (SaveGame.MartialArtistHeavyArmour())
            {
                MartialArtistArmourAux = true;
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
            if (OldHeavyBow != SaveGame.Player.HasHeavyBow) // TODO: This should be moved to the wield action
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
                OldHeavyBow = SaveGame.Player.HasHeavyBow;
            }
            if (OldHeavyWeapon != SaveGame.Player.HasHeavyWeapon) // TODO: This should be moved to the wield action
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
                OldHeavyWeapon = SaveGame.Player.HasHeavyWeapon;
            }
            if (OldUnpriestlyWeapon != SaveGame.Player.HasUnpriestlyWeapon) // TODO: This should be moved to the wield action
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
                OldUnpriestlyWeapon = SaveGame.Player.HasUnpriestlyWeapon;
            }
            if ((SaveGame.Player.ProfessionIndex == CharacterClass.Monk || SaveGame.Player.ProfessionIndex == CharacterClass.Mystic) && MartialArtistArmourAux != MartialArtistNotifyAux) // TODO: This should be moved to the wield action
            {
                SaveGame.MsgPrint(SaveGame.MartialArtistHeavyArmour()
                    ? "The weight of your armour disrupts your balance."
                    : "You regain your balance.");
                MartialArtistNotifyAux = MartialArtistArmourAux;
            }
        }

    }
}