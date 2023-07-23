// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class Item : IComparable<Item>
{
    /// <summary>
    /// Returns true, if the item can be used as fuel for a torch.
    /// </summary>
    public virtual bool IsFuelForTorch => false;

    /// <summary>
    /// Returns a sort order index for sorting items in a pack.  Lower numbers show before higher numbers.
    /// </summary>
    public int PackSort => Factory.PackSort;

    /// <summary>
    /// Returns true, if the item is capable of vorpal slaying.  Only swords return true.  Returns false, by default.
    /// </summary>
    public virtual bool CanVorpalSlay => false;

    /// <summary>
    /// Returns a count for the number of items to create during the MakeObject.  Returns 1, by default.  Spikes, shots, arrows and bolts return values greater than 1.
    /// </summary>
    public virtual int MakeObjectCount => 1;

    /// <summary>
    /// Returns true, if the item multiplies damages against a specific monster race.  Returns false, by default. Shots, arrows, bolts, hafted, polearms, swords and digging all return true.
    /// </summary>
    public virtual bool GetsDamageMultiplier => false;

    /// <summary>
    /// Returns the percentage chance that an thrown or fired item breaks.  Returns 10, or 10%, by default.  A value of 101, guarantees the item will break.
    /// </summary>
    public virtual int PercentageBreakageChance => 10;

    /// <summary>
    /// Returns true, if the item can apply a bonus armor class for miscellaneous power.  Only weapons return true.  Returns false, by default.
    /// </summary>
    public virtual bool CanApplyBonusArmorClassMiscPower => false;

    /// <summary>
    /// Returns true, if the item can apply a blows bonus.  All weapons, except for the bow, return true.  Returns false, by default.
    /// </summary>
    public virtual bool CanApplyBlowsBonus => false;

    /// <summary>
    /// Returns true, if the identity of the item can be sensed; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool IdentityCanBeSensed => false;

    /// <summary>
    /// Returns the intensity of light that the object emits.  By default, a value of 1 is returned, if the item has a 
    /// light-source characteristic.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public virtual int CalculateTorch()
    {
        RefreshFlagBasedProperties();
        if (Characteristics.Lightsource)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// Returns the inventory slot where the item is wielded.  Returns the pack, by default.
    /// </summary>
    public virtual int WieldSlot => InventorySlot.Pack;

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
    /// This property used to be a flag in the IdentifyFlags.
    /// </summary>
    public bool IdentStoreb;

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

    public readonly ItemCharacteristics RandartItemCharacteristics = new ItemCharacteristics();
    public int BaseArmorClass;
    public int BonusArmorClass;
    public int BonusDamage;
    public Activation BonusPowerSubType;
    public RareItemTypeEnum BonusPowerType;
    public int BonusToHit;
    public int Count;
    public int DamageDice;
    public int DamageDiceSides;
    public int Discount;
    public FixedArtifact? FixedArtifact; // If this item is a fixed artifact, this will be not null.
    public int HoldingMonsterIndex;
    public string Inscription = "";

    /// <summary>
    /// Tests an item to determine if it belongs to an Item type and returns a the item casted into that type; or null, if the item doesn't belong to the type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T? TryCast<T>() where T : Item
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

    /// <summary>
    /// Returns the container that is holding the container.
    /// </summary>
    public IItemContainer? GetContainer()
    {
        foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots)
        {
            foreach (int slot in inventorySlot.InventorySlots)
            {
                if (SaveGame.GetInventoryItem(slot) == this)
                {
                    return inventorySlot;
                }
            }
        }

        if (HoldingMonsterIndex != 0)
        {
            return SaveGame.Monsters[HoldingMonsterIndex];
        } 
        else if (X != 0 && Y != 0)
        {
            return SaveGame.Grid[Y][X];
        }
        else
        {
            return null;
        }
    }

    public string Label
    {
        get
        {
            IItemContainer? container = GetContainer();
            if (container == null)
            {
                throw new Exception("Missing item container.");
            }
            return container.Label(this);
        }
    }

    public string DescribeLocation()
    {
        IItemContainer? container = GetContainer();
        if (container == null)
        {
            throw new Exception("Missing item container.");
        }
        return container.DescribeItemLocation(this);
    }

    /// <summary>
    /// Modifies the quantity of an item.  The modification process differs depending on the type of container containing the item (e.g. inventory slots will update the player stats, monster and grid tile containers do not).
    /// </summary>
    /// <param name="oPtr"></param>
    /// <param name="num"></param>
    public void ItemIncrease(int num)
    {
        IItemContainer? container = GetContainer();
        if (container == null)
        {
            throw new Exception("Missing item container.");
        }
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
        container.ItemDescribe(this);
    }

    /// <summary>
    /// Checks the quantity of an item and removes it, when the quanity is zero.  This process differs depending on which container is containing the item.
    /// </summary>
    /// <param name="oPtr"></param>
    public void ItemOptimize()
    {
        IItemContainer? container = GetContainer();
        if (container == null)
        {
            throw new Exception("Missing item container.");
        }
        container.ItemOptimize(this);
    }

    public void ProcessWorld()
    {
        if (Category == ItemTypeEnum.Rod && TypeSpecificValue != 0)
        {
            TypeSpecificValue--;
        }
    }

    /// <summary>
    /// Returns true, if the container is part of the players inventory.  All inventory slots (pack & equipment), return true; monsters and grid tiles return false.
    /// </summary>
    public bool IsInInventory
    {
        get
        {
            IItemContainer? container = GetContainer();
            if (container == null)
            {
                throw new Exception("Missing item container.");
            }
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
            IItemContainer? container = GetContainer();
            if (container == null)
            {
                throw new Exception("Missing item container.");
            }
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
    /// Returns the factory that created this item.
    /// </summary>
    private readonly ItemFactory _factory;

    /// <summary>
    /// Returns the factory that created this item.
    /// </summary>
    public virtual ItemFactory Factory => _factory;

    public bool Marked;

    public string RandartName = "";
    public RareItemTypeEnum RareItemTypeIndex;
    public int RechargeTimeLeft;

    /// <summary>
    /// Returns a value that is specific to the item class.
    /// Gold - The amount of gold.
    /// Light - The number of turns remaining.
    /// Rod - Recharge time remaining.
    /// Wand - Number of charges remaining.
    /// Chest - The number of items in the chest.
    /// Food - The amount of sustenence the food provides.
    /// Potion - The amount of sustenence the potion provides.
    /// Staff - The number of charges remaining.
    /// Weapons (Blows) - The weapon attacks
    /// FOR ALL EQUIMENT - The bonus value for item.characteristic.(str, int, wis, dex, cha, dex, stealth, search, infra, tunnel, speed and blows
    /// </summary>
    public int TypeSpecificValue;
    public int Weight;
    public int X;
    public int Y;
    public readonly SaveGame SaveGame;
    public ItemCharacteristics Characteristics = new ItemCharacteristics();

    public Item(SaveGame saveGame, ItemFactory factory)
    {
        SaveGame = saveGame;
        _factory = factory;
        TypeSpecificValue = Factory.Pval;
        Count = 1;
        Weight = Factory.Weight;
        BonusToHit = Factory.ToH;
        BonusDamage = Factory.ToD;
        BonusArmorClass = Factory.ToA;
        BaseArmorClass = Factory.Ac;
        DamageDice = Factory.Dd;
        DamageDiceSides = Factory.Ds;
        if (Factory.Cost <= 0)
        {
            IdentBroken = true;
        }
        if (Factory.Cursed)
        {
            IdentCursed = true;
        }
    }

    /// <summary>
    /// Hook into the ProcessWorld, when the item is being worn/wielded.  Does nothing, by default.
    /// </summary>
    /// <param name="saveGame"></param>
    public virtual void EquipmentProcessWorldHook() { }

    /// <summary>
    /// Hook into the ProcessWorld, when the item is being carried in a pack inventory slot.  Does nothing, by default..
    /// </summary>
    /// <param name="saveGame"></param>
    public virtual void PackProcessWorldHook() { }

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
            if (thisBookFactory.ToRealm == SaveGame.PrimaryRealm && oPtrBookFactory.ToRealm != SaveGame.PrimaryRealm)
            {
                return -1;
            }
            if (thisBookFactory.ToRealm != SaveGame.PrimaryRealm && oPtrBookFactory.ToRealm == SaveGame.PrimaryRealm)
            {
                return 1;
            }

            // Second level sort (secondary realm spell books).
            // A book that matches the second realm, will always come before a book that doesn't match the second realm.
            if (thisBookFactory.ToRealm == SaveGame.SecondaryRealm && oPtrBookFactory.ToRealm != SaveGame.SecondaryRealm)
            {
                return 1;
            }
            if (thisBookFactory.ToRealm != SaveGame.SecondaryRealm && oPtrBookFactory.ToRealm == SaveGame.SecondaryRealm)
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
        // Flavour aware items sort before those not identified.
        if (IsFlavourAware() && !oPtr.IsFlavourAware())
        {
            return -1;
        }
        if (!IsFlavourAware() && oPtr.IsFlavourAware())
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
        if (Category == ItemTypeEnum.Rod && oPtr.Category == ItemTypeEnum.Rod)
        {
            if (TypeSpecificValue < oPtr.TypeSpecificValue)
            {
                return -1;
            }
            if (TypeSpecificValue > oPtr.TypeSpecificValue)
            {
                return 1;
            }
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

    public Item Clone(int? newCount = null)
    {
        Item clonedItem = Factory.CreateItem();
        clonedItem.BaseArmorClass = BaseArmorClass;
        clonedItem.RandartItemCharacteristics.Copy(RandartItemCharacteristics);
        clonedItem.RandartName = RandartName;
        clonedItem.DamageDice = DamageDice;
        clonedItem.Discount = Discount;
        clonedItem.DamageDiceSides = DamageDiceSides;
        clonedItem.HoldingMonsterIndex = HoldingMonsterIndex;

        clonedItem.IdentSense = IdentSense;
        clonedItem.IdentFixed = IdentFixed;
        clonedItem.IdentEmpty = IdentEmpty;
        clonedItem.IdentKnown = IdentKnown;
        clonedItem.IdentStoreb = IdentStoreb;
        clonedItem.IdentMental = IdentMental;
        clonedItem.IdentCursed = IdentCursed;
        clonedItem.IdentBroken = IdentBroken;

        clonedItem.X = X;
        clonedItem.Y = Y;
        clonedItem.Marked = Marked;
        clonedItem.FixedArtifact = FixedArtifact;
        clonedItem.RareItemTypeIndex = RareItemTypeIndex;
        clonedItem.Inscription = Inscription;
        clonedItem.Count = newCount ?? Count;
        clonedItem.TypeSpecificValue = TypeSpecificValue;
        clonedItem.RechargeTimeLeft = RechargeTimeLeft;
        clonedItem.BonusArmorClass = BonusArmorClass;
        clonedItem.BonusDamage = BonusDamage;
        clonedItem.BonusToHit = BonusToHit;
        clonedItem.Weight = Weight;
        clonedItem.BonusPowerType = BonusPowerType;
        clonedItem.BonusPowerSubType = BonusPowerSubType;
        return clonedItem;
    }

    public bool IsKnownArtifact => IsKnown() && (FixedArtifact != null || !string.IsNullOrEmpty(RandartName));

    [Obsolete]
    public ItemTypeEnum Category => Factory == null ? ItemTypeEnum.None : Factory.CategoryEnum; // TODO: Provided for backwards compatibility.  Will be deleted.

    public void Absorb(Item other)
    {
        int total = Count + other.Count;
        Count = total < Constants.MaxStackSize ? total : Constants.MaxStackSize - 1;
        if (other.IsKnown())
        {
            BecomeKnown();
        }
        if (IdentStoreb || (other.IdentStoreb &&
            !(IdentStoreb && other.IdentStoreb)))
        {
            if (other.IdentStoreb)
            {
                other.IdentStoreb = false;
            }
            if (IdentStoreb)
            {
                IdentStoreb = false;
            }
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
        if (GetsDamageMultiplier)
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
                    mult *= FixedArtifact.KilLDragonMultiplier;
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

    public void ApplyRandomResistance(int specific)
    {
        IArtifactBias artifactBias = null;
        ApplyRandomResistance(ref artifactBias, specific); // TODO: We has to inject 0 for the ArtifactBias because the constructor would have initialized the _artifactBias to 0.
    }

    public void BecomeFlavourAware()
    {
        Factory.FlavourAware = true;
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

    public int BreakageChance()
    {
        return PercentageBreakageChance;
    }

    public bool StatsAreSame(Item other)
    {
        if (!IsKnown())
        {
            return false;
        }
        if (IsKnown() != other.IsKnown())
        {
            return false;
        }
        if (BonusToHit != other.BonusToHit)
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
        if (FixedArtifact != other.FixedArtifact)
        {
            return false;
        }
        if (!string.IsNullOrEmpty(RandartName) || !string.IsNullOrEmpty(other.RandartName))
        {
            return false;
        }
        if (RareItemTypeIndex != other.RareItemTypeIndex)
        {
            return false;
        }
        if (BonusPowerType != 0 || other.BonusPowerType != 0)
        {
            return false;
        }
        if (RechargeTimeLeft != 0 || other.RechargeTimeLeft != 0)
        {
            return false;
        }
        if (BaseArmorClass != other.BaseArmorClass)
        {
            return false;
        }
        if (DamageDice != other.DamageDice)
        {
            return false;
        }
        if (DamageDiceSides != other.DamageDiceSides)
        {
            return false;
        }
        return true;
    }

    public bool CanAbsorb(Item other)
    {
        int total = Count + other.Count;
        if (Factory != other.Factory)
        {
            return false;
        }
        if (!FactoryCanAbsorbItem(other))
        {
            return false;
        }

        if (!RandartItemCharacteristics.Equals(other.RandartItemCharacteristics))
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
        if (!string.IsNullOrEmpty(Inscription) && !string.IsNullOrEmpty(other.Inscription) &&
            Inscription != other.Inscription)
        {
            return false;
        }
        if (Discount != other.Discount)
        {
            return false;
        }
        return total < Constants.MaxStackSize;
    }


    /// <summary>
    /// Returns true, if an item can absorb another item of the same type.  Returns false, by default, if either item is known.
    /// </summary>
    protected virtual bool FactoryCanAbsorbItem(Item other)
    {
        if (!IsKnown() || !other.IsKnown())
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="includeCountPrefix">Specify true, to prefix the description with the number of items (e.g. 5 Brown Dragon Scale Mails);
    /// false, otherwise (e.g. Brown Dragon Scale Mails).  When false, the item will still be pluralized (e.g. stole one of your Brown Dragon Scale Mails).</param>
    /// <param name="mode"></param>
    /// <returns></returns>
    public string Description(bool includeCountPrefix, int mode)
    {
        if (Factory == null)
        {
            return "(nothing)";
        }
        string basenm = GetDescription(includeCountPrefix);
        if (IsKnown())
        {
            if (!string.IsNullOrEmpty(RandartName))
            {
                basenm += ' ';
                basenm += RandartName;
            }
            else if (FixedArtifact != null)
            {
                basenm += ' ';
                basenm += FixedArtifact.FriendlyName;
            }
            else if (RareItemTypeIndex != RareItemTypeEnum.None)
            {
                RareItem ePtr = SaveGame.SingletonRepository.RareItems[RareItemTypeIndex];
                basenm += ' ';
                basenm += ePtr.FriendlyName; // This used to be oPtr.Name ... but Long Bow Bow of Velocity is wrong
            }
        }
        if (mode < 1)
        {
            return basenm;
        }

        // This is the detailed description.
        basenm += GetDetailedDescription();
        if (mode < 2)
        {
            return basenm;
        }

        basenm += GetVerboseDescription();

        // This is the verbose description.
        if (mode < 3)
        {
            return basenm;
        }

        // This is the full description.
        basenm += GetFullDescription();

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
        if (Characteristics.Lightsource)
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
        if (!string.IsNullOrEmpty(RandartName) && RandartItemCharacteristics.Activate)
        {
            total += BonusPowerSubType.Value;
        }
        return total;
    }

    public string GetDetailedFeeling()
    {
        if (FixedArtifact != null || !string.IsNullOrEmpty(RandartName))
        {
            if (IsCursed() || IsBroken())
            {
                return "terrible";
            }
            return "special";
        }
        if (IsRare())
        {
            if (IsCursed() || IsBroken())
            {
                return "worthless";
            }
            return "excellent";
        }
        if (IsCursed())
        {
            return "cursed";
        }
        if (IsBroken())
        {
            return "broken";
        }
        if (BonusArmorClass > 0)
        {
            return "good";
        }
        if (BonusToHit + BonusDamage > 0)
        {
            return "good";
        }
        return "average";
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
        if (Factory == null)
        {
            return;
        }

        // Merge the characteristics from the base item category.
        Characteristics.Merge(Factory);

        // Now merge the characteristics from the fixed artifact, if there is one.
        if (FixedArtifact != null)
        {
            Characteristics.Merge(FixedArtifact);
        }

        // Now merge the characteristics from the rare item type, if there is one.
        if (RareItemTypeIndex != RareItemTypeEnum.None)
        {
            RareItem ePtr = SaveGame.SingletonRepository.RareItems[RareItemTypeIndex];
            Characteristics.Merge(ePtr);
        }

        Characteristics.Merge(RandartItemCharacteristics);

        if (!string.IsNullOrEmpty(RandartName))
        {
            switch (BonusPowerType)
            {
                case RareItemTypeEnum.SpecialSustain:
                    BonusPowerSubType.ActivateSpecialSustain(Characteristics);
                    break;
                case RareItemTypeEnum.SpecialPower:
                    BonusPowerSubType.ActivateSpecialPower(Characteristics);
                    break;
                case RareItemTypeEnum.SpecialAbility:
                    BonusPowerSubType.ActivateSpecialAbility(Characteristics);
                    break;
            }
        }

    }

    public string GetVagueFeeling()
    {
        if (IsCursed())
        {
            return "cursed";
        }
        if (IsBroken())
        {
            return "broken";
        }
        if (FixedArtifact != null || !string.IsNullOrEmpty(RandartName))
        {
            return "special";
        }
        if (IsRare())
        {
            return "good";
        }
        if (BonusArmorClass > 0)
        {
            return "good";
        }
        if (BonusToHit + BonusDamage > 0)
        {
            return "good";
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
            info[i++] = DescribeActivationEffect();
            info[i++] = "...if it is being worn.";
        }
        string categoryIdentity = Identify();
        if (categoryIdentity != null)
        {
            info[i++] = categoryIdentity;
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
        if (Characteristics.Lightsource)
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
        ScreenBuffer savedScreen = SaveGame.Screen.Clone();
        for (k = 1; k < 24; k++)
        {
            SaveGame.Screen.PrintLine("", k, 13);
        }
        SaveGame.Screen.PrintLine("     Item Attributes:", 1, 15);
        for (k = 2, j = 0; j < i; j++)
        {
            SaveGame.Screen.PrintLine(info[j], k++, 15);
            if (k == 22 && j + 1 < i)
            {
                SaveGame.Screen.PrintLine("-- more --", k, 15);
                SaveGame.Inkey();
                for (; k > 2; k--)
                {
                    SaveGame.Screen.PrintLine("", k, 15);
                }
            }
        }
        SaveGame.Screen.PrintLine("[Press any key to continue]", k, 15);
        SaveGame.Inkey();
        SaveGame.Screen.Restore(savedScreen);
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

    public bool IsFlavourAware()
    {
        if (Factory == null)
        {
            return false;
        }
        return Factory.FlavourAware;
    }

    public bool IsKnown()
    {
        if (Factory == null)
        {
            return false;
        }
        if (IdentKnown)
        {
            return true;
        }
        if (Factory.EasyKnow && Factory.FlavourAware)
        {
            return true;
        }
        return false;
    }

    public bool IsRare()
    {
        return RareItemTypeIndex != 0;
    }

    public ItemCharacteristics ObjectFlagsKnown()
    {
        if (!IsKnown())
        {
            return new ItemCharacteristics();
        }
        return Characteristics;
    }

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
        if (RandartItemCharacteristics.IsSet)
        {
            value += FlagBasedCost(TypeSpecificValue);
        }
        else if (FixedArtifact != null)
        {
            if (FixedArtifact.Cost == 0)
            {
                return 0;
            }
            value = FixedArtifact.Cost;
        }
        else if (RareItemTypeIndex != RareItemTypeEnum.None)
        {
            RareItem ePtr = SaveGame.SingletonRepository.RareItems[RareItemTypeIndex];
            if (ePtr.Cost == 0)
            {
                return 0;
            }
            value += ePtr.Cost;
        }
        if (IsWorthless())
        {
            return 0;
        }
        int? typeSpecificValue = GetTypeSpecificRealValue(value);
        if (typeSpecificValue == null)
        {
            return 0;
        }
        value += typeSpecificValue.Value;

        int? bonusValue = GetBonusRealValue(value);
        if (bonusValue == null)
            return 0;

        value += bonusValue.Value;
        return value;
    }

    public bool Stompable()
    {
        if (!IsKnown())
        {
            if (Factory.HasFlavor)
            {
                if (IsFlavourAware())
                {
                    return Factory.Stompable[StompableType.Broken];
                }
            }
            if (!IdentSense)
            {
                return false;
            }
        }
        return IsStompable();
    }

    public string StoreDescription(bool pref, int mode)
    {
        bool hackAware = Factory.FlavourAware;
        bool hackKnown = IdentKnown;
        IdentKnown = true;
        Factory.FlavourAware = true;
        string buf = Description(pref, mode);
        Factory.FlavourAware = hackAware;
        if (!hackKnown)
        {
            IdentKnown = false;
        }
        return buf;
    }

    /// <summary>
    /// Returns a description for the item.
    /// </summary>
    /// <returns></returns>
    /// <remarks>There may not be any references in code but this method is very useful for debugging.</remarks>
    public override string ToString()
    {
        return Description(false, 0);
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
            value = BaseValue();
        }
        if (Discount != 0)
        {
            value -= value * Discount / 100;
        }
        return value;
    }

    private int BaseValue()
    {
        if (IsFlavourAware())
        {
            return Factory.Cost;
        }
        return Factory.BaseValue;
    }

    private string? DescribeActivationEffect()
    {
        RefreshFlagBasedProperties();
        if (!Characteristics.Activate)
        {
            return null;
        }
        if (FixedArtifact == null && RareItemTypeIndex == 0 && BonusPowerType == 0 && BonusPowerSubType != null)
        {
            return BonusPowerSubType.Description;
        }

        if (FixedArtifact != null && typeof(IFixedArtifactActivatible).IsAssignableFrom(FixedArtifact.GetType()))
        {
            IFixedArtifactActivatible activatibleFixedArtifact = (IFixedArtifactActivatible)FixedArtifact;
            return activatibleFixedArtifact.DescribeActivationEffect();
        }
        if (RareItemTypeIndex == RareItemTypeEnum.WeaponPlanarWeapon)
        {
            return "teleport every 50+d50 turns";
        }
        return Factory.DescribeActivationEffect;
    }

    public void ApplyMagic(int lev, bool okay, bool good, bool great, Store? store)
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
        if (good || Program.Rng.PercentileRoll(f1))
        {
            power = 1;
            if (great || Program.Rng.PercentileRoll(f2))
            {
                power = 2;
            }
        }
        else if (Program.Rng.PercentileRoll(f1))
        {
            power = -1;
            if (Program.Rng.PercentileRoll(f2))
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
            TypeSpecificValue = FixedArtifact.Pval;
            BaseArmorClass = FixedArtifact.Ac;
            DamageDice = FixedArtifact.Dd;
            DamageDiceSides = FixedArtifact.Ds;
            BonusArmorClass = FixedArtifact.ToA;
            BonusToHit = FixedArtifact.ToH;
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
            SaveGame.TreasureRating += 10;
            if (FixedArtifact.Cost > 50000)
            {
                SaveGame.TreasureRating += 10;
            }
            SaveGame.SpecialTreasure = true;
            return;
        }
        ApplyMagic(lev, power, store);
        if (!string.IsNullOrEmpty(RandartName))
        {
            SaveGame.TreasureRating += 40;
        }
        else if (RareItemTypeIndex != RareItemTypeEnum.None)
        {
            RareItem ePtr = SaveGame.SingletonRepository.RareItems[RareItemTypeIndex];
            switch (RareItemTypeIndex)
            {
                case RareItemTypeEnum.WeaponElderSign:
                    {
                        BonusPowerType = RareItemTypeEnum.SpecialSustain;
                        break;
                    }
                case RareItemTypeEnum.WeaponDefender:
                    {
                        BonusPowerType = RareItemTypeEnum.SpecialSustain;
                        break;
                    }
                case RareItemTypeEnum.WeaponBlessed:
                    {
                        BonusPowerType = RareItemTypeEnum.SpecialAbility;
                        break;
                    }
                case RareItemTypeEnum.WeaponPlanarWeapon:
                    {
                        if (Program.Rng.DieRoll(7) == 1)
                        {
                            BonusPowerType = RareItemTypeEnum.SpecialAbility;
                        }
                        break;
                    }
                case RareItemTypeEnum.ArmourOfPermanence:
                    {
                        BonusPowerType = RareItemTypeEnum.SpecialPower;
                        break;
                    }
                case RareItemTypeEnum.ArmourOfYith:
                    {
                        BonusPowerType = RareItemTypeEnum.SpecialPower;
                        break;
                    }
                case RareItemTypeEnum.HatOfTheMagi:
                    {
                        BonusPowerType = RareItemTypeEnum.SpecialAbility;
                        break;
                    }
                case RareItemTypeEnum.CloakOfAman:
                    {
                        BonusPowerType = RareItemTypeEnum.SpecialPower;
                        break;
                    }
            }
            if (BonusPowerType != 0 && string.IsNullOrEmpty(RandartName))
            {
                BonusPowerSubType= SaveGame.SingletonRepository.Activations.ToWeightedRandom().Choose();
            }
            if (ePtr.Cost == 0)
            {
                IdentBroken = true;
            }
            if (ePtr.Cursed)
            {
                IdentCursed = true;
            }
            if (IsCursed() || IsBroken())
            {
                if (ePtr.MaxToH != 0)
                {
                    BonusToHit -= Program.Rng.DieRoll(ePtr.MaxToH);
                }
                if (ePtr.MaxToD != 0)
                {
                    BonusDamage -= Program.Rng.DieRoll(ePtr.MaxToD);
                }
                if (ePtr.MaxToA != 0)
                {
                    BonusArmorClass -= Program.Rng.DieRoll(ePtr.MaxToA);
                }
                if (ePtr.MaxPval != 0)
                {
                    TypeSpecificValue -= Program.Rng.DieRoll(ePtr.MaxPval);
                }
            }
            else
            {
                if (ePtr.MaxToH != 0)
                {
                    BonusToHit += Program.Rng.DieRoll(ePtr.MaxToH);
                }
                if (ePtr.MaxToD != 0)
                {
                    BonusDamage += Program.Rng.DieRoll(ePtr.MaxToD);
                }
                if (ePtr.MaxToA != 0)
                {
                    BonusArmorClass += Program.Rng.DieRoll(ePtr.MaxToA);
                }
                if (ePtr.MaxPval != 0)
                {
                    TypeSpecificValue += Program.Rng.DieRoll(ePtr.MaxPval);
                }
            }
            SaveGame.TreasureRating += ePtr.Rating;
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

    /// <summary>
    /// Applies magic to the item.  Does nothing, by default.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    protected virtual void ApplyMagic(int level, int power, Store? store) { }

    public void ApplyRandomResistance(ref IArtifactBias artifactBias, int specific)
    {
        if (specific == 0 && artifactBias != null)
        {
            if (artifactBias.ApplyRandomResistances(this))
            {
                return;
            }

        }
        switch (specific != 0 ? specific : Program.Rng.DieRoll(41))
        {
            case 1:
                if (Program.Rng.DieRoll(Constants.WeirdLuck) != 1)
                {
                    ApplyRandomResistance(ref artifactBias, 0);
                }
                else
                {
                    RandartItemCharacteristics.ImAcid = true;
                    if (artifactBias == null)
                    {
                        artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<AcidArtifactBias>();
                    }
                }
                break;

            case 2:
                if (Program.Rng.DieRoll(Constants.WeirdLuck) != 1)
                {
                    ApplyRandomResistance(ref artifactBias, 0);
                }
                else
                {
                    RandartItemCharacteristics.ImElec = true;
                    if (artifactBias == null)
                    {
                        artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<ElectricityArtifactBias>();
                    }
                }
                break;

            case 3:
                if (Program.Rng.DieRoll(Constants.WeirdLuck) != 1)
                {
                    ApplyRandomResistance(ref artifactBias, 0);
                }
                else
                {
                    RandartItemCharacteristics.ImCold = true;
                    if (artifactBias == null)
                    {
                        artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<ColdArtifactBias>();
                    }
                }
                break;

            case 4:
                if (Program.Rng.DieRoll(Constants.WeirdLuck) != 1)
                {
                    ApplyRandomResistance(ref artifactBias, 0);
                }
                else
                {
                    RandartItemCharacteristics.ImFire = true;
                    if (artifactBias == null)
                    {
                        artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<FireArtifactBias>();
                    }
                }
                break;

            case 5:
            case 6:
            case 13:
                RandartItemCharacteristics.ResAcid = true;
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<AcidArtifactBias>();
                }
                break;

            case 7:
            case 8:
            case 14:
                RandartItemCharacteristics.ResElec = true;
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<ElectricityArtifactBias>();
                }
                break;

            case 9:
            case 10:
            case 15:
                RandartItemCharacteristics.ResFire = true;
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<FireArtifactBias>();
                }
                break;

            case 11:
            case 12:
            case 16:
                RandartItemCharacteristics.ResCold = true;
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<ColdArtifactBias>();
                }
                break;

            case 17:
            case 18:
                RandartItemCharacteristics.ResPois = true;
                if (artifactBias == null && Program.Rng.DieRoll(4) != 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<PoisonArtifactBias>();
                }
                else if (artifactBias == null && Program.Rng.DieRoll(2) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<NecromanticArtifactBias>();
                }
                else if (artifactBias == null && Program.Rng.DieRoll(2) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<RogueArtifactBias>();
                }
                break;

            case 19:
            case 20:
                RandartItemCharacteristics.ResFear = true;
                if (artifactBias == null && Program.Rng.DieRoll(3) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<WarriorArtifactBias>();
                }
                break;

            case 21:
                RandartItemCharacteristics.ResLight = true;
                break;

            case 22:
                RandartItemCharacteristics.ResDark = true;
                break;

            case 23:
            case 24:
                RandartItemCharacteristics.ResBlind = true;
                break;

            case 25:
            case 26:
                RandartItemCharacteristics.ResConf = true;
                if (artifactBias == null && Program.Rng.DieRoll(6) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<ChaosArtifactBias>();
                }
                break;

            case 27:
            case 28:
                RandartItemCharacteristics.ResSound = true;
                break;

            case 29:
            case 30:
                RandartItemCharacteristics.ResShards = true;
                break;

            case 31:
            case 32:
                RandartItemCharacteristics.ResNether = true;
                if (artifactBias == null && Program.Rng.DieRoll(3) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<NecromanticArtifactBias>();
                }
                break;

            case 33:
            case 34:
                RandartItemCharacteristics.ResNexus = true;
                break;

            case 35:
            case 36:
                RandartItemCharacteristics.ResChaos = true;
                if (artifactBias == null && Program.Rng.DieRoll(2) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<ChaosArtifactBias>();
                }
                break;

            case 37:
            case 38:
                RandartItemCharacteristics.ResDisen = true;
                break;

            case 39:
                if (Factory.CanProvideSheathOfElectricity)
                {
                    RandartItemCharacteristics.ShElec = true;
                }
                else
                {
                    ApplyRandomResistance(ref artifactBias, 0);
                }
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<ElectricityArtifactBias>();
                }
                break;

            case 40:
                if (Factory.CanProvideSheathOfFire)
                {
                    RandartItemCharacteristics.ShFire = true;
                }
                else
                {
                    ApplyRandomResistance(ref artifactBias, 0);
                }
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<FireArtifactBias>();
                }
                break;

            case 41:
                if (Factory.CanReflectBoltsAndArrows)
                {
                    RandartItemCharacteristics.Reflect = true;
                }
                else
                {
                    ApplyRandomResistance(ref artifactBias, 0);
                }
                break;
        }
    }

    public bool CreateRandart(bool fromScroll)
    {
        const int ArtifactCurseChance = 13;
        bool hasPval = false;
        int powers = Program.Rng.DieRoll(5) + 1;
        bool aCursed = false;
        int warriorArtifactBias = 0;
        IArtifactBias? artifactBias = null;
        if (fromScroll && Program.Rng.DieRoll(4) == 1)
        {
            artifactBias = SaveGame.BaseCharacterClass.ArtifactBias;
            warriorArtifactBias = SaveGame.BaseCharacterClass.FromScrollWarriorArtifactBiasPercentageChance;
        }
        if (Program.Rng.DieRoll(100) <= warriorArtifactBias && fromScroll)
        {
            artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<WarriorArtifactBias>();
        }
        string newName;
        if (!fromScroll && Program.Rng.DieRoll(ArtifactCurseChance) == 1)
        {
            aCursed = true;
        }
        while (Program.Rng.DieRoll(powers) == 1 || Program.Rng.DieRoll(7) == 1 || Program.Rng.DieRoll(10) == 1)
        {
            powers++;
        }
        if (!aCursed && Program.Rng.DieRoll(Constants.WeirdLuck) == 1)
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
            switch (Program.Rng.DieRoll(maxType))
            {
                case 1:
                case 2:
                    ApplyRandomBonuses(ref artifactBias);
                    hasPval = true;
                    break;

                case 3:
                case 4:
                    ApplyRandomResistance(ref artifactBias, 0);
                    break;

                case 5:
                    ApplyRandomMiscPower(ref artifactBias);
                    break;

                case 6:
                case 7:
                    ApplyRandomSlaying(ref artifactBias);
                    break;

                default:
                    powers++;
                    break;
            }
        }
        if (hasPval)
        {
            if (RandartItemCharacteristics.Blows)
            {
                TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
            }
            else
            {
                do
                {
                    TypeSpecificValue++;
                } while (TypeSpecificValue < Program.Rng.DieRoll(5) ||
                         Program.Rng.DieRoll(TypeSpecificValue) == 1);
            }
            if (TypeSpecificValue > 4 && Program.Rng.DieRoll(Constants.WeirdLuck) != 1)
            {
                TypeSpecificValue = 4;
            }
        }
        ApplyRandartBonus();
        RandartItemCharacteristics.IgnoreAcid = true;
        RandartItemCharacteristics.IgnoreElec = true;
        RandartItemCharacteristics.IgnoreFire = true;
        RandartItemCharacteristics.IgnoreCold = true;
        int totalFlags = FlagBasedCost(TypeSpecificValue);
        if (aCursed)
        {
            CurseRandart();
        }
        if (!aCursed && Program.Rng.DieRoll(Factory.RandartActivationChance) == 1)
        {
            BonusPowerSubType = null;
            GiveActivationPower(ref artifactBias);
        }
        if (fromScroll)
        {
            IdentifyFully();
            IdentStoreb = true;
            if (!SaveGame.GetString("What do you want to call the artifact? ", out string dummyName, "(a DIY artifact)", 80))
            {
                newName = "(a DIY artifact)";
            }
            else
            {
                newName = "called '" + dummyName + "'";
            }
            BecomeFlavourAware();
            BecomeKnown();
            IdentMental = true;
        }
        else
        {
            newName = GetTableName();
        }
        RandartName = newName;
        return true;
    }

    public void GetFixedArtifactResistances()
    {
        if (FixedArtifact != null)
        {
            FixedArtifact.ApplyResistances(SaveGame, this);
        }
    }

    private bool ApplyFixedArtifact()
    {
        if (Count != 1)
        {
            return false;
        }
        foreach (FixedArtifact aPtr in SaveGame.SingletonRepository.FixedArtifacts)
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

            if (aPtr.BaseItemCategory != Factory)
            {
                continue;
            }
            if (aPtr.Level > SaveGame.Difficulty)
            {
                int d = (aPtr.Level - SaveGame.Difficulty) * 2;
                if (Program.Rng.RandomLessThan(d) != 0)
                {
                    continue;
                }
            }
            if (Program.Rng.RandomLessThan(aPtr.Rarity) != 0)
            {
                continue;
            }
            FixedArtifact = aPtr;
            GetFixedArtifactResistances();
            return true;
        }
        return false;
    }

    private void ApplyRandomBonuses(ref IArtifactBias artifactBias)
    {
        if (artifactBias != null)
        {
            if (artifactBias.ApplyBonuses(this))
            {
                return;
            }
        }
        switch (Program.Rng.DieRoll(23))
        {
            case 1:
            case 2:
                RandartItemCharacteristics.Str = true;
                if (artifactBias == null && Program.Rng.DieRoll(13) != 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<StrengthArtifactBias>();
                }
                else if (artifactBias == null && Program.Rng.DieRoll(7) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<WarriorArtifactBias>();
                }
                break;

            case 3:
            case 4:
                RandartItemCharacteristics.Int = true;
                if (artifactBias == null && Program.Rng.DieRoll(13) != 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<IntelligenceArtifactBias>();
                }
                else if (artifactBias == null && Program.Rng.DieRoll(7) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<MageArtifactBias>();
                }
                break;

            case 5:
            case 6:
                RandartItemCharacteristics.Wis = true;
                if (artifactBias == null && Program.Rng.DieRoll(13) != 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<WisdomArtifactBias>();
                }
                else if (artifactBias == null && Program.Rng.DieRoll(7) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<PriestlyArtifactBias>();
                }
                break;

            case 7:
            case 8:
                RandartItemCharacteristics.Dex = true;
                if (artifactBias == null && Program.Rng.DieRoll(13) != 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<DexterityArtifactBias>();
                }
                else if (artifactBias == null && Program.Rng.DieRoll(7) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<RogueArtifactBias>();
                }
                break;

            case 9:
            case 10:
                RandartItemCharacteristics.Con = true;
                if (artifactBias == null && Program.Rng.DieRoll(13) != 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<ConstitutionArtifactBias>();
                }
                else if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<RangerArtifactBias>();
                }
                break;

            case 11:
            case 12:
                RandartItemCharacteristics.Cha = true;
                if (artifactBias == null && Program.Rng.DieRoll(13) != 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<CharismaArtifactBias>();
                }
                break;

            case 13:
            case 14:
                RandartItemCharacteristics.Stealth = true;
                if (artifactBias == null && Program.Rng.DieRoll(3) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<RogueArtifactBias>();
                }
                break;

            case 15:
            case 16:
                RandartItemCharacteristics.Search = true;
                if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<RangerArtifactBias>();
                }
                break;

            case 17:
            case 18:
                RandartItemCharacteristics.Infra = true;
                break;

            case 19:
                RandartItemCharacteristics.Speed = true;
                if (artifactBias == null && Program.Rng.DieRoll(11) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<RogueArtifactBias>();
                }
                break;

            case 20:
            case 21:
                if (!Factory.CanApplyTunnelBonus)
                {
                    ApplyRandomBonuses(ref artifactBias);
                }
                else
                {
                    RandartItemCharacteristics.Tunnel = true;
                }
                break;

            case 22:
            case 23:
                if (!CanApplyBlowsBonus)
                {
                    ApplyRandomBonuses(ref artifactBias);
                }
                else
                {
                    RandartItemCharacteristics.Blows = true;
                    if (artifactBias == null && Program.Rng.DieRoll(11) == 1)
                    {
                        artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<WarriorArtifactBias>();
                    }
                }
                break;
        }
    }

    private void ApplyRandomMiscPower(ref IArtifactBias artifactBias)
    {
        if (artifactBias != null)
        {
            artifactBias.ApplyMiscPowers(this);
        }
        switch (Program.Rng.DieRoll(31))
        {
            case 1:
                RandartItemCharacteristics.SustStr = true;
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<StrengthArtifactBias>();
                }
                break;

            case 2:
                RandartItemCharacteristics.SustInt = true;
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<IntelligenceArtifactBias>();
                }
                break;

            case 3:
                RandartItemCharacteristics.SustWis = true;
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<WisdomArtifactBias>();
                }
                break;

            case 4:
                RandartItemCharacteristics.SustDex = true;
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<DexterityArtifactBias>();
                }
                break;

            case 5:
                RandartItemCharacteristics.SustCon = true;
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<ConstitutionArtifactBias>();
                }
                break;

            case 6:
                RandartItemCharacteristics.SustCha = true;
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<CharismaArtifactBias>();
                }
                break;

            case 7:
            case 8:
            case 14:
                RandartItemCharacteristics.FreeAct = true;
                break;

            case 9:
                RandartItemCharacteristics.HoldLife = true;
                if (artifactBias == null && Program.Rng.DieRoll(5) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<PriestlyArtifactBias>();
                }
                else if (artifactBias == null && Program.Rng.DieRoll(6) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<NecromanticArtifactBias>();
                }
                break;

            case 10:
            case 11:
                RandartItemCharacteristics.Lightsource = true;
                break;

            case 12:
            case 13:
                RandartItemCharacteristics.Feather = true;
                break;

            case 15:
            case 16:
            case 17:
                RandartItemCharacteristics.SeeInvis = true;
                break;

            case 18:
                RandartItemCharacteristics.Telepathy = true;
                if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<MageArtifactBias>();
                }
                break;

            case 19:
            case 20:
                RandartItemCharacteristics.SlowDigest = true;
                break;

            case 21:
            case 22:
                RandartItemCharacteristics.Regen = true;
                break;

            case 23:
                RandartItemCharacteristics.Teleport = true;
                break;

            case 24:
            case 25:
            case 26:
                if (!CanApplyBonusArmorClassMiscPower)
                {
                    ApplyRandomMiscPower(ref artifactBias);
                }
                else
                {
                    RandartItemCharacteristics.ShowMods = true;
                    BonusArmorClass = 4 + Program.Rng.DieRoll(11);
                }
                break;

            case 27:
            case 28:
            case 29:
                RandartItemCharacteristics.ShowMods = true;
                BonusToHit += 4 + Program.Rng.DieRoll(11);
                BonusDamage += 4 + Program.Rng.DieRoll(11);
                break;

            case 30:
                RandartItemCharacteristics.NoMagic = true;
                break;

            case 31:
                RandartItemCharacteristics.NoTele = true;
                break;
        }
    }

    public virtual void ApplyRandomSlaying(ref IArtifactBias artifactBias)
    {
        if (artifactBias != null)
        {
            if (artifactBias.ApplySlaying(this))
            {
                return;
            }
        }

        switch (Program.Rng.DieRoll(34))
        {
            case 1:
            case 2:
                RandartItemCharacteristics.SlayAnimal = true;
                break;

            case 3:
            case 4:
                RandartItemCharacteristics.SlayEvil = true;
                if (artifactBias == null && Program.Rng.DieRoll(2) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<LawArtifactBias>();
                }
                else if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<PriestlyArtifactBias>();
                }
                break;

            case 5:
            case 6:
                RandartItemCharacteristics.SlayUndead = true;
                if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<PriestlyArtifactBias>();
                }
                break;

            case 7:
            case 8:
                RandartItemCharacteristics.SlayDemon = true;
                if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<PriestlyArtifactBias>();
                }
                break;

            case 9:
            case 10:
                RandartItemCharacteristics.SlayOrc = true;
                break;

            case 11:
            case 12:
                RandartItemCharacteristics.SlayTroll = true;
                break;

            case 13:
            case 14:
                RandartItemCharacteristics.SlayGiant = true;
                break;

            case 15:
            case 16:
                RandartItemCharacteristics.SlayDragon = true;
                break;

            case 17:
                RandartItemCharacteristics.KillDragon = true;
                break;

            case 18:
            case 19:
                if (CanVorpalSlay)
                {
                    RandartItemCharacteristics.Vorpal = true;
                    if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<WarriorArtifactBias>();
                    }
                }
                else
                {
                    ApplyRandomSlaying(ref artifactBias);
                }
                break;

            case 20:
                RandartItemCharacteristics.Impact = true;
                break;

            case 21:
            case 22:
                RandartItemCharacteristics.BrandFire = true;
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<FireArtifactBias>();
                }
                break;

            case 23:
            case 24:
                RandartItemCharacteristics.BrandCold = true;
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<ColdArtifactBias>();
                }
                break;

            case 25:
            case 26:
                RandartItemCharacteristics.BrandElec = true;
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<ElectricityArtifactBias>();
                }
                break;

            case 27:
            case 28:
                RandartItemCharacteristics.BrandAcid = true;
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<AcidArtifactBias>();
                }
                break;

            case 29:
            case 30:
                RandartItemCharacteristics.BrandPois = true;
                if (artifactBias == null && Program.Rng.DieRoll(3) != 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<PoisonArtifactBias>();
                }
                else if (artifactBias == null && Program.Rng.DieRoll(6) == 1)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<NecromanticArtifactBias>();
                }
                else if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<RogueArtifactBias>();
                }
                break;

            case 31:
            case 32:
                RandartItemCharacteristics.Vampiric = true;
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<NecromanticArtifactBias>();
                }
                break;

            default:
                RandartItemCharacteristics.Chaotic = true;
                if (artifactBias == null)
                {
                    artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<ChaosArtifactBias>();
                }
                break;
        }
    }

    private void CurseRandart()
    {
        if (TypeSpecificValue != 0)
        {
            TypeSpecificValue = 0 - (TypeSpecificValue + Program.Rng.DieRoll(4));
        }
        if (BonusArmorClass != 0)
        {
            BonusArmorClass = 0 - (BonusArmorClass + Program.Rng.DieRoll(4));
        }
        if (BonusToHit != 0)
        {
            BonusToHit = 0 - (BonusToHit + Program.Rng.DieRoll(4));
        }
        if (BonusDamage != 0)
        {
            BonusDamage = 0 - (BonusDamage + Program.Rng.DieRoll(4));
        }
        RandartItemCharacteristics.HeavyCurse = true;
        RandartItemCharacteristics.Cursed = true;
        if (Program.Rng.DieRoll(4) == 1)
        {
            RandartItemCharacteristics.PermaCurse = true;
        }
        if (Program.Rng.DieRoll(3) == 1)
        {
            RandartItemCharacteristics.DreadCurse = true;
        }
        if (Program.Rng.DieRoll(2) == 1)
        {
            RandartItemCharacteristics.Aggravate = true;
        }
        if (Program.Rng.DieRoll(3) == 1)
        {
            RandartItemCharacteristics.DrainExp = true;
        }
        if (Program.Rng.DieRoll(2) == 1)
        {
            RandartItemCharacteristics.Teleport = true;
        }
        else if (Program.Rng.DieRoll(3) == 1)
        {
            RandartItemCharacteristics.NoTele = true;
        }
        if (SaveGame.BaseCharacterClass.ID != CharacterClass.Warrior && Program.Rng.DieRoll(3) == 1)
        {
            RandartItemCharacteristics.NoMagic = true;
        }
        IdentCursed = true;
    }

    private string GetTableName()
    {
        int testcounter = Program.Rng.DieRoll(3) + 1;
        string outString = "";
        if (Program.Rng.DieRoll(3) == 2)
        {
            while (testcounter-- != 0)
            {
                outString += BaseScrollFlavour.Syllables[Program.Rng.RandomLessThan(BaseScrollFlavour.Syllables.Length)];
            }
        }
        else
        {
            testcounter = Program.Rng.DieRoll(2) + 1;
            while (testcounter-- != 0)
            {
                outString += SaveGame.SingletonRepository.ElvishText.ToWeightedRandom().Choose();
            }
        }
        return "'" + outString.Substring(0, 1).ToUpper() + outString.Substring(1) + "'";
    }

    private void GiveActivationPower(ref IArtifactBias artifactBias)
    {
        Activation type = null;
        if (artifactBias != null)
        {
            if (Program.Rng.DieRoll(100) < artifactBias.ActivationPowerChance)
            {
                type = artifactBias.GetActivationPowerType(this);
            }
        }
        if (type == null)
        {
            int chance = 0;
            while (type == null || Program.Rng.DieRoll(100) >= chance)
            {
                type = SaveGame.SingletonRepository.Activations.ToWeightedRandom().Choose();
                chance = type.RandomChance;
            }
        }
        BonusPowerSubType = type;
        RandartItemCharacteristics.Activate = true;
        RechargeTimeLeft = 0;
    }

    /// <summary>
    /// Gets an additional bonus gold real value associated with the item.  Returns 0, by default.  Returns null, if the item is worthless.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual int? GetBonusRealValue(int value) => 0;


    protected int GetBonusValue(int max, int level)
    {
        if (level > Constants.MaxDepth - 1)
        {
            level = Constants.MaxDepth - 1;
        }
        int bonus = max * level / Constants.MaxDepth;
        int extra = max * level % Constants.MaxDepth;
        if (Program.Rng.RandomLessThan(Constants.MaxDepth) < extra)
        {
            bonus++;
        }
        int stand = max / 4;
        extra = max % 4;
        if (Program.Rng.RandomLessThan(4) < extra)
        {
            stand++;
        }
        int value = Program.Rng.RandomNormal(bonus, stand);
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
    /// Returns an additional description when identified fully.  Returns null by default.  Only light sources provide an additional description.
    /// </summary>
    public virtual string Identify() => null;

    /// <summary>
    /// Applies an additional bonus to random artifacts.  Does nothing by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual void ApplyRandartBonus() { }

    public virtual int? GetTypeSpecificRealValue(int value) => 0;

    /// <summary>
    /// Provides base functionality for the type specific real value.  Returns a real value for the type specific characteristics of the item.  Returns
    /// null, if the item is worthless.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    protected int? ComputeTypeSpecificRealValue(int value)
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

    protected int MassRoll(int num, int max)
    {
        int t = 0;
        for (int i = 0; i < num; i++)
        {
            t += Program.Rng.RandomLessThan(max);
        }
        return t;
    }

    /// <summary>
    /// Returns the number of additional items to be produced, when the item is mass produced for a store.  Returns 0, by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual int GetAdditionalMassProduceCount() => 0;

    /// <summary>
    /// Returns a description for the item.  Returns a macro processed description, by default.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="includeCountPrefix">Specify true, to include the number of items as the prefix; false, to excluse the count.  Pluralization will still
    /// occur when the count is not included.</param>
    /// <returns></returns>
    public virtual string GetDescription(bool includeCountPrefix)
    {
        string pluralizedName = ApplyPlurizationMacro(Factory.FriendlyName, Count);
        return ApplyGetPrefixCountMacro(includeCountPrefix, pluralizedName, Count, IsKnownArtifact);
    }

    /// <summary>
    /// Returns an additional description of the item that is appended to the base description, when needed.  Returns string.empty by default.
    /// </summary>
    /// <returns></returns>
    public virtual string GetDetailedDescription()
    {
        string s = "";
        if (IsKnown())
        {
            RefreshFlagBasedProperties();
            if (Factory.ShowMods || BonusToHit != 0 && BonusDamage != 0)
            {
                s += $" ({GetSignedValue(BonusToHit)},{GetSignedValue(BonusDamage)})";
            }
            else if (BonusToHit != 0)
            {
                s += $" ({GetSignedValue(BonusToHit)})";
            }
            else if (BonusDamage != 0)
            {
                s += $" ({GetSignedValue(BonusDamage)})";
            }

            if (BaseArmorClass != 0)
            {
                // Add base armour class for all types of armour and when the base armour class is greater than zero.
                s += $" [{BaseArmorClass},{GetSignedValue(BonusArmorClass)}]";
            }
            else if (BonusArmorClass != 0)
            {
                // This is not armour, only show bonus armour class, if it is not zero and we know about it.
                s += $" [{GetSignedValue(BonusArmorClass)}]";
            }
        }
        return s;
    }

    /// <summary>
    /// Returns an additional description of the item that is appended to the detailed description, when needed.  
    /// By default, empty is returned, if the item is known; otherwise, the HideType, Speed, Blows, Stealth, Search, Infra, Tunnel and recharging time characteristics are returned.
    /// </summary>
    /// <returns></returns>
    public virtual string GetVerboseDescription()
    {
        string s = "";
        RefreshFlagBasedProperties();
        if (IsKnown() && Factory.HasAnyPvalMask)
        {
            s += $" ({GetSignedValue(TypeSpecificValue)}";
            if (Factory.HideType)
            {
            }
            else if (Factory.Speed)
            {
                s += " speed";
            }
            else if (Factory.Blows)
            {
                if (TypeSpecificValue > 1)
                {
                    s += " attacks";
                }
                else
                {
                    s += " attack";
                }
            }
            else if (Factory.Stealth)
            {
                s += " stealth";
            }
            else if (Factory.Search)
            {
                s += " searching";
            }
            else if (Factory.Infra)
            {
                s += " infravision";
            }
            else if (Factory.Tunnel)
            {
            }
            s += ")";
        }
        if (IsKnown() && RechargeTimeLeft != 0)
        {
            s += " (charging)";
        }
        return s;
    }

    /// <summary>
    /// Returns an additional description to fully identify the item that is appended to the verbode description, when needed.  
    /// By default, returns the description for inscriptions, cursed, empty, tried and on discount.
    /// </summary>
    /// <returns></returns>
    public virtual string GetFullDescription()
    {
        string tmpVal2 = "";
        if (!string.IsNullOrEmpty(Inscription))
        {
            tmpVal2 = Inscription;
        }
        else if (IsCursed() && (IsKnown() || IdentSense))
        {
            tmpVal2 = "cursed";
        }
        else if (!IsKnown() && IdentEmpty)
        {
            tmpVal2 = "empty";
        }
        else if (!IsFlavourAware() && Factory.Tried)
        {
            tmpVal2 = "tried";
        }
        else if (Discount != 0)
        {
            tmpVal2 = Discount.ToString();
            tmpVal2 += "% off";
        }
        if (!string.IsNullOrEmpty(tmpVal2))
        {
            tmpVal2 = $" {{{tmpVal2}}}";
        }
        return tmpVal2;
    }

    /// <summary>
    /// Returns true, if the item can be stomped.  Returns the stompable status based on the item "Feeling", by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual bool IsStompable()
    {
        if (Factory.HasQuality)
        {
            switch (GetDetailedFeeling()) // TODO: This is poor
            {
                case "terrible":
                case "worthless":
                case "cursed":
                case "broken":
                    return Factory.Stompable[StompableType.Broken];

                case "average":
                    return Factory.Stompable[StompableType.Average];

                case "good":
                    return Factory.Stompable[StompableType.Good];

                case "excellent":
                    return Factory.Stompable[StompableType.Excellent];

                case "special":
                    return false;

                default:
                    throw new InvalidDataException($"Unrecognised item quality ({GetDetailedFeeling()})");
            }
        }
        return Factory.Stompable[StompableType.Broken];
    }

    /// <summary>
    /// Returns true, if the item is deemed as worthless.  Worthless items will ignore their RealValue and will always have 0 real value.  Returns false by default.
    /// </summary>
    public virtual bool IsWorthless() => false;

    /// <summary>
    /// Returns true, if the item is ignored by monsters.  Returns false for all items, except gold.  Gold isn't picked up by monsters.
    /// </summary>
    public virtual bool IsIgnoredByMonsters => false;
}