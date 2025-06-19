// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents different variations (ItemType) of item categories (ItemCategory).  E.g. different types of food that belong to the food category.  Several of the
/// properties are modifiable.
/// </summary>
[Serializable]
internal class ItemFactory : IGetKey
{
    protected readonly Game Game;
    protected virtual string? ItemEnhancementBindingKey { get; } = null;
    public ItemEnhancement ItemEnhancement { get; private set; }
    public virtual string Key { get; }
    public string GetKey => Key;
    #region Constructors
    public ItemFactory(Game game, ItemFactoryGameConfiguration itemFactoryGameConfiguration) 
    {
        Game = game;
        Key = itemFactoryGameConfiguration.Key ?? itemFactoryGameConfiguration.GetType().Name;
        ItemEnhancementBindingKey = itemFactoryGameConfiguration.ItemEnhancementBindingKey;

        PreassignedItemFlavorBindingKey = itemFactoryGameConfiguration.PreassignedItemFlavorBindingKey;
        NegativeBonusDamageRepresentsBroken = itemFactoryGameConfiguration.NegativeBonusDamageRepresentsBroken;
        NegativeBonusArmorClassRepresentsBroken = itemFactoryGameConfiguration.NegativeBonusArmorClassRepresentsBroken;
        NegativeBonusHitRepresentsBroken = itemFactoryGameConfiguration.NegativeBonusHitRepresentsBroken;
        SlayingRandomArtifactItemEnhancementWeightedRandomBindingKey = itemFactoryGameConfiguration.SlayingRandomArtifactItemEnhancementWeightedRandomBindingKey;
        RandomArtifactBonusArmorCeiling = itemFactoryGameConfiguration.RandomArtifactBonusArmorCeiling;
        RandomArtifactBonusHitCeiling = itemFactoryGameConfiguration.RandomArtifactBonusHitCeiling;
        RandomArtifactBonusDamageCeiling = itemFactoryGameConfiguration.RandomArtifactBonusDamageCeiling;
        RefillScriptBindingKey = itemFactoryGameConfiguration.RefillScriptBindingKey;
        SymbolBindingKey = itemFactoryGameConfiguration.SymbolBindingKey;
        CanBeWeaponOfLaw = itemFactoryGameConfiguration.CanBeWeaponOfLaw;
        CanBeWeaponOfSharpness = itemFactoryGameConfiguration.CanBeWeaponOfSharpness;
        CapableOfVorpalSlaying = itemFactoryGameConfiguration.CapableOfVorpalSlaying;
        Color = itemFactoryGameConfiguration.Color;
        UseBindingTuple = itemFactoryGameConfiguration.UseBindingTuple;
        QuaffBindingTuple = itemFactoryGameConfiguration.QuaffBindingTuple;
        AmmunitionItemFactoryBindingKeys = itemFactoryGameConfiguration.AmmunitionItemFactoryBindingKeys;
        CanSpikeDoorClosed = itemFactoryGameConfiguration.CanSpikeDoorClosed;
        CanTunnel = itemFactoryGameConfiguration.CanTunnel;
        CanProjectArrows = itemFactoryGameConfiguration.CanProjectArrows;
        EnchantmentMaximumCount = itemFactoryGameConfiguration.EnchantmentMaximumCount;
        IsMagical = itemFactoryGameConfiguration.IsMagical;
        ValuePerTurnOfLight = itemFactoryGameConfiguration.ValuePerTurnOfLight;
        AimingBindingTuple = itemFactoryGameConfiguration.AimingBindingTuple;
        IsBroken = itemFactoryGameConfiguration.IsBroken;
        InitialBrokenStomp = itemFactoryGameConfiguration.InitialBrokenStomp;
        InitialAverageStomp = itemFactoryGameConfiguration.InitialAverageStomp;
        InitialGoodStomp = itemFactoryGameConfiguration.InitialGoodStomp;
        InitialExcellentStomp = itemFactoryGameConfiguration.InitialExcellentStomp;
        RechargeScriptBindingKey = itemFactoryGameConfiguration.RechargeScriptBindingKey;
        IsIgnoredByMonsters = itemFactoryGameConfiguration.IsIgnoredByMonsters;
        IsContainer = itemFactoryGameConfiguration.IsContainer;
        IsRangedWeapon = itemFactoryGameConfiguration.IsRangedWeapon;
        MissileDamageMultiplier = itemFactoryGameConfiguration.MissileDamageMultiplier;
        MaxPhlogiston = itemFactoryGameConfiguration.MaxPhlogiston;
        BurnRate = itemFactoryGameConfiguration.BurnRate;
        MassProduceBindingTuples = itemFactoryGameConfiguration.MassProduceBindingTuples;
        BonusHitRealValueMultiplier = itemFactoryGameConfiguration.BonusHitRealValueMultiplier;
        BonusDamageRealValueMultiplier = itemFactoryGameConfiguration.BonusDamageRealValueMultiplier;
        BonusArmorClassRealValueMultiplier = itemFactoryGameConfiguration.BonusArmorClassRealValueMultiplier;
        BonusDiceRealValueMultiplier = itemFactoryGameConfiguration.BonusDiceRealValueMultiplier;
        BreaksDuringEnchantmentProbabilityExpression = itemFactoryGameConfiguration.BreaksDuringEnchantmentProbabilityExpression;
        EnchantmentBindingTuples = itemFactoryGameConfiguration.EnchantmentBindingTuples;
        EatMagicScriptBindingKey = itemFactoryGameConfiguration.EatMagicScriptBindingKey;
        GridProcessWorldScriptBindingKey = itemFactoryGameConfiguration.GridProcessWorldScriptBindingKey;
        MonsterProcessWorldScriptBindingKey = itemFactoryGameConfiguration.MonsterProcessWorldScriptBindingKey;
        EquipmentProcessWorldScriptBindingKey = itemFactoryGameConfiguration.EquipmentProcessWorldScriptBindingKey;
        PackProcessWorldScriptBindingKey = itemFactoryGameConfiguration.PackProcessWorldScriptBindingKey;
        CanApplyBonusArmorClassMiscPower = itemFactoryGameConfiguration.CanApplyBonusArmorClassMiscPower;
        CanApplyBlowsBonus = itemFactoryGameConfiguration.CanApplyBlowsBonus;
        BreakageChanceProbabilityExpression = itemFactoryGameConfiguration.BreakageChanceProbabilityExpression;
        MakeObjectCountExpression = itemFactoryGameConfiguration.MakeObjectCountExpression;
        GetsDamageMultiplier = itemFactoryGameConfiguration.GetsDamageMultiplier;
        IdentityCanBeSensed = itemFactoryGameConfiguration.IdentityCanBeSensed;
        IsFuelForTorch = itemFactoryGameConfiguration.IsFuelForTorch;
        IsWearableOrWieldable = itemFactoryGameConfiguration.IsWearableOrWieldable;
        CanBeEaten = itemFactoryGameConfiguration.CanBeEaten;
        IsArmor = itemFactoryGameConfiguration.IsArmor;
        IsWeapon = itemFactoryGameConfiguration.IsWeapon;
        NumberOfItemsContained = itemFactoryGameConfiguration.NumberOfItemsContained;
        Name = itemFactoryGameConfiguration.Name;
        DescriptionSyntax = itemFactoryGameConfiguration.DescriptionSyntax;
        AlternateDescriptionSyntax = itemFactoryGameConfiguration.AlternateDescriptionSyntax;
        FlavorSuppressedDescriptionSyntax = itemFactoryGameConfiguration.FlavorSuppressedDescriptionSyntax;
        AlternateFlavorSuppressedDescriptionSyntax = itemFactoryGameConfiguration.AlternateFlavorSuppressedDescriptionSyntax;
        FlavorUnknownDescriptionSyntax = itemFactoryGameConfiguration.FlavorUnknownDescriptionSyntax;
        AlternateFlavorUnknownDescriptionSyntax = itemFactoryGameConfiguration.AlternateFlavorUnknownDescriptionSyntax;
        ZapBindingTuple = itemFactoryGameConfiguration.ZapBindingTuple;
        ItemClassBindingKey = itemFactoryGameConfiguration.ItemClassBindingKey;
        IsLanternFuel = itemFactoryGameConfiguration.IsLanternFuel;
        PackSort = itemFactoryGameConfiguration.PackSort;
        WieldSlotBindingKeys = itemFactoryGameConfiguration.WieldSlotBindingKeys;
        AskDestroyAll = itemFactoryGameConfiguration.AskDestroyAll;
        HasQualityRatings = itemFactoryGameConfiguration.HasQualityRatings;
        ArmorClass = itemFactoryGameConfiguration.ArmorClass;
        DepthsFoundAndChances = itemFactoryGameConfiguration.DepthsFoundAndChances;
        Cost = itemFactoryGameConfiguration.Cost;
        DamageDice = itemFactoryGameConfiguration.DamageDice;
        DamageSides = itemFactoryGameConfiguration.DamageSides;
        LevelNormallyFound = itemFactoryGameConfiguration.LevelNormallyFound;
        InitialBonusAttacks = itemFactoryGameConfiguration.InitialBonusAttacks;
        InitialBonusInfravision = itemFactoryGameConfiguration.InitialBonusInfravision;
        InitialBonusSpeed = itemFactoryGameConfiguration.InitialBonusSpeed;
        InitialBonusSearchExpression = itemFactoryGameConfiguration.InitialBonusSearchExpression;
        InitialBonusStealthExpression = itemFactoryGameConfiguration.InitialBonusStealthExpression;
        InitialBonusTunnel = itemFactoryGameConfiguration.InitialBonusTunnel;
        InitialTurnsOfLight = itemFactoryGameConfiguration.InitialTurnsOfLight;
        InitialNutritionalValue = itemFactoryGameConfiguration.InitialNutritionalValue;
        InitialGoldPiecesRollExpression = itemFactoryGameConfiguration.InitialGoldPiecesRollExpression;
        ExperienceGainDivisorForDestroying = itemFactoryGameConfiguration.ExperienceGainDivisorForDestroying;
        SpellBindingKeys = itemFactoryGameConfiguration.SpellBindingKeys;
        BonusArmorClass = itemFactoryGameConfiguration.BonusArmorClass;
        BonusDamage = itemFactoryGameConfiguration.BonusDamage;
        BonusHit = itemFactoryGameConfiguration.BonusHit;
        Weight = itemFactoryGameConfiguration.Weight;
        IsSmall = itemFactoryGameConfiguration.IsSmall;
        CanApplySlayingBonus = itemFactoryGameConfiguration.CanApplySlayingBonus;
        BaseValue = itemFactoryGameConfiguration.BaseValue;
        HatesElectricity = itemFactoryGameConfiguration.HatesElectricity;
        HatesFire = itemFactoryGameConfiguration.HatesFire;
        HatesAcid = itemFactoryGameConfiguration.HatesAcid;
        HatesCold = itemFactoryGameConfiguration.HatesCold;
        CanProvideSheathOfElectricity = itemFactoryGameConfiguration.CanProvideSheathOfElectricity;
        CanProvideSheathOfFire = itemFactoryGameConfiguration.CanProvideSheathOfFire;
        CanReflectBoltsAndArrows = itemFactoryGameConfiguration.CanReflectBoltsAndArrows;
        RandartActivationChance = itemFactoryGameConfiguration.RandartActivationChance;
        ProvidesSunlight = itemFactoryGameConfiguration.ProvidesSunlight;
        CanApplyArtifactBiasSlaying = itemFactoryGameConfiguration.CanApplyArtifactBiasSlaying;
        CanApplyArtifactBiasResistance = itemFactoryGameConfiguration.CanApplyArtifactBiasResistance;
        CanApplyBlessedArtifactBias = itemFactoryGameConfiguration.CanApplyBlessedArtifactBias;
        CanBeEatenByMonsters = itemFactoryGameConfiguration.CanBeEatenByMonsters;
        EatScriptBindingKey = itemFactoryGameConfiguration.EatScriptBindingKey;
        VanishesWhenEatenBySkeletons = itemFactoryGameConfiguration.VanishesWhenEatenBySkeletons;
        IsConsumedWhenEaten = itemFactoryGameConfiguration.IsConsumedWhenEaten;
        ReadBindingTuple = itemFactoryGameConfiguration.ReadBindingTuple;
    }
    #endregion

    #region State Data - Read/write fields.
    /// <summary>
    /// Returns true, if the flavor for the factory has been identified or the factory doesn't use flavors; false, when the factory uses flavors and
    /// the flavor still hasn't been identified by the player.  The <see cref="Game.IllegibleFlavorInit"/> method is used to re-initialize this variable.  Stores may produce items from this
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
    /// Returns the the <see cref="ItemFlavor"/> that this item should be assigned.  This assignment overrides the random flavor assignment, when the <see cref="ItemClass"/>
    /// utilizes item flavors.  Returns null, to allow the <see cref="ItemClass"/> to assign a random <see cref="ItemFlavor"/> or when this factory doesn't produce flavored items.
    /// This property is bound using the <see cref="PreassignedItemFlavorBindingKey"/> property during the binding phase.
    /// </summary>
    public Flavor? PreassignedItemFlavor { get; private set; }

    /// <summary>
    /// Returns the flavor that was issued to the item factory.
    /// </summary>
    public Flavor? Flavor { get; set; }

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

    /// <summary>
    /// Returns the index of the book as it pertains to the realm.
    /// </summary>
    public int BookIndex { get; private set; } // TODO: Can this be done during binding?

    /// <summary>
    /// Returns the singleton realm that this book factory belongs to.  This is needed because realms define books--books do not define what realm they belong to.
    /// For this reason, the Realm the book belongs to is set at run-time.
    /// </summary>
    public Realm Realm { get; private set; } // TODO: Can this be done during binding?
    #endregion

    #region Concrete Methods and Properties (Non-abstract and non-virtual) - API Object Functionality
    public string ToJson()
    {
        ItemFactoryGameConfiguration itemFactoryGameConfiguration = new ItemFactoryGameConfiguration()
        {
            Key = Key,           
            ItemEnhancementBindingKey = ItemEnhancementBindingKey,
            PreassignedItemFlavorBindingKey = PreassignedItemFlavorBindingKey,
            NegativeBonusDamageRepresentsBroken = NegativeBonusDamageRepresentsBroken,
            NegativeBonusArmorClassRepresentsBroken = NegativeBonusArmorClassRepresentsBroken,
            NegativeBonusHitRepresentsBroken = NegativeBonusHitRepresentsBroken,
            SlayingRandomArtifactItemEnhancementWeightedRandomBindingKey = SlayingRandomArtifactItemEnhancementWeightedRandomBindingKey,
            RandomArtifactBonusArmorCeiling = RandomArtifactBonusArmorCeiling,
            RandomArtifactBonusHitCeiling = RandomArtifactBonusHitCeiling,
            RandomArtifactBonusDamageCeiling = RandomArtifactBonusDamageCeiling,
            RefillScriptBindingKey = RefillScriptBindingKey,
            SymbolBindingKey = SymbolBindingKey,
            CanBeWeaponOfLaw = CanBeWeaponOfLaw,
            CanBeWeaponOfSharpness = CanBeWeaponOfSharpness,
            CapableOfVorpalSlaying = CapableOfVorpalSlaying,
            Color = Color,
            UseBindingTuple = UseBindingTuple,
            QuaffBindingTuple = QuaffBindingTuple,
            AmmunitionItemFactoryBindingKeys = AmmunitionItemFactoryBindingKeys,
            CanSpikeDoorClosed = CanSpikeDoorClosed,
            CanTunnel = CanTunnel,
            CanProjectArrows = CanProjectArrows,
            EnchantmentMaximumCount = EnchantmentMaximumCount,
            IsMagical = IsMagical,
            ValuePerTurnOfLight = ValuePerTurnOfLight,
            AimingBindingTuple = AimingBindingTuple,
            IsBroken = IsBroken,
            InitialBrokenStomp = InitialBrokenStomp,
            InitialAverageStomp = InitialAverageStomp,
            InitialGoodStomp = InitialGoodStomp,
            InitialExcellentStomp = InitialExcellentStomp,
            RechargeScriptBindingKey = RechargeScriptBindingKey,
            IsIgnoredByMonsters = IsIgnoredByMonsters,
            IsContainer = IsContainer,
            IsRangedWeapon = IsRangedWeapon,
            MissileDamageMultiplier = MissileDamageMultiplier,
            MaxPhlogiston = MaxPhlogiston,
            BurnRate = BurnRate,
            MassProduceBindingTuples = MassProduceBindingTuples,
            BonusHitRealValueMultiplier = BonusHitRealValueMultiplier,
            BonusDamageRealValueMultiplier = BonusDamageRealValueMultiplier,
            BonusArmorClassRealValueMultiplier = BonusArmorClassRealValueMultiplier,
            BonusDiceRealValueMultiplier = BonusDiceRealValueMultiplier,
            BreaksDuringEnchantmentProbabilityExpression = BreaksDuringEnchantmentProbabilityExpression,
            EnchantmentBindingTuples = EnchantmentBindingTuples,
            EatMagicScriptBindingKey = EatMagicScriptBindingKey,
            GridProcessWorldScriptBindingKey = GridProcessWorldScriptBindingKey,
            MonsterProcessWorldScriptBindingKey = MonsterProcessWorldScriptBindingKey,
            EquipmentProcessWorldScriptBindingKey = EquipmentProcessWorldScriptBindingKey,
            PackProcessWorldScriptBindingKey = PackProcessWorldScriptBindingKey,
            CanApplyBonusArmorClassMiscPower = CanApplyBonusArmorClassMiscPower,
            CanApplyBlowsBonus = CanApplyBlowsBonus,
            BreakageChanceProbabilityExpression = BreakageChanceProbabilityExpression,
            MakeObjectCountExpression = MakeObjectCountExpression,
            GetsDamageMultiplier = GetsDamageMultiplier,
            IdentityCanBeSensed = IdentityCanBeSensed,
            IsFuelForTorch = IsFuelForTorch,
            IsWearableOrWieldable = IsWearableOrWieldable,
            CanBeEaten = CanBeEaten,
            IsArmor = IsArmor,
            IsWeapon = IsWeapon,
            NumberOfItemsContained = NumberOfItemsContained,
            Name = Name,
            DescriptionSyntax = DescriptionSyntax,
            AlternateDescriptionSyntax = AlternateDescriptionSyntax,
            FlavorSuppressedDescriptionSyntax = FlavorSuppressedDescriptionSyntax,
            AlternateFlavorSuppressedDescriptionSyntax = AlternateFlavorSuppressedDescriptionSyntax,
            FlavorUnknownDescriptionSyntax = FlavorUnknownDescriptionSyntax,
            AlternateFlavorUnknownDescriptionSyntax = AlternateFlavorUnknownDescriptionSyntax,
            ZapBindingTuple = ZapBindingTuple,
            ItemClassBindingKey = ItemClassBindingKey,
            IsLanternFuel = IsLanternFuel,
            PackSort = PackSort,
            WieldSlotBindingKeys = WieldSlotBindingKeys,
            AskDestroyAll = AskDestroyAll,
            HasQualityRatings = HasQualityRatings,
            ArmorClass = ArmorClass,
            DepthsFoundAndChances = DepthsFoundAndChances,
            Cost = Cost,
            DamageDice = DamageDice,
            DamageSides = DamageSides,
            LevelNormallyFound = LevelNormallyFound,
            InitialBonusAttacks = InitialBonusAttacks,
            InitialBonusInfravision = InitialBonusInfravision,
            InitialBonusSpeed = InitialBonusSpeed,
            InitialBonusSearchExpression = InitialBonusSearchExpression,
            InitialBonusStealthExpression = InitialBonusStealthExpression,
            InitialBonusTunnel = InitialBonusTunnel,
            InitialTurnsOfLight = InitialTurnsOfLight,
            InitialNutritionalValue = InitialNutritionalValue,
            InitialGoldPiecesRollExpression = InitialGoldPiecesRollExpression,
            ExperienceGainDivisorForDestroying = ExperienceGainDivisorForDestroying,
            SpellBindingKeys = SpellBindingKeys,
            BonusArmorClass = BonusArmorClass,
            BonusDamage = BonusDamage,
            BonusHit = BonusHit,
            Weight = Weight,
            IsSmall = IsSmall,
            CanApplySlayingBonus = CanApplySlayingBonus,
            BaseValue = BaseValue,
            HatesElectricity = HatesElectricity,
            HatesFire = HatesFire,
            HatesAcid = HatesAcid,
            HatesCold = HatesCold,
            CanProvideSheathOfElectricity = CanProvideSheathOfElectricity,
            CanProvideSheathOfFire = CanProvideSheathOfFire,
            CanReflectBoltsAndArrows = CanReflectBoltsAndArrows,
            RandartActivationChance = RandartActivationChance,
            ProvidesSunlight = ProvidesSunlight,
            CanApplyArtifactBiasSlaying = CanApplyArtifactBiasSlaying,
            CanApplyArtifactBiasResistance = CanApplyArtifactBiasResistance,
            CanApplyBlessedArtifactBias = CanApplyBlessedArtifactBias,
            CanBeEatenByMonsters = CanBeEatenByMonsters,
            EatScriptBindingKey = EatScriptBindingKey,
            VanishesWhenEatenBySkeletons = VanishesWhenEatenBySkeletons,
            IsConsumedWhenEaten = IsConsumedWhenEaten,
            ReadBindingTuple = ReadBindingTuple,
        };
        return JsonSerializer.Serialize(itemFactoryGameConfiguration, Game.GetJsonSerializerOptions());
    }

    public Item GenerateItem()
    {
        return new Item(Game, this);
    }

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

    /// <summary>
    /// Sets the index of the book in the realm.  This is done when the realm binds the books.
    /// </summary>
    /// <param name="realm"></param>
    /// <param name="bookIndex"></param>
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

    public void Bind()
    {
        // TODO: We require an object but not from the game config
        ItemEnhancement? nullableItemEnhancement = Game.SingletonRepository.GetNullable<ItemEnhancement>(ItemEnhancementBindingKey);
        ItemEnhancement = nullableItemEnhancement ?? new ItemEnhancement(Game);

        Symbol = Game.SingletonRepository.Get<Symbol>(SymbolBindingKey);
        ItemClass = Game.SingletonRepository.Get<ItemClass>(ItemClassBindingKey);
        FlavorSymbol = Symbol;
        FlavorColor = Color;

        MakeObjectCount = Game.ParseNumericExpression(MakeObjectCountExpression);
        WieldSlots = Game.SingletonRepository.Get<WieldSlot>(WieldSlotBindingKeys);

        InitialBonusSearch = Game.ParseNumericExpression(InitialBonusSearchExpression);
        InitialBonusStealth = Game.ParseNumericExpression(InitialBonusStealthExpression);

        // Bind the MassProduceTuples
        if (MassProduceBindingTuples != null)
        {
            List<(int, Expression)> massProduceTuplesList = new List<(int, Expression)>();
            foreach ((int cost, string rollExpression) in MassProduceBindingTuples)
            {
                Expression rollResult = Game.ParseNumericExpression(rollExpression);
                (int, Expression) newTuple = (cost, rollResult);
                massProduceTuplesList.Add(newTuple);
            }
            MassProduceTuples = massProduceTuplesList.ToArray();

            // Validate the MassProduceTuples sorting.
            if (!Game.ValidateTupleSorting<(int cost, Expression expression)>(MassProduceTuples, (a, b) => a.cost < b.cost))
            {
                throw new Exception($"The MassProduceTupleNames specified for the {GetType().Name} are not sorted in ascending order by cost.");
            }
        }

        InitialGoldPiecesRoll = Game.ParseNumericExpression(InitialGoldPiecesRollExpression);
        EatScript = Game.SingletonRepository.GetNullable<IEatOrQuaffScript>(EatScriptBindingKey);

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
            IAimWandScript identifableDirectionalScript = Game.SingletonRepository.Get<IAimWandScript>(AimingBindingTuple.Value.ActivationScriptName);
            Expression initialChargeCountRoll = Game.ParseNumericExpression(AimingBindingTuple.Value.InitialChargesCountRollExpression);
            int perChargeValue = AimingBindingTuple.Value.PerChargeValue;
            int manaValue = AimingBindingTuple.Value.ManaValue;
            AimingTuple = (identifableDirectionalScript, initialChargeCountRoll, perChargeValue, manaValue);
        }

        if (ReadBindingTuple != null)
        {
            IReadScrollOrUseStaffScript identifableAndUsedScript = Game.SingletonRepository.Get<IReadScrollOrUseStaffScript>(ReadBindingTuple.Value.ScriptName);
            int manaValue = ReadBindingTuple.Value.ManaValue;
            ReadTuple = (identifableAndUsedScript, manaValue);
        }

        RechargeScript = Game.SingletonRepository.GetNullable<IScriptItemInt>(RechargeScriptBindingKey);
        GridProcessWorldScript = Game.SingletonRepository.GetNullable<IScriptItemGridTile>(GridProcessWorldScriptBindingKey);
        MonsterProcessWorldScript = Game.SingletonRepository.GetNullable<IScriptItemMonster>(MonsterProcessWorldScriptBindingKey);
        EquipmentProcessWorldScript = Game.SingletonRepository.GetNullable<IScriptItem>(EquipmentProcessWorldScriptBindingKey);
        PackProcessWorldScript = Game.SingletonRepository.GetNullable<IScriptItem>(PackProcessWorldScriptBindingKey);

        EatMagicScript = Game.SingletonRepository.GetNullable<IScriptItem>(EatMagicScriptBindingKey);

        if (ZapBindingTuple != null)
        {
            IZapRodScript identifiedAndUsedScriptItemDirection = Game.SingletonRepository.Get<IZapRodScript>(ZapBindingTuple.Value.ScriptName);
            Expression roll = Game.ParseNumericExpression(ZapBindingTuple.Value.TurnsToRecharge);
            bool requiresAiming = ZapBindingTuple.Value.RequiresAiming;
            int manaEquivalent = ZapBindingTuple.Value.ManaEquivalent;
            ZapTuple = (identifiedAndUsedScriptItemDirection, roll, requiresAiming, manaEquivalent);
        }

        AmmunitionItemFactories = Game.SingletonRepository.GetNullable<ItemFactory>(AmmunitionItemFactoryBindingKeys);

        if (QuaffBindingTuple != null)
        {
            IEatOrQuaffScript quaffNoticeableScript = Game.SingletonRepository.Get<IEatOrQuaffScript>(QuaffBindingTuple.Value.QuaffScriptName);
            ProjectileScript? smashUnfriendlyScript = Game.SingletonRepository.GetNullable<ProjectileScript>(QuaffBindingTuple.Value.SmashScriptName);
            int manaEquivalent = QuaffBindingTuple.Value.ManaEquivalent;
            QuaffTuple = (quaffNoticeableScript, smashUnfriendlyScript, manaEquivalent);
        }

        if (UseBindingTuple != null)
        {
            IReadScrollOrUseStaffScript useScript = Game.SingletonRepository.Get<IReadScrollOrUseStaffScript>(UseBindingTuple.Value.UseScriptBindingKey);
            Expression initialChargeRoll = Game.ParseNumericExpression(UseBindingTuple.Value.InitialChargesRollExpression);
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
        BreakageChanceProbability = Game.ParseProbabilityExpression(BreakageChanceProbabilityExpression);
        SlayingRandomArtifactItemEnhancementWeightedRandom = Game.SingletonRepository.GetNullable<ItemEnhancementWeightedRandom>(SlayingRandomArtifactItemEnhancementWeightedRandomBindingKey);
        PreassignedItemFlavor = Game.SingletonRepository.GetNullable<ItemFlavor>(PreassignedItemFlavorBindingKey);
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
            foreach ((int cost, Expression expression) in MassProduceTuples)
            {
                if (itemCost <= cost)
                {
                    IntegerExpression result = Game.ComputeIntegerExpression(expression);
                    return result.Value;
                }
            }
        }
        return 0;
    }

    /// <summary>
    /// Returns an additional description of the item that is appended to the base description, when needed.  Returns string.empty by default.
    /// </summary>
    /// <returns></returns>
    public string GetDetailedDescription(Item item)
    {
        RoItemPropertySet effectiveItemProperties = item.GetEffectiveItemProperties();
        string s = "";
        if (IsRangedWeapon)
        {
            int power = MissileDamageMultiplier;
            if (effectiveItemProperties.XtraMight)
            {
                power++;
            }
            s += $" (x{power})";

            if (item.IsKnown())
            {
                s += $" ({GetSignedValue(item.EnchantmentItemProperties.BonusHit)},{GetSignedValue(item.EnchantmentItemProperties.BonusDamage)})";

                if (item.ArmorClass != 0)
                {
                    // Add base armor class for all types of armor and when the base armor class is greater than zero.
                    s += $" [{item.ArmorClass},{GetSignedValue(item.EnchantmentItemProperties.BonusArmorClass)}]";
                }
                else if (item.EnchantmentItemProperties.BonusArmorClass != 0)
                {
                    // This is not armor, only show bonus armor class, if it is not zero and we know about it.
                    s += $" [{GetSignedValue(item.EnchantmentItemProperties.BonusArmorClass)}]";
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
                s += $" ({GetSignedValue(item.EnchantmentItemProperties.BonusHit)},{GetSignedValue(item.EnchantmentItemProperties.BonusDamage)})";

                if (item.ArmorClass != 0)
                {
                    // Add base armor class for all types of armor and when the base armor class is greater than zero.
                    s += $" [{item.ArmorClass},{GetSignedValue(item.EnchantmentItemProperties.BonusArmorClass)}]";
                }
                else if (item.EnchantmentItemProperties.BonusArmorClass != 0)
                {
                    // This is not armor, only show bonus armor class, if it is not zero and we know about it.
                    s += $" [{GetSignedValue(item.EnchantmentItemProperties.BonusArmorClass)}]";
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
                if (effectiveItemProperties.ShowMods || item.EnchantmentItemProperties.BonusHit != 0 && item.EnchantmentItemProperties.BonusDamage != 0)
                {
                    s += $" ({GetSignedValue(item.EnchantmentItemProperties.BonusHit)},{GetSignedValue(item.EnchantmentItemProperties.BonusDamage)})";
                }
                else if (item.EnchantmentItemProperties.BonusHit != 0)
                {
                    s += $" ({GetSignedValue(item.EnchantmentItemProperties.BonusHit)})";
                }
                else if (item.EnchantmentItemProperties.BonusDamage != 0)
                {
                    s += $" ({GetSignedValue(item.EnchantmentItemProperties.BonusDamage)})";
                }

                // Add base armor class for all types of armor and when the base armor class is greater than zero.
                s += $" [{item.ArmorClass},{GetSignedValue(item.EnchantmentItemProperties.BonusArmorClass)}]";
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
                if (effectiveItemProperties.ShowMods || item.EnchantmentItemProperties.BonusHit != 0 && item.EnchantmentItemProperties.BonusDamage != 0)
                {
                    s += $" ({GetSignedValue(item.EnchantmentItemProperties.BonusHit)},{GetSignedValue(item.EnchantmentItemProperties.BonusDamage)})";
                }
                else if (item.EnchantmentItemProperties.BonusHit != 0)
                {
                    s += $" ({GetSignedValue(item.EnchantmentItemProperties.BonusHit)})";
                }
                else if (item.EnchantmentItemProperties.BonusDamage != 0)
                {
                    s += $" ({GetSignedValue(item.EnchantmentItemProperties.BonusDamage)})";
                }

                if (item.ArmorClass != 0)
                {
                    // Add base armor class for all types of armor and when the base armor class is greater than zero.
                    s += $" [{item.ArmorClass},{GetSignedValue(item.EnchantmentItemProperties.BonusArmorClass)}]";
                }
                else if (item.EnchantmentItemProperties.BonusArmorClass != 0)
                {
                    // This is not armor, only show bonus armor class, if it is not zero and we know about it.
                    s += $" [{GetSignedValue(item.EnchantmentItemProperties.BonusArmorClass)}]";
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
        RoItemPropertySet effectiveItemProperties = item.GetEffectiveItemProperties();

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
                if (!effectiveItemProperties.HideType && commonBonusValue.Value.priorityBonusName != "")
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
        if (item.EnchantmentItemProperties.BonusSpeed != 0)
        {
            if (value.HasValue && item.EnchantmentItemProperties.BonusSpeed != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EnchantmentItemProperties.BonusSpeed, "speed");
        }
        if (item.EnchantmentItemProperties.BonusAttacks != 0)
        {
            if (value.HasValue && item.EnchantmentItemProperties.BonusAttacks != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EnchantmentItemProperties.BonusAttacks, item.EnchantmentItemProperties.BonusAttacks > 1 ? "attacks" : "attack");
        }
        if (item.EnchantmentItemProperties.BonusStealth != 0)
        {
            if (value.HasValue && item.EnchantmentItemProperties.BonusStealth != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EnchantmentItemProperties.BonusStealth, "stealth");
        }
        if (item.EnchantmentItemProperties.BonusSearch != 0)
        {
            if (value.HasValue && item.EnchantmentItemProperties.BonusSearch != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EnchantmentItemProperties.BonusSearch, "searching");
        }
        if (item.EnchantmentItemProperties.BonusInfravision != 0)
        {
            if (value.HasValue && item.EnchantmentItemProperties.BonusInfravision != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EnchantmentItemProperties.BonusInfravision, "infravision");
        }
        if (item.EnchantmentItemProperties.BonusCharisma != 0)
        {
            if (value.HasValue && item.EnchantmentItemProperties.BonusCharisma != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EnchantmentItemProperties.BonusCharisma, "");
        }
        if (item.EnchantmentItemProperties.BonusConstitution != 0)
        {
            if (value.HasValue && item.EnchantmentItemProperties.BonusConstitution != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EnchantmentItemProperties.BonusConstitution, "");
        }
        if (item.EnchantmentItemProperties.BonusDexterity != 0)
        {
            if (value.HasValue && item.EnchantmentItemProperties.BonusDexterity != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EnchantmentItemProperties.BonusDexterity, "");
        }
        if (item.EnchantmentItemProperties.BonusIntelligence != 0)
        {
            if (value.HasValue && item.EnchantmentItemProperties.BonusIntelligence != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EnchantmentItemProperties.BonusIntelligence, "");
        }
        if (item.EnchantmentItemProperties.BonusStrength != 0)
        {
            if (value.HasValue && item.EnchantmentItemProperties.BonusStrength != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EnchantmentItemProperties.BonusStrength, "");
        }
        if (item.EnchantmentItemProperties.BonusWisdom != 0)
        {
            if (value.HasValue && item.EnchantmentItemProperties.BonusWisdom != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EnchantmentItemProperties.BonusWisdom, "");
        }
        if (item.EnchantmentItemProperties.BonusTunnel != 0)
        {
            if (value.HasValue && item.EnchantmentItemProperties.BonusTunnel != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EnchantmentItemProperties.BonusTunnel, "");
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
        int bonusValue = item.EnchantmentItemProperties.BonusHit * BonusHitRealValueMultiplier + item.EnchantmentItemProperties.BonusArmorClass * BonusArmorClassRealValueMultiplier + item.EnchantmentItemProperties.BonusDamage * BonusDamageRealValueMultiplier;
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
        RoItemPropertySet mergedCharacteristics = item.GetEffectiveItemProperties();
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
        string pluralizedName = ApplyPlurizationMacro(descriptionSyntax, item.StackCount);

        if (!includeCountPrefix)
        {
            return pluralizedName;
        }

        if (item.StackCount <= 0)
        {
            return $"no more {pluralizedName}";
        }
        else if (item.StackCount > 1)
        {
            return $"{item.StackCount} {pluralizedName}";
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
    public bool CanBeRead => ReadTuple != null;

    public void CreateRandomArtifact(RwItemPropertySet characteristics, bool fromScroll)
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

        void ApplyRandomBonuses(RwItemPropertySet characteristics)
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

        void CurseRandart(RwItemPropertySet characteristics)
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
            if (Game.BaseCharacterClass.ID != CharacterClassEnum.Warrior && Game.DieRoll(3) == 1)
            {
                characteristics.NoMagic = true;
            }
            characteristics.IsCursed = true;
        }

        void ApplyMiscPowerForRandomArtifactCreation(RwItemPropertySet characteristics)
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
                        WeightedRandom<ItemEnhancement> itemAdditiveBundleWeightedRandom = new WeightedRandom<ItemEnhancement>(Game);
                        itemAdditiveBundleWeightedRandom.Add(1 * 48, Game.SingletonRepository.Get<ItemEnhancement>(nameof(AcidImmunityAndAcidArtifactBiasItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(1 * 48, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ElectricityImmunityItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(1 * 48, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ColdImmunityItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(1 * 48, Game.SingletonRepository.Get<ItemEnhancement>(nameof(FireImmunityItemEnhancement)));

                        itemAdditiveBundleWeightedRandom.Add(3 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistAcidAndAcidBiasItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(3 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistElectricityAndElectricityBiasItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(3 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistFireAndFireBiasItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(3 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistColdAndColdBiasItemEnhancement)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 36 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistPoisonAndPoisonBiasItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 6 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistPoisonAndNecromanticBiasItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 3 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistPoisonAndRogueBiasItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 3, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistPoisonItemEnhancement)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 16 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistFearAndWarriorBiasItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 32 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistFearItemEnhancement)));

                        itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistLightItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistDarknessItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistBlindnessItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistBlindnessItemEnhancement)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 8 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistConfusionAndChaosBiasItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 40 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistConfusionItemEnhancement)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistSoundItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistShardsItemEnhancement)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 16 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistNetherAndNecromanticBiasItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 32 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistNetherItemEnhancement)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistNexusItemEnhancement)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 24 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistChaosAndChaosBiasItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 24 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistChaosItemEnhancement)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistDisenchantItemEnhancement)));

                        if (characteristics.CanProvideSheathOfElectricity)
                        {
                            itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(SheathOfElectricityAndElectricityBiasItemEnhancement)));
                        }

                        if (characteristics.CanProvideSheathOfFire)
                        {
                            itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(SheathOfFireAndFireBiasItemEnhancement)));
                        }

                        if (characteristics.CanReflectBoltsAndArrows)
                        {
                            itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ReflectBoltsAndArrowsItemEnhancement)));
                        }

                        ItemEnhancement? itemAdditiveBundle = itemAdditiveBundleWeightedRandom.ChooseOrDefault();
                        if (itemAdditiveBundle != null)
                        {
                            characteristics = characteristics.Merge(itemAdditiveBundle.GenerateItemCharacteristics());
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

    public void ApplySlayingForRandomArtifactCreation(RwItemPropertySet characteristics)
    {
        if (characteristics.ArtifactBias != null)
        {
            if (characteristics.ArtifactBias.ApplySlaying(characteristics))
            {
                return;
            }
        }

        // Choose a slaying item enhancement.  If the item enhancement doesn't apply to this item factory, choose another.
        ItemEnhancement? slayingItemEnhancement = null;
        do
        {
            slayingItemEnhancement = SlayingRandomArtifactItemEnhancementWeightedRandom?.ChooseOrDefault();
        } while (slayingItemEnhancement != null && !slayingItemEnhancement.AppliesTo(this));

        // Apply the item enhancement.  This supports a null choice.
        characteristics.Merge(slayingItemEnhancement?.GenerateItemCharacteristics());
    }
    #endregion

    #region Bound Concrete Properties - API Object Functionality - Set during Bind() - get; private set;
    public Expression InitialBonusSearch { get; private set; }
    public Expression InitialBonusStealth { get; private set; }

    /// <summary>
    /// Returns a count for the number of items to create during the MakeObject.  Returns 1, by default.  Spikes, shots, arrows and bolts return values greater than 1.
    /// </summary>
    public Expression MakeObjectCount { get; private set; }

    public ItemEnhancementWeightedRandom? SlayingRandomArtifactItemEnhancementWeightedRandom { get; private set; }

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
    public (IReadScrollOrUseStaffScript UseScript, Expression InitialCharges, int PerChargeValue, int ManaEquivalent)? UseTuple { get; private set; } = null;

    /// <summary>
    /// Returns the noticeable script to run when the player quaffs the potion; or null, if the item cannot be quaffed.  This property is bound using the <see cref="QuaffBindingTuple"/>
    /// property during the bind phase.
    /// 
    /// Perform a smash effect on the potion and returns true, if the effect causes pets to become unfriendly; false, otherwise.  Returns false, by default.
    /// 
    /// The amount of mana needed to consume to keep the potion.
    /// 
    /// </summary>
    public (IEatOrQuaffScript QuaffScript, ProjectileScript? SmashScript, int ManaEquivalent)? QuaffTuple { get; private set; } = null;

    /// <summary>
    /// Returns the <see cref="ItemClass"/> that is used as ammunition for this item; or null, if the item is not a ranged weapon.  This property bound using
    /// the <see cref="AmmunitionItemFactoryBindingKeys"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    public ItemFactory[]? AmmunitionItemFactories { get; private set; } = null;

    /// <summary>
    /// Returns the <see cref="IAimWandScript"/> script for wands when aimed, a Roll to determine the number of charges to assign to new wands and the value for each charge; or null, if the item cannot be aimed.  
    /// This property is bound from the <see cref="AimingBindingTuple"/> property during the bind phase.
    /// </summary>
    public (IAimWandScript ActivationScript, Expression InitialChargesCountRoll, int PerChargeValue, int ManaValue)? AimingTuple { get; private set; } = null;

    public IScriptItemInt? RechargeScript { get; private set; }

    public (int, Expression)[]? MassProduceTuples { get; private set; } = null;
    public ProbabilityExpression? BreaksDuringEnchantmentProbability { get; private set; }
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
    public ProbabilityExpression BreakageChanceProbability { get; private set; }

    public (IZapRodScript Script, Expression TurnsToRecharge, bool RequiresAiming, int ManaEquivalent)? ZapTuple { get; private set; } = null;
    public ItemClass ItemClass { get; private set; }

    /// <summary>
    /// Returns the inventory slots where the item can be wielded.  Items will be placed in the first wield slot that is available. Rings use multiple wield slots for left and right hands. 
    /// Returns the pack, by default.  This property is bound from the <see cref="WieldSlotBindingKeys"/> property during the binding phase.
    /// </summary>
    public WieldSlot[] WieldSlots { get; private set; }

    /// <summary>
    /// Returns a Roll that is used to determine the number of gold pieces that are given to the player when the item is picked up.  This property is bound from the
    /// <see cref="InitialGoldPiecesRollExpression"/> property during the bind phase.
    /// </summary>
    public Expression InitialGoldPiecesRoll { get; private set; }

    /// <summary>
    /// Returns the spells, in order, that belong to this book; or null, if the item is not a book.  This property is bound from the SpellNames property during the binding phase.
    /// </summary>
    public Spell[]? Spells { get; private set; }

    /// <summary>
    /// Returns the script to be run when an item of this factory is eaten; or null, if items cannot be eaten.  This property is bound from the <see cref="EatScriptBindingKey"/> property
    /// during the bind phase.
    /// </summary>
    public IEatOrQuaffScript? EatScript { get; private set; }

    /// <summary>
    /// Returns the activation script for scrolls when read; or null, if the item cannot be read.  This property is bound from the <see cref="ReadBindingTuple"/> property during the bind phase.
    /// </summary>
    public (IReadScrollOrUseStaffScript ActivationScript, int ManaValue)? ReadTuple { get; private set; } = null;
    #endregion

    #region Light-Weight Virtual and Abstract Properties - Action Hooks and Behavior Modifiers for Game Packs and Generic API Objects
    /// <summary>
    /// Returns the name of the <see cref="ItemFlavor"/> that this item should be assigned.  This assignment overrides the random flavor assignment, when the <see cref="ItemClass"/>
    /// utilizes item flavors.  Returns null, to allow the <see cref="ItemClass"/> to assign a random <see cref="ItemFlavor"/> or when this factory doesn't produce flavored items.
    /// This property is used to bind the <see cref="PreassignedItemFlavor"/> property during the binding phase.
    /// </summary>
    protected virtual string? PreassignedItemFlavorBindingKey { get; } = null;

    public virtual bool NegativeBonusDamageRepresentsBroken { get; } = false;
    public virtual bool NegativeBonusArmorClassRepresentsBroken { get; } = false;
    public virtual bool NegativeBonusHitRepresentsBroken { get; } = false;

    protected virtual string? SlayingRandomArtifactItemEnhancementWeightedRandomBindingKey { get; } = nameof(SlayingItemEnhancementWeightedRandom);

    /// <summary>
    /// Returns the ceiling value for bonus armor values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    public virtual int? RandomArtifactBonusArmorCeiling { get; } = null;

    /// <summary>
    /// Returns the ceiling value for bonus hit values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    public virtual int? RandomArtifactBonusHitCeiling { get; } = null;

    /// <summary>
    /// Returns the ceiling value for bonus damage values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    public virtual int? RandomArtifactBonusDamageCeiling { get; } = null;

    /// <summary>
    /// Returns the key of the script that is used to refill the item; or null, if the item cannot be refilled.  Returns null, by default.  This property is used to bind the <see cref="RefillScript"/>
    /// property during the binding phase.
    /// </summary>
    protected virtual string? RefillScriptBindingKey { get; } = null;

    /// <summary>
    /// Returns the symbol to use for rendering the item.  This symbol will be initially used to set the <see cref="FlavorSymol"/> and item catagories that have flavor may the change the
    /// <see cref="FlavorCharacter"/> based on the flavor.  This property is used to bind the <see cref="Symbol"/> property during the bind phase.
    /// </summary>
    protected virtual string SymbolBindingKey { get; }

    public virtual bool CanBeWeaponOfLaw { get; } = false;

    public virtual bool CanBeWeaponOfSharpness { get; } = false;

    public virtual bool CapableOfVorpalSlaying { get; } = false;

    /// <summary>
    /// Returns the color that items of this type should be rendered with.  This color will be initially used to set the <see cref="FlavorColor"/> and item categories
    /// that have flavor may change the FlavorColor based on the flavor.
    /// </summary>
    public virtual ColorEnum Color { get; } = ColorEnum.White;

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
    /// </summary>
    protected virtual (string UseScriptBindingKey, string InitialChargesRollExpression, int PerChargeValue, int ManaEquivalent)? UseBindingTuple { get; } = null;

    /// <summary>
    /// Returns the name of the noticeable script to run when the player quaffs the potion and the name of the smash script when the player smashes the potion; or null if the potion does
    /// not have a smash effect; if the item can be quaffed; or null, if the item cannot be quaffed.  This property is used to bind the
    /// <see cref="QuaffTuple"/> property during the bind phase.  Returns null, by default.
    /// 
    /// Perform a smash effect on the potion and returns true, if the effect causes pets to become unfriendly; false, otherwise.  Returns false, by default.
    /// 
    /// The amount of mana needed to consume to keep the potion.
    /// </summary>
    protected virtual (string QuaffScriptName, string? SmashScriptName, int ManaEquivalent)? QuaffBindingTuple { get; } = null;

    /// <summary>
    /// Returns the name of the <see cref="ItemClass"/> that is used as ammunition for this item; or null, if the item is not a ranged weapon.  This property is used to bind
    /// the <see cref="AmmunitionItemFactories"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    protected virtual string[]? AmmunitionItemFactoryBindingKeys { get; } = null;

    /// <summary>
    /// Returns true, if the item can be used to spike a door closed; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool CanSpikeDoorClosed { get; } = false;

    /// <summary>
    /// Returns true, if the item can be used to dig; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool CanTunnel { get; } = false;

    /// <summary>
    /// Returns true, if the item is a bow and can project arrows; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool CanProjectArrows { get; } = false;

    /// <summary>
    /// Returns the maximum number of items that can be enchanted at one time.  A value of 1 is returned, by default.  Ammunition items return 20.  Item counts greater than this value
    /// will have a decreased probability of enchantment.
    /// </summary>
    public virtual int EnchantmentMaximumCount { get; } = 1;

    /// <summary>
    /// Returns true, if the item is magical and is noticed with the detect magical scoll.
    /// </summary>
    public virtual bool IsMagical { get; } = false;

    /// <summary>
    /// Returns the value of each turn of light for light sources.  Returns 0, by default;
    /// </summary>
    public virtual int ValuePerTurnOfLight { get; } = 0;

    /// <summary>
    /// Returns the name of the <see cref="IAimWandScript"/> script for wands when aimed, a roll expression to determine the number of charges to assign to new wands and the value of each charge; or null, if the 
    /// item cannot be aimed.  Returns null, by default.  This property is used to bind the <see cref="AimingTuple"/>  property during the bind phase.
    /// </summary>
    protected virtual (string ActivationScriptName, string InitialChargesCountRollExpression, int PerChargeValue, int ManaValue)? AimingBindingTuple { get; } = null;

    /// <summary>
    /// Returns true, if the item is broken; false, otherwise.  Broken items have no value and will be stomped.
    /// </summary>
    public virtual bool IsBroken { get; } = false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality that should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.  
    /// Returns false, by default.  Weapons, armor, orbs of light and broken items (items that negatively affect the player) return true.
    /// </summary>
    public virtual bool InitialBrokenStomp { get; } = false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    public virtual bool InitialAverageStomp { get; } = false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    public virtual bool InitialGoodStomp { get; } = false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    public virtual bool InitialExcellentStomp { get; } = false;

    protected virtual string? RechargeScriptBindingKey { get; } = null;

    /// <summary>
    /// Returns true, if the item is ignored by monsters.  Returns false for all items, except gold.  Gold isn't picked up by monsters.
    /// </summary>
    public virtual bool IsIgnoredByMonsters { get; } = false;

    /// <summary>
    /// Returns true, if the item is a container; false, otherwise.  Containers can be opened (ContainerIsOpen) and trapped (ContainerTraps).
    /// </summary>
    public virtual bool IsContainer { get; } = false;

    /// <summary>
    /// Returns true, if the item is a ranged weapon; false, otherwise.
    /// </summary>
    public virtual bool IsRangedWeapon { get; } = false;

    /// <summary>
    /// Returns a damage multiplier when the missile weapon is used.
    /// </summary>
    public virtual int MissileDamageMultiplier { get; } = 1;

    /// <summary>
    /// Returns the maximum fuel that can be used for phlogiston.  Returns null, by default, meaning that the light source cannot be used to create a phlogiston.
    /// </summary>
    public virtual int? MaxPhlogiston { get; } = null;

    /// <summary>
    /// Returns the number of turns of light that is consumed per turn.  Defaults to zero; which means there is no consumption and that the light source lasts forever.
    /// Torches and laterns have burn rates greater than zero.
    /// </summary>
    public virtual int BurnRate { get; } = 0;

    /// <summary>
    /// Returns an array of tuples that define the mass produce for items of this factory.  These tuples define a Roll that is applied for additional items to be produced
    /// for items of a cost value or less; or null, if no additional items should be produced based on any cost.  Returns null, by default.  This property is used
    /// to bind the <see cref="MassProduceTuples"/> property during the bind phase.  The tuples must be sorted by cost and are checked during the bind phase.
    /// </summary>
    protected virtual (int count, string rollExpression)[]? MassProduceBindingTuples { get; } = null;

    public virtual int BonusHitRealValueMultiplier { get; } = 100;
    public virtual int BonusDamageRealValueMultiplier { get; } = 100;
    public virtual int BonusArmorClassRealValueMultiplier { get; } = 100;
    public virtual int BonusDiceRealValueMultiplier { get; } = 100;

    protected virtual string? BreaksDuringEnchantmentProbabilityExpression { get; } = null;

    /// <summary>
    /// Returns the name of the IEnchantmentScript to run for enchanting items depending on the item power and whether the item is being sold in a store.
    /// </summary>
    /// <returns>
    /// Powers - One or more item power levels (-2, -1, 0, 1, 2) the enchantment applies to; or null, if the enchantments apply to all power levels./>
    /// StoreStock - True, when the enchantment applies only to items sold in a store; false, when the enchantment only applies to items not sold in a store; or null, if the enchantment applies regardless of whether the item is being sold in a store or not.;<para />
    /// ScriptNames - The names of one or more scripts that implement the IEnhancementScript interface to be run to enhance the item when the Powers and StoreStock criteria match.  An empty array will throw during binding.
    /// </returns>
    protected virtual (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples { get; } = null;

    /// <summary>
    /// Returns the name of the script to run, when the energy of a rechargeable item is consumed; or null, if the item does not have charges that can be consumed or those charges cannot be consumed.
    /// This property is used to bind the <see cref="EatMagicScript"/> property during the bind phase.
    /// </summary>
    protected virtual string? EatMagicScriptBindingKey { get; } = null;

    protected virtual string? GridProcessWorldScriptBindingKey { get; } = null;
    protected virtual string? MonsterProcessWorldScriptBindingKey { get; } = null;
    protected virtual string? EquipmentProcessWorldScriptBindingKey { get; } = null;
    protected virtual string? PackProcessWorldScriptBindingKey { get; } = null;

    /// <summary>
    /// Returns true, if the item can apply a bonus armor class for miscellaneous power.  Only weapons return true.  Returns false, by default.
    /// </summary>
    public virtual bool CanApplyBonusArmorClassMiscPower { get; } = false;

    /// <summary>
    /// Returns true, if the item can apply a blows bonus.  Returns false, by default. Bows, return true.
    /// </summary>
    public virtual bool CanApplyBlowsBonus { get; } = false;

    /// <summary>
    /// Returns an expression that represents the chance that an item that is thrown or fired will break.  Returns 10, or 10%, by default.  This
    /// property is used to bind the <see cref="BreakageChanceProbability"/> property during the bind phase.
    /// </summary>
    protected virtual string BreakageChanceProbabilityExpression { get; } = "10/100";

    protected virtual string MakeObjectCountExpression { get; } = "1";

    /// <summary>
    /// Returns true, if the item multiplies damages against a specific monster race.  Returns false, by default. Shots, arrows, bolts, hafted, polearms, swords and digging all return true.
    /// </summary>
    public virtual bool GetsDamageMultiplier { get; } = false;

    /// <summary>
    /// Returns true, if the item can be sensed; false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool IdentityCanBeSensed { get; } = false;

    /// <summary>
    /// Returns true, if the item can be used as fuel for a torch.
    /// </summary>
    public virtual bool IsFuelForTorch { get; } = false;

    /// <summary>
    /// Returns true, if the item can be worn.
    /// </summary>
    public virtual bool IsWearableOrWieldable { get; } = false;

    /// <summary>
    /// Returns true, if the item can be eaten.
    /// </summary>
    public virtual bool CanBeEaten { get; } = false;

    /// <summary>
    /// Returns true, if the item is armor.
    /// </summary>
    public virtual bool IsArmor { get; } = false;

    /// <summary>
    /// Returns true, if the item is a weapon.
    /// </summary>
    public virtual bool IsWeapon { get; } = false;

    /// <summary>
    /// Returns the number of items contained in the chest; or 0, if the item is not a container.  Returns 0, by default.
    /// </summary>
    public virtual int NumberOfItemsContained { get; } = 0;

    /// <summary>
    /// Returns the name of the item as it applies to the factory class.  In other words, the name does not include the factory class name.  E.g. The factory class of scrolls would
    /// have names like "light", "magic mapping" and "identify".  This name should be able to uniquely identify the item from other items within the same factory class.
    /// </summary>
    public virtual string Name { get; }

    /// <summary>
    /// Returns the syntax for the description of the item.  The and symbol '&' is used to represent the article (a, an or a number) and the
    /// tilde symbol '~' used to place the 's', 'es', or 'ies' plural form of the noun.
    /// </summary>
    protected virtual string? DescriptionSyntax { get; } = null; // TODO: Books use a hard-coded realm name when the realm is set at run-time.

    /// <summary>
    /// Returns an alternate coded name for some character classes for known items; null, if there is no altername name; in which the <see cref="DescriptionSyntax"/> property will
    /// be used.  Returns null, by default.  Spellbooks have a alternate names.  Druid, Fanatic, Monk, Priest and Ranger character classes use alternate names.  Character
    /// classes will use alternate naming conventions when <see cref="BaseCharacterClass.UseAlternateItemNames"/> property returns true.
    /// </summary>
    protected virtual string? AlternateDescriptionSyntax { get; } = null; // TODO: This coded divine name has hard-coded realm names when realm is set at run-time.

    protected virtual string? FlavorSuppressedDescriptionSyntax { get; } = null;
    protected virtual string? AlternateFlavorSuppressedDescriptionSyntax { get; } = null;

    protected virtual string? FlavorUnknownDescriptionSyntax { get; } = null;

    protected virtual string? AlternateFlavorUnknownDescriptionSyntax { get; } = null;

    /// <summary>
    /// Returns the number of turns an item that can be zapped needs before it is recharged; or null, if the item cannot be zapped.  A value of zero, means the item does not need any turns to
    /// be recharged after it is used.
    /// </summary>
    protected virtual (string ScriptName, string TurnsToRecharge, bool RequiresAiming, int ManaEquivalent)? ZapBindingTuple { get; } = null;

    protected virtual string ItemClassBindingKey { get; }

    /// <summary>
    /// Returns true, if the item is fuel for a lantern.  Returns false, by default.
    /// </summary>
    public virtual bool IsLanternFuel { get; } = false;

    /// <summary>
    /// Returns a sort order index for sorting items in a pack.  Lower numbers show before higher numbers.
    /// </summary>
    public virtual int PackSort { get; }

    /// <summary>
    /// Returns the inventory slot where the item is wielded.  Items will be wielded in the first slot that is available.  Rings use multiple wield slots for left and right hands.
    /// Returns the pack, by default.  This property is used to bind the <see cref="WieldSlots"/>  property during the binding phase.
    /// </summary>
    protected virtual string[] WieldSlotBindingKeys { get; } = new string[] { nameof(PackWieldSlot) };

    /// <summary>
    /// Returns true, if the destroy script should ask the player if known items from this factory should be destroyed by setting the applicable 
    /// broken stomp type to true; false, otherwise.  Returns true, by default.  Chests, weapons, armor and orbs of light return false.
    /// </summary>
    public virtual bool AskDestroyAll { get; } = true;

    /// <summary>
    /// Returns true, if the object has different quality ratings; false, if items of the factory all have the same quality rating.  Returns false, by default.  
    /// Armor, weapons and orbs of light return true.  Items without quality ratings will always use the Broken stomp type.  Items with various quality ratings will use various
    /// item properties to determine their quality.
    /// </summary>
    public virtual bool HasQualityRatings { get; } = false;

    public virtual int ArmorClass { get; } = 0;

    /// <summary>
    /// Returns the depth and 1-in probably for where the item can be found; or null, if the item is not found naturally.  Returns null, by default.
    /// </summary>
    public virtual (int level, int chance)[]? DepthsFoundAndChances { get; } = null; // TODO: Convert the chance into a Roll object

    /// <summary>
    /// Returns the real cost of a standard item.  Returns 0 by default.  For wands, staffs and light-sources, this value should be the value of an item with no charges.  An empty item should
    /// still have some value if it can be recharged.
    /// </summary>
    public virtual int Cost { get; } = 0;

    public virtual int DamageDice { get; } = 0;

    public virtual int DamageSides { get; } = 0;

    public virtual int LevelNormallyFound { get; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus attacks to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusAttacks { get; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus infravision to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusInfravision { get; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus speed to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusSpeed { get; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus search to be assigned to the item.
    /// </summary>
    protected virtual string InitialBonusSearchExpression { get; } = "0";

    /// <summary>
    /// Returns the initial amount of bonus stealth to be assigned to the item.
    /// </summary>
    protected virtual string InitialBonusStealthExpression { get; } = "0";

    /// <summary>
    /// Returns the initial amount of bonus tunnel to be assigned to the item.
    /// </summary>
    public virtual int InitialBonusTunnel { get; } = 0;

    /// <summary>
    /// Returns the initial number of turns of light to be assigned to the item.
    /// </summary>
    public virtual int InitialTurnsOfLight { get; } = 0;

    /// <summary>
    /// Returns the initial nutritional value that items of this factory will be given.  0 turns is returns by default.
    /// </summary>
    public virtual int InitialNutritionalValue { get; } = 0;

    /// <summary>
    /// Returns the roll expression to determine the initial gold pieces that are given to the player when the item is picked up.  This property must conform to the <see cref="Roll"/> syntax for parsing.  
    /// See <see cref="Game.ParseNumericExpression"/> for syntax details.  This property is used to bind the <see cref="InitialGoldPiecesRoll"/> property during the bind phase.
    /// </summary>
    protected virtual string InitialGoldPiecesRollExpression { get; } = "0";

    /// <summary>
    /// Returns a divisor to be used to compute the amount of experience gained when an applicable character class destroys the book.  Defaults to 4.
    /// </summary>
    public virtual int ExperienceGainDivisorForDestroying { get; } = 0;

    /// <summary>
    /// Returns the names of the spells, in order, that belong to this book; or null, if the item is not a book.  This property is used to bind the Spells property during the binding phase.
    /// </summary>
    protected virtual string[]? SpellBindingKeys { get; } = null;

    public virtual int BonusArmorClass { get; } = 0;
    public virtual int BonusDamage { get; } = 0;
    public virtual int BonusHit { get; } = 0;

    public virtual int Weight { get; } = 0;

    /// <summary>
    /// Returns whether or not the chest is small.  Small chests have a 75% chance that the items in the chest are gold.  Large chest always return items.
    /// </summary>
    public virtual bool IsSmall { get; } = false; // TODO: This property is only valid when IsContainer.  The data type is horrible.

    /// <summary>
    /// Returns true, if the item is capable of having slaying bonuses applied.  Only weapons return true.  Returns false by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual bool CanApplySlayingBonus { get; } = false;

    /// <summary>
    /// Returns the base value for a non flavor-aware item.  Returns 0, by default.
    /// </summary>
    public virtual int BaseValue { get; } = 0;

    /// <summary>
    /// Returns true, if the item is susceptible to electricity.  Returns false, by default.
    /// </summary>
    public virtual bool HatesElectricity { get; } = false;

    /// <summary>
    /// Returns true, if the item is susceptible to fire.  Returns false, by default.
    /// </summary>
    public virtual bool HatesFire { get; } = false;

    /// <summary>
    /// Returns true, if the item is susceptible to acid.  Returns false, by default.
    /// </summary>
    public virtual bool HatesAcid { get; } = false;

    /// <summary>
    /// Returns true, if the item is susceptible to cold.  Returns false, by default.
    /// </summary>
    public virtual bool HatesCold { get; } = false;

    /// <summary>
    /// Returns true, if the item can provide a sheath of electricity.  Returns false, by default.  Cloaks, soft and hard armor return true.
    /// </summary>
    public virtual bool CanProvideSheathOfElectricity { get; } = false;

    /// <summary>
    /// Returns true, if the item can provide a sheath of fire.  Returns false, by default.  Cloaks, soft and hard armor return true.
    /// </summary>
    public virtual bool CanProvideSheathOfFire { get; } = false;

    /// <summary>
    /// Returns true, if the item can reflect bolts and arrows.  Returns false, by default.  Shields, helms, cloaks and hard armor return true.
    /// </summary>
    public virtual bool CanReflectBoltsAndArrows { get; } = false;

    /// <summary>
    /// Returns a 1-in-chance for a random artifact to have activation applied.  Returns 3 by default.  Armor returns double the default.
    /// </summary>
    public virtual int RandartActivationChance { get; } = 3;

    /// <summary>
    /// Returns true, if the item provides sunlight, which burns certain races.  Returns false, by default.
    /// </summary>
    public virtual bool ProvidesSunlight { get; } = false;

    /// <summary>
    /// Returns true, if an item of this factory can have slaying bonus applied for biased artifacts.  Returns true, for all items except bows; which return false.
    /// </summary>
    public virtual bool CanApplyArtifactBiasSlaying { get; } = true;

    /// <summary>
    /// Returns true, if an item of this factory can have random resistance bonus applied for biased artifacts.  Returns false for all items except for cloaks, soft armor and hard armor; which return true.
    /// </summary>
    public virtual bool CanApplyArtifactBiasResistance { get; } = true;

    /// <summary>
    /// Returns true, if an item of this factory can have be blessed for priestly biased artifacts.  Returns false, for all items except swords and polearms; which return false.
    /// </summary>
    public virtual bool CanApplyBlessedArtifactBias { get; } = false;

    /// <summary>
    /// Returns true, if an item of this factory can be eaten by a monster with the eat food attack effect.  Returns false for all items except food items; which return true.
    /// </summary>
    public virtual bool CanBeEatenByMonsters { get; } = false;

    /// <summary>
    /// Returns the name of the script to be run when an item of this factory is eaten; or null, if items cannot be eaten.  Returns null, by default.  This property
    /// is used to bind the <see cref="EatScript"/> property during the bind phase.
    /// </summary>
    public virtual string? EatScriptBindingKey { get; } = null;

    public virtual bool VanishesWhenEatenBySkeletons { get; } = false;

    /// <summary>
    /// Returns true, if the food item is completely consumed when eaten.  Consumed food items are removed once eaten.  Returns true, by default because 
    /// all food items are consumed except for dwarf bread.  Dwarf bread returns false.
    /// </summary>
    public virtual bool IsConsumedWhenEaten { get; } = true;

    /// <summary>
    /// Returns the name of the activation script for scrolls when read; or null, if the item cannot be read.  Returns null, by default.  This property is used to bind the <see cref="ReadTuple"/> 
    /// property during the bind phase.
    /// </summary>
    /// <returns>
    /// ManaValue:description Returns the amount of mana channelers can substitute instead of the scroll being used up.
    /// </returns>
    protected virtual (string ScriptName, int ManaValue)? ReadBindingTuple { get; } = null;
    #endregion
}
