// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents an instance of an item.  This item object is universally capable of being any type of object in the game but it also has a
/// single parent (or factory) that controls what type of object the item is.
/// </summary>
[Serializable]
internal sealed class Item : IComparable<Item>
{
    #region State Data - Fields that are maintained
    /// <summary>
    /// Returns true, if the player has sensed the item.  Item characteristics that can be sensed are <see cref="IsCursed"/> and <see cref="IsBroken"/> (maybe <see cref="IsArtifact"/> too?)
    /// </summary>
    public bool IdentSense;

    /// <summary>
    /// This property used to be a flag in the IdentifyFlags.
    /// </summary>
    public bool IdentFixed;

    /// <summary>
    /// This property used to be a flag in the IdentifyFlags.
    /// </summary>
    public bool IdentEmpty;

    /// <summary>
    /// Returns true, if item has been identified; false, otherwise.  This property is near identical to the <see cref="ItemFactory.IsFlavorAware"/>, with the exception that a store will identify an item, 
    /// but the factory for the item may still have the <see cref="ItemFactory.IsFlavorAware"/> still set to false.
    /// </summary>
    public bool IdentityIsKnown;

    /// <summary>
    /// Returns true, if the identity of the item was provided because the item was bought from the store.  This property is used to hide the
    /// flavor name when flavored items are bought from the store.  This prevents the player from learning the flavor by simply buying the item
    /// from the store.  This property used to be a flag in the IdentifyFlags.
    /// </summary>
    public bool IdentityIsStoreBought;

    /// <summary>
    /// This property used to be a flag in the IdentifyFlags.  Do we know anything about the item.
    /// </summary>
    public bool IdentMental;


    /// <summary>
    /// Returns the number of stacked items.
    /// </summary>
    public int StackCount;

    public int Discount;
    public int HoldingMonsterIndex;
    public string Inscription = "";

     /// <summary>
    /// Returns true, if this item has been noticed and/or detected by the player.  Unnoticed items will cause the player to stop running.
    /// </summary>
    public bool WasNoticed = false;

    /// <summary>
    /// Returns the number of turns remaining to recharge the activation.
    /// </summary>
    public int ActivationRechargeTimeRemaining;

    /// <summary>
    /// Returns null if the container is unlocked and can be opened without picking; or an empty array, if a previously trapped container is now disarmed and locked, or an array of traps.
    /// </summary>
    public ChestTrap[]? ContainerTraps = null; // TODO: This doesn't support an open for a trapped container.

    /// <summary>
    /// Returns the level of the objects contained in the chest.
    /// </summary>
    public int LevelOfObjectsInContainer = 0;
    public bool ContainerIsOpen = false;

    public int StaffChargesRemaining = 0;

    /// <summary>
    /// Returns the number of wand charges remaining.
    /// </summary>
    public int WandChargesRemaining = 0;

    public int RodRechargeTimeRemaining = 0;

    public int X;
    public int Y;
    private readonly Game Game;

    // All of these properties are initially set by the Factory.
    public int TurnsOfLightRemaining;

    /// <summary>
    /// Returns the number of gold pieces the item contains.  Applies to gold.
    /// </summary>
    public int GoldPieces;

    /// <summary>
    /// Returns the name the player provided when this item was converted into a random artifact, including an empty string; or null, if the item was never converted into a random artifact.
    /// </summary>
    public string? RandomArtifactName = null;

    public int ArmorClass;

    /// <summary>
    /// Returns true, if the item is broken; false, otherwise.  Broken items are considered worthless, regardless of their other properties.
    /// </summary>
    public bool IsBroken; // TODO: This needs to be moved into IItemCharacteristics
    #endregion

    #region API Methods
    public Item TakeFromStack(int count)
    {
        Item retrievedItem = Clone(count); // This will not take the items from the stack yet.
        ModifyStackCount(-count);
        return retrievedItem;
    }

    /// <summary>
    /// Clone an item and set the stack size.  Used during the purchasing of items from a store to detect if the player can carry the item before it is removed
    /// from inventory.
    /// </summary>
    /// <param name="newCount"></param>
    /// <returns></returns>
    public Item Clone(int? newCount = null) // TODO: Can this be a constructor?
    {
        Item clonedItem = _factory.GenerateItem();
        clonedItem.StackCount = newCount.HasValue ? newCount.Value : 1;

        // TODO: There is no way to ensure a cloned gets all of the properties
        clonedItem.IdentSense = IdentSense;
        clonedItem.IdentFixed = IdentFixed;
        clonedItem.IdentEmpty = IdentEmpty;
        clonedItem.IdentityIsKnown = IdentityIsKnown;
        clonedItem.IdentityIsStoreBought = IdentityIsStoreBought;
        clonedItem.IdentMental = IdentMental;
        clonedItem.EffectivePropertySet = EffectivePropertySet.Clone();
        clonedItem.FixedArtifact = FixedArtifact;
        clonedItem.Discount = Discount;
        clonedItem.HoldingMonsterIndex = HoldingMonsterIndex;
        clonedItem.Inscription = Inscription;
        clonedItem.WasNoticed = WasNoticed;
        clonedItem.ActivationRechargeTimeRemaining = ActivationRechargeTimeRemaining;
        clonedItem.ContainerTraps = ContainerTraps;
        clonedItem.LevelOfObjectsInContainer = LevelOfObjectsInContainer;
        clonedItem.ContainerIsOpen = ContainerIsOpen;
        clonedItem.StaffChargesRemaining = StaffChargesRemaining;
        clonedItem.WandChargesRemaining = WandChargesRemaining;
        clonedItem.RodRechargeTimeRemaining = RodRechargeTimeRemaining;
        clonedItem.X = X;
        clonedItem.Y = Y;
        clonedItem.TurnsOfLightRemaining = TurnsOfLightRemaining;
        clonedItem.GoldPieces = GoldPieces;
        clonedItem.RandomArtifactName = RandomArtifactName;
        clonedItem.ArmorClass = ArmorClass;
        clonedItem.IsBroken = IsBroken;

        return clonedItem;
    }

    public bool CanBeWeaponOfSharpness => _factory.CanBeWeaponOfSharpness;
    public bool CapableOfVorpalSlaying => _factory.CapableOfVorpalSlaying;
    public bool CanBeWeaponOfLaw => _factory.CanBeWeaponOfLaw;

    public WieldSlot[] WieldSlots => _factory.WieldSlots;
    public ColorEnum FlavorColor => _factory.FlavorColor; // TODO: Rename to represent current or assigned
    public Symbol FlavorSymbol => _factory.FlavorSymbol; // TODO: Rename to represent current or assigned

    /// <summary>
    /// Returns a sort order index for sorting items in a pack.  Lower numbers show before higher numbers.
    /// </summary>
    private int PackSort => _factory.PackSort;

    public bool FactoryTried => _factory.Tried;
    public Spell[]? Spells => _factory.Spells;
    public bool CanBeEatenByMonsters => _factory.CanBeEatenByMonsters;
    public int? MaxPhlogiston => _factory.MaxPhlogiston;
    public bool IsMagical => _factory.IsMagical;
    public ItemClass ItemClass => _factory.ItemClass;
    public int MakeObjectCount  => Game.ComputeIntegerExpression(_factory.MakeObjectCount).Value;
    public int LevelNormallyFound => _factory.LevelNormallyFound;
    public int NumberOfItemsContained => _factory.NumberOfItemsContained;
    public int EnchantmentMaximumCount => _factory.EnchantmentMaximumCount;
    public bool IsSmall => _factory.IsSmall;
    public bool AskDestroyAll => _factory.AskDestroyAll;
    public bool VanishesWhenEatenBySkeletons => _factory.VanishesWhenEatenBySkeletons;
    public bool CanSpikeDoorClosed => _factory.CanSpikeDoorClosed;
    public bool IsFuelForTorch => _factory.IsFuelForTorch;
    public bool IsLanternFuel => _factory.IsLanternFuel;
    public ItemFactory[]? AmmunitionItemFactories => _factory.AmmunitionItemFactories;
    public bool CanTunnel => _factory.CanTunnel;
    public int BurnRate => _factory.BurnRate;
    public bool IsWearableOrWieldable => _factory.IsWearableOrWieldable;
    public bool ProvidesSunlight => _factory.ProvidesSunlight;
    public bool CanBeEaten => _factory.CanBeEaten;
    public IScriptItem? EatMagicScript => _factory.EatMagicScript;
    public bool HatesAcid => _factory.HatesAcid;
    public bool HatesCold => _factory.HatesCold;
    public bool HatesElectricity => _factory.HatesElectricity;
    public bool HatesFire => _factory.HatesFire;
    public (IEatOrQuaffScript QuaffScript, ProjectileScript? SmashScript, int ManaEquivalent)? QuaffTuple => _factory.QuaffTuple;
    public (IZapRodScript Script, Expression TurnsToRecharge, bool RequiresAiming, int ManaEquivalent)? ZapTuple => _factory.ZapTuple;
    public (IReadScrollOrUseStaffScript UseScript, Expression InitialCharges, int PerChargeValue, int ManaEquivalent)? UseTuple => _factory.UseTuple;
    public (IAimWandScript ActivationScript, Expression InitialChargesCountRoll, int PerChargeValue, int ManaValue)? AimingTuple => _factory.AimingTuple;
    public (IReadScrollOrUseStaffScript ActivationScript, int ManaValue)? ReadTuple => _factory.ReadTuple;
    public ProbabilityExpression BreakageChanceProbability => _factory.BreakageChanceProbability;
    public int MissileDamageMultiplier => _factory.MissileDamageMultiplier;
    public bool CanBeRead => _factory.CanBeRead;
    public IScriptItemInt? RechargeScript => _factory.RechargeScript;
    public bool CanProjectArrows => _factory.CanProjectArrows;
    public bool IsWeapon => _factory.IsWeapon;
    public bool IsIgnoredByMonsters => _factory.IsIgnoredByMonsters;
    public bool IsArmor => _factory.IsArmor;
    public bool IsContainer => _factory.IsContainer;
    public int ExperienceGainDivisorForDestroying => _factory.ExperienceGainDivisorForDestroying;
    public bool IdentityCanBeSensed => _factory.IdentityCanBeSensed;
    public bool IsConsumedWhenEaten => _factory.IsConsumedWhenEaten;
    public IEatOrQuaffScript? EatScript => _factory.EatScript;
    private bool GetsDamageMultiplier => _factory.GetsDamageMultiplier;
    public bool NegativeBonusDamageRepresentsBroken => _factory.NegativeBonusDamageRepresentsBroken;
    public bool NegativeBonusArmorClassRepresentsBroken => _factory.NegativeBonusArmorClassRepresentsBroken;
    public bool NegativeBonusHitRepresentsBroken => _factory.NegativeBonusHitRepresentsBroken;

    /// <summary>
    /// Returns the nutritional value in turns provided to the player, when eaten.
    /// </summary>
    public int NutritionalValue { get; private set; }

    private int TurnOfLightValue => _factory.ValuePerTurnOfLight;
    private int BaseValue => _factory.BaseValue;
    public Realm Realm => _factory.Realm;

    /// <summary>
    /// Returns true, if the smash effect causes the target to be unfriendly.
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
        ProjectileScript? smashUnfriendlyScript = QuaffTuple.Value.SmashScript;
        if (smashUnfriendlyScript == null)
        {
            return false;
        }
        return smashUnfriendlyScript.ExecuteUnfriendlyScript(who, y, x);
    }

    public bool IsFlavorAware
    {
        get
        {
            return _factory.IsFlavorAware;
        }
        set
        {
            _factory.IsFlavorAware = value;
        }
    }
    public int GetAdditionalMassProduceCount()
    {
        return _factory.GetAdditionalMassProduceCount(this);
    }
    public void Refill()
    {
        _factory.Refill(this);
    }
    public int CalculateTorch()
    {
        return _factory.CalculateTorch(this);
    }
    public bool IsAmmunitionFor(Item rangedWeapon)
    {
        return rangedWeapon.AmmunitionItemFactories != null && rangedWeapon.AmmunitionItemFactories.Contains(_factory);
    }
    public bool IsUsableSpellBook()
    {
        return Game.PrimaryRealm != null && Game.PrimaryRealm.SpellBooks.Contains(_factory) || Game.SecondaryRealm != null && Game.SecondaryRealm.SpellBooks.Contains(_factory);
    }
    public void GridProcessWorld(GridTile gridTile)
    {
        _factory.GridProcessWorld(this, gridTile);
    }
    public void PackProcessWorld()
    {
        _factory.PackProcessWorld(this);
    }
    public void EquipmentProcessWorld()
    {
        _factory.EquipmentProcessWorld(this);
    }
    public void MonsterProcessWorld(Monster mPtr)
    {
        _factory.MonsterProcessWorld(this, mPtr);
    }

    /// <summary>
    /// Returns the container that is holding the item.
    /// </summary>
    public IItemContainer GetContainer()
    {
        // Check to see if the item is in the players inventory.
        foreach (WieldSlot inventorySlot in Game.SingletonRepository.Get<WieldSlot>())
        {
            foreach (int slot in inventorySlot.InventorySlots)
            {
                if (Game.GetInventoryItem(slot) == this)
                {
                    return inventorySlot;
                }
            }
        }

        // Check to see if a monster is holding the item.
        if (HoldingMonsterIndex != 0)
        {
            return Game.Monsters[HoldingMonsterIndex];
        }

        // Check to see if the item in on the floor.
        if (X != 0 && Y != 0)
        {
            return Game.Map.Grid[Y][X];
        }

        // Something is wrong.
        throw new Exception("Missing item container.");
    }

    public string Label
    {
        get
        {
            IItemContainer container = GetContainer();
            return container.Label(this);
        }
    }

    public string DescribeLocation()
    {
        IItemContainer container = GetContainer();
        return container.DescribeItemLocation(this);
    }

    /// <summary>
    /// Modifies the quantity of an item.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <param name="num"></param>
    public void ModifyStackCount(int num)
    {
        num += StackCount;
        if (num >= Constants.MaxStackSize)
        {
            num = Constants.MaxStackSize - 1;
        }
        else if (num < 0)
        {
            num = 0;
        }
        num -= StackCount;
        StackCount += num;
    }

    /// <summary>
    /// Renders a description of the item.  For a wield slot, the description is rendered as possessive; non-wield slots, render as the player is viewing the item.
    /// </summary>
    /// <param name="item"></param>
    public void ItemDescribe()
    {
        IItemContainer? container = GetContainer();
        if (container == null)
        {
            throw new Exception("Missing item container.");
        }
        string containerDescription = container.DescribeContainer(this);
        Game.MsgPrint(containerDescription);
    }

    /// <summary>
    /// Checks the quantity of an item and removes it, when the quanity is zero.  This process differs depending on which container is containing the item.
    /// </summary>
    /// <param name="oPtr"></param>
    public void ItemOptimize()
    {
        IItemContainer container = GetContainer();
        container.ItemOptimize(this);
    }

    /// <summary>
    /// Returns true, if the container is part of the players inventory.  All wield slots (pack & equipment), return true; monsters and grid tiles return false.
    /// </summary>
    public bool IsInInventory
    {
        get
        {
            IItemContainer container = GetContainer();
            return container.IsWielded;
        }
    }

    /// <summary>
    /// Returns true, if the container is part of the players inventory.  All inventory slots (pack & equipment), return true; monsters and grid tiles return false.
    /// </summary>
    public bool IsInEquipment
    {
        get
        {
            IItemContainer container = GetContainer();
            return container.IsWieldedAsEquipment;
        }
    }

    public string TakeOffMessage
    {
        get
        {
            IItemContainer? container = GetContainer();
            if (container == null)
            {
                throw new Exception("Missing item container.");
            }
            return container.TakeOffMessage(this);
        }
    }

    /// <summary>
    /// Attempts to wield the item in the first available wield slot and return true, if successful; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool Wield()
    {
        if (WieldSlots.Length == 0)
        {
            return false;
        }

        foreach (WieldSlot wieldSlot in WieldSlots)
        {
            if (wieldSlot.Count < wieldSlot.MaximumItemSlots)
            {
                // Wield only 1 item from a stack.
                wieldSlot.AddItem(TakeFromStack(1));
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Returns a clone of the item that has been taken off; or null, if the amount <= 0, or the item cannot be carries, for which it is gone. 
    /// </summary>
    /// <param name="oPtr"></param>
    /// <param name="amt"></param>
    /// <returns></returns>
    public Item? Takeoff(int amt)
    {
        string act;
        if (amt <= 0)
        {
            return null;
        }
        if (amt > StackCount)
        {
            amt = StackCount;
        }
        Item qPtr = TakeFromStack(amt);
        string oName = qPtr.GetFullDescription(true);
        act = TakeOffMessage;
        ItemOptimize();
        Item? newItem = Game.InventoryCarry(qPtr);
        if (newItem == null)
        {
            Game.MsgPrint("Failed to carry item."); // TODO: Need to prevent this
            return null;
        }
        Game.MsgPrint($"{act} {oName} ({newItem.Label}).");
        return newItem;
    }

    /// <summary>
    /// Returns true, if the item can be carried; false, otherwise.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public bool CanCarry()
    {
        if (Game._invenCnt < InventorySlotEnum.PackCount)
        {
            return true;
        }
        for (int j = 0; j < InventorySlotEnum.PackCount; j++)
        {
            Item? jPtr = Game.GetInventoryItem(j);
            if (jPtr == null)
            {
                continue;
            }
            if (jPtr.CanAbsorb(this))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Compares two items for sorting.  Returns -1, if this item sorts before the oPtr item; 1, if this item sorts after or 0 if they are equivalent.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public int CompareTo(Item oPtr)
    {
        // First level sort (primary realm spells books).
        // A book that matches the first realm, will always come before a book that doesn't match the first realm.
        if (Spells != null && oPtr.Spells != null)
        {
            if (Realm == Game.PrimaryRealm && oPtr.Realm != Game.PrimaryRealm)
            {
                return -1;
            }
            if (Realm != Game.PrimaryRealm && oPtr.Realm == Game.PrimaryRealm)
            {
                return 1;
            }

            // Second level sort (secondary realm spell books).
            // A book that matches the second realm, will always come before a book that doesn't match the second realm.
            if (Realm == Game.SecondaryRealm && oPtr.Realm != Game.SecondaryRealm)
            {
                return 1;
            }
            if (Realm != Game.SecondaryRealm && oPtr.Realm == Game.SecondaryRealm)
            {
                return -1;
            }
        }

        // Third level sort (category, in reverse order).
        // Sort items by their pack sort order.
        if (PackSort < oPtr.PackSort)
        {
            return -1;
        }
        if (PackSort > oPtr.PackSort)
        {
            return 1;
        }

        // Fourth level sort (FlavorAware before those unidentified)
        // Flavor aware items sort before those not identified.
        if (IsFlavorAware && !oPtr.IsFlavorAware)
        {
            return -1;
        }
        if (!IsFlavorAware && oPtr.IsFlavorAware)
        {
            return 1;
        }

        //// Fifth level sort (subcategory).
        //// Sort items by their subcategory, in ascending order.
        //if (Factory.PerCategorySortOrder < oPtr.Factory.PerCategorySortOrder)
        //{
        //    return -1;
        //}
        //if (Factory.PerCategorySortOrder > oPtr.Factory.PerCategorySortOrder)
        //{
        //    return 1;
        //}

        // Sixth level sort (known before unknown).
        if (IsKnown() && !oPtr.IsKnown())
        {
            return -1;
        }
        if (!IsKnown() && oPtr.IsKnown())
        {
            return 1;
        }

        // Seventh level sort (rods with shortest recharge time).
        if (RodRechargeTimeRemaining < oPtr.RodRechargeTimeRemaining)
        {
            return -1;
        }
        if (RodRechargeTimeRemaining > oPtr.RodRechargeTimeRemaining)
        {
            return 1;
        }

        // Eigth level sort (greater value over less value).
        if (Value() > oPtr.Value())
        {
            return 1;
        }
        if (Value() < oPtr.Value())
        {
            return -1;
        }

        // They are equal.
        return 0;
    }

    /// <summary>
    /// Returns true, if the item is both known and an artifact (fixed or random); false, otherwise.
    /// </summary>
    public bool IsKnownArtifact => IsKnown() && IsArtifact;

    /// <summary>
    /// Returns true, if the item is an artifact (fixed or random); false, otherwise.
    /// </summary>
    public bool IsArtifact => FixedArtifact != null || IsRandomArtifact;

    /// <summary>
    /// Returns true, if the item is a random artifact; false, otherwise.
    /// </summary>
    public bool IsRandomArtifact => RandomArtifactName != null;

    /// <summary>
    /// Takes an item that is the same <see cref="CanAbsorb"/> and adds it.  The original item <paramref name="other"/> is not changed.
    /// </summary>
    /// <param name="other"></param>
    public void Absorb(Item other)
    {
        ModifyStackCount(other.StackCount);
        other.TakeFromStack(other.StackCount);
        if (other.IsKnown())
        {
            BecomeKnown();
        }
        if (!IdentityIsStoreBought || !other.IdentityIsStoreBought)
        {
            other.IdentityIsStoreBought = false;
        }
        if (other.IdentMental)
        {
            IdentMental = true;
        }
        if (!string.IsNullOrEmpty(other.Inscription))
        {
            Inscription = other.Inscription;
        }
        if (Discount < other.Discount)
        {
            Discount = other.Discount;
        }
    }

    public int AdjustDamageForMonsterType(int tdam, Monster mPtr)
    {
        int mult = 1;
        MonsterRace rPtr = mPtr.Race;
        if (GetsDamageMultiplier)
        {
            if (EffectivePropertySet.SlayAnimal && rPtr.Animal)
            {
                if (mPtr.IsVisible)
                {
                    rPtr.Knowledge.Characteristics.Animal = true;
                }
                if (mult < 2)
                {
                    mult = 2;
                }
            }
            if (EffectivePropertySet.SlayEvil && rPtr.Evil)
            {
                if (mPtr.IsVisible)
                {
                    rPtr.Knowledge.Characteristics.Evil = true;
                }
                if (mult < 2)
                {
                    mult = 2;
                }
            }
            if (EffectivePropertySet.SlayUndead && rPtr.Undead)
            {
                if (mPtr.IsVisible)
                {
                    rPtr.Knowledge.Characteristics.Undead = true;
                }
                if (mult < 3)
                {
                    mult = 3;
                }
            }
            if (EffectivePropertySet.SlayDemon && rPtr.Demon)
            {
                if (mPtr.IsVisible)
                {
                    rPtr.Knowledge.Characteristics.Demon = true;
                }
                if (mult < 3)
                {
                    mult = 3;
                }
            }
            if (EffectivePropertySet.SlayOrc && rPtr.Orc)
            {
                if (mPtr.IsVisible)
                {
                    rPtr.Knowledge.Characteristics.Orc = true;
                }
                if (mult < 3)
                {
                    mult = 3;
                }
            }
            if (EffectivePropertySet.SlayTroll && rPtr.Troll)
            {
                if (mPtr.IsVisible)
                {
                    rPtr.Knowledge.Characteristics.Troll = true;
                }
                if (mult < 3)
                {
                    mult = 3;
                }
            }
            if (EffectivePropertySet.SlayGiant && rPtr.Giant)
            {
                if (mPtr.IsVisible)
                {
                    rPtr.Knowledge.Characteristics.Giant = true;
                }
                if (mult < 3)
                {
                    mult = 3;
                }
            }
            if (rPtr.Dragon)
            {
                if (mPtr.IsVisible)
                {
                    rPtr.Knowledge.Characteristics.Dragon = true;
                }
                if (mult < EffectivePropertySet.SlayDragon)
                {
                    mult = EffectivePropertySet.SlayDragon;
                }
            }
            if (EffectivePropertySet.BrandAcid)
            {
                if (rPtr.ImmuneAcid)
                {
                    if (mPtr.IsVisible)
                    {
                        rPtr.Knowledge.Characteristics.ImmuneAcid = true;
                    }
                }
                else
                {
                    if (mult < 3)
                    {
                        mult = 3;
                    }
                }
            }
            if (EffectivePropertySet.BrandElec)
            {
                if (rPtr.ImmuneLightning)
                {
                    if (mPtr.IsVisible)
                    {
                        rPtr.Knowledge.Characteristics.ImmuneLightning = true;
                    }
                }
                else
                {
                    if (mult < 3)
                    {
                        mult = 3;
                    }
                }
            }
            if (EffectivePropertySet.BrandFire)
            {
                if (rPtr.ImmuneFire)
                {
                    if (mPtr.IsVisible)
                    {
                        rPtr.Knowledge.Characteristics.ImmuneFire = true;
                    }
                }
                else
                {
                    if (mult < 3)
                    {
                        mult = 3;
                    }
                }
            }
            if (EffectivePropertySet.BrandCold)
            {
                if (rPtr.ImmuneCold)
                {
                    if (mPtr.IsVisible)
                    {
                        rPtr.Knowledge.Characteristics.ImmuneCold = true;
                    }
                }
                else
                {
                    if (mult < 3)
                    {
                        mult = 3;
                    }
                }
            }
            if (EffectivePropertySet.BrandPois)
            {
                if (rPtr.ImmunePoison)
                {
                    if (mPtr.IsVisible)
                    {
                        rPtr.Knowledge.Characteristics.ImmunePoison = true;
                    }
                }
                else
                {
                    if (mult < 3)
                    {
                        mult = 3;
                    }
                }
            }
        }
        return tdam * mult;
    }

    public void BecomeKnown()
    {
        if (!string.IsNullOrEmpty(Inscription) && IdentSense)
        {
            string q = Inscription;
            if (q == "cursed" || q == "broken" || q == "good" || q == "average" || q == "excellent" ||
                q == "worthless" || q == "special" || q == "terrible")
            {
                Inscription = string.Empty;
            }
        }
        IdentSense = false;
        IdentEmpty = false;
        IdentityIsKnown = true;
    }

    /// <summary>
    /// Returns true, if two objects are identical and can be grouped together in inventory listings (e.g. 5 wooden torches).
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool CanAbsorb(Item other)
    {
        // Ensure both items belong to the same factory.  This works because factories are singletons.  Items from different factories cannot
        // be merged.
        if (_factory != other._factory)
        {
            return false;
        }

        if (EffectivePropertySet != other.EffectivePropertySet)
        {
            return false;
        }

        // The known status must be the same.
        if (IsKnown() != other.IsKnown())
        {
            return false;
        }

        // Only open chests can be combined; otherwise, chests are never combined.
        if (IsContainer && !ContainerIsOpen || other.IsContainer && !other.ContainerIsOpen)
        {
            return false;
        }
        if (NumberOfItemsContained != other.NumberOfItemsContained)
        {
            return false;
        }

        // TODO: Each of these belong to the factory
        if (StaffChargesRemaining != other.StaffChargesRemaining)
        {
            return false;
        }

        if (WandChargesRemaining != other.WandChargesRemaining)
        {
            return false;
        }

        // Items need to have the same nutritional value.  Normally, this would always be true, but nutritional values may become variable.  Taking a bite of something.
        if (NutritionalValue != other.NutritionalValue)
        {
            return false;
        }

        // Items that have turns of light need to have the same number of turns, to be mergable.  E.g. 5 Wooden Torches (2500 turns)
        if (TurnsOfLightRemaining != other.TurnsOfLightRemaining)
        {
            return false;
        }
        if (IsArtifact != other.IsArtifact)
        {
            return false;
        }
        if (ActivationRechargeTimeRemaining != 0 || other.ActivationRechargeTimeRemaining != 0)
        {
            return false;
        }
        if (RodRechargeTimeRemaining != 0 || other.RodRechargeTimeRemaining != 0)
        {
            return false;
        }
        if (ArmorClass != other.ArmorClass)
        {
            return false;
        }
        if (IsRandomArtifact || other.IsRandomArtifact)
        {
            return false;
        }
        if (IsBroken != other.IsBroken)
        {
            return false;
        }
        if (Inscription != other.Inscription)
        {
            return false;
        }
        if (Discount != other.Discount)
        {
            return false;
        }
        if (IdentityIsStoreBought != other.IdentityIsStoreBought)
        {
            return false;
        }

        int total = StackCount + other.StackCount;
        return total < Constants.MaxStackSize;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="includeCountPrefix">Specify true, to prefix the description with the number of items (e.g. 5 Brown Dragon Scale Mails);
    /// false, otherwise (e.g. Brown Dragon Scale Mails).  When false, the item will still be pluralized (e.g. stole one of your Brown Dragon Scale Mails).</param>
    /// <param name="mode"></param>
    /// <returns></returns>
    public string GetDescription(bool includeCountPrefix)
    {
        string basenm = _factory.GetDescription(this, includeCountPrefix);
        if (IsKnown())
        {
            if (IsRandomArtifact)
            {
                basenm += ' ';
                basenm += RandomArtifactName;
            }
            else if (FixedArtifact != null)
            {
                basenm = FixedArtifact.Name;
            }
            else if (EffectivePropertySet.FriendlyName != null)
            {
                basenm = $"{basenm} {EffectivePropertySet.FriendlyName}";
            }
        }
        return basenm;
    }

    /// <summary>
    /// Returns an additional description to fully identify the item that is appended to the verbode description, when needed.  
    /// By default, returns the description for inscriptions, cursed, empty, tried and on discount.
    /// </summary>
    /// <returns></returns>
    public string GetFullDescription(bool includeCountPrefix)
    {
        string basenm = GetDescription(includeCountPrefix);
        basenm += _factory.GetDetailedDescription(this);
        basenm += _factory.GetVerboseDescription(this);

        // This is the full description.
        string fullDescription = "";
        if (!string.IsNullOrEmpty(Inscription))
        {
            fullDescription = Inscription;
        }
        else if (EffectivePropertySet.IsCursed && (IsKnown() || IdentSense))
        {
            fullDescription = "cursed";
        }
        else if (!IsKnown() && IdentEmpty)
        {
            fullDescription = "empty";
        }
        else if (!IsFlavorAware && FactoryTried)
        {
            fullDescription = "tried";
        }
        else if (Discount != 0)
        {
            fullDescription = $"{Discount}% off";
        }
        if (!string.IsNullOrEmpty(fullDescription))
        {
            basenm += $" {{{fullDescription}}}";
        }

        // We can only render 75 characters max ... we are forced to truncate.
        if (basenm.Length > 75)
        {
            basenm = basenm.Substring(0, 75);
        }
        return basenm;
    }

    /// <summary>
    /// Returns a quality rating for the item using the following algorithm.  The rating tests are performed in order, and the rating is returned when the test matches.
    /// 1. If the ItemFactory indicates that items do not have quality rating <see cref="ItemFactory.HasQualityRatings"/>, the <see cref="BrokenItemQualityRating"/> is returned.
    /// 2. If the item is an artifact (fixed or random), the <see cref="SpecialItemQualityRating"/> is returned; unless the item is cursed or broken, for which the <see cref="TerribleItemQualityRating"/> is returned.
    /// 3. If the item is rare, the <see cref="ExcellentItemQualityRating"/> is returned; unless the item is cursed or broken, for which the <see cref="WorthlessItemQualityRating"/> is returned.
    /// 4. If the item <see cref="IsCursed"/>, the <see cref="CursedItemQualityRating"/> is returned.
    /// 5. If the item <see cref="IsBroken"/>, or the <see cref="Characteristics.BonusDamage"/>, <see cref="Characteristics.BonusHit"/> or <see cref="Characteristics.BonusArmorClass"/> are less than zero, the <see cref="BrokenItemQualityRating"/> is returned.
    /// 6. If the <see cref="Characteristics.BonusDamage"/>, <see cref="Characteristics.BonusHit"/> or <see cref="Characteristics.BonusArmorClass"/> is greater than 0, then the <see cref="GoodItemQualityRating"/> is returned.
    /// 7. The <see cref="AverageItemQualityRating"/> is returned.
    /// </summary>
    /// <returns></returns>
    public ItemQualityRating GetQualityRating()
    {
        if (!_factory.HasQualityRatings)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(BrokenItemQualityRating));
        }

        if (IsArtifact)
        {
            if (EffectivePropertySet.IsCursed || IsBroken)
            {
                return Game.SingletonRepository.Get<ItemQualityRating>(nameof(TerribleItemQualityRating));
            }
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(SpecialItemQualityRating));
        }
        if (IsRare)
        {
            if (EffectivePropertySet.IsCursed || IsBroken)
            {
                return Game.SingletonRepository.Get<ItemQualityRating>(nameof(WorthlessItemQualityRating));
            }
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(ExcellentItemQualityRating));
        }

        if (EffectivePropertySet.IsCursed)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(CursedItemQualityRating));
        }

        if (IsBroken)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(BrokenItemQualityRating));
        }
        if (NegativeBonusDamageRepresentsBroken && EffectivePropertySet.BonusDamage < 0)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(BrokenItemQualityRating));
        }
        if (NegativeBonusArmorClassRepresentsBroken && EffectivePropertySet.BonusArmorClass < 0)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(BrokenItemQualityRating));
        }
        if (NegativeBonusHitRepresentsBroken && EffectivePropertySet.BonusHits < 0)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(BrokenItemQualityRating));
        }

        if (EffectivePropertySet.BonusArmorClass > 0 || EffectivePropertySet.BonusHits + EffectivePropertySet.BonusDamage > 0)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(GoodItemQualityRating));
        }

        return Game.SingletonRepository.Get<ItemQualityRating>(nameof(AverageItemQualityRating));
    }

    public string GetDetailedFeeling()
    {
        return GetQualityRating().Description;
    }

    public ItemQualityRating? GetVagueQualityRating()
    {
        if (EffectivePropertySet.IsCursed)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(CursedItemQualityRating));
        }
        if (IsBroken)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(BrokenItemQualityRating));
        }
        if (IsArtifact)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(SpecialItemQualityRating));
        }
        if (IsRare)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(GoodItemQualityRating));
        }
        if (EffectivePropertySet.BonusArmorClass > 0)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(GoodItemQualityRating));
        }
        if (EffectivePropertySet.BonusHits + EffectivePropertySet.BonusDamage > 0)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(GoodItemQualityRating));
        }
        return null;
    }

    public bool IdentifyFully()
    {
        int i = 0, j, k;
        string[] info = new string[128];
        if (EffectivePropertySet.Activation != null)
        {
            info[i++] = "It can be activated for...";
            info[i++] = EffectivePropertySet.Activation.Description;
            info[i++] = "...if it is being worn.";
        }
        if (EffectivePropertySet.ArtifactBias != null)
        {
            info[i++] = $"It has an affinity for {EffectivePropertySet.ArtifactBias.AffinityName.ToLower()}.";
        }
        if (EffectivePropertySet.BonusStrength > 0)
        {
            info[i++] = "It affects your strength.";
        }
        if (EffectivePropertySet.BonusIntelligence > 0)
        {
            info[i++] = "It affects your intelligence.";
        }
        if (EffectivePropertySet.BonusWisdom > 0)
        {
            info[i++] = "It affects your wisdom.";
        }
        if (EffectivePropertySet.BonusDexterity > 0)
        {
            info[i++] = "It affects your dexterity.";
        }
        if (EffectivePropertySet.BonusConstitution > 0)
        {
            info[i++] = "It affects your constitution.";
        }
        if (EffectivePropertySet.BonusCharisma > 0)
        {
            info[i++] = "It affects your charisma.";
        }
        if (EffectivePropertySet.BonusStealth > 0)
        {
            info[i++] = "It affects your stealth.";
        }
        if (EffectivePropertySet.BonusSearch > 0)
        {
            info[i++] = "It affects your searching.";
        }
        if (EffectivePropertySet.BonusInfravision > 0)
        {
            info[i++] = "It affects your infravision.";
        }
        if (EffectivePropertySet.BonusTunnel > 0)
        {
            info[i++] = "It affects your ability to tunnel.";
        }
        if (EffectivePropertySet.BonusSpeed > 0)
        {
            info[i++] = "It affects your movement speed.";
        }
        if (EffectivePropertySet.BonusAttacks > 0)
        {
            info[i++] = "It affects your attack speed.";
        }
        if (EffectivePropertySet.BrandAcid)
        {
            info[i++] = "It does extra damage from acid.";
        }
        if (EffectivePropertySet.BrandElec)
        {
            info[i++] = "It does extra damage from electricity.";
        }
        if (EffectivePropertySet.BrandFire)
        {
            info[i++] = "It does extra damage from fire.";
        }
        if (EffectivePropertySet.BrandCold)
        {
            info[i++] = "It does extra damage from frost.";
        }
        if (EffectivePropertySet.BrandPois)
        {
            info[i++] = "It poisons your foes.";
        }
        if (EffectivePropertySet.Chaotic)
        {
            info[i++] = "It produces chaotic effects.";
        }
        if (EffectivePropertySet.Vampiric)
        {
            info[i++] = "It drains life from your foes.";
        }
        if (EffectivePropertySet.Impact)
        {
            info[i++] = "It can cause earthquakes.";
        }

        if (EffectivePropertySet.Radius > 0)
        {
            string burnRate = BurnRate == 0 ? "forever" : "when fueled";
            info[i++] = $"It provides light (radius {EffectivePropertySet.Radius}) {burnRate}.";
        }

        if (EffectivePropertySet.Vorpal1InChance > 0)
        {
            info[i++] = "It is very sharp and can cut your foes.";
        }
        if (EffectivePropertySet.SlayDragon > 3)
        {
            info[i++] = "It is a great bane of dragons.";
        }
        else if (EffectivePropertySet.SlayDragon > 1)
        {
            info[i++] = "It is especially deadly against dragons.";
        }
        if (EffectivePropertySet.SlayOrc)
        {
            info[i++] = "It is especially deadly against orcs.";
        }
        if (EffectivePropertySet.SlayTroll)
        {
            info[i++] = "It is especially deadly against trolls.";
        }
        if (EffectivePropertySet.SlayGiant)
        {
            info[i++] = "It is especially deadly against giants.";
        }
        if (EffectivePropertySet.SlayDemon)
        {
            info[i++] = "It strikes at demons with holy wrath.";
        }
        if (EffectivePropertySet.SlayUndead)
        {
            info[i++] = "It strikes at undead with holy wrath.";
        }
        if (EffectivePropertySet.SlayEvil)
        {
            info[i++] = "It fights against evil with holy fury.";
        }
        if (EffectivePropertySet.SlayAnimal)
        {
            info[i++] = "It is especially deadly against natural creatures.";
        }
        if (EffectivePropertySet.SustStr)
        {
            info[i++] = "It sustains your strength.";
        }
        if (EffectivePropertySet.SustInt)
        {
            info[i++] = "It sustains your intelligence.";
        }
        if (EffectivePropertySet.SustWis)
        {
            info[i++] = "It sustains your wisdom.";
        }
        if (EffectivePropertySet.SustDex)
        {
            info[i++] = "It sustains your dexterity.";
        }
        if (EffectivePropertySet.SustCon)
        {
            info[i++] = "It sustains your constitution.";
        }
        if (EffectivePropertySet.SustCha)
        {
            info[i++] = "It sustains your charisma.";
        }
        if (EffectivePropertySet.ImAcid)
        {
            info[i++] = "It provides immunity to acid.";
        }
        if (EffectivePropertySet.ImElec)
        {
            info[i++] = "It provides immunity to electricity.";
        }
        if (EffectivePropertySet.ImFire)
        {
            info[i++] = "It provides immunity to fire.";
        }
        if (EffectivePropertySet.ImCold)
        {
            info[i++] = "It provides immunity to cold.";
        }
        if (EffectivePropertySet.FreeAct)
        {
            info[i++] = "It provides immunity to paralysis.";
        }
        if (EffectivePropertySet.HoldLife)
        {
            info[i++] = "It provides resistance to life draining.";
        }
        if (EffectivePropertySet.ResFear)
        {
            info[i++] = "It makes you completely fearless.";
        }
        if (EffectivePropertySet.ResAcid)
        {
            info[i++] = "It provides resistance to acid.";
        }
        if (EffectivePropertySet.ResElec)
        {
            info[i++] = "It provides resistance to electricity.";
        }
        if (EffectivePropertySet.ResFire)
        {
            info[i++] = "It provides resistance to fire.";
        }
        if (EffectivePropertySet.ResCold)
        {
            info[i++] = "It provides resistance to cold.";
        }
        if (EffectivePropertySet.ResPois)
        {
            info[i++] = "It provides resistance to poison.";
        }
        if (EffectivePropertySet.ResLight)
        {
            info[i++] = "It provides resistance to light.";
        }
        if (EffectivePropertySet.ResDark)
        {
            info[i++] = "It provides resistance to dark.";
        }
        if (EffectivePropertySet.ResBlind)
        {
            info[i++] = "It provides resistance to blindness.";
        }
        if (EffectivePropertySet.ResConf)
        {
            info[i++] = "It provides resistance to confusion.";
        }
        if (EffectivePropertySet.ResSound)
        {
            info[i++] = "It provides resistance to sound.";
        }
        if (EffectivePropertySet.ResShards)
        {
            info[i++] = "It provides resistance to shards.";
        }
        if (EffectivePropertySet.ResNether)
        {
            info[i++] = "It provides resistance to nether.";
        }
        if (EffectivePropertySet.ResNexus)
        {
            info[i++] = "It provides resistance to nexus.";
        }
        if (EffectivePropertySet.ResChaos)
        {
            info[i++] = "It provides resistance to chaos.";
        }
        if (EffectivePropertySet.ResDisen)
        {
            info[i++] = "It provides resistance to disenchantment.";
        }
        if (EffectivePropertySet.Wraith)
        {
            info[i++] = "It renders you incorporeal.";
        }
        if (EffectivePropertySet.Feather)
        {
            info[i++] = "It allows you to levitate.";
        }
        if (EffectivePropertySet.Radius > 0 && BurnRate == 0)
        {
            info[i++] = "It provides permanent light.";
        }
        if (EffectivePropertySet.SeeInvis)
        {
            info[i++] = "It allows you to see invisible monsters.";
        }
        if (EffectivePropertySet.Telepathy)
        {
            info[i++] = "It gives telepathic powers.";
        }
        if (EffectivePropertySet.SlowDigest)
        {
            info[i++] = "It slows your metabolism.";
        }
        if (EffectivePropertySet.Regen)
        {
            info[i++] = "It speeds your regenerative powers.";
        }
        if (EffectivePropertySet.Reflect)
        {
            info[i++] = "It reflects bolts and arrows.";
        }
        if (EffectivePropertySet.ShFire)
        {
            info[i++] = "It produces a fiery sheath.";
        }
        if (EffectivePropertySet.ShElec)
        {
            info[i++] = "It produces an electric sheath.";
        }
        if (EffectivePropertySet.NoMagic)
        {
            info[i++] = "It produces an anti-magic shell.";
        }
        if (EffectivePropertySet.NoTele)
        {
            info[i++] = "It prevents teleportation.";
        }
        if (EffectivePropertySet.XtraMight)
        {
            info[i++] = "It fires missiles with extra might.";
        }
        if (EffectivePropertySet.XtraShots)
        {
            info[i++] = "It fires missiles excessively fast.";
        }
        if (EffectivePropertySet.DrainExp)
        {
            info[i++] = "It drains experience.";
        }
        if (EffectivePropertySet.Teleport)
        {
            info[i++] = "It induces random teleportation.";
        }
        if (EffectivePropertySet.Aggravate)
        {
            info[i++] = "It aggravates nearby creatures.";
        }
        if (EffectivePropertySet.Blessed)
        {
            info[i++] = "It has been blessed by the gods.";
        }
        if (EffectivePropertySet.IsCursed)
        {
            if (EffectivePropertySet.PermaCurse)
            {
                info[i++] = "It is permanently cursed.";
            }
            else if (EffectivePropertySet.HeavyCurse)
            {
                info[i++] = "It is heavily cursed.";
            }
            else
            {
                info[i++] = "It is cursed.";
            }
        }
        if (EffectivePropertySet.DreadCurse)
        {
            info[i++] = "It carries an ancient foul curse.";
        }
        if (EffectivePropertySet.IgnoreAcid)
        {
            info[i++] = "It cannot be harmed by acid.";
        }
        if (EffectivePropertySet.IgnoreElec)
        {
            info[i++] = "It cannot be harmed by electricity.";
        }
        if (EffectivePropertySet.IgnoreFire)
        {
            info[i++] = "It cannot be harmed by fire.";
        }
        if (EffectivePropertySet.IgnoreCold)
        {
            info[i++] = "It cannot be harmed by cold.";
        }
        if (i == 0)
        {
            return false;
        }
        ScreenBuffer savedScreen = Game.Screen.Clone();
        for (k = 1; k < 24; k++)
        {
            Game.Screen.PrintLine("", k, 13);
        }
        Game.Screen.PrintLine("     Item Attributes:", 1, 15);
        for (k = 2, j = 0; j < i; j++)
        {
            Game.Screen.PrintLine(info[j], k++, 15);
            if (k == 22 && j + 1 < i)
            {
                Game.Screen.PrintLine("-- more --", k, 15);
                Game.Inkey();
                for (; k > 2; k--)
                {
                    Game.Screen.PrintLine("", k, 15);
                }
            }
        }
        Game.Screen.PrintLine("[Press any key to continue]", k, 15);
        Game.Inkey();
        Game.Screen.Restore(savedScreen);
        return true;
    }

    public bool IsKnown()
    {
        if (IdentityIsKnown)
        {
            return true;
        }
        if (EffectivePropertySet.EasyKnow && IsFlavorAware)
        {
            return true;
        }
        return false;
    }

    public bool IsRare => EffectivePropertySet.HasKeyedItemEnhancements("rare");

    public EffectivePropertySet ObjectFlagsKnown()
    {
        if (!IsKnown())
        {
            return new EffectivePropertySet();
        }
        return EffectivePropertySet;
    }

    /// <summary>
    /// Indicate that the item has been tried.
    /// </summary>
    public void ObjectTried() // TODO: This needs to be better named.
    {
        _factory.Tried = true;

    }

    /// <summary>
    /// Returns the actual value of the item.  This real value may not be known, if the item is unknown.  This real value is also used by the Alchemy script to convert the item into gold.
    /// </summary>
    /// <returns></returns>
    public int GetRealValue()
    {
        // If the factory reports the item as valueless, then the item is valueless.
        if (EffectivePropertySet.Valueless)
        {
            return 0;
        }

        int value = EffectivePropertySet.Cost;
        if (EffectivePropertySet.Chaotic)
        {
            value += Game.BonusChaoticValue;
        }
        if (EffectivePropertySet.Vampiric)
        {
            value += Game.BonusVampiricValue;
        }
        if (EffectivePropertySet.AntiTheft)
        {
            value += Game.BonusAntiTheftValue;
        }
        if (EffectivePropertySet.SlayAnimal)
        {
            value += Game.BonusSlayAnimalValue;
        }
        if (EffectivePropertySet.SlayEvil)
        {
            value += Game.BonusSlayEvilValue;
        }
        if (EffectivePropertySet.SlayUndead)
        {
            value += Game.BonusSlayUndeadValue;
        }
        if (EffectivePropertySet.SlayDemon)
        {
            value += Game.BonusSlayDemonValue;
        }
        if (EffectivePropertySet.SlayOrc)
        {
            value += Game.BonusSlayOrcValue;
        }
        if (EffectivePropertySet.SlayTroll)
        {
            value += Game.BonusSlayTrollValue;
        }
        if (EffectivePropertySet.SlayGiant)
        {
            value += Game.BonusSlayGiantlValue;
        }
        value += EffectivePropertySet.SlayDragon * Game.BonusSlayDragonValue;
        if (EffectivePropertySet.Vorpal1InChance > 0)
        {
            value += Game.BonusVorpalValue;
        }
        if (EffectivePropertySet.Impact)
        {
            value += Game.BonusImpactValue;
        }
        if (EffectivePropertySet.BrandPois)
        {
            value += Game.BonusBrandPoisValue;
        }
        if (EffectivePropertySet.BrandAcid)
        {
            value += Game.BonusBrandAcidValue;
        }
        if (EffectivePropertySet.BrandElec)
        {
            value += Game.BonusBrandElecValue;
        }
        if (EffectivePropertySet.BrandFire)
        {
            value += Game.BonusBrandFireValue;
        }
        if (EffectivePropertySet.BrandCold)
        {
            value += Game.BonusBrandColdValue;
        }
        if (EffectivePropertySet.SustStr)
        {
            value += Game.BonusSustStrValue;
        }
        if (EffectivePropertySet.SustInt)
        {
            value += Game.BonusSustIntValue;
        }
        if (EffectivePropertySet.SustWis)
        {
            value += Game.BonusSustWisValue;
        }
        if (EffectivePropertySet.SustDex)
        {
            value += Game.BonusSustDexValue;
        }
        if (EffectivePropertySet.SustCon)
        {
            value += Game.BonusSustConValue;
        }
        if (EffectivePropertySet.SustCha)
        {
            value += Game.BonusSustChaValue;
        }
        if (EffectivePropertySet.ImAcid)
        {
            value += Game.BonusImAcidValue;
        }
        if (EffectivePropertySet.ImElec)
        {
            value += Game.BonusImElecValue;
        }
        if (EffectivePropertySet.ImFire)
        {
            value += Game.BonusImFireValue;
        }
        if (EffectivePropertySet.ImCold)
        {
            value += Game.BonusImColdValue;
        }
        if (EffectivePropertySet.Reflect)
        {
            value += Game.BonusReflectValue;
        }
        if (EffectivePropertySet.FreeAct)
        {
            value += Game.BonusFreeActValue;
        }
        if (EffectivePropertySet.HoldLife)
        {
            value += Game.BonusHoldLifeValue;
        }
        if (EffectivePropertySet.ResAcid)
        {
            value += Game.BonusResAcidValue;
        }
        if (EffectivePropertySet.ResElec)
        {
            value += Game.BonusResElecValue;
        }
        if (EffectivePropertySet.ResFire)
        {
            value += Game.BonusResFireValue;
        }
        if (EffectivePropertySet.ResCold)
        {
            value += Game.BonusResColdValue;
        }
        if (EffectivePropertySet.ResPois)
        {
            value += Game.BonusResPoisValue;
        }
        if (EffectivePropertySet.ResFear)
        {
            value += Game.BonusResFearValue;
        }
        if (EffectivePropertySet.ResLight)
        {
            value += Game.BonusResLightValue;
        }
        if (EffectivePropertySet.ResDark)
        {
            value += Game.BonusResDarkValue;
        }
        if (EffectivePropertySet.ResBlind)
        {
            value += Game.BonusResBlindValue;
        }
        if (EffectivePropertySet.ResConf)
        {
            value += Game.BonusResConfValue;
        }
        if (EffectivePropertySet.ResSound)
        {
            value += Game.BonusResSoundValue;
        }
        if (EffectivePropertySet.ResShards)
        {
            value += Game.BonusResShardsValue;
        }
        if (EffectivePropertySet.ResNether)
        {
            value += Game.BonusResNetherValue;
        }
        if (EffectivePropertySet.ResNexus)
        {
            value += Game.BonusResNexusValue;
        }
        if (EffectivePropertySet.ResChaos)
        {
            value += Game.BonusResChaosValue;
        }
        if (EffectivePropertySet.ResDisen)
        {
            value += Game.BonusResDisenValue;
        }
        if (EffectivePropertySet.ShFire)
        {
            value += Game.BonusShFireValue;
        }
        if (EffectivePropertySet.ShElec)
        {
            value += Game.BonusShElecValue;
        }
        if (EffectivePropertySet.NoTele)
        {
            value += Game.BonusNoTeleValue;
        }
        if (EffectivePropertySet.NoMagic)
        {
            value += Game.BonusNoMagicValue;
        }
        if (EffectivePropertySet.Wraith)
        {
            value += Game.BonusWraithValue;
        }
        if (EffectivePropertySet.DreadCurse)
        {
            value += Game.BonusDreadCurseValue;
        }
        if (EffectivePropertySet.Feather)
        {
            value += Game.BonusFeatherValue;
        }
        if (EffectivePropertySet.SeeInvis)
        {
            value += Game.BonusSeeInvisValue;
        }
        if (EffectivePropertySet.Telepathy)
        {
            value += Game.BonusTelepathyValue;
        }
        if (EffectivePropertySet.SlowDigest)
        {
            value += Game.BonusSlowDigestValue;
        }
        if (EffectivePropertySet.Regen)
        {
            value += Game.BonusRegenValue;
        }
        if (EffectivePropertySet.XtraMight)
        {
            value += Game.BonusXtraMightValue;
        }
        if (EffectivePropertySet.XtraShots)
        {
            value += Game.BonusXtraShotsValue;
        }
        if (EffectivePropertySet.IgnoreAcid)
        {
            value += Game.BonusIgnoreAcidValue;
        }
        if (EffectivePropertySet.IgnoreElec)
        {
            value += Game.BonusIgnoreElecValue;
        }
        if (EffectivePropertySet.IgnoreFire)
        {
            value += Game.BonusIgnoreFireValue;
        }
        if (EffectivePropertySet.IgnoreCold)
        {
            value += Game.BonusIgnoreColdValue;
        }
        if (EffectivePropertySet.DrainExp)
        {
            value += Game.BonusDrainExpValue;
        }
        if (EffectivePropertySet.Teleport)
        {
            value += Game.BonusTeleportValue;
        }
        if (EffectivePropertySet.Aggravate)
        {
            value += Game.BonusAggravateValue;
        }
        if (EffectivePropertySet.Blessed)
        {
            value += Game.BonusBlessedValue;
        }
        if (EffectivePropertySet.IsCursed)
        {
            value += Game.BonusIsCursedValue;
        }
        if (EffectivePropertySet.HeavyCurse)
        {
            value += Game.BonusHeavyCurseValue;
        }
        if (EffectivePropertySet.PermaCurse)
        {
            value += Game.BonusPermaCurseValue;
        }
        value += EffectivePropertySet.BonusStrength * Game.BonusStrengthValue;
        value += EffectivePropertySet.BonusIntelligence * Game.BonusIntelligenceValue;
        value += EffectivePropertySet.BonusWisdom * Game.BonusWisdomValue;
        value += EffectivePropertySet.BonusDexterity * Game.BonusDexterityValue;
        value += EffectivePropertySet.BonusConstitution * Game.BonusConstitutionValue;
        value += EffectivePropertySet.BonusCharisma * Game.BonusCharismaValue;
        value += EffectivePropertySet.BonusStealth * Game.BonusStealthValue;
        value += EffectivePropertySet.BonusSearch * Game.BonusSearchValue;
        value += EffectivePropertySet.BonusInfravision * Game.BonusInfravisionValue;
        value += EffectivePropertySet.BonusTunnel * Game.BonusTunnelValue;
        value += EffectivePropertySet.BonusAttacks * Game.BonusExtraBlowslValue;
        value += EffectivePropertySet.BonusSpeed * Game.BonusSpeedlValue;

        if (EffectivePropertySet.Activation != null)
        {
            value += EffectivePropertySet.Activation.Value;
        }

        if (AimingTuple != null)
        {
            value += AimingTuple.Value.PerChargeValue * WandChargesRemaining;
        }

        if (UseTuple != null)
        {
            value += UseTuple.Value.PerChargeValue * StaffChargesRemaining;
        }

        value += TurnOfLightValue * TurnsOfLightRemaining;

        value += EffectivePropertySet.BonusHits * _factory.BonusHitRealValueMultiplier;
        value += EffectivePropertySet.BonusArmorClass * _factory.BonusArmorClassRealValueMultiplier;
        value += EffectivePropertySet.BonusDamage * _factory.BonusDamageRealValueMultiplier;
        value += EffectivePropertySet.DamageDice * EffectivePropertySet.DiceSides * _factory.BonusDiceRealValueMultiplier;
        return value;
    }

    /// <summary>
    /// Returns true, if the item can be stomped.  Returns the stompable status based on the item quality rating, by default.  The algorithm for determine if an item can be stomped is:
    /// 1. If the item is unknown (e.g. <see cref="IsKnown"/> is false) and the player has not been able to sense the object, false is returned.
    /// 2. If the item is unknown, and the item <see cref="HasFlavor"/> and the player has identified the flavor <see cref="IsFlavorAware"/>, then the <see cref="StompableTypeEnum.Broken"/> setting value is returned.
    /// 3. Unknown containers will return false.
    /// 4. Open containers will return the <see cref="StompableTypeEnum.Broken"/> setting value.
    /// 5. Closed containers that are not trapped will return the <see cref="StompableTypeEnum.Average"/> setting value.
    /// 6. Unlocked containers will return the <see cref="StompableTypeEnum.Good"/> setting value.
    /// 7. Locked containers that are trapped or disarmed will return the <see cref="StompableTypeEnum.Excellent"/> setting value.
    /// 8. The item factory will return the <see cref="StompSetting"/> for other non-containers items.
    /// </summary>
    public bool Stompable
    {
        get
        {
            if (!IsKnown())
            {
                if (ItemClass.HasFlavor)
                {
                    if (IsFlavorAware)
                    {
                        return _factory.Stompable[StompableTypeEnum.Broken];
                    }
                }
                if (!IdentSense)
                {
                    return false;
                }
            }

            if (IsContainer)
            {
                if (!IsKnown())
                {
                    return false;
                }
                else if (ContainerIsOpen)
                {
                    return _factory.Stompable[StompableTypeEnum.Broken]; // Empty
                }
                else if (ContainerTraps == null)
                {
                    return _factory.Stompable[StompableTypeEnum.Average];
                }
                else
                {
                    if (ContainerTraps.Length == 0)
                    {
                        return _factory.Stompable[StompableTypeEnum.Good];
                    }
                    else
                    {
                        return _factory.Stompable[StompableTypeEnum.Excellent];
                    }
                }
            }
            else
            {
                ItemQualityRating itemQualityRating = GetQualityRating();
                int? stompableIndex = itemQualityRating.StompIndex;
                if (stompableIndex == null)
                {
                    return false;
                }
                return _factory.Stompable[stompableIndex.Value];
            }
        }
        set
        {
            _factory.Stompable[0] = value;
        }
    }

    /// <summary>
    /// Returns a description for the item.
    /// </summary>
    /// <returns></returns>
    /// <remarks>There may not be any references in code but this method is very useful for debugging.</remarks>
    public override string ToString()
    {
        return GetDescription(true);
    }

    /// <summary>
    /// Returns the best known value of the item.  If the item is known, then the real value will be returned.  If the item is unknown, then the base value of the factory will be returned.  
    /// The value will also reflect a discount if the item was bought at a discount.
    /// </summary>
    /// <returns></returns>
    public int Value()
    {
        int value;
        if (IsKnown())
        {
            if (IsBroken)
            {
                return 0;
            }
            if (EffectivePropertySet.IsCursed)
            {
                return 0;
            }
            value = GetRealValue();
        }
        else
        {
            if (IdentSense && IsBroken)
            {
                return 0;
            }
            if (IdentSense && EffectivePropertySet.IsCursed)
            {
                return 0;
            }
            if (IsFlavorAware)
            {
                return EffectivePropertySet.Cost;
            }
            return BaseValue;
        }
        if (Discount != 0)
        {
            value -= value * Discount / 100;
        }
        return value;
    }

    public bool ApplyFixedArtifact(FixedArtifact fixedArtifact)
    {
        // There cannot be more than one of each fixed artifacts.
        if (fixedArtifact.CurNum > 0)
        {
            return false;
        }

        fixedArtifact.CurNum = 1;

        // Retrieve all of the mapped item enhancements for the LINQ query.
        MappedItemEnhancement[] allMappedItemEnhancements = Game.SingletonRepository.Get<MappedItemEnhancement>(); // TODO: This is slow

        // A => Fixed Artifact
        // B => Character Class

        // Query for the applicable item enhancement.
        MappedItemEnhancement? mappedItemEnhancement = allMappedItemEnhancements
            .SingleOrDefault(_mappedItemEnhancement => (_mappedItemEnhancement.FixedArtifactBindingKeys is not null && _mappedItemEnhancement.FixedArtifactBindingKeys.Contains(fixedArtifact.GetKey)) && // Must match the fixed artifact
                                                       (_mappedItemEnhancement.CharacterClassBindingKeys is not null && _mappedItemEnhancement.CharacterClassBindingKeys.Contains(Game.BaseCharacterClass.GetKey))); // Must match the character class

        if (mappedItemEnhancement is null)
        {
            // Check the mappings for a and b and detect ambiguity.
            MappedItemEnhancement? aMappedItemEnhancement = allMappedItemEnhancements
                .SingleOrDefault(_mappedItemEnhancement => (_mappedItemEnhancement.FixedArtifactBindingKeys is not null && _mappedItemEnhancement.FixedArtifactBindingKeys.Contains(fixedArtifact.GetKey)) && // Must match the fixed artifact
                                                           (_mappedItemEnhancement.CharacterClassBindingKeys is null)); // Wildcard match for the character class

            MappedItemEnhancement? bMappedItemEnhancement = allMappedItemEnhancements
                .SingleOrDefault(_mappedItemEnhancement => (_mappedItemEnhancement.FixedArtifactBindingKeys is null) && // Wilcard match for the fixed artifact
                                                           (_mappedItemEnhancement.CharacterClassBindingKeys is not null && _mappedItemEnhancement.CharacterClassBindingKeys.Contains(Game.BaseCharacterClass.GetKey))); // Must match the character class

            if (aMappedItemEnhancement is not null && bMappedItemEnhancement is not null)
            {
                throw new Exception($"Ambigious mapped item enhancement for fixed artifact {fixedArtifact.GetKey} and character class {Game.BaseCharacterClass.GetKey}.");
            }
            else if (aMappedItemEnhancement is not null)
            {
                mappedItemEnhancement = aMappedItemEnhancement;
            }
            else
            {
                mappedItemEnhancement = bMappedItemEnhancement;
            }
        }
        if (mappedItemEnhancement is null)
        {
            mappedItemEnhancement = allMappedItemEnhancements.SingleOrDefault(_mappedItemEnhancement => _mappedItemEnhancement.FixedArtifactBindingKeys is null && _mappedItemEnhancement.CharacterClassBindingKeys is null);
        }

        // Check to see if we found an applicable mapped item enhancement and check to see if there are any attached item enhancements.
        EffectivePropertySet fixedArtifactItemPropertySet = new EffectivePropertySet();
        if (mappedItemEnhancement is not null && mappedItemEnhancement.ItemEnhancements is not null)
        {
            // Merge all of the applicable item enhancements.
            foreach (IItemEnhancement itemEnhancementAsInterface in mappedItemEnhancement.ItemEnhancements)
            {
                ItemEnhancement? itemEnhancement = itemEnhancementAsInterface.GetItemEnhancement();

                // If it was a weighted random, no item enhancement might have been selected because null item enhancements can be assigned weights.
                if (itemEnhancement is not null)
                {
                    fixedArtifactItemPropertySet.AddEnhancement(itemEnhancement.GenerateItemCharacteristics());
                }
            }
        }
        FixedArtifact = fixedArtifact;
        EffectivePropertySet.AddEnhancement("fixed", fixedArtifactItemPropertySet.ToReadOnly());

        if (EffectivePropertySet.Cost <= 0) // TODO: This was the fixedartifiact cost == 0, then isbroken = true.  should be enumerated out into the enhancements.
        {
            IsBroken = true;
        }
        Game.TreasureRating += fixedArtifactItemPropertySet.TreasureRating;
        Game.SpecialTreasure = true;
        return true;
    }

    /// <summary>
    /// Applies 
    /// </summary>
    /// <param name="lev"></param>
    /// <param name="allowFixedArtifact">Stores send false.  The game otherwise sends true.  Wizards get to select the value.</param>
    /// <param name="good">Stores send false.  Monsters will have a good item count Monster.DropGood. When true, skips the percentile roll for good objects.</param>
    /// <param name="great">Stores send false.  Monsters will have a great item count Monster.DropGreat. When true, skips the percentile roll for great objects.</param>
    /// <param name="store"></param>
    public void EnchantItem(int lev, bool allowFixedArtifact, bool good, bool great, bool usedOkay)
    {            
        if (lev > Constants.MaxDepth - 1)
        {
            lev = Constants.MaxDepth - 1;
        }
        int goodPercentRoll = lev + 10;
        if (goodPercentRoll > 75)
        {
            goodPercentRoll = 75;
        }
        int greatPercentRoll = goodPercentRoll / 2;
        if (greatPercentRoll > 20)
        {
            greatPercentRoll = 20;
        }
        int power = 0;
        if (good || Game.PercentileRoll(goodPercentRoll))
        {
            power = 1;
            if (great || Game.PercentileRoll(greatPercentRoll))
            {
                power = 2;
            }
        }
        else if (Game.PercentileRoll(goodPercentRoll))
        {
            power = -1;
            if (Game.PercentileRoll(greatPercentRoll))
            {
                power = -2;
            }
        }

        // The factory may have specified a breakage
        if (power == 0 && _factory.BreaksDuringEnchantmentProbability != null && _factory.BreaksDuringEnchantmentProbability.Test())
        {
            power = -1;
        }

        int rollsForFixedArtifactAttempts = 0;
        if (allowFixedArtifact && FixedArtifact == null)
        {
            if (great)
            {
                rollsForFixedArtifactAttempts = 4;
            }
            else if (power >= 2)
            {
                rollsForFixedArtifactAttempts = 1;
            }
        }
        for (int i = 0; i < rollsForFixedArtifactAttempts; i++)
        {
            FixedArtifact? fixedArtifact = SelectCompatibleFixedArtifact(); // TODO: This overrides the MakeArtifact selection
            if (fixedArtifact != null)
            {
                // Apply the fixed 
                if (ApplyFixedArtifact(fixedArtifact))
                {
                    // Fixed artifacts do not receive anymore enchantment.
                    return;
                }
            }
        }

        if (_factory.EnchantmentTuples != null)
        {
            bool isStoreStock = !usedOkay;
            foreach ((int[]? Powers, bool? StoreStock, IEnhancementScript[] Scripts) in _factory.EnchantmentTuples)
            {
                if ((Powers == null || Powers.Contains(power)) && (StoreStock == null || StoreStock == isStoreStock))
                {
                    foreach (IEnhancementScript script in Scripts)
                    {
                        script.ExecuteEnchantmentScript(this, lev); // This may set the RareItem property
                    }
                }
            }
        }

        Game.TreasureRating += _factory.ItemEnhancement.TreasureRating; // TODO: This only pulls from the ItemFactory and not generated characteristcs
        if (IsRandomArtifact) 
        {
            Game.TreasureRating += EffectivePropertySet.TreasureRating;
        }
        if (EffectivePropertySet.Cost == 0)
        {
            IsBroken = true;
        }
    }

    public void ApplyRandomResistance(WeightedRandom<ItemEnhancement> itemAdditiveBundleWeightedRandom)
    {
        ItemEnhancement? itemAdditiveBundle = itemAdditiveBundleWeightedRandom.ChooseOrDefault();
        if (itemAdditiveBundle != null)
        {
            EffectivePropertySet.AddEnhancement(itemAdditiveBundle.GenerateItemCharacteristics());
        }
    }

    /// <summary>
    /// Converts this item into a random artifact.
    /// </summary>
    /// <param name="fromScroll"></param>
    /// <returns></returns>
    public bool CreateRandomArtifact(bool fromScroll)
    {
        // Create a set of random artifact characteristics.
        EffectivePropertySet.AddEnhancement("random", _factory.CreateRandomArtifact(this, fromScroll));

        ActivationRechargeTimeRemaining = 0; // TODO: If the item already had activation running, the conversion could change it? and restart the recharge?
        string newName;
        if (fromScroll)
        {
            IdentifyFully();
            IdentityIsStoreBought = true;
            if (!Game.GetString("What do you want to call the artifact? ", out string dummyName, "(a DIY artifact)", 80))
            {
                newName = "(a DIY artifact)";
            }
            else
            {
                newName = "called '" + dummyName + "'";
            }
            IsFlavorAware = true;
            BecomeKnown();
            IdentMental = true;
        }
        else
        {
            newName = GenerateRandomArtifactName();
        }
        RandomArtifactName = newName;
        return true;
    }

    private FixedArtifact? SelectCompatibleFixedArtifact()
    {
        if (StackCount != 1)
        {
            return null;
        }
        foreach (FixedArtifact aPtr in Game.SingletonRepository.Get<FixedArtifact>()) // TODO: This needs to be random ... 
        {
            if (aPtr.HasOwnType)
            {
                continue;
            }

            // Do not create another, if there is already one in the game. 
            if (aPtr.CurNum != 0) // TODO: This is already in the ApplyFixedArtifact
            {
                continue;
            }

            if (aPtr.BaseItemFactory != _factory)
            {
                continue;
            }
            if (aPtr.Level > Game.Difficulty)
            {
                int d = (aPtr.Level - Game.Difficulty) * 2;
                if (Game.RandomLessThan(d) != 0)
                {
                    continue;
                }
            }
            if (Game.RandomLessThan(aPtr.Rarity) != 0)
            {
                continue;
            }
            return aPtr;
        }
        return null;
    }

    private string GenerateRandomArtifactName()
    {
        int testcounter = Game.DieRoll(3) + 1;
        string outString = "";
        if (Game.DieRoll(3) == 2)
        {
            while (testcounter-- != 0)
            {
                outString += new WeightedRandom<string>(Game, Game.IllegibleFlavorSyllables).ChooseOrDefault();
            }
        }
        else
        {
            testcounter = Game.DieRoll(2) + 1;
            while (testcounter-- != 0)
            {
                outString += new WeightedRandom<string>(Game, Game.ElvishTexts).ChooseOrDefault();
            }
        }
        return "'" + outString.Substring(0, 1).ToUpper() + outString.Substring(1) + "'";
    }

    public int GetBonusValue(int max, int level)
    {
        if (level > Constants.MaxDepth - 1)
        {
            level = Constants.MaxDepth - 1;
        }
        int bonus = max * level / Constants.MaxDepth;
        int extra = max * level % Constants.MaxDepth;
        if (Game.RandomLessThan(Constants.MaxDepth) < extra)
        {
            bonus++;
        }
        int stand = max / 4;
        extra = max % 4;
        if (Game.RandomLessThan(4) < extra)
        {
            stand++;
        }
        int value = Game.RandomNormal(bonus, stand);
        if (value < 0)
        {
            return 0;
        }
        if (value > max)
        {
            return max;
        }
        return value;
    }

    /// <summary>
    /// Returns a random number similar to a dice roll diceDsides but this mass roll uses 
    /// </summary>
    /// <param name="num"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public int MassRoll(int num, int max)
    {
        int t = 0;
        for (int i = 0; i < num; i++)
        {
            t += Game.RandomLessThan(max);
        }
        return t;
    }
    #endregion

    #region Constructors
    public Item(Game game, ItemFactory factory)
    {
        Game = game;

        // Generate the read-only item characteristics from the factory.
        _factory = factory;
        EffectivePropertySet = new EffectivePropertySet();
        ReadOnlyPropertySet factoryPropertySet = factory.ItemEnhancement.GenerateItemCharacteristics();
        EffectivePropertySet.AddEnhancement("factory", factoryPropertySet);

        StackCount = 1;

        // Now we retrieve all of the characteristics from the factory.
        NutritionalValue = _factory.InitialNutritionalValue;        
        GoldPieces = Game.ComputeIntegerExpression(_factory.InitialGoldPiecesRoll).Value;
        TurnsOfLightRemaining = _factory.InitialTurnsOfLight;
        EffectivePropertySet.BonusHits = _factory.BonusHit;
        EffectivePropertySet.BonusDamage = _factory.BonusDamage;
        EffectivePropertySet.BonusArmorClass = _factory.BonusArmorClass;
        ArmorClass = _factory.ArmorClass;
        IsBroken = _factory.IsBroken;

        if (_factory.AimingTuple != null)
        {
            WandChargesRemaining = Game.ComputeIntegerExpression(_factory.AimingTuple.Value.InitialChargesCountRoll).Value;
        }

        if (_factory.UseTuple != null)
        {
            StaffChargesRemaining = Game.ComputeIntegerExpression(_factory.UseTuple.Value.InitialCharges).Value;
        }
    }
    #endregion

    #region Item Properties Management
    public FixedArtifact? FixedArtifact = null;

    public EffectivePropertySet EffectivePropertySet;

    /// <summary>
    /// Returns the factory that created this item.  All of the initial state data is retrieved from the <see cref="ItemFactory"/>when the <see cref="Item"/> is created.  We preserve this <see cref="ItemFactory"/>
    /// because the factory provides some methods but eventually, these methods will become customizable scripts that the <see cref="Item"/> will take copies of when the <see cref="Item"/> is constructed.  At 
    /// that point, the <see cref="ItemFactory"/> will no longer be needed after construction.
    /// </summary>
    private ItemFactory _factory;

    /// <summary>
    /// Returns the factory for this item.  This method is being used for <see cref="ItemFilter"/> classes and should not be used directly.
    /// </summary>
    public ItemFactory GetFactory => _factory; // TODO: Refactor the ItemFilter to not need this.

    public void SetRareItem(ItemEnhancement? rareItem)
    {
        if (rareItem == null)
        {
            // Check to see if we need to remove properties.
            if (IsRare)
            {
                Game.TreasureRating -= rareItem.TreasureRating;
                EffectivePropertySet.RemoveEnhancement("rare");
            }
        }
        else
        {
            // Check to see if we are enchanting a cursed or broken item.
            int goodBadMultiplier = EffectivePropertySet.IsCursed || IsBroken ? -1 : 1;

            EffectivePropertySet? rareItemEffectivePropertySet = new EffectivePropertySet();
            rareItemEffectivePropertySet.AddEnhancement(rareItem.GenerateItemCharacteristics());

            // If the rare item has no value, consider it broken.
            if (rareItemEffectivePropertySet.Valueless)
            {
                IsBroken = true; // This should be manual.
            }

            rareItemEffectivePropertySet.BonusHits *= goodBadMultiplier;
            rareItemEffectivePropertySet.BonusDamage *= goodBadMultiplier;
            rareItemEffectivePropertySet.BonusArmorClass *= goodBadMultiplier;
            rareItemEffectivePropertySet.BonusStrength *= goodBadMultiplier;
            rareItemEffectivePropertySet.BonusIntelligence *= goodBadMultiplier;
            rareItemEffectivePropertySet.BonusWisdom *= goodBadMultiplier;
            rareItemEffectivePropertySet.BonusDexterity *= goodBadMultiplier;
            rareItemEffectivePropertySet.BonusConstitution *= goodBadMultiplier;
            rareItemEffectivePropertySet.BonusCharisma *= goodBadMultiplier;
            rareItemEffectivePropertySet.BonusStealth *= goodBadMultiplier;
            rareItemEffectivePropertySet.BonusSearch *= goodBadMultiplier;
            rareItemEffectivePropertySet.BonusInfravision *= goodBadMultiplier;
            rareItemEffectivePropertySet.BonusTunnel *= goodBadMultiplier;
            rareItemEffectivePropertySet.BonusAttacks *= goodBadMultiplier;
            rareItemEffectivePropertySet.BonusSpeed *= goodBadMultiplier;
            Game.TreasureRating += rareItem.TreasureRating;
            EffectivePropertySet.AddEnhancement("rare", rareItemEffectivePropertySet.ToReadOnly());
        }
    }

    public void ResetCurse()
    {
        EffectivePropertySet.ResetCurse();
    }

    /// <summary>
    /// Removes the curse from an item.  This overrides the curse state of an item; as false.
    /// </summary>
    public void RemoveCurse()
    {
        EffectivePropertySet.RemoveCurse();
    }

    /// <summary>
    /// Resets the heavy curse removed state back to default.  This is used when applying a heavy curse on an item so that the item shows as cursed.
    /// </summary>
    public void ResetHeavyCurse()
    {
        EffectivePropertySet.ResetHeavyCurse();
    }

    /// <summary>
    /// Removes the heavy curse from an item.  This overrides the heavy curse state of an item; as false.
    /// </summary>
    public void RemoveHeavyCurse()
    {
        EffectivePropertySet.RemoveHeavyCurse();
    }

    #endregion
}