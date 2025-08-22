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
    protected override void Execute()
    {
        Game.EffectivePropertySet = new EffectivePropertySet();
        Game.EffectivePropertySet.AddEnhancement(Game.Race.Enhancement.GenerateItemCharacteristics());
        Game.EffectivePropertySet.AddEnhancement(Game.BaseCharacterClass.Enhancement.GenerateItemCharacteristics());

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
        Game.DisplayedArmorClassBonus = 0;
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
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            RaceAbility raceAbility = Game.SingletonRepository.Get<RaceAbility>(RaceAbility.GetCompositeKey(Game.Race, ability));
            string compositeKey = CharacterClassAbility.GetCompositeKey(Game.BaseCharacterClass, ability);
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
        Game.InfravisionRange += Game.InfravisionBonus;
        Game.HasElectricitySheath |= Game.ElecHit;
        Game.HasFireSheath |= Game.FireHit;
        if (Game.GlowInTheDarkRadius == 0 && Game.FireHit)
        {
            Game.GlowInTheDarkRadius = 1;
        }
        Game.ArmorClassBonus += Game.GenomeArmorClassBonus;
        Game.DisplayedArmorClassBonus += Game.GenomeArmorClassBonus;
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
                    Game.EffectivePropertySet.AddEnhancement(oPtr.EffectivePropertySet.ToReadOnly());

                    Game.StrengthAbility.Bonus += oPtr.EffectivePropertySet.BonusStrength;
                    Game.IntelligenceAbility.Bonus += oPtr.EffectivePropertySet.BonusIntelligence;
                    Game.WisdomAbility.Bonus += oPtr.EffectivePropertySet.BonusWisdom;
                    Game.DexterityAbility.Bonus += oPtr.EffectivePropertySet.BonusDexterity;
                    Game.ConstitutionAbility.Bonus += oPtr.EffectivePropertySet.BonusConstitution;
                    Game.CharismaAbility.Bonus += oPtr.EffectivePropertySet.BonusCharisma;
                    Game.SkillStealth += oPtr.EffectivePropertySet.BonusStealth;
                    Game.SkillSearching += oPtr.EffectivePropertySet.BonusSearch * 5;
                    Game.SkillSearchFrequency += oPtr.EffectivePropertySet.BonusSearch * 5;
                    Game.InfravisionRange += oPtr.EffectivePropertySet.BonusInfravision;
                    Game.SkillDigging += oPtr.EffectivePropertySet.BonusTunnel * 20;
                    Game.Speed.IntValue += oPtr.EffectivePropertySet.BonusSpeed;
                    extraBlows += oPtr.EffectivePropertySet.BonusAttacks;
                    if (oPtr.EffectivePropertySet.Impact)
                    {
                        Game.HasQuakeWeapon = true;
                    }
                    if (oPtr.EffectivePropertySet.AntiTheft)
                    {
                        Game.HasAntiTheft = true;
                    }
                    if (oPtr.EffectivePropertySet.XtraShots)
                    {
                        extraShots++;
                    }
                    if (oPtr.EffectivePropertySet.Aggravate)
                    {
                        Game.HasAggravation = true;
                    }
                    if (oPtr.EffectivePropertySet.Teleport)
                    {
                        Game.HasRandomTeleport = true;
                    }
                    if (oPtr.EffectivePropertySet.DrainExp)
                    {
                        Game.HasExperienceDrain = true;
                    }
                    if (oPtr.EffectivePropertySet.Blessed)
                    {
                        Game.HasBlessedBlade = true;
                    }
                    if (oPtr.EffectivePropertySet.XtraMight)
                    {
                        Game.HasExtraMight = true;
                    }
                    if (oPtr.EffectivePropertySet.SlowDigest)
                    {
                        Game.HasSlowDigestion = true;
                    }
                    if (oPtr.EffectivePropertySet.Regen)
                    {
                        Game.HasRegeneration = true;
                    }
                    if (oPtr.EffectivePropertySet.Telepathy)
                    {
                        Game.HasTelepathy = true;
                    }
                    if (oPtr.EffectivePropertySet.SeeInvis)
                    {
                        Game.HasSeeInvisibility = true;
                    }
                    if (oPtr.EffectivePropertySet.Feather)
                    {
                        Game.HasFeatherFall = true;
                    }
                    if (oPtr.EffectivePropertySet.FreeAct)
                    {
                        Game.HasFreeAction = true;
                    }
                    if (oPtr.EffectivePropertySet.HoldLife)
                    {
                        Game.HasHoldLife = true;
                    }
                    if (oPtr.EffectivePropertySet.Wraith)
                    {
                        Game.EtherealnessTimer.SetValue(Math.Max(Game.EtherealnessTimer.Value, 20));
                    }
                    if (oPtr.EffectivePropertySet.ImFire)
                    {
                        Game.HasFireImmunity = true;
                    }
                    if (oPtr.EffectivePropertySet.ImAcid)
                    {
                        Game.HasAcidImmunity = true;
                    }
                    if (oPtr.EffectivePropertySet.ImCold)
                    {
                        Game.HasColdImmunity = true;
                    }
                    if (oPtr.EffectivePropertySet.ImElec)
                    {
                        Game.HasLightningImmunity = true;
                    }
                    if (oPtr.EffectivePropertySet.ResAcid)
                    {
                        Game.HasAcidResistance = true;
                    }
                    if (oPtr.EffectivePropertySet.ResElec)
                    {
                        Game.HasLightningResistance = true;
                    }
                    if (oPtr.EffectivePropertySet.ResFire)
                    {
                        Game.HasFireResistance = true;
                    }
                    if (oPtr.EffectivePropertySet.ResCold)
                    {
                        Game.HasColdResistance = true;
                    }
                    if (oPtr.EffectivePropertySet.ResPois)
                    {
                        Game.HasPoisonResistance = true;
                    }
                    if (oPtr.EffectivePropertySet.ResFear)
                    {
                        Game.HasFearResistance = true;
                    }
                    if (oPtr.EffectivePropertySet.ResConf)
                    {
                        Game.HasConfusionResistance = true;
                    }
                    if (oPtr.EffectivePropertySet.ResSound)
                    {
                        Game.HasSoundResistance = true;
                    }
                    if (oPtr.EffectivePropertySet.ResLight)
                    {
                        Game.HasLightResistance = true;
                    }
                    if (oPtr.EffectivePropertySet.ResDark)
                    {
                        Game.HasDarkResistance = true;
                    }
                    if (oPtr.EffectivePropertySet.ResChaos)
                    {
                        Game.HasChaosResistance = true;
                    }
                    if (oPtr.EffectivePropertySet.ResDisen)
                    {
                        Game.HasDisenchantResistance = true;
                    }
                    if (oPtr.EffectivePropertySet.ResShards)
                    {
                        Game.HasShardResistance = true;
                    }
                    if (oPtr.EffectivePropertySet.ResNexus)
                    {
                        Game.HasNexusResistance = true;
                    }
                    if (oPtr.EffectivePropertySet.ResBlind)
                    {
                        Game.HasBlindnessResistance = true;
                    }
                    if (oPtr.EffectivePropertySet.ResNether)
                    {
                        Game.HasNetherResistance = true;
                    }
                    if (oPtr.EffectivePropertySet.Reflect)
                    {
                        Game.HasReflection = true;
                    }
                    if (oPtr.EffectivePropertySet.ShFire)
                    {
                        Game.HasFireSheath = true;
                    }
                    if (oPtr.EffectivePropertySet.ShElec)
                    {
                        Game.HasElectricitySheath = true;
                    }
                    if (oPtr.EffectivePropertySet.NoMagic)
                    {
                        Game.HasAntiMagic = true;
                    }
                    if (oPtr.EffectivePropertySet.NoTele)
                    {
                        Game.HasAntiTeleport = true;
                    }
                    if (oPtr.EffectivePropertySet.SustStr)
                    {
                        Game.HasSustainStrength = true;
                    }
                    if (oPtr.EffectivePropertySet.SustInt)
                    {
                        Game.HasSustainIntelligence = true;
                    }
                    if (oPtr.EffectivePropertySet.SustWis)
                    {
                        Game.HasSustainWisdom = true;
                    }
                    if (oPtr.EffectivePropertySet.SustDex)
                    {
                        Game.HasSustainDexterity = true;
                    }
                    if (oPtr.EffectivePropertySet.SustCon)
                    {
                        Game.HasSustainConstitution = true;
                    }
                    if (oPtr.EffectivePropertySet.SustCha)
                    {
                        Game.HasSustainCharisma = true;
                    }
                    baseArmorClass += oPtr.ArmorClass;
                    Game.DisplayedBaseArmorClass += oPtr.ArmorClass;
                    Game.ArmorClassBonus += oPtr.EffectivePropertySet.BonusArmorClass;
                    if (oPtr.IsKnown())
                    {
                        Game.DisplayedArmorClassBonus += oPtr.EffectivePropertySet.BonusArmorClass;
                    }
                    if (inventorySlot.IsWeapon)
                    {
                        continue;
                    }
                    attackBonus += oPtr.EffectivePropertySet.BonusHits;
                    damageBonus += oPtr.EffectivePropertySet.BonusDamage;
                    if (oPtr.IsKnown())
                    {
                        displayedAttackBonus += oPtr.EffectivePropertySet.BonusHits;
                    }
                    if (oPtr.IsKnown())
                    {
                        displayedDamageBonus += oPtr.EffectivePropertySet.BonusDamage;
                    }
                }
            }
        }
        if (Game.BaseCharacterClass.IsMartialArtist && !Game.MartialArtistHeavyArmor())
        {
            foreach (WieldSlot inventorySlot in Game.SingletonRepository.Get<WieldSlot>())
            {
                if (inventorySlot.Count == 0)
                {
                    int bareArmorBonus = inventorySlot.BareArmorClassBonus;
                    Game.ArmorClassBonus += bareArmorBonus;
                    Game.DisplayedArmorClassBonus += bareArmorBonus;
                }
            }
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
            Game.DisplayedArmorClassBonus += 100;
        }
        if (Game.EtherealnessTimer.Value != 0)
        {
            Game.ArmorClassBonus += 100;
            Game.DisplayedArmorClassBonus += 100;
            Game.HasReflection = true;
        }
        if (Game.BlessingTimer.Value != 0)
        {
            Game.ArmorClassBonus += 5;
            Game.DisplayedArmorClassBonus += 5;
            attackBonus += 10;
            displayedAttackBonus += 10;
        }
        if (Game.StoneskinTimer.Value != 0)
        {
            Game.ArmorClassBonus += 50;
            Game.DisplayedArmorClassBonus += 50;
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
            Game.DisplayedArmorClassBonus -= 10;
        }
        if (Game.HasteTimer.Value != 0)
        {
            Game.Speed.IntValue += 10;
        }
        if (Game.SlowTimer.Value != 0)
        {
            Game.Speed.IntValue -= 10;
        }
        if (Game.BaseCharacterClass.IsMartialArtist && !Game.MartialArtistHeavyArmor())
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
        Game.DisplayedArmorClassBonus += Game.DexterityAbility.DexArmorClassBonus;
        displayedDamageBonus += Game.StrengthAbility.StrDamageBonus;
        displayedAttackBonus += Game.DexterityAbility.DexAttackBonus;
        displayedAttackBonus += Game.StrengthAbility.StrAttackBonus;
        int hold = Game.StrengthAbility.StrMaxWeaponWeight;
        foreach (WieldSlot rangedWeaponInventorySlot in Game.SingletonRepository.Get<WieldSlot>().Where(_inventorySlot => _inventorySlot.IsRangedWeapon))
        {
            foreach (int index in rangedWeaponInventorySlot.InventorySlots)
            {
                Item? oPtr = Game.GetInventoryItem(index);
                if (oPtr != null)
                {
                    if (hold < oPtr.EffectivePropertySet.Weight / 10)
                    {
                        attackBonus += 2 * (hold - (oPtr.EffectivePropertySet.Weight / 10));
                        displayedAttackBonus += 2 * (hold - (oPtr.EffectivePropertySet.Weight / 10));
                        hasHeavyBow = true;
                    }
                    else
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

        // TODO: Legacy code only had 1 possibility for the melee weapon.  Now we are scanning multiple wield slots capable of multiple items.
        foreach (WieldSlot meleeWeaponInventorySlot in Game.SingletonRepository.Get<WieldSlot>().Where(_inventorySlot => _inventorySlot.IsMeleeWeapon))
        {
            foreach (int index in meleeWeaponInventorySlot.InventorySlots)
            {
                Item? oPtr = Game.GetInventoryItem(index);
                if (oPtr != null && hold < oPtr.EffectivePropertySet.Weight / 10)
                {
                    attackBonus += 2 * (hold - (oPtr.EffectivePropertySet.Weight / 10));
                    displayedAttackBonus += 2 * (hold - (oPtr.EffectivePropertySet.Weight / 10));
                    hasHeavyWeapon = true;
                }
                if (oPtr != null && !hasHeavyWeapon)
                {
                    int num = Game.BaseCharacterClass.MaximumMeleeAttacksPerRound(Game.ExperienceLevel.IntValue);
                    int wgt = Game.BaseCharacterClass.MaximumWeight;
                    int mul = Game.BaseCharacterClass.AttackSpeedMultiplier;
                    int div = oPtr.EffectivePropertySet.Weight < wgt ? wgt : oPtr.EffectivePropertySet.Weight;
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
                    if (Game.BaseCharacterClass.MeleeAttacksPerRoundBonus is not null)
                    {
                        int meleeAttacksPerRound = Game.ComputeIntegerExpression(Game.BaseCharacterClass.MeleeAttacksPerRoundBonus).Value;
                        Game.MeleeAttacksPerRound += meleeAttacksPerRound;
                    }
                    if (Game.MeleeAttacksPerRound < 1)
                    {
                        Game.MeleeAttacksPerRound = 1;
                    }
                    Game.SkillDigging += oPtr.EffectivePropertySet.Weight / 10;
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
                if (Game.BaseCharacterClass.ID == CharacterClassEnum.Warrior)
                {
                    attackBonus += Game.ExperienceLevel.IntValue / 5;
                    damageBonus += Game.ExperienceLevel.IntValue / 5;
                    displayedAttackBonus += Game.ExperienceLevel.IntValue / 5;
                    displayedDamageBonus += Game.ExperienceLevel.IntValue / 5;
                }
                
                if ((Game.BaseCharacterClass.ID == CharacterClassEnum.Priest || Game.BaseCharacterClass.ID == CharacterClassEnum.Druid) && !Game.HasBlessedBlade && oPtr != null && (oPtr.ItemClass==Game.SingletonRepository.Get<ItemClass>(nameof(SwordsItemClass)) || oPtr.ItemClass == Game.SingletonRepository.Get<ItemClass>(nameof(PolearmsItemClass))))
                {
                    attackBonus -= 2;
                    damageBonus -= 2;
                    displayedAttackBonus -= 2;
                    displayedDamageBonus -= 2;
                    hasUnpriestlyWeapon = true;
                }

                Bonuses? characterClassMeleeWeaponBonuses = Game.BaseCharacterClass.GetBonusesForMeleeWeapon(oPtr);
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
        Game.SkillDisarmTraps += Game.DexterityAbility.DexDisarmBonus;
        Game.SkillDisarmTraps += Game.IntelligenceAbility.IntDisarmBonus;
        Game.SkillUseDevice += Game.IntelligenceAbility.IntUseDeviceBonus;
        Game.SkillSavingThrow += Game.WisdomAbility.WisSavingThrowBonus;
        Game.SkillDigging += Game.StrengthAbility.StrDiggingBonus;
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
                Game.MsgPrint(Game.BaseCharacterClass.ID == CharacterClassEnum.Cultist ? "Your weapon restricts the flow of chaos through you." : "You do not feel comfortable with your weapon.");
            }
            else if (Game.GetInventoryItem(InventorySlotEnum.MeleeWeapon) != null)
            {
                Game.MsgPrint("You feel comfortable with your weapon.");
            }
            else
            {
                Game.MsgPrint(Game.BaseCharacterClass.ID == CharacterClassEnum.Cultist ? "Chaos flows freely through you again." : "You feel more comfortable after removing your weapon.");
            }
        }
        if (Game.BaseCharacterClass.IsMartialArtist && MartialArtistArmorAux != MartialArtistNotifyAux) // TODO: This should be moved to the wield action
        {
            Game.MsgPrint(Game.MartialArtistHeavyArmor() ? "The weight of your armor disrupts your balance." : "You regain your balance.");
            MartialArtistNotifyAux = MartialArtistArmorAux;
        }
    }
}
