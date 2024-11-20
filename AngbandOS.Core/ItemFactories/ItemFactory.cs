// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

/// <summary>
/// Represents different variations (ItemType) of item categories (ItemCategory).  E.g. different types of food that belong to the food category.  Several of the
/// properties are modifiable.
/// </summary>
[Serializable]
internal abstract class ItemFactory : ItemAdditiveBundle
{
    #region Constructors
    protected ItemFactory(Game game) : base(game) { }
    #endregion

    #region State Data - Read/write fields.
    /// <summary>
    /// Returns true, if the flavor for the factory has been identified or the factory doesn't use flavors; false, when the factory uses flavors and
    /// the flavor still hasn't been identified by the player.  The <see cref="Game.FlavorInit"/> method is used to re-initialize this variable.  Stores may produce items from this
    /// factory and identify them; even though the Factory flavor still has not been identified.
    /// </summary>
    public bool IsFlavorAware;

    /// <summary>
    /// Returns the character that is used to display items of this type.  This character is initially set from the BaseItemCategory, but item categories
    /// that have flavor may override this character and replace it with a different character from the flavor.
    /// </summary>
    [Obsolete("This property is available via the IFlavor.Flavor property.")]
    public Symbol FlavorSymbol;

    /// <summary>
    /// Returns the color to be used for items of this type.  This color is initially set from the BaseItemCategory, but item categories
    /// that have flavor may override this color and replace it with a different color from the flavor.
    /// </summary>
    [Obsolete("This property is available via the IFlavor.Flavor property.")]
    public ColorEnum FlavorColor;

    /// <summary>
    /// Returns the flavor that was issued to the item factory.
    /// </summary>
    public Flavor? Flavor;

    /// <summary>
    /// Returns true, if the player has attempted/tried the item.
    /// </summary>
    public bool Tried;

    /// <summary>
    /// Returns true, if items of this type are stompable (based on the known "feeling" of (Broken, Average, Good & Excellent)).
    /// Use StompableType enum to address each index.
    /// </summary>
    public readonly bool[] Stompable = new bool[4];
    #endregion

    #region Cached Data - Non-binding properties that are set once, considered read-only and used for performance.
    /// <summary>
    /// Returns the CodedName value to render the item descriptions.  
    /// </summary>
    private string _descriptionSyntax;

    /// <summary>
    /// Returns the AlternateCodedName value to render for item descriptions.
    /// </summary>
    private string _alternateDescriptionSyntax;
    private string _flavorSuppressedDescriptionSyntax;
    private string _alternateFlavorSuppressedDescriptionSyntax;
    private string _flavorUnknownDescriptionSyntax;
    private string _alternateFlavorUnknownDescriptionSyntax;

    public int BookIndex { get; private set; } // TODO: Can this be done during binding?

    /// <summary>
    /// Returns the singleton realm that this book factory belongs to.  This is needed because realms define books--books do not define what realm they belong to.
    /// For this reason, the Realm the book belongs to is set at run-time.
    /// </summary>
    public Realm Realm { get; private set; } // TODO: Can this be done during binding?
    #endregion

    #region Concrete Methods and Properties (Non-abstract and non-virtual) - API Object Functionality
    public void Refill(Item item)
    {
        if (RefillScript == null)
        {
            Game.MsgPrint("Your light cannot be refilled.");
            return;
        }
        RefillScript.ExecuteScriptItem(item);
    }

    /// <summary>
    /// Processes a world turn for an item that is on the dungeon floor.  Does nothing, by default.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="gridTile"></param>
    public void GridProcessWorld(Item item, GridTile gridTile)
    {
        GridProcessWorldScript?.ExecuteScriptItemGridTile(item, gridTile);
        ProcessWorld(item);
    }

    public void SetBookIndex(Realm realm, int bookIndex) // TODO: Can this be done during binding?
    {
        BookIndex = bookIndex;
        Realm = realm;
    }

    /// <summary>
    /// Processes the world turn for an item being held by a monster.  Does nothing, by default.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="monster"></param>
    public void MonsterProcessWorld(Item item, Monster monster)
    {
        MonsterProcessWorldScript?.ExecuteScriptItemMonster(item, monster);
        ProcessWorld(item);
    }

    /// <summary>
    /// Hook into the ProcessWorld, when the item is being carried in a pack inventory slot.  Does nothing, by default..
    /// </summary>
    /// <param name="game"></param>
    public void PackProcessWorld(Item item)
    {
        PackProcessWorldScript?.ExecuteScriptItem(item);
        ProcessWorld(item);
    }

    /// <summary>
    /// Processes the world turn, when the item is being worn/wielded.  Does nothing, by default.  Gemstones of light drain from the player.
    /// </summary>
    /// <param name="game"></param>
    public void EquipmentProcessWorld(Item item)
    {
        EquipmentProcessWorldScript?.ExecuteScriptItem(item);
        ProcessWorld(item);
    }

    public override void Bind()
    {
        Symbol = Game.SingletonRepository.Get<Symbol>(SymbolBindingKey);
        ItemClass = Game.SingletonRepository.Get<ItemClass>(ItemClassBindingKey);
        FlavorSymbol = Symbol;
        FlavorColor = Color;

        BaseWieldSlots = Game.SingletonRepository.Get<BaseInventorySlot>(BaseWieldSlotBindingKeys);

        // Bind the MassProduceTuples
        if (MassProduceBindingTuples != null)
        {
            List<(int, Roll)> massProduceTuplesList = new List<(int, Roll)>();
            foreach ((int cost, string rollExpression) in MassProduceBindingTuples)
            {
                (int, Roll) newTuple = (cost, Game.ParseRollExpression(rollExpression));
                massProduceTuplesList.Add(newTuple);
            }
            MassProduceTuples = massProduceTuplesList.ToArray();

            // Validate the MassProduceTuples sorting.
            if (!Game.ValidateTupleSorting<(int cost, Roll roll)>(MassProduceTuples, (a, b) => a.cost < b.cost))
            {
                throw new Exception($"The MassProduceTupleNames specified for the {GetType().Name} are not sorted in ascending order by cost.");
            }
        }

        InitialGoldPiecesRoll = Game.ParseRollExpression(InitialGoldPiecesRollExpression);
        EatScript = Game.SingletonRepository.GetNullable<IIdentifableScript>(EatScriptBindingKey);

        // If there is no DescriptionSyntax, use the Name as the default.
        _descriptionSyntax = DescriptionSyntax != null ? DescriptionSyntax : Name;

        // If there is no AlternateDescriptionSyntax, use the DescriptionSyntax as the default.
        _alternateDescriptionSyntax = AlternateDescriptionSyntax != null ? AlternateDescriptionSyntax : _descriptionSyntax;

        // Flavored items that are still unknown will default to using the flavorless syntaxes.
        _flavorUnknownDescriptionSyntax = FlavorUnknownDescriptionSyntax != null ? FlavorUnknownDescriptionSyntax : _descriptionSyntax;
        _alternateFlavorUnknownDescriptionSyntax = AlternateFlavorUnknownDescriptionSyntax != null ? AlternateFlavorUnknownDescriptionSyntax : _flavorUnknownDescriptionSyntax;

        _flavorSuppressedDescriptionSyntax = FlavorSuppressedDescriptionSyntax != null ? FlavorSuppressedDescriptionSyntax : _descriptionSyntax;
        _alternateFlavorSuppressedDescriptionSyntax = AlternateFlavorSuppressedDescriptionSyntax != null ? AlternateFlavorSuppressedDescriptionSyntax : _flavorSuppressedDescriptionSyntax;

        // Bind Wands
        if (AimingBindingTuple != null)
        {
            IIdentifableDirectionalScript identifableDirectionalScript = Game.SingletonRepository.Get<IIdentifableDirectionalScript>(AimingBindingTuple.Value.ActivationScriptName);
            Roll initialChargeCountRoll = Game.ParseRollExpression(AimingBindingTuple.Value.InitialChargesCountRollExpression);
            int perChargeValue = AimingBindingTuple.Value.PerChargeValue;
            int manaValue = AimingBindingTuple.Value.ManaValue;
            AimingTuple = (identifableDirectionalScript, initialChargeCountRoll, perChargeValue, manaValue);
        }

        if (ActivationBindingTuple != null)
        {
            IIdentifableAndUsedScript identifableAndUsedScript = Game.SingletonRepository.Get<IIdentifableAndUsedScript>(ActivationBindingTuple.Value.ScriptName);
            int manaValue = ActivationBindingTuple.Value.ManaValue;
            ActivationTuple = (identifableAndUsedScript, manaValue);
        }

        RechargeScript = Game.SingletonRepository.GetNullable<IScriptItemInt>(RechargeScriptBindingKey);
        GridProcessWorldScript = Game.SingletonRepository.GetNullable<IScriptItemGridTile>(GridProcessWorldScriptBindingKey);
        MonsterProcessWorldScript = Game.SingletonRepository.GetNullable<IScriptItemMonster>(MonsterProcessWorldScriptBindingKey);
        EquipmentProcessWorldScript = Game.SingletonRepository.GetNullable<IScriptItem>(EquipmentProcessWorldScriptBindingKey);
        PackProcessWorldScript = Game.SingletonRepository.GetNullable<IScriptItem>(PackProcessWorldScriptBindingKey);

        EatMagicScript = Game.SingletonRepository.GetNullable<IScriptItem>(EatMagicScriptBindingKey);

        if (ZapBindingTuple != null)
        {
            IIdentifiedAndUsedScriptItemDirection identifiedAndUsedScriptItemDirection = Game.SingletonRepository.Get<IIdentifiedAndUsedScriptItemDirection>(ZapBindingTuple.Value.ScriptName);
            Roll roll = Game.ParseRollExpression(ZapBindingTuple.Value.TurnsToRecharge);
            bool requiresAiming = ZapBindingTuple.Value.RequiresAiming;
            int manaEquivalent = ZapBindingTuple.Value.ManaEquivalent;
            ZapTuple = (identifiedAndUsedScriptItemDirection, roll, requiresAiming, manaEquivalent);
        }

        AmmunitionItemFactories = Game.SingletonRepository.GetNullable<ItemFactory>(AmmunitionItemFactoryBindingKeys);

        if (QuaffBindingTuple != null)
        {
            INoticeableScript quaffNoticeableScript = Game.SingletonRepository.Get<INoticeableScript>(QuaffBindingTuple.Value.QuaffScriptName);
            IUnfriendlyScript? smashUnfriendlyScript = Game.SingletonRepository.GetNullable<IUnfriendlyScript>(QuaffBindingTuple.Value.SmashScriptName);
            int manaEquivalent = QuaffBindingTuple.Value.ManaEquivalent;
            QuaffTuple = (quaffNoticeableScript, smashUnfriendlyScript, manaEquivalent);
        }

        if (UseBindingTuple != null)
        {
            IIdentifableAndUsedScript useScript = Game.SingletonRepository.Get<IIdentifableAndUsedScript>(UseBindingTuple.Value.UseScriptBindingKey);
            Roll initialChargeRoll = Game.ParseRollExpression(UseBindingTuple.Value.InitialChargesRollExpression);
            int chargeValue = UseBindingTuple.Value.PerChargeValue;
            int manaEquivalent = UseBindingTuple.Value.ManaEquivalent;
            UseTuple = (useScript, initialChargeRoll, chargeValue, manaEquivalent);
        }

        Spells = Game.SingletonRepository.GetNullable<Spell>(SpellBindingKeys);
        BreaksDuringEnchantmentProbability = Game.ParseNullableProbabilityExpression(BreaksDuringEnchantmentProbabilityExpression);

        if (EnchantmentBindingTuples != null)
        {
            List<(int[]?, bool?, IEnhancementScript[])> enchantmentsList = new List<(int[]?, bool?, IEnhancementScript[])>();
            foreach ((int[]? Powers, bool? StoreStock, string[] ScriptNames) in EnchantmentBindingTuples)
            {
                if (ScriptNames.Length == 0)
                {
                    throw new Exception($"The {Name} item factory specifies an enchantment that contains no enchantment scripts.");
                }
                IEnhancementScript[] scripts = Game.SingletonRepository.Get<IEnhancementScript>(ScriptNames);
                enchantmentsList.Add((Powers, StoreStock, scripts));
            }
            EnchantmentTuples = enchantmentsList.ToArray();
        }

        RefillScript = Game.SingletonRepository.GetNullable<IScriptItem>(RefillScriptBindingKey);
    }

    /// <summary>
    /// Returns the number of additional items to be produced, when the item is mass produced for a store.  Returns 0, by default.  When an item
    /// is created for stores, this mass produce count can be used to create additional stores of the item based on the value of the item.  An item
    /// with a high value may not produce as many as other items of lower value.  This property is bound using the <see cref="MassProduceBindingTuples"/> property during
    /// the bind phase.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int GetAdditionalMassProduceCount(Item item)
    {
        // Rare items will not mass produce.
        if (item.RareItem != null)
        {
            return 0;
        }

        // Determine the cost of the item.
        int itemCost = item.Value();

        // Get the Random to be used.
        Random random = Game.UseRandom;

        if (MassProduceTuples != null)
        {
            foreach ((int cost, Roll roll) in MassProduceTuples)
            {
                if (itemCost <= cost)
                {
                    return roll.Get(random);
                }
            }
        }
        return 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="game"></param>
    /// <param name="who"></param>
    /// <param name="y"></param>
    /// <param name="x"></param>
    public bool Smash(int who, int y, int x)
    {
        if (QuaffTuple == null)
        {
            throw new Exception("Smash is not supported for a non-potion.");
        }
        IUnfriendlyScript? smashUnfriendlyScript = QuaffTuple.Value.SmashScript;
        if (smashUnfriendlyScript == null)
        {
            return false;
        }
        return smashUnfriendlyScript.ExecuteUnfriendlyScript(who, y, x);
    }

    /// <summary>
    /// Returns an additional description of the item that is appended to the base description, when needed.  Returns string.empty by default.
    /// </summary>
    /// <returns></returns>
    public string GetDetailedDescription(Item item)
    {
        string s = "";
        if (IsRangedWeapon)
        {
            int power = MissileDamageMultiplier;
            if (XtraMight)
            {
                power++;
            }
            s += $" (x{power})";

            if (item.IsKnown())
            {
                s += $" ({GetSignedValue(item.BonusHit)},{GetSignedValue(item.BonusDamage)})";

                if (item.ArmorClass != 0)
                {
                    // Add base armor class for all types of armor and when the base armor class is greater than zero.
                    s += $" [{item.ArmorClass},{GetSignedValue(item.BonusArmorClass)}]";
                }
                else if (item.BonusArmorClass != 0)
                {
                    // This is not armor, only show bonus armor class, if it is not zero and we know about it.
                    s += $" [{GetSignedValue(item.BonusArmorClass)}]";
                }
            }
            else if (item.ArmorClass != 0)
            {
                s += $" [{item.ArmorClass}]";
            }
        }
        else if (IsWeapon)
        {
            s += $" ({item.DamageDice}d{item.DamageSides})";

            if (item.IsKnown())
            {
                s += $" ({GetSignedValue(item.BonusHit)},{GetSignedValue(item.BonusDamage)})";

                if (item.ArmorClass != 0)
                {
                    // Add base armor class for all types of armor and when the base armor class is greater than zero.
                    s += $" [{item.ArmorClass},{GetSignedValue(item.BonusArmorClass)}]";
                }
                else if (item.BonusArmorClass != 0)
                {
                    // This is not armor, only show bonus armor class, if it is not zero and we know about it.
                    s += $" [{GetSignedValue(item.BonusArmorClass)}]";
                }
            }
            else if (item.ArmorClass != 0)
            {
                s += $" [{item.ArmorClass}]";
            }
        }
        else if (IsArmor)
        {
            if (item.IsKnown())
            {
                if (ShowMods || item.BonusHit != 0 && item.BonusDamage != 0)
                {
                    s += $" ({GetSignedValue(item.BonusHit)},{GetSignedValue(item.BonusDamage)})";
                }
                else if (item.BonusHit != 0)
                {
                    s += $" ({GetSignedValue(item.BonusHit)})";
                }
                else if (item.BonusDamage != 0)
                {
                    s += $" ({GetSignedValue(item.BonusDamage)})";
                }

                // Add base armor class for all types of armor and when the base armor class is greater than zero.
                s += $" [{item.ArmorClass},{GetSignedValue(item.BonusArmorClass)}]";
            }
            else if (item.ArmorClass != 0)
            {
                s += $" [{item.ArmorClass}]";
            }
        }
        else
        {
            if (item.IsKnown())
            {
                if (ShowMods || item.BonusHit != 0 && item.BonusDamage != 0)
                {
                    s += $" ({GetSignedValue(item.BonusHit)},{GetSignedValue(item.BonusDamage)})";
                }
                else if (item.BonusHit != 0)
                {
                    s += $" ({GetSignedValue(item.BonusHit)})";
                }
                else if (item.BonusDamage != 0)
                {
                    s += $" ({GetSignedValue(item.BonusDamage)})";
                }

                if (item.ArmorClass != 0)
                {
                    // Add base armor class for all types of armor and when the base armor class is greater than zero.
                    s += $" [{item.ArmorClass},{GetSignedValue(item.BonusArmorClass)}]";
                }
                else if (item.BonusArmorClass != 0)
                {
                    // This is not armor, only show bonus armor class, if it is not zero and we know about it.
                    s += $" [{GetSignedValue(item.BonusArmorClass)}]";
                }
            }
        }

        if (IsContainer && item.IsKnown())
        {
            if (item.ContainerIsOpen)
            {
                s += " (empty)";
            }
            else if (item.ContainerTraps == null)
            {
                s += " (unlocked)";
            }
            else if (item.ContainerTraps.Length == 0)
            {
                s += " (locked)";
            }
            else if (item.ContainerTraps.Length > 1)
            {
                s += " (multiple traps)";
            }
            else
            {
                s += $" {item.ContainerTraps[0].Description}";
            }
        }
        return s;
    }

    /// <summary>
    /// Returns an additional description of the item that is appended to the detailed description, when needed.  
    /// By default, empty is returned, if the item is known; otherwise, the HideType, Speed, Blows, Stealth, Search, Infra, Tunnel and recharging time characteristics are returned.
    /// </summary>
    /// <returns></returns>
    public string GetVerboseDescription(Item item)
    {
        string s = "";
        if (item.IsKnown() && AimingBindingTuple != null)
        {
            s += $" ({item.WandChargesRemaining} {Game.Pluralize("charge", item.WandChargesRemaining)})";
        }

        if (BurnRate > 0)
        {
            s += $" (with {item.TurnsOfLightRemaining} {Game.Pluralize("turn", item.TurnsOfLightRemaining)} of light)";
        }

        if (item.IsKnown())
        {
            (int bonusValue, string priorityBonusName)? commonBonusValue = CommonBonusValue(item);
            if (commonBonusValue.HasValue && commonBonusValue.Value.bonusValue != 0)
            {
                s += $" ({GetSignedValue(commonBonusValue.Value.bonusValue)}";
                if (!HideType && commonBonusValue.Value.priorityBonusName != "")
                {
                    s += $" {commonBonusValue.Value.priorityBonusName}";
                }
                s += ")";
            }
        }
        if (item.IsKnown() && item.ActivationRechargeTimeRemaining != 0)
        {
            s += " (charging)";
        }

        if (item.IsKnown() && item.RodRechargeTimeRemaining != 0)
        {
            s += $" (charging)";
        }

        if (item.IsKnown() && UseTuple != null)
        {
            s += $" ({item.StaffChargesRemaining} {Game.Pluralize("charge", item.StaffChargesRemaining)})";
        }
        return s;
    }

    private (int bonusValue, string priorityBonusName)? CommonBonusValue(Item item)
    {
        (int bonusValue, string priorityBonusName)? value = null;
        if (item.BonusSpeed != 0)
        {
            if (value.HasValue && item.BonusSpeed != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.BonusSpeed, "speed");
        }
        if (item.BonusAttacks != 0)
        {
            if (value.HasValue && item.BonusAttacks != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.BonusAttacks, item.BonusAttacks > 1 ? "attacks" : "attack");
        }
        if (item.BonusStealth != 0)
        {
            if (value.HasValue && item.BonusStealth != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.BonusStealth, "stealth");
        }
        if (item.BonusSearch != 0)
        {
            if (value.HasValue && item.BonusSearch != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.BonusSearch, "searching");
        }
        if (item.BonusInfravision != 0)
        {
            if (value.HasValue && item.BonusInfravision != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.BonusInfravision, "infravision");
        }
        if (item.BonusCharisma != 0)
        {
            if (value.HasValue && item.BonusCharisma != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.BonusCharisma, "");
        }
        if (item.BonusConstitution != 0)
        {
            if (value.HasValue && item.BonusConstitution != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.BonusConstitution, "");
        }
        if (item.BonusDexterity != 0)
        {
            if (value.HasValue && item.BonusDexterity != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.BonusDexterity, "");
        }
        if (item.BonusIntelligence != 0)
        {
            if (value.HasValue && item.BonusIntelligence != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.BonusIntelligence, "");
        }
        if (item.BonusStrength != 0)
        {
            if (value.HasValue && item.BonusStrength != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.BonusStrength, "");
        }
        if (item.BonusWisdom != 0)
        {
            if (value.HasValue && item.BonusWisdom != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.BonusWisdom, "");
        }
        if (item.BonusTunnel != 0)
        {
            if (value.HasValue && item.BonusTunnel != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.BonusTunnel, "");
        }
        if (!value.HasValue)
        {
            return (0, "");
        }
        return (value.Value);
    }

    private string ApplyPlurizationMacro(string name, int count)
    {
        int pos = name.IndexOf("~");
        if (pos >= 0)
        {
            return $"{Game.Pluralize(name.Substring(0, pos), count)}{name.Substring(pos + 1)}";
        }
        else
        {
            return name;
        }
    }

    /// <summary>
    /// Gets an additional bonus gold real value associated with the item.  Returns 0, by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int GetBonusRealValue(Item item)
    {
        int bonusValue = item.BonusHit * BonusHitRealValueMultiplier + item.BonusArmorClass * BonusArmorClassRealValueMultiplier + item.BonusDamage * BonusDamageRealValueMultiplier;
        if (item.DamageDice > DamageDice && item.DamageSides == DamageSides)
        {
            bonusValue += (item.DamageDice - DamageDice) * item.DamageSides * BonusDiceRealValueMultiplier;
        }
        return bonusValue;
    }

    private void ProcessWorld(Item oPtr)
    {
        // Decrement a rod recharge time regardless of where the rod is.
        if (oPtr.RodRechargeTimeRemaining > 0)
        {
            oPtr.RodRechargeTimeRemaining--;
            if (oPtr.RodRechargeTimeRemaining == 0)
            {
                Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineFlaggedAction)).Set();
            }
        }
    }

    /// <summary>
    /// Returns the intensity of light that the object emits.  By default, returns the Radius from the merged characteristics.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public int CalculateTorch(Item item)
    {
        if (BurnRate > 0 && item.TurnsOfLightRemaining <= 0)
        {
            return 0;
        }
        ItemCharacteristics mergedCharacteristics = item.GetMergedCharacteristics();
        return mergedCharacteristics.Radius;
    }

    /// <summary>
    /// Returns a description for the item.  Returns a macro processed description, by default.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="includeCountPrefix">Specify true, to include the number of items as the prefix; false, to excluse the count.  Pluralization will still
    /// occur when the count is not included.</param>
    /// <returns></returns>
    public string GetDescription(Item item, bool includeCountPrefix)
    {
        string descriptionSyntax;

        // Check to see if this factory has flavors.
        if (ItemClass.HasFlavor)
        {
            // Check if this item flavor needs to be suppressed, is unknown or known.
            if (item.IdentityIsStoreBought)
            {
                // The item was bought from the store or if we need to suppress flavors because we are in a store.
                descriptionSyntax = Game.BaseCharacterClass.UseAlternateItemNames ? _alternateFlavorSuppressedDescriptionSyntax : _flavorSuppressedDescriptionSyntax;

                // This syntax is allowed to use the Name macro but not the Flavor macro.
                descriptionSyntax = descriptionSyntax.Replace("$Name$", Name, StringComparison.OrdinalIgnoreCase);
            }
            else if (!IsFlavorAware)
            {
                // The flavor for this item is still unknown.
                descriptionSyntax = Game.BaseCharacterClass.UseAlternateItemNames ? _alternateFlavorUnknownDescriptionSyntax : _flavorUnknownDescriptionSyntax;

                // This syntax is allowed to use the flavor macro.
                descriptionSyntax = descriptionSyntax.Replace("$Flavor$", Flavor.Name, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                // This item has a known flavor.
                descriptionSyntax = Game.BaseCharacterClass.UseAlternateItemNames ? _alternateDescriptionSyntax : _descriptionSyntax;

                // This syntax is allowed to use the name and flavor macros.
                descriptionSyntax = descriptionSyntax.Replace("$Name$", Name, StringComparison.OrdinalIgnoreCase);
                descriptionSyntax = descriptionSyntax.Replace("$Flavor$", Flavor.Name, StringComparison.OrdinalIgnoreCase);
            }
        }
        else
        {
            // This item is flavorless.
            descriptionSyntax = Game.BaseCharacterClass.UseAlternateItemNames ? _alternateDescriptionSyntax : _descriptionSyntax;

            // This syntax is allowed to use the name macro.
            descriptionSyntax = descriptionSyntax.Replace("$Name$", Name, StringComparison.OrdinalIgnoreCase);
        }
        string pluralizedName = ApplyPlurizationMacro(descriptionSyntax, item.Count);

        if (!includeCountPrefix)
        {
            return pluralizedName;
        }

        if (item.Count <= 0)
        {
            return $"no more {pluralizedName}";
        }
        else if (item.Count > 1)
        {
            return $"{item.Count} {pluralizedName}";
        }
        else if (item.IsKnownArtifact)
        {
            return $"The {pluralizedName}";
        }
        else
        {
            if (pluralizedName[0].IsVowel())
            {
                return $"an {pluralizedName}";
            }
            else
            {
                return $"a {pluralizedName}";
            }
        }
    }

    /// <summary>
    /// Returns true, if the item is a scroll.
    /// </summary>
    public bool CanBeRead => ActivationTuple != null;

    public void CreateRandomArtifact(RandomArtifactCharacteristics characteristics, bool fromScroll)
    {
        int EnchantBonus(int bonus)
        {
            do
            {
                bonus++;
            } while (bonus < Game.DieRoll(5) || Game.DieRoll(bonus) == 1);
            if (bonus > 4 && Game.DieRoll(Constants.WeirdLuck) != 1)
            {
                bonus = 4;
            }
            return bonus;
        }

        void ApplyRandomBonuses(RandomArtifactCharacteristics characteristics)
        {
            if (characteristics.ArtifactBias != null)
            {
                if (characteristics.ArtifactBias.ApplyRandomArtifactBonuses(characteristics))
                {
                    return;
                }
            }
            switch (Game.DieRoll(23))
            {
                case 1:
                case 2:
                    characteristics.Str = true;
                    characteristics.BonusStrength = EnchantBonus(characteristics.BonusStrength);
                    if (characteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(StrengthArtifactBias));
                    }
                    else if (characteristics.ArtifactBias == null && Game.DieRoll(7) == 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WarriorArtifactBias));
                    }
                    break;

                case 3:
                case 4:
                    characteristics.Int = true;
                    characteristics.BonusIntelligence = EnchantBonus(characteristics.BonusIntelligence);
                    if (characteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(IntelligenceArtifactBias));
                    }
                    else if (characteristics.ArtifactBias == null && Game.DieRoll(7) == 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(MageArtifactBias));
                    }
                    break;

                case 5:
                case 6:
                    characteristics.Wis = true;
                    characteristics.BonusWisdom = EnchantBonus(characteristics.BonusWisdom);
                    if (characteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WisdomArtifactBias));
                    }
                    else if (characteristics.ArtifactBias == null && Game.DieRoll(7) == 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
                    }
                    break;

                case 7:
                case 8:
                    characteristics.Dex = true;
                    characteristics.BonusDexterity = EnchantBonus(characteristics.BonusDexterity);
                    if (characteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(DexterityArtifactBias));
                    }
                    else if (characteristics.ArtifactBias == null && Game.DieRoll(7) == 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RogueArtifactBias));
                    }
                    break;

                case 9:
                case 10:
                    characteristics.Con = true;
                    characteristics.BonusConstitution = EnchantBonus(characteristics.BonusConstitution);
                    if (characteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(ConstitutionArtifactBias));
                    }
                    else if (characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RangerArtifactBias));
                    }
                    break;

                case 11:
                case 12:
                    characteristics.Cha = true;
                    characteristics.BonusCharisma = EnchantBonus(characteristics.BonusCharisma);
                    if (characteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(CharismaArtifactBias));
                    }
                    break;

                case 13:
                case 14:
                    characteristics.Stealth = true;
                    characteristics.BonusStealth = EnchantBonus(characteristics.BonusStealth);
                    if (characteristics.ArtifactBias == null && Game.DieRoll(3) == 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RogueArtifactBias));
                    }
                    break;

                case 15:
                case 16:
                    characteristics.Search = true;
                    characteristics.BonusSearch = EnchantBonus(characteristics.BonusSearch);
                    if (characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RangerArtifactBias));
                    }
                    break;

                case 17:
                case 18:
                    characteristics.Infra = true;
                    characteristics.BonusInfravision = EnchantBonus(characteristics.BonusInfravision);
                    break;

                case 19:
                    characteristics.Speed = true;
                    characteristics.BonusSpeed = EnchantBonus(characteristics.BonusSpeed);
                    if (characteristics.ArtifactBias == null && Game.DieRoll(11) == 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RogueArtifactBias));
                    }
                    break;

                case 20:
                case 21:
                    characteristics.Tunnel = true;
                    characteristics.BonusTunnel = EnchantBonus(characteristics.BonusTunnel);
                    break;

                case 22:
                case 23:
                    if (characteristics.CanApplyBlowsBonus)
                    {
                        ApplyRandomBonuses(characteristics);
                    }
                    else
                    {
                        characteristics.Blows = true;
                        characteristics.BonusAttacks = Game.DieRoll(2) + 1;
                        if (characteristics.BonusAttacks > 4 && Game.DieRoll(Constants.WeirdLuck) != 1)
                        {
                            characteristics.BonusAttacks = 4;
                        }
                        if (characteristics.ArtifactBias == null && Game.DieRoll(11) == 1)
                        {
                            characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WarriorArtifactBias));
                        }
                    }
                    break;
            }
        }

        void CurseRandart(RandomArtifactCharacteristics characteristics)
        {
            if (characteristics.BonusStrength != 0)
            {
                characteristics.BonusStrength = 0 - (characteristics.BonusStrength + Game.DieRoll(4));
            }
            if (characteristics.BonusIntelligence != 0)
            {
                characteristics.BonusIntelligence = 0 - (characteristics.BonusIntelligence + Game.DieRoll(4));
            }
            if (characteristics.BonusWisdom != 0)
            {
                characteristics.BonusWisdom = 0 - (characteristics.BonusWisdom + Game.DieRoll(4));
            }
            if (characteristics.BonusDexterity != 0)
            {
                characteristics.BonusDexterity = 0 - (characteristics.BonusDexterity + Game.DieRoll(4));
            }
            if (characteristics.BonusConstitution != 0)
            {
                characteristics.BonusConstitution = 0 - (characteristics.BonusConstitution + Game.DieRoll(4));
            }
            if (characteristics.BonusCharisma != 0)
            {
                characteristics.BonusCharisma = 0 - (characteristics.BonusCharisma + Game.DieRoll(4));
            }
            if (characteristics.BonusStealth != 0)
            {
                characteristics.BonusStealth = 0 - (characteristics.BonusStealth + Game.DieRoll(4));
            }
            if (characteristics.BonusSearch != 0)
            {
                characteristics.BonusSearch = 0 - (characteristics.BonusSearch + Game.DieRoll(4));
            }
            if (characteristics.BonusInfravision != 0)
            {
                characteristics.BonusInfravision = 0 - (characteristics.BonusInfravision + Game.DieRoll(4));
            }
            if (characteristics.BonusTunnel != 0)
            {
                characteristics.BonusTunnel = 0 - (characteristics.BonusTunnel + Game.DieRoll(4));
            }
            if (characteristics.BonusAttacks != 0)
            {
                characteristics.BonusAttacks = 0 - (characteristics.BonusAttacks + Game.DieRoll(4));
            }
            if (characteristics.BonusSpeed != 0)
            {
                characteristics.BonusSpeed = 0 - (characteristics.BonusSpeed + Game.DieRoll(4));
            }
            if (characteristics.BonusArmorClass != 0)
            {
                characteristics.BonusArmorClass = 0 - (characteristics.BonusArmorClass + Game.DieRoll(4));
            }
            if (characteristics.BonusHit != 0)
            {
                characteristics.BonusHit = 0 - (characteristics.BonusHit + Game.DieRoll(4));
            }
            if (characteristics.BonusDamage != 0)
            {
                characteristics.BonusDamage = 0 - (characteristics.BonusDamage + Game.DieRoll(4));
            }
            characteristics.HeavyCurse = true;
            characteristics.IsCursed = true;
            if (Game.DieRoll(4) == 1)
            {
                characteristics.PermaCurse = true;
            }
            if (Game.DieRoll(3) == 1)
            {
                characteristics.DreadCurse = true;
            }
            if (Game.DieRoll(2) == 1)
            {
                characteristics.Aggravate = true;
            }
            if (Game.DieRoll(3) == 1)
            {
                characteristics.DrainExp = true;
            }
            if (Game.DieRoll(2) == 1)
            {
                characteristics.Teleport = true;
            }
            else if (Game.DieRoll(3) == 1)
            {
                characteristics.NoTele = true;
            }
            if (Game.BaseCharacterClass.ID != CharacterClass.Warrior && Game.DieRoll(3) == 1)
            {
                characteristics.NoMagic = true;
            }
            characteristics.IsCursed = true;
        }

        void ApplyMiscPowerForRandomArtifactCreation(RandomArtifactCharacteristics characteristics)
        {
            if (characteristics.ArtifactBias != null)
            {
                characteristics.ArtifactBias.ApplyMiscPowers(characteristics);
            }
            switch (Game.DieRoll(31))
            {
                case 1:
                    characteristics.SustStr = true;
                    if (characteristics.ArtifactBias == null)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(StrengthArtifactBias));
                    }
                    break;

                case 2:
                    characteristics.SustInt = true;
                    if (characteristics.ArtifactBias == null)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(IntelligenceArtifactBias));
                    }
                    break;

                case 3:
                    characteristics.SustWis = true;
                    if (characteristics.ArtifactBias == null)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WisdomArtifactBias));
                    }
                    break;

                case 4:
                    characteristics.SustDex = true;
                    if (characteristics.ArtifactBias == null)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(DexterityArtifactBias));
                    }
                    break;

                case 5:
                    characteristics.SustCon = true;
                    if (characteristics.ArtifactBias == null)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(ConstitutionArtifactBias));
                    }
                    break;

                case 6:
                    characteristics.SustCha = true;
                    if (characteristics.ArtifactBias == null)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(CharismaArtifactBias));
                    }
                    break;

                case 7:
                case 8:
                case 14:
                    characteristics.FreeAct = true;
                    break;

                case 9:
                    characteristics.HoldLife = true;
                    if (characteristics.ArtifactBias == null && Game.DieRoll(5) == 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
                    }
                    else if (characteristics.ArtifactBias == null && Game.DieRoll(6) == 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(NecromanticArtifactBias));
                    }
                    break;

                case 10:
                case 11:
                    characteristics.Radius = 3;
                    break;

                case 12:
                case 13:
                    characteristics.Feather = true;
                    break;

                case 15:
                case 16:
                case 17:
                    characteristics.SeeInvis = true;
                    break;

                case 18:
                    characteristics.Telepathy = true;
                    if (characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(MageArtifactBias));
                    }
                    break;

                case 19:
                case 20:
                    characteristics.SlowDigest = true;
                    break;

                case 21:
                case 22:
                    characteristics.Regen = true;
                    break;

                case 23:
                    characteristics.Teleport = true;
                    break;

                case 24:
                case 25:
                case 26:
                    if (!characteristics.CanApplyBonusArmorClassMiscPower)
                    {
                        // This item cannot have misc power, select a different
                        ApplyMiscPowerForRandomArtifactCreation(characteristics);
                    }
                    else
                    {
                        characteristics.ShowMods = true;
                        characteristics.BonusArmorClass = 4 + Game.DieRoll(11);
                    }
                    break;

                case 27:
                case 28:
                case 29:
                    characteristics.ShowMods = true;
                    characteristics.BonusHit += 4 + Game.DieRoll(11);
                    characteristics.BonusDamage += 4 + Game.DieRoll(11);
                    break;

                case 30:
                    characteristics.NoMagic = true;
                    break;

                case 31:
                    characteristics.NoTele = true;
                    break;
            }
        }

        const int ArtifactCurseChance = 13;
        int powers = Game.DieRoll(5) + 1;
        bool aCursed = false;
        int warriorArtifactBias = 0;
        if (fromScroll && Game.DieRoll(4) == 1)
        {
            characteristics.ArtifactBias = Game.BaseCharacterClass.ArtifactBias;
            warriorArtifactBias = Game.BaseCharacterClass.FromScrollWarriorArtifactBiasPercentageChance;
        }
        if (Game.DieRoll(100) <= warriorArtifactBias && fromScroll)
        {
            characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WarriorArtifactBias));
        }
        if (!fromScroll && Game.DieRoll(ArtifactCurseChance) == 1)
        {
            aCursed = true;
        }
        while (Game.DieRoll(powers) == 1 || Game.DieRoll(7) == 1 || Game.DieRoll(10) == 1)
        {
            powers++;
        }
        if (!aCursed && Game.DieRoll(Constants.WeirdLuck) == 1)
        {
            powers *= 2;
        }
        if (aCursed)
        {
            powers /= 2;
        }
        while (powers-- != 0)
        {
            int maxType = (characteristics.CanApplySlayingBonus ? 7 : 5);
            switch (Game.DieRoll(maxType))
            {
                case 1:
                case 2:
                    ApplyRandomBonuses(characteristics);
                    break;
                case 3:
                case 4:
                    if (characteristics.ArtifactBias != null)
                    {
                        characteristics.ArtifactBias.ApplyRandomResistances(characteristics);
                    }
                    else
                    {
                        WeightedRandom<ItemAdditiveBundle> itemAdditiveBundleWeightedRandom = new WeightedRandom<ItemAdditiveBundle>(Game);
                        itemAdditiveBundleWeightedRandom.Add(1 * 48, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(AcidImmunityItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(1 * 48, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ElectricityImmunityItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(1 * 48, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ColdImmunityItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(1 * 48, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(FireImmunityItemAdditiveBundle)));

                        itemAdditiveBundleWeightedRandom.Add(3 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistAcidAndAcidBiasItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(3 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistElectricityAndElectricityBiasItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(3 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistFireAndFireBiasItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(3 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistColdAndColdBiasItemAdditiveBundle)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 36 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistPoisonAndPoisonBiasItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 6 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistPoisonAndNecromanticBiasItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 3 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistPoisonAndRogueBiasItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 3, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistPoisonItemAdditiveBundle)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 16 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistFearAndWarriorBiasItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 32 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistFearItemAdditiveBundle)));

                        itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistLightItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistDarknessItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistBlindnessItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistBlindnessItemAdditiveBundle)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 8 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistConfusionAndChaosBiasItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 40 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistConfusionItemAdditiveBundle)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistSoundItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistShardsItemAdditiveBundle)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 16 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistNetherAndNecromanticBiasItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 32 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistNetherItemAdditiveBundle)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistNexusItemAdditiveBundle)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 24 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistChaosAndChaosBiasItemAdditiveBundle)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 24 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistChaosItemAdditiveBundle)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ResistDisenchantItemAdditiveBundle)));

                        if (characteristics.CanProvideSheathOfElectricity)
                        {
                            itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(SheathOfElectricityAndElectricityBiasItemAdditiveBundle)));
                        }

                        if (characteristics.CanProvideSheathOfFire)
                        {
                            itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(SheathOfFireAndFireBiasItemAdditiveBundle)));
                        }

                        if (characteristics.CanReflectBoltsAndArrows)
                        {
                            itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ReflectBoltsAndArrowsItemAdditiveBundle)));
                        }

                        ItemAdditiveBundle? itemAdditiveBundle = itemAdditiveBundleWeightedRandom.ChooseOrDefault();
                        if (itemAdditiveBundle != null)
                        {
                            characteristics.Merge(itemAdditiveBundle.GenerateItemCharacteristics());
                        }
                    }
                    break;

                case 5:
                    ApplyMiscPowerForRandomArtifactCreation(characteristics);
                    break;

                case 6:
                case 7:
                    ApplySlayingForRandomArtifactCreation(characteristics);
                    break;

                default:
                    powers++;
                    break;
            }
        }
        if (RandomArtifactBonusArmorCeiling != null)
        {
            characteristics.BonusArmorClass += Game.DieRoll(characteristics.BonusArmorClass > RandomArtifactBonusArmorCeiling.Value ? 1 : RandomArtifactBonusArmorCeiling.Value + 1 - characteristics.BonusArmorClass);
        }
        if (RandomArtifactBonusHitCeiling != null)
        { 
            characteristics.BonusHit += Game.DieRoll(characteristics.BonusHit > RandomArtifactBonusHitCeiling.Value ? 1 : RandomArtifactBonusHitCeiling.Value + 1 - characteristics.BonusArmorClass);
        }
        if (RandomArtifactBonusDamageCeiling != null)
        {
            characteristics.BonusDamage += Game.DieRoll(characteristics.BonusDamage > RandomArtifactBonusDamageCeiling.Value ? 1 : RandomArtifactBonusDamageCeiling.Value + 1 - characteristics.BonusArmorClass);
        }

        characteristics.IgnoreAcid = true;
        characteristics.IgnoreElec = true;
        characteristics.IgnoreFire = true;
        characteristics.IgnoreCold = true;
        characteristics.TreasureRating = 40;

        if (aCursed)
        {
            CurseRandart(characteristics);
        }
        if (!aCursed && Game.DieRoll(RandartActivationChance) == 1)
        {
            characteristics.Activation = null;
            if (characteristics.ArtifactBias != null)
            {
                if (Game.DieRoll(100) < characteristics.ArtifactBias.ActivationPowerChance)
                {
                    characteristics.Activation = characteristics.ArtifactBias.GetActivationPowerType();
                }
            }
            if (characteristics.Activation == null)
            {
                characteristics.Activation = Game.SingletonRepository.Get<ActivationWeightedRandom>(nameof(RandomArtifactActivationWeightedRandom)).ChooseOrDefault();
            }
        }
    }
    #endregion

    #region Bound Concrete Properties - API Object Functionality - Set during Bind() - get; private set;
    /// <summary>
    /// Returns the script that is used to refill the item; or null, if the item cannot be refilled.  This property is bound using the <see cref="RefillScriptBindingKey"/> property during the binding
    /// phase.
    /// </summary>
    protected IScriptItem? RefillScript { get; private set; }

    /// <summary>
    /// Returns the symbol to use for rendering. This symbol will be initially used to set the <see cref="FlavorSymbol"/> and item
    /// categories that have flavor may change the FlavorCharacter based on the flavor.  This property is bound from the <see cref="SymbolBindingKey"/> property during the bind phase.
    /// </summary>
    public Symbol Symbol { get; private set; }

    /// <summary>
    /// Returns the noticeable script to run when the player uses an item; or null, if the item cannot be used.  This property is bound using the <see cref="UseBindingTuple"/>
    /// property during the bind phase.
    /// 
    /// Returns the number of staff charges that will be given to the item at item creation; or 0, if the item is not a staff.  0 is returns, by default.  This property is bound using the
    /// <see cref="StaffChargeCountRollExpression"/> property during the bind phase.
    /// 
    /// Returns the value of each staff charge.  Returns 0, by default.
    /// The amount of mana needed to consume to keep the charge.
    /// 
    /// </summary>
    public (IIdentifableAndUsedScript UseScript, Roll InitialCharges, int PerChargeValue, int ManaEquivalent)? UseTuple { get; private set; } = null;

    /// <summary>
    /// Returns the noticeable script to run when the player quaffs the potion; or null, if the item cannot be quaffed.  This property is bound using the <see cref="QuaffBindingTuple"/>
    /// property during the bind phase.
    /// 
    /// Perform a smash effect on the potion and returns true, if the effect causes pets to become unfriendly; false, otherwise.  Returns false, by default.
    /// 
    /// The amount of mana needed to consume to keep the potion.
    /// 
    /// </summary>
    public (INoticeableScript QuaffScript, IUnfriendlyScript? SmashScript, int ManaEquivalent)? QuaffTuple { get; private set; } = null;

    /// <summary>
    /// Returns the <see cref="ItemClass"/> that is used as ammunition for this item; or null, if the item is not a ranged weapon.  This property bound using
    /// the <see cref="AmmunitionItemFactoryBindingKeys"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    public ItemFactory[]? AmmunitionItemFactories { get; private set; } = null;

    /// <summary>
    /// Returns the activation script for wands when aimed, a Roll to determine the number of charges to assign to new wands and the value for each charge; or null, if the item cannot be aimed.  
    /// This property is bound from the <see cref="AimingBindingTuple"/> property during the bind phase.
    /// </summary>
    public (IIdentifableDirectionalScript ActivationScript, Roll InitialChargesCountRoll, int PerChargeValue, int ManaValue)? AimingTuple { get; private set; } = null;

    public IScriptItemInt? RechargeScript { get; private set; }

    public (int, Roll)[]? MassProduceTuples { get; private set; } = null;
    public Probability? BreaksDuringEnchantmentProbability { get; private set; }
    public (int[]? Powers, bool? StoreStock, IEnhancementScript[] Scripts)[]? EnchantmentTuples { get; private set; }

    /// <summary>
    /// Returns the the script to run, when the energy of a rechargeable item is consumed; or null, if the item does not have charges that can be consumed or those charges cannot be consumed.
    /// This property is bound using the <see cref="EatMagicScriptBindingKey"/> property during the bind phase.
    /// </summary>
    public IScriptItem? EatMagicScript { get; private set; }
    public IScriptItemGridTile? GridProcessWorldScript { get; private set; }
    public IScriptItemMonster? MonsterProcessWorldScript { get; private set; }
    public IScriptItem? EquipmentProcessWorldScript { get; private set; }
    public IScriptItem? PackProcessWorldScript { get; private set; }

    /// <summary>
    /// Returns the probability that an item that is thrown or fired will break.  This property is bound using the <see cref="BreakageChangeProbabilityExpression"/> property during the bind phase.
    /// </summary>
    public Probability BreakageChanceProbability { get; private set; }

    public (IIdentifiedAndUsedScriptItemDirection Script, Roll TurnsToRecharge, bool RequiresAiming, int ManaEquivalent)? ZapTuple { get; private set; } = null;
    public ItemClass ItemClass { get; private set; }

    /// <summary>
    /// Returns the inventory slots where the item can be wielded.  Items will be placed in the first wield slot that is available. Rings use multiple wield slots for left and right hands. 
    /// Returns the pack, by default.  This property is bound from the <see cref="BaseWieldSlotBindingKey"/> property during the binding phase.
    /// </summary>
    public BaseInventorySlot[] BaseWieldSlots { get; private set; }

    /// <summary>
    /// Returns a Roll that is used to determine the number of gold pieces that are given to the player when the item is picked up.  This property is bound from the
    /// <see cref="InitialGoldPiecesRollExpression"/> property during the bind phase.
    /// </summary>
    public Roll InitialGoldPiecesRoll { get; private set; }

    /// <summary>
    /// Returns the spells, in order, that belong to this book; or null, if the item is not a book.  This property is bound from the SpellNames property during the binding phase.
    /// </summary>
    public Spell[]? Spells { get; private set; }

    /// <summary>
    /// Returns the script to be run when an item of this factory is eaten; or null, if items cannot be eaten.  This property is bound from the <see cref="EatScriptBindingKey"/> property
    /// during the bind phase.
    /// </summary>
    public IIdentifableScript? EatScript { get; private set; }

    /// <summary>
    /// Returns the activation script for scrolls when read; or null, if the item cannot be read.  This property is bound from the <see cref="ActivationBindingTuple"/> property during the bind phase.
    /// </summary>
    public (IIdentifableAndUsedScript ActivationScript, int ManaValue)? ActivationTuple { get; private set; } = null;
    #endregion

    #region Heavy Weights and Obsoletes - Virtual Methods and Virtual Complex Properties that must be resolved

    public virtual void ApplySlayingForRandomArtifactCreation(RandomArtifactCharacteristics characteristics)
    {
        if (characteristics.ArtifactBias != null)
        {
            if (characteristics.ArtifactBias.ApplySlaying(characteristics))
            {
                return;
            }
        }

        switch (Game.DieRoll(34))
        {
            case 1:
            case 2:
                characteristics.SlayAnimal = true;
                break;

            case 3:
            case 4:
                characteristics.SlayEvil = true;
                if (characteristics.ArtifactBias == null && Game.DieRoll(2) == 1)
                {
                    characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(LawArtifactBias));
                }
                else if (characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                {
                    characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
                }
                break;

            case 5:
            case 6:
                characteristics.SlayUndead = true;
                if (characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                {
                    characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
                }
                break;

            case 7:
            case 8:
                characteristics.SlayDemon = true;
                if (characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                {
                    characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
                }
                break;

            case 9:
            case 10:
                characteristics.SlayOrc = true;
                break;

            case 11:
            case 12:
                characteristics.SlayTroll = true;
                break;

            case 13:
            case 14:
                characteristics.SlayGiant = true;
                break;

            case 15:
            case 16:
                characteristics.SlayDragon = true;
                break;

            case 17:
                characteristics.KillDragon = true;
                break;

            case 18:
            case 19:
                if (CanVorpalSlay)
                {
                    characteristics.Vorpal = true;
                    if (characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WarriorArtifactBias));
                    }
                }
                else
                {
                    // This item cannot have vorpal slaying applied, choose a different random slaying.
                    ApplySlayingForRandomArtifactCreation(characteristics);
                }
                break;

            case 20:
                characteristics.Impact = true;
                break;

            case 21:
            case 22:
                characteristics.BrandFire = true;
                if (characteristics.ArtifactBias == null)
                {
                    characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(FireArtifactBias));
                }
                break;

            case 23:
            case 24:
                characteristics.BrandCold = true;
                if (characteristics.ArtifactBias == null)
                {
                    characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(ColdArtifactBias));
                }
                break;

            case 25:
            case 26:
                characteristics.BrandElec = true;
                if (characteristics.ArtifactBias == null)
                {
                    characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(ElectricityArtifactBias));
                }
                break;

            case 27:
            case 28:
                characteristics.BrandAcid = true;
                if (characteristics.ArtifactBias == null)
                {
                    characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(AcidArtifactBias));
                }
                break;

            case 29:
            case 30:
                characteristics.BrandPois = true;
                if (characteristics.ArtifactBias == null && Game.DieRoll(3) != 1)
                {
                    characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PoisonArtifactBias));
                }
                else if (characteristics.ArtifactBias == null && Game.DieRoll(6) == 1)
                {
                    characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(NecromanticArtifactBias));
                }
                else if (characteristics.ArtifactBias == null)
                {
                    characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RogueArtifactBias));
                }
                break;

            case 31:
            case 32:
                characteristics.Vampiric = true;
                if (characteristics.ArtifactBias == null)
                {
                    characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(NecromanticArtifactBias));
                }
                break;

            default:
                characteristics.Chaotic = true;
                if (characteristics.ArtifactBias == null)
                {
                    characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(ChaosArtifactBias));
                }
                break;
        }
    }
    #endregion

    /// <summary>
    /// Returns the ceiling value for bonus armor values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    public virtual int? RandomArtifactBonusArmorCeiling => null;

    /// <summary>
    /// Returns the ceiling value for bonus hit values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    public virtual int? RandomArtifactBonusHitCeiling => null;

    /// <summary>
    /// Returns the ceiling value for bonus damage values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    public virtual int? RandomArtifactBonusDamageCeiling => null;

    #region Light-Weight Virtual and Abstract Properties - Action Hooks and Behavior Modifiers for Game Packs and Generic API Objects
    /// <summary>
    /// Returns the key of the script that is used to refill the item; or null, if the item cannot be refilled.  Returns null, by default.  This property is used to bind the <see cref="RefillScript"/>
    /// property during the binding phase.
    /// </summary>
    protected virtual string? RefillScriptBindingKey => null;

    /// <summary>
    /// Returns the symbol to use for rendering the item.  This symbol will be initially used to set the <see cref="FlavorSymol"/> and item catagories that have flavor may the change the
    /// <see cref="FlavorCharacter"/> based on the flavor.  This property is used to bind the <see cref="Symbol"/> property during the bind phase.
    /// </summary>
    protected abstract string SymbolBindingKey { get; }

    public virtual bool CanBeWeaponOfLaw => false;

    public virtual bool CanBeWeaponOfSharpness => false;

    public virtual bool CapableOfVorpalSlaying => false;

    /// <summary>
    /// Returns the color that items of this type should be rendered with.  This color will be initially used to set the <see cref="FlavorColor"/> and item categories
    /// that have flavor may change the FlavorColor based on the flavor.
    /// </summary>
    public virtual ColorEnum Color => ColorEnum.White;

    /// <summary>
    /// Returns the name of the noticeable script to run when the player uses the item ; or null if the potion does
    /// not have a smash effect; if the item can be quaffed; or null, if the item cannot be quaffed.  This property is used to bind the
    /// <see cref="UseTuple"/> property during the bind phase.  Returns null, by default.
    /// 
    /// Returns the roll expression used to determine the initial number of staff charges that will be given to the item at item creation; or null, if the item is not a staff.  null is returns, 
    /// by default.  This property is used to bind the <see cref="StaffChargeCount"/> property during the bind phase.
    ///     
    /// Returns the value of each staff charge.  Returns 0, by default.
    /// The amount of mana needed to consume to keep the potion.
    /// 
    /// </summary>
    protected virtual (string UseScriptBindingKey, string InitialChargesRollExpression, int PerChargeValue, int ManaEquivalent)? UseBindingTuple => null;

    /// <summary>
    /// Returns the name of the noticeable script to run when the player quaffs the potion and the name of the smash script when the player smashes the potion; or null if the potion does
    /// not have a smash effect; if the item can be quaffed; or null, if the item cannot be quaffed.  This property is used to bind the
    /// <see cref="QuaffTuple"/> property during the bind phase.  Returns null, by default.
    /// 
    /// Perform a smash effect on the potion and returns true, if the effect causes pets to become unfriendly; false, otherwise.  Returns false, by default.
    /// 
    /// The amount of mana needed to consume to keep the potion.
    /// 
    /// </summary>
    protected virtual (string QuaffScriptName, string? SmashScriptName, int ManaEquivalent)? QuaffBindingTuple => null;

    /// <summary>
    /// Returns the name of the <see cref="ItemClass"/> that is used as ammunition for this item; or null, if the item is not a ranged weapon.  This property is used to bind
    /// the <see cref="AmmunitionItemFactories"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    protected virtual string[]? AmmunitionItemFactoryBindingKeys => null;

    /// <summary>
    /// Returns true, if the item can be used to spike a door closed; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool CanSpikeDoorClosed => false;

    /// <summary>
    /// Returns true, if the item can be used to dig; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool CanTunnel => false;

    /// <summary>
    /// Returns true, if the item is a bow and can project arrows; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool CanProjectArrows => false;

    /// <summary>
    /// Returns the maximum number of items that can be enchanted at one time.  A value of 1 is returned, by default.  Ammunition items return 20.  Item counts greater than this value
    /// will have a decreased probability of enchantment.
    /// </summary>
    public virtual int EnchantmentMaximumCount => 1;

    /// <summary>
    /// Returns true, if the item is magical and is noticed with the detect magical scoll.
    /// </summary>
    public virtual bool IsMagical => false;

    /// <summary>
    /// Returns the value of each turn of light for light sources.  Returns 0, by default;
    /// </summary>
    public virtual int ValuePerTurnOfLight => 0;

    /// <summary>
    /// Returns the name of the activation script for wands when aimed, a roll expression to determine the number of charges to assign to new wands and the value of each charge; or null, if the 
    /// item cannot be aimed.  Returns null, by default.  This property is used to bind the <see cref="AimingTuple"/>  property during the bind phase.
    /// </summary>
    protected virtual (string ActivationScriptName, string InitialChargesCountRollExpression, int PerChargeValue, int ManaValue)? AimingBindingTuple => null;

    /// <summary>
    /// Returns true, if the item is broken; false, otherwise.  Broken items have no value and will be stomped.
    /// </summary>
    public virtual bool IsBroken => false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality that should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.  
    /// Returns false, by default.  Weapons, armor, orbs of light and broken items (items that negatively affect the player) return true.
    /// </summary>
    public virtual bool InitialBrokenStomp => false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    public virtual bool InitialAverageStomp => false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    public virtual bool InitialGoodStomp => false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    public virtual bool InitialExcellentStomp => false;

    protected virtual string? RechargeScriptBindingKey => null;

    /// <summary>
    /// Returns true, if the item is ignored by monsters.  Returns false for all items, except gold.  Gold isn't picked up by monsters.
    /// </summary>
    public virtual bool IsIgnoredByMonsters => false;

    /// <summary>
    /// Returns true, if the item is a container; false, otherwise.  Containers can be opened (ContainerIsOpen) and trapped (ContainerTraps).
    /// </summary>
    public virtual bool IsContainer => false;

    /// <summary>
    /// Returns true, if the item is a ranged weapon; false, otherwise.
    /// </summary>
    public virtual bool IsRangedWeapon => false;

    /// <summary>
    /// Returns a damage multiplier when the missile weapon is used.
    /// </summary>
    public virtual int MissileDamageMultiplier => 1;

    /// <summary>
    /// Returns the maximum fuel that can be used for phlogiston.  Returns null, by default, meaning that the light source cannot be used to create a phlogiston.
    /// </summary>
    public virtual int? MaxPhlogiston => null;

    /// <summary>
    /// Returns the number of turns of light that is consumed per turn.  Defaults to zero; which means there is no consumption and that the light source lasts forever.
    /// Torches and laterns have burn rates greater than zero.
    /// </summary>
    public virtual int BurnRate => 0;

    /// <summary>
    /// Returns an array of tuples that define the mass produce for items of this factory.  These tuples define a Roll that is applied for additional items to be produced
    /// for items of a cost value or less; or null, if no additional items should be produced based on any cost.  Returns null, by default.  This property is used
    /// to bind the <see cref="MassProduceTuples"/> property during the bind phase.  The tuples must be sorted by cost and are checked during the bind phase.
    /// </summary>
    protected virtual (int count, string rollExpression)[]? MassProduceBindingTuples => null;

    public virtual int BonusHitRealValueMultiplier => 100;
    public virtual int BonusDamageRealValueMultiplier => 100;
    public virtual int BonusArmorClassRealValueMultiplier => 100;
    public virtual int BonusDiceRealValueMultiplier => 100;

    protected virtual string? BreaksDuringEnchantmentProbabilityExpression => null;

    /// <summary>
    /// Returns the name of the IEnchantmentScript to run for enchanting items depending on the item power and whether the item is being sold in a store.
    /// </summary>
    /// <returns>
    /// Powers - One or more item power levels (-2, -1, 0, 1, 2) the enchantment applies to; or null, if the enchantments apply to all power levels./>
    /// StoreStock - True, when the enchantment applies only to items sold in a store; false, when the enchantment only applies to items not sold in a store; or null, if the enchantment applies regardless of whether the item is being sold in a store or not.;<para />
    /// ScriptNames - The names of one or more scripts that implement the IEnhancementScript interface to be run to enhance the item when the Powers and StoreStock criteria match.  An empty array will throw during binding.
    /// </returns>
    protected virtual (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => null;

    /// <summary>
    /// Returns the name of the script to run, when the energy of a rechargeable item is consumed; or null, if the item does not have charges that can be consumed or those charges cannot be consumed.
    /// This property is used to bind the <see cref="EatMagicScript"/> property during the bind phase.
    /// </summary>
    protected virtual string? EatMagicScriptBindingKey => null;

    protected virtual string? GridProcessWorldScriptBindingKey => null;
    protected virtual string? MonsterProcessWorldScriptBindingKey => null;
    protected virtual string? EquipmentProcessWorldScriptBindingKey => null;
    protected virtual string? PackProcessWorldScriptBindingKey => null;

    /// <summary>
    /// Returns true, if the item can apply a bonus armor class for miscellaneous power.  Only weapons return true.  Returns false, by default.
    /// </summary>
    public virtual bool CanApplyBonusArmorClassMiscPower => false;

    /// <summary>
    /// Returns true, if the item can apply a blows bonus.  Returns false, by default. Bows, return true.
    /// </summary>
    public virtual bool CanApplyBlowsBonus => false;

    /// <summary>
    /// Returns true, if the item is capable of vorpal slaying.  Only swords return true.  Returns false, by default.
    /// </summary>
    public virtual bool CanVorpalSlay => false;

    /// <summary>
    /// Returns an expression that represents the chance that an item that is thrown or fired will break.  Returns 10, or 10%, by default.  This
    /// property is used to bind the <see cref="BreakageChanceProbability"/> property during the bind phase.
    /// </summary>
    protected virtual string BreakageChanceProbabilityExpression => "10/100";

    /// <summary>
    /// Returns a count for the number of items to create during the MakeObject.  Returns 1, by default.  Spikes, shots, arrows and bolts return values greater than 1.
    /// </summary>
    public virtual int MakeObjectCount => 1;

    /// <summary>
    /// Returns true, if the item multiplies damages against a specific monster race.  Returns false, by default. Shots, arrows, bolts, hafted, polearms, swords and digging all return true.
    /// </summary>
    public virtual bool GetsDamageMultiplier => false;

    /// <summary>
    /// Returns true, if the item can be sensed; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool IdentityCanBeSensed => false;

    /// <summary>
    /// Returns true, if the item can be used as fuel for a torch.
    /// </summary>
    public virtual bool IsFuelForTorch => false;

    /// <summary>
    /// Returns true, if the item can be worn.
    /// </summary>
    public virtual bool IsWearableOrWieldable => false;

    /// <summary>
    /// Returns true, if the item can be eaten.
    /// </summary>
    public virtual bool CanBeEaten => false;

    /// <summary>
    /// Returns true, if the item is armor.
    /// </summary>
    public virtual bool IsArmor => false;

    /// <summary>
    /// Returns true, if the item is a weapon.
    /// </summary>
    public virtual bool IsWeapon => false;

    /// <summary>
    /// Returns the number of items contained in the chest; or 0, if the item is not a container.  Returns 0, by default.
    /// </summary>
    public virtual int NumberOfItemsContained => 0;

    /// <summary>
    /// Returns the name of the item as it applies to the factory class.  In other words, the name does not include the factory class name.  E.g. The factory class of scrolls would
    /// have names like "light", "magic mapping" and "identify".  This name should be able to uniquely identify the item from other items within the same factory class.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Returns the syntax for the description of the item.  The and symbol '&' is used to represent the article (a, an or a number) and the
    /// tilde symbol '~' used to place the 's', 'es', or 'ies' plural form of the noun.
    /// </summary>
    protected virtual string? DescriptionSyntax => null; // TODO: Books use a hard-coded realm name when the realm is set at run-time.

    /// <summary>
    /// Returns an alternate coded name for some character classes for known items; null, if there is no altername name; in which the <see cref="DescriptionSyntax"/> property will
    /// be used.  Returns null, by default.  Spellbooks have a alternate names.  Druid, Fanatic, Monk, Priest and Ranger character classes use alternate names.  Character
    /// classes will use alternate naming conventions when <see cref="BaseCharacterClass.UseAlternateItemNames"/> property returns true.
    /// </summary>
    protected virtual string? AlternateDescriptionSyntax => null; // TODO: This coded divine name has hard-coded realm names when realm is set at run-time.

    protected virtual string? FlavorSuppressedDescriptionSyntax => null;
    protected virtual string? AlternateFlavorSuppressedDescriptionSyntax => null;

    protected virtual string? FlavorUnknownDescriptionSyntax => null;

    protected virtual string? AlternateFlavorUnknownDescriptionSyntax => null;

    /// <summary>
    /// Returns the number of turns an item that can be zapped needs before it is recharged; or null, if the item cannot be zapped.  A value of zero, means the item does not need any turns to
    /// be recharged after it is used.
    /// </summary>
    protected virtual (string ScriptName, string TurnsToRecharge, bool RequiresAiming, int ManaEquivalent)? ZapBindingTuple => null;

    protected abstract string ItemClassBindingKey { get; }

    /// <summary>
    /// Returns true, if the item is fuel for a lantern.  Returns false, by default.
    /// </summary>
    public virtual bool IsLanternFuel => false;

    /// <summary>
    /// Returns a sort order index for sorting items in a pack.  Lower numbers show before higher numbers.
    /// </summary>
    public abstract int PackSort { get; }

    /// <summary>
    /// Returns the inventory slot where the item is wielded.  Items will be wielded in the first slot that is available.  Rings use multiple wield slots for left and right hands.
    /// Returns the pack, by default.  This property is used to bind the <see cref="BaseWieldSlot"/>  property during the binding phase.
    /// </summary>
    protected virtual string[] BaseWieldSlotBindingKeys => new string[] { nameof(PackInventorySlot) };

    /// <summary>
    /// Returns true, if the destroy script should ask the player if known items from this factory should be destroyed by setting the applicable 
    /// broken stomp type to true; false, otherwise.  Returns true, by default.  Chests, weapons, armor and orbs of light return false.
    /// </summary>
    public virtual bool AskDestroyAll => true;

    /// <summary>
    /// Returns true, if the object has different quality ratings; false, if items of the factory all have the same quality rating.  Returns false, by default.  
    /// Armor, weapons and orbs of light return true.  Items without quality ratings will always use the Broken stomp type.  Items with various quality ratings will use various
    /// item properties to determine their quality.
    /// </summary>
    public virtual bool HasQualityRatings => false;

    public virtual int ArmorClass => 0;

    /// <summary>
    /// Returns the depth and 1-in probably for where the item can be found; or null, if the item is not found naturally.  Returns null, by definition.
    /// </summary>
    public virtual (int level, int chance)[]? DepthsFoundAndChances => null; // TODO: Convert the chance into a Roll object

    /// <summary>
    /// Returns the real cost of a standard item.  Returns 0 by default.  For wands, staffs and light-sources, this value should be the value of an item with no charges.  An empty item should
    /// still have some value if it can be recharged.
    /// </summary>
    public virtual int Cost => 0;

    public virtual int DamageDice => 0;

    public virtual int DamageSides => 0;

    public virtual bool KindIsGood => false;
    public virtual int LevelNormallyFound => 0;
    public virtual bool Lightsource { get; set; } = false;

    /// <summary>
    /// Returns the initial amount of bonus charisma to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusCharisma => 0;

    /// <summary>
    /// Returns the initial amount of bonus constitution to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusConstitution => 0;

    /// <summary>
    /// Returns the initial amount of bonus dexterity to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusDexterity => 0;

    /// <summary>
    /// Returns the initial amount of bonus intelligence to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusIntelligence => 0;

    /// <summary>
    /// Returns the initial amount of bonus strength to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusStrength => 0;

    /// <summary>
    /// Returns the initial amount of bonus wisdom to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusWisdom => 0;

    /// <summary>
    /// Returns the initial amount of bonus attacks to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusAttacks => 0;

    /// <summary>
    /// Returns the initial amount of bonus infravision to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusInfravision => 0;

    /// <summary>
    /// Returns the initial amount of bonus speed to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusSpeed => 0;

    /// <summary>
    /// Returns the initial amount of bonus search to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusSearch => 0;

    /// <summary>
    /// Returns the initial amount of bonus stealth to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusStealth => 0;

    /// <summary>
    /// Returns the initial amount of bonus tunnel to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusTunnel => 0;

    /// <summary>
    /// Returns the initial number of turns of light to be assigned to the item.
    /// </summary>
    public virtual int InitialTurnsOfLight => 0;

    /// <summary>
    /// Returns the initial nutritional value that items of this factory will be given.  0 turns is returns by default.
    /// </summary>
    public virtual int InitialNutritionalValue => 0;

    /// <summary>
    /// Returns the roll expression to determine the initial gold pieces that are given to the player when the item is picked up.  This property must conform to the <see cref="Roll"/> syntax for parsing.  
    /// See <see cref="Game.ParseRollExpression"/> for syntax details.  This property is used to bind the <see cref="InitialGoldPiecesRoll"/> property during the bind phase.
    /// </summary>
    protected virtual string InitialGoldPiecesRollExpression => "0";

    /// <summary>
    /// Returns a divisor to be used to compute the amount of experience gained when an applicable character class destroys the book.  Defaults to 4.
    /// </summary>
    public virtual int ExperienceGainDivisorForDestroying => 0;

    /// <summary>
    /// Returns the names of the spells, in order, that belong to this book; or null, if the item is not a book.  This property is used to bind the Spells property during the binding phase.
    /// </summary>
    protected virtual string[]? SpellBindingKeys => null;

    public virtual int BonusArmorClass => 0;
    public virtual int BonusDamage => 0;
    public virtual int BonusHit => 0;

    public virtual int Weight => 0;

    /// <summary>
    /// Returns whether or not the chest is small.  Small chests have a 75% chance that the items in the chest are gold.  Large chest always return items.
    /// </summary>
    public virtual bool IsSmall => false; // TODO: This property is only valid when IsContainer.  The data type is horrible.

    /// <summary>
    /// Returns true, if the item is capable of having slaying bonuses applied.  Only weapons return true.  Returns false by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual bool CanApplySlayingBonus => false;

    /// <summary>
    /// Returns the base value for a non flavor-aware item.  Returns 0, by default.
    /// </summary>
    public virtual int BaseValue => 0;

    /// <summary>
    /// Returns true, if the item is susceptible to electricity.  Returns false, by default.
    /// </summary>
    public virtual bool HatesElectricity => false;

    /// <summary>
    /// Returns true, if the item is susceptible to fire.  Returns false, by default.
    /// </summary>
    public virtual bool HatesFire => false;

    /// <summary>
    /// Returns true, if the item is susceptible to acid.  Returns false, by default.
    /// </summary>
    public virtual bool HatesAcid => false;

    /// <summary>
    /// Returns true, if the item is susceptible to cold.  Returns false, by default.
    /// </summary>
    public virtual bool HatesCold => false;

    /// <summary>
    /// Returns true, if the item can provide a sheath of electricity.  Returns false, by default.  Cloaks, soft and hard armor return true.
    /// </summary>
    public virtual bool CanProvideSheathOfElectricity => false;

    /// <summary>
    /// Returns true, if the item can provide a sheath of fire.  Returns false, by default.  Cloaks, soft and hard armor return true.
    /// </summary>
    public virtual bool CanProvideSheathOfFire => false;

    /// <summary>
    /// Returns true, if the item can reflect bolts and arrows.  Returns false, by default.  Shields, helms, cloaks and hard armor return true.
    /// </summary>
    public virtual bool CanReflectBoltsAndArrows => false;

    /// <summary>
    /// Returns a 1-in-chance for a random artifact to have activation applied.  Returns 3 by default.  Armor returns double the default.
    /// </summary>
    public virtual int RandartActivationChance => 3;

    /// <summary>
    /// Returns true, if the item provides sunlight, which burns certain races.  Returns false, by default.
    /// </summary>
    public virtual bool ProvidesSunlight => false;

    /// <summary>
    /// Returns true, if an item of this factory can have slaying bonus applied for biased artifacts.  Returns true, for all items except bows; which return false.
    /// </summary>
    public virtual bool CanApplyArtifactBiasSlaying => true;

    /// <summary>
    /// Returns true, if an item of this factory can have random resistance bonus applied for biased artifacts.  Returns false for all items except for cloaks, soft armor and hard armor; which return true.
    /// </summary>
    public virtual bool CanApplyArtifactBiasResistance => true;

    /// <summary>
    /// Returns true, if an item of this factory can have be blessed for priestly biased artifacts.  Returns false, for all items except swords and polearms; which return false.
    /// </summary>
    public virtual bool CanApplyBlessedArtifactBias => false;

    /// <summary>
    /// Returns true, if an item of this factory can be eaten by a monster with the eat food attack effect.  Returns false for all items except food items; which return true.
    /// </summary>
    public virtual bool CanBeEatenByMonsters => false;

    /// <summary>
    /// Returns the name of the script to be run when an item of this factory is eaten; or null, if items cannot be eaten.  Returns null, by default.  This property
    /// is used to bind the <see cref="EatScript"/> property during the bind phase.
    /// </summary>
    public virtual string? EatScriptBindingKey => null;

    public virtual bool VanishesWhenEatenBySkeletons => false;

    /// <summary>
    /// Returns true, if the food item is completely consumed when eaten.  Consumed food items are removed once eaten.  Returns true, by default because 
    /// all food items are consumed except for dwarf bread.  Dwarf bread returns false.
    /// </summary>
    public virtual bool IsConsumedWhenEaten => true;

    /// <summary>
    /// Returns the name of the activation script for scrolls when read; or null, if the item cannot be read.  Returns null, by default.  This property is used to bind the <see cref="ActivationTuple"/> 
    /// property during the bind phase.
    /// </summary>
    protected virtual (string ScriptName, int ManaValue)? ActivationBindingTuple => null;
    #endregion
}
