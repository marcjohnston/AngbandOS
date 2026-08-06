// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FlaggedActions;

internal class UpdateBonusesFlaggedAction : FlaggedAction
{
    private bool PreviousMartialArtistArmorAux;

    private UpdateBonusesFlaggedAction(Game game) : base(game) { }
    public override void Bind(RestoreGameState? restoreGameState)
    {
        base.Bind(restoreGameState);
        if (restoreGameState is not null)
        {
            PreviousMartialArtistArmorAux = restoreGameState.GetByKey(nameof(PreviousMartialArtistArmorAux)).GetBool();
        }
    }
    private EffectiveAttributeSet BuildEffectiveAttributeSetForPlayer()
    {
        EffectiveAttributeSet effectiveAttributeSet = new EffectiveAttributeSet(Game);

        // Squash, refresh and apply the race attributes.
        Game.Race.RefreshAndSquashAttributeSet();
        effectiveAttributeSet.MergeAttributeSet(Game.Race.AttributeSet);

        // Squash, refresh and apply the character class attributes.
        Game.CharacterClass.RefreshAndSquashAttributeSet();
        effectiveAttributeSet.MergeAttributeSet(Game.CharacterClass.AttributeSet);

        // Apply all of the mutations that the player has.        
        ReadOnlyAttributeSet mutationsAttributeSet = Game.GetMutationsAttributeSet();
        effectiveAttributeSet.MergeAttributeSet(mutationsAttributeSet);

        // Apply all of the items that the player is wielding.
        foreach (EquipmentWieldSlot equipmentWieldSlot in Game.SingletonRepository.Get<EquipmentWieldSlot>())
        {
            foreach (int i in equipmentWieldSlot.InventorySlots)
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

    public override DictionaryGameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(base.Serialize(saveGameState), 
            (nameof(PreviousMartialArtistArmorAux), saveGameState.CreateGameStateBag(PreviousMartialArtistArmorAux))
        );
    }
    protected override void Execute()
    {
        Game.AttributeSet = BuildEffectiveAttributeSetForPlayer().ToReadOnly(); // TODO: This isn't being used yet.

        Game.HasAggravation = Game.AttributeSet.GetBool(nameof(AggravateAttribute));
        Game.HasRegeneration = Game.AttributeSet.GetBool(nameof(RegenAttribute)) && !Game.AttributeSet.GetBool(nameof(SuppressRegenAttribute));
        Game.HasAcidImmunity = Game.AttributeSet.GetBool(nameof(ImAcidAttribute));
        Game.GlowRadius = Game.AttributeSet.GetInt(nameof(GlowRadiusAttribute)) + (Game.AttributeSet.GetBool(nameof(ShFireAttribute)) ? 1 : 0);
        Game.HasAcidResistance = Game.AttributeSet.GetBool(nameof(ResAcidAttribute)) || Game.AcidResistanceTimer.Value > 0;
        Game.HasAntiMagic = Game.AttributeSet.GetBool(nameof(NoMagicAttribute));
        Game.HasSustainCharisma = Game.AttributeSet.GetBool(nameof(SustChaAttribute));
        Game.HasSustainConstitution = Game.AttributeSet.GetBool(nameof(SustConAttribute));
        Game.HasSustainDexterity = Game.AttributeSet.GetBool(nameof(SustDexAttribute));
        Game.HasSustainIntelligence = Game.AttributeSet.GetBool(nameof(SustIntAttribute));
        Game.HasSustainStrength = Game.AttributeSet.GetBool(nameof(SustStrAttribute));
        Game.HasSustainWisdom = Game.AttributeSet.GetBool(nameof(SustWisAttribute));
        Game.HasAntiTeleport = Game.AttributeSet.GetBool(nameof(NoTeleAttribute));
        Game.HasAntiTheft = Game.AttributeSet.GetBool(nameof(AntiTheftAttribute));
        Game.HasBlessedBlade = Game.AttributeSet.GetBool(nameof(BlessedAttribute));
        Game.HasBlindnessResistance = Game.AttributeSet.GetBool(nameof(ResBlindAttribute));
        Game.HasChaosResistance = Game.AttributeSet.GetBool(nameof(ResChaosAttribute));
        Game.HasColdImmunity = Game.AttributeSet.GetBool(nameof(ImColdAttribute));
        Game.HasColdResistance = Game.AttributeSet.GetBool(nameof(ResColdAttribute));
        Game.HasConfusionResistance = Game.AttributeSet.GetBool(nameof(ResConfAttribute));
        Game.HasDarkResistance = Game.AttributeSet.GetBool(nameof(ResDarkAttribute));
        Game.HasDisenchantResistance = Game.AttributeSet.GetBool(nameof(ResDisenAttribute));
        Game.HasElementalVulnerability = Game.AttributeSet.GetBool(nameof(ElementalVulnerabilityAttribute));
        Game.HasExperienceDrain = Game.AttributeSet.GetBool(nameof(DrainExpAttribute));
        Game.HasExtraMight = Game.AttributeSet.GetBool(nameof(XtraMightAttribute));
        Game.HasFearResistance = Game.AttributeSet.GetBool(nameof(ResFearAttribute)) || Game.HeroismTimer.Value > 0 || Game.SuperheroismTimer.Value > 0;
        Game.HasFeatherFall = Game.AttributeSet.GetBool(nameof(FeatherAttribute));
        Game.HasFireImmunity = Game.AttributeSet.GetBool(nameof(ImFireAttribute));
        Game.HasFireResistance = Game.AttributeSet.GetBool(nameof(ResFireAttribute)) || Game.FireResistanceTimer.Value > 0 || Game.HasFireImmunity;
        Game.HasFireSheath = Game.AttributeSet.GetBool(nameof(ShFireAttribute));
        Game.HasFreeAction = Game.AttributeSet.GetBool(nameof(FreeActAttribute));
        Game.HasHoldLife = Game.AttributeSet.GetBool(nameof(HoldLifeAttribute));
        Game.HasLightningImmunity = Game.AttributeSet.GetBool(nameof(ImElecAttribute));
        Game.HasLightningResistance = Game.AttributeSet.GetBool(nameof(ResElecAttribute)) || Game.LightningResistanceTimer.Value != 0;
        Game.HasElectricitySheath = Game.AttributeSet.GetBool(nameof(ShElecAttribute));
        Game.HasLightResistance = Game.AttributeSet.GetBool(nameof(ResLightAttribute));
        Game.HasNetherResistance = Game.AttributeSet.GetBool(nameof(ResNetherAttribute));
        Game.HasNexusResistance = Game.AttributeSet.GetBool(nameof(ResNexusAttribute));
        Game.HasPoisonResistance = Game.AttributeSet.GetBool(nameof(ResPoisAttribute));
        Game.HasQuakeWeapon = Game.AttributeSet.GetBool(nameof(QuakeAttribute));
        Game.HasRandomTeleport = Game.AttributeSet.GetBool(nameof(TeleportAttribute));
        Game.HasReflection = Game.AttributeSet.GetBool(nameof(ReflectAttribute)) || Game.EtherealnessTimer.Value > 0;
        Game.HasSeeInvisibility = Game.AttributeSet.GetBool(nameof(SeeInvisAttribute));
        Game.HasShardResistance = Game.AttributeSet.GetBool(nameof(ResShardsAttribute));
        Game.HasSlowDigestion = Game.AttributeSet.GetBool(nameof(SlowDigestAttribute));
        Game.HasSoundResistance = Game.AttributeSet.GetBool(nameof(ResSoundAttribute));
        Game.HasTelepathy = Game.AttributeSet.GetBool(nameof(TelepathyAttribute));
        Game.HasTimeResistance = Game.AttributeSet.GetBool(nameof(ResTimeAttribute));
        Game.InfraVisionRange = Game.AttributeSet.GetInt(nameof(InfraVisionAttribute)) + (Game.InfravisionTimer.Value > 0 ? 1 : 0);

        #region Speed
        int oldVisibleOnlySpeed = Game.Speed - Game.SpeedHidden; // The speed flag is only for visible speed

        // Compute the weight limit.
        int weightCarried = Game.WeightCarried;
        int carryingWeightLimit = Game.SingletonRepository.Get<Ability>(nameof(StrengthAbility)).StrCarryingCapacity * 100;
        Game.SpeedHidden = Game.AttributeSet.GetInt(nameof(SpeedHiddenAttribute)) +
            (Game.IsSearching ? -10 : 0);
        Game.Speed = 110 + Game.SpeedHidden +
            Game.AttributeSet.GetInt(nameof(SpeedAttribute)) +
            (Game.Food.IntValue >= Constants.PyFoodMax ? -10 : 0) +
            (weightCarried > carryingWeightLimit / 2 ? -(weightCarried - (carryingWeightLimit / 2)) / (carryingWeightLimit / 10) : 0) +
            (Game.HasteTimer.Value > 0 ? 10 : 0) +
            (Game.SlowTimer.Value > 0 ? -10 : 0) +
            (!Game.ArmorIsHeavy() ? Game.ExperienceLevel.IntValue / 10 : 0);

        int newVisibleOnlySpeed = Game.Speed - Game.SpeedHidden;
        if (newVisibleOnlySpeed != oldVisibleOnlySpeed)
        {
            Game.SingletonRepository.Get<FlaggedAction>(nameof(RedrawSpeedFlaggedAction)).Set();
        }
        #endregion

        #region Base, Known Bonus and Total Bonus Armor Class
        Game.BaseArmorClass = Game.AttributeSet.GetInt(nameof(BaseArmorClassAttribute));
        Game.TotalBonusArmorClass = Game.AttributeSet.GetInt(nameof(BonusArmorClassAttribute)) +
            Game.SingletonRepository.Get<Ability>(nameof(DexterityAbility)).DexArmorClassBonus +
            (Game.SuperheroismTimer.Value > 0 ? -10 : 0) +
            (Game.BlessingTimer.Value > 0 ? 5 : 0) +
            (Game.StoneskinTimer.Value > 0 ? 50 : 0) +
            (Game.InvulnerabilityTimer.Value > 0 ? 100 : 0) +
            (Game.EtherealnessTimer.Value > 0 ? 100 : 0);
        if (!Game.ArmorIsHeavy())
        {
            foreach (WieldSlot inventorySlot in Game.SingletonRepository.Get<WieldSlot>())
            {
                if (inventorySlot.Count == 0)
                {
                    int bareArmorBonus = inventorySlot.BareArmorClassBonus;
                    Game.TotalBonusArmorClass += bareArmorBonus;
                }
            }
        }
        Game.KnownBonusArmorClass = Game.TotalBonusArmorClass;
        foreach (EquipmentWieldSlot equipmentWieldSlot in Game.SingletonRepository.Get<EquipmentWieldSlot>())
        {
            foreach (int i in equipmentWieldSlot.InventorySlots)
            {
                Item? oPtr = Game.GetInventoryItem(i);
                if (oPtr is not null && !oPtr.IsKnown())
                {
                    Game.KnownBonusArmorClass -= oPtr.EffectiveAttributeSet.BonusArmorClass;
                }
            }
        }
        #endregion

        /// Old Compute

        List<Bonuses> bonusesToMerge = new List<Bonuses>();
        int attackBonus = 0;
        int damageBonus = 0;
        int displayedAttackBonus = 0;
        int displayedDamageBonus = 0;
        bool hasUnpriestlyWeapon = false;
        bool hasHeavyBow = false;
        bool hasHeavyWeapon = false;

        int extraShots;
        bool oldTelepathy = Game.HasTelepathy;
        bool oldSeeInv = Game.HasSeeInvisibility;
        int extraBlows = extraShots = 0;
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            ability.Bonus = 0;
        }
        Game.ComputedDisarmTraps = Game.Race.AttributeSet.GetInt(nameof(DisarmTrapsAttribute)) + Game.CharacterClass.AttributeSet.GetInt(nameof(DisarmTrapsAttribute)); // done
        Game.SkillUseDevice = Game.Race.UseDevice + Game.CharacterClass.UseDevice; // done
        Game.SkillSavingThrow = Game.Race.SavingThrow + Game.CharacterClass.SavingThrow; // done
        Game.SkillStealth = Game.Race.Stealth + Game.CharacterClass.Stealth; // done .. need to copy
        Game.SkillSearching = Game.Race.Search + Game.CharacterClass.Search; // done .. need to copy
        Game.SkillPerception = Game.Race.BasePerception + Game.CharacterClass.BasePerception; // added to attributes
        Game.SkillMelee = Game.Race.MeleeToHit + Game.CharacterClass.MeleeToHit; // this appears to be tohit
        Game.SkillRanged = Game.Race.RangedToHit + Game.CharacterClass.RangedToHit; // added rangedtohit
        Game.SkillThrowing = Game.Race.RangedToHit + Game.CharacterClass.RangedToHit; // added throwingtohit
        Game.SkillDigging = 0;
        Game.MeleeAttacksPerRound = 1;
        Game.MissileAttacksPerRound = 1;
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            RaceAbility raceAbility = Game.SingletonRepository.Get<RaceAbility>(RaceAbility.GetCompositeKey(Game.Race, ability));
            string compositeKey = CharacterClassAbility.GetCompositeKey(Game.CharacterClass, ability);
            CharacterClassAbility characterClassAbility = Game.SingletonRepository.Get<CharacterClassAbility>(compositeKey);
            ability.Bonus += raceAbility.Bonus + characterClassAbility.Bonus;
        }
        Game.SingletonRepository.Get<Ability>(nameof(StrengthAbility)).Bonus += Game.StrengthBonus;
        Game.SingletonRepository.Get<Ability>(nameof(IntelligenceAbility)).Bonus += Game.IntelligenceBonus;
        Game.SingletonRepository.Get<Ability>(nameof(WisdomAbility)).Bonus += Game.WisdomBonus;
        Game.SingletonRepository.Get<Ability>(nameof(DexterityAbility)).Bonus += Game.DexterityBonus;
        Game.SingletonRepository.Get<Ability>(nameof(ConstitutionAbility)).Bonus += Game.ConstitutionBonus;
        Game.SingletonRepository.Get<Ability>(nameof(CharismaAbility)).Bonus += Game.CharismaBonus;
        Game.SkillPerception += Game.SearchBonus;
        Game.SkillSearching += Game.SearchBonus;
        Game.SkillStealth += Game.StealthBonus;
        if (Game.MagicResistance)
        {
            Game.SkillSavingThrow += 15 + (Game.ExperienceLevel.IntValue / 5);
        }
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            ability.OverrideUpdateBonuses();
        }
        foreach (EquipmentWieldSlot equipmentWieldSlot in Game.SingletonRepository.Get<EquipmentWieldSlot>())
        {
            foreach (int i in equipmentWieldSlot.InventorySlots)
            {
                Item? oPtr = Game.GetInventoryItem(i);
                if (oPtr != null)
                {
                    Game.SingletonRepository.Get<Ability>(nameof(StrengthAbility)).Bonus += oPtr.EffectiveAttributeSet.Strength;
                    Game.SingletonRepository.Get<Ability>(nameof(IntelligenceAbility)).Bonus += oPtr.EffectiveAttributeSet.Intelligence;
                    Game.SingletonRepository.Get<Ability>(nameof(WisdomAbility)).Bonus += oPtr.EffectiveAttributeSet.Wisdom;
                    Game.SingletonRepository.Get<Ability>(nameof(DexterityAbility)).Bonus += oPtr.EffectiveAttributeSet.Dexterity;
                    Game.SingletonRepository.Get<Ability>(nameof(ConstitutionAbility)).Bonus += oPtr.EffectiveAttributeSet.Constitution;
                    Game.SingletonRepository.Get<Ability>(nameof(CharismaAbility)).Bonus += oPtr.EffectiveAttributeSet.Charisma;
                    Game.SkillStealth += oPtr.EffectiveAttributeSet.Stealth;
                    Game.SkillSearching += oPtr.EffectiveAttributeSet.Search * 5;
                    Game.SkillPerception += oPtr.EffectiveAttributeSet.Search * 5;
                    Game.SkillDigging += oPtr.EffectiveAttributeSet.Tunnel * 20;
                    extraBlows += oPtr.EffectiveAttributeSet.Attacks;
                    if (oPtr.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(XtraShotsAttribute)).Get())
                    {
                        extraShots++;
                    }
                    if (oPtr.EffectiveAttributeSet.Get<BitwiseOrEffectiveAttributeValue>(nameof(WraithAttribute)).Get())
                    {
                        Game.EtherealnessTimer.SetValue(Math.Max(Game.EtherealnessTimer.Value, 20));
                    }
                    if (equipmentWieldSlot.IsWeapon)
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
        if (Game.BlessingTimer.Value != 0)
        {
            attackBonus += 10;
            displayedAttackBonus += 10;
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
        }
        if (Game.HasTelepathy != oldTelepathy)
        {
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
        }
        if (Game.HasSeeInvisibility != oldSeeInv)
        {
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
        }
        displayedDamageBonus += Game.SingletonRepository.Get<Ability>(nameof(StrengthAbility)).StrDamageBonus;
        displayedAttackBonus += Game.SingletonRepository.Get<Ability>(nameof(DexterityAbility)).DexAttackBonus;
        displayedAttackBonus += Game.SingletonRepository.Get<Ability>(nameof(StrengthAbility)).StrAttackBonus;
        int hold = Game.SingletonRepository.Get<Ability>(nameof(StrengthAbility)).StrMaxWeaponWeight;

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
        bool newMartialArtistAndArmorIsHeavy = false;
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
                    int strIndex = Game.SingletonRepository.Get<Ability>(nameof(StrengthAbility)).StrAttackSpeedComponent * mul / div;
                    if (strIndex > 11)
                    {
                        strIndex = 11;
                    }
                    int dexIndex = Game.SingletonRepository.Get<Ability>(nameof(DexterityAbility)).DexAttackSpeedComponent;
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
                else if (Game.IsUsingMartialArts())
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
                    if (Game.ArmorIsHeavy())
                    {
                        Game.MeleeAttacksPerRound /= 2;
                    }
                    Game.MeleeAttacksPerRound += 1 + extraBlows;
                    if (!Game.ArmorIsHeavy())
                    {
                        attackBonus += Game.ExperienceLevel.IntValue / 3;
                        damageBonus += Game.ExperienceLevel.IntValue / 3;
                        displayedAttackBonus += Game.ExperienceLevel.IntValue / 3;
                        displayedDamageBonus += Game.ExperienceLevel.IntValue / 3;
                    }
                }

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

                if (Game.ArmorIsHeavy())
                {
                    newMartialArtistAndArmorIsHeavy = true;
                }
            }
        }

        Game.SkillStealth++;
        Game.ComputedDisarmTraps += Game.SingletonRepository.Get<Ability>(nameof(DexterityAbility)).DexDisarmBonus;
        Game.ComputedDisarmTraps += Game.SingletonRepository.Get<Ability>(nameof(IntelligenceAbility)).IntDisarmBonus;
        Game.SkillUseDevice += Game.SingletonRepository.Get<Ability>(nameof(IntelligenceAbility)).IntUseDeviceBonus;
        Game.SkillSavingThrow += Game.SingletonRepository.Get<Ability>(nameof(WisdomAbility)).WisSavingThrowBonus;
        Game.SkillDigging += Game.SingletonRepository.Get<Ability>(nameof(StrengthAbility)).StrDiggingBonus;
        Game.ComputedDisarmTraps += (Game.CharacterClass.DisarmBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillUseDevice += (Game.CharacterClass.DeviceBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillSavingThrow += (Game.CharacterClass.SaveBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
        Game.SkillStealth += (Game.CharacterClass.StealthBonusPerLevel * Game.ExperienceLevel.IntValue) / 10;
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
        if (newMartialArtistAndArmorIsHeavy != PreviousMartialArtistArmorAux) // TODO: This should be moved to the wield action
        {
            Game.MsgPrint(Game.ArmorIsHeavy() ? "The weight of your armor disrupts your balance." : "You regain your balance.");
            PreviousMartialArtistArmorAux = newMartialArtistAndArmorIsHeavy;
        }
    }
}
