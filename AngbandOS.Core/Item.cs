// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Races;
using AngbandOS.Core.Spells;
using System.Reflection.PortableExecutable;
using System.Reflection;
using System.Text.RegularExpressions;
using System;

namespace AngbandOS.Core;

/// <summary>
/// Represents an instance of an item.  This item object is universally capable of being any type of object in the game but it also has a
/// single parent (or factory) that controls what type of object the item is.
/// </summary>
[Serializable]
internal sealed class Item : IComparable<Item>
{
    /// <summary>
    /// Returns the factory that created this item.  All of the initial state data is retrieved from the <see cref="ItemFactory"/>when the <see cref="Item"/> is created.  We preserve this <see cref="ItemFactory"/>
    /// because the factory provides some methods but eventually, these methods will become customizable scripts that the <see cref="Item"/> will take copies of when the <see cref="Item"/> is constructed.  At 
    /// that point, the <see cref="ItemFactory"/> will no longer be needed after construction.
    /// </summary>
    private ItemFactory _factory { get; set; }

    public FixedArtifact? FixedArtifact; // If this item is a fixed artifact, this will be not null.

    /// <summary>
    /// Returns the rare item, if the item is a rare item; or null, if the item is not rare.
    /// </summary>
    public ItemAdditiveBundle? RareItem = null; // TODO: To accommodate the RandomPower ... this needs to be an array

    /// <summary>
    /// Returns the base characteristics for this item.  These characteristics all provide defaults and can be modified with magic via enchancement or random artifact creation.
    /// </summary>
    public ItemCharacteristics Characteristics = new ItemCharacteristics();

    public RandomArtifactCharacteristics? RandomArtifact = null;

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
    /// Returns an additional special power that is added for fixed artifacts and rare items.
    /// </summary>
    public ItemAdditiveBundle? RandomPower = null;

    public int Count;
    public int Discount;
    public int HoldingMonsterIndex;
    public string Inscription = "";

    #region Factory Encapsulation and Properties that will need to be part of the IItemCharacteristics
    // All of these properties are initially set by the Factory.
    public int TurnsOfLightRemaining;

    /// <summary>
    /// Returns the number of gold pieces the item contains.  Applies to gold.
    /// </summary>
    public int GoldPieces;

    public int BonusHit;
    public int BonusDamage;
    public int BonusArmorClass;
    public int ArmorClass;
    public int DamageDice;
    public int DamageSides;
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
    /// This property used to be a flag in the IdentifyFlags.
    /// </summary>
    public bool IsCursed;

    /// <summary>
    /// Returns true, if the item is broken; false, otherwise.  Broken items are considered worthless, regardless of their other properties.
    /// </summary>
    public bool IsBroken;


    public ColorEnum FlavorColor => _factory.FlavorColor; // TODO: Rename to represent current or assigned
    public Symbol FlavorSymbol => _factory.FlavorSymbol; // TODO: Rename to represent current or assigned
    public ColorEnum Color => _factory.Color; // TODO: Rename to represent raw or original or base
    public ItemFactory GetFactory => _factory;

    /// <summary>
    /// Returns a sort order index for sorting items in a pack.  Lower numbers show before higher numbers.
    /// </summary>
    public int PackSort { get; private set; }

    public bool Tried => _factory.Tried;
    public Spell[]? Spells { get; private set; }
    public bool CanBeEatenByMonsters { get; private set; }
    public int? MaxPhlogiston { get; private set; }
    public bool IsMagical { get; private set; }
    public ItemClass ItemClass { get; private set; }
    public int MakeObjectCount { get; private set; }
    public int LevelNormallyFound { get; private set; }
    public int NumberOfItemsContained { get; private set; }
    public int EnchantmentMaximumCount { get; private set; }
    public bool IsSmall { get; private set; }
    public int Cost { get; private set; }
    public bool AskDestroyAll { get; private set; }
    public bool VanishesWhenEatenBySkeletons { get; private set; }
    public bool CanSpikeDoorClosed { get; private set; }
    public bool IsFuelForTorch { get; private set; }
    public bool IsLanternFuel { get; private set; }
    public ItemFactory[]? AmmunitionItemFactories { get; private set; }
    public bool CanApplyBlessedArtifactBias { get; private set; }
    public bool CanApplyArtifactBiasSlaying { get; private set; }
    public bool CanApplyBlowsBonus { get; private set; }
    public bool CanReflectBoltsAndArrows { get; private set; }
    public bool CanApplySlayingBonus { get; private set; }
    public bool CanApplyBonusArmorClassMiscPower { get; private set; }
    public bool CanTunnel { get; private set; }
    public int BurnRate { get; private set; }
    public bool IsWearableOrWieldable { get; private set; }
    public bool CanProvideSheathOfElectricity { get; private set; }
    public bool CanProvideSheathOfFire { get; private set; }
    public bool ProvidesSunlight { get; private set; }
    public bool CanBeEaten { get; private set; }
    public IScriptItem? EatMagicScript { get; private set; }
    public bool HatesAcid { get; private set; }
    public bool HatesCold { get; private set; }
    public bool HatesElec { get; private set; }
    public bool HatesFire { get; private set; }
    public (INoticeableScript QuaffScript, IUnfriendlyScript? SmashScript, int ManaEquivalent)? QuaffDetails { get; private set; }
    public (IIdentifiedAndUsedScriptItemDirection Script, Roll TurnsToRecharge, bool RequiresAiming, int ManaEquivalent)? ZapDetails { get; private set; }
    public (IIdentifableAndUsedScript UseScript, Roll InitialCharges, int PerChargeValue, int ManaEquivalent)? UseDetails { get; private set; }
    public (IIdentifableDirectionalScript ActivationScript, Roll InitialChargesCountRoll, int PerChargeValue, int ManaValue)? AimingDetails { get; private set; }
    public (IIdentifableAndUsedScript ActivationScript, int ManaValue)? ActivationDetails { get; private set; }
    public Probability BreakageChanceProbability { get; private set; }
    public int MissileDamageMultiplier { get; private set; }
    public int WieldSlot { get; private set; }
    public bool CanBeRead { get; private set; }
    public IScriptItemInt? RechargeScript { get; private set; }
    public bool CanProjectArrows { get; private set; }
    public bool IsWeapon { get; private set; }
    public bool IsIgnoredByMonsters { get; private set; }
    public bool IsArmor { get; private set; }
    public bool IsContainer { get; private set; }
    public int ExperienceGainDivisorForDestroying { get; private set; }
    public bool IdentityCanBeSensed { get; private set; }
    public bool IsConsumedWhenEaten { get; private set; }
    public IIdentifableScript? EatScript { get; private set; }
    public bool GetsDamageMultiplier { get; private set; }

    /// <summary>
    /// Returns the nutritional value in turns provided to the player, when eaten.
    /// </summary>
    public int NutritionalValue { get; private set; }

    public int Weight { get; private set; }

    public bool HasQualityRatings { get; private set; } // This is only used within Item ... might be able to make it private.
    public bool EasyKnow { get; private set; } // This is only used within Item ... might be able to make it private.
    public int TurnOfLightValue { get; private set; } // This is only used within Item ... might be able to make it private.
    public int BaseValue { get; private set; } // This is only used within Item ... might be able to make it private.
    public int TreasureRating { get; private set; } // This is only used within Item ... might be able to make it private.
    public Realm Realm { get; private set; }

    public bool Smash(int who, int y, int x) => _factory.Smash(who, y, x);
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
    #endregion

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
    /// Returns true, if this item has been noticed and/or detected by the player.  Unnoticed items will cause the player to stop running.
    /// </summary>
    public bool WasNoticed = false;

    /// <summary>
    /// Returns the number of turns remaining to recharge the activation.
    /// </summary>
    public int ActivationRechargeTimeRemaining;

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

    public int X;
    public int Y;
    private readonly Game Game;

    public Item(Game game, ItemFactory factory)
    {
        Game = game;
        _factory = factory;

        Count = 1;

        // Now we retrieve all of the characteristics from the factory.
        ExperienceGainDivisorForDestroying = _factory.ExperienceGainDivisorForDestroying;
        IsSmall = _factory.IsSmall;
        Spells = _factory.Spells;

        BonusStrength = _factory.InitialBonusStrength;
        BonusIntelligence = _factory.InitialBonusIntelligence;
        BonusWisdom = _factory.InitialBonusWisdom;
        BonusDexterity = _factory.InitialBonusDexterity;
        BonusConstitution = _factory.InitialBonusConstitution;
        BonusCharisma = _factory.InitialBonusCharisma;
        BonusStealth = _factory.InitialBonusStealth;
        BonusSearch = _factory.InitialBonusSearch;
        BonusInfravision = _factory.InitialBonusInfravision;
        BonusTunnel = _factory.InitialBonusTunnel;
        BonusAttacks = _factory.InitialBonusAttacks;
        BonusSpeed = _factory.InitialBonusSpeed;
        NutritionalValue = _factory.InitialNutritionalValue;        
        GoldPieces = _factory.InitialGoldPiecesRoll.Get(Game.UseRandom);
        TurnsOfLightRemaining = _factory.InitialTurnsOfLight;
        Weight = _factory.Weight;
        BonusHit = _factory.BonusHit;
        BonusDamage = _factory.BonusDamage;
        BonusArmorClass = _factory.BonusArmorClass;
        ArmorClass = _factory.ArmorClass;
        DamageDice = _factory.DamageDice;
        DamageSides = _factory.DamageSides;
        IsBroken = _factory.IsBroken;
        IsCursed = _factory.IsCursed;
        EatScript = _factory.EatScript;
        IsConsumedWhenEaten = _factory.IsConsumedWhenEaten;
        IdentityCanBeSensed = _factory.IdentityCanBeSensed;
        IsContainer = _factory.IsContainer;
        IsArmor = _factory.IsArmor;
        WieldSlot = _factory.WieldSlot;
        CanBeRead = _factory.CanBeRead;
        RechargeScript = _factory.RechargeScript;
        CanProjectArrows = _factory.CanProjectArrows;
        IsWeapon = _factory.IsWeapon;
        IsIgnoredByMonsters = _factory.IsIgnoredByMonsters;
        QuaffDetails = _factory.QuaffDetails;
        ZapDetails = _factory.ZapDetails;
        UseDetails = _factory.UseDetails;
        AimingDetails = _factory.AimingDetails;
        ActivationDetails = _factory.ActivationDetails;
        BreakageChanceProbability = _factory.BreakageChanceProbability;
        MissileDamageMultiplier = _factory.MissileDamageMultiplier;
        CanBeEatenByMonsters = _factory.CanBeEatenByMonsters;
        MaxPhlogiston = _factory.MaxPhlogiston;
        IsMagical = _factory.IsMagical;
        ItemClass = _factory.ItemClass;
        MakeObjectCount = _factory.MakeObjectCount;
        LevelNormallyFound = _factory.LevelNormallyFound;
        NumberOfItemsContained = _factory.NumberOfItemsContained;
        EnchantmentMaximumCount = _factory.EnchantmentMaximumCount;
        Cost = _factory.Cost;
        AskDestroyAll = _factory.AskDestroyAll;
        VanishesWhenEatenBySkeletons = _factory.VanishesWhenEatenBySkeletons;
        CanSpikeDoorClosed = _factory.CanSpikeDoorClosed;
        IsFuelForTorch = _factory.IsFuelForTorch;
        IsLanternFuel = _factory.IsLanternFuel;
        AmmunitionItemFactories = _factory.AmmunitionItemFactories;
        CanApplyBlessedArtifactBias = _factory.CanApplyBlessedArtifactBias;
        CanApplyArtifactBiasSlaying = _factory.CanApplyArtifactBiasSlaying;
        CanApplyBlowsBonus = _factory.CanApplyBlowsBonus;
        CanReflectBoltsAndArrows = _factory.CanReflectBoltsAndArrows;
        CanApplySlayingBonus = _factory.CanApplySlayingBonus;
        CanApplyBonusArmorClassMiscPower = _factory.CanApplyBonusArmorClassMiscPower;
        CanTunnel = _factory.CanTunnel;
        BurnRate = _factory.BurnRate;
        IsWearableOrWieldable = _factory.IsWearableOrWieldable;
        CanProvideSheathOfElectricity = _factory.CanProvideSheathOfElectricity;
        CanProvideSheathOfFire = _factory.CanProvideSheathOfFire;
        ProvidesSunlight = _factory.ProvidesSunlight;
        CanBeEaten = _factory.CanBeEaten;
        EatMagicScript = _factory.EatMagicScript;
        HatesAcid = _factory.HatesAcid;
        HatesCold = _factory.HatesCold;
        HatesElec = _factory.HatesElectricity;
        HatesFire = _factory.HatesFire;
        PackSort = _factory.PackSort;
        GetsDamageMultiplier = _factory.GetsDamageMultiplier;
        HasQualityRatings = _factory.HasQualityRatings;
        EasyKnow = _factory.EasyKnow;
        TurnOfLightValue = _factory.TurnOfLightValue;
        BaseValue = _factory.BaseValue;
        TreasureRating = _factory.TreasureRating;
        Realm = _factory.Realm;

        if (_factory.AimingDetails != null)
        {
            WandChargesRemaining = _factory.AimingDetails.Value.InitialChargesCountRoll.Get(Game.UseRandom);
        }

        if (_factory.UseDetails != null)
        {
            StaffChargesRemaining = _factory.UseDetails.Value.InitialCharges.Get(Game.UseRandom);
        }

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

    // TODO: There is no way to ensure a cloned gets all of the properties
    public Item Clone(int? newCount = null)
    {
        // TODO: The assignments below need to be performed by each factory.  This can be integrated into the CreateItem.
        Item clonedItem = new Item(Game, _factory); // TODO: This logically doesn't make sense ... all of the data is now in the item.

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
        if (GetsDamageMultiplier)
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
        if (_factory != other._factory)
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
            else if (RareItem != null && RareItem.FriendlyName != null)
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
        basenm += _factory.GetDetailedDescription(this);
        basenm += _factory.GetVerboseDescription(this);

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
        else if (!IsFlavorAware && Tried)
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
        if (!HasQualityRatings)
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
        characteristics.Merge(_factory); // TODO: This merging is obsolete

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

        // If there are any random power characteristics, apply those also.
        if (RandomPower != null) // TODO: This smells funny
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
        string categoryIdentity = _factory.Identify(this);
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
            string burnRate = BurnRate == 0 ? "forever" : "when fueled";
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
        if (mergedCharacteristics.Radius > 0 && BurnRate == 0)
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
        if (EasyKnow && IsFlavorAware)
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
        if (Cost == 0)
        {
            return 0;
        }
        int value = Cost;
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
            // Check to see if the item is now worthless.
            if (RareItem.AdditiveBundleValue.HasValue)
            {
                if (RareItem.AdditiveBundleValue == 0)
                {
                    return 0;
                }
                value += RareItem.AdditiveBundleValue.Value;
            }
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
        if (mergedCharacteristics.InstaArt)
        {
            value += 0;
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

        if (AimingDetails != null)
        {
            value += AimingDetails.Value.PerChargeValue * WandChargesRemaining;
        }

        if (UseDetails != null)
        {
            value += UseDetails.Value.PerChargeValue * StaffChargesRemaining;
        }

        value += TurnOfLightValue * TurnsOfLightRemaining;
        value += _factory.GetBonusRealValue(this);
        return value;
    }

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
                        return _factory.Stompable[StompableType.Broken];
                    }
                }
                if (!IdentSense)
                {
                    return false;
                }
            }
            return _factory.IsStompable(this);
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
            if (IsFlavorAware)
            {
                return Cost;
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
        if (fixedArtifact.BonusStrength != null)
        {
            BonusStrength = fixedArtifact.BonusStrength.Get(Game.UseRandom);
        }
        if (fixedArtifact.BonusIntelligence != null)
        {
            BonusIntelligence = fixedArtifact.BonusIntelligence.Get(Game.UseRandom);
        }
        if (fixedArtifact.BonusWisdom != null)
        {
            BonusWisdom = fixedArtifact.BonusWisdom.Get(Game.UseRandom);
        }
        if (fixedArtifact.BonusDexterity != null)
        {
            BonusDexterity = fixedArtifact.BonusDexterity.Get(Game.UseRandom);
        }
        if (fixedArtifact.BonusConstitution != null)
        {
            BonusConstitution = fixedArtifact.BonusConstitution.Get(Game.UseRandom);
        }
        if (fixedArtifact.BonusCharisma != null)
        {
            BonusCharisma = fixedArtifact.BonusCharisma.Get(Game.UseRandom);
        }
        if (fixedArtifact.BonusStealth != null)
        {
            BonusStealth = fixedArtifact.BonusStealth.Get(Game.UseRandom);
        }
        if (fixedArtifact.BonusSearch != null)
        {
            BonusSearch = fixedArtifact.BonusSearch.Get(Game.UseRandom);
        }
        if (fixedArtifact.BonusInfravision != null)
        {
            BonusInfravision = fixedArtifact.BonusInfravision.Get(Game.UseRandom);
        }
        if (fixedArtifact.BonusTunnel != null)
        {
            BonusTunnel = fixedArtifact.BonusTunnel.Get(Game.UseRandom);
        }
        if (fixedArtifact.BonusAttacks != null)
        {
            BonusAttacks = fixedArtifact.BonusAttacks.Get(Game.UseRandom);
        }
        if (fixedArtifact.BonusSpeed != null)
        {
            BonusSpeed = fixedArtifact.BonusSpeed.Get(Game.UseRandom);
        }
        ArmorClass = fixedArtifact.Ac;
        DamageDice = fixedArtifact.Dd;
        DamageSides = fixedArtifact.Ds;
        BonusArmorClass = fixedArtifact.ToA;
        BonusHit = fixedArtifact.ToH;
        BonusDamage = fixedArtifact.ToD;
        Weight = fixedArtifact.Weight;
        if (fixedArtifact.IsCursed)
        {
            IsCursed = true;
        }
        GetFixedArtifactResistances();

        if (fixedArtifact.Cost == 0)
        {
            IsBroken = true;
        }
        Game.TreasureRating += fixedArtifact.TreasureRating;
        Game.SpecialTreasure = true;
        return true;
    }

    /// <summary>
    /// Applies 
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

        // The factory may have specified a breakage
        if (power == 0 && _factory.BreaksDuringEnchantmentProbability != null && _factory.BreaksDuringEnchantmentProbability.Test(Game))
        {
            power = -1;
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
            FixedArtifact? fixedArtifact = SelectCompatibleFixedArtifact();
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
        _factory.EnchantItem(this, usedOkay, lev, power); // Some item factories (i.g. armor, boots, helms etc) will convert the item into a RandomArtifact here.
        Game.TreasureRating += TreasureRating;
        if (IsRandomArtifact) 
        {
            Game.TreasureRating += Characteristics.TreasureRating;
        }
        else if (RareItem != null)
        {
            if (RareItem.RandomPower != null)
            {
                RandomPower = RareItem.RandomPower;
            }
            if (RareItem.AdditiveBundleValue.HasValue && RareItem.AdditiveBundleValue == 0)
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
        if (Cost == 0)
        {
            IsBroken = true;
        }
        if (IsCursed)
        {
            IsCursed = true;
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

    /// <summary>
    /// Imports the characteristics of another item.  This is only needed for the <see cref="Item.Clone"/> method.
    /// </summary>
    /// <param name="itemCharacteristicsA"></param>
    /// <param name="itemCharacteristicsB"></param>
    public void Copy(RandomArtifactCharacteristics characteristics)
    {
        // CanApplyBlessedArtifactBias = Factory.CanApplyBlessedArtifactBias; // TODO: Need to restore this.
        // CanApplyArtifactBiasSlaying = Factory.CanApplyArtifactBiasSlaying; // TODO: Need to restore this.
        // CanApplyBlowsBonus = Factory.CanApplyBlowsBonus; // TODO: Need to restore this.
        // CanReflectBoltsAndArrows = Factory.CanReflectBoltsAndArrows; // TODO: Need to restore this.
        // CanApplySlayingBonus = Factory.CanApplySlayingBonus; // TODO: Need to restore this.
        // CanApplyBonusArmorClassMiscPower = Factory.CanApplyBonusArmorClassMiscPower; // TODO: Need to restore this.
        // CanProvideSheathOfElectricity = Factory.CanProvideSheathOfElectricity; // TODO: Need to restore this.
        // CanProvideSheathOfFire = Factory.CanProvideSheathOfFire;        // TODO: Need to restore this.
        BonusHit = characteristics.BonusHit;
        BonusArmorClass = characteristics.BonusArmorClass;
        BonusDamage = characteristics.BonusDamage;
        BonusStrength = characteristics.BonusStrength;
        BonusIntelligence = characteristics.BonusIntelligence;
        BonusWisdom = characteristics.BonusWisdom;
        BonusDexterity = characteristics.BonusDexterity;
        BonusConstitution = characteristics.BonusConstitution;
        BonusCharisma = characteristics.BonusCharisma;
        BonusStealth = characteristics.BonusStealth;
        BonusSearch = characteristics.BonusSearch;
        BonusInfravision = characteristics.BonusInfravision;
        BonusTunnel = characteristics.BonusTunnel;
        BonusAttacks = characteristics.BonusAttacks;
        BonusSpeed = characteristics.BonusSpeed;        
        Characteristics.Activation = characteristics.Activation;
        Characteristics.Aggravate = characteristics.Aggravate;
        Characteristics.AntiTheft = characteristics.AntiTheft;
        Characteristics.ArtifactBias = characteristics.ArtifactBias;
        Characteristics.Blessed = characteristics.Blessed;
        Characteristics.Blows = characteristics.Blows;
        Characteristics.BrandAcid = characteristics.BrandAcid;
        Characteristics.BrandCold = characteristics.BrandCold;
        Characteristics.BrandElec = characteristics.BrandElec;
        Characteristics.BrandFire = characteristics.BrandFire;
        Characteristics.BrandPois = characteristics.BrandPois;
        Characteristics.Cha = characteristics.Cha;
        Characteristics.Chaotic = characteristics.Chaotic;
        Characteristics.Con = characteristics.Con;
        Characteristics.IsCursed = characteristics.IsCursed;
        Characteristics.Dex = characteristics.Dex;
        Characteristics.DrainExp = characteristics.DrainExp;
        Characteristics.DreadCurse = characteristics.DreadCurse;
        Characteristics.EasyKnow = characteristics.EasyKnow;
        Characteristics.Feather = characteristics.Feather;
        Characteristics.FreeAct = characteristics.FreeAct;
        Characteristics.HeavyCurse = characteristics.HeavyCurse;
        Characteristics.HideType = characteristics.HideType;
        Characteristics.HoldLife = characteristics.HoldLife;
        Characteristics.IgnoreAcid = characteristics.IgnoreAcid;
        Characteristics.IgnoreCold = characteristics.IgnoreCold;
        Characteristics.IgnoreElec = characteristics.IgnoreElec;
        Characteristics.IgnoreFire = characteristics.IgnoreFire;
        Characteristics.ImAcid = characteristics.ImAcid;
        Characteristics.ImCold = characteristics.ImCold;
        Characteristics.ImElec = characteristics.ImElec;
        Characteristics.ImFire = characteristics.ImFire;
        Characteristics.Impact = characteristics.Impact;
        Characteristics.Infra = characteristics.Infra;
        Characteristics.InstaArt = characteristics.InstaArt;
        Characteristics.Int = characteristics.Int;
        Characteristics.KillDragon = characteristics.KillDragon;
        Characteristics.NoMagic = characteristics.NoMagic;
        Characteristics.NoTele = characteristics.NoTele;
        Characteristics.PermaCurse = characteristics.PermaCurse;
        Characteristics.Radius = characteristics.Radius;
        Characteristics.Reflect = characteristics.Reflect;
        Characteristics.Regen = characteristics.Regen;
        Characteristics.ResAcid = characteristics.ResAcid;
        Characteristics.ResBlind = characteristics.ResBlind;
        Characteristics.ResChaos = characteristics.ResChaos;
        Characteristics.ResCold = characteristics.ResCold;
        Characteristics.ResConf = characteristics.ResConf;
        Characteristics.ResDark = characteristics.ResDark;
        Characteristics.ResDisen = characteristics.ResDisen;
        Characteristics.ResElec = characteristics.ResElec;
        Characteristics.ResFear = characteristics.ResFear;
        Characteristics.ResFire = characteristics.ResFire;
        Characteristics.ResLight = characteristics.ResLight;
        Characteristics.ResNether = characteristics.ResNether;
        Characteristics.ResNexus = characteristics.ResNexus;
        Characteristics.ResPois = characteristics.ResPois;
        Characteristics.ResShards = characteristics.ResShards;
        Characteristics.ResSound = characteristics.ResSound;
        Characteristics.Search = characteristics.Search;
        Characteristics.SeeInvis = characteristics.SeeInvis;
        Characteristics.ShElec = characteristics.ShElec;
        Characteristics.ShFire = characteristics.ShFire;
        Characteristics.ShowMods = characteristics.ShowMods;
        Characteristics.SlayAnimal = characteristics.SlayAnimal;
        Characteristics.SlayDemon = characteristics.SlayDemon;
        Characteristics.SlayDragon = characteristics.SlayDragon;
        Characteristics.SlayEvil = characteristics.SlayEvil;
        Characteristics.SlayGiant = characteristics.SlayGiant;
        Characteristics.SlayOrc = characteristics.SlayOrc;
        Characteristics.SlayTroll = characteristics.SlayTroll;
        Characteristics.SlayUndead = characteristics.SlayUndead;
        Characteristics.SlowDigest = characteristics.SlowDigest;
        Characteristics.Speed = characteristics.Speed;
        Characteristics.Stealth = characteristics.Stealth;
        Characteristics.Str = characteristics.Str;
        Characteristics.SustCha = characteristics.SustCha;
        Characteristics.SustCon = characteristics.SustCon;
        Characteristics.SustDex = characteristics.SustDex;
        Characteristics.SustInt = characteristics.SustInt;
        Characteristics.SustStr = characteristics.SustStr;
        Characteristics.SustWis = characteristics.SustWis;
        Characteristics.Telepathy = characteristics.Telepathy;
        Characteristics.Teleport = characteristics.Teleport;
        Characteristics.TreasureRating = characteristics.TreasureRating;
        Characteristics.Tunnel = characteristics.Tunnel;
        Characteristics.Vampiric = characteristics.Vampiric;
        Characteristics.Vorpal = characteristics.Vorpal;
        Characteristics.Wis = characteristics.Wis;
        Characteristics.Wraith = characteristics.Wraith;
        Characteristics.XtraMight = characteristics.XtraMight;
        Characteristics.XtraShots = characteristics.XtraShots;
    }

    public bool CreateRandomArtifact(bool fromScroll)
    {
        // Create a set of random artifact characteristics.
        RandomArtifactCharacteristics characteristics = new RandomArtifactCharacteristics();

        // Get the current item values.
        characteristics.Copy(this);

        _factory.CreateRandomArtifact(characteristics, fromScroll);

        Copy(characteristics);

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

    public void GetFixedArtifactResistances()
    {
        if (FixedArtifact != null)
        {
            FixedArtifact.ApplyResistances(this);
        }
    }

    private FixedArtifact? SelectCompatibleFixedArtifact()
    {
        if (Count != 1)
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