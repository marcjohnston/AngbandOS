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
    public ItemCharacteristics Characteristics = new ItemCharacteristics();

    /// <summary>
    /// Returns the factory that created this item.
    /// </summary>
    public ItemFactory Factory { get; private set; } // TODO: This should be protected ... and force the item to call the factory methods.

    public FixedArtifact? FixedArtifact; // If this item is a fixed artifact, this will be not null.

    /// <summary>
    /// Returns the rare item, if the item is a rare item; or null, if the item is not rare.
    /// </summary>
    public RareItem? RareItem = null;

    public ItemCharacteristics RandomArtifactItemCharacteristics = new ItemCharacteristics();

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
    /// This property used to be a flag in the IdentifyFlags.  The item has been identified.  
    /// </summary>
    public bool IdentKnown;

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
    public bool IdentCursed;

    /// <summary>
    /// This property used to be a flag in the IdentifyFlags.
    /// </summary>
    public bool IdentBroken;

    public int ArmorClass;
    public int BonusArmorClass;
    public int BonusDamage;
    public Activation? RandomArtifactActivation = null;

    /// <summary>
    /// Returns an additional special power that is added for fixed artifacts and rare items.
    /// </summary>
    public Power? RandomPower = null;

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

    public bool Marked;

    public int RingsArmorActivationAndFixedArtifactsRechargeTimeLeft;

    /// <summary>
    /// Returns a value that is specific to the item class.
    /// Chest - The number of items in the chest. 
    ///   <0 => Average ... untrapped with ABS value being the level of objects +10 
    ///   0  => empty or opened
    ///   >0 => the index of the chest trap configuration and the level of the items + 10
    /// Ring?
    /// Weapons (Blows) - The weapon attacks
    /// FOR ALL EQUIMENT - The bonus value for item.characteristic.(str, int, wis, dex, cha, dex, stealth, search, infra, tunnel, speed and blows
    /// </summary>
    public int TypeSpecificValue;

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
        TypeSpecificValue = Factory.InitialTypeSpecificValue;
        NutritionalValue = Factory.InitialNutritionalValue;        
        GoldPieces = Factory.InitialGoldPiecesRoll.Get(Game.UseRandom);
        TurnsOfLightRemaining = Factory.InitialTurnsOfLight;
        WandChargesRemaining = Factory.RodChargeCount;
        Count = 1;
        Weight = Factory.Weight;
        BonusHit = Factory.BonusHit;
        BonusDamage = Factory.BonusDamage;
        BonusArmorClass = Factory.BonusArmorClass;
        ArmorClass = Factory.ArmorClass;
        DamageDice = Factory.DamageDice;
        DamageSides = Factory.DamageSides;
        if (Factory.Cost <= 0)
        {
            IdentBroken = true;
        }
        if (Factory.Cursed)
        {
            IdentCursed = true;
        }
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
        clonedItem.RandomArtifactItemCharacteristics.Copy(RandomArtifactItemCharacteristics);
        clonedItem.RandomArtifactName = RandomArtifactName;
        clonedItem.DamageDice = DamageDice;
        clonedItem.Discount = Discount;
        clonedItem.DamageSides = DamageSides;
        clonedItem.HoldingMonsterIndex = HoldingMonsterIndex;

        clonedItem.IdentSense = IdentSense;
        clonedItem.IdentFixed = IdentFixed;
        clonedItem.IdentEmpty = IdentEmpty;
        clonedItem.IdentKnown = IdentKnown;
        clonedItem.IdentityIsStoreBought = IdentityIsStoreBought;
        clonedItem.IdentMental = IdentMental;
        clonedItem.IdentCursed = IdentCursed;
        clonedItem.IdentBroken = IdentBroken;

        clonedItem.X = X;
        clonedItem.Y = Y;
        clonedItem.Marked = Marked;
        clonedItem.FixedArtifact = FixedArtifact;
        clonedItem.RareItem = RareItem;
        clonedItem.Inscription = Inscription;
        clonedItem.Count = newCount ?? Count;
        clonedItem.TypeSpecificValue = TypeSpecificValue;
        clonedItem.TurnsOfLightRemaining = TurnsOfLightRemaining;
        clonedItem.NutritionalValue = NutritionalValue;
        clonedItem.RingsArmorActivationAndFixedArtifactsRechargeTimeLeft = RingsArmorActivationAndFixedArtifactsRechargeTimeLeft;
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
        clonedItem.RandomPower = RandomPower;
        clonedItem.RandomArtifactActivation = RandomArtifactActivation;
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

    public string RandomArtifactName = "";

    /// <summary>
    /// Returns true, if the item is a random artifact; false, otherwise.
    /// </summary>
    public bool IsRandomArtifact => !String.IsNullOrEmpty(RandomArtifactName); // TODO: the name is all we have until we can use the random item characteristics as null

    [Obsolete]
    public ItemTypeEnum Category => Factory.CategoryEnum; // TODO: Provided for backwards compatibility.  Will be deleted.

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
        RefreshFlagBasedProperties();
        if (Factory.GetsDamageMultiplier)
        {
            if (Characteristics.SlayAnimal && rPtr.Animal)
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
            if (Characteristics.SlayEvil && rPtr.Evil)
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
            if (Characteristics.SlayUndead && rPtr.Undead)
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
            if (Characteristics.SlayDemon && rPtr.Demon)
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
            if (Characteristics.SlayOrc && rPtr.Orc)
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
            if (Characteristics.SlayTroll && rPtr.Troll)
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
            if (Characteristics.SlayGiant && rPtr.Giant)
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
            if (Characteristics.SlayDragon && rPtr.Dragon)
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
            if (Characteristics.KillDragon && rPtr.Dragon)
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
            if (Characteristics.BrandAcid)
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
            if (Characteristics.BrandElec)
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
            if (Characteristics.BrandFire)
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
            if (Characteristics.BrandCold)
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
            if (Characteristics.BrandPois)
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

    public void BecomeFlavorAware()
    {
        Factory.IsFlavorAware = true;
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
        IdentKnown = true;
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
        if (TypeSpecificValue != other.TypeSpecificValue)
        {
            return false;
        }

        // Only open chests can be combined; otherwise, chests are never combined.
        if (!ContainerIsOpen || !other.ContainerIsOpen)
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
        if (RandomPower != null || other.RandomPower != null)
        {
            return false;
        }
        if (RingsArmorActivationAndFixedArtifactsRechargeTimeLeft != 0 || other.RingsArmorActivationAndFixedArtifactsRechargeTimeLeft != 0)
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
        if (IdentCursed != other.IdentCursed)
        {
            return false;
        }
        if (IdentBroken != other.IdentBroken)
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
                basenm += ' ';
                basenm += FixedArtifact.FriendlyName;
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
        else if (IsCursed() && (IsKnown() || IdentSense))
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

    public int FlagBasedCost(int plusses)
    {
        int total = 0;
        RefreshFlagBasedProperties();
        if (Characteristics.Str)
        {
            total += 1000 * plusses;
        }
        if (Characteristics.Int)
        {
            total += 1000 * plusses;
        }
        if (Characteristics.Wis)
        {
            total += 1000 * plusses;
        }
        if (Characteristics.Dex)
        {
            total += 1000 * plusses;
        }
        if (Characteristics.Con)
        {
            total += 1000 * plusses;
        }
        if (Characteristics.Cha)
        {
            total += 250 * plusses;
        }
        if (Characteristics.Chaotic)
        {
            total += 10000;
        }
        if (Characteristics.Vampiric)
        {
            total += 13000;
        }
        if (Characteristics.Stealth)
        {
            total += 250 * plusses;
        }
        if (Characteristics.Search)
        {
            total += 100 * plusses;
        }
        if (Characteristics.Infra)
        {
            total += 150 * plusses;
        }
        if (Characteristics.Tunnel)
        {
            total += 175 * plusses;
        }
        if (Characteristics.Speed && plusses > 0)
        {
            total += 30000 * plusses;
        }
        if (Characteristics.Blows && plusses > 0)
        {
            total += 2000 * plusses;
        }
        if (Characteristics.AntiTheft)
        {
            total += 0;
        }
        if (Characteristics.SlayAnimal)
        {
            total += 3500;
        }
        if (Characteristics.SlayEvil)
        {
            total += 4500;
        }
        if (Characteristics.SlayUndead)
        {
            total += 3500;
        }
        if (Characteristics.SlayDemon)
        {
            total += 3500;
        }
        if (Characteristics.SlayOrc)
        {
            total += 3000;
        }
        if (Characteristics.SlayTroll)
        {
            total += 3500;
        }
        if (Characteristics.SlayGiant)
        {
            total += 3500;
        }
        if (Characteristics.SlayDragon)
        {
            total += 3500;
        }
        if (Characteristics.KillDragon)
        {
            total += 5500;
        }
        if (Characteristics.Vorpal)
        {
            total += 5000;
        }
        if (Characteristics.Impact)
        {
            total += 5000;
        }
        if (Characteristics.BrandPois)
        {
            total += 7500;
        }
        if (Characteristics.BrandAcid)
        {
            total += 7500;
        }
        if (Characteristics.BrandElec)
        {
            total += 7500;
        }
        if (Characteristics.BrandFire)
        {
            total += 5000;
        }
        if (Characteristics.BrandCold)
        {
            total += 5000;
        }
        if (Characteristics.SustStr)
        {
            total += 850;
        }
        if (Characteristics.SustInt)
        {
            total += 850;
        }
        if (Characteristics.SustWis)
        {
            total += 850;
        }
        if (Characteristics.SustDex)
        {
            total += 850;
        }
        if (Characteristics.SustCon)
        {
            total += 850;
        }
        if (Characteristics.SustCha)
        {
            total += 250;
        }
        if (Characteristics.ImAcid)
        {
            total += 10000;
        }
        if (Characteristics.ImElec)
        {
            total += 10000;
        }
        if (Characteristics.ImFire)
        {
            total += 10000;
        }
        if (Characteristics.ImCold)
        {
            total += 10000;
        }
        if (Characteristics.Reflect)
        {
            total += 10000;
        }
        if (Characteristics.FreeAct)
        {
            total += 4500;
        }
        if (Characteristics.HoldLife)
        {
            total += 8500;
        }
        if (Characteristics.ResAcid)
        {
            total += 1250;
        }
        if (Characteristics.ResElec)
        {
            total += 1250;
        }
        if (Characteristics.ResFire)
        {
            total += 1250;
        }
        if (Characteristics.ResCold)
        {
            total += 1250;
        }
        if (Characteristics.ResPois)
        {
            total += 2500;
        }
        if (Characteristics.ResFear)
        {
            total += 2500;
        }
        if (Characteristics.ResLight)
        {
            total += 1750;
        }
        if (Characteristics.ResDark)
        {
            total += 1750;
        }
        if (Characteristics.ResBlind)
        {
            total += 2000;
        }
        if (Characteristics.ResConf)
        {
            total += 2000;
        }
        if (Characteristics.ResSound)
        {
            total += 2000;
        }
        if (Characteristics.ResShards)
        {
            total += 2000;
        }
        if (Characteristics.ResNether)
        {
            total += 2000;
        }
        if (Characteristics.ResNexus)
        {
            total += 2000;
        }
        if (Characteristics.ResChaos)
        {
            total += 2000;
        }
        if (Characteristics.ResDisen)
        {
            total += 10000;
        }
        if (Characteristics.ShFire)
        {
            total += 5000;
        }
        if (Characteristics.ShElec)
        {
            total += 5000;
        }
        if (Characteristics.NoTele)
        {
            total += 2500;
        }
        if (Characteristics.NoMagic)
        {
            total += 2500;
        }
        if (Characteristics.Wraith)
        {
            total += 250000;
        }
        if (Characteristics.DreadCurse)
        {
            total -= 15000;
        }
        if (Characteristics.EasyKnow)
        {
            total += 0;
        }
        if (Characteristics.HideType)
        {
            total += 0;
        }
        if (Characteristics.ShowMods)
        {
            total += 0;
        }
        if (Characteristics.InstaArt)
        {
            total += 0;
        }
        if (Characteristics.Feather)
        {
            total += 1250;
        }
        if (Characteristics.Radius > 0)
        {
            total += 1250;
        }
        if (Characteristics.SeeInvis)
        {
            total += 2000;
        }
        if (Characteristics.Telepathy)
        {
            total += 12500;
        }
        if (Characteristics.SlowDigest)
        {
            total += 750;
        }
        if (Characteristics.Regen)
        {
            total += 2500;
        }
        if (Characteristics.XtraMight)
        {
            total += 2250;
        }
        if (Characteristics.XtraShots)
        {
            total += 10000;
        }
        if (Characteristics.IgnoreAcid)
        {
            total += 100;
        }
        if (Characteristics.IgnoreElec)
        {
            total += 100;
        }
        if (Characteristics.IgnoreFire)
        {
            total += 100;
        }
        if (Characteristics.IgnoreCold)
        {
            total += 100;
        }
        if (Characteristics.Activate)
        {
            total += 100;
        }
        if (Characteristics.DrainExp)
        {
            total -= 12500;
        }
        if (Characteristics.Teleport)
        {
            if (IdentCursed)
            {
                total -= 7500;
            }
            else
            {
                total += 250;
            }
        }
        if (Characteristics.Aggravate)
        {
            total -= 10000;
        }
        if (Characteristics.Blessed)
        {
            total += 750;
        }
        if (Characteristics.Cursed)
        {
            total -= 5000;
        }
        if (Characteristics.HeavyCurse)
        {
            total -= 12500;
        }
        if (Characteristics.PermaCurse)
        {
            total -= 15000;
        }
        if (IsRandomArtifact && RandomArtifactItemCharacteristics.Activate)
        {
            total += RandomArtifactActivation.Value;
        }
        return total;
    }

    public ItemQualityRating GetQualityRating()
    {
        if (!Factory.HasQualityRatings)
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(BrokenItemQualityRating));
        }

        if (IsArtifact)
        {
            if (IsCursed() || IsBroken())
            {
                return Game.SingletonRepository.Get<ItemQualityRating>(nameof(TerribleItemQualityRating));
            }
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(SpecialItemQualityRating));
        }
        if (IsRare())
        {
            if (IsCursed() || IsBroken())
            {
                return Game.SingletonRepository.Get<ItemQualityRating>(nameof(WorthlessItemQualityRating));
            }
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(ExcellentItemQualityRating));
        }

        if (IsCursed())
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(CursedItemQualityRating));
        }

        if (IsBroken() || BonusDamage < 0 || BonusHit < 0 || BonusArmorClass < 0)
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
    public void RefreshFlagBasedProperties()
    {
        // All characteristics are set to false.
        Characteristics = new ItemCharacteristics();

        // Merge the characteristics from the base item category.
        Characteristics.Merge(Factory);

        // Now merge the characteristics from the fixed artifact, if there is one.
        if (FixedArtifact != null)
        {
            Characteristics.Merge(FixedArtifact);
        }

        // Now merge the characteristics from the rare item type, if there is one.
        if (RareItem != null)
        {
            Characteristics.Merge(RareItem);
        }

        // Finally, merge any additional random artifact characteristics, if there are any.
        Characteristics.Merge(RandomArtifactItemCharacteristics);

        // If there are any random characteristics, apply those also.
        if (RandomPower != null)
        {
            RandomPower.Activate(this);
        }
    }

    public ItemQualityRating? GetVagueQualityRating()
    { 
        if (IsCursed())
        {
            return Game.SingletonRepository.Get<ItemQualityRating>(nameof(CursedItemQualityRating));
        }
        if (IsBroken())
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
        RefreshFlagBasedProperties();
        if (Characteristics.Activate)
        {
            info[i++] = "It can be activated for...";
            if (FixedArtifact != null && typeof(IFixedArtifactActivatible).IsAssignableFrom(FixedArtifact.GetType()))
            {
                IFixedArtifactActivatible activatibleFixedArtifact = (IFixedArtifactActivatible)FixedArtifact;
                info[i++] = activatibleFixedArtifact.DescribeActivationEffect;
            }
            else if (RareItem != null && RareItem.Activate)
            {
                info[i++] = RareItem.DescribeActivationEffect;
            }
            else if (RandomArtifactActivation != null)
            {
                info[i++] = RandomArtifactActivation.Description;
            }
            else if (Factory.DescribeActivationEffect != null)
            {
                info[i++] = Factory.DescribeActivationEffect;
            }
            info[i++] = "...if it is being worn.";
        }
        string categoryIdentity = Factory.Identify(this);
        if (categoryIdentity != null)
        {
            info[i++] = categoryIdentity;
        }
        if (Characteristics.ArtifactBias != null)
        {
            info[i++] = $"It has an affinity for {Characteristics.ArtifactBias.AffinityName.ToLower()}.";
        }
        if (Characteristics.Str)
        {
            info[i++] = "It affects your strength.";
        }
        if (Characteristics.Int)
        {
            info[i++] = "It affects your intelligence.";
        }
        if (Characteristics.Wis)
        {
            info[i++] = "It affects your wisdom.";
        }
        if (Characteristics.Dex)
        {
            info[i++] = "It affects your dexterity.";
        }
        if (Characteristics.Con)
        {
            info[i++] = "It affects your constitution.";
        }
        if (Characteristics.Cha)
        {
            info[i++] = "It affects your charisma.";
        }
        if (Characteristics.Stealth)
        {
            info[i++] = "It affects your stealth.";
        }
        if (Characteristics.Search)
        {
            info[i++] = "It affects your searching.";
        }
        if (Characteristics.Infra)
        {
            info[i++] = "It affects your infravision.";
        }
        if (Characteristics.Tunnel)
        {
            info[i++] = "It affects your ability to tunnel.";
        }
        if (Characteristics.Speed)
        {
            info[i++] = "It affects your movement speed.";
        }
        if (Characteristics.Blows)
        {
            info[i++] = "It affects your attack speed.";
        }
        if (Characteristics.BrandAcid)
        {
            info[i++] = "It does extra damage from acid.";
        }
        if (Characteristics.BrandElec)
        {
            info[i++] = "It does extra damage from electricity.";
        }
        if (Characteristics.BrandFire)
        {
            info[i++] = "It does extra damage from fire.";
        }
        if (Characteristics.BrandCold)
        {
            info[i++] = "It does extra damage from frost.";
        }
        if (Characteristics.BrandPois)
        {
            info[i++] = "It poisons your foes.";
        }
        if (Characteristics.Chaotic)
        {
            info[i++] = "It produces chaotic effects.";
        }
        if (Characteristics.Vampiric)
        {
            info[i++] = "It drains life from your foes.";
        }
        if (Characteristics.Impact)
        {
            info[i++] = "It can cause earthquakes.";
        }

        if (Characteristics.Radius > 0)
        {
            string burnRate = Factory.BurnRate == 0 ? "forever" : "when fueled";
            info[i++] = $"It provides light (radius {Characteristics.Radius}) {burnRate}.";
        }

        if (Characteristics.Vorpal)
        {
            info[i++] = "It is very sharp and can cut your foes.";
        }
        if (Characteristics.KillDragon)
        {
            info[i++] = "It is a great bane of dragons.";
        }
        else if (Characteristics.SlayDragon)
        {
            info[i++] = "It is especially deadly against dragons.";
        }
        if (Characteristics.SlayOrc)
        {
            info[i++] = "It is especially deadly against orcs.";
        }
        if (Characteristics.SlayTroll)
        {
            info[i++] = "It is especially deadly against trolls.";
        }
        if (Characteristics.SlayGiant)
        {
            info[i++] = "It is especially deadly against giants.";
        }
        if (Characteristics.SlayDemon)
        {
            info[i++] = "It strikes at demons with holy wrath.";
        }
        if (Characteristics.SlayUndead)
        {
            info[i++] = "It strikes at undead with holy wrath.";
        }
        if (Characteristics.SlayEvil)
        {
            info[i++] = "It fights against evil with holy fury.";
        }
        if (Characteristics.SlayAnimal)
        {
            info[i++] = "It is especially deadly against natural creatures.";
        }
        if (Characteristics.SustStr)
        {
            info[i++] = "It sustains your strength.";
        }
        if (Characteristics.SustInt)
        {
            info[i++] = "It sustains your intelligence.";
        }
        if (Characteristics.SustWis)
        {
            info[i++] = "It sustains your wisdom.";
        }
        if (Characteristics.SustDex)
        {
            info[i++] = "It sustains your dexterity.";
        }
        if (Characteristics.SustCon)
        {
            info[i++] = "It sustains your constitution.";
        }
        if (Characteristics.SustCha)
        {
            info[i++] = "It sustains your charisma.";
        }
        if (Characteristics.ImAcid)
        {
            info[i++] = "It provides immunity to acid.";
        }
        if (Characteristics.ImElec)
        {
            info[i++] = "It provides immunity to electricity.";
        }
        if (Characteristics.ImFire)
        {
            info[i++] = "It provides immunity to fire.";
        }
        if (Characteristics.ImCold)
        {
            info[i++] = "It provides immunity to cold.";
        }
        if (Characteristics.FreeAct)
        {
            info[i++] = "It provides immunity to paralysis.";
        }
        if (Characteristics.HoldLife)
        {
            info[i++] = "It provides resistance to life draining.";
        }
        if (Characteristics.ResFear)
        {
            info[i++] = "It makes you completely fearless.";
        }
        if (Characteristics.ResAcid)
        {
            info[i++] = "It provides resistance to acid.";
        }
        if (Characteristics.ResElec)
        {
            info[i++] = "It provides resistance to electricity.";
        }
        if (Characteristics.ResFire)
        {
            info[i++] = "It provides resistance to fire.";
        }
        if (Characteristics.ResCold)
        {
            info[i++] = "It provides resistance to cold.";
        }
        if (Characteristics.ResPois)
        {
            info[i++] = "It provides resistance to poison.";
        }
        if (Characteristics.ResLight)
        {
            info[i++] = "It provides resistance to light.";
        }
        if (Characteristics.ResDark)
        {
            info[i++] = "It provides resistance to dark.";
        }
        if (Characteristics.ResBlind)
        {
            info[i++] = "It provides resistance to blindness.";
        }
        if (Characteristics.ResConf)
        {
            info[i++] = "It provides resistance to confusion.";
        }
        if (Characteristics.ResSound)
        {
            info[i++] = "It provides resistance to sound.";
        }
        if (Characteristics.ResShards)
        {
            info[i++] = "It provides resistance to shards.";
        }
        if (Characteristics.ResNether)
        {
            info[i++] = "It provides resistance to nether.";
        }
        if (Characteristics.ResNexus)
        {
            info[i++] = "It provides resistance to nexus.";
        }
        if (Characteristics.ResChaos)
        {
            info[i++] = "It provides resistance to chaos.";
        }
        if (Characteristics.ResDisen)
        {
            info[i++] = "It provides resistance to disenchantment.";
        }
        if (Characteristics.Wraith)
        {
            info[i++] = "It renders you incorporeal.";
        }
        if (Characteristics.Feather)
        {
            info[i++] = "It allows you to levitate.";
        }
        if (Characteristics.Radius > 0 && Factory.BurnRate == 0)
        {
            info[i++] = "It provides permanent light.";
        }
        if (Characteristics.SeeInvis)
        {
            info[i++] = "It allows you to see invisible monsters.";
        }
        if (Characteristics.Telepathy)
        {
            info[i++] = "It gives telepathic powers.";
        }
        if (Characteristics.SlowDigest)
        {
            info[i++] = "It slows your metabolism.";
        }
        if (Characteristics.Regen)
        {
            info[i++] = "It speeds your regenerative powers.";
        }
        if (Characteristics.Reflect)
        {
            info[i++] = "It reflects bolts and arrows.";
        }
        if (Characteristics.ShFire)
        {
            info[i++] = "It produces a fiery sheath.";
        }
        if (Characteristics.ShElec)
        {
            info[i++] = "It produces an electric sheath.";
        }
        if (Characteristics.NoMagic)
        {
            info[i++] = "It produces an anti-magic shell.";
        }
        if (Characteristics.NoTele)
        {
            info[i++] = "It prevents teleportation.";
        }
        if (Characteristics.XtraMight)
        {
            info[i++] = "It fires missiles with extra might.";
        }
        if (Characteristics.XtraShots)
        {
            info[i++] = "It fires missiles excessively fast.";
        }
        if (Characteristics.DrainExp)
        {
            info[i++] = "It drains experience.";
        }
        if (Characteristics.Teleport)
        {
            info[i++] = "It induces random teleportation.";
        }
        if (Characteristics.Aggravate)
        {
            info[i++] = "It aggravates nearby creatures.";
        }
        if (Characteristics.Blessed)
        {
            info[i++] = "It has been blessed by the gods.";
        }
        if (IsCursed())
        {
            if (Characteristics.PermaCurse)
            {
                info[i++] = "It is permanently cursed.";
            }
            else if (Characteristics.HeavyCurse)
            {
                info[i++] = "It is heavily cursed.";
            }
            else
            {
                info[i++] = "It is cursed.";
            }
        }
        if (Characteristics.DreadCurse)
        {
            info[i++] = "It carries an ancient foul curse.";
        }
        if (Characteristics.IgnoreAcid)
        {
            info[i++] = "It cannot be harmed by acid.";
        }
        if (Characteristics.IgnoreElec)
        {
            info[i++] = "It cannot be harmed by electricity.";
        }
        if (Characteristics.IgnoreFire)
        {
            info[i++] = "It cannot be harmed by fire.";
        }
        if (Characteristics.IgnoreCold)
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

    public bool IsBroken()
    {
        return IdentBroken;
    }

    public bool IsCursed()
    {
        return IdentCursed;
    }

    public bool IsKnown()
    {
        if (IdentKnown)
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
        return Characteristics;
    }

    /// <summary>
    /// Indicate that the item has been tried.
    /// </summary>
    public void ObjectTried()
    {
        Factory.Tried = true;
    }

    public int RealValue()
    {
        if (Factory.Cost == 0)
        {
            return 0;
        }
        int value = Factory.Cost;
        value += FlagBasedCost(TypeSpecificValue);
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
        if (Factory.IsWorthless(this))
        {
            return 0;
        }
        int? typeSpecificValue = Factory.GetTypeSpecificRealValue(this, value);
        if (typeSpecificValue == null)
        {
            return 0;
        }
        value += typeSpecificValue.Value;

        int? bonusValue = Factory.GetBonusRealValue(this, value);
        if (bonusValue == null)
            return 0;

        value += bonusValue.Value;
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

    public int Value()
    {
        int value;
        if (IsKnown())
        {
            if (IsBroken())
            {
                return 0;
            }
            if (IsCursed())
            {
                return 0;
            }
            value = RealValue();
        }
        else
        {
            if (IdentSense && IsBroken())
            {
                return 0;
            }
            if (IdentSense && IsCursed())
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

    public void EnchantItem(int lev, bool okay, bool good, bool great, Store? store)
    {            
        if (lev > Constants.MaxDepth - 1)
        {
            lev = Constants.MaxDepth - 1;
        }
        int f1 = lev + 10;
        if (f1 > 75)
        {
            f1 = 75;
        }
        int f2 = f1 / 2;
        if (f2 > 20)
        {
            f2 = 20;
        }
        int power = 0;
        if (good || Game.PercentileRoll(f1))
        {
            power = 1;
            if (great || Game.PercentileRoll(f2))
            {
                power = 2;
            }
        }
        else if (Game.PercentileRoll(f1))
        {
            power = -1;
            if (Game.PercentileRoll(f2))
            {
                power = -2;
            }
        }
        int rolls = 0;
        if (power >= 2)
        {
            rolls = 1;
        }
        if (great)
        {
            rolls = 4;
        }
        if (!okay || FixedArtifact != null)
        {
            rolls = 0;
        }
        for (int i = 0; i < rolls; i++)
        {
            if (ApplyFixedArtifact())
            {
                break;
            }
        }
        if (FixedArtifact != null)
        {
            FixedArtifact.CurNum = 1;
            TypeSpecificValue = FixedArtifact.InitialTypeSpecificValue;
            ArmorClass = FixedArtifact.Ac;
            DamageDice = FixedArtifact.Dd;
            DamageSides = FixedArtifact.Ds;
            BonusArmorClass = FixedArtifact.ToA;
            BonusHit = FixedArtifact.ToH;
            BonusDamage = FixedArtifact.ToD;
            Weight = FixedArtifact.Weight;
            if (FixedArtifact.Cost == 0)
            {
                IdentBroken = true;
            }
            if (FixedArtifact.Cursed)
            {
                IdentCursed = true;
            }
            Game.TreasureRating += FixedArtifact.TreasureRating;
            Game.SpecialTreasure = true;
            return;
        }
        Factory.ApplyMagic(this, lev, power, store);
        Game.TreasureRating += Factory.TreasureRating;
        if (IsRandomArtifact)
        {
            Game.TreasureRating += 40;
        }
        else if (RareItem != null)
        {
            RareItem.ApplyMagic(this);
            if (RareItem.Cost == 0)
            {
                IdentBroken = true;
            }
            if (RareItem.Cursed)
            {
                IdentCursed = true;
            }
            if (IsCursed() || IsBroken())
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
                if (RareItem.MaxPval != 0)
                {
                    TypeSpecificValue -= Game.DieRoll(RareItem.MaxPval);
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
                if (RareItem.MaxPval != 0)
                {
                    TypeSpecificValue += Game.DieRoll(RareItem.MaxPval);
                }
            }
            Game.TreasureRating += RareItem.TreasureRating;
            return;
        }
        if (Factory != null)
        {
            if (Factory.Cost == 0)
            {
                IdentBroken = true;
            }
            if (Factory.Cursed)
            {
                IdentCursed = true;
            }
        }
    }

    public void ApplyRandomResistance(ItemAdditiveBundleWeightedRandom itemAdditiveBundleWeightedRandom)
    {
        ItemAdditiveBundle? itemAdditiveBundle = itemAdditiveBundleWeightedRandom.ChooseOrDefault();
        if (itemAdditiveBundle != null)
        {
            RandomArtifactItemCharacteristics.Merge(itemAdditiveBundle);
        }
    }
    public bool CreateRandomArtifact(bool fromScroll)
    {
        const int ArtifactCurseChance = 13;
        int powers = Game.DieRoll(5) + 1;
        bool aCursed = false;
        int warriorArtifactBias = 0;
        if (fromScroll && Game.DieRoll(4) == 1)
        {
            RandomArtifactItemCharacteristics.ArtifactBias = Game.BaseCharacterClass.ArtifactBias;
            warriorArtifactBias = Game.BaseCharacterClass.FromScrollWarriorArtifactBiasPercentageChance;
        }
        if (Game.DieRoll(100) <= warriorArtifactBias && fromScroll)
        {
            RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WarriorArtifactBias));
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
                    if (RandomArtifactItemCharacteristics.Blows)
                    {
                        TypeSpecificValue = Game.DieRoll(2) + 1;
                    }
                    else
                    {
                        do
                        {
                            TypeSpecificValue++;
                        } while (TypeSpecificValue < Game.DieRoll(5) || Game.DieRoll(TypeSpecificValue) == 1);
                    }
                    if (TypeSpecificValue > 4 && Game.DieRoll(Constants.WeirdLuck) != 1)
                    {
                        TypeSpecificValue = 4;
                    }
                    break;

                case 3:
                case 4:
                    if (RandomArtifactItemCharacteristics.ArtifactBias != null)
                    {
                        RandomArtifactItemCharacteristics.ArtifactBias.ApplyRandomResistances(this);
                    }
                    else
                    {
                        ItemAdditiveBundleWeightedRandom itemAdditiveBundleWeightedRandom = new ItemAdditiveBundleWeightedRandom(Game);
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
        RandomArtifactItemCharacteristics.IgnoreAcid = true;
        RandomArtifactItemCharacteristics.IgnoreElec = true;
        RandomArtifactItemCharacteristics.IgnoreFire = true;
        RandomArtifactItemCharacteristics.IgnoreCold = true;
        int totalFlags = FlagBasedCost(TypeSpecificValue);
        if (aCursed)
        {
            CurseRandart();
        }
        if (!aCursed && Game.DieRoll(Factory.RandartActivationChance) == 1)
        {
            RandomArtifactActivation = null;
            GiveActivationPower();
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
            BecomeFlavorAware();
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
        if (RandomArtifactItemCharacteristics.ArtifactBias != null)
        {
            if (RandomArtifactItemCharacteristics.ArtifactBias.ApplyBonuses(this))
            {
                return;
            }
        }
        switch (Game.DieRoll(23))
        {
            case 1:
            case 2:
                RandomArtifactItemCharacteristics.Str = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(StrengthArtifactBias));
                }
                else if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(7) == 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WarriorArtifactBias));
                }
                break;

            case 3:
            case 4:
                RandomArtifactItemCharacteristics.Int = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(IntelligenceArtifactBias));
                }
                else if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(7) == 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(MageArtifactBias));
                }
                break;

            case 5:
            case 6:
                RandomArtifactItemCharacteristics.Wis = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WisdomArtifactBias));
                }
                else if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(7) == 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
                }
                break;

            case 7:
            case 8:
                RandomArtifactItemCharacteristics.Dex = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(DexterityArtifactBias));
                }
                else if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(7) == 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RogueArtifactBias));
                }
                break;

            case 9:
            case 10:
                RandomArtifactItemCharacteristics.Con = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(ConstitutionArtifactBias));
                }
                else if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RangerArtifactBias));
                }
                break;

            case 11:
            case 12:
                RandomArtifactItemCharacteristics.Cha = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(CharismaArtifactBias));
                }
                break;

            case 13:
            case 14:
                RandomArtifactItemCharacteristics.Stealth = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(3) == 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RogueArtifactBias));
                }
                break;

            case 15:
            case 16:
                RandomArtifactItemCharacteristics.Search = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RangerArtifactBias));
                }
                break;

            case 17:
            case 18:
                RandomArtifactItemCharacteristics.Infra = true;
                break;

            case 19:
                RandomArtifactItemCharacteristics.Speed = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(11) == 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RogueArtifactBias));
                }
                break;

            case 20:
            case 21:
                RandomArtifactItemCharacteristics.Tunnel = true;
                break;

            case 22:
            case 23:
                if (Factory.CanApplyBlowsBonus)
                {
                    ApplyRandomBonuses();
                }
                else
                {
                    RandomArtifactItemCharacteristics.Blows = true;
                    if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(11) == 1)
                    {
                        RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WarriorArtifactBias));
                    }
                }
                break;
        }
    }

    private void ApplyMiscPowerForRandomArtifactCreation()
    {
        if (RandomArtifactItemCharacteristics.ArtifactBias != null)
        {
            RandomArtifactItemCharacteristics.ArtifactBias.ApplyMiscPowers(this);
        }
        switch (Game.DieRoll(31))
        {
            case 1:
                RandomArtifactItemCharacteristics.SustStr = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(StrengthArtifactBias));
                }
                break;

            case 2:
                RandomArtifactItemCharacteristics.SustInt = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(IntelligenceArtifactBias));
                }
                break;

            case 3:
                RandomArtifactItemCharacteristics.SustWis = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WisdomArtifactBias));
                }
                break;

            case 4:
                RandomArtifactItemCharacteristics.SustDex = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(DexterityArtifactBias));
                }
                break;

            case 5:
                RandomArtifactItemCharacteristics.SustCon = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(ConstitutionArtifactBias));
                }
                break;

            case 6:
                RandomArtifactItemCharacteristics.SustCha = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(CharismaArtifactBias));
                }
                break;

            case 7:
            case 8:
            case 14:
                RandomArtifactItemCharacteristics.FreeAct = true;
                break;

            case 9:
                RandomArtifactItemCharacteristics.HoldLife = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(5) == 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
                }
                else if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(6) == 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(NecromanticArtifactBias));
                }
                break;

            case 10:
            case 11:
                RandomArtifactItemCharacteristics.Radius = 3;
                break;

            case 12:
            case 13:
                RandomArtifactItemCharacteristics.Feather = true;
                break;

            case 15:
            case 16:
            case 17:
                RandomArtifactItemCharacteristics.SeeInvis = true;
                break;

            case 18:
                RandomArtifactItemCharacteristics.Telepathy = true;
                if (RandomArtifactItemCharacteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                {
                    RandomArtifactItemCharacteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(MageArtifactBias));
                }
                break;

            case 19:
            case 20:
                RandomArtifactItemCharacteristics.SlowDigest = true;
                break;

            case 21:
            case 22:
                RandomArtifactItemCharacteristics.Regen = true;
                break;

            case 23:
                RandomArtifactItemCharacteristics.Teleport = true;
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
                    RandomArtifactItemCharacteristics.ShowMods = true;
                    BonusArmorClass = 4 + Game.DieRoll(11);
                }
                break;

            case 27:
            case 28:
            case 29:
                RandomArtifactItemCharacteristics.ShowMods = true;
                BonusHit += 4 + Game.DieRoll(11);
                BonusDamage += 4 + Game.DieRoll(11);
                break;

            case 30:
                RandomArtifactItemCharacteristics.NoMagic = true;
                break;

            case 31:
                RandomArtifactItemCharacteristics.NoTele = true;
                break;
        }
    }

    private void CurseRandart()
    {
        if (TypeSpecificValue != 0)
        {
            TypeSpecificValue = 0 - (TypeSpecificValue + Game.DieRoll(4));
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
        RandomArtifactItemCharacteristics.HeavyCurse = true;
        RandomArtifactItemCharacteristics.Cursed = true;
        if (Game.DieRoll(4) == 1)
        {
            RandomArtifactItemCharacteristics.PermaCurse = true;
        }
        if (Game.DieRoll(3) == 1)
        {
            RandomArtifactItemCharacteristics.DreadCurse = true;
        }
        if (Game.DieRoll(2) == 1)
        {
            RandomArtifactItemCharacteristics.Aggravate = true;
        }
        if (Game.DieRoll(3) == 1)
        {
            RandomArtifactItemCharacteristics.DrainExp = true;
        }
        if (Game.DieRoll(2) == 1)
        {
            RandomArtifactItemCharacteristics.Teleport = true;
        }
        else if (Game.DieRoll(3) == 1)
        {
            RandomArtifactItemCharacteristics.NoTele = true;
        }
        if (Game.BaseCharacterClass.ID != CharacterClass.Warrior && Game.DieRoll(3) == 1)
        {
            RandomArtifactItemCharacteristics.NoMagic = true;
        }
        IdentCursed = true;
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

    private void GiveActivationPower() // TODO: There may not be any activiations
    {
        Activation? activation = null;
        if (RandomArtifactItemCharacteristics.ArtifactBias != null)
        {
            if (Game.DieRoll(100) < RandomArtifactItemCharacteristics.ArtifactBias.ActivationPowerChance)
            {
                activation = RandomArtifactItemCharacteristics.ArtifactBias.GetActivationPowerType(this);
            }
        }
        if (activation == null)
        {
            int chance = 0;
            while (activation == null || Game.DieRoll(100) >= chance)
            {
                activation = Game.SingletonRepository.ToWeightedRandom<Activation>().ChooseOrDefault();
                chance = activation.RandomChance;
            }
        }
        RandomArtifactActivation = activation;
        RandomArtifactItemCharacteristics.Activate = true;
        RingsArmorActivationAndFixedArtifactsRechargeTimeLeft = 0;
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
    /// Provides base functionality for the type specific real value.  Returns a real value for the type specific characteristics of the item.  Returns
    /// null, if the item is worthless.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public int? ComputeTypeSpecificRealValue(int value)
    {
        if (TypeSpecificValue < 0)
        {
            return null; // Worthless
        }

        if (TypeSpecificValue == 0)
        {
            return 0;
        }

        int bonusValue = 0;
        RefreshFlagBasedProperties();
        if (Characteristics.Str)
        {
            bonusValue += TypeSpecificValue * 200;
        }
        if (Characteristics.Int)
        {
            bonusValue += TypeSpecificValue * 200;
        }
        if (Characteristics.Wis)
        {
            bonusValue += TypeSpecificValue * 200;
        }
        if (Characteristics.Dex)
        {
            bonusValue += TypeSpecificValue * 200;
        }
        if (Characteristics.Con)
        {
            bonusValue += TypeSpecificValue * 200;
        }
        if (Characteristics.Cha)
        {
            bonusValue += TypeSpecificValue * 200;
        }
        if (Characteristics.Stealth)
        {
            bonusValue += TypeSpecificValue * 100;
        }
        if (Characteristics.Search)
        {
            bonusValue += TypeSpecificValue * 100;
        }
        if (Characteristics.Infra)
        {
            bonusValue += TypeSpecificValue * 50;
        }
        if (Characteristics.Tunnel)
        {
            bonusValue += TypeSpecificValue * 50;
        }
        if (Characteristics.Blows)
        {
            bonusValue += TypeSpecificValue * 5000;
        }
        if (Characteristics.Speed)
        {
            bonusValue += TypeSpecificValue * 3000;
        }
        return bonusValue;
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