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
    private bool MartialArtistArmorAux;
    private bool MartialArtistNotifyAux;

    private UpdateBonusesFlaggedAction(Game game) : base(game) { }
    private EffectiveAttributeSet BuildEffectiveAttributeSetForPlayer()
    {
        EffectiveAttributeSet effectiveAttributeSet = new EffectiveAttributeSet(Game);

        // Apply the race enhancements.
        effectiveAttributeSet.MergeAttributeSet(Game.Race.EffectiveAttributeSet);

        // Apply the character class enhancements.
        effectiveAttributeSet.MergeAttributeSet(Game.CharacterClass.EffectiveAttributeSet);

        // Apply all of the mutations that the player has.

        // Apply all of the items that the player is wielding.
        foreach (WieldSlot inventorySlot in Game.SingletonRepository.Get<WieldSlot>().Where(_inventorySlot => _inventorySlot.IsEquipment))
        {
            foreach (int i in inventorySlot.InventorySlots)
            {
                Item? oPtr = Game.GetInventoryItem(i);
                if (oPtr != null)
                {
                    effectiveAttributeSet.MergeAttributeSet(oPtr.EffectiveAttributeSet.ToReadOnly());
                }
            }
        }

        return effectiveAttributeSet;
    }

    protected override void Execute()
    {
        Game.EffectiveAttributeSet = BuildEffectiveAttributeSetForPlayer().ToReadOnly(); // TODO: This isn't being used yet.

        List<Bonuses> bonusesToMerge = new List<Bonuses>();
        int baseArmorClass = 0;
        int attackBonus = 0;
        int damageBonus = 0;
        int displayedAttackBonus = 0;
        int displayedDamageBonus = 0;
        bool hasUnpriestlyWeapon = false;
        bool hasHeavyBow = false;
        bool hasHeavyWeapon = false;

        int extraShots;
        int oldSpeed = Game.Speed.IntValue;
        bool oldTelepathy = Game.HasTelepathy;
        bool oldSeeInv = Game.HasSeeInvisibility;
        int extraBlows = extraShots = 0;
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            ability.Bonus = 0;
        }
        Game.DisplayedBaseArmorClass = 0;
        Game.KnownBonusArmorClass = 0;
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
        Game.GlowInTheDarkRadius = 0;
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
        Game.HasFireSheath = false;
        Game.HasElectricitySheath = false;
        Game.HasAntiMagic = false;
        Game.HasAntiTeleport = false;
        Game.HasAntiTheft = false;
        Game.HasAcidImmunity = false;
        Game.HasLightningImmunity = false;
        Game.HasFireImmunity = false;
        Game.HasColdImmunity = false;
        Game.InfravisionRange = Game.Race.Infravision; // done
        Game.ComputedDisarmTraps = Game.Race.EffectiveAttributeSet.Get<ReadOnlyAttributeValue<int>>(nameof(DisarmTrapsAttribute)).Value + Game.CharacterClass.EffectiveAttributeSet.Get<ReadOnlyAttributeValue<int>>(nameof(DisarmTrapsAttribute)).Value; // done
        Game.SkillUseDevice = Game.Race.UseDevice + Game.CharacterClass.UseDevice; // done
        Game.SkillSavingThrow = Game.Race.SavingThrow + Game.CharacterClass.SavingThrow; // done
        Game.SkillStealth = Game.Race.Stealth + Game.CharacterClass.Stealth; // done .. need to copy
        Game.SkillSearching = Game.Race.Search + Game.CharacterClass.Search; // done .. need to copy
        Game.SkillSearchFrequency = Game.Race.BaseSearchFrequency + Game.CharacterClass.BaseSearchFrequency; // added to attributes
        Game.SkillMelee = Game.Race.MeleeToHit + Game.CharacterClass.MeleeToHit; // this appears to be tohit
        Game.SkillRanged = Game.Race.RangedToHit + Game.CharacterClass.RangedToHit; // added rangedtohit
        Game.SkillThrowing = Game.Race.RangedToHit + Game.CharacterClass.RangedToHit; // added throwingtohit
        Game.SkillDigging = 0;
        Game.CharacterClass.CalcBonuses();
        Game.Race.CalcBonuses();
        Game.Speed.IntValue = 110;
        Game.MeleeAttacksPerRound = 1;
        Game.MissileAttacksPerRound = 1;
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            RaceAbility raceAbility = Game.SingletonRepository.Get<RaceAbility>(RaceAbility.GetCompositeKey(Game.Race, ability));
            string compositeKey = CharacterClassAbility.GetCompositeKey(Game.CharacterClass, ability);
            CharacterClassAbility characterClassAbility = Game.SingletonRepository.Get<CharacterClassAbility>(compositeKey);
            ability.Bonus += raceAbility.Bonus + characterClassAbility.Bonus;
        }
        Game.StrengthAbility.Bonus += Game.StrengthBonus;
        Game.IntelligenceAbility.Bonus += Game.IntelligenceBonus;
        Game.WisdomAbility.Bonus += Game.WisdomBonus;
        Game.DexterityAbility.Bonus += Game.DexterityBonus;
        Game.ConstitutionAbility.Bonus += Game.ConstitutionBonus;
        Game.CharismaAbility.Bonus += Game.CharismaBonus;
        Game.Speed.IntValue += Game.SpeedBonus;
        Game.HasRegeneration |= Game.Regen;
        Game.SkillSearchFrequency += Game.SearchBonus;
        Game.SkillSearching += Game.SearchBonus;
        Game.InfravisionRange += Game.MutationInfravisionBonus;
        Game.HasElectricitySheath |= Game.ElecHit;
        Game.HasFireSheath |= Game.MutationFireHit;
        if (Game.GlowInTheDarkRadius == 0 && Game.HasFireSheath)
        {
            Game.GlowInTheDarkRadius = 1;
        }
        Game.ArmorClassBonus += Game.GenomeArmorClassBonus;
        Game.KnownBonusArmorClass += Game.GenomeArmorClassBonus;
        Game.HasFeatherFall |= Game.FeatherFall;
        Game.HasFearResistance |= Game.ResFear;
        Game.HasTimeResistance |= Game.ResTime;
        Game.HasTelepathy |= Game.Esp;
        Game.SkillStealth += Game.StealthBonus;
        Game.HasFreeAction |= Game.MutationFreeAction;
        Game.HasElementalVulnerability |= Game.Vulnerable;
        if (Game.MagicResistance)
        {
            Game.SkillSavingThrow += 15 + (Game.ExperienceLevel.IntValue / 5);
        }
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            ability.OverrideUpdateBonuses();
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
                    Game.StrengthAbility.Bonus += oPtr.EffectiveAttributeSet.Strength;
                    Game.IntelligenceAbility.Bonus += oPtr.EffectiveAttributeSet.Intelligence;
                    Game.WisdomAbility.Bonus += oPtr.EffectiveAttributeSet.Wisdom;
                    Game.DexterityAbility.Bonus += oPtr.EffectiveAttributeSet.Dexterity;
                    Game.ConstitutionAbility.Bonus += oPtr.EffectiveAttributeSet.Constitution;
                    Game.CharismaAbility.Bonus += oPtr.EffectiveAttributeSet.Charisma;
                    Game.SkillStealth += oPtr.EffectiveAttributeSet.Stealth;
                    Game.SkillSearching += oPtr.EffectiveAttributeSet.Search * 5;
                    Game.SkillSearchFrequency += oPtr.EffectiveAttributeSet.Search * 5;
                    Game.InfravisionRange += oPtr.EffectiveAttributeSet.Infravision;
                    Game.SkillDigging += oPtr.EffectiveAttributeSet.Tunnel * 20;
                    Game.Speed.IntValue += oPtr.EffectiveAttributeSet.Speed;
                    extraBlows += oPtr.EffectiveAttributeSet.Attacks;
                    if (oPtr.EffectiveAttributeSet.Impact)
                    {
                        Game.HasQuakeWeapon = true;
                    }
                    if (oPtr.EffectiveAttributeSet.AntiTheft)
                    {
                        Game.HasAntiTheft = true;
                    }
                    if (oPtr.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(XtraShotsAttribute)).Get())
                    {
                        extraShots++;
                    }
                    if (oPtr.EffectiveAttributeSet.Aggravate)
                    {
                        Game.HasAggravation = true;
                    }
                    if (oPtr.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(TeleportAttribute)).Get())
                    {
                        Game.HasRandomTeleport = true;
                    }
                    if (oPtr.EffectiveAttributeSet.DrainExp)
                    {
                        Game.HasExperienceDrain = true;
                    }
                    if (oPtr.EffectiveAttributeSet.Blessed)
                    {
                        Game.HasBlessedBlade = true;
                    }
                    if (oPtr.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(XtraMightAttribute)).Get())
                    {
                        Game.HasExtraMight = true;
                    }
                    if (oPtr.EffectiveAttributeSet.SlowDigest)
                    {
                        Game.HasSlowDigestion = true;
                    }
                    if (oPtr.EffectiveAttributeSet.Regen)
                    {
                        Game.HasRegeneration = true;
                    }
                    if (oPtr.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(TelepathyAttribute)).Get())
                    {
                        Game.HasTelepathy = true;
                    }
                    if (oPtr.EffectiveAttributeSet.SeeInvis)
                    {
                        Game.HasSeeInvisibility = true;
                    }
                    if (oPtr.EffectiveAttributeSet.Feather)
                    {
                        Game.HasFeatherFall = true;
                    }
                    if (oPtr.EffectiveAttributeSet.FreeAct)
                    {
                        Game.HasFreeAction = true;
                    }
                    if (oPtr.EffectiveAttributeSet.HoldLife)
                    {
                        Game.HasHoldLife = true;
                    }
                    if (oPtr.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(WraithAttribute)).Get())
                    {
                        Game.EtherealnessTimer.SetValue(Math.Max(Game.EtherealnessTimer.Value, 20));
                    }
                    if (oPtr.EffectiveAttributeSet.ImFire)
                    {
                        Game.HasFireImmunity = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ImAcid)
                    {
                        Game.HasAcidImmunity = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ImCold)
                    {
                        Game.HasColdImmunity = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ImElec)
                    {
                        Game.HasLightningImmunity = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ResAcid)
                    {
                        Game.HasAcidResistance = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ResElec)
                    {
                        Game.HasLightningResistance = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ResFire)
                    {
                        Game.HasFireResistance = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ResCold)
                    {
                        Game.HasColdResistance = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ResPois)
                    {
                        Game.HasPoisonResistance = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ResFear)
                    {
                        Game.HasFearResistance = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ResConf)
                    {
                        Game.HasConfusionResistance = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ResSound)
                    {
                        Game.HasSoundResistance = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ResLight)
                    {
                        Game.HasLightResistance = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ResDark)
                    {
                        Game.HasDarkResistance = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ResChaos)
                    {
                        Game.HasChaosResistance = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ResDisen)
                    {
                        Game.HasDisenchantResistance = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ResShards)
                    {
                        Game.HasShardResistance = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ResNexus)
                    {
                        Game.HasNexusResistance = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ResBlind)
                    {
                        Game.HasBlindnessResistance = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ResNether)
                    {
                        Game.HasNetherResistance = true;
                    }
                    if (oPtr.EffectiveAttributeSet.Reflect)
                    {
                        Game.HasReflection = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ShFire)
                    {
                        Game.HasFireSheath = true;
                    }
                    if (oPtr.EffectiveAttributeSet.ShElec)
                    {
                        Game.HasElectricitySheath = true;
                    }
                    if (oPtr.EffectiveAttributeSet.NoMagic)
                    {
                        Game.HasAntiMagic = true;
                    }
                    if (oPtr.EffectiveAttributeSet.NoTele)
                    {
                        Game.HasAntiTeleport = true;
                    }
                    if (oPtr.EffectiveAttributeSet.SustStr)
                    {
                        Game.HasSustainStrength = true;
                    }
                    if (oPtr.EffectiveAttributeSet.SustInt)
                    {
                        Game.HasSustainIntelligence = true;
                    }
                    if (oPtr.EffectiveAttributeSet.SustWis)
                    {
                        Game.HasSustainWisdom = true;
                    }
                    if (oPtr.EffectiveAttributeSet.SustDex)
                    {
                        Game.HasSustainDexterity = true;
                    }
                    if (oPtr.EffectiveAttributeSet.SustCon)
                    {
                        Game.HasSustainConstitution = true;
                    }
                    if (oPtr.EffectiveAttributeSet.SustCha)
                    {
                        Game.HasSustainCharisma = true;
                    }
                    baseArmorClass += oPtr.EffectiveAttributeSet.BaseArmorClass;
                    Game.DisplayedBaseArmorClass += oPtr.EffectiveAttributeSet.BaseArmorClass;
                    Game.ArmorClassBonus += oPtr.EffectiveAttributeSet.BonusArmorClass;
                    if (oPtr.IsKnown())
                    {
                        Game.KnownBonusArmorClass += oPtr.EffectiveAttributeSet.BonusArmorClass;
                    }
                    if (inventorySlot.IsWeapon)
                    {
                        continue;
                    }
                    attackBonus += oPtr.EffectiveAttributeSet.MeleeToHit;
                    damageBonus += oPtr.EffectiveAttributeSet.ToDamage;
                    if (oPtr.IsKnown())
                    {
                        displayedAttackBonus += oPtr.EffectiveAttributeSet.MeleeToHit;
                    }
                    if (oPtr.IsKnown())
                    {
                        displayedDamageBonus += oPtr.EffectiveAttributeSet.ToDamage;
                    }
                }
            }
        }
        if (Game.CharacterClass.IsMartialArtist && !Game.MartialArtistHeavyArmor())
        {
            foreach (WieldSlot inventorySlot in Game.SingletonRepository.Get<WieldSlot>())
            {
                if (inventorySlot.Count == 0)
                {
                    int bareArmorBonus = inventorySlot.BareArmorClassBonus;
                    Game.ArmorClassBonus += bareArmorBonus;
                    Game.KnownBonusArmorClass += bareArmorBonus;
                }
            }
        }
        if (Game.SuppressRegen)
        {
            Game.HasRegeneration = false;
        }
        if (Game.HasFireSheath)
        {
            Game.GlowInTheDarkRadius = 1;
        }
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            int top = ability.ModifyStatValue(ability.InnateMax, ability.Bonus);
            if (ability.AdjustedMax != top)
            {
                ability.AdjustedMax = top;
                Game.SingletonRepository.Get<FlaggedAction>(nameof(RedrawStatsFlaggedAction)).Set();
            }
            int use = ability.ModifyStatValue(ability.Innate, ability.Bonus);
            use = ability.OverrideUse(use);
            if (ability.Adjusted != use)
            {
                ability.Adjusted = use;
                Game.SingletonRepository.Get<FlaggedAction>(nameof(RedrawStatsFlaggedAction)).Set();
            }
            int abilityTableIndex = 37; // The range for this value is 0-37.
            if (use <= 18) // TODO: This should be a setting
            {
                abilityTableIndex = use - 3; // TODO: This should be a setting
            }
            else if (use <= 18 + 219)
            {
                abilityTableIndex = 15 + ((use - 18) / 10);
            }
            if (ability.TableIndex != abilityTableIndex)
            {
                ability.TableIndex = abilityTableIndex;
                ability.FlagActions();
            }
        }
        if (Game.StunTimer.Value > 50)
        {
            attackBonus -= 20;
            displayedAttackBonus -= 20;
            damageBonus -= 20;
            displayedDamageBonus -= 20;
        }
        else if (Game.StunTimer.Value != 0)
        {
            attackBonus -= 5;
            displayedAttackBonus -= 5;
            damageBonus -= 5;
            displayedDamageBonus -= 5;
        }
        if (Game.InvulnerabilityTimer.Value != 0)
        {
            Game.ArmorClassBonus += 100;
            Game.KnownBonusArmorClass += 100;
        }
        if (Game.EtherealnessTimer.Value != 0)
        {
            Game.ArmorClassBonus += 100;
            Game.KnownBonusArmorClass += 100;
            Game.HasReflection = true;
        }
        if (Game.BlessingTimer.Value != 0)
        {
            Game.ArmorClassBonus += 5;
            Game.KnownBonusArmorClass += 5;
            attackBonus += 10;
            displayedAttackBonus += 10;
        }
        if (Game.StoneskinTimer.Value != 0)
        {
            Game.ArmorClassBonus += 50;
            Game.KnownBonusArmorClass += 50;
        }
        if (Game.HeroismTimer.Value != 0)
        {
            attackBonus += 12;
            displayedAttackBonus += 12;
        }
        if (Game.SuperheroismTimer.Value != 0)
        {
            attackBonus += 24;
            displayedAttackBonus += 24;
            Game.ArmorClassBonus -= 10;
            Game.KnownBonusArmorClass -= 10;
        }
        if (Game.HasteTimer.Value != 0)
        {
            Game.Speed.IntValue += 10;
        }
        if (Game.SlowTimer.Value != 0)
        {
            Game.Speed.IntValue -= 10;
        }
        if (Game.CharacterClass.IsMartialArtist && !Game.MartialArtistHeavyArmor())
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
        int ii = Game.StrengthAbility.StrCarryingCapacity * 100;

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
        Game.ArmorClassBonus += Game.DexterityAbility.DexArmorClassBonus;
        damageBonus += Game.StrengthAbility.StrDamageBonus;
        attackBonus += Game.DexterityAbility.DexAttackBonus;
        attackBonus += Game.StrengthAbility.StrAttackBonus;
        Game.KnownBonusArmorClass += Game.DexterityAbility.DexArmorClassBonus;
        displayedDamageBonus += Game.StrengthAbility.StrDamageBonus;
        displayedAttackBonus += Game.DexterityAbility.DexAttackBonus;
        displayedAttackBonus += Game.StrengthAbility.StrAttackBonus;
        int hold = Game.StrengthAbility.StrMaxWeaponWeight;

        // Enumerate all of the ranged weapon slots.
        foreach (WieldSlot rangedWeaponInventorySlot in Game.SingletonRepository.Get<WieldSlot>().Where(_inventorySlot => _inventorySlot.IsRangedWeapon))
        {
            // Enumerate all of the items in the slow.
            foreach (int index in rangedWeaponInventorySlot.InventorySlots)
            {
                // Retrieve the item.
                Item? oPtr = Game.GetInventoryItem(index);
                if (oPtr != null)
                {
                    // Determine if the ranged weapon is too heavy.
                    if (hold < oPtr.EffectiveAttributeSet.Weight / 10)
                    {
                        attackBonus += 2 * (hold - (oPtr.EffectiveAttributeSet.Weight / 10));
                        displayedAttackBonus += 2 * (hold - (oPtr.EffectiveAttributeSet.Weight / 10));
                        hasHeavyBow = true;
                    }
                    else
                    {
                        RangedWeaponBonus[] table = Game.SingletonRepository.Get<RangedWeaponBonus>(); // TODO: This will be slow because the GenericRepository is type casting every record.

                        // Retrieve all of the records that apply.
                        RangedWeaponBonus[] matchingBonuses = table.Where(_rangedWeaponBonus => 
                            (_rangedWeaponBonus.CharacterClassBindingKey is null || _rangedWeaponBonus.CharacterClassBindingKey == Game.CharacterClass.GetKey) &&
                            (_rangedWeaponBonus.ItemClassBindingKey is null || _rangedWeaponBonus.ItemClassBindingKey ==oPtr.ItemClass.GetKey) &&
                            (_rangedWeaponBonus.ExperienceLevel is null || _rangedWeaponBonus.ExperienceLevel.Value <= Game.ExperienceLevel.IntValue)).ToArray();

                        foreach (RangedWeaponBonus rangedWeaponBonus in matchingBonuses)
                        {
                            Game.MissileAttacksPerRound += rangedWeaponBonus.BonusMissileAttacksPerRound;
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

        // TODO: Legacy code only had 1 possibility for the melee weapon.  Now we are scanning multiple wield slots capable of multiple items.
        foreach (WieldSlot meleeWeaponInventorySlot in Game.SingletonRepository.Get<WieldSlot>().Where(_inventorySlot => _inventorySlot.IsMeleeWeapon))
        {
            foreach (int index in meleeWeaponInventorySlot.InventorySlots)
            {
                Item? oPtr = Game.GetInventoryItem(index);
                if (oPtr != null && hold < oPtr.EffectiveAttributeSet.Weight / 10)
                {
                    attackBonus += 2 * (hold - (oPtr.EffectiveAttributeSet.Weight / 10));
                    displayedAttackBonus += 2 * (hold - (oPtr.EffectiveAttributeSet.Weight / 10));
                    hasHeavyWeapon = true;
                }
                if (oPtr != null && !hasHeavyWeapon)
                {
                    int num = Game.CharacterClass.MaximumMeleeAttacksPerRound(Game.ExperienceLevel.IntValue);
                    int wgt = Game.CharacterClass.MaximumWeight;
                    int mul = Game.CharacterClass.AttackSpeedMultiplier;
                    int div = oPtr.EffectiveAttributeSet.Weight < wgt ? wgt : oPtr.EffectiveAttributeSet.Weight;
                    int strIndex = Game.StrengthAbility.StrAttackSpeedComponent * mul / div;
                    if (strIndex > 11)
                    {
                        strIndex = 11;
                    }
                    int dexIndex = Game.DexterityAbility.DexAttackSpeedComponent;
                    if (dexIndex > 11)
                    {
                        dexIndex = 11;
                    }
                    Game.MeleeAttacksPerRound = Game.BlowsTable[strIndex][dexIndex];
                    if (Game.MeleeAttacksPerRound > num)
                    {
                        Game.MeleeAttacksPerRound = num;
                    }
                    Game.MeleeAttacksPerRound += extraBlows;
                    if (Game.CharacterClass.MeleeAttacksPerRoundBonus is not null)
                    {
                        int meleeAttacksPerRound = Game.ComputeIntegerExpression(Game.CharacterClass.MeleeAttacksPerRoundBonus).Value;
                        Game.MeleeAttacksPerRound += meleeAttacksPerRound;
                    }
                    if (Game.MeleeAttacksPerRound < 1)
                    {
                        Game.MeleeAttacksPerRound = 1;
                    }
                    Game.SkillDigging += oPtr.EffectiveAttributeSet.Weight / 10;
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
                        attackBonus += Game.ExperienceLevel.IntValue / 3;
                        damageBonus += Game.ExperienceLevel.IntValue / 3;
                        displayedAttackBonus += Game.ExperienceLevel.IntValue / 3;
                        displayedDamageBonus += Game.ExperienceLevel.IntValue / 3;
                    }
                }

                MartialArtistArmorAux = false;
                if (Game.CharacterClass.AttackAndDamageBonusPerExperienceLevelDivisor is not null)
                {
                    int divisor = Game.CharacterClass.AttackAndDamageBonusPerExperienceLevelDivisor.Value;
                    attackBonus += Game.ExperienceLevel.IntValue / divisor;
                    damageBonus += Game.ExperienceLevel.IntValue / divisor;
                    displayedAttackBonus += Game.ExperienceLevel.IntValue / divisor;
                    displayedDamageBonus += Game.ExperienceLevel.IntValue / divisor;
                }
                
                if (Game.CharacterClass.AttackAndDamageBonusForUnpriestlyWeapon is not null && !Game.HasBlessedBlade && oPtr != null && (oPtr.ItemClass==Game.SingletonRepository.Get<ItemClass>(nameof(SwordsItemClass)) || oPtr.ItemClass == Game.SingletonRepository.Get<ItemClass>(nameof(PolearmsItemClass))))
                {
                    attackBonus += Game.CharacterClass.AttackAndDamageBonusForUnpriestlyWeapon.Value;
                    damageBonus += Game.CharacterClass.AttackAndDamageBonusForUnpriestlyWeapon.Value;
                    displayedAttackBonus += Game.CharacterClass.AttackAndDamageBonusForUnpriestlyWeapon.Value;
                    displayedDamageBonus += Game.CharacterClass.AttackAndDamageBonusForUnpriestlyWeapon.Value;
                    hasUnpriestlyWeapon = true;
                }

                Bonuses? characterClassMeleeWeaponBonuses = Game.CharacterClass.GetBonusesForMeleeWeapon(oPtr);
                if (characterClassMeleeWeaponBonuses is not null)
                {
                    bonusesToMerge.Add(characterClassMeleeWeaponBonuses);
                }

                if (Game.MartialArtistHeavyArmor())
                {
                    MartialArtistArmorAux = true;
                }
            }
        }

        Game.SkillStealth++;
        Game.ComputedDisarmTraps += Game.DexterityAbility.DexDisarmBonus;
        Game.ComputedDisarmTraps += Game.IntelligenceAbility.IntDisarmBonus;
        Game.SkillUseDevice += Game.IntelligenceAbility.IntUseDeviceBonus;
        Game.SkillSavingThrow += Game.WisdomAbility.WisSavingThrowBonus;
        Game.SkillDigging += Game.StrengthAbility.StrDiggingBonus;
        Game.ComputedDisarmTraps += (Game.CharacterClass.DisarmBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillUseDevice += (Game.CharacterClass.DeviceBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillSavingThrow += (Game.CharacterClass.SaveBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillStealth += (Game.CharacterClass.StealthBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillSearching += (Game.CharacterClass.SearchBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillSearchFrequency += (Game.CharacterClass.SearchFrequencyPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillMelee += (Game.CharacterClass.MeleeAttackBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillRanged += (Game.CharacterClass.RangedAttackBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillThrowing += (Game.CharacterClass.RangedAttackBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
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

        // Create a new bonuses that we will use to merge with all of the additionals.
        Bonuses newBonuses = new Bonuses
        {
            BaseArmorClass = baseArmorClass,
            AttackBonus = attackBonus,
            DamageBonus = damageBonus,
            DisplayedAttackBonus = displayedAttackBonus,
            DisplayedDamageBonus = displayedDamageBonus,
            HasUnpriestlyWeapon = hasUnpriestlyWeapon,
            HasHeavyBow = hasHeavyBow,
            HasHeavyWeapon = hasHeavyWeapon,
        };

        // Merge the additional bonuses.
        foreach (Bonuses bonuses in bonusesToMerge)
        {
            newBonuses = newBonuses.Merge(bonuses);
        }

        // Grab a copy of the previous/old bonuses for us to render messages.
        Bonuses previousBonuses = Game.Bonuses;

        // Set the game bonuses with the new immutable object.
        Game.Bonuses = newBonuses;

        if (Game.CharacterXtra)
        {
            return;
        }

        if (previousBonuses.HasHeavyBow != newBonuses.HasHeavyBow) // TODO: This should be moved to the wield action
        {
            if (newBonuses.HasHeavyBow)
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
        }

        if (previousBonuses.HasHeavyWeapon != newBonuses.HasHeavyWeapon) // TODO: This should be moved to the wield action
        {
            if (newBonuses.HasHeavyWeapon)
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
        }
        if (previousBonuses.HasUnpriestlyWeapon != newBonuses.HasUnpriestlyWeapon) // TODO: This should be moved to the wield action
        {
            if (newBonuses.HasUnpriestlyWeapon)
            {
                Game.MsgPrint(Game.CharacterClass.RenderChaosMessageForWieldingUnpriestlyWeapon ? "Your weapon restricts the flow of chaos through you." : "You do not feel comfortable with your weapon.");
            }
            else if (Game.GetInventoryItem(InventorySlotEnum.MeleeWeapon) != null)
            {
                Game.MsgPrint("You feel comfortable with your weapon.");
            }
            else
            {
                Game.MsgPrint(Game.CharacterClass.RenderChaosMessageForWieldingUnpriestlyWeapon ? "Chaos flows freely through you again." : "You feel more comfortable after removing your weapon.");
            }
        }
        if (Game.CharacterClass.IsMartialArtist && MartialArtistArmorAux != MartialArtistNotifyAux) // TODO: This should be moved to the wield action
        {
            Game.MsgPrint(Game.MartialArtistHeavyArmor() ? "The weight of your armor disrupts your balance." : "You regain your balance.");
            MartialArtistNotifyAux = MartialArtistArmorAux;
        }
    }
}
