// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

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

    private bool MartialArtistArmorAux;
    private bool MartialArtistNotifyAux;
    private bool OldUnpriestlyWeapon;
    private bool OldHeavyBow;
    private bool OldHeavyWeapon;

    private UpdateBonusesFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        int extraShots;
        int oldSpeed = SaveGame.Speed.Value;
        bool oldTelepathy = SaveGame.HasTelepathy;
        bool oldSeeInv = SaveGame.HasSeeInvisibility;
        int oldDisAc = SaveGame.DisplayedBaseArmorClass.Value;
        int oldDisToA = SaveGame.DisplayedArmorClassBonus.Value;
        int extraBlows = extraShots = 0;
        for (int i = 0; i < 6; i++)
        {
            SaveGame.AbilityScores[i].Bonus = 0;
        }
        SaveGame.DisplayedBaseArmorClass.Value = 0;
        SaveGame.BaseArmorClass = 0;
        SaveGame.DisplayedAttackBonus = 0;
        SaveGame.AttackBonus = 0;
        SaveGame.DisplayedDamageBonus = 0;
        SaveGame.DamageBonus = 0;
        SaveGame.DisplayedArmorClassBonus.Value = 0;
        SaveGame.ArmorClassBonus = 0;
        SaveGame.HasAggravation = false;
        SaveGame.HasRandomTeleport = false;
        SaveGame.HasExperienceDrain = false;
        SaveGame.HasBlessedBlade = false;
        SaveGame.HasExtraMight = false;
        SaveGame.HasQuakeWeapon = false;
        SaveGame.HasSeeInvisibility = false;
        SaveGame.HasFreeAction = false;
        SaveGame.HasSlowDigestion = false;
        SaveGame.HasRegeneration = false;
        SaveGame.HasFeatherFall = false;
        SaveGame.HasHoldLife = false;
        SaveGame.HasTelepathy = false;
        SaveGame.HasGlow = false;
        SaveGame.HasSustainStrength = false;
        SaveGame.HasSustainIntelligence = false;
        SaveGame.HasSustainWisdom = false;
        SaveGame.HasSustainConstitution = false;
        SaveGame.HasSustainDexterity = false;
        SaveGame.HasSustainCharisma = false;
        SaveGame.HasAcidResistance = false;
        SaveGame.HasLightningResistance = false;
        SaveGame.HasFireResistance = false;
        SaveGame.HasColdResistance = false;
        SaveGame.HasPoisonResistance = false;
        SaveGame.HasConfusionResistance = false;
        SaveGame.HasSoundResistance = false;
        SaveGame.HasTimeResistance = false;
        SaveGame.HasLightResistance = false;
        SaveGame.HasDarkResistance = false;
        SaveGame.HasChaosResistance = false;
        SaveGame.HasDisenchantResistance = false;
        SaveGame.HasShardResistance = false;
        SaveGame.HasNexusResistance = false;
        SaveGame.HasBlindnessResistance = false;
        SaveGame.HasNetherResistance = false;
        SaveGame.HasFearResistance = false;
        SaveGame.HasElementalVulnerability = false;
        SaveGame.HasReflection = false;
        SaveGame.HasFireShield = false;
        SaveGame.HasLightningShield = false;
        SaveGame.HasAntiMagic = false;
        SaveGame.HasAntiTeleport = false;
        SaveGame.HasAntiTheft = false;
        SaveGame.HasAcidImmunity = false;
        SaveGame.HasLightningImmunity = false;
        SaveGame.HasFireImmunity = false;
        SaveGame.HasColdImmunity = false;
        SaveGame.InfravisionRange = SaveGame.Race.Infravision;
        SaveGame.SkillDisarmTraps = SaveGame.Race.BaseDisarmBonus + SaveGame.BaseCharacterClass.BaseDisarmBonus;
        SaveGame.SkillUseDevice = SaveGame.Race.BaseDeviceBonus + SaveGame.BaseCharacterClass.BaseDeviceBonus;
        SaveGame.SkillSavingThrow = SaveGame.Race.BaseSaveBonus + SaveGame.BaseCharacterClass.BaseSaveBonus;
        SaveGame.SkillStealth = SaveGame.Race.BaseStealthBonus + SaveGame.BaseCharacterClass.BaseStealthBonus;
        SaveGame.SkillSearching = SaveGame.Race.BaseSearchBonus + SaveGame.BaseCharacterClass.BaseSearchBonus;
        SaveGame.SkillSearchFrequency = SaveGame.Race.BaseSearchFrequency + SaveGame.BaseCharacterClass.BaseSearchFrequency;
        SaveGame.SkillMelee = SaveGame.Race.BaseMeleeAttackBonus + SaveGame.BaseCharacterClass.BaseMeleeAttackBonus;
        SaveGame.SkillRanged = SaveGame.Race.BaseRangedAttackBonus + SaveGame.BaseCharacterClass.BaseRangedAttackBonus;
        SaveGame.SkillThrowing = SaveGame.Race.BaseRangedAttackBonus + SaveGame.BaseCharacterClass.BaseRangedAttackBonus;
        SaveGame.SkillDigging = 0;
        if ((SaveGame.BaseCharacterClass.ID == CharacterClass.Warrior && SaveGame.ExperienceLevel > 29) ||
            (SaveGame.BaseCharacterClass.ID == CharacterClass.Paladin && SaveGame.ExperienceLevel > 39) ||
            (SaveGame.BaseCharacterClass.ID == CharacterClass.Fanatic && SaveGame.ExperienceLevel > 39))
        {
            SaveGame.HasFearResistance = true;
        }
        if (SaveGame.BaseCharacterClass.ID == CharacterClass.Fanatic && SaveGame.ExperienceLevel > 29)
        {
            SaveGame.HasChaosResistance = true;
        }
        if (SaveGame.BaseCharacterClass.ID == CharacterClass.Cultist && SaveGame.ExperienceLevel > 19)
        {
            SaveGame.HasChaosResistance = true;
        }
        if (SaveGame.BaseCharacterClass.ID == CharacterClass.Mindcrafter)
        {
            if (SaveGame.ExperienceLevel > 9)
            {
                SaveGame.HasFearResistance = true;
            }
            if (SaveGame.ExperienceLevel > 19)
            {
                SaveGame.HasSustainWisdom = true;
            }
            if (SaveGame.ExperienceLevel > 29)
            {
                SaveGame.HasConfusionResistance = true;
            }
            if (SaveGame.ExperienceLevel > 39)
            {
                SaveGame.HasTelepathy = true;
            }
        }
        if (SaveGame.BaseCharacterClass.ID == CharacterClass.Monk && SaveGame.ExperienceLevel > 24 && !SaveGame.MartialArtistHeavyArmor())
        {
            SaveGame.HasFreeAction = true;
        }
        if (SaveGame.BaseCharacterClass.ID == CharacterClass.Mystic)
        {
            if (SaveGame.ExperienceLevel > 9)
            {
                SaveGame.HasConfusionResistance = true;
            }
            if (SaveGame.ExperienceLevel > 24)
            {
                SaveGame.HasFearResistance = true;
            }
            if (SaveGame.ExperienceLevel > 29 && !SaveGame.MartialArtistHeavyArmor())
            {
                SaveGame.HasFreeAction = true;
            }
            if (SaveGame.ExperienceLevel > 39)
            {
                SaveGame.HasTelepathy = true;
            }
        }
        if (SaveGame.BaseCharacterClass.ID == CharacterClass.ChosenOne)
        {
            SaveGame.HasGlow = true;
            if (SaveGame.ExperienceLevel >= 2)
            {
                SaveGame.HasConfusionResistance = true;
            }
            if (SaveGame.ExperienceLevel >= 4)
            {
                SaveGame.HasFearResistance = true;
            }
            if (SaveGame.ExperienceLevel >= 6)
            {
                SaveGame.HasBlindnessResistance = true;
            }
            if (SaveGame.ExperienceLevel >= 8)
            {
                SaveGame.HasFeatherFall = true;
            }
            if (SaveGame.ExperienceLevel >= 10)
            {
                SaveGame.HasSeeInvisibility = true;
            }
            if (SaveGame.ExperienceLevel >= 12)
            {
                SaveGame.HasSlowDigestion = true;
            }
            if (SaveGame.ExperienceLevel >= 14)
            {
                SaveGame.HasSustainConstitution = true;
            }
            if (SaveGame.ExperienceLevel >= 16)
            {
                SaveGame.HasPoisonResistance = true;
            }
            if (SaveGame.ExperienceLevel >= 18)
            {
                SaveGame.HasSustainDexterity = true;
            }
            if (SaveGame.ExperienceLevel >= 20)
            {
                SaveGame.HasSustainStrength = true;
            }
            if (SaveGame.ExperienceLevel >= 22)
            {
                SaveGame.HasHoldLife = true;
            }
            if (SaveGame.ExperienceLevel >= 24)
            {
                SaveGame.HasFreeAction = true;
            }
            if (SaveGame.ExperienceLevel >= 26)
            {
                SaveGame.HasTelepathy = true;
            }
            if (SaveGame.ExperienceLevel >= 28)
            {
                SaveGame.HasDarkResistance = true;
            }
            if (SaveGame.ExperienceLevel >= 30)
            {
                SaveGame.HasLightResistance = true;
            }
            if (SaveGame.ExperienceLevel >= 32)
            {
                SaveGame.HasSustainCharisma = true;
            }
            if (SaveGame.ExperienceLevel >= 34)
            {
                SaveGame.HasSoundResistance = true;
            }
            if (SaveGame.ExperienceLevel >= 36)
            {
                SaveGame.HasDisenchantResistance = true;
            }
            if (SaveGame.ExperienceLevel >= 38)
            {
                SaveGame.HasRegeneration = true;
            }
            if (SaveGame.ExperienceLevel >= 40)
            {
                SaveGame.HasSustainIntelligence = true;
            }
            if (SaveGame.ExperienceLevel >= 42)
            {
                SaveGame.HasChaosResistance = true;
            }
            if (SaveGame.ExperienceLevel >= 44)
            {
                SaveGame.HasSustainWisdom = true;
            }
            if (SaveGame.ExperienceLevel >= 46)
            {
                SaveGame.HasNexusResistance = true;
            }
            if (SaveGame.ExperienceLevel >= 48)
            {
                SaveGame.HasShardResistance = true;
            }
            if (SaveGame.ExperienceLevel >= 50)
            {
                SaveGame.HasNetherResistance = true;
            }
        }
        SaveGame.Race.CalcBonuses();
        SaveGame.Speed.Value = 110;
        SaveGame.MeleeAttacksPerRound = 1;
        SaveGame.MissileAttacksPerRound = 1;
        SaveGame.AmmunitionItemCategory = 0;
        for (int i = 0; i < 6; i++)
        {
            SaveGame.AbilityScores[i].Bonus += SaveGame.Race.AbilityBonus[i] + SaveGame.BaseCharacterClass.AbilityBonus[i];
        }
        SaveGame.AbilityScores[Ability.Strength].Bonus += SaveGame.StrengthBonus;
        SaveGame.AbilityScores[Ability.Intelligence].Bonus += SaveGame.IntelligenceBonus;
        SaveGame.AbilityScores[Ability.Wisdom].Bonus += SaveGame.WisdomBonus;
        SaveGame.AbilityScores[Ability.Dexterity].Bonus += SaveGame.DexterityBonus;
        SaveGame.AbilityScores[Ability.Constitution].Bonus += SaveGame.ConstitutionBonus;
        SaveGame.AbilityScores[Ability.Charisma].Bonus += SaveGame.CharismaBonus;
        SaveGame.Speed.Value += SaveGame.SpeedBonus;
        SaveGame.HasRegeneration |= SaveGame.Regen;
        SaveGame.SkillSearchFrequency += SaveGame.SearchBonus;
        SaveGame.SkillSearching += SaveGame.SearchBonus;
        SaveGame.InfravisionRange += SaveGame.InfravisionBonus;
        SaveGame.HasLightningShield |= SaveGame.ElecHit;
        SaveGame.HasFireShield |= SaveGame.FireHit;
        SaveGame.HasGlow |= SaveGame.FireHit;
        SaveGame.ArmorClassBonus += SaveGame.GenomeArmorClassBonus;
        SaveGame.DisplayedArmorClassBonus.Value += SaveGame.GenomeArmorClassBonus;
        SaveGame.HasFeatherFall |= SaveGame.FeatherFall;
        SaveGame.HasFearResistance |= SaveGame.ResFear;
        SaveGame.HasTimeResistance |= SaveGame.ResTime;
        SaveGame.HasTelepathy |= SaveGame.Esp;
        SaveGame.SkillStealth += SaveGame.StealthBonus;
        SaveGame.HasFreeAction |= SaveGame.FreeAction;
        SaveGame.HasElementalVulnerability |= SaveGame.Vulnerable;
        if (SaveGame.MagicResistance)
        {
            SaveGame.SkillSavingThrow += 15 + (SaveGame.ExperienceLevel / 5);
        }
        if (SaveGame.SuppressRegen)
        {
            SaveGame.HasRegeneration = false;
        }
        if (SaveGame.CharismaOverride)
        {
            SaveGame.AbilityScores[Ability.Charisma].Bonus = 0;
        }
        if (SaveGame.SustainAll)
        {
            SaveGame.HasSustainConstitution = true;
            if (SaveGame.ExperienceLevel > 9)
            {
                SaveGame.HasSustainStrength = true;
            }
            if (SaveGame.ExperienceLevel > 19)
            {
                SaveGame.HasSustainDexterity = true;
            }
            if (SaveGame.ExperienceLevel > 29)
            {
                SaveGame.HasSustainWisdom = true;
            }
            if (SaveGame.ExperienceLevel > 39)
            {
                SaveGame.HasSustainIntelligence = true;
            }
            if (SaveGame.ExperienceLevel > 49)
            {
                SaveGame.HasSustainCharisma = true;
            }
        }
        foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots.Where(_inventorySlot => _inventorySlot.IsEquipment))
        {
            foreach (int i in inventorySlot.InventorySlots)
            {
                Item? oPtr = SaveGame.GetInventoryItem(i);
                if (oPtr != null)
                {
                    oPtr.RefreshFlagBasedProperties();
                    if (oPtr.Characteristics.Str)
                    {
                        SaveGame.AbilityScores[Ability.Strength].Bonus += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Int)
                    {
                        SaveGame.AbilityScores[Ability.Intelligence].Bonus += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Wis)
                    {
                        SaveGame.AbilityScores[Ability.Wisdom].Bonus += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Dex)
                    {
                        SaveGame.AbilityScores[Ability.Dexterity].Bonus += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Con)
                    {
                        SaveGame.AbilityScores[Ability.Constitution].Bonus += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Cha)
                    {
                        SaveGame.AbilityScores[Ability.Charisma].Bonus += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Stealth)
                    {
                        SaveGame.SkillStealth += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Search)
                    {
                        SaveGame.SkillSearching += oPtr.TypeSpecificValue * 5;
                    }
                    if (oPtr.Characteristics.Search)
                    {
                        SaveGame.SkillSearchFrequency += oPtr.TypeSpecificValue * 5;
                    }
                    if (oPtr.Characteristics.Infra)
                    {
                        SaveGame.InfravisionRange += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Tunnel)
                    {
                        SaveGame.SkillDigging += oPtr.TypeSpecificValue * 20;
                    }
                    if (oPtr.Characteristics.Speed)
                    {
                        SaveGame.Speed.Value += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Blows)
                    {
                        extraBlows += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Impact)
                    {
                        SaveGame.HasQuakeWeapon = true;
                    }
                    if (oPtr.Characteristics.AntiTheft)
                    {
                        SaveGame.HasAntiTheft = true;
                    }
                    if (oPtr.Characteristics.XtraShots)
                    {
                        extraShots++;
                    }
                    if (oPtr.Characteristics.Aggravate)
                    {
                        SaveGame.HasAggravation = true;
                    }
                    if (oPtr.Characteristics.Teleport)
                    {
                        SaveGame.HasRandomTeleport = true;
                    }
                    if (oPtr.Characteristics.DrainExp)
                    {
                        SaveGame.HasExperienceDrain = true;
                    }
                    if (oPtr.Characteristics.Blessed)
                    {
                        SaveGame.HasBlessedBlade = true;
                    }
                    if (oPtr.Characteristics.XtraMight)
                    {
                        SaveGame.HasExtraMight = true;
                    }
                    if (oPtr.Characteristics.SlowDigest)
                    {
                        SaveGame.HasSlowDigestion = true;
                    }
                    if (oPtr.Characteristics.Regen)
                    {
                        SaveGame.HasRegeneration = true;
                    }
                    if (oPtr.Characteristics.Telepathy)
                    {
                        SaveGame.HasTelepathy = true;
                    }
                    if (oPtr.Characteristics.Lightsource)
                    {
                        SaveGame.HasGlow = true;
                    }
                    if (oPtr.Characteristics.SeeInvis)
                    {
                        SaveGame.HasSeeInvisibility = true;
                    }
                    if (oPtr.Characteristics.Feather)
                    {
                        SaveGame.HasFeatherFall = true;
                    }
                    if (oPtr.Characteristics.FreeAct)
                    {
                        SaveGame.HasFreeAction = true;
                    }
                    if (oPtr.Characteristics.HoldLife)
                    {
                        SaveGame.HasHoldLife = true;
                    }
                    if (oPtr.Characteristics.Wraith)
                    {
                        SaveGame.EtherealnessTimer.SetValue(Math.Max(SaveGame.EtherealnessTimer.Value, 20));
                    }
                    if (oPtr.Characteristics.ImFire)
                    {
                        SaveGame.HasFireImmunity = true;
                    }
                    if (oPtr.Characteristics.ImAcid)
                    {
                        SaveGame.HasAcidImmunity = true;
                    }
                    if (oPtr.Characteristics.ImCold)
                    {
                        SaveGame.HasColdImmunity = true;
                    }
                    if (oPtr.Characteristics.ImElec)
                    {
                        SaveGame.HasLightningImmunity = true;
                    }
                    if (oPtr.Characteristics.ResAcid)
                    {
                        SaveGame.HasAcidResistance = true;
                    }
                    if (oPtr.Characteristics.ResElec)
                    {
                        SaveGame.HasLightningResistance = true;
                    }
                    if (oPtr.Characteristics.ResFire)
                    {
                        SaveGame.HasFireResistance = true;
                    }
                    if (oPtr.Characteristics.ResCold)
                    {
                        SaveGame.HasColdResistance = true;
                    }
                    if (oPtr.Characteristics.ResPois)
                    {
                        SaveGame.HasPoisonResistance = true;
                    }
                    if (oPtr.Characteristics.ResFear)
                    {
                        SaveGame.HasFearResistance = true;
                    }
                    if (oPtr.Characteristics.ResConf)
                    {
                        SaveGame.HasConfusionResistance = true;
                    }
                    if (oPtr.Characteristics.ResSound)
                    {
                        SaveGame.HasSoundResistance = true;
                    }
                    if (oPtr.Characteristics.ResLight)
                    {
                        SaveGame.HasLightResistance = true;
                    }
                    if (oPtr.Characteristics.ResDark)
                    {
                        SaveGame.HasDarkResistance = true;
                    }
                    if (oPtr.Characteristics.ResChaos)
                    {
                        SaveGame.HasChaosResistance = true;
                    }
                    if (oPtr.Characteristics.ResDisen)
                    {
                        SaveGame.HasDisenchantResistance = true;
                    }
                    if (oPtr.Characteristics.ResShards)
                    {
                        SaveGame.HasShardResistance = true;
                    }
                    if (oPtr.Characteristics.ResNexus)
                    {
                        SaveGame.HasNexusResistance = true;
                    }
                    if (oPtr.Characteristics.ResBlind)
                    {
                        SaveGame.HasBlindnessResistance = true;
                    }
                    if (oPtr.Characteristics.ResNether)
                    {
                        SaveGame.HasNetherResistance = true;
                    }
                    if (oPtr.Characteristics.Reflect)
                    {
                        SaveGame.HasReflection = true;
                    }
                    if (oPtr.Characteristics.ShFire)
                    {
                        SaveGame.HasFireShield = true;
                    }
                    if (oPtr.Characteristics.ShElec)
                    {
                        SaveGame.HasLightningShield = true;
                    }
                    if (oPtr.Characteristics.NoMagic)
                    {
                        SaveGame.HasAntiMagic = true;
                    }
                    if (oPtr.Characteristics.NoTele)
                    {
                        SaveGame.HasAntiTeleport = true;
                    }
                    if (oPtr.Characteristics.SustStr)
                    {
                        SaveGame.HasSustainStrength = true;
                    }
                    if (oPtr.Characteristics.SustInt)
                    {
                        SaveGame.HasSustainIntelligence = true;
                    }
                    if (oPtr.Characteristics.SustWis)
                    {
                        SaveGame.HasSustainWisdom = true;
                    }
                    if (oPtr.Characteristics.SustDex)
                    {
                        SaveGame.HasSustainDexterity = true;
                    }
                    if (oPtr.Characteristics.SustCon)
                    {
                        SaveGame.HasSustainConstitution = true;
                    }
                    if (oPtr.Characteristics.SustCha)
                    {
                        SaveGame.HasSustainCharisma = true;
                    }
                    SaveGame.BaseArmorClass += oPtr.BaseArmorClass;
                    SaveGame.DisplayedBaseArmorClass.Value += oPtr.BaseArmorClass;
                    SaveGame.ArmorClassBonus += oPtr.BonusArmorClass;
                    if (oPtr.IsKnown())
                    {
                        SaveGame.DisplayedArmorClassBonus.Value += oPtr.BonusArmorClass;
                    }
                    if (inventorySlot.IsWeapon)
                    {
                        continue;
                    }
                    SaveGame.AttackBonus += oPtr.BonusToHit;
                    SaveGame.DamageBonus += oPtr.BonusDamage;
                    if (oPtr.IsKnown())
                    {
                        SaveGame.DisplayedAttackBonus += oPtr.BonusToHit;
                    }
                    if (oPtr.IsKnown())
                    {
                        SaveGame.DisplayedDamageBonus += oPtr.BonusDamage;
                    }
                }
            }
        }
        if ((SaveGame.BaseCharacterClass.ID == CharacterClass.Monk || SaveGame.BaseCharacterClass.ID == CharacterClass.Mystic) && !SaveGame.MartialArtistHeavyArmor())
        {
            foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots)
            {
                if (inventorySlot.Count == 0)
                {
                    int bareArmorBonus = inventorySlot.BareArmorClassBonus;
                    SaveGame.ArmorClassBonus += bareArmorBonus;
                    SaveGame.DisplayedArmorClassBonus.Value += bareArmorBonus;
                }
            }
        }
        if (SaveGame.HasFireShield)
        {
            SaveGame.HasGlow = true;
        }
        for (int i = 0; i < 6; i++)
        {
            int ind;
            int top = SaveGame.AbilityScores[i]
                .ModifyStatValue(SaveGame.AbilityScores[i].InnateMax, SaveGame.AbilityScores[i].Bonus);
            if (SaveGame.AbilityScores[i].AdjustedMax != top)
            {
                SaveGame.AbilityScores[i].AdjustedMax = top;
                SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawStatsFlaggedAction)).Set();
            }
            int use = SaveGame.AbilityScores[i]
                .ModifyStatValue(SaveGame.AbilityScores[i].Innate, SaveGame.AbilityScores[i].Bonus);
            if (i == Ability.Charisma && SaveGame.CharismaOverride)
            {
                if (use < 8 + (2 * SaveGame.ExperienceLevel))
                {
                    use = 8 + (2 * SaveGame.ExperienceLevel);
                }
            }
            if (SaveGame.AbilityScores[i].Adjusted != use)
            {
                SaveGame.AbilityScores[i].Adjusted = use;
                SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawStatsFlaggedAction)).Set();
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
            if (SaveGame.AbilityScores[i].TableIndex != ind)
            {
                SaveGame.AbilityScores[i].TableIndex = ind;
                if (i == Ability.Constitution)
                {
                    SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateHealthFlaggedAction)).Set();
                }
                else if (i == Ability.Intelligence)
                {
                    if (SaveGame.BaseCharacterClass.SpellStat == Ability.Intelligence)
                    {
                        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateManaFlaggedAction)).Set();
                        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateSpellsFlaggedAction)).Set();
                    }
                }
                else if (i == Ability.Wisdom)
                {
                    if (SaveGame.BaseCharacterClass.SpellStat == Ability.Wisdom)
                    {
                        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateManaFlaggedAction)).Set();
                        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateSpellsFlaggedAction)).Set();
                    }
                }
                else if (i == Ability.Charisma)
                {
                    if (SaveGame.BaseCharacterClass.SpellStat == Ability.Charisma)
                    {
                        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateManaFlaggedAction)).Set();
                        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateSpellsFlaggedAction)).Set();
                    }
                }
            }
        }
        if (SaveGame.StunTimer.Value > 50)
        {
            SaveGame.AttackBonus -= 20;
            SaveGame.DisplayedAttackBonus -= 20;
            SaveGame.DamageBonus -= 20;
            SaveGame.DisplayedDamageBonus -= 20;
        }
        else if (SaveGame.StunTimer.Value != 0)
        {
            SaveGame.AttackBonus -= 5;
            SaveGame.DisplayedAttackBonus -= 5;
            SaveGame.DamageBonus -= 5;
            SaveGame.DisplayedDamageBonus -= 5;
        }
        if (SaveGame.InvulnerabilityTimer.Value != 0)
        {
            SaveGame.ArmorClassBonus += 100;
            SaveGame.DisplayedArmorClassBonus.Value += 100;
        }
        if (SaveGame.EtherealnessTimer.Value != 0)
        {
            SaveGame.ArmorClassBonus += 100;
            SaveGame.DisplayedArmorClassBonus.Value += 100;
            SaveGame.HasReflection = true;
        }
        if (SaveGame.BlessingTimer.Value != 0)
        {
            SaveGame.ArmorClassBonus += 5;
            SaveGame.DisplayedArmorClassBonus.Value += 5;
            SaveGame.AttackBonus += 10;
            SaveGame.DisplayedAttackBonus += 10;
        }
        if (SaveGame.StoneskinTimer.Value != 0)
        {
            SaveGame.ArmorClassBonus += 50;
            SaveGame.DisplayedArmorClassBonus.Value += 50;
        }
        if (SaveGame.HeroismTimer.Value != 0)
        {
            SaveGame.AttackBonus += 12;
            SaveGame.DisplayedAttackBonus += 12;
        }
        if (SaveGame.SuperheroismTimer.Value != 0)
        {
            SaveGame.AttackBonus += 24;
            SaveGame.DisplayedAttackBonus += 24;
            SaveGame.ArmorClassBonus -= 10;
            SaveGame.DisplayedArmorClassBonus.Value -= 10;
        }
        if (SaveGame.HasteTimer.Value != 0)
        {
            SaveGame.Speed.Value += 10;
        }
        if (SaveGame.SlowTimer.Value != 0)
        {
            SaveGame.Speed.Value -= 10;
        }
        if ((SaveGame.BaseCharacterClass.ID == CharacterClass.Monk || SaveGame.BaseCharacterClass.ID == CharacterClass.Mystic) && !SaveGame.MartialArtistHeavyArmor())
        {
            SaveGame.Speed.Value += SaveGame.ExperienceLevel / 10;
        }
        if (SaveGame.TelepathyTimer.Value != 0)
        {
            SaveGame.HasTelepathy = true;
        }
        if (SaveGame.SeeInvisibilityTimer.Value != 0)
        {
            SaveGame.HasSeeInvisibility = true;
        }
        if (SaveGame.InfravisionTimer.Value != 0)
        {
            SaveGame.InfravisionRange++;
        }
        if (SaveGame.HasChaosResistance)
        {
            SaveGame.HasConfusionResistance = true;
        }
        if (SaveGame.HeroismTimer.Value != 0 || SaveGame.SuperheroismTimer.Value != 0)
        {
            SaveGame.HasFearResistance = true;
        }
        if (SaveGame.HasTelepathy != oldTelepathy)
        {
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateMonstersFlaggedAction)).Set();
        }
        if (SaveGame.HasSeeInvisibility != oldSeeInv)
        {
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateMonstersFlaggedAction)).Set();
        }
        int j = SaveGame.WeightCarried;

        // Compute the weight limit.
        int ii = SaveGame.AbilityScores[Ability.Strength].StrCarryingCapacity * 100;

        if (j > ii / 2)
        {
            SaveGame.Speed.Value -= (j - (ii / 2)) / (ii / 10);
        }
        if (SaveGame.Food.Value >= Constants.PyFoodMax)
        {
            SaveGame.Speed.Value -= 10;
        }
        if (SaveGame.IsSearching)
        {
            SaveGame.Speed.Value -= 10;
        }
        if (SaveGame.Speed.Value != oldSpeed)
        {
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawSpeedFlaggedAction)).Set();
        }
        SaveGame.ArmorClassBonus += SaveGame.AbilityScores[Ability.Dexterity].DexArmorClassBonus;
        SaveGame.DamageBonus += SaveGame.AbilityScores[Ability.Strength].StrDamageBonus;
        SaveGame.AttackBonus += SaveGame.AbilityScores[Ability.Dexterity].DexAttackBonus;
        SaveGame.AttackBonus += SaveGame.AbilityScores[Ability.Strength].StrAttackBonus;
        SaveGame.DisplayedArmorClassBonus.Value += SaveGame.AbilityScores[Ability.Dexterity].DexArmorClassBonus;
        SaveGame.DisplayedDamageBonus += SaveGame.AbilityScores[Ability.Strength].StrDamageBonus;
        SaveGame.DisplayedAttackBonus += SaveGame.AbilityScores[Ability.Dexterity].DexAttackBonus;
        SaveGame.DisplayedAttackBonus += SaveGame.AbilityScores[Ability.Strength].StrAttackBonus;
        if (SaveGame.DisplayedBaseArmorClass.Value != oldDisAc || SaveGame.DisplayedArmorClassBonus.Value != oldDisToA)
        {
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawArmorFlaggedAction)).Set();
        }
        int hold = SaveGame.AbilityScores[Ability.Strength].StrMaxWeaponWeight;
        foreach (BaseInventorySlot rangedWeaponInventorySlot in SaveGame.SingletonRepository.InventorySlots.Where(_inventorySlot => _inventorySlot.IsRangedWeapon))
        {
            foreach (int index in rangedWeaponInventorySlot.InventorySlots)
            {
                SaveGame.HasHeavyBow = false;
                Item? oPtr = SaveGame.GetInventoryItem(index);
                if (oPtr != null)
                {
                    if (hold < oPtr.Weight / 10)
                    {
                        SaveGame.AttackBonus += 2 * (hold - (oPtr.Weight / 10));
                        SaveGame.DisplayedAttackBonus += 2 * (hold - (oPtr.Weight / 10));
                        SaveGame.HasHeavyBow = true;
                    }
                    if (!SaveGame.HasHeavyBow)
                    {
                        // Since this came from the ranged weapon, we know it is a missile weapon type/bow.
                        BowWeaponItemFactory missileWeaponItemCategory = (BowWeaponItemFactory)oPtr.Factory;
                        SaveGame.AmmunitionItemCategory = missileWeaponItemCategory.AmmunitionItemCategory;
                        if (SaveGame.BaseCharacterClass.ID == CharacterClass.Ranger && SaveGame.AmmunitionItemCategory == ItemTypeEnum.Arrow)
                        {
                            if (SaveGame.ExperienceLevel >= 20)
                            {
                                SaveGame.MissileAttacksPerRound++;
                            }
                            if (SaveGame.ExperienceLevel >= 40)
                            {
                                SaveGame.MissileAttacksPerRound++;
                            }
                        }
                        if (SaveGame.BaseCharacterClass.ID == CharacterClass.Warrior && SaveGame.AmmunitionItemCategory <= ItemTypeEnum.Bolt &&
                            SaveGame.AmmunitionItemCategory >= ItemTypeEnum.Shot)
                        {
                            if (SaveGame.ExperienceLevel >= 25)
                            {
                                SaveGame.MissileAttacksPerRound++;
                            }
                            if (SaveGame.ExperienceLevel >= 50)
                            {
                                SaveGame.MissileAttacksPerRound++;
                            }
                        }
                        SaveGame.MissileAttacksPerRound += extraShots;
                        if (SaveGame.MissileAttacksPerRound < 1)
                        {
                            SaveGame.MissileAttacksPerRound = 1;
                        }
                    }
                }
            }
        }

        foreach (BaseInventorySlot meleeWeaponInventorySlot in SaveGame.SingletonRepository.InventorySlots.Where(_inventorySlot => _inventorySlot.IsMeleeWeapon))
        {
            foreach (int index in meleeWeaponInventorySlot.InventorySlots)
            {
                SaveGame.HasHeavyWeapon = false;
                Item? oPtr = SaveGame.GetInventoryItem(index);
                if (oPtr != null && hold < oPtr.Weight / 10)
                {
                    SaveGame.AttackBonus += 2 * (hold - (oPtr.Weight / 10));
                    SaveGame.DisplayedAttackBonus += 2 * (hold - (oPtr.Weight / 10));
                    SaveGame.HasHeavyWeapon = true;
                }
                if (oPtr != null && !SaveGame.HasHeavyWeapon)
                {
                    int num = SaveGame.BaseCharacterClass.MaximumMeleeAttacksPerRound(SaveGame.ExperienceLevel);
                    int wgt = SaveGame.BaseCharacterClass.MaximumWeight;
                    int mul = SaveGame.BaseCharacterClass.AttackSpeedMultiplier;
                    int div = oPtr.Weight < wgt ? wgt : oPtr.Weight;
                    int strIndex = SaveGame.AbilityScores[Ability.Strength].StrAttackSpeedComponent * mul / div;
                    if (strIndex > 11)
                    {
                        strIndex = 11;
                    }
                    int dexIndex = SaveGame.AbilityScores[Ability.Dexterity].DexAttackSpeedComponent;
                    if (dexIndex > 11)
                    {
                        dexIndex = 11;
                    }
                    SaveGame.MeleeAttacksPerRound = _blowsTable[strIndex][dexIndex];
                    if (SaveGame.MeleeAttacksPerRound > num)
                    {
                        SaveGame.MeleeAttacksPerRound = num;
                    }
                    SaveGame.MeleeAttacksPerRound += extraBlows;
                    if (SaveGame.BaseCharacterClass.ID == CharacterClass.Warrior)
                    {
                        SaveGame.MeleeAttacksPerRound += SaveGame.ExperienceLevel / 15;
                    }
                    if (SaveGame.MeleeAttacksPerRound < 1)
                    {
                        SaveGame.MeleeAttacksPerRound = 1;
                    }
                    SaveGame.SkillDigging += oPtr.Weight / 10;
                }
                else if ((SaveGame.BaseCharacterClass.ID == CharacterClass.Monk || SaveGame.BaseCharacterClass.ID == CharacterClass.Mystic) && SaveGame.MartialArtistEmptyHands())
                {
                    SaveGame.MeleeAttacksPerRound = 0;
                    if (SaveGame.ExperienceLevel > 9)
                    {
                        SaveGame.MeleeAttacksPerRound++;
                    }
                    if (SaveGame.ExperienceLevel > 19)
                    {
                        SaveGame.MeleeAttacksPerRound++;
                    }
                    if (SaveGame.ExperienceLevel > 29)
                    {
                        SaveGame.MeleeAttacksPerRound++;
                    }
                    if (SaveGame.ExperienceLevel > 34)
                    {
                        SaveGame.MeleeAttacksPerRound++;
                    }
                    if (SaveGame.ExperienceLevel > 39)
                    {
                        SaveGame.MeleeAttacksPerRound++;
                    }
                    if (SaveGame.ExperienceLevel > 44)
                    {
                        SaveGame.MeleeAttacksPerRound++;
                    }
                    if (SaveGame.ExperienceLevel > 49)
                    {
                        SaveGame.MeleeAttacksPerRound++;
                    }
                    if (SaveGame.MartialArtistHeavyArmor())
                    {
                        SaveGame.MeleeAttacksPerRound /= 2;
                    }
                    SaveGame.MeleeAttacksPerRound += 1 + extraBlows;
                    if (!SaveGame.MartialArtistHeavyArmor())
                    {
                        SaveGame.AttackBonus += SaveGame.ExperienceLevel / 3;
                        SaveGame.DamageBonus += SaveGame.ExperienceLevel / 3;
                        SaveGame.DisplayedAttackBonus += SaveGame.ExperienceLevel / 3;
                        SaveGame.DisplayedDamageBonus += SaveGame.ExperienceLevel / 3;
                    }
                }

                SaveGame.HasUnpriestlyWeapon = false;
                MartialArtistArmorAux = false;
                if (SaveGame.BaseCharacterClass.ID == CharacterClass.Warrior)
                {
                    SaveGame.AttackBonus += SaveGame.ExperienceLevel / 5;
                    SaveGame.DamageBonus += SaveGame.ExperienceLevel / 5;
                    SaveGame.DisplayedAttackBonus += SaveGame.ExperienceLevel / 5;
                    SaveGame.DisplayedDamageBonus += SaveGame.ExperienceLevel / 5;
                }
                if ((SaveGame.BaseCharacterClass.ID == CharacterClass.Priest || SaveGame.BaseCharacterClass.ID == CharacterClass.Druid) && !SaveGame.HasBlessedBlade && oPtr != null && (oPtr.Category == ItemTypeEnum.Sword || oPtr.Category == ItemTypeEnum.Polearm))
                {
                    SaveGame.AttackBonus -= 2;
                    SaveGame.DamageBonus -= 2;
                    SaveGame.DisplayedAttackBonus -= 2;
                    SaveGame.DisplayedDamageBonus -= 2;
                    SaveGame.HasUnpriestlyWeapon = true;
                }

                SaveGame.BaseCharacterClass.UpdateBonusesForMeleeWeapon(oPtr);
                if (SaveGame.MartialArtistHeavyArmor())
                {
                    MartialArtistArmorAux = true;
                }
            }
        }

        SaveGame.SkillStealth++;
        SaveGame.SkillDisarmTraps += SaveGame.AbilityScores[Ability.Dexterity].DexDisarmBonus;
        SaveGame.SkillDisarmTraps += SaveGame.AbilityScores[Ability.Intelligence].IntDisarmBonus;
        SaveGame.SkillUseDevice += SaveGame.AbilityScores[Ability.Intelligence].IntUseDeviceBonus;
        SaveGame.SkillSavingThrow += SaveGame.AbilityScores[Ability.Wisdom].WisSavingThrowBonus;
        SaveGame.SkillDigging += SaveGame.AbilityScores[Ability.Strength].StrDiggingBonus;
        SaveGame.SkillDisarmTraps += (SaveGame.BaseCharacterClass.DisarmBonusPerLevel * SaveGame.ExperienceLevel) / 10;
        SaveGame.SkillUseDevice += (SaveGame.BaseCharacterClass.DeviceBonusPerLevel * SaveGame.ExperienceLevel) / 10;
        SaveGame.SkillSavingThrow += (SaveGame.BaseCharacterClass.SaveBonusPerLevel * SaveGame.ExperienceLevel) / 10;
        SaveGame.SkillStealth += (SaveGame.BaseCharacterClass.StealthBonusPerLevel * SaveGame.ExperienceLevel) / 10;
        SaveGame.SkillSearching += (SaveGame.BaseCharacterClass.SearchBonusPerLevel * SaveGame.ExperienceLevel) / 10;
        SaveGame.SkillSearchFrequency += (SaveGame.BaseCharacterClass.SearchFrequencyPerLevel * SaveGame.ExperienceLevel) / 10;
        SaveGame.SkillMelee += (SaveGame.BaseCharacterClass.MeleeAttackBonusPerLevel * SaveGame.ExperienceLevel) / 10;
        SaveGame.SkillRanged += (SaveGame.BaseCharacterClass.RangedAttackBonusPerLevel * SaveGame.ExperienceLevel) / 10;
        SaveGame.SkillThrowing += (SaveGame.BaseCharacterClass.RangedAttackBonusPerLevel * SaveGame.ExperienceLevel) / 10;
        if (SaveGame.SkillStealth > 30)
        {
            SaveGame.SkillStealth = 30;
        }
        if (SaveGame.SkillStealth < 0)
        {
            SaveGame.SkillStealth = 0;
        }
        if (SaveGame.SkillDigging < 1)
        {
            SaveGame.SkillDigging = 1;
        }
        if (SaveGame.HasAntiMagic && SaveGame.SkillSavingThrow < 95)
        {
            SaveGame.SkillSavingThrow = 95;
        }
        if (SaveGame.CharacterXtra)
        {
            return;
        }
        if (OldHeavyBow != SaveGame.HasHeavyBow) // TODO: This should be moved to the wield action
        {
            if (SaveGame.HasHeavyBow)
            {
                SaveGame.MsgPrint("You have trouble wielding such a heavy bow.");
            }
            else if (SaveGame.SingletonRepository.InventorySlots.Get(nameof(RangedWeaponInventorySlot)).Count > 0)
            {
                SaveGame.MsgPrint("You have no trouble wielding your bow.");
            }
            else
            {
                SaveGame.MsgPrint("You feel relieved to put down your heavy bow.");
            }
            OldHeavyBow = SaveGame.HasHeavyBow;
        }
        if (OldHeavyWeapon != SaveGame.HasHeavyWeapon) // TODO: This should be moved to the wield action
        {
            if (SaveGame.HasHeavyWeapon)
            {
                SaveGame.MsgPrint("You have trouble wielding such a heavy weapon.");
            }
            else if (SaveGame.SingletonRepository.InventorySlots.Get(nameof(MeleeWeaponInventorySlot)).Count > 0)
            {
                SaveGame.MsgPrint("You have no trouble wielding your weapon.");
            }
            else
            {
                SaveGame.MsgPrint("You feel relieved to put down your heavy weapon.");
            }
            OldHeavyWeapon = SaveGame.HasHeavyWeapon;
        }
        if (OldUnpriestlyWeapon != SaveGame.HasUnpriestlyWeapon) // TODO: This should be moved to the wield action
        {
            if (SaveGame.HasUnpriestlyWeapon)
            {
                SaveGame.MsgPrint(SaveGame.BaseCharacterClass.ID == CharacterClass.Cultist
                    ? "Your weapon restricts the flow of chaos through you."
                    : "You do not feel comfortable with your weapon.");
            }
            else if (SaveGame.GetInventoryItem(InventorySlot.MeleeWeapon) != null)
            {
                SaveGame.MsgPrint("You feel comfortable with your weapon.");
            }
            else
            {
                SaveGame.MsgPrint(SaveGame.BaseCharacterClass.ID == CharacterClass.Cultist
                    ? "Chaos flows freely through you again."
                    : "You feel more comfortable after removing your weapon.");
            }
            OldUnpriestlyWeapon = SaveGame.HasUnpriestlyWeapon;
        }
        if ((SaveGame.BaseCharacterClass.ID == CharacterClass.Monk || SaveGame.BaseCharacterClass.ID == CharacterClass.Mystic) && MartialArtistArmorAux != MartialArtistNotifyAux) // TODO: This should be moved to the wield action
        {
            SaveGame.MsgPrint(SaveGame.MartialArtistHeavyArmor()
                ? "The weight of your armor disrupts your balance."
                : "You regain your balance.");
            MartialArtistNotifyAux = MartialArtistArmorAux;
        }
    }

}
