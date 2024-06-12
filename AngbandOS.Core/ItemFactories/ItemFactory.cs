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
    protected ItemFactory(Game game) : base(game) { }

    /// <summary>
    /// Returns true, if the item is broken; false, otherwise.  Broken items have no value and will be stomped.
    /// </summary>
    public virtual bool IsBroken => false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.  
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

    public virtual void Recharge(Item item, int num) { }

    /// <summary>
    /// Returns the number of charges to assign to an item that is a rod.  A value of 0 is returned, by default.
    /// </summary>
    public virtual int RodChargeCount => 0;

    /// <summary>
    /// Processes a world turn for an item that is on the dungeon floor.  Does nothing, by default.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="gridTile"></param>
    public virtual void GridProcessWorld(Item item, GridTile gridTile) { }

    /// <summary>
    /// Processes the world turn for an item being held by a monster.  Does nothing, by default.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="mPtr"></param>
    public virtual void MonsterProcessWorld(Item item, Monster mPtr) { }

    /// <summary>
    /// Consumes the magic of a rechargeable item.  Does nothing, by default.  Rods, staves and wands are supported.
    /// </summary>
    public virtual void EatMagic(Item item) { }

    public string UniqueId = Guid.NewGuid().ToString();

    /// <summary>
    /// Returns true, if the item can be stomped.  Returns the stompable status based on the item quality rating, by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual bool IsStompable(Item item)
    {
        ItemQualityRating itemQualityRating = item.GetQualityRating();
        int? stompableIndex = itemQualityRating.StompIndex;
        if (stompableIndex == null)
        {
            return false;
        }
        return Stompable[stompableIndex.Value];
    }

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

    public virtual void Refill(Game game, Item item)
    {
        game.MsgPrint("Your light cannot be refilled.");
    }

    /// <summary>
    /// Returns the maximum fuel that can be used for phlogiston.  Returns null, by default, meaning that the light source cannot be used to create a phlogiston.
    /// </summary>
    public virtual int? MaxPhlogiston => null;

    /// <summary>
    /// Returns the number of turns of light that consumeds for each world turn.  Defaults to zero; which means there is no consumption and that the light source lasts forever.
    /// Torches and laterns have burn rates greater than zero.
    /// </summary>
    public virtual int BurnRate => 0;

    /// <summary>
    /// Returns an additional description of the item that is appended to the detailed description, when needed.  
    /// By default, empty is returned, if the item is known; otherwise, the HideType, Speed, Blows, Stealth, Search, Infra, Tunnel and recharging time characteristics are returned.
    /// </summary>
    /// <returns></returns>
    public virtual string GetVerboseDescription(Item item)
    {
        string s = "";
        if (item.IsKnown() && CanBeAimed)
        {
            s += $" ({item.WandChargesRemaining} {Game.Pluralize("charge", item.WandChargesRemaining)})";
        }

        if (BurnRate > 0)
        {
            s += $" (with {item.TurnsOfLightRemaining} {Game.Pluralize("turn", item.TurnsOfLightRemaining)} of light)";
        }

        if (item.IsKnown() && HasAnyPvalMask)
        {
            s += $" ({GetSignedValue(item.TypeSpecificValue)}";
            if (HideType)
            {
            }
            else if (Speed)
            {
                s += " speed";
            }
            else if (Blows)
            {
                if (item.TypeSpecificValue > 1)
                {
                    s += " attacks";
                }
                else
                {
                    s += " attack";
                }
            }
            else if (Stealth)
            {
                s += " stealth";
            }
            else if (Search)
            {
                s += " searching";
            }
            else if (Infra)
            {
                s += " infravision";
            }
            else if (Tunnel)
            {
            }
            s += ")";
        }
        if (item.IsKnown() && item.ActivationRechargeTimeRemaining != 0)
        {
            s += " (charging)";
        }
        return s;
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

    public virtual int? GetTypeSpecificRealValue(Item item, int value) => 0;

    /// <summary>
    /// Returns an array of tuples that define the mass produce for items of this factory.  These tuples define a Roll that is applied for additional items to be produced
    /// for items of a cost value or less; or null, if no additional items should be produced based on any cost.  Returns null, by default.  This property is used
    /// to bind the <see cref="MassProduceTuples"/> property during the bind phase.  The tuples must be sorted by cost and are checked during the bind phase.
    /// </summary>
    protected virtual (int, string)[]? MassProduceTupleNames => null;

    public (int, Roll)[]? MassProduceTuples { get; private set; }

    /// <summary>
    /// Returns the number of additional items to be produced, when the item is mass produced for a store.  Returns 0, by default.  When an item
    /// is created for stores, this mass produce count can be used to create additional stores of the item based on the value of the item.  An item
    /// with a high value may not produce as many as other items of lower value.  This property is bound using the <see cref="MassProduceTupleNames"/> property during
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
    /// Applies an additional bonus to random artifacts.  Does nothing by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual void ApplyBonusForRandomArtifactCreation(Item item) { }

    /// <summary>
    /// Returns an additional description when identified fully.  Returns null by default.  Only light sources provide an additional description.
    /// </summary>
    [Obsolete("The Identify is being handled by the Item and cannot be provided here in the factory.  Current usage is limited to existing overrides.")]
    public virtual string Identify(Item item) => null;

    /// <summary>
    /// Returns true, if the item is deemed as worthless.  Worthless items will ignore their RealValue and will always have 0 real value.  Returns false by default.
    /// </summary>
    public virtual bool IsWorthless(Item item) => false;

    /// <summary>
    /// Gets an additional bonus gold real value associated with the item.  Returns 0, by default.  Returns null, if the item is worthless.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual int? GetBonusRealValue(Item item, int value) => 0;

    public virtual void ApplySlayingForRandomArtifactCreation(Item item)
    {
        if (item.Characteristics.ArtifactBias != null)
        {
            if (item.Characteristics.ArtifactBias.ApplySlaying(item))
            {
                return;
            }
        }

        switch (Game.DieRoll(34))
        {
            case 1:
            case 2:
                item.Characteristics.SlayAnimal = true;
                break;

            case 3:
            case 4:
                item.Characteristics.SlayEvil = true;
                if (item.Characteristics.ArtifactBias == null && Game.DieRoll(2) == 1)
                {
                    item.Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(LawArtifactBias));
                }
                else if (item.Characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                {
                    item.Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
                }
                break;

            case 5:
            case 6:
                item.Characteristics.SlayUndead = true;
                if (item.Characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                {
                    item.Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
                }
                break;

            case 7:
            case 8:
                item.Characteristics.SlayDemon = true;
                if (item.Characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                {
                    item.Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
                }
                break;

            case 9:
            case 10:
                item.Characteristics.SlayOrc = true;
                break;

            case 11:
            case 12:
                item.Characteristics.SlayTroll = true;
                break;

            case 13:
            case 14:
                item.Characteristics.SlayGiant = true;
                break;

            case 15:
            case 16:
                item.Characteristics.SlayDragon = true;
                break;

            case 17:
                item.Characteristics.KillDragon = true;
                break;

            case 18:
            case 19:
                if (CanVorpalSlay)
                {
                    item.Characteristics.Vorpal = true;
                    if (item.Characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                    {
                        item.Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WarriorArtifactBias));
                    }
                }
                else
                {
                    // This item cannot have vorpal slaying applied, choose a different random slaying.
                    ApplySlayingForRandomArtifactCreation(item);
                }
                break;

            case 20:
                item.Characteristics.Impact = true;
                break;

            case 21:
            case 22:
                item.Characteristics.BrandFire = true;
                if (item.Characteristics.ArtifactBias == null)
                {
                    item.Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(FireArtifactBias));
                }
                break;

            case 23:
            case 24:
                item.Characteristics.BrandCold = true;
                if (item.Characteristics.ArtifactBias == null)
                {
                    item.Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(ColdArtifactBias));
                }
                break;

            case 25:
            case 26:
                item.Characteristics.BrandElec = true;
                if (item.Characteristics.ArtifactBias == null)
                {
                    item.Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(ElectricityArtifactBias));
                }
                break;

            case 27:
            case 28:
                item.Characteristics.BrandAcid = true;
                if (item.Characteristics.ArtifactBias == null)
                {
                    item.Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(AcidArtifactBias));
                }
                break;

            case 29:
            case 30:
                item.Characteristics.BrandPois = true;
                if (item.Characteristics.ArtifactBias == null && Game.DieRoll(3) != 1)
                {
                    item.Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PoisonArtifactBias));
                }
                else if (item.Characteristics.ArtifactBias == null && Game.DieRoll(6) == 1)
                {
                    item.Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(NecromanticArtifactBias));
                }
                else if (item.Characteristics.ArtifactBias == null)
                {
                    item.Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RogueArtifactBias));
                }
                break;

            case 31:
            case 32:
                item.Characteristics.Vampiric = true;
                if (item.Characteristics.ArtifactBias == null)
                {
                    item.Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(NecromanticArtifactBias));
                }
                break;

            default:
                item.Characteristics.Chaotic = true;
                if (item.Characteristics.ArtifactBias == null)
                {
                    item.Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(ChaosArtifactBias));
                }
                break;
        }
    }

    /// <summary>
    /// Applies magic to the item.  Does nothing, by default.  This apply magic method is always called after an object is created (new Item()) but not all new Item creation call ApplyMagic.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    public virtual void EnchantItem(Item item, bool usedOkay, int level, int power) { } // TODO: Needs to be built into the new Item(), should be renamed .. the Store is needed for FuelSources to be full not used

    /// <summary>
    /// Applies a good random rare characteristics to an item of armor.
    /// </summary>
    /// <param name="item"></param>
    protected virtual void ApplyRandomGoodRareCharacteristics(Item item) { }

    /// <summary>
    /// Applies a poor random rare characteristics to an item of armor.  Does nothing by default.  Various derived class may override
    /// this method and apply a random poor characteristic to the item.
    /// </summary>
    /// <param name="item"></param>
    protected virtual void ApplyRandomPoorRareCharacteristics(Item item) { }

    /// <summary>
    /// Hook into the ProcessWorld, when the item is being carried in a pack inventory slot.  Does nothing, by default..
    /// </summary>
    /// <param name="game"></param>
    public virtual void PackProcessWorld(Item item) { }

    /// <summary>
    /// Processes the world turn, when the item is being worn/wielded.  Does nothing, by default.  Gemstones of light drain from the player.
    /// </summary>
    /// <param name="game"></param>
    public virtual void EquipmentProcessWorld(Item item) { }

    /// <summary>
    /// Returns the inventory slot where the item is wielded.  Returns the pack, by default.
    /// </summary>
    public virtual int WieldSlot => InventorySlot.Pack;

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
    /// Returns the percentage chance that an thrown or fired item breaks.  Returns 10, or 10%, by default.  A value of 101, guarantees the item will break.
    /// </summary>
    public virtual int PercentageBreakageChance => 10;

    /// <summary>
    /// Returns a count for the number of items to create during the MakeObject.  Returns 1, by default.  Spikes, shots, arrows and bolts return values greater than 1.
    /// </summary>
    public virtual int MakeObjectCount => 1;

    /// <summary>
    /// Returns true, if the item multiplies damages against a specific monster race.  Returns false, by default. Shots, arrows, bolts, hafted, polearms, swords and digging all return true.
    /// </summary>
    public virtual bool GetsDamageMultiplier => false;

    /// <summary>
    /// Returns true, if the identity of the item can be sensed; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool IdentityCanBeSensed => false;

    /// <summary>
    /// Returns true, if the item can be used as fuel for a torch.
    /// </summary>
    public virtual bool IsFuelForTorch => false;

    /// <summary>
    /// Returns true, if the item can be worn.
    /// </summary>
    public virtual bool IsWearable => false;

    /// <summary>
    /// Returns true, if the item can be eaten.
    /// </summary>
    public virtual bool CanBeEaten => false;

    /// <summary>
    /// Returns true, if the item can be quaffed.
    /// </summary>
    public virtual bool CanBeQuaffed => false;

    /// <summary>
    /// Returns true, if the item can be used.
    /// </summary>
    public virtual bool CanBeUsed => false;
    /// <summary>
    /// Returns true, if the item can be zapped.
    /// </summary>
    public virtual bool CanBeZapped => false;

    /// <summary>
    /// Returns true, if the item can be chosen for the Fire command.
    /// </summary>
    public virtual bool CanBeFired => false;

    /// <summary>
    /// Returns true, if the item is armor.
    /// </summary>
    public virtual bool IsArmor => false;

    /// <summary>
    /// Returns true, if the item is rechargable.
    /// </summary>
    public virtual bool IsRechargable => false;

    /// <summary>
    /// Returns true, if the item is a weapon.
    /// </summary>
    public virtual bool IsWeapon => false;

    /// <summary>
    /// Returns the number of items contained in the chest; or 0, if the item is not a chest.  Returns 0, by default.
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

    public override void Bind()
    {
        Symbol = Game.SingletonRepository.Get<Symbol>(SymbolName);
        ItemClass = Game.SingletonRepository.Get<ItemClass>(ItemClassName);
        FlavorSymbol = Symbol;
        FlavorColor = Color;

        // Bind the MassProduceTuples
        if (MassProduceTupleNames == null)
        {
            MassProduceTuples = null;
        }
        else
        {
            List<(int, Roll)> massProduceTuplesList = new List<(int, Roll)>();
            foreach ((int cost, string rollSyntax) in MassProduceTupleNames)
            {
                (int, Roll) newTuple = (cost, Game.ParseRollExpression(rollSyntax));
                massProduceTuplesList.Add(newTuple);
            }
            MassProduceTuples = massProduceTuplesList.ToArray();

            // Validate the MassProduceTuples sorting.
            if (!Game.ValidateTupleSorting<(int cost, Roll roll)>(MassProduceTuples, (a, b) => a.cost < b.cost))
            {
                throw new Exception($"The MassProduceTupleNames specified for the {GetType().Name} are not sorted in ascending order by cost.");
            }
        }

        InitialGoldPiecesRoll = Game.ParseRollExpression(InitialGoldPieces);
        EatScript = Game.SingletonRepository.GetNullable<IIdentifableScript>(EatScriptName);

        // Flavorless items will default to simply use the item name.
        _descriptionSyntax = DescriptionSyntax != null ? DescriptionSyntax : Name;

        // If the flavorless item doesn't have an altername, default to the non-alternate version.
        _alternateDescriptionSyntax = AlternateDescriptionSyntax != null ? AlternateDescriptionSyntax : _descriptionSyntax;

        // Flavored items that are still unknown will default to using the flavorless syntaxes.
        _flavorUnknownDescriptionSyntax = FlavorUnknownDescriptionSyntax != null ? FlavorUnknownDescriptionSyntax : _descriptionSyntax;
        _alternateFlavorUnknownDescriptionSyntax = AlternateFlavorUnknownDescriptionSyntax != null ? AlternateFlavorUnknownDescriptionSyntax : _flavorUnknownDescriptionSyntax;

        _flavorSuppressedDescriptionSyntax = FlavorSuppressedDescriptionSyntax != null ? FlavorSuppressedDescriptionSyntax : _descriptionSyntax;
        _alternateFlavorSuppressedDescriptionSyntax = AlternateFlavorSuppressedDescriptionSyntax != null ? AlternateFlavorSuppressedDescriptionSyntax : _flavorSuppressedDescriptionSyntax;

        ActivateWandScript = Game.SingletonRepository.GetNullable<IIdentifableDirectionalScript>(ActivateWandScriptName);
        ActivateScrollScript = Game.SingletonRepository.GetNullable<IIdentifableAndUsedScript>(ActivateScrollScriptName);
    }

    protected abstract string ItemClassName { get; }

    public ItemClass ItemClass { get; private set; }

    /// <summary>
    /// Returns true, if the item is fuel for a lantern.  Returns false, by default.
    /// </summary>
    public virtual bool IsFuelForLantern => false;

    /// <summary>
    /// Returns a sort order index for sorting items in a pack.  Lower numbers show before higher numbers.
    /// </summary>
    public abstract int PackSort { get; }

    /// <summary>
    /// Drains charges from the item and returns true, if charges were drained; false, otherwise.  Returns false, by default.
    /// </summary>
    /// <param name="monster"></param>
    /// <param name="obvious"></param>
    /// <returns></returns>
    public virtual bool DrainChargesMonsterAttack(Item item, Monster monster, ref bool obvious) // TODO: obvious needs to be in an event 
    {
        return false;
    } 

    /// <summary>
    /// Returns the inventory slot where the item is wielded.  Returns the pack, by default.
    /// </summary>
    public virtual BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(PackInventorySlot));

    /// <summary>
    /// Returns true, if items of this type are stompable (based on the known "feeling" of (Broken, Average, Good & Excellent)).
    /// Use StompableType enum to address each index.
    /// </summary>
    public readonly bool[] Stompable = new bool[4];

    /// <summary>
    /// Returns true, if the flavor for the factory has been identified or the factory doesn't use flavors; false, when the factory uses flavors and
    /// the flavor still hasn't been identified by the player.  The <see cref="Game.FlavorInit"/> method is used to re-initialize this variable.
    /// </summary>
    public bool IsFlavorAware;

    /// <summary>
    /// Returns the character to be displayed for items of this type.  This character is initially set from the BaseItemCategory, but item categories
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
    /// Returns true, if the item category has any of the following properties: Str, Int, Wis, Dex, Con, Cha, Stealth, Search, Infra, Tunnel, Speed or Blows.
    /// </summary>
    /// <returns></returns>
    public bool HasAnyPvalMask
    {
        get
        {
            return Str || Int || Wis || Dex || Con || Cha || Stealth || Search || Infra || Tunnel || Speed || Blows;
        }
    }

    /// <summary>
    /// Returns true, if the destroy script should ask the player if known items from this factory should be destroyed by setting the applicable 
    /// broken stomp type to true; false, otherwise.  Returns true, by default.  Chests, weapons, armor and orbs of light return false.
    /// </summary>
    public virtual bool AskDestroyAll => true;

    /// <summary>
    /// Returns true, if the object have different quality ratings; false, if items of the factory all have the same quality rating.  Returns false, by default.  
    /// Armor, weapons and orbs of light return true.  Items without quality rating will always use the Broken stomp type.  Items with quality will use various
    /// item properties to determine their quality.
    /// </summary>
    public virtual bool HasQualityRatings => false;

    /// <summary>
    /// Returns the flavor that was issued to the item factory.
    /// </summary>
    public Flavor? Flavor { get; set; }

    /// <summary>
    /// Applies random flavor visuals to the items.  This method is called if the HasFlavor property returns true when creating a new game.
    /// </summary>
    public virtual void ApplyFlavorVisuals() { }

    /// <summary>
    /// Returns true, if the player has attempted/tried the item.
    /// </summary>
    public bool Tried;

    protected abstract string SymbolName { get; }

    /// <summary>
    /// Returns the symbol to use for rendering. This symbol will be initially used to set the FlavorCharacter and item
    /// categories that have flavor may change the FlavorCharacter based on the flavor.
    /// </summary>
    public Symbol Symbol { get; private set; }

    /// <summary>
    /// Returns the color that items of this type should be rendered with.  This color will be initially used to set the FlavorColor and item categories
    /// that have flavor may change the FlavorColor based on the flavor.
    /// </summary>
    public virtual ColorEnum Color => ColorEnum.White;

    public virtual int ArmorClass => 0;

    /// <summary>
    /// Returns the depth and 1-in probably for where the item can be found; or null, if the item is not found naturally.  Returns null, by definition.
    /// </summary>
    public virtual (int level, int chance)[]? DepthsFoundAndChances => null;

    /// <summary>
    /// Returns the real cost of a standard item.  Returns 0 by default.
    /// </summary>
    public virtual int Cost => 0;

    public virtual int DamageDice => 0;

    public virtual int DamageSides => 0;

    public virtual bool KindIsGood => false;
    public virtual int LevelNormallyFound => 0;
    public virtual bool Lightsource { get; set; } = false;

    /// <summary>
    /// Returns the initial value to be assigned to the type specific value.  Most items will override a default value.  Gold will
    /// compute a value based on the cost property.
    /// </summary>
    [Obsolete("Being converted to using true type specific values")]
    public virtual int InitialTypeSpecificValue => 0;
    public virtual int InitialTurnsOfLight => 0;

    /// <summary>
    /// Returns the initial nutritional value that items of this factory will be given.  0 turns is returns by default.
    /// </summary>
    public virtual int InitialNutritionalValue => 0;

    /// <summary>
    /// Returns the initial gold pieces that are given to the player when the item is picked up.  This property must conform to the <see cref="Roll"/> syntax for parsing.  
    /// See <see cref="Game.ParseRollExpression"/> for syntax details.  This property is used to bind the <see cref="InitialGoldPiecesRoll"/> property during the bind phase.
    /// </summary>
    protected virtual string InitialGoldPieces => "0";

    /// <summary>
    /// Returns a Roll that is used to determine the number of gold pieces that are given to the player when the item is picked up.  This property is bound from the
    /// <see cref="InitialGoldPieces"/> property during the bind phase.
    /// </summary>
    public Roll InitialGoldPiecesRoll { get; private set; }

    /// <summary>
    /// Tests an item to determine if it belongs to an Item type and returns a the item casted into that type; or null, if the item doesn't belong to the type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T? TryCast<T>() where T : ItemFactory
    {
        if (typeof(T).IsAssignableFrom(GetType()))
        {
            return (T)this;
        }
        else
        {
            return null;
        }
    }

    public virtual int BonusArmorClass => 0;
    public virtual int BonusDamage => 0;
    public virtual int BonusHit => 0;


    public virtual int Weight => 0;

    /// <summary>
    /// Returns the ItemCategoryEnum value for backwards compatibility.  This property will be deleted.
    /// </summary>
    public virtual ItemTypeEnum CategoryEnum { get; }

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
    /// Returns the script to be run when an item of this factory is eaten; or null, if items cannot be eaten.  This property is bound from the <see cref="EatScriptName"/> property
    /// during the bind phase.
    /// </summary>
    public IIdentifableScript? EatScript { get; private set; }

    /// <summary>
    /// Returns the name of the script to be run when an item of this factory is eaten; or null, if items cannot be eaten.  Returns null, by default.  This property
    /// is used to bind the <see cref="EatScript"/> property during the bind phase.
    /// </summary>
    public virtual string? EatScriptName => null;

    public virtual bool VanishesWhenEatenBySkeletons => false;

    /// <summary>
    /// Returns true, if the food item is completely consumed when eaten.  Consumed food items are removed once eaten.  Returns true, by default because 
    /// all food items are consumed except for dwarf bread.  Dwarf bread returns false.
    /// </summary>
    public virtual bool IsConsumedWhenEaten => true;

    /// <summary>
    /// Returns the name of the activation script for wands when aimed; or null, if the item cannot be aimed.  Returns null, by default.  This property is used to bind the <see cref="ActivateWandScript"/> 
    /// property during the bind phase.
    /// </summary>
    protected virtual string? ActivateWandScriptName => null;

    /// <summary>
    /// Returns the activation script for wands when aimed; or null, if the item cannot be aimed.  This property is bound from the <see cref="ActivateWandScriptName"/> property during the bind phase.
    /// </summary>
    private IIdentifableDirectionalScript? ActivateWandScript { get; set; }

    public bool ActivateWand(int dir)
    {
        if (ActivateWandScript == null)
        {
            throw new Exception("Cannot activate wand with null script.");
        }
        return ActivateWandScript.ExecuteIdentifableDirectionalScript(dir);
    }

    public bool CanBeAimed => ActivateWandScript != null;

    /// <summary>
    /// Returns the name of the activation script for scrolls when read; or null, if the item cannot be read.  Returns null, by default.  This property is used to bind the <see cref="ActivateScrollScript"/> 
    /// property during the bind phase.
    /// </summary>
    protected virtual string? ActivateScrollScriptName => null;

    /// <summary>
    /// Returns the activation script for scrolls when read; or null, if the item cannot be read.  This property is bound from the <see cref="ActivateScrollScriptName"/> property during the bind phase.
    /// </summary>
    private IIdentifableAndUsedScript? ActivateScrollScript { get; set; }

    /// <summary>
    /// Returns true, if the item is a scroll.
    /// </summary>
    public bool CanBeRead => ActivateScrollScript != null;

    public (bool identified, bool used) Read()
    {
        if (ActivateScrollScript == null)
        {
            throw new Exception("Cannot activate scroll with null script.");
        }
        return ActivateScrollScript.ExecuteIdentifableAndUsedScript();
    }
}
