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

    private UpdateBonusesFlaggedAction(Game game) : base(game) { }
    protected override void Execute()
    {
        int extraShots;
        int oldSpeed = Game.Speed.IntValue;
        bool oldTelepathy = Game.HasTelepathy;
        bool oldSeeInv = Game.HasSeeInvisibility;
        int extraBlows = extraShots = 0;
        for (int i = 0; i < 6; i++)
        {
            Game.AbilityScores[i].Bonus = 0;
        }
        Game.DisplayedBaseArmorClass.IntValue = 0;
        Game.BaseArmorClass = 0;
        Game.DisplayedAttackBonus = 0;
        Game.AttackBonus = 0;
        Game.DisplayedDamageBonus = 0;
        Game.DamageBonus = 0;
        Game.DisplayedArmorClassBonus.IntValue = 0;
        Game.ArmorClassBonus = 0;
        Game.HasAggravation = false;
        Game.HasRandomTeleport = false;
        Game.HasExperienceDrain = false;
        Game.HasBlessedBlade = false;
        Game.HasExtraMight = false;
        Game.HasQuakeWeapon = false;
        Game.HasSeeInvisibility = false;
        Game.HasFreeAction = false;
        Game.HasSlowDigestion = false;
        Game.HasRegeneration = false;
        Game.HasFeatherFall = false;
        Game.HasHoldLife = false;
        Game.HasTelepathy = false;
        Game.HasGlow = false;
        Game.HasSustainStrength = false;
        Game.HasSustainIntelligence = false;
        Game.HasSustainWisdom = false;
        Game.HasSustainConstitution = false;
        Game.HasSustainDexterity = false;
        Game.HasSustainCharisma = false;
        Game.HasAcidResistance = false;
        Game.HasLightningResistance = false;
        Game.HasFireResistance = false;
        Game.HasColdResistance = false;
        Game.HasPoisonResistance = false;
        Game.HasConfusionResistance = false;
        Game.HasSoundResistance = false;
        Game.HasTimeResistance = false;
        Game.HasLightResistance = false;
        Game.HasDarkResistance = false;
        Game.HasChaosResistance = false;
        Game.HasDisenchantResistance = false;
        Game.HasShardResistance = false;
        Game.HasNexusResistance = false;
        Game.HasBlindnessResistance = false;
        Game.HasNetherResistance = false;
        Game.HasFearResistance = false;
        Game.HasElementalVulnerability = false;
        Game.HasReflection = false;
        Game.HasFireShield = false;
        Game.HasLightningShield = false;
        Game.HasAntiMagic = false;
        Game.HasAntiTeleport = false;
        Game.HasAntiTheft = false;
        Game.HasAcidImmunity = false;
        Game.HasLightningImmunity = false;
        Game.HasFireImmunity = false;
        Game.HasColdImmunity = false;
        Game.InfravisionRange = Game.Race.Infravision;
        Game.SkillDisarmTraps = Game.Race.BaseDisarmBonus + Game.BaseCharacterClass.BaseDisarmBonus;
        Game.SkillUseDevice = Game.Race.BaseDeviceBonus + Game.BaseCharacterClass.BaseDeviceBonus;
        Game.SkillSavingThrow = Game.Race.BaseSaveBonus + Game.BaseCharacterClass.BaseSaveBonus;
        Game.SkillStealth = Game.Race.BaseStealthBonus + Game.BaseCharacterClass.BaseStealthBonus;
        Game.SkillSearching = Game.Race.BaseSearchBonus + Game.BaseCharacterClass.BaseSearchBonus;
        Game.SkillSearchFrequency = Game.Race.BaseSearchFrequency + Game.BaseCharacterClass.BaseSearchFrequency;
        Game.SkillMelee = Game.Race.BaseMeleeAttackBonus + Game.BaseCharacterClass.BaseMeleeAttackBonus;
        Game.SkillRanged = Game.Race.BaseRangedAttackBonus + Game.BaseCharacterClass.BaseRangedAttackBonus;
        Game.SkillThrowing = Game.Race.BaseRangedAttackBonus + Game.BaseCharacterClass.BaseRangedAttackBonus;
        Game.SkillDigging = 0;
        if ((Game.BaseCharacterClass.ID == CharacterClass.Warrior && Game.ExperienceLevel.IntValue > 29) ||
            (Game.BaseCharacterClass.ID == CharacterClass.Paladin && Game.ExperienceLevel.IntValue > 39) ||
            (Game.BaseCharacterClass.ID == CharacterClass.Fanatic && Game.ExperienceLevel.IntValue > 39))
        {
            Game.HasFearResistance = true;
        }
        if (Game.BaseCharacterClass.ID == CharacterClass.Fanatic && Game.ExperienceLevel.IntValue > 29)
        {
            Game.HasChaosResistance = true;
        }
        if (Game.BaseCharacterClass.ID == CharacterClass.Cultist && Game.ExperienceLevel.IntValue > 19)
        {
            Game.HasChaosResistance = true;
        }
        if (Game.BaseCharacterClass.ID == CharacterClass.Mindcrafter)
        {
            if (Game.ExperienceLevel.IntValue > 9)
            {
                Game.HasFearResistance = true;
            }
            if (Game.ExperienceLevel.IntValue > 19)
            {
                Game.HasSustainWisdom = true;
            }
            if (Game.ExperienceLevel.IntValue > 29)
            {
                Game.HasConfusionResistance = true;
            }
            if (Game.ExperienceLevel.IntValue > 39)
            {
                Game.HasTelepathy = true;
            }
        }
        if (Game.BaseCharacterClass.ID == CharacterClass.Monk && Game.ExperienceLevel.IntValue > 24 && !Game.MartialArtistHeavyArmor())
        {
            Game.HasFreeAction = true;
        }
        if (Game.BaseCharacterClass.ID == CharacterClass.Mystic)
        {
            if (Game.ExperienceLevel.IntValue > 9)
            {
                Game.HasConfusionResistance = true;
            }
            if (Game.ExperienceLevel.IntValue > 24)
            {
                Game.HasFearResistance = true;
            }
            if (Game.ExperienceLevel.IntValue > 29 && !Game.MartialArtistHeavyArmor())
            {
                Game.HasFreeAction = true;
            }
            if (Game.ExperienceLevel.IntValue > 39)
            {
                Game.HasTelepathy = true;
            }
        }
        if (Game.BaseCharacterClass.ID == CharacterClass.ChosenOne)
        {
            Game.HasGlow = true;
            if (Game.ExperienceLevel.IntValue >= 2)
            {
                Game.HasConfusionResistance = true;
            }
            if (Game.ExperienceLevel.IntValue >= 4)
            {
                Game.HasFearResistance = true;
            }
            if (Game.ExperienceLevel.IntValue >= 6)
            {
                Game.HasBlindnessResistance = true;
            }
            if (Game.ExperienceLevel.IntValue >= 8)
            {
                Game.HasFeatherFall = true;
            }
            if (Game.ExperienceLevel.IntValue >= 10)
            {
                Game.HasSeeInvisibility = true;
            }
            if (Game.ExperienceLevel.IntValue >= 12)
            {
                Game.HasSlowDigestion = true;
            }
            if (Game.ExperienceLevel.IntValue >= 14)
            {
                Game.HasSustainConstitution = true;
            }
            if (Game.ExperienceLevel.IntValue >= 16)
            {
                Game.HasPoisonResistance = true;
            }
            if (Game.ExperienceLevel.IntValue >= 18)
            {
                Game.HasSustainDexterity = true;
            }
            if (Game.ExperienceLevel.IntValue >= 20)
            {
                Game.HasSustainStrength = true;
            }
            if (Game.ExperienceLevel.IntValue >= 22)
            {
                Game.HasHoldLife = true;
            }
            if (Game.ExperienceLevel.IntValue >= 24)
            {
                Game.HasFreeAction = true;
            }
            if (Game.ExperienceLevel.IntValue >= 26)
            {
                Game.HasTelepathy = true;
            }
            if (Game.ExperienceLevel.IntValue >= 28)
            {
                Game.HasDarkResistance = true;
            }
            if (Game.ExperienceLevel.IntValue >= 30)
            {
                Game.HasLightResistance = true;
            }
            if (Game.ExperienceLevel.IntValue >= 32)
            {
                Game.HasSustainCharisma = true;
            }
            if (Game.ExperienceLevel.IntValue >= 34)
            {
                Game.HasSoundResistance = true;
            }
            if (Game.ExperienceLevel.IntValue >= 36)
            {
                Game.HasDisenchantResistance = true;
            }
            if (Game.ExperienceLevel.IntValue >= 38)
            {
                Game.HasRegeneration = true;
            }
            if (Game.ExperienceLevel.IntValue >= 40)
            {
                Game.HasSustainIntelligence = true;
            }
            if (Game.ExperienceLevel.IntValue >= 42)
            {
                Game.HasChaosResistance = true;
            }
            if (Game.ExperienceLevel.IntValue >= 44)
            {
                Game.HasSustainWisdom = true;
            }
            if (Game.ExperienceLevel.IntValue >= 46)
            {
                Game.HasNexusResistance = true;
            }
            if (Game.ExperienceLevel.IntValue >= 48)
            {
                Game.HasShardResistance = true;
            }
            if (Game.ExperienceLevel.IntValue >= 50)
            {
                Game.HasNetherResistance = true;
            }
        }
        Game.Race.CalcBonuses();
        Game.Speed.IntValue = 110;
        Game.MeleeAttacksPerRound = 1;
        Game.MissileAttacksPerRound = 1;
        Game.AmmunitionItemCategory = 0;
        for (int i = 0; i < 6; i++)
        {
            Game.AbilityScores[i].Bonus += Game.Race.AbilityBonus[i] + Game.BaseCharacterClass.AbilityBonus[i];
        }
        Game.AbilityScores[Ability.Strength].Bonus += Game.StrengthBonus;
        Game.AbilityScores[Ability.Intelligence].Bonus += Game.IntelligenceBonus;
        Game.AbilityScores[Ability.Wisdom].Bonus += Game.WisdomBonus;
        Game.AbilityScores[Ability.Dexterity].Bonus += Game.DexterityBonus;
        Game.AbilityScores[Ability.Constitution].Bonus += Game.ConstitutionBonus;
        Game.AbilityScores[Ability.Charisma].Bonus += Game.CharismaBonus;
        Game.Speed.IntValue += Game.SpeedBonus;
        Game.HasRegeneration |= Game.Regen;
        Game.SkillSearchFrequency += Game.SearchBonus;
        Game.SkillSearching += Game.SearchBonus;
        Game.InfravisionRange += Game.InfravisionBonus;
        Game.HasLightningShield |= Game.ElecHit;
        Game.HasFireShield |= Game.FireHit;
        Game.HasGlow |= Game.FireHit;
        Game.ArmorClassBonus += Game.GenomeArmorClassBonus;
        Game.DisplayedArmorClassBonus.IntValue += Game.GenomeArmorClassBonus;
        Game.HasFeatherFall |= Game.FeatherFall;
        Game.HasFearResistance |= Game.ResFear;
        Game.HasTimeResistance |= Game.ResTime;
        Game.HasTelepathy |= Game.Esp;
        Game.SkillStealth += Game.StealthBonus;
        Game.HasFreeAction |= Game.FreeAction;
        Game.HasElementalVulnerability |= Game.Vulnerable;
        if (Game.MagicResistance)
        {
            Game.SkillSavingThrow += 15 + (Game.ExperienceLevel.IntValue / 5);
        }
        if (Game.SuppressRegen)
        {
            Game.HasRegeneration = false;
        }
        if (Game.CharismaOverride)
        {
            Game.AbilityScores[Ability.Charisma].Bonus = 0;
        }
        if (Game.SustainAll)
        {
            Game.HasSustainConstitution = true;
            if (Game.ExperienceLevel.IntValue > 9)
            {
                Game.HasSustainStrength = true;
            }
            if (Game.ExperienceLevel.IntValue > 19)
            {
                Game.HasSustainDexterity = true;
            }
            if (Game.ExperienceLevel.IntValue > 29)
            {
                Game.HasSustainWisdom = true;
            }
            if (Game.ExperienceLevel.IntValue > 39)
            {
                Game.HasSustainIntelligence = true;
            }
            if (Game.ExperienceLevel.IntValue > 49)
            {
                Game.HasSustainCharisma = true;
            }
        }
        foreach (BaseInventorySlot inventorySlot in Game.SingletonRepository.Get<BaseInventorySlot>().Where(_inventorySlot => _inventorySlot.IsEquipment))
        {
            foreach (int i in inventorySlot.InventorySlots)
            {
                Item? oPtr = Game.GetInventoryItem(i);
                if (oPtr != null)
                {
                    oPtr.RefreshFlagBasedProperties();
                    if (oPtr.Characteristics.Str)
                    {
                        Game.AbilityScores[Ability.Strength].Bonus += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Int)
                    {
                        Game.AbilityScores[Ability.Intelligence].Bonus += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Wis)
                    {
                        Game.AbilityScores[Ability.Wisdom].Bonus += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Dex)
                    {
                        Game.AbilityScores[Ability.Dexterity].Bonus += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Con)
                    {
                        Game.AbilityScores[Ability.Constitution].Bonus += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Cha)
                    {
                        Game.AbilityScores[Ability.Charisma].Bonus += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Stealth)
                    {
                        Game.SkillStealth += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Search)
                    {
                        Game.SkillSearching += oPtr.TypeSpecificValue * 5;
                    }
                    if (oPtr.Characteristics.Search)
                    {
                        Game.SkillSearchFrequency += oPtr.TypeSpecificValue * 5;
                    }
                    if (oPtr.Characteristics.Infra)
                    {
                        Game.InfravisionRange += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Tunnel)
                    {
                        Game.SkillDigging += oPtr.TypeSpecificValue * 20;
                    }
                    if (oPtr.Characteristics.Speed)
                    {
                        Game.Speed.IntValue += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Blows)
                    {
                        extraBlows += oPtr.TypeSpecificValue;
                    }
                    if (oPtr.Characteristics.Impact)
                    {
                        Game.HasQuakeWeapon = true;
                    }
                    if (oPtr.Characteristics.AntiTheft)
                    {
                        Game.HasAntiTheft = true;
                    }
                    if (oPtr.Characteristics.XtraShots)
                    {
                        extraShots++;
                    }
                    if (oPtr.Characteristics.Aggravate)
                    {
                        Game.HasAggravation = true;
                    }
                    if (oPtr.Characteristics.Teleport)
                    {
                        Game.HasRandomTeleport = true;
                    }
                    if (oPtr.Characteristics.DrainExp)
                    {
                        Game.HasExperienceDrain = true;
                    }
                    if (oPtr.Characteristics.Blessed)
                    {
                        Game.HasBlessedBlade = true;
                    }
                    if (oPtr.Characteristics.XtraMight)
                    {
                        Game.HasExtraMight = true;
                    }
                    if (oPtr.Characteristics.SlowDigest)
                    {
                        Game.HasSlowDigestion = true;
                    }
                    if (oPtr.Characteristics.Regen)
                    {
                        Game.HasRegeneration = true;
                    }
                    if (oPtr.Characteristics.Telepathy)
                    {
                        Game.HasTelepathy = true;
                    }
                    if (oPtr.Characteristics.Lightsource)
                    {
                        Game.HasGlow = true;
                    }
                    if (oPtr.Characteristics.SeeInvis)
                    {
                        Game.HasSeeInvisibility = true;
                    }
                    if (oPtr.Characteristics.Feather)
                    {
                        Game.HasFeatherFall = true;
                    }
                    if (oPtr.Characteristics.FreeAct)
                    {
                        Game.HasFreeAction = true;
                    }
                    if (oPtr.Characteristics.HoldLife)
                    {
                        Game.HasHoldLife = true;
                    }
                    if (oPtr.Characteristics.Wraith)
                    {
                        Game.EtherealnessTimer.SetValue(Math.Max(Game.EtherealnessTimer.Value, 20));
                    }
                    if (oPtr.Characteristics.ImFire)
                    {
                        Game.HasFireImmunity = true;
                    }
                    if (oPtr.Characteristics.ImAcid)
                    {
                        Game.HasAcidImmunity = true;
                    }
                    if (oPtr.Characteristics.ImCold)
                    {
                        Game.HasColdImmunity = true;
                    }
                    if (oPtr.Characteristics.ImElec)
                    {
                        Game.HasLightningImmunity = true;
                    }
                    if (oPtr.Characteristics.ResAcid)
                    {
                        Game.HasAcidResistance = true;
                    }
                    if (oPtr.Characteristics.ResElec)
                    {
                        Game.HasLightningResistance = true;
                    }
                    if (oPtr.Characteristics.ResFire)
                    {
                        Game.HasFireResistance = true;
                    }
                    if (oPtr.Characteristics.ResCold)
                    {
                        Game.HasColdResistance = true;
                    }
                    if (oPtr.Characteristics.ResPois)
                    {
                        Game.HasPoisonResistance = true;
                    }
                    if (oPtr.Characteristics.ResFear)
                    {
                        Game.HasFearResistance = true;
                    }
                    if (oPtr.Characteristics.ResConf)
                    {
                        Game.HasConfusionResistance = true;
                    }
                    if (oPtr.Characteristics.ResSound)
                    {
                        Game.HasSoundResistance = true;
                    }
                    if (oPtr.Characteristics.ResLight)
                    {
                        Game.HasLightResistance = true;
                    }
                    if (oPtr.Characteristics.ResDark)
                    {
                        Game.HasDarkResistance = true;
                    }
                    if (oPtr.Characteristics.ResChaos)
                    {
                        Game.HasChaosResistance = true;
                    }
                    if (oPtr.Characteristics.ResDisen)
                    {
                        Game.HasDisenchantResistance = true;
                    }
                    if (oPtr.Characteristics.ResShards)
                    {
                        Game.HasShardResistance = true;
                    }
                    if (oPtr.Characteristics.ResNexus)
                    {
                        Game.HasNexusResistance = true;
                    }
                    if (oPtr.Characteristics.ResBlind)
                    {
                        Game.HasBlindnessResistance = true;
                    }
                    if (oPtr.Characteristics.ResNether)
                    {
                        Game.HasNetherResistance = true;
                    }
                    if (oPtr.Characteristics.Reflect)
                    {
                        Game.HasReflection = true;
                    }
                    if (oPtr.Characteristics.ShFire)
                    {
                        Game.HasFireShield = true;
                    }
                    if (oPtr.Characteristics.ShElec)
                    {
                        Game.HasLightningShield = true;
                    }
                    if (oPtr.Characteristics.NoMagic)
                    {
                        Game.HasAntiMagic = true;
                    }
                    if (oPtr.Characteristics.NoTele)
                    {
                        Game.HasAntiTeleport = true;
                    }
                    if (oPtr.Characteristics.SustStr)
                    {
                        Game.HasSustainStrength = true;
                    }
                    if (oPtr.Characteristics.SustInt)
                    {
                        Game.HasSustainIntelligence = true;
                    }
                    if (oPtr.Characteristics.SustWis)
                    {
                        Game.HasSustainWisdom = true;
                    }
                    if (oPtr.Characteristics.SustDex)
                    {
                        Game.HasSustainDexterity = true;
                    }
                    if (oPtr.Characteristics.SustCon)
                    {
                        Game.HasSustainConstitution = true;
                    }
                    if (oPtr.Characteristics.SustCha)
                    {
                        Game.HasSustainCharisma = true;
                    }
                    Game.BaseArmorClass += oPtr.BaseArmorClass;
                    Game.DisplayedBaseArmorClass.IntValue += oPtr.BaseArmorClass;
                    Game.ArmorClassBonus += oPtr.BonusArmorClass;
                    if (oPtr.IsKnown())
                    {
                        Game.DisplayedArmorClassBonus.IntValue += oPtr.BonusArmorClass;
                    }
                    if (inventorySlot.IsWeapon)
                    {
                        continue;
                    }
                    Game.AttackBonus += oPtr.BonusToHit;
                    Game.DamageBonus += oPtr.BonusDamage;
                    if (oPtr.IsKnown())
                    {
                        Game.DisplayedAttackBonus += oPtr.BonusToHit;
                    }
                    if (oPtr.IsKnown())
                    {
                        Game.DisplayedDamageBonus += oPtr.BonusDamage;
                    }
                }
            }
        }
        if ((Game.BaseCharacterClass.ID == CharacterClass.Monk || Game.BaseCharacterClass.ID == CharacterClass.Mystic) && !Game.MartialArtistHeavyArmor())
        {
            foreach (BaseInventorySlot inventorySlot in Game.SingletonRepository.Get<BaseInventorySlot>())
            {
                if (inventorySlot.Count == 0)
                {
                    int bareArmorBonus = inventorySlot.BareArmorClassBonus;
                    Game.ArmorClassBonus += bareArmorBonus;
                    Game.DisplayedArmorClassBonus.IntValue += bareArmorBonus;
                }
            }
        }
        if (Game.HasFireShield)
        {
            Game.HasGlow = true;
        }
        for (int i = 0; i < 6; i++)
        {
            int ind;
            int top = Game.AbilityScores[i]
                .ModifyStatValue(Game.AbilityScores[i].InnateMax, Game.AbilityScores[i].Bonus);
            if (Game.AbilityScores[i].AdjustedMax != top)
            {
                Game.AbilityScores[i].AdjustedMax = top;
                Game.SingletonRepository.Get<FlaggedAction>(nameof(RedrawStatsFlaggedAction)).Set();
            }
            int use = Game.AbilityScores[i]
                .ModifyStatValue(Game.AbilityScores[i].Innate, Game.AbilityScores[i].Bonus);
            if (i == Ability.Charisma && Game.CharismaOverride)
            {
                if (use < 8 + (2 * Game.ExperienceLevel.IntValue))
                {
                    use = 8 + (2 * Game.ExperienceLevel.IntValue);
                }
            }
            if (Game.AbilityScores[i].Adjusted != use)
            {
                Game.AbilityScores[i].Adjusted = use;
                Game.SingletonRepository.Get<FlaggedAction>(nameof(RedrawStatsFlaggedAction)).Set();
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
            if (Game.AbilityScores[i].TableIndex != ind)
            {
                Game.AbilityScores[i].TableIndex = ind;
                if (i == Ability.Constitution)
                {
                    Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateHealthFlaggedAction)).Set();
                }
                else if (i == Ability.Intelligence)
                {
                    if (Game.BaseCharacterClass.SpellStat == Ability.Intelligence)
                    {
                        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
                        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateSpellsFlaggedAction)).Set();
                    }
                }
                else if (i == Ability.Wisdom)
                {
                    if (Game.BaseCharacterClass.SpellStat == Ability.Wisdom)
                    {
                        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
                        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateSpellsFlaggedAction)).Set();
                    }
                }
                else if (i == Ability.Charisma)
                {
                    if (Game.BaseCharacterClass.SpellStat == Ability.Charisma)
                    {
                        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
                        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateSpellsFlaggedAction)).Set();
                    }
                }
            }
        }
        if (Game.StunTimer.Value > 50)
        {
            Game.AttackBonus -= 20;
            Game.DisplayedAttackBonus -= 20;
            Game.DamageBonus -= 20;
            Game.DisplayedDamageBonus -= 20;
        }
        else if (Game.StunTimer.Value != 0)
        {
            Game.AttackBonus -= 5;
            Game.DisplayedAttackBonus -= 5;
            Game.DamageBonus -= 5;
            Game.DisplayedDamageBonus -= 5;
        }
        if (Game.InvulnerabilityTimer.Value != 0)
        {
            Game.ArmorClassBonus += 100;
            Game.DisplayedArmorClassBonus.IntValue += 100;
        }
        if (Game.EtherealnessTimer.Value != 0)
        {
            Game.ArmorClassBonus += 100;
            Game.DisplayedArmorClassBonus.IntValue += 100;
            Game.HasReflection = true;
        }
        if (Game.BlessingTimer.Value != 0)
        {
            Game.ArmorClassBonus += 5;
            Game.DisplayedArmorClassBonus.IntValue += 5;
            Game.AttackBonus += 10;
            Game.DisplayedAttackBonus += 10;
        }
        if (Game.StoneskinTimer.Value != 0)
        {
            Game.ArmorClassBonus += 50;
            Game.DisplayedArmorClassBonus.IntValue += 50;
        }
        if (Game.HeroismTimer.Value != 0)
        {
            Game.AttackBonus += 12;
            Game.DisplayedAttackBonus += 12;
        }
        if (Game.SuperheroismTimer.Value != 0)
        {
            Game.AttackBonus += 24;
            Game.DisplayedAttackBonus += 24;
            Game.ArmorClassBonus -= 10;
            Game.DisplayedArmorClassBonus.IntValue -= 10;
        }
        if (Game.HasteTimer.Value != 0)
        {
            Game.Speed.IntValue += 10;
        }
        if (Game.SlowTimer.Value != 0)
        {
            Game.Speed.IntValue -= 10;
        }
        if ((Game.BaseCharacterClass.ID == CharacterClass.Monk || Game.BaseCharacterClass.ID == CharacterClass.Mystic) && !Game.MartialArtistHeavyArmor())
        {
            Game.Speed.IntValue += Game.ExperienceLevel.IntValue / 10;
        }
        if (Game.TelepathyTimer.Value != 0)
        {
            Game.HasTelepathy = true;
        }
        if (Game.SeeInvisibilityTimer.Value != 0)
        {
            Game.HasSeeInvisibility = true;
        }
        if (Game.InfravisionTimer.Value != 0)
        {
            Game.InfravisionRange++;
        }
        if (Game.HasChaosResistance)
        {
            Game.HasConfusionResistance = true;
        }
        if (Game.HeroismTimer.Value != 0 || Game.SuperheroismTimer.Value != 0)
        {
            Game.HasFearResistance = true;
        }
        if (Game.HasTelepathy != oldTelepathy)
        {
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
        }
        if (Game.HasSeeInvisibility != oldSeeInv)
        {
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
        }
        int j = Game.WeightCarried;

        // Compute the weight limit.
        int ii = Game.AbilityScores[Ability.Strength].StrCarryingCapacity * 100;

        if (j > ii / 2)
        {
            Game.Speed.IntValue -= (j - (ii / 2)) / (ii / 10);
        }
        if (Game.Food.IntValue >= Constants.PyFoodMax)
        {
            Game.Speed.IntValue -= 10;
        }
        if (Game.IsSearching)
        {
            Game.Speed.IntValue -= 10;
        }
        if (Game.Speed.IntValue != oldSpeed)
        {
            Game.SingletonRepository.Get<FlaggedAction>(nameof(RedrawSpeedFlaggedAction)).Set();
        }
        Game.ArmorClassBonus += Game.AbilityScores[Ability.Dexterity].DexArmorClassBonus;
        Game.DamageBonus += Game.AbilityScores[Ability.Strength].StrDamageBonus;
        Game.AttackBonus += Game.AbilityScores[Ability.Dexterity].DexAttackBonus;
        Game.AttackBonus += Game.AbilityScores[Ability.Strength].StrAttackBonus;
        Game.DisplayedArmorClassBonus.IntValue += Game.AbilityScores[Ability.Dexterity].DexArmorClassBonus;
        Game.DisplayedDamageBonus += Game.AbilityScores[Ability.Strength].StrDamageBonus;
        Game.DisplayedAttackBonus += Game.AbilityScores[Ability.Dexterity].DexAttackBonus;
        Game.DisplayedAttackBonus += Game.AbilityScores[Ability.Strength].StrAttackBonus;
        int hold = Game.AbilityScores[Ability.Strength].StrMaxWeaponWeight;
        foreach (BaseInventorySlot rangedWeaponInventorySlot in Game.SingletonRepository.Get<BaseInventorySlot>().Where(_inventorySlot => _inventorySlot.IsRangedWeapon))
        {
            foreach (int index in rangedWeaponInventorySlot.InventorySlots)
            {
                Game.HasHeavyBow = false;
                Item? oPtr = Game.GetInventoryItem(index);
                if (oPtr != null)
                {
                    if (hold < oPtr.Weight / 10)
                    {
                        Game.AttackBonus += 2 * (hold - (oPtr.Weight / 10));
                        Game.DisplayedAttackBonus += 2 * (hold - (oPtr.Weight / 10));
                        Game.HasHeavyBow = true;
                    }
                    if (!Game.HasHeavyBow)
                    {
                        // Since this came from the ranged weapon, we know it is a missile weapon type/bow.
                        BowWeaponItemFactory missileWeaponItemCategory = (BowWeaponItemFactory)oPtr.Factory;
                        Game.AmmunitionItemCategory = missileWeaponItemCategory.AmmunitionItemCategory;
                        if (Game.BaseCharacterClass.ID == CharacterClass.Ranger && Game.AmmunitionItemCategory == ItemTypeEnum.Arrow)
                        {
                            if (Game.ExperienceLevel.IntValue >= 20)
                            {
                                Game.MissileAttacksPerRound++;
                            }
                            if (Game.ExperienceLevel.IntValue >= 40)
                            {
                                Game.MissileAttacksPerRound++;
                            }
                        }
                        if (Game.BaseCharacterClass.ID == CharacterClass.Warrior && Game.AmmunitionItemCategory <= ItemTypeEnum.Bolt &&
                            Game.AmmunitionItemCategory >= ItemTypeEnum.Shot)
                        {
                            if (Game.ExperienceLevel.IntValue >= 25)
                            {
                                Game.MissileAttacksPerRound++;
                            }
                            if (Game.ExperienceLevel.IntValue >= 50)
                            {
                                Game.MissileAttacksPerRound++;
                            }
                        }
                        Game.MissileAttacksPerRound += extraShots;
                        if (Game.MissileAttacksPerRound < 1)
                        {
                            Game.MissileAttacksPerRound = 1;
                        }
                    }
                }
            }
        }

        foreach (BaseInventorySlot meleeWeaponInventorySlot in Game.SingletonRepository.Get<BaseInventorySlot>().Where(_inventorySlot => _inventorySlot.IsMeleeWeapon))
        {
            foreach (int index in meleeWeaponInventorySlot.InventorySlots)
            {
                Game.HasHeavyWeapon = false;
                Item? oPtr = Game.GetInventoryItem(index);
                if (oPtr != null && hold < oPtr.Weight / 10)
                {
                    Game.AttackBonus += 2 * (hold - (oPtr.Weight / 10));
                    Game.DisplayedAttackBonus += 2 * (hold - (oPtr.Weight / 10));
                    Game.HasHeavyWeapon = true;
                }
                if (oPtr != null && !Game.HasHeavyWeapon)
                {
                    int num = Game.BaseCharacterClass.MaximumMeleeAttacksPerRound(Game.ExperienceLevel.IntValue);
                    int wgt = Game.BaseCharacterClass.MaximumWeight;
                    int mul = Game.BaseCharacterClass.AttackSpeedMultiplier;
                    int div = oPtr.Weight < wgt ? wgt : oPtr.Weight;
                    int strIndex = Game.AbilityScores[Ability.Strength].StrAttackSpeedComponent * mul / div;
                    if (strIndex > 11)
                    {
                        strIndex = 11;
                    }
                    int dexIndex = Game.AbilityScores[Ability.Dexterity].DexAttackSpeedComponent;
                    if (dexIndex > 11)
                    {
                        dexIndex = 11;
                    }
                    Game.MeleeAttacksPerRound = _blowsTable[strIndex][dexIndex];
                    if (Game.MeleeAttacksPerRound > num)
                    {
                        Game.MeleeAttacksPerRound = num;
                    }
                    Game.MeleeAttacksPerRound += extraBlows;
                    if (Game.BaseCharacterClass.ID == CharacterClass.Warrior)
                    {
                        Game.MeleeAttacksPerRound += Game.ExperienceLevel.IntValue / 15;
                    }
                    if (Game.MeleeAttacksPerRound < 1)
                    {
                        Game.MeleeAttacksPerRound = 1;
                    }
                    Game.SkillDigging += oPtr.Weight / 10;
                }
                else if ((Game.BaseCharacterClass.ID == CharacterClass.Monk || Game.BaseCharacterClass.ID == CharacterClass.Mystic) && Game.MartialArtistEmptyHands())
                {
                    Game.MeleeAttacksPerRound = 0;
                    if (Game.ExperienceLevel.IntValue > 9)
                    {
                        Game.MeleeAttacksPerRound++;
                    }
                    if (Game.ExperienceLevel.IntValue > 19)
                    {
                        Game.MeleeAttacksPerRound++;
                    }
                    if (Game.ExperienceLevel.IntValue > 29)
                    {
                        Game.MeleeAttacksPerRound++;
                    }
                    if (Game.ExperienceLevel.IntValue > 34)
                    {
                        Game.MeleeAttacksPerRound++;
                    }
                    if (Game.ExperienceLevel.IntValue > 39)
                    {
                        Game.MeleeAttacksPerRound++;
                    }
                    if (Game.ExperienceLevel.IntValue > 44)
                    {
                        Game.MeleeAttacksPerRound++;
                    }
                    if (Game.ExperienceLevel.IntValue > 49)
                    {
                        Game.MeleeAttacksPerRound++;
                    }
                    if (Game.MartialArtistHeavyArmor())
                    {
                        Game.MeleeAttacksPerRound /= 2;
                    }
                    Game.MeleeAttacksPerRound += 1 + extraBlows;
                    if (!Game.MartialArtistHeavyArmor())
                    {
                        Game.AttackBonus += Game.ExperienceLevel.IntValue / 3;
                        Game.DamageBonus += Game.ExperienceLevel.IntValue / 3;
                        Game.DisplayedAttackBonus += Game.ExperienceLevel.IntValue / 3;
                        Game.DisplayedDamageBonus += Game.ExperienceLevel.IntValue / 3;
                    }
                }

                Game.HasUnpriestlyWeapon = false;
                MartialArtistArmorAux = false;
                if (Game.BaseCharacterClass.ID == CharacterClass.Warrior)
                {
                    Game.AttackBonus += Game.ExperienceLevel.IntValue / 5;
                    Game.DamageBonus += Game.ExperienceLevel.IntValue / 5;
                    Game.DisplayedAttackBonus += Game.ExperienceLevel.IntValue / 5;
                    Game.DisplayedDamageBonus += Game.ExperienceLevel.IntValue / 5;
                }
                if ((Game.BaseCharacterClass.ID == CharacterClass.Priest || Game.BaseCharacterClass.ID == CharacterClass.Druid) && !Game.HasBlessedBlade && oPtr != null && (oPtr.Category == ItemTypeEnum.Sword || oPtr.Category == ItemTypeEnum.Polearm))
                {
                    Game.AttackBonus -= 2;
                    Game.DamageBonus -= 2;
                    Game.DisplayedAttackBonus -= 2;
                    Game.DisplayedDamageBonus -= 2;
                    Game.HasUnpriestlyWeapon = true;
                }

                Game.BaseCharacterClass.UpdateBonusesForMeleeWeapon(oPtr);
                if (Game.MartialArtistHeavyArmor())
                {
                    MartialArtistArmorAux = true;
                }
            }
        }

        Game.SkillStealth++;
        Game.SkillDisarmTraps += Game.AbilityScores[Ability.Dexterity].DexDisarmBonus;
        Game.SkillDisarmTraps += Game.AbilityScores[Ability.Intelligence].IntDisarmBonus;
        Game.SkillUseDevice += Game.AbilityScores[Ability.Intelligence].IntUseDeviceBonus;
        Game.SkillSavingThrow += Game.AbilityScores[Ability.Wisdom].WisSavingThrowBonus;
        Game.SkillDigging += Game.AbilityScores[Ability.Strength].StrDiggingBonus;
        Game.SkillDisarmTraps += (Game.BaseCharacterClass.DisarmBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillUseDevice += (Game.BaseCharacterClass.DeviceBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillSavingThrow += (Game.BaseCharacterClass.SaveBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillStealth += (Game.BaseCharacterClass.StealthBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillSearching += (Game.BaseCharacterClass.SearchBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillSearchFrequency += (Game.BaseCharacterClass.SearchFrequencyPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillMelee += (Game.BaseCharacterClass.MeleeAttackBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillRanged += (Game.BaseCharacterClass.RangedAttackBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillThrowing += (Game.BaseCharacterClass.RangedAttackBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        if (Game.SkillStealth > 30)
        {
            Game.SkillStealth = 30;
        }
        if (Game.SkillStealth < 0)
        {
            Game.SkillStealth = 0;
        }
        if (Game.SkillDigging < 1)
        {
            Game.SkillDigging = 1;
        }
        if (Game.HasAntiMagic && Game.SkillSavingThrow < 95)
        {
            Game.SkillSavingThrow = 95;
        }
        if (Game.CharacterXtra)
        {
            return;
        }
        if (OldHeavyBow != Game.HasHeavyBow) // TODO: This should be moved to the wield action
        {
            if (Game.HasHeavyBow)
            {
                Game.MsgPrint("You have trouble wielding such a heavy bow.");
            }
            else if (Game.SingletonRepository.Get<BaseInventorySlot>(nameof(RangedWeaponInventorySlot)).Count > 0)
            {
                Game.MsgPrint("You have no trouble wielding your bow.");
            }
            else
            {
                Game.MsgPrint("You feel relieved to put down your heavy bow.");
            }
            OldHeavyBow = Game.HasHeavyBow;
        }
        if (OldHeavyWeapon != Game.HasHeavyWeapon) // TODO: This should be moved to the wield action
        {
            if (Game.HasHeavyWeapon)
            {
                Game.MsgPrint("You have trouble wielding such a heavy weapon.");
            }
            else if (Game.SingletonRepository.Get<BaseInventorySlot>(nameof(MeleeWeaponInventorySlot)).Count > 0)
            {
                Game.MsgPrint("You have no trouble wielding your weapon.");
            }
            else
            {
                Game.MsgPrint("You feel relieved to put down your heavy weapon.");
            }
            OldHeavyWeapon = Game.HasHeavyWeapon;
        }
        if (OldUnpriestlyWeapon != Game.HasUnpriestlyWeapon) // TODO: This should be moved to the wield action
        {
            if (Game.HasUnpriestlyWeapon)
            {
                Game.MsgPrint(Game.BaseCharacterClass.ID == CharacterClass.Cultist
                    ? "Your weapon restricts the flow of chaos through you."
                    : "You do not feel comfortable with your weapon.");
            }
            else if (Game.GetInventoryItem(InventorySlot.MeleeWeapon) != null)
            {
                Game.MsgPrint("You feel comfortable with your weapon.");
            }
            else
            {
                Game.MsgPrint(Game.BaseCharacterClass.ID == CharacterClass.Cultist
                    ? "Chaos flows freely through you again."
                    : "You feel more comfortable after removing your weapon.");
            }
            OldUnpriestlyWeapon = Game.HasUnpriestlyWeapon;
        }
        if ((Game.BaseCharacterClass.ID == CharacterClass.Monk || Game.BaseCharacterClass.ID == CharacterClass.Mystic) && MartialArtistArmorAux != MartialArtistNotifyAux) // TODO: This should be moved to the wield action
        {
            Game.MsgPrint(Game.MartialArtistHeavyArmor()
                ? "The weight of your armor disrupts your balance."
                : "You regain your balance.");
            MartialArtistNotifyAux = MartialArtistArmorAux;
        }
    }

}
