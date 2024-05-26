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

internal abstract class ItemFactory : IItemCharacteristics, IGetKey
{
    protected readonly Game Game;

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

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

    /// <summary>
    /// Returns a value to add to the treasure rating.  Returns 0, by default.
    /// </summary>
    public virtual int TreasureRating => 0;

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
    /// Returns an additional description of the item that is appended to the base description, when needed.  Returns string.empty by default.
    /// </summary>
    /// <returns></returns>
    public virtual string GetDetailedDescription(Item item)
    {
        string s = "";
        if (item.IsKnown())
        {
            item.RefreshFlagBasedProperties();
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
    /// Returns the radius that the light source illuminates.  Default radius is 2.
    /// </summary>
    public virtual int Radius => 2;

    /// <summary>
    /// Returns an additional description of the item that is appended to the detailed description, when needed.  
    /// By default, empty is returned, if the item is known; otherwise, the HideType, Speed, Blows, Stealth, Search, Infra, Tunnel and recharging time characteristics are returned.
    /// </summary>
    /// <returns></returns>
    public virtual string GetVerboseDescription(Item item)
    {
        string s = "";
        if (BurnRate > 0)
        {
            s += $" (with {item.TurnsOfLightRemaining} {Game.Pluralize("turn", item.TurnsOfLightRemaining)} of light)";
        }

        item.RefreshFlagBasedProperties();
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
        if (item.IsKnown() && item.RingsArmorActivationAndFixedArtifactsRechargeTimeLeft != 0)
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
    public virtual void ApplyRandartBonus(Item item) { }

    /// <summary>
    /// Returns an additional description when identified fully.  Returns null by default.  Only light sources provide an additional description.
    /// </summary>
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

    public virtual void ApplyRandomSlaying(Item item, ref ArtifactBias? artifactBias)
    {
        if (artifactBias != null)
        {
            if (artifactBias.ApplySlaying(item))
            {
                return;
            }
        }

        switch (Game.DieRoll(34))
        {
            case 1:
            case 2:
                item.RandomArtifactItemCharacteristics.SlayAnimal = true;
                break;

            case 3:
            case 4:
                item.RandomArtifactItemCharacteristics.SlayEvil = true;
                if (artifactBias == null && Game.DieRoll(2) == 1)
                {
                    artifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(LawArtifactBias));
                }
                else if (artifactBias == null && Game.DieRoll(9) == 1)
                {
                    artifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
                }
                break;

            case 5:
            case 6:
                item.RandomArtifactItemCharacteristics.SlayUndead = true;
                if (artifactBias == null && Game.DieRoll(9) == 1)
                {
                    artifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
                }
                break;

            case 7:
            case 8:
                item.RandomArtifactItemCharacteristics.SlayDemon = true;
                if (artifactBias == null && Game.DieRoll(9) == 1)
                {
                    artifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
                }
                break;

            case 9:
            case 10:
                item.RandomArtifactItemCharacteristics.SlayOrc = true;
                break;

            case 11:
            case 12:
                item.RandomArtifactItemCharacteristics.SlayTroll = true;
                break;

            case 13:
            case 14:
                item.RandomArtifactItemCharacteristics.SlayGiant = true;
                break;

            case 15:
            case 16:
                item.RandomArtifactItemCharacteristics.SlayDragon = true;
                break;

            case 17:
                item.RandomArtifactItemCharacteristics.KillDragon = true;
                break;

            case 18:
            case 19:
                if (CanVorpalSlay)
                {
                    item.RandomArtifactItemCharacteristics.Vorpal = true;
                    if (artifactBias == null && Game.DieRoll(9) == 1)
                    {
                        artifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WarriorArtifactBias));
                    }
                }
                else
                {
                    ApplyRandomSlaying(item, ref artifactBias);
                }
                break;

            case 20:
                item.RandomArtifactItemCharacteristics.Impact = true;
                break;

            case 21:
            case 22:
                item.RandomArtifactItemCharacteristics.BrandFire = true;
                if (artifactBias == null)
                {
                    artifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(FireArtifactBias));
                }
                break;

            case 23:
            case 24:
                item.RandomArtifactItemCharacteristics.BrandCold = true;
                if (artifactBias == null)
                {
                    artifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(ColdArtifactBias));
                }
                break;

            case 25:
            case 26:
                item.RandomArtifactItemCharacteristics.BrandElec = true;
                if (artifactBias == null)
                {
                    artifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(ElectricityArtifactBias));
                }
                break;

            case 27:
            case 28:
                item.RandomArtifactItemCharacteristics.BrandAcid = true;
                if (artifactBias == null)
                {
                    artifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(AcidArtifactBias));
                }
                break;

            case 29:
            case 30:
                item.RandomArtifactItemCharacteristics.BrandPois = true;
                if (artifactBias == null && Game.DieRoll(3) != 1)
                {
                    artifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PoisonArtifactBias));
                }
                else if (artifactBias == null && Game.DieRoll(6) == 1)
                {
                    artifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(NecromanticArtifactBias));
                }
                else if (artifactBias == null)
                {
                    artifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RogueArtifactBias));
                }
                break;

            case 31:
            case 32:
                item.RandomArtifactItemCharacteristics.Vampiric = true;
                if (artifactBias == null)
                {
                    artifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(NecromanticArtifactBias));
                }
                break;

            default:
                item.RandomArtifactItemCharacteristics.Chaotic = true;
                if (artifactBias == null)
                {
                    artifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(ChaosArtifactBias));
                }
                break;
        }
    }

    /// <summary>
    /// Applies magic to the item.  Does nothing, by default.  This apply magic method is called after an object is created (new Item())
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    public virtual void ApplyMagic(Item item, int level, int power, Store? store) { } // TODO: Needs to be built into the new Item(), should be renamed

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
    /// Returns the intensity of light that the object emits.  By default, a value of 1 is returned, if the item has a 
    /// light-source characteristic.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public virtual int CalculateTorch(Item item)
    {
        item.RefreshFlagBasedProperties();
        if (item.Characteristics.Lightsource)
        {
            return 1;
        }
        else
        {
            return 0;
        }
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
    /// Returns true, if two item can be merged.  By default, returns true, if both items are from the same factory and are both known.
    /// </summary>
    public virtual bool ItemsCanBeMerged(Item a, Item b)
    {
        // Ensure both items belong to the same factory.  This works because factories are singletons.  Items from different factories cannot
        // be merged.
        if (a.Factory != b.Factory)
        {
            return false;
        }

        // The known status must be the same.
        if (a.IsKnown() != b.IsKnown())
        {
            return false;
        }
        if (a.BonusHit != b.BonusHit)
        {
            return false;
        }
        if (a.BonusDamage != b.BonusDamage)
        {
            return false;
        }
        if (a.BonusArmorClass != b.BonusArmorClass)
        {
            return false;
        }
        if (a.TypeSpecificValue != b.TypeSpecificValue)
        {
            return false;
        }
        if (a.ContainerIsOpen != b.ContainerIsOpen)
        {
            return false;
        }
        if (a.ContainerTrapConfiguration != null || b.ContainerTrapConfiguration != null)
        {
            return false;
        }
        if (a.LevelOfObjectsInContainer != b.LevelOfObjectsInContainer)
        {
            return false;
        }

        // TODO: Each of these belong to the factory
        if (a.StaffChargesRemaining != b.StaffChargesRemaining)
        {
            return false;
        }

        if (a.WandChargesRemaining!= b.WandChargesRemaining)
        {
            return false;
        }

        // Items need to have the same nutritional value.  Normally, this would always be true, but nutritional values may become variable.  Taking a bite of something.
        if (a.NutritionalValue != b.NutritionalValue)
        {
            return false;
        }

        // Items that have turns of light need to have the same number of turns, to be mergable.  E.g. 5 Wooden Torches (2500 turns)
        if (a.TurnsOfLightRemaining != b.TurnsOfLightRemaining)
        {
            return false;
        }
        if (a.IsArtifact != b.IsArtifact)
        {
            return false;
        }
        if (a.RareItem != b.RareItem)
        {
            return false;
        }
        if (a.RandomPower != null || b.RandomPower != null)
        {
            return false;
        }
        if (a.RingsArmorActivationAndFixedArtifactsRechargeTimeLeft != 0 || b.RingsArmorActivationAndFixedArtifactsRechargeTimeLeft != 0)
        {
            return false;
        }
        if (a.RodRechargeTimeRemaining != 0 || b.RodRechargeTimeRemaining != 0)
        {
            return false;
        }
        if (a.ArmorClass != b.ArmorClass)
        {
            return false;
        }
        if (a.DamageDice != b.DamageDice)
        {
            return false;
        }
        if (a.DamageSides != b.DamageSides)
        {
            return false;
        }
        if (!a.RandomArtifactItemCharacteristics.Equals(b.RandomArtifactItemCharacteristics))
        {
            return false;
        }
        if (a.IdentCursed != b.IdentCursed)
        {
            return false;
        }
        if (a.IdentBroken != b.IdentBroken)
        {
            return false;
        }
        if (a.Inscription != b.Inscription)
        {
            return false;
        }
        if (a.Discount != b.Discount)
        {
            return false;
        }
        if (a.IdentityIsStoreBought != b.IdentityIsStoreBought)
        {
            return false;
        }

        int total = a.Count + b.Count;
        return total < Constants.MaxStackSize;
    }

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
    /// Returns true, if the item can be aimed.
    /// </summary>
    public virtual bool CanBeAimed => false;

    /// <summary>
    /// Returns true, if the item can be eaten.
    /// </summary>
    public virtual bool CanBeEaten => false;

    /// <summary>
    /// Returns true, if the item can be quaffed.
    /// </summary>
    public virtual bool CanBeQuaffed => false;

    /// <summary>
    /// Returns true, if the item can be read.
    /// </summary>
    public virtual bool CanBeRead => false;
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

    protected ItemFactory(Game game)
    {
        Game = game;
    }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

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

    public virtual void Bind()
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
                (int, Roll) newTuple = (cost, Game.ParseRoll(rollSyntax));
                massProduceTuplesList.Add(newTuple);
            }
            MassProduceTuples = massProduceTuplesList.ToArray();

            // Validate the MassProduceTuples sorting.
            if (!Game.ValidateTupleSorting<(int cost, Roll roll)>(MassProduceTuples, (a, b) => a.cost < b.cost))
            {
                throw new Exception($"The MassProduceTupleNames specified for the {GetType().Name} are not sorted in ascending order by cost.");
            }
        }

        InitialGoldPiecesRoll = Game.ParseRoll(InitialGoldPieces);
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
    }

    protected abstract string ItemClassName { get; }

    public ItemClass ItemClass { get; private set; }

    /// <summary>
    /// Returns a description of the activation effect for the item or null, if the item cannot be activated.  Returns null by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual string? DescribeActivationEffect => null;

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
    /// Returns true, if items of this factory can be activated.  Returns true for all dragon scale mail and rings of ice, acid and flames.  Returns false, by default.  Items produced
    /// by this factory will implement the IItemActivatible interface.
    /// </summary>
    public virtual bool Activate { get; set; } = false;
    public virtual bool Aggravate { get; set; } = false;
    public virtual bool AntiTheft { get; set; } = false;
    public virtual bool Blessed { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the blows delivered by the player when being worn.
    /// </summary>
    public virtual bool Blows { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item does extra damage from acid when being wielded.
    /// </summary>
    public virtual bool BrandAcid { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item does extra damage from frost when being wielded.
    /// </summary>
    public virtual bool BrandCold { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item does extra damage from electricity when being wielded.
    /// </summary>
    public virtual bool BrandElec { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item does extra damage from fire when being wielded.
    /// </summary>
    public virtual bool BrandFire { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item poisons foes when being wielded.
    /// </summary>
    public virtual bool BrandPois { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the charisma of the player when being worn.
    /// </summary>
    public virtual bool Cha { get; set; } = false;

    /// <summary>
    /// Returns the depth and 1-in probably for where the item can be found; or null, if the item is not found naturally.  Returns null, by definition.
    /// </summary>
    public virtual (int level, int chance)[]? DepthsFoundAndChances => null;

    /// <summary>
    /// Returns whether or not the item produced chaotic effects when being wielded.
    /// </summary>
    public virtual bool Chaotic { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the constitution of the player when being worn.
    /// </summary>
    public virtual bool Con { get; set; } = false;

    /// <summary>
    /// Returns the real cost of a standard item.  Returns 0 by default.
    /// </summary>
    public virtual int Cost => 0;

    public virtual bool Cursed { get; set; } = false;
    public virtual int DamageDice => 0;

    /// <summary>
    /// Returns whether or not the item affects the dexterity of the player when being worn.
    /// </summary>
    public virtual bool Dex { get; set; } = false;
    public virtual bool DrainExp { get; set; } = false;
    public virtual bool DreadCurse { get; set; } = false;
    public virtual int DamageSides => 0;
    public virtual bool EasyKnow { get; set; } = false;
    public virtual bool Feather { get; set; } = false;
    public virtual bool FreeAct { get; set; } = false;

    public virtual bool HeavyCurse { get; set; } = false;
    public virtual bool HideType { get; set; } = false;
    public virtual bool HoldLife { get; set; } = false;
    public virtual bool IgnoreAcid { get; set; } = false;
    public virtual bool IgnoreCold { get; set; } = false;
    public virtual bool IgnoreElec { get; set; } = false;
    public virtual bool IgnoreFire { get; set; } = false;
    public virtual bool ImAcid { get; set; } = false;
    public virtual bool ImCold { get; set; } = false;
    public virtual bool ImElec { get; set; } = false;
    public virtual bool ImFire { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item causes earthquakes of the player when being worn.
    /// </summary>
    public virtual bool Impact { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the infravision of the player when being worn.
    /// </summary>
    public virtual bool Infra { get; set; } = false;
    public virtual bool InstaArt { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the intelligence of the player when being worn.
    /// </summary>
    public virtual bool Int { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item is a great bane of dragons.
    /// </summary>
    public virtual bool KillDragon { get; set; } = false;

    public virtual bool KindIsGood => false;
    public virtual int LevelNormallyFound => 0;
    public virtual bool Lightsource { get; set; } = false;

    public virtual bool NoMagic { get; set; } = false;
    public virtual bool NoTele { get; set; } = false;
    public virtual bool PermaCurse { get; set; } = false;

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
    /// See <see cref="Game.ParseRoll"/> for syntax details.  This property is used to bind the <see cref="InitialGoldPiecesRoll"/> property during the bind phase.
    /// </summary>
    protected virtual string InitialGoldPieces => "0";

    /// <summary>
    /// Returns a Roll that is used to determine the number of gold pieces that are given to the player when the item is picked up.  This property is bound from the
    /// <see cref="InitialGoldPieces"/> property during the bind phase.
    /// </summary>
    public Roll InitialGoldPiecesRoll { get; private set; }

    public virtual bool Reflect { get; set; } = false;
    public virtual bool Regen { get; set; } = false;
    public virtual bool ResAcid { get; set; } = false;
    public virtual bool ResBlind { get; set; } = false;
    public virtual bool ResChaos { get; set; } = false;
    public virtual bool ResCold { get; set; } = false;
    public virtual bool ResConf { get; set; } = false;
    public virtual bool ResDark { get; set; } = false;
    public virtual bool ResDisen { get; set; } = false;
    public virtual bool ResElec { get; set; } = false;
    public virtual bool ResFear { get; set; } = false;
    public virtual bool ResFire { get; set; } = false;
    public virtual bool ResLight { get; set; } = false;
    public virtual bool ResNether { get; set; } = false;
    public virtual bool ResNexus { get; set; } = false;
    public virtual bool ResPois { get; set; } = false;
    public virtual bool ResShards { get; set; } = false;
    public virtual bool ResSound { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the search capabilities of the player when being worn.
    /// </summary>
    public virtual bool Search { get; set; } = false;

    public virtual bool SeeInvis { get; set; } = false;
    public virtual bool ShElec { get; set; } = false;
    public virtual bool ShFire { get; set; } = false;
    public virtual bool ShowMods { get; set; } = false;
    public virtual bool SlayAnimal { get; set; } = false;
    public virtual bool SlayDemon { get; set; } = false;
    public virtual bool SlayDragon { get; set; } = false;
    public virtual bool SlayEvil { get; set; } = false;
    public virtual bool SlayGiant { get; set; } = false;
    public virtual bool SlayOrc { get; set; } = false;
    public virtual bool SlayTroll { get; set; } = false;
    public virtual bool SlayUndead { get; set; } = false;
    public virtual bool SlowDigest { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the attack speed of the player when being worn.
    /// </summary>
    public virtual bool Speed { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the stealth of the player when being worn.
    /// </summary>
    public virtual bool Stealth { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the strength of the player when being worn.
    /// </summary>
    public virtual bool Str { get; set; } = false;

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

    public virtual bool SustCha { get; set; } = false;
    public virtual bool SustCon { get; set; } = false;
    public virtual bool SustDex { get; set; } = false;
    public virtual bool SustInt { get; set; } = false;
    public virtual bool SustStr { get; set; } = false;
    public virtual bool SustWis { get; set; } = false;
    public virtual bool Telepathy { get; set; } = false;
    public virtual bool Teleport { get; set; } = false;
    public virtual int BonusArmorClass => 0;
    public virtual int BonusDamage => 0;
    public virtual int BonusHit => 0;

    /// <summary>
    /// Returns whether or not the item affects the tunneling capabilities of the player when being worn.
    /// </summary>
    public virtual bool Tunnel { get; set; } = false;

    public virtual bool Vampiric { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item is very sharp and cuts foes of the player when being used.
    /// </summary>
    public virtual bool Vorpal { get; set; } = false;

    public virtual int Weight => 0;

    /// <summary>
    /// Returns whether or not the item affects the wisdom of the player when being worn.
    /// </summary>
    public virtual bool Wis { get; set; } = false;
    public virtual bool Wraith { get; set; } = false;
    public virtual bool XtraMight { get; set; } = false;
    public virtual bool XtraShots { get; set; } = false;

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
}
