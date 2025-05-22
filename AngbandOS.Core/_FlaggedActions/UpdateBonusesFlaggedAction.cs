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
        Game.HasBlessedBlade = false; // TODO: This is local
        Game.HasExtraMight = false;
        Game.HasQuakeWeapon = false;
        Game.HasSeeInvisibility = false;
        Game.HasFreeAction = false;
        Game.HasSlowDigestion = false;
        Game.HasRegeneration = false;
        Game.HasFeatherFall = false;
        Game.HasHoldLife = false;
        Game.HasTelepathy = false;
        Game.GlowInTheDarkRadius = 0;
        Game.HasSustainStrength = false;
        Game.HasSustainIntelligence = false;
        Game.HasSustainWisdom = false;
        Game.HasSustainConstitution = false;
        Game.HasSustainDexterity = false;
        Game.HasSustainCharisma = false;
        Game.AcidResistanceTimer.HasResistance = false;
        Game.LightningResistanceTimer.HasResistance = false;
        Game.FireResistanceTimer.HasResistance = false;
        Game.ColdResistanceTimer.HasResistance = false;
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
        Game.BlindnessTimer.HasResistance = false;
        Game.HasNetherResistance = false;
        Game.HasFearResistance = false;
        Game.HasElementalVulnerability = false;
        Game.HasReflection = false;
        Game.HasFireSheath = false;
        Game.HasElectricitySheath = false;
        Game.HasAntiMagic = false;
        Game.HasAntiTeleport = false;
        Game.HasAntiTheft = false;
        Game.AcidResistanceTimer.HasImmunity = false;
        Game.LightningResistanceTimer.HasImmunity = false;
        Game.FireResistanceTimer.HasImmunity = false;
        Game.ColdResistanceTimer.HasImmunity = false;
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
        Game.BaseCharacterClass.CalcBonuses();
        Game.Race.CalcBonuses();
        Game.Speed.IntValue = 110;
        Game.MeleeAttacksPerRound = 1;
        Game.MissileAttacksPerRound = 1;
        for (int i = 0; i < 6; i++)
        {
            Game.AbilityScores[i].Bonus += Game.Race.AbilityBonus[i] + Game.BaseCharacterClass.AbilityBonus[i];
        }
        Game.AbilityScores[AbilityEnum.Strength].Bonus += Game.StrengthBonus;
        Game.AbilityScores[AbilityEnum.Intelligence].Bonus += Game.IntelligenceBonus;
        Game.AbilityScores[AbilityEnum.Wisdom].Bonus += Game.WisdomBonus;
        Game.AbilityScores[AbilityEnum.Dexterity].Bonus += Game.DexterityBonus;
        Game.AbilityScores[AbilityEnum.Constitution].Bonus += Game.ConstitutionBonus;
        Game.AbilityScores[AbilityEnum.Charisma].Bonus += Game.CharismaBonus;
        Game.Speed.IntValue += Game.SpeedBonus;
        Game.HasRegeneration |= Game.Regen;
        Game.SkillSearchFrequency += Game.SearchBonus;
        Game.SkillSearching += Game.SearchBonus;
        Game.InfravisionRange += Game.InfravisionBonus;
        Game.HasElectricitySheath |= Game.ElecHit;
        Game.HasFireSheath |= Game.FireHit;
        if (Game.GlowInTheDarkRadius == 0 && Game.FireHit)
        {
            Game.GlowInTheDarkRadius = 1;
        }
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
            Game.AbilityScores[AbilityEnum.Charisma].Bonus = 0;
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
        foreach (WieldSlot inventorySlot in Game.SingletonRepository.Get<WieldSlot>().Where(_inventorySlot => _inventorySlot.IsEquipment))
        {
            foreach (int i in inventorySlot.InventorySlots)
            {
                Item? oPtr = Game.GetInventoryItem(i);
                if (oPtr != null)
                {
                    RoItemPropertySet mergedCharacteristics = oPtr.GetEffectiveItemProperties();
                    if (mergedCharacteristics.Str)
                    {
                        Game.AbilityScores[AbilityEnum.Strength].Bonus += mergedCharacteristics.BonusStrength;
                    }
                    if (mergedCharacteristics.Int)
                    {
                        Game.AbilityScores[AbilityEnum.Intelligence].Bonus += mergedCharacteristics.BonusIntelligence;
                    }
                    if (mergedCharacteristics.Wis)
                    {
                        Game.AbilityScores[AbilityEnum.Wisdom].Bonus += mergedCharacteristics.BonusWisdom;
                    }
                    if (mergedCharacteristics.Dex)
                    {
                        Game.AbilityScores[AbilityEnum.Dexterity].Bonus += mergedCharacteristics.BonusDexterity;
                    }
                    if (mergedCharacteristics.Con)
                    {
                        Game.AbilityScores[AbilityEnum.Constitution].Bonus += mergedCharacteristics.BonusConstitution;
                    }
                    if (mergedCharacteristics.Cha)
                    {
                        Game.AbilityScores[AbilityEnum.Charisma].Bonus += mergedCharacteristics.BonusCharisma;
                    }
                    if (mergedCharacteristics.Stealth)
                    {
                        Game.SkillStealth += mergedCharacteristics.BonusStealth;
                    }
                    if (mergedCharacteristics.Search)
                    {
                        Game.SkillSearching += mergedCharacteristics.BonusSearch * 5;
                    }
                    if (mergedCharacteristics.Search)
                    {
                        Game.SkillSearchFrequency += mergedCharacteristics.BonusSearch * 5;
                    }
                    if (mergedCharacteristics.Infra)
                    {
                        Game.InfravisionRange += mergedCharacteristics.BonusInfravision;
                    }
                    if (mergedCharacteristics.Tunnel)
                    {
                        Game.SkillDigging += mergedCharacteristics.BonusTunnel * 20;
                    }
                    if (mergedCharacteristics.Speed)
                    {
                        Game.Speed.IntValue += mergedCharacteristics.BonusSpeed;
                    }
                    if (mergedCharacteristics.Blows)
                    {
                        extraBlows += mergedCharacteristics.BonusAttacks;
                    }
                    if (mergedCharacteristics.Impact)
                    {
                        Game.HasQuakeWeapon = true;
                    }
                    if (mergedCharacteristics.AntiTheft)
                    {
                        Game.HasAntiTheft = true;
                    }
                    if (mergedCharacteristics.XtraShots)
                    {
                        extraShots++;
                    }
                    if (mergedCharacteristics.Aggravate)
                    {
                        Game.HasAggravation = true;
                    }
                    if (mergedCharacteristics.Teleport)
                    {
                        Game.HasRandomTeleport = true;
                    }
                    if (mergedCharacteristics.DrainExp)
                    {
                        Game.HasExperienceDrain = true;
                    }
                    if (mergedCharacteristics.Blessed)
                    {
                        Game.HasBlessedBlade = true;
                    }
                    if (mergedCharacteristics.XtraMight)
                    {
                        Game.HasExtraMight = true;
                    }
                    if (mergedCharacteristics.SlowDigest)
                    {
                        Game.HasSlowDigestion = true;
                    }
                    if (mergedCharacteristics.Regen)
                    {
                        Game.HasRegeneration = true;
                    }
                    if (mergedCharacteristics.Telepathy)
                    {
                        Game.HasTelepathy = true;
                    }
                    if (mergedCharacteristics.SeeInvis)
                    {
                        Game.HasSeeInvisibility = true;
                    }
                    if (mergedCharacteristics.Feather)
                    {
                        Game.HasFeatherFall = true;
                    }
                    if (mergedCharacteristics.FreeAct)
                    {
                        Game.HasFreeAction = true;
                    }
                    if (mergedCharacteristics.HoldLife)
                    {
                        Game.HasHoldLife = true;
                    }
                    if (mergedCharacteristics.Wraith)
                    {
                        Game.EtherealnessTimer.SetValue(Math.Max(Game.EtherealnessTimer.Value, 20));
                    }
                    if (mergedCharacteristics.ImFire)
                    {
                        Game.FireResistanceTimer.HasImmunity = true;
                    }
                    if (mergedCharacteristics.ImAcid)
                    {
                        Game.AcidResistanceTimer.HasImmunity = true;
                    }
                    if (mergedCharacteristics.ImCold)
                    {
                        Game.ColdResistanceTimer.HasImmunity = true;
                    }
                    if (mergedCharacteristics.ImElec)
                    {
                        Game.LightningResistanceTimer.HasImmunity = true;
                    }
                    if (mergedCharacteristics.ResAcid)
                    {
                        Game.AcidResistanceTimer.HasResistance = true;
                    }
                    if (mergedCharacteristics.ResElec)
                    {
                        Game.LightningResistanceTimer.HasResistance = true;
                    }
                    if (mergedCharacteristics.ResFire)
                    {
                        Game.FireResistanceTimer.HasResistance = true;
                    }
                    if (mergedCharacteristics.ResCold)
                    {
                        Game.ColdResistanceTimer.HasResistance = true;
                    }
                    if (mergedCharacteristics.ResPois)
                    {
                        Game.HasPoisonResistance = true;
                    }
                    if (mergedCharacteristics.ResFear)
                    {
                        Game.HasFearResistance = true;
                    }
                    if (mergedCharacteristics.ResConf)
                    {
                        Game.HasConfusionResistance = true;
                    }
                    if (mergedCharacteristics.ResSound)
                    {
                        Game.HasSoundResistance = true;
                    }
                    if (mergedCharacteristics.ResLight)
                    {
                        Game.HasLightResistance = true;
                    }
                    if (mergedCharacteristics.ResDark)
                    {
                        Game.HasDarkResistance = true;
                    }
                    if (mergedCharacteristics.ResChaos)
                    {
                        Game.HasChaosResistance = true;
                    }
                    if (mergedCharacteristics.ResDisen)
                    {
                        Game.HasDisenchantResistance = true;
                    }
                    if (mergedCharacteristics.ResShards)
                    {
                        Game.HasShardResistance = true;
                    }
                    if (mergedCharacteristics.ResNexus)
                    {
                        Game.HasNexusResistance = true;
                    }
                    if (mergedCharacteristics.ResBlind)
                    {
                        Game.BlindnessTimer.HasResistance = true;
                    }
                    if (mergedCharacteristics.ResNether)
                    {
                        Game.HasNetherResistance = true;
                    }
                    if (mergedCharacteristics.Reflect)
                    {
                        Game.HasReflection = true;
                    }
                    if (mergedCharacteristics.ShFire)
                    {
                        Game.HasFireSheath = true;
                    }
                    if (mergedCharacteristics.ShElec)
                    {
                        Game.HasElectricitySheath = true;
                    }
                    if (mergedCharacteristics.NoMagic)
                    {
                        Game.HasAntiMagic = true;
                    }
                    if (mergedCharacteristics.NoTele)
                    {
                        Game.HasAntiTeleport = true;
                    }
                    if (mergedCharacteristics.SustStr)
                    {
                        Game.HasSustainStrength = true;
                    }
                    if (mergedCharacteristics.SustInt)
                    {
                        Game.HasSustainIntelligence = true;
                    }
                    if (mergedCharacteristics.SustWis)
                    {
                        Game.HasSustainWisdom = true;
                    }
                    if (mergedCharacteristics.SustDex)
                    {
                        Game.HasSustainDexterity = true;
                    }
                    if (mergedCharacteristics.SustCon)
                    {
                        Game.HasSustainConstitution = true;
                    }
                    if (mergedCharacteristics.SustCha)
                    {
                        Game.HasSustainCharisma = true;
                    }
                    Game.BaseArmorClass += oPtr.ArmorClass;
                    Game.DisplayedBaseArmorClass.IntValue += oPtr.ArmorClass;
                    Game.ArmorClassBonus += mergedCharacteristics.BonusArmorClass;
                    if (oPtr.IsKnown())
                    {
                        Game.DisplayedArmorClassBonus.IntValue += mergedCharacteristics.BonusArmorClass;
                    }
                    if (inventorySlot.IsWeapon)
                    {
                        continue;
                    }
                    Game.AttackBonus += mergedCharacteristics.BonusHit;
                    Game.DamageBonus += mergedCharacteristics.BonusDamage;
                    if (oPtr.IsKnown())
                    {
                        Game.DisplayedAttackBonus += mergedCharacteristics.BonusHit;
                    }
                    if (oPtr.IsKnown())
                    {
                        Game.DisplayedDamageBonus += mergedCharacteristics.BonusDamage;
                    }
                }
            }
        }
        if ((Game.BaseCharacterClass.ID == CharacterClassEnum.Monk || Game.BaseCharacterClass.ID == CharacterClassEnum.Mystic) && !Game.MartialArtistHeavyArmor())
        {
            foreach (WieldSlot inventorySlot in Game.SingletonRepository.Get<WieldSlot>())
            {
                if (inventorySlot.Count == 0)
                {
                    int bareArmorBonus = inventorySlot.BareArmorClassBonus;
                    Game.ArmorClassBonus += bareArmorBonus;
                    Game.DisplayedArmorClassBonus.IntValue += bareArmorBonus;
                }
            }
        }
        if (Game.HasFireSheath)
        {
            Game.GlowInTheDarkRadius = 1;
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
            if (i == AbilityEnum.Charisma && Game.CharismaOverride)
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
                if (i == AbilityEnum.Constitution)
                {
                    Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateHealthFlaggedAction)).Set();
                }
                else if (i == AbilityEnum.Intelligence)
                {
                    if (Game.BaseCharacterClass.SpellStat == AbilityEnum.Intelligence)
                    {
                        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
                        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateSpellsFlaggedAction)).Set();
                    }
                }
                else if (i == AbilityEnum.Wisdom)
                {
                    if (Game.BaseCharacterClass.SpellStat == AbilityEnum.Wisdom)
                    {
                        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
                        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateSpellsFlaggedAction)).Set();
                    }
                }
                else if (i == AbilityEnum.Charisma)
                {
                    if (Game.BaseCharacterClass.SpellStat == AbilityEnum.Charisma)
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
        if ((Game.BaseCharacterClass.ID == CharacterClassEnum.Monk || Game.BaseCharacterClass.ID == CharacterClassEnum.Mystic) && !Game.MartialArtistHeavyArmor())
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
        int ii = Game.AbilityScores[AbilityEnum.Strength].StrCarryingCapacity * 100;

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
        Game.ArmorClassBonus += Game.AbilityScores[AbilityEnum.Dexterity].DexArmorClassBonus;
        Game.DamageBonus += Game.AbilityScores[AbilityEnum.Strength].StrDamageBonus;
        Game.AttackBonus += Game.AbilityScores[AbilityEnum.Dexterity].DexAttackBonus;
        Game.AttackBonus += Game.AbilityScores[AbilityEnum.Strength].StrAttackBonus;
        Game.DisplayedArmorClassBonus.IntValue += Game.AbilityScores[AbilityEnum.Dexterity].DexArmorClassBonus;
        Game.DisplayedDamageBonus += Game.AbilityScores[AbilityEnum.Strength].StrDamageBonus;
        Game.DisplayedAttackBonus += Game.AbilityScores[AbilityEnum.Dexterity].DexAttackBonus;
        Game.DisplayedAttackBonus += Game.AbilityScores[AbilityEnum.Strength].StrAttackBonus;
        int hold = Game.AbilityScores[AbilityEnum.Strength].StrMaxWeaponWeight;
        foreach (WieldSlot rangedWeaponInventorySlot in Game.SingletonRepository.Get<WieldSlot>().Where(_inventorySlot => _inventorySlot.IsRangedWeapon))
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
                        ItemFactory[]? ammunitionItemFactories = oPtr.AmmunitionItemFactories;

                        // Rangers get a bonus for using ranged weapons that use arrows for ammunition.
                        if (Game.BaseCharacterClass.ID == CharacterClassEnum.Ranger && oPtr.ItemClass == Game.SingletonRepository.Get<ItemClass>(nameof(BowItemClass)))
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
                        if (Game.BaseCharacterClass.ID == CharacterClassEnum.Warrior)
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

        foreach (WieldSlot meleeWeaponInventorySlot in Game.SingletonRepository.Get<WieldSlot>().Where(_inventorySlot => _inventorySlot.IsMeleeWeapon))
        {
            foreach (int index in meleeWeaponInventorySlot.InventorySlots)
            {
                Game.HasHeavyWeapon = false; // TODO: Is this local only
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
                    int strIndex = Game.AbilityScores[AbilityEnum.Strength].StrAttackSpeedComponent * mul / div;
                    if (strIndex > 11)
                    {
                        strIndex = 11;
                    }
                    int dexIndex = Game.AbilityScores[AbilityEnum.Dexterity].DexAttackSpeedComponent;
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
                    if (Game.BaseCharacterClass.ID == CharacterClassEnum.Warrior)
                    {
                        Game.MeleeAttacksPerRound += Game.ExperienceLevel.IntValue / 15;
                    }
                    if (Game.MeleeAttacksPerRound < 1)
                    {
                        Game.MeleeAttacksPerRound = 1;
                    }
                    Game.SkillDigging += oPtr.Weight / 10;
                }
                else if (Game.IsMartialArtistAndNotWieldingAMeleeWeapon())
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
                if (Game.BaseCharacterClass.ID == CharacterClassEnum.Warrior)
                {
                    Game.AttackBonus += Game.ExperienceLevel.IntValue / 5;
                    Game.DamageBonus += Game.ExperienceLevel.IntValue / 5;
                    Game.DisplayedAttackBonus += Game.ExperienceLevel.IntValue / 5;
                    Game.DisplayedDamageBonus += Game.ExperienceLevel.IntValue / 5;
                }
                
                if ((Game.BaseCharacterClass.ID == CharacterClassEnum.Priest || Game.BaseCharacterClass.ID == CharacterClassEnum.Druid) && !Game.HasBlessedBlade && oPtr != null && (oPtr.ItemClass==Game.SingletonRepository.Get<ItemClass>(nameof(SwordsItemClass)) || oPtr.ItemClass == Game.SingletonRepository.Get<ItemClass>(nameof(PolearmsItemClass))))
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
        Game.SkillDisarmTraps += Game.AbilityScores[AbilityEnum.Dexterity].DexDisarmBonus;
        Game.SkillDisarmTraps += Game.AbilityScores[AbilityEnum.Intelligence].IntDisarmBonus;
        Game.SkillUseDevice += Game.AbilityScores[AbilityEnum.Intelligence].IntUseDeviceBonus;
        Game.SkillSavingThrow += Game.AbilityScores[AbilityEnum.Wisdom].WisSavingThrowBonus;
        Game.SkillDigging += Game.AbilityScores[AbilityEnum.Strength].StrDiggingBonus;
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
            else if (Game.SingletonRepository.Get<WieldSlot>(nameof(RangedWeaponWieldSlot)).Count > 0)
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
            else if (Game.SingletonRepository.Get<WieldSlot>(nameof(MeleeWeaponWieldSlot)).Count > 0)
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
                Game.MsgPrint(Game.BaseCharacterClass.ID == CharacterClassEnum.Cultist
                    ? "Your weapon restricts the flow of chaos through you."
                    : "You do not feel comfortable with your weapon.");
            }
            else if (Game.GetInventoryItem(InventorySlotEnum.MeleeWeapon) != null)
            {
                Game.MsgPrint("You feel comfortable with your weapon.");
            }
            else
            {
                Game.MsgPrint(Game.BaseCharacterClass.ID == CharacterClassEnum.Cultist
                    ? "Chaos flows freely through you again."
                    : "You feel more comfortable after removing your weapon.");
            }
            OldUnpriestlyWeapon = Game.HasUnpriestlyWeapon;
        }
        if ((Game.BaseCharacterClass.ID == CharacterClassEnum.Monk || Game.BaseCharacterClass.ID == CharacterClassEnum.Mystic) && MartialArtistArmorAux != MartialArtistNotifyAux) // TODO: This should be moved to the wield action
        {
            Game.MsgPrint(Game.MartialArtistHeavyArmor()
                ? "The weight of your armor disrupts your balance."
                : "You regain your balance.");
            MartialArtistNotifyAux = MartialArtistArmorAux;
        }
    }

}
