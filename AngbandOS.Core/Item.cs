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
    /// <summary>
    /// Returns the factory that created this item.
    /// </summary>
    public ItemFactory Factory { get; private set; } // TODO: This should be protected ... and force the item to call the factory methods.

    public FixedArtifact? FixedArtifact; // If this item is a fixed artifact, this will be not null.

    /// <summary>
    /// Returns the rare item, if the item is a rare item; or null, if the item is not rare.
    /// </summary>
    public RareItem? RareItem = null;

    /// <summary>
    /// Returns the base characteristics for this item.  These characteristics all provide defaults and can be modified with magic via enchancement or random artifact creation.
    /// </summary>
    public ItemCharacteristics Characteristics = new ItemCharacteristics();

    /// <summary>
    /// Returns a sort order index for sorting items in a pack.  Lower numbers show before higher numbers.
    /// </summary>
    public int PackSort => Factory.PackSort;

    public int TurnsOfLightRemaining = 0;

    /// <summary>
    /// Returns the number of gold pieces the item contains.  Applies to gold.
    /// </summary>
    public int GoldPieces = 0;

    /// <summary>
    /// Returns true, if the item has already been identify sensed.  This property used to be a flag in the IdentifyFlags.
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
    /// Returns true, if item has been identified; false, otherwise.  This property is near identical to the Factory.IsFlavorAware, with the exception that a store will identify an item, 
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
    /// This property used to be a flag in the IdentifyFlags.
    /// </summary>
    public bool IsCursed;

    /// <summary>
    /// Returns true, if the item is broken; false, otherwise.  Broken items are considered worthless, regardless of their other properties.
    /// </summary>
    public bool IsBroken;

    public int ArmorClass;
    public int BonusArmorClass;
    public int BonusDamage;
 //   public Activation? Activation = null;

    /// <summary>
    /// Returns an additional special power that is added for fixed artifacts and rare items.
    /// </summary>
    public ItemAdditiveBundle? RandomPower = null;

    public int BonusHit;
    public int Count;
    public int DamageDice;
    public int DamageSides;
    public int Discount;
    public int HoldingMonsterIndex;
    public string Inscription = "";

    /// <summary>
    /// Returns the container that is holding the item.
    /// </summary>
    public IItemContainer GetContainer()
    {
        // Check to see if the item is in the players inventory.
        foreach (BaseInventorySlot inventorySlot in Game.SingletonRepository.Get<BaseInventorySlot>())
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
    /// Modifies the quantity of an item.  The modification process differs depending on the type of container containing the item (e.g. inventory slots will update the player stats, monster and grid tile containers do not).
    /// </summary>
    /// <param name="oPtr"></param>
    /// <param name="num"></param>
    public void ItemIncrease(int num)
    {
        IItemContainer container = GetContainer();
        container.ItemIncrease(this, num);
    }

    /// <summary>
    /// Renders a description of the item.  For an inventory slot, the description is rendered as possessive; non-inventory slots, render as the player is viewing the item.
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

    public void GridProcessWorld(GridTile gridTile)
    {
        Factory.GridProcessWorld(this, gridTile);
    }

    public void PackProcessWorld()
    {
        Factory.PackProcessWorld(this);
    }

    public void EquipmentProcessWorld()
    {
        Factory.EquipmentProcessWorld(this);
    }

    public void MonsterProcessWorld(Monster mPtr)
    {
        Factory.MonsterProcessWorld(this, mPtr);
    }

    /// <summary>
    /// Returns true, if the container is part of the players inventory.  All inventory slots (pack & equipment), return true; monsters and grid tiles return false.
    /// </summary>
    public bool IsInInventory
    {
        get
        {
            IItemContainer container = GetContainer();
            return container.IsInInventory;
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
            return container.IsInEquipment;
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
    /// Tests an item to determine if it belongs to an Item type and returns a the item casted into that type; or null, if the item doesn't belong to the type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [Obsolete]
    public T? TryGetFactory<T>() where T : ItemFactory
    {
        if (typeof(T).IsAssignableFrom(Factory.GetType()))
        {
            return (T)Factory;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Returns true, if this item has been noticed and/or detected by the player.  Unnoticed items will cause the player to stop running.
    /// </summary>
    public bool WasNoticed = false;

    /// <summary>
    /// Returns the number of turns remaining to recharge the activation.
    /// </summary>
    public int ActivationRechargeTimeRemaining;

    public int BonusStrength;
    public int BonusIntelligence;
    public int BonusWisdom;
    public int BonusDexterity;
    public int BonusConstitution;
    public int BonusCharisma;
    public int BonusStealth;
    public int BonusSearch;
    public int BonusInfravision;
    public int BonusTunnel;
    public int BonusAttacks;
    public int BonusSpeed;

    /// <summary>
    /// Returns null if the container is unlocked and can be opened without picking, an empty array, if the container is disarmed and locked, or an array of traps.
    /// </summary>
    public ChestTrap[]? ContainerTraps = null;

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

    /// <summary>
    /// Returns the nutritional value in turns provided to the player, when eaten.
    /// </summary>
    public int NutritionalValue = 0;

    public int Weight;
    public int X;
    public int Y;
    private readonly Game Game;

    public Item(Game game, ItemFactory factory)
    {
        Game = game;
        Factory = factory;

        // TODO: The below statements should be in the ApplyMagic method for each factory.
        BonusStrength = Factory.InitialBonusStrength;
        BonusIntelligence = Factory.InitialBonusIntelligence;
        BonusWisdom = Factory.InitialBonusWisdom;
        BonusDexterity = Factory.InitialBonusDexterity;
        BonusConstitution = Factory.InitialBonusConstitution;
        BonusCharisma = Factory.InitialBonusCharisma;
        BonusStealth = Factory.InitialBonusStealth;
        BonusSearch = Factory.InitialBonusSearch;
        BonusInfravision = Factory.InitialBonusInfravision;
        BonusTunnel = Factory.InitialBonusTunnel;
        BonusAttacks = Factory.InitialBonusAttacks;
        BonusSpeed = Factory.InitialBonusSpeed;
        NutritionalValue = Factory.InitialNutritionalValue;        
        GoldPieces = Factory.InitialGoldPiecesRoll.Get(Game.UseRandom);
        TurnsOfLightRemaining = Factory.InitialTurnsOfLight;
        WandChargesRemaining = Factory.RodChargeCount;

        if (Factory.StaffChargeCount != null)
        {
            StaffChargesRemaining = Factory.StaffChargeCount.Get(Game.UseRandom);
        }

        Count = 1;
        Weight = Factory.Weight;
        BonusHit = Factory.BonusHit;
        BonusDamage = Factory.BonusDamage;
        BonusArmorClass = Factory.BonusArmorClass;
        ArmorClass = Factory.ArmorClass;
        DamageDice = Factory.DamageDice;
        DamageSides = Factory.DamageSides;
        IsBroken = Factory.IsBroken;
        IsCursed = Factory.IsCursed;
    }

    public void Recharge(int num)
    {
        Factory.Recharge(this, num);
    }

    /// <summary>
    /// Consume magic of a rechargeable item.  Rods, staves and wands are supported.
    /// </summary>
    public void EatMagic()
    {
        Factory.EatMagic(this);
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
        BookItemFactory? thisBookFactory = Factory.TryCast<BookItemFactory>();
        BookItemFactory? oPtrBookFactory = oPtr.Factory.TryCast<BookItemFactory>();
        if (thisBookFactory != null && oPtrBookFactory != null)
        {
            if (thisBookFactory.Realm == Game.PrimaryRealm && oPtrBookFactory.Realm != Game.PrimaryRealm)
            {
                return -1;
            }
            if (thisBookFactory.Realm != Game.PrimaryRealm && oPtrBookFactory.Realm == Game.PrimaryRealm)
            {
                return 1;
            }

            // Second level sort (secondary realm spell books).
            // A book that matches the second realm, will always come before a book that doesn't match the second realm.
            if (thisBookFactory.Realm == Game.SecondaryRealm && oPtrBookFactory.Realm != Game.SecondaryRealm)
            {
                return 1;
            }
            if (thisBookFactory.Realm != Game.SecondaryRealm && oPtrBookFactory.Realm == Game.SecondaryRealm)
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
        if (Factory.IsFlavorAware && !oPtr.Factory.IsFlavorAware)
        {
            return -1;
        }
        if (!Factory.IsFlavorAware && oPtr.Factory.IsFlavorAware)
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
    /// Drains charges from the item and returns true, if charges were drained.
    /// </summary>
    /// <param name="monster"></param>
    /// <param name="obvious"></param>
    /// <returns></returns>
    public bool DrainChargesMonsterAttack(Monster monster, ref bool obvious) // TODO: obvious needs to be in an event 
    {
        return Factory.DrainChargesMonsterAttack(this, monster, ref obvious); // TODO: obvious needs to be in an event 
    }

    // TODO: There is no way to ensure a cloned gets all of the properties
    public Item Clone(int? newCount = null)
    {
        // TODO: The assignments below need to be performed by each factory.  This can be integrated into the CreateItem.
        Item clonedItem = new Item(Game, Factory);

        clonedItem.ArmorClass = ArmorClass;
        clonedItem.Characteristics.Copy(Characteristics);
        clonedItem.RandomArtifactName = RandomArtifactName;
        clonedItem.DamageDice = DamageDice;
        clonedItem.Discount = Discount;
        clonedItem.DamageSides = DamageSides;
        clonedItem.HoldingMonsterIndex = HoldingMonsterIndex;
        clonedItem.RandomPower = RandomPower;

        clonedItem.IdentSense = IdentSense;
        clonedItem.IdentFixed = IdentFixed;
        clonedItem.IdentEmpty = IdentEmpty;
        clonedItem.IdentityIsKnown = IdentityIsKnown;
        clonedItem.IdentityIsStoreBought = IdentityIsStoreBought;
        clonedItem.IdentMental = IdentMental;
        clonedItem.IsCursed = IsCursed;
        clonedItem.IsBroken = IsBroken;

        clonedItem.X = X;
        clonedItem.Y = Y;
        clonedItem.WasNoticed = WasNoticed;
        clonedItem.FixedArtifact = FixedArtifact;
        clonedItem.RareItem = RareItem;
        clonedItem.Inscription = Inscription;
        clonedItem.Count = newCount ?? Count;
        clonedItem.BonusStrength = BonusStrength;
        clonedItem.BonusIntelligence = BonusIntelligence;
        clonedItem.BonusWisdom = BonusWisdom;
        clonedItem.BonusDexterity = BonusDexterity;
        clonedItem.BonusConstitution = BonusConstitution;
        clonedItem.BonusCharisma = BonusCharisma;
        clonedItem.BonusStealth = BonusStealth;
        clonedItem.BonusSearch = BonusSearch;
        clonedItem.BonusInfravision = BonusInfravision;
        clonedItem.BonusTunnel = BonusTunnel;
        clonedItem.BonusAttacks = BonusAttacks;
        clonedItem.BonusSpeed = BonusSpeed;
        clonedItem.TurnsOfLightRemaining = TurnsOfLightRemaining;
        clonedItem.NutritionalValue = NutritionalValue;
        clonedItem.ActivationRechargeTimeRemaining = ActivationRechargeTimeRemaining;
        clonedItem.ContainerIsOpen = ContainerIsOpen;
        clonedItem.LevelOfObjectsInContainer = LevelOfObjectsInContainer;
        clonedItem.ContainerTraps = ContainerTraps;
        clonedItem.RodRechargeTimeRemaining = RodRechargeTimeRemaining;
        clonedItem.StaffChargesRemaining = StaffChargesRemaining;
        clonedItem.WandChargesRemaining = WandChargesRemaining;
        clonedItem.GoldPieces = GoldPieces;
        clonedItem.BonusArmorClass = BonusArmorClass;
        clonedItem.BonusDamage = BonusDamage;
        clonedItem.BonusHit = BonusHit;
        clonedItem.Weight = Weight;
        return clonedItem;
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
    /// Returns the name the player provided when this item was converted into a random artifact, including an empty string; or null, if the item was never converted into a random artifact.
    /// </summary>
    public string? RandomArtifactName = null;

    /// <summary>
    /// Returns true, if the item is a random artifact; false, otherwise.
    /// </summary>
    public bool IsRandomArtifact => RandomArtifactName != null;

    public void Absorb(Item other)
    {
        int total = Count + other.Count;
        Count = total < Constants.MaxStackSize ? total : Constants.MaxStackSize - 1;
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
        ItemCharacteristics mergedCharacteristics = GetMergedCharacteristics();
        if (Factory.GetsDamageMultiplier)
        {
            if (mergedCharacteristics.SlayAnimal && rPtr.Animal)
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
            if (mergedCharacteristics.SlayEvil && rPtr.Evil)
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
            if (mergedCharacteristics.SlayUndead && rPtr.Undead)
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
            if (mergedCharacteristics.SlayDemon && rPtr.Demon)
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
            if (mergedCharacteristics.SlayOrc && rPtr.Orc)
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
            if (mergedCharacteristics.SlayTroll && rPtr.Troll)
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
            if (mergedCharacteristics.SlayGiant && rPtr.Giant)
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
            if (mergedCharacteristics.SlayDragon && rPtr.Dragon)
            {
                if (mPtr.IsVisible)
                {
                    rPtr.Knowledge.Characteristics.Dragon = true;
                }
                if (mult < 3)
                {
                    mult = 3;
                }
            }
            if (mergedCharacteristics.KillDragon && rPtr.Dragon)
            {
                if (mPtr.IsVisible)
                {
                    rPtr.Knowledge.Characteristics.Dragon = true;
                }
                if (mult < 5)
                {
                    mult = 5;
                }
                if (FixedArtifact != null)
                {
                    mult *= FixedArtifact.KillDragonMultiplier;
                }
            }
            if (mergedCharacteristics.BrandAcid)
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
            if (mergedCharacteristics.BrandElec)
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
            if (mergedCharacteristics.BrandFire)
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
            if (mergedCharacteristics.BrandCold)
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
            if (mergedCharacteristics.BrandPois)
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
    /// Returns true, if two objects can be absorbed into one for the home store.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool CanAbsorb(Item other)
    {
        // Ensure both items belong to the same factory.  This works because factories are singletons.  Items from different factories cannot
        // be merged.
        if (Factory != other.Factory)
        {
            return false;
        }

        ItemCharacteristics mergedCharacteristics = GetMergedCharacteristics();
        ItemCharacteristics otherMergedCharacteristics = other.GetMergedCharacteristics();
        if (mergedCharacteristics != otherMergedCharacteristics)
        {
            return false;
        }

        // The known status must be the same.
        if (IsKnown() != other.IsKnown())
        {
            return false;
        }
        if (BonusHit != other.BonusHit)
        {
            return false;
        }
        if (BonusDamage != other.BonusDamage)
        {
            return false;
        }
        if (BonusArmorClass != other.BonusArmorClass)
        {
            return false;
        }
        if (BonusStrength != other.BonusStrength)
        {
            return false;
        }
        if (BonusIntelligence != other.BonusIntelligence)
        {
         return false;
        }
        if (BonusWisdom != other.BonusWisdom)
        {
          return false;
        }
        if (BonusDexterity != other.BonusDexterity)
        {
          return false;
        }
        if (BonusConstitution != other.BonusConstitution)
        {
          return false;
        }
        if (BonusCharisma != other.BonusCharisma)
        {
         return false;
        }
        if (BonusStealth != other.BonusStealth)
        {
            return false;
        }
        if (BonusSearch != other.BonusSearch)
        {
           return false;
        }
        if (BonusInfravision != other.BonusInfravision)
        {
           return false;
        }
        if (BonusTunnel != other.BonusTunnel)
        {
            return false;
        }
        if (BonusAttacks != other.BonusAttacks)
        {
           return false;
        }
        if (BonusSpeed != other.BonusSpeed)
        {
           return false;
        }

        // Only open chests can be combined; otherwise, chests are never combined.
        if (Factory.IsContainer && !ContainerIsOpen || other.Factory.IsContainer && !other.ContainerIsOpen)
        {
            return false;
        }
        if (Factory.NumberOfItemsContained != other.Factory.NumberOfItemsContained)
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
        if (RareItem != other.RareItem)
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
        if (DamageDice != other.DamageDice)
        {
            return false;
        }
        if (DamageSides != other.DamageSides)
        {
            return false;
        }
        if (IsRandomArtifact || other.IsRandomArtifact)
        {
            return false;
        }
        if (IsCursed != other.IsCursed)
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

        int total = Count + other.Count;
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
        string basenm = Factory.GetDescription(this, includeCountPrefix);
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
            else if (RareItem != null)
            {
                basenm += ' ';
                basenm += RareItem.FriendlyName; // This used to be oPtr.Name ... but Long Bow Bow of Velocity is wrong
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
        basenm += Factory.GetDetailedDescription(this);
        basenm += Factory.GetVerboseDescription(this);

        // This is the full description.
        string fullDescription = "";
        if (!string.IsNullOrEmpty(Inscription))
        {
            fullDescription = Inscription;
        }
        else if (IsCursed && (IsKnown() || IdentSense))
        {
            fullDescription = "cursed";
        }
        else if (!IsKnown() && IdentEmpty)
        {
            fullDescription = "empty";
        }
        else if (!Factory.IsFlavorAware && Factory.Tried)
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

    public ItemQualityRating GetQualityRating()
    {
        if (!Factory.HasQualityRatings)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(BrokenItemQualityRating));
        }

        if (IsArtifact)
        {
            if (IsCursed || IsBroken)
            {
                return Game.SingletonRepository.Get<ItemQualityRating>(nameof(TerribleItemQualityRating));
            }
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(SpecialItemQualityRating));
        }
        if (IsRare())
        {
            if (IsCursed || IsBroken)
            {
                return Game.SingletonRepository.Get<ItemQualityRating>(nameof(WorthlessItemQualityRating));
            }
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(ExcellentItemQualityRating));
        }

        if (IsCursed)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(CursedItemQualityRating));
        }

        if (IsBroken || BonusDamage < 0 || BonusHit < 0 || BonusArmorClass < 0)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(BrokenItemQualityRating));
        }

        if (BonusArmorClass > 0 || BonusHit + BonusDamage > 0)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(GoodItemQualityRating));
        }

        return Game.SingletonRepository.Get<ItemQualityRating>(nameof(AverageItemQualityRating));
    }

    public string GetDetailedFeeling()
    {
        return GetQualityRating().Description;
    }

    /// <summary>
    /// Refreshes all of the flag-based properties.  This is an interim method that replaces the deprecated GetMergedFlags(f1, f2, f3).  This method will
    /// be deprecated once all of the flag-based properties are maintained when the FixedArtifactIndex, RareItemType and RandartFlags automatically update
    /// the flag-based properties.
    /// </summary>
    public ItemCharacteristics GetMergedCharacteristics()
    {
        // All characteristics are set to false.
        ItemCharacteristics characteristics = new ItemCharacteristics();

        // Merge the characteristics from the base item category.
        characteristics.Merge(Factory);

        // Now merge the characteristics from the fixed artifact, if there is one.
        if (FixedArtifact != null)
        {
            characteristics.Merge(FixedArtifact);
        }

        // Now merge the characteristics from the rare item type, if there is one.
        if (RareItem != null)
        {
            characteristics.Merge(RareItem);
        }

        // Finally, merge any additional random artifact characteristics, if there are any.
        characteristics.Merge(Characteristics);

        // If there are any random characteristics, apply those also.
        if (RandomPower != null)
        {
            characteristics.Merge(RandomPower);
        }
        return characteristics;
    }

    public ItemQualityRating? GetVagueQualityRating()
    { 
        if (IsCursed)
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
        if (IsRare())
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(GoodItemQualityRating));
        }
        if (BonusArmorClass > 0)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(GoodItemQualityRating));
        }
        if (BonusHit + BonusDamage > 0)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(GoodItemQualityRating));
        }
        return null;
    }

    public bool HatesAcid()
    {
        return Factory.HatesAcid;
    }

    public bool HatesCold()
    {
        return Factory.HatesCold;
    }

    public bool HatesElec()
    {
        return Factory.HatesElectricity;
    }

    public bool HatesFire()
    {
        return Factory.HatesFire;
    }

    public bool IdentifyFully()
    {
        int i = 0, j, k;
        string[] info = new string[128];
        ItemCharacteristics mergedCharacteristics = GetMergedCharacteristics();
        if (mergedCharacteristics.Activation != null)
        {
            info[i++] = "It can be activated for...";
            info[i++] = mergedCharacteristics.Activation.Description;
            info[i++] = "...if it is being worn.";
        }
        string categoryIdentity = Factory.Identify(this);
        if (categoryIdentity != null)
        {
            info[i++] = categoryIdentity;
        }
        if (mergedCharacteristics.ArtifactBias != null)
        {
            info[i++] = $"It has an affinity for {mergedCharacteristics.ArtifactBias.AffinityName.ToLower()}.";
        }
        if (mergedCharacteristics.Str)
        {
            info[i++] = "It affects your strength.";
        }
        if (mergedCharacteristics.Int)
        {
            info[i++] = "It affects your intelligence.";
        }
        if (mergedCharacteristics.Wis)
        {
            info[i++] = "It affects your wisdom.";
        }
        if (mergedCharacteristics.Dex)
        {
            info[i++] = "It affects your dexterity.";
        }
        if (mergedCharacteristics.Con)
        {
            info[i++] = "It affects your constitution.";
        }
        if (mergedCharacteristics.Cha)
        {
            info[i++] = "It affects your charisma.";
        }
        if (mergedCharacteristics.Stealth)
        {
            info[i++] = "It affects your stealth.";
        }
        if (mergedCharacteristics.Search)
        {
            info[i++] = "It affects your searching.";
        }
        if (mergedCharacteristics.Infra)
        {
            info[i++] = "It affects your infravision.";
        }
        if (mergedCharacteristics.Tunnel)
        {
            info[i++] = "It affects your ability to tunnel.";
        }
        if (mergedCharacteristics.Speed)
        {
            info[i++] = "It affects your movement speed.";
        }
        if (mergedCharacteristics.Blows)
        {
            info[i++] = "It affects your attack speed.";
        }
        if (mergedCharacteristics.BrandAcid)
        {
            info[i++] = "It does extra damage from acid.";
        }
        if (mergedCharacteristics.BrandElec)
        {
            info[i++] = "It does extra damage from electricity.";
        }
        if (mergedCharacteristics.BrandFire)
        {
            info[i++] = "It does extra damage from fire.";
        }
        if (mergedCharacteristics.BrandCold)
        {
            info[i++] = "It does extra damage from frost.";
        }
        if (mergedCharacteristics.BrandPois)
        {
            info[i++] = "It poisons your foes.";
        }
        if (mergedCharacteristics.Chaotic)
        {
            info[i++] = "It produces chaotic effects.";
        }
        if (mergedCharacteristics.Vampiric)
        {
            info[i++] = "It drains life from your foes.";
        }
        if (mergedCharacteristics.Impact)
        {
            info[i++] = "It can cause earthquakes.";
        }

        if (mergedCharacteristics.Radius > 0)
        {
            string burnRate = Factory.BurnRate == 0 ? "forever" : "when fueled";
            info[i++] = $"It provides light (radius {mergedCharacteristics.Radius}) {burnRate}.";
        }

        if (mergedCharacteristics.Vorpal)
        {
            info[i++] = "It is very sharp and can cut your foes.";
        }
        if (mergedCharacteristics.KillDragon)
        {
            info[i++] = "It is a great bane of dragons.";
        }
        else if (mergedCharacteristics.SlayDragon)
        {
            info[i++] = "It is especially deadly against dragons.";
        }
        if (mergedCharacteristics.SlayOrc)
        {
            info[i++] = "It is especially deadly against orcs.";
        }
        if (mergedCharacteristics.SlayTroll)
        {
            info[i++] = "It is especially deadly against trolls.";
        }
        if (mergedCharacteristics.SlayGiant)
        {
            info[i++] = "It is especially deadly against giants.";
        }
        if (mergedCharacteristics.SlayDemon)
        {
            info[i++] = "It strikes at demons with holy wrath.";
        }
        if (mergedCharacteristics.SlayUndead)
        {
            info[i++] = "It strikes at undead with holy wrath.";
        }
        if (mergedCharacteristics.SlayEvil)
        {
            info[i++] = "It fights against evil with holy fury.";
        }
        if (mergedCharacteristics.SlayAnimal)
        {
            info[i++] = "It is especially deadly against natural creatures.";
        }
        if (mergedCharacteristics.SustStr)
        {
            info[i++] = "It sustains your strength.";
        }
        if (mergedCharacteristics.SustInt)
        {
            info[i++] = "It sustains your intelligence.";
        }
        if (mergedCharacteristics.SustWis)
        {
            info[i++] = "It sustains your wisdom.";
        }
        if (mergedCharacteristics.SustDex)
        {
            info[i++] = "It sustains your dexterity.";
        }
        if (mergedCharacteristics.SustCon)
        {
            info[i++] = "It sustains your constitution.";
        }
        if (mergedCharacteristics.SustCha)
        {
            info[i++] = "It sustains your charisma.";
        }
        if (mergedCharacteristics.ImAcid)
        {
            info[i++] = "It provides immunity to acid.";
        }
        if (mergedCharacteristics.ImElec)
        {
            info[i++] = "It provides immunity to electricity.";
        }
        if (mergedCharacteristics.ImFire)
        {
            info[i++] = "It provides immunity to fire.";
        }
        if (mergedCharacteristics.ImCold)
        {
            info[i++] = "It provides immunity to cold.";
        }
        if (mergedCharacteristics.FreeAct)
        {
            info[i++] = "It provides immunity to paralysis.";
        }
        if (mergedCharacteristics.HoldLife)
        {
            info[i++] = "It provides resistance to life draining.";
        }
        if (mergedCharacteristics.ResFear)
        {
            info[i++] = "It makes you completely fearless.";
        }
        if (mergedCharacteristics.ResAcid)
        {
            info[i++] = "It provides resistance to acid.";
        }
        if (mergedCharacteristics.ResElec)
        {
            info[i++] = "It provides resistance to electricity.";
        }
        if (mergedCharacteristics.ResFire)
        {
            info[i++] = "It provides resistance to fire.";
        }
        if (mergedCharacteristics.ResCold)
        {
            info[i++] = "It provides resistance to cold.";
        }
        if (mergedCharacteristics.ResPois)
        {
            info[i++] = "It provides resistance to poison.";
        }
        if (mergedCharacteristics.ResLight)
        {
            info[i++] = "It provides resistance to light.";
        }
        if (mergedCharacteristics.ResDark)
        {
            info[i++] = "It provides resistance to dark.";
        }
        if (mergedCharacteristics.ResBlind)
        {
            info[i++] = "It provides resistance to blindness.";
        }
        if (mergedCharacteristics.ResConf)
        {
            info[i++] = "It provides resistance to confusion.";
        }
        if (mergedCharacteristics.ResSound)
        {
            info[i++] = "It provides resistance to sound.";
        }
        if (mergedCharacteristics.ResShards)
        {
            info[i++] = "It provides resistance to shards.";
        }
        if (mergedCharacteristics.ResNether)
        {
            info[i++] = "It provides resistance to nether.";
        }
        if (mergedCharacteristics.ResNexus)
        {
            info[i++] = "It provides resistance to nexus.";
        }
        if (mergedCharacteristics.ResChaos)
        {
            info[i++] = "It provides resistance to chaos.";
        }
        if (mergedCharacteristics.ResDisen)
        {
            info[i++] = "It provides resistance to disenchantment.";
        }
        if (mergedCharacteristics.Wraith)
        {
            info[i++] = "It renders you incorporeal.";
        }
        if (mergedCharacteristics.Feather)
        {
            info[i++] = "It allows you to levitate.";
        }
        if (mergedCharacteristics.Radius > 0 && Factory.BurnRate == 0)
        {
            info[i++] = "It provides permanent light.";
        }
        if (mergedCharacteristics.SeeInvis)
        {
            info[i++] = "It allows you to see invisible monsters.";
        }
        if (mergedCharacteristics.Telepathy)
        {
            info[i++] = "It gives telepathic powers.";
        }
        if (mergedCharacteristics.SlowDigest)
        {
            info[i++] = "It slows your metabolism.";
        }
        if (mergedCharacteristics.Regen)
        {
            info[i++] = "It speeds your regenerative powers.";
        }
        if (mergedCharacteristics.Reflect)
        {
            info[i++] = "It reflects bolts and arrows.";
        }
        if (mergedCharacteristics.ShFire)
        {
            info[i++] = "It produces a fiery sheath.";
        }
        if (mergedCharacteristics.ShElec)
        {
            info[i++] = "It produces an electric sheath.";
        }
        if (mergedCharacteristics.NoMagic)
        {
            info[i++] = "It produces an anti-magic shell.";
        }
        if (mergedCharacteristics.NoTele)
        {
            info[i++] = "It prevents teleportation.";
        }
        if (mergedCharacteristics.XtraMight)
        {
            info[i++] = "It fires missiles with extra might.";
        }
        if (mergedCharacteristics.XtraShots)
        {
            info[i++] = "It fires missiles excessively fast.";
        }
        if (mergedCharacteristics.DrainExp)
        {
            info[i++] = "It drains experience.";
        }
        if (mergedCharacteristics.Teleport)
        {
            info[i++] = "It induces random teleportation.";
        }
        if (mergedCharacteristics.Aggravate)
        {
            info[i++] = "It aggravates nearby creatures.";
        }
        if (mergedCharacteristics.Blessed)
        {
            info[i++] = "It has been blessed by the gods.";
        }
        if (IsCursed)
        {
            if (mergedCharacteristics.PermaCurse)
            {
                info[i++] = "It is permanently cursed.";
            }
            else if (mergedCharacteristics.HeavyCurse)
            {
                info[i++] = "It is heavily cursed.";
            }
            else
            {
                info[i++] = "It is cursed.";
            }
        }
        if (mergedCharacteristics.DreadCurse)
        {
            info[i++] = "It carries an ancient foul curse.";
        }
        if (mergedCharacteristics.IgnoreAcid)
        {
            info[i++] = "It cannot be harmed by acid.";
        }
        if (mergedCharacteristics.IgnoreElec)
        {
            info[i++] = "It cannot be harmed by electricity.";
        }
        if (mergedCharacteristics.IgnoreFire)
        {
            info[i++] = "It cannot be harmed by fire.";
        }
        if (mergedCharacteristics.IgnoreCold)
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
        if (Factory.EasyKnow && Factory.IsFlavorAware)
        {
            return true;
        }
        return false;
    }

    public bool IsRare()
    {
        return RareItem != null;
    }

    public ItemCharacteristics ObjectFlagsKnown()
    {
        if (!IsKnown())
        {
            return new ItemCharacteristics();
        }
        return GetMergedCharacteristics();
    }

    /// <summary>
    /// Indicate that the item has been tried.
    /// </summary>
    public void ObjectTried()
    {
        Factory.Tried = true;
    }

    /// <summary>
    /// Returns the actual value of the item.  This real value may not be known, if the item is unknown.  This real value is also used by the Alchemy script to convert the item into gold.
    /// </summary>
    /// <returns></returns>
    public int GetRealValue()
    {
        if (Factory.Cost == 0)
        {
            return 0;
        }
        int value = Factory.Cost;
        if (FixedArtifact != null)
        {
            if (FixedArtifact.Cost == 0)
            {
                return 0;
            }
            value = FixedArtifact.Cost;
        }
        else if (RareItem != null)
        {
            if (RareItem.Cost == 0)
            {
                return 0;
            }
            value += RareItem.Cost;
        }

        ItemCharacteristics mergedCharacteristics = GetMergedCharacteristics();
        if (mergedCharacteristics.Chaotic)
        {
            value += Game.BonusChaoticValue;
        }
        if (mergedCharacteristics.Vampiric)
        {
            value += Game.BonusVampiricValue;
        }
        if (mergedCharacteristics.AntiTheft)
        {
            value += Game.BonusAntiTheftValue;
        }
        if (mergedCharacteristics.SlayAnimal)
        {
            value += Game.BonusSlayAnimalValue;
        }
        if (mergedCharacteristics.SlayEvil)
        {
            value += Game.BonusSlayEvilValue;
        }
        if (mergedCharacteristics.SlayUndead)
        {
            value += Game.BonusSlayUndeadValue;
        }
        if (mergedCharacteristics.SlayDemon)
        {
            value += Game.BonusSlayDemonValue;
        }
        if (mergedCharacteristics.SlayOrc)
        {
            value += Game.BonusSlayOrcValue;
        }
        if (mergedCharacteristics.SlayTroll)
        {
            value += Game.BonusSlayTrollValue;
        }
        if (mergedCharacteristics.SlayGiant)
        {
            value += Game.BonusSlayGiantlValue;
        }
        if (mergedCharacteristics.SlayDragon)
        {
            value += Game.BonusSlayDragonValue;
        }
        if (mergedCharacteristics.KillDragon)
        {
            value += Game.BonusKillDragonValue;
        }
        if (mergedCharacteristics.Vorpal)
        {
            value += Game.BonusVorpalValue;
        }
        if (mergedCharacteristics.Impact)
        {
            value += Game.BonusImpactValue;
        }
        if (mergedCharacteristics.BrandPois)
        {
            value += Game.BonusBrandPoisValue;
        }
        if (mergedCharacteristics.BrandAcid)
        {
            value += Game.BonusBrandAcidValue;
        }
        if (mergedCharacteristics.BrandElec)
        {
            value += Game.BonusBrandElecValue;
        }
        if (mergedCharacteristics.BrandFire)
        {
            value += Game.BonusBrandFireValue;
        }
        if (mergedCharacteristics.BrandCold)
        {
            value += Game.BonusBrandColdValue;
        }
        if (mergedCharacteristics.SustStr)
        {
            value += Game.BonusSustStrValue;
        }
        if (mergedCharacteristics.SustInt)
        {
            value += Game.BonusSustIntValue;
        }
        if (mergedCharacteristics.SustWis)
        {
            value += Game.BonusSustWisValue;
        }
        if (mergedCharacteristics.SustDex)
        {
            value += Game.BonusSustDexValue;
        }
        if (mergedCharacteristics.SustCon)
        {
            value += Game.BonusSustConValue;
        }
        if (mergedCharacteristics.SustCha)
        {
            value += Game.BonusSustChaValue;
        }
        if (mergedCharacteristics.ImAcid)
        {
            value += Game.BonusImAcidValue;
        }
        if (mergedCharacteristics.ImElec)
        {
            value += Game.BonusImElecValue;
        }
        if (mergedCharacteristics.ImFire)
        {
            value += Game.BonusImFireValue;
        }
        if (mergedCharacteristics.ImCold)
        {
            value += Game.BonusImColdValue;
        }
        if (mergedCharacteristics.Reflect)
        {
            value += Game.BonusReflectValue;
        }
        if (mergedCharacteristics.FreeAct)
        {
            value += Game.BonusFreeActValue;
        }
        if (mergedCharacteristics.HoldLife)
        {
            value += Game.BonusHoldLifeValue;
        }
        if (mergedCharacteristics.ResAcid)
        {
            value += Game.BonusResAcidValue;
        }
        if (mergedCharacteristics.ResElec)
        {
            value += Game.BonusResElecValue;
        }
        if (mergedCharacteristics.ResFire)
        {
            value += Game.BonusResFireValue;
        }
        if (mergedCharacteristics.ResCold)
        {
            value += Game.BonusResColdValue;
        }
        if (mergedCharacteristics.ResPois)
        {
            value += Game.BonusResPoisValue;
        }
        if (mergedCharacteristics.ResFear)
        {
            value += Game.BonusResFearValue;
        }
        if (mergedCharacteristics.ResLight)
        {
            value += Game.BonusResLightValue;
        }
        if (mergedCharacteristics.ResDark)
        {
            value += Game.BonusResDarkValue;
        }
        if (mergedCharacteristics.ResBlind)
        {
            value += Game.BonusResBlindValue;
        }
        if (mergedCharacteristics.ResConf)
        {
            value += Game.BonusResConfValue;
        }
        if (mergedCharacteristics.ResSound)
        {
            value += Game.BonusResSoundValue;
        }
        if (mergedCharacteristics.ResShards)
        {
            value += Game.BonusResShardsValue;
        }
        if (mergedCharacteristics.ResNether)
        {
            value += Game.BonusResNetherValue;
        }
        if (mergedCharacteristics.ResNexus)
        {
            value += Game.BonusResNexusValue;
        }
        if (mergedCharacteristics.ResChaos)
        {
            value += Game.BonusResChaosValue;
        }
        if (mergedCharacteristics.ResDisen)
        {
            value += Game.BonusResDisenValue;
        }
        if (mergedCharacteristics.ShFire)
        {
            value += Game.BonusShFireValue;
        }
        if (mergedCharacteristics.ShElec)
        {
            value += Game.BonusShElecValue;
        }
        if (mergedCharacteristics.NoTele)
        {
            value += Game.BonusNoTeleValue;
        }
        if (mergedCharacteristics.NoMagic)
        {
            value += Game.BonusNoMagicValue;
        }
        if (mergedCharacteristics.Wraith)
        {
            value += Game.BonusWraithValue;
        }
        if (mergedCharacteristics.DreadCurse)
        {
            value += Game.BonusDreadCurseValue;
        }
        if (mergedCharacteristics.Feather)
        {
            value += Game.BonusFeatherValue;
        }
        if (mergedCharacteristics.SeeInvis)
        {
            value += Game.BonusSeeInvisValue;
        }
        if (mergedCharacteristics.Telepathy)
        {
            value += Game.BonusTelepathyValue;
        }
        if (mergedCharacteristics.SlowDigest)
        {
            value += Game.BonusSlowDigestValue;
        }
        if (mergedCharacteristics.Regen)
        {
            value += Game.BonusRegenValue;
        }
        if (mergedCharacteristics.XtraMight)
        {
            value += Game.BonusXtraMightValue;
        }
        if (mergedCharacteristics.XtraShots)
        {
            value += Game.BonusXtraShotsValue;
        }
        if (mergedCharacteristics.IgnoreAcid)
        {
            value += Game.BonusIgnoreAcidValue;
        }
        if (mergedCharacteristics.IgnoreElec)
        {
            value += Game.BonusIgnoreElecValue;
        }
        if (mergedCharacteristics.IgnoreFire)
        {
            value += Game.BonusIgnoreFireValue;
        }
        if (mergedCharacteristics.IgnoreCold)
        {
            value += Game.BonusIgnoreColdValue;
        }
        if (mergedCharacteristics.DrainExp)
        {
            value += Game.BonusDrainExpValue;
        }
        if (mergedCharacteristics.Teleport)
        {
            value += Game.BonusTeleportValue;
        }
        if (mergedCharacteristics.Aggravate)
        {
            value += Game.BonusAggravateValue;
        }
        if (mergedCharacteristics.Blessed)
        {
            value += Game.BonusBlessedValue;
        }
        if (mergedCharacteristics.IsCursed)
        {
            value += Game.BonusIsCursedValue;
        }
        if (mergedCharacteristics.HeavyCurse)
        {
            value += Game.BonusHeavyCurseValue;
        }
        if (mergedCharacteristics.PermaCurse)
        {
            value += Game.BonusPermaCurseValue;
        }
        if (mergedCharacteristics.Str)
        {
            value += BonusStrength * Game.BonusStrengthValue;
        }
        if (mergedCharacteristics.Int)
        {
            value += BonusIntelligence * Game.BonusIntelligenceValue;
        }
        if (mergedCharacteristics.Wis)
        {
            value += BonusWisdom * Game.BonusWisdomValue;
        }
        if (mergedCharacteristics.Dex)
        {
            value += BonusDexterity * Game.BonusDexterityValue;
        }
        if (mergedCharacteristics.Con)
        {
            value += BonusConstitution * Game.BonusConstitutionValue;
        }
        if (mergedCharacteristics.Cha)
        {
            value += BonusCharisma * Game.BonusCharismaValue;
        }
        if (mergedCharacteristics.Stealth)
        {
            value += BonusStealth * Game.BonusStealthValue;
        }
        if (mergedCharacteristics.Search)
        {
            value += BonusSearch * Game.BonusSearchValue;
        }
        if (mergedCharacteristics.Infra)
        {
            value += BonusInfravision * Game.BonusInfravisionValue;
        }
        if (mergedCharacteristics.Tunnel)
        {
            value += BonusTunnel * Game.BonusTunnelValue;
        }
        if (mergedCharacteristics.Blows)
        {
            value += BonusAttacks * Game.BonusExtraBlowslValue;
        }
        if (mergedCharacteristics.Speed)
        {
            value += BonusSpeed * Game.BonusSpeedlValue;
        }

        if (mergedCharacteristics.Activation != null)
        {
            value += mergedCharacteristics.Activation.Value;
        }

        value += Factory.WandChargeValue * WandChargesRemaining;
        value += Factory.StaffChargeValue * StaffChargesRemaining;
        value += Factory.TurnOfLightValue * TurnsOfLightRemaining;
        value += Factory.GetBonusRealValue(this);
        return value;
    }

    public bool Stompable()
    {
        if (!IsKnown())
        {
            if (Factory.ItemClass.HasFlavor)
            {
                if (Factory.IsFlavorAware)
                {
                    return Factory.Stompable[StompableType.Broken];
                }
            }
            if (!IdentSense)
            {
                return false;
            }
        }
        return Factory.IsStompable(this);
    }

    /// <summary>
    /// Returns a description for the item.
    /// </summary>
    /// <returns></returns>
    /// <remarks>There may not be any references in code but this method is very useful for debugging.</remarks>
    public override string ToString()
    {
        return GetDescription(false);
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
            if (IsCursed)
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
            if (IdentSense && IsCursed)
            {
                return 0;
            }
            if (Factory.IsFlavorAware)
            {
                return Factory.Cost;
            }
            return Factory.BaseValue;
        }
        if (Discount != 0)
        {
            value -= value * Discount / 100;
        }
        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lev"></param>
    /// <param name="okay">Stores send false.  The game otherwise sends true.  Wizards get to select the value.</param>
    /// <param name="good">Stores send false.  Monsters will have a good item count Monster.DropGood. When true, skips the percentile roll for good objects.</param>
    /// <param name="great">Stores send false.  Monsters will have a great item count Monster.DropGreat. When true, skips the percentile roll for great objects.</param>
    /// <param name="store"></param>
    public void EnchantItem(int lev, bool okay, bool good, bool great, bool usedOkay)
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
        int rollsForFixedArtifactAttempts = 0;
        if (power >= 2)
        {
            rollsForFixedArtifactAttempts = 1;
        }
        if (great)
        {
            rollsForFixedArtifactAttempts = 4;
        }
        if (!okay || FixedArtifact != null)
        {
            rollsForFixedArtifactAttempts = 0;
        }
        for (int i = 0; i < rollsForFixedArtifactAttempts; i++)
        {
            if (ApplyFixedArtifact())
            {
                break;
            }
        }
        if (FixedArtifact != null)
        {
            FixedArtifact.CurNum = 1;
            BonusStrength = FixedArtifact.InitialBonusStrength;
            BonusIntelligence = FixedArtifact.InitialBonusIntelligence;
            BonusWisdom = FixedArtifact.InitialBonusWisdom;
            BonusDexterity = FixedArtifact.InitialBonusDexterity;
            BonusConstitution = FixedArtifact.InitialBonusConstitution;
            BonusCharisma = FixedArtifact.InitialBonusCharisma;
            BonusStealth = FixedArtifact.InitialBonusStealth;
            BonusSearch = FixedArtifact.InitialBonusSearch;
            BonusInfravision = FixedArtifact.InitialBonusInfravision;
            BonusTunnel = FixedArtifact.InitialBonusTunnel;
            BonusAttacks = FixedArtifact.InitialBonusExtraBlows;
            BonusSpeed = FixedArtifact.InitialBonusSpeed;
            ArmorClass = FixedArtifact.Ac;
            DamageDice = FixedArtifact.Dd;
            DamageSides = FixedArtifact.Ds;
            BonusArmorClass = FixedArtifact.ToA;
            BonusHit = FixedArtifact.ToH;
            BonusDamage = FixedArtifact.ToD;
            Weight = FixedArtifact.Weight;
            if (FixedArtifact.Cost == 0)
            {
                IsBroken = true;
            }
            if (FixedArtifact.IsCursed)
            {
                IsCursed = true;
            }
            Game.TreasureRating += FixedArtifact.TreasureRating;
            Game.SpecialTreasure = true;
            return;
        }
        Factory.EnchantItem(this, usedOkay, lev, power);
        Game.TreasureRating += Factory.TreasureRating;
        if (IsRandomArtifact)
        {
            Game.TreasureRating += Characteristics.TreasureRating;
        }
        else if (RareItem != null)
        {
            RareItem.ApplyMagic(this);
            if (RareItem.Cost == 0)
            {
                IsBroken = true;
            }
            if (RareItem.IsCursed)
            {
                IsCursed = true;
            }

            // Check to see if we are enchanting a cursed or broken item.
            if (IsCursed || IsBroken)
            {
                if (RareItem.MaxToH != 0)
                {
                    BonusHit -= Game.DieRoll(RareItem.MaxToH);
                }
                if (RareItem.MaxToD != 0)
                {
                    BonusDamage -= Game.DieRoll(RareItem.MaxToD);
                }
                if (RareItem.MaxToA != 0)
                {
                    BonusArmorClass -= Game.DieRoll(RareItem.MaxToA);
                }
                if (RareItem.BonusStrength != null)
                {
                    BonusStrength -= RareItem.BonusStrength.Get(Game.UseRandom);
                }
                if (RareItem.BonusIntelligence != null)
                {
                    BonusIntelligence -= RareItem.BonusIntelligence.Get(Game.UseRandom);
                }
                if (RareItem.BonusWisdom != null)
                {
                    BonusWisdom -= RareItem.BonusWisdom.Get(Game.UseRandom);
                }
                if (RareItem.BonusDexterity != null)
                {
                    BonusDexterity -= RareItem.BonusDexterity.Get(Game.UseRandom);
                }
                if (RareItem.BonusConstitution != null)
                {
                    BonusConstitution -= RareItem.BonusConstitution.Get(Game.UseRandom);
                }
                if (RareItem.BonusCharisma != null)
                {
                    BonusCharisma -= RareItem.BonusCharisma.Get(Game.UseRandom);
                }
                if (RareItem.BonusStealth != null)
                {
                    BonusStealth -= RareItem.BonusStealth.Get(Game.UseRandom);
                }
                if (RareItem.BonusSearch != null)
                {
                    BonusSearch -= RareItem.BonusSearch.Get(Game.UseRandom);
                }
                if (RareItem.BonusInfravision != null)
                {
                    BonusInfravision -= RareItem.BonusInfravision.Get(Game.UseRandom);
                }
                if (RareItem.BonusTunnel != null)
                {
                    BonusTunnel -= RareItem.BonusTunnel.Get(Game.UseRandom);
                }
                if (RareItem.BonusAttacks != null)
                {
                    BonusAttacks -= RareItem.BonusAttacks.Get(Game.UseRandom);
                }
                if (RareItem.BonusSpeed != null)
                {
                    BonusSpeed -= RareItem.BonusSpeed.Get(Game.UseRandom);
                }
            }
            else
            {
                if (RareItem.MaxToH != 0)
                {
                    BonusHit += Game.DieRoll(RareItem.MaxToH);
                }
                if (RareItem.MaxToD != 0)
                {
                    BonusDamage += Game.DieRoll(RareItem.MaxToD);
                }
                if (RareItem.MaxToA != 0)
                {
                    BonusArmorClass += Game.DieRoll(RareItem.MaxToA);
                }
                if (RareItem.BonusStrength != null)
                {
                    BonusStrength += RareItem.BonusStrength.Get(Game.UseRandom);
                }
                if (RareItem.BonusIntelligence != null)
                {
                    BonusIntelligence += RareItem.BonusIntelligence.Get(Game.UseRandom);
                }
                if (RareItem.BonusWisdom != null)
                {
                    BonusWisdom += RareItem.BonusWisdom.Get(Game.UseRandom);
                }
                if (RareItem.BonusDexterity != null)
                {
                    BonusDexterity += RareItem.BonusDexterity.Get(Game.UseRandom);
                }
                if (RareItem.BonusConstitution != null)
                {
                    BonusConstitution += RareItem.BonusConstitution.Get(Game.UseRandom);
                }
                if (RareItem.BonusCharisma != null)
                {
                    BonusCharisma += RareItem.BonusCharisma.Get(Game.UseRandom);
                }
                if (RareItem.BonusStealth != null)
                {
                    BonusStealth += RareItem.BonusStealth.Get(Game.UseRandom);
                }
                if (RareItem.BonusSearch != null)
                {
                    BonusSearch += RareItem.BonusSearch.Get(Game.UseRandom);
                }
                if (RareItem.BonusInfravision != null)
                {
                    BonusInfravision += RareItem.BonusInfravision.Get(Game.UseRandom);
                }
                if (RareItem.BonusTunnel != null)
                {
                    BonusTunnel += RareItem.BonusTunnel.Get(Game.UseRandom);
                }
                if (RareItem.BonusAttacks != null)
                {
                    BonusAttacks += RareItem.BonusAttacks.Get(Game.UseRandom);
                }
                if (RareItem.BonusSpeed != null)
                {
                    BonusSpeed += RareItem.BonusSpeed.Get(Game.UseRandom);
                }
            }
            Game.TreasureRating += RareItem.TreasureRating;
            return;
        }
        if (Factory != null)
        {
            if (Factory.Cost == 0)
            {
                IsBroken = true;
            }
            if (Factory.IsCursed)
            {
                IsCursed = true;
            }
        }
    }

    public void ApplyRandomResistance(WeightedRandom<ItemAdditiveBundle> itemAdditiveBundleWeightedRandom)
    {
        ItemAdditiveBundle? itemAdditiveBundle = itemAdditiveBundleWeightedRandom.ChooseOrDefault();
        if (itemAdditiveBundle != null)
        {
            Characteristics.Merge(itemAdditiveBundle);
        }
    }

    private int EnchantBonus(int bonus)
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

    public bool CreateRandomArtifact(bool fromScroll)
    {
        const int ArtifactCurseChance = 13;
        int powers = Game.DieRoll(5) + 1;
        bool aCursed = false;
        int warriorArtifactBias = 0;
        if (fromScroll && Game.DieRoll(4) == 1)
        {
            Characteristics.ArtifactBias = Game.BaseCharacterClass.ArtifactBias;
            warriorArtifactBias = Game.BaseCharacterClass.FromScrollWarriorArtifactBiasPercentageChance;
        }
        if (Game.DieRoll(100) <= warriorArtifactBias && fromScroll)
        {
            Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WarriorArtifactBias));
        }
        string newName;
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
            int maxType = (Factory.CanApplySlayingBonus ? 7 : 5);
            switch (Game.DieRoll(maxType))
            {
                case 1:
                case 2:
                    ApplyRandomBonuses();
                    break;
                case 3:
                case 4:
                    if (Characteristics.ArtifactBias != null)
                    {
                        Characteristics.ArtifactBias.ApplyRandomResistances(this);
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

                        if (Factory.CanProvideSheathOfElectricity)
                        {
                            itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(SheathOfElectricityAndElectricityBiasItemAdditiveBundle)));
                        }

                        if (Factory.CanProvideSheathOfFire)
                        {
                            itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(SheathOfFireAndFireBiasItemAdditiveBundle)));
                        }

                        if (Factory.CanReflectBoltsAndArrows)
                        {
                            itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ReflectBoltsAndArrowsItemAdditiveBundle)));
                        }

                        ApplyRandomResistance(itemAdditiveBundleWeightedRandom);
                    }
                    break;

                case 5:
                    ApplyMiscPowerForRandomArtifactCreation();
                    break;

                case 6:
                case 7:
                    Factory.ApplySlayingForRandomArtifactCreation(this);
                    break;

                default:
                    powers++;
                    break;
            }
        }
        Factory.ApplyBonusForRandomArtifactCreation(this);
        Characteristics.IgnoreAcid = true;
        Characteristics.IgnoreElec = true;
        Characteristics.IgnoreFire = true;
        Characteristics.IgnoreCold = true;
        Characteristics.TreasureRating = 40;

        if (aCursed)
        {
            CurseRandart();
        }
        if (!aCursed && Game.DieRoll(Factory.RandartActivationChance) == 1)
        {
            Characteristics.Activation = null;
            if (Characteristics.ArtifactBias != null)
            {
                if (Game.DieRoll(100) < Characteristics.ArtifactBias.ActivationPowerChance)
                {
                    Characteristics.Activation = Characteristics.ArtifactBias.GetActivationPowerType(this);
                }
            }
            if (Characteristics.Activation == null)
            {
                Characteristics.Activation = Game.SingletonRepository.Get<ActivationWeightedRandom>(nameof(RandomArtifactActivationWeightedRandom)).ChooseOrDefault();
            }
            ActivationRechargeTimeRemaining = 0;
        }
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
            Factory.IsFlavorAware = true;
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

    public void GetFixedArtifactResistances()
    {
        if (FixedArtifact != null)
        {
            FixedArtifact.ApplyResistances(this);
        }
    }

    private bool ApplyFixedArtifact()
    {
        if (Count != 1)
        {
            return false;
        }
        foreach (FixedArtifact aPtr in Game.SingletonRepository.Get<FixedArtifact>())
        {
            if (aPtr.HasOwnType)
            {
                continue;
            }

            // Do not create another, if there is already one in the game.
            if (aPtr.CurNum != 0)
            {
                continue;
            }

            if (aPtr.BaseItemFactory != Factory)
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
            FixedArtifact = aPtr;
            GetFixedArtifactResistances();
            return true;
        }
        return false;
    }

    private void ApplyRandomBonuses()
    {
        if (Characteristics.ArtifactBias != null)
        {
            if (Characteristics.ArtifactBias.ApplyBonuses(this))
            {
                return;
            }
        }
        switch (Game.DieRoll(23))
        {
            case 1:
            case 2:
                Characteristics.Str = true;
                BonusStrength = EnchantBonus(BonusStrength);
                if (Characteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(StrengthArtifactBias));
                }
                else if (Characteristics.ArtifactBias == null && Game.DieRoll(7) == 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WarriorArtifactBias));
                }
                break;

            case 3:
            case 4:
                Characteristics.Int = true;
                BonusIntelligence = EnchantBonus(BonusIntelligence);
                if (Characteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(IntelligenceArtifactBias));
                }
                else if (Characteristics.ArtifactBias == null && Game.DieRoll(7) == 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(MageArtifactBias));
                }
                break;

            case 5:
            case 6:
                Characteristics.Wis = true;
                BonusWisdom = EnchantBonus(BonusWisdom);
                if (Characteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WisdomArtifactBias));
                }
                else if (Characteristics.ArtifactBias == null && Game.DieRoll(7) == 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
                }
                break;

            case 7:
            case 8:
                Characteristics.Dex = true;
                BonusDexterity = EnchantBonus(BonusDexterity);
                if (Characteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(DexterityArtifactBias));
                }
                else if (Characteristics.ArtifactBias == null && Game.DieRoll(7) == 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RogueArtifactBias));
                }
                break;

            case 9:
            case 10:
                Characteristics.Con = true;
                BonusConstitution = EnchantBonus(BonusConstitution);
                if (Characteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(ConstitutionArtifactBias));
                }
                else if (Characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RangerArtifactBias));
                }
                break;

            case 11:
            case 12:
                Characteristics.Cha = true;
                BonusCharisma = EnchantBonus(BonusCharisma);
                if (Characteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(CharismaArtifactBias));
                }
                break;

            case 13:
            case 14:
                Characteristics.Stealth = true;
                BonusStealth = EnchantBonus(BonusStealth);
                if (Characteristics.ArtifactBias == null && Game.DieRoll(3) == 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RogueArtifactBias));
                }
                break;

            case 15:
            case 16:
                Characteristics.Search = true;
                BonusSearch = EnchantBonus(BonusSearch);
                if (Characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RangerArtifactBias));
                }
                break;

            case 17:
            case 18:
                Characteristics.Infra = true;
                BonusInfravision = EnchantBonus(BonusInfravision);
                break;

            case 19:
                Characteristics.Speed = true;
                BonusSpeed = EnchantBonus(BonusSpeed);
                if (Characteristics.ArtifactBias == null && Game.DieRoll(11) == 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RogueArtifactBias));
                }
                break;

            case 20:
            case 21:
                Characteristics.Tunnel = true;
                BonusTunnel = EnchantBonus(BonusTunnel);
                break;

            case 22:
            case 23:
                if (Factory.CanApplyBlowsBonus)
                {
                    ApplyRandomBonuses();
                }
                else
                {
                    Characteristics.Blows = true;
                    BonusAttacks = Game.DieRoll(2) + 1;
                    if (BonusAttacks > 4 && Game.DieRoll(Constants.WeirdLuck) != 1)
                    {
                        BonusAttacks = 4;
                    }
                    if (Characteristics.ArtifactBias == null && Game.DieRoll(11) == 1)
                    {
                        Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WarriorArtifactBias));
                    }
                }
                break;
        }
    }

    private void ApplyMiscPowerForRandomArtifactCreation()
    {
        if (Characteristics.ArtifactBias != null)
        {
            Characteristics.ArtifactBias.ApplyMiscPowers(this);
        }
        switch (Game.DieRoll(31))
        {
            case 1:
                Characteristics.SustStr = true;
                if (Characteristics.ArtifactBias == null)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(StrengthArtifactBias));
                }
                break;

            case 2:
                Characteristics.SustInt = true;
                if (Characteristics.ArtifactBias == null)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(IntelligenceArtifactBias));
                }
                break;

            case 3:
                Characteristics.SustWis = true;
                if (Characteristics.ArtifactBias == null)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WisdomArtifactBias));
                }
                break;

            case 4:
                Characteristics.SustDex = true;
                if (Characteristics.ArtifactBias == null)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(DexterityArtifactBias));
                }
                break;

            case 5:
                Characteristics.SustCon = true;
                if (Characteristics.ArtifactBias == null)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(ConstitutionArtifactBias));
                }
                break;

            case 6:
                Characteristics.SustCha = true;
                if (Characteristics.ArtifactBias == null)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(CharismaArtifactBias));
                }
                break;

            case 7:
            case 8:
            case 14:
                Characteristics.FreeAct = true;
                break;

            case 9:
                Characteristics.HoldLife = true;
                if (Characteristics.ArtifactBias == null && Game.DieRoll(5) == 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
                }
                else if (Characteristics.ArtifactBias == null && Game.DieRoll(6) == 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(NecromanticArtifactBias));
                }
                break;

            case 10:
            case 11:
                Characteristics.Radius = 3;
                break;

            case 12:
            case 13:
                Characteristics.Feather = true;
                break;

            case 15:
            case 16:
            case 17:
                Characteristics.SeeInvis = true;
                break;

            case 18:
                Characteristics.Telepathy = true;
                if (Characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                {
                    Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(MageArtifactBias));
                }
                break;

            case 19:
            case 20:
                Characteristics.SlowDigest = true;
                break;

            case 21:
            case 22:
                Characteristics.Regen = true;
                break;

            case 23:
                Characteristics.Teleport = true;
                break;

            case 24:
            case 25:
            case 26:
                if (!Factory.CanApplyBonusArmorClassMiscPower)
                {
                    // This item cannot have misc power, select a different
                    ApplyMiscPowerForRandomArtifactCreation();
                }
                else
                {
                    Characteristics.ShowMods = true;
                    BonusArmorClass = 4 + Game.DieRoll(11);
                }
                break;

            case 27:
            case 28:
            case 29:
                Characteristics.ShowMods = true;
                BonusHit += 4 + Game.DieRoll(11);
                BonusDamage += 4 + Game.DieRoll(11);
                break;

            case 30:
                Characteristics.NoMagic = true;
                break;

            case 31:
                Characteristics.NoTele = true;
                break;
        }
    }

    private void CurseRandart()
    {
        if (BonusStrength != 0)
        {
            BonusStrength = 0 - (BonusStrength + Game.DieRoll(4));
        }
        if (BonusIntelligence != 0)
        {
            BonusIntelligence = 0 - (BonusIntelligence + Game.DieRoll(4));
        }
        if (BonusWisdom != 0)
        {
            BonusWisdom = 0 - (BonusWisdom + Game.DieRoll(4));
        }
        if (BonusDexterity != 0)
        {
            BonusDexterity = 0 - (BonusDexterity + Game.DieRoll(4));
        }
        if (BonusConstitution != 0)
        {
            BonusConstitution = 0 - (BonusConstitution + Game.DieRoll(4));
        }
        if (BonusCharisma != 0)
        {
            BonusCharisma = 0 - (BonusCharisma + Game.DieRoll(4));
        }
        if (BonusStealth != 0)
        {
            BonusStealth = 0 - (BonusStealth + Game.DieRoll(4));
        }
        if (BonusSearch != 0)
        {
            BonusSearch = 0 - (BonusSearch + Game.DieRoll(4));
        }
        if (BonusInfravision != 0)
        {
            BonusInfravision = 0 - (BonusInfravision + Game.DieRoll(4));
        }
        if (BonusTunnel != 0)
        {
            BonusTunnel = 0 - (BonusTunnel + Game.DieRoll(4));
        }
        if (BonusAttacks != 0)
        {
            BonusAttacks = 0 - (BonusAttacks + Game.DieRoll(4));
        }
        if (BonusSpeed != 0)
        {
            BonusSpeed = 0 - (BonusSpeed + Game.DieRoll(4));
        }
        if (BonusArmorClass != 0)
        {
            BonusArmorClass = 0 - (BonusArmorClass + Game.DieRoll(4));
        }
        if (BonusHit != 0)
        {
            BonusHit = 0 - (BonusHit + Game.DieRoll(4));
        }
        if (BonusDamage != 0)
        {
            BonusDamage = 0 - (BonusDamage + Game.DieRoll(4));
        }
        Characteristics.HeavyCurse = true;
        Characteristics.IsCursed = true;
        if (Game.DieRoll(4) == 1)
        {
            Characteristics.PermaCurse = true;
        }
        if (Game.DieRoll(3) == 1)
        {
            Characteristics.DreadCurse = true;
        }
        if (Game.DieRoll(2) == 1)
        {
            Characteristics.Aggravate = true;
        }
        if (Game.DieRoll(3) == 1)
        {
            Characteristics.DrainExp = true;
        }
        if (Game.DieRoll(2) == 1)
        {
            Characteristics.Teleport = true;
        }
        else if (Game.DieRoll(3) == 1)
        {
            Characteristics.NoTele = true;
        }
        if (Game.BaseCharacterClass.ID != CharacterClass.Warrior && Game.DieRoll(3) == 1)
        {
            Characteristics.NoMagic = true;
        }
        IsCursed = true;
    }

    private string GenerateRandomArtifactName()
    {
        int testcounter = Game.DieRoll(3) + 1;
        string outString = "";
        if (Game.DieRoll(3) == 2)
        {
            while (testcounter-- != 0)
            {
                outString += Game.SingletonRepository.UnreadableFlavorSyllables.ToWeightedRandom().ChooseOrDefault();
            }
        }
        else
        {
            testcounter = Game.DieRoll(2) + 1;
            while (testcounter-- != 0)
            {
                outString += Game.SingletonRepository.ElvishText.ToWeightedRandom().ChooseOrDefault();
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
}