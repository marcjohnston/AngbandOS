// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration;

namespace AngbandOS.Core;

/// <summary>
/// Represents different variations (ItemType) of item categories (ItemCategory).  E.g. different types of food that belong to the food category.  Several of the
/// properties are modifiable.
/// </summary>
[Serializable]
internal sealed class ItemFactory : IGetKey, IToJson
{
    private readonly Game Game;
    private string ItemEnhancementBindingKey { get; }

    ///// <summary>
    ///// Represents the enhancements to apply to items created by this factory.
    ///// </summary>
    //private ItemEnhancement ItemEnhancement { get; set; }

    public override string ToString()
    {
        return $"{Key} - {base.ToString()}";
    }
    public string Key { get; }
    public string GetKey => Key;
    public ColorEnum Color { get; set; }

    #region Constructors
    public ItemFactory(Game game, ItemFactoryGameConfiguration itemFactoryGameConfiguration) 
    {
        Game = game;
        EffectiveAttributeSet = new EffectiveAttributeSet(Game);
        Key = itemFactoryGameConfiguration.Key ?? itemFactoryGameConfiguration.GetType().Name;
        ItemEnhancementBindingKey = itemFactoryGameConfiguration.ItemEnhancementBindingKey;

        Color = itemFactoryGameConfiguration.Color;
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
        UseBindingTuple = itemFactoryGameConfiguration.UseBindingTuple;
        QuaffBindingTuple = itemFactoryGameConfiguration.QuaffBindingTuple;
        AmmunitionItemFactoryBindingKeys = itemFactoryGameConfiguration.AmmunitionItemFactoryBindingKeys;
        CanSpikeDoorClosed = itemFactoryGameConfiguration.CanSpikeDoorClosed;
        CanProjectArrows = itemFactoryGameConfiguration.CanProjectArrows;
        EnchantmentMaximumCount = itemFactoryGameConfiguration.EnchantmentMaximumCount;
        IsMagical = itemFactoryGameConfiguration.IsMagical;
        ValuePerTurnOfLight = itemFactoryGameConfiguration.ValuePerTurnOfLight;
        AimingBindingTuple = itemFactoryGameConfiguration.AimingBindingTuple;
        InitialBrokenStomp = itemFactoryGameConfiguration.InitialBrokenStomp;
        InitialAverageStomp = itemFactoryGameConfiguration.InitialAverageStomp;
        InitialGoodStomp = itemFactoryGameConfiguration.InitialGoodStomp;
        InitialExcellentStomp = itemFactoryGameConfiguration.InitialExcellentStomp;
        RechargeScriptBindingKey = itemFactoryGameConfiguration.RechargeScriptBindingKey;
        IsIgnoredByMonsters = itemFactoryGameConfiguration.IsIgnoredByMonsters;
        IsContainer = itemFactoryGameConfiguration.IsContainer;
        IsGood = itemFactoryGameConfiguration.IsGood;
        IsRangedWeapon = itemFactoryGameConfiguration.IsRangedWeapon;
        MissileDamageMultiplier = itemFactoryGameConfiguration.MissileDamageMultiplier;
        MaxPhlogiston = itemFactoryGameConfiguration.MaxPhlogiston;
        MassProduceBindingTuples = itemFactoryGameConfiguration.MassProduceBindingTuples;
        BreaksDuringEnchantmentProbabilityExpression = itemFactoryGameConfiguration.BreaksDuringEnchantmentProbabilityExpression;
        EnchantmentBindingTuples = itemFactoryGameConfiguration.EnchantmentBindingTuples;
        EatMagicScriptBindingKey = itemFactoryGameConfiguration.EatMagicScriptBindingKey;
        GridProcessWorldScriptBindingKey = itemFactoryGameConfiguration.GridProcessWorldScriptBindingKey;
        MonsterProcessWorldScriptBindingKey = itemFactoryGameConfiguration.MonsterProcessWorldScriptBindingKey;
        EquipmentProcessWorldScriptBindingKey = itemFactoryGameConfiguration.EquipmentProcessWorldScriptBindingKey;
        PackProcessWorldScriptBindingKey = itemFactoryGameConfiguration.PackProcessWorldScriptBindingKey;
        BreakageChanceProbabilityExpression = itemFactoryGameConfiguration.BreakageChanceProbabilityExpression;
        MakeObjectCountExpression = itemFactoryGameConfiguration.MakeObjectCountExpression;
        GetsDamageMultiplier = itemFactoryGameConfiguration.GetsDamageMultiplier;
        IdentityCanBeSensed = itemFactoryGameConfiguration.IdentityCanBeSensed;
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
        PackSort = itemFactoryGameConfiguration.PackSort;
        WieldSlotBindingKeys = itemFactoryGameConfiguration.WieldSlotBindingKeys;
        AskDestroyAll = itemFactoryGameConfiguration.AskDestroyAll;
        HasQualityRatings = itemFactoryGameConfiguration.HasQualityRatings;
        DepthsFoundAndChances = itemFactoryGameConfiguration.DepthsFoundAndChances;
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
        IsSmall = itemFactoryGameConfiguration.IsSmall;
        BaseValue = itemFactoryGameConfiguration.BaseValue;
        CanProvideSheathOfElectricity = itemFactoryGameConfiguration.CanProvideSheathOfElectricity;
        CanProvideSheathOfFire = itemFactoryGameConfiguration.CanProvideSheathOfFire;
        RandartActivationChance = itemFactoryGameConfiguration.RandartActivationChance;
        ProvidesSunlight = itemFactoryGameConfiguration.ProvidesSunlight;
        CanApplyArtifactBiasResistance = itemFactoryGameConfiguration.CanApplyArtifactBiasResistance;
        CanBeEatenByMonsters = itemFactoryGameConfiguration.CanBeEatenByMonsters;
        EatScriptBindingKey = itemFactoryGameConfiguration.EatScriptBindingKey;
        VanishesWhenEatenBySkeletons = itemFactoryGameConfiguration.VanishesWhenEatenBySkeletons;
        IsConsumedWhenEaten = itemFactoryGameConfiguration.IsConsumedWhenEaten;
        ReadBindingTuple = itemFactoryGameConfiguration.ReadBindingTuple;
        DisableStomp = itemFactoryGameConfiguration.DisableStomp;
        EnhancementFixedArtifactFactoriesBindingKeys = itemFactoryGameConfiguration.EnhancementFixedArtifactFactoriesBindingKeys;
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
    /// Returns the character that is used to display items of this type.  This character is initially set from the BaseItemCategory, but item classes
    /// that have flavor may override this character and replace it with a different character from the flavor.
    /// </summary>
    public Symbol FlavorSymbol;

    /// <summary>
    /// Returns the color to be used for items of this type.  This color is initially set from the BaseItemCategory, but item categories
    /// that have flavor may override this color and replace it with a different color from the flavor.
    /// </summary>
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
            Color = Color,
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
            UseBindingTuple = UseBindingTuple,
            QuaffBindingTuple = QuaffBindingTuple,
            AmmunitionItemFactoryBindingKeys = AmmunitionItemFactoryBindingKeys,
            CanSpikeDoorClosed = CanSpikeDoorClosed,
            CanProjectArrows = CanProjectArrows,
            EnchantmentMaximumCount = EnchantmentMaximumCount,
            IsMagical = IsMagical,
            ValuePerTurnOfLight = ValuePerTurnOfLight,
            AimingBindingTuple = AimingBindingTuple,
            InitialBrokenStomp = InitialBrokenStomp,
            InitialAverageStomp = InitialAverageStomp,
            InitialGoodStomp = InitialGoodStomp,
            InitialExcellentStomp = InitialExcellentStomp,
            RechargeScriptBindingKey = RechargeScriptBindingKey,
            IsIgnoredByMonsters = IsIgnoredByMonsters,
            IsContainer = IsContainer,
            IsGood = IsGood,
            DisableStomp = DisableStomp,
            IsRangedWeapon = IsRangedWeapon,
            MissileDamageMultiplier = MissileDamageMultiplier,
            MaxPhlogiston = MaxPhlogiston,
            MassProduceBindingTuples = MassProduceBindingTuples,
            BreaksDuringEnchantmentProbabilityExpression = BreaksDuringEnchantmentProbabilityExpression,
            EnchantmentBindingTuples = EnchantmentBindingTuples,
            EatMagicScriptBindingKey = EatMagicScriptBindingKey,
            GridProcessWorldScriptBindingKey = GridProcessWorldScriptBindingKey,
            MonsterProcessWorldScriptBindingKey = MonsterProcessWorldScriptBindingKey,
            EquipmentProcessWorldScriptBindingKey = EquipmentProcessWorldScriptBindingKey,
            PackProcessWorldScriptBindingKey = PackProcessWorldScriptBindingKey,
            BreakageChanceProbabilityExpression = BreakageChanceProbabilityExpression,
            MakeObjectCountExpression = MakeObjectCountExpression,
            GetsDamageMultiplier = GetsDamageMultiplier,
            IdentityCanBeSensed = IdentityCanBeSensed,
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
            PackSort = PackSort,
            WieldSlotBindingKeys = WieldSlotBindingKeys,
            AskDestroyAll = AskDestroyAll,
            HasQualityRatings = HasQualityRatings,
            DepthsFoundAndChances = DepthsFoundAndChances,
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
            IsSmall = IsSmall,
            BaseValue = BaseValue,
            CanProvideSheathOfElectricity = CanProvideSheathOfElectricity,
            CanProvideSheathOfFire = CanProvideSheathOfFire,
            RandartActivationChance = RandartActivationChance,
            ProvidesSunlight = ProvidesSunlight,
            CanApplyArtifactBiasResistance = CanApplyArtifactBiasResistance,
            CanBeEatenByMonsters = CanBeEatenByMonsters,
            EatScriptBindingKey = EatScriptBindingKey,
            VanishesWhenEatenBySkeletons = VanishesWhenEatenBySkeletons,
            IsConsumedWhenEaten = IsConsumedWhenEaten,
            ReadBindingTuple = ReadBindingTuple,
            EnhancementFixedArtifactFactoriesBindingKeys = EnhancementFixedArtifactFactoriesBindingKeys,
        };
        return JsonSerializer.Serialize(itemFactoryGameConfiguration, Game.GetJsonSerializerOptions());
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
    public EffectiveAttributeSet EffectiveAttributeSet;

    public void Bind()
    {
        ItemEnhancement itemEnhancement = Game.SingletonRepository.Get<ItemEnhancement>(ItemEnhancementBindingKey);
        EffectiveAttributeSet.MergeAttributeSet(itemEnhancement.GenerateAttributeSet());

        // Cut and paste
        //string? prop1 = Game.CutProperty(@"D:\Programming\AngbandOS\AngbandOS.GamePacks.Cthangband\ItemEnhancements\", itemEnhancement.GetKey, "public override ColorEnum");
        //if (prop1 is null && itemEnhancement.Color is not null)
        //    throw new Exception();
        //if (prop1 is not null)
        //    Game.PasteProperty(@$"D:\Programming\AngbandOS\AngbandOS.GamePacks.Cthangband\ItemFactories", Key, $"    public override ColorEnum Color => ColorEnum.{Enum.GetName<ColorEnum>(itemEnhancement.Color.Value)};");
        //bool isGood = BonusArmorClass >= 0 && BonusHit >= 0 && BonusDamage >= 0;
        //if (isGood)
        //    Game.PasteProperty(@"D:\Programming\AngbandOS\AngbandOS.GamePacks.Cthangband\ItemFactories\", Key, $"    public override bool IsGood => {isGood.ToString().ToLower()};");
        Symbol = Game.SingletonRepository.Get<Symbol>(SymbolBindingKey);
        ItemClass = Game.SingletonRepository.Get<ItemClass>(ItemClassBindingKey);
        FlavorSymbol = Symbol;

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
        _descriptionSyntax = DescriptionSyntax ?? Name;

        // If there is no AlternateDescriptionSyntax, use the DescriptionSyntax as the default.
        _alternateDescriptionSyntax = AlternateDescriptionSyntax ?? _descriptionSyntax;

        // Flavored items that are still unknown will default to using the flavorless syntaxes.
        _flavorUnknownDescriptionSyntax = FlavorUnknownDescriptionSyntax ?? _descriptionSyntax;
        _alternateFlavorUnknownDescriptionSyntax = AlternateFlavorUnknownDescriptionSyntax ?? _flavorUnknownDescriptionSyntax;

        _flavorSuppressedDescriptionSyntax = FlavorSuppressedDescriptionSyntax ?? _descriptionSyntax;
        _alternateFlavorSuppressedDescriptionSyntax = AlternateFlavorSuppressedDescriptionSyntax ?? _flavorSuppressedDescriptionSyntax;

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
        EnhancementFixedArtifactFactories = Game.SingletonRepository.GetNullable<FixedArtifact>(EnhancementFixedArtifactFactoriesBindingKeys);
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
        if (item.IsRare)
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
        string s = "";
        if (IsRangedWeapon)
        {
            int power = MissileDamageMultiplier;
            if (item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(XtraMightAttribute)).Get())
            {
                power++;
            }
            s += $" (x{power})";

            if (item.IsKnown())
            {
                s += $" ({GetSignedValue(item.EffectiveAttributeSet.MeleeToHit)},{GetSignedValue(item.EffectiveAttributeSet.ToDamage)})";

                if (item.EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Get() != 0)
                {
                    // Add base armor class for all types of armor and when the base armor class is greater than zero.
                    s += $" [{item.EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Get()},{GetSignedValue(item.EffectiveAttributeSet.BonusArmorClass)}]";
                }
                else if (item.EffectiveAttributeSet.BonusArmorClass != 0)
                {
                    // This is not armor, only show bonus armor class, if it is not zero and we know about it.
                    s += $" [{GetSignedValue(item.EffectiveAttributeSet.BonusArmorClass)}]";
                }
            }
            else if (item.EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Get() != 0)
            {
                s += $" [{item.EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Get()}]";
            }
        }
        else if (IsWeapon)
        {
            s += $" ({item.EffectiveAttributeSet.DamageDice}d{item.EffectiveAttributeSet.DiceSides})";

            if (item.IsKnown())
            {
                s += $" ({GetSignedValue(item.EffectiveAttributeSet.MeleeToHit)},{GetSignedValue(item.EffectiveAttributeSet.ToDamage)})";

                if (item.EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Get() != 0)
                {
                    // Add base armor class for all types of armor and when the base armor class is greater than zero.
                    s += $" [{item.EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Get()},{GetSignedValue(item.EffectiveAttributeSet.BonusArmorClass)}]";
                }
                else if (item.EffectiveAttributeSet.BonusArmorClass != 0)
                {
                    // This is not armor, only show bonus armor class, if it is not zero and we know about it.
                    s += $" [{GetSignedValue(item.EffectiveAttributeSet.BonusArmorClass)}]";
                }
            }
            else if (item.EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Get() != 0)
            {
                s += $" [{item.EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Get()}]";
            }
        }
        else if (IsArmor)
        {
            if (item.IsKnown())
            {
                if (item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ShowModsAttribute)).Get() || item.EffectiveAttributeSet.MeleeToHit != 0 && item.EffectiveAttributeSet.ToDamage != 0)
                {
                    s += $" ({GetSignedValue(item.EffectiveAttributeSet.MeleeToHit)},{GetSignedValue(item.EffectiveAttributeSet.ToDamage)})";
                }
                else if (item.EffectiveAttributeSet.MeleeToHit != 0)
                {
                    s += $" ({GetSignedValue(item.EffectiveAttributeSet.MeleeToHit)})";
                }
                else if (item.EffectiveAttributeSet.ToDamage != 0)
                {
                    s += $" ({GetSignedValue(item.EffectiveAttributeSet.ToDamage)})";
                }

                // Add base armor class for all types of armor and when the base armor class is greater than zero.
                s += $" [{item.EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Get()},{GetSignedValue(item.EffectiveAttributeSet.BonusArmorClass)}]";
            }
            else if (item.EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Get() != 0)
            {
                s += $" [{item.EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Get()}]";
            }
        }
        else
        {
            if (item.IsKnown())
            {
                if (item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ShowModsAttribute)).Get() || item.EffectiveAttributeSet.MeleeToHit != 0 && item.EffectiveAttributeSet.ToDamage != 0)
                {
                    s += $" ({GetSignedValue(item.EffectiveAttributeSet.MeleeToHit)},{GetSignedValue(item.EffectiveAttributeSet.ToDamage)})";
                }
                else if (item.EffectiveAttributeSet.MeleeToHit != 0)
                {
                    s += $" ({GetSignedValue(item.EffectiveAttributeSet.MeleeToHit)})";
                }
                else if (item.EffectiveAttributeSet.ToDamage != 0)
                {
                    s += $" ({GetSignedValue(item.EffectiveAttributeSet.ToDamage)})";
                }

                if (item.EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Get() != 0)
                {
                    // Add base armor class for all types of armor and when the base armor class is greater than zero.
                    s += $" [{item.EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Get()},{GetSignedValue(item.EffectiveAttributeSet.BonusArmorClass)}]";
                }
                else if (item.EffectiveAttributeSet.BonusArmorClass != 0)
                {
                    // This is not armor, only show bonus armor class, if it is not zero and we know about it.
                    s += $" [{GetSignedValue(item.EffectiveAttributeSet.BonusArmorClass)}]";
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

        if (EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BurnRateAttribute)).Get() > 0)
        {
            s += $" (with {item.TurnsOfLightRemaining} {Game.Pluralize("turn", item.TurnsOfLightRemaining)} of light)";
        }

        if (item.IsKnown())
        {
            (int bonusValue, string priorityBonusName)? commonBonusValue = CommonBonusValue(item);
            if (commonBonusValue.HasValue && commonBonusValue.Value.bonusValue != 0)
            {
                s += $" ({GetSignedValue(commonBonusValue.Value.bonusValue)}";
                if (!item.EffectiveAttributeSet.HideType && commonBonusValue.Value.priorityBonusName != "")
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
        if (item.EffectiveAttributeSet.Speed != 0)
        {
            if (value.HasValue && item.EffectiveAttributeSet.Speed != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EffectiveAttributeSet.Speed, "speed");
        }
        if (item.EffectiveAttributeSet.Attacks != 0)
        {
            if (value.HasValue && item.EffectiveAttributeSet.Attacks != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EffectiveAttributeSet.Attacks, Game.Pluralize("attack", item.EffectiveAttributeSet.Attacks));
        }
        if (item.EffectiveAttributeSet.Stealth != 0)
        {
            if (value.HasValue && item.EffectiveAttributeSet.Stealth != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EffectiveAttributeSet.Stealth, "stealth");
        }
        if (item.EffectiveAttributeSet.Search != 0)
        {
            if (value.HasValue && item.EffectiveAttributeSet.Search != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EffectiveAttributeSet.Search, "searching");
        }
        if (item.EffectiveAttributeSet.Infravision != 0)
        {
            if (value.HasValue && item.EffectiveAttributeSet.Infravision != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EffectiveAttributeSet.Infravision, "infravision");
        }
        if (item.EffectiveAttributeSet.Charisma != 0)
        {
            if (value.HasValue && item.EffectiveAttributeSet.Charisma != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EffectiveAttributeSet.Charisma, "");
        }
        if (item.EffectiveAttributeSet.Constitution != 0)
        {
            if (value.HasValue && item.EffectiveAttributeSet.Constitution != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EffectiveAttributeSet.Constitution, "");
        }
        if (item.EffectiveAttributeSet.Dexterity != 0)
        {
            if (value.HasValue && item.EffectiveAttributeSet.Dexterity != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EffectiveAttributeSet.Dexterity, "");
        }
        if (item.EffectiveAttributeSet.Intelligence != 0)
        {
            if (value.HasValue && item.EffectiveAttributeSet.Intelligence != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EffectiveAttributeSet.Intelligence, "");
        }
        if (item.EffectiveAttributeSet.Strength != 0)
        {
            if (value.HasValue && item.EffectiveAttributeSet.Strength != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EffectiveAttributeSet.Strength, "");
        }
        if (item.EffectiveAttributeSet.Wisdom != 0)
        {
            if (value.HasValue && item.EffectiveAttributeSet.Wisdom != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EffectiveAttributeSet.Wisdom, "");
        }
        if (item.EffectiveAttributeSet.Tunnel != 0)
        {
            if (value.HasValue && item.EffectiveAttributeSet.Tunnel != value.Value.bonusValue)
            {
                return null;
            }
            value = (item.EffectiveAttributeSet.Tunnel, "");
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
        if (EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BurnRateAttribute)).Get() > 0 && item.TurnsOfLightRemaining <= 0)
        {
            return 0;
        }
        return item.EffectiveAttributeSet.Radius;
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
                descriptionSyntax = Game.CharacterClass.UseAlternateItemNames ? _alternateFlavorSuppressedDescriptionSyntax : _flavorSuppressedDescriptionSyntax;

                // This syntax is allowed to use the Name macro but not the Flavor macro.
                descriptionSyntax = descriptionSyntax.Replace("$Name$", Name, StringComparison.OrdinalIgnoreCase);
            }
            else if (!IsFlavorAware)
            {
                // The flavor for this item is still unknown.
                descriptionSyntax = Game.CharacterClass.UseAlternateItemNames ? _alternateFlavorUnknownDescriptionSyntax : _flavorUnknownDescriptionSyntax;

                // This syntax is allowed to use the flavor macro.
                descriptionSyntax = descriptionSyntax.Replace("$Flavor$", Flavor.Name, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                // This item has a known flavor.
                descriptionSyntax = Game.CharacterClass.UseAlternateItemNames ? _alternateDescriptionSyntax : _descriptionSyntax;

                // This syntax is allowed to use the name and flavor macros.
                descriptionSyntax = descriptionSyntax.Replace("$Name$", Name, StringComparison.OrdinalIgnoreCase);
                descriptionSyntax = descriptionSyntax.Replace("$Flavor$", Flavor.Name, StringComparison.OrdinalIgnoreCase);
            }
        }
        else
        {
            // This item is flavorless.
            descriptionSyntax = Game.CharacterClass.UseAlternateItemNames ? _alternateDescriptionSyntax : _descriptionSyntax;

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

    public ReadOnlyAttributeSet CreateRandomArtifact(Item item, bool fromScroll)
    {

        void ApplyRandomBonuses(EffectiveAttributeSet characteristics)
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
                    characteristics.Strength = Game.EnchantBonus(characteristics.Strength);
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
                    characteristics.Intelligence = Game.EnchantBonus(characteristics.Intelligence);
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
                    characteristics.Wisdom = Game.EnchantBonus(characteristics.Wisdom);
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
                    characteristics.Dexterity = Game.EnchantBonus(characteristics.Dexterity);
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
                    characteristics.Constitution = Game.EnchantBonus(characteristics.Constitution);
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
                    characteristics.Charisma = Game.EnchantBonus(characteristics.Charisma);
                    if (characteristics.ArtifactBias == null && Game.DieRoll(13) != 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(CharismaArtifactBias));
                    }
                    break;

                case 13:
                case 14:
                    characteristics.Stealth = Game.EnchantBonus(characteristics.Stealth);
                    if (characteristics.ArtifactBias == null && Game.DieRoll(3) == 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RogueArtifactBias));
                    }
                    break;

                case 15:
                case 16:
                    characteristics.Search = Game.EnchantBonus(characteristics.Search);
                    if (characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RangerArtifactBias));
                    }
                    break;

                case 17:
                case 18:
                    characteristics.Infravision = Game.EnchantBonus(characteristics.Infravision);
                    break;

                case 19:
                    characteristics.Speed = Game.EnchantBonus(characteristics.Speed);
                    if (characteristics.ArtifactBias == null && Game.DieRoll(11) == 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RogueArtifactBias));
                    }
                    break;

                case 20:
                case 21:
                    characteristics.Tunnel = Game.EnchantBonus(characteristics.Tunnel);
                    break;

                case 22:
                case 23:
                    if (characteristics.Get<OrEffectiveAttributeValue>(nameof(CanApplyBlowsBonusAttribute)).Get())
                    {
                        ApplyRandomBonuses(characteristics);
                    }
                    else
                    {
                        characteristics.Attacks = Game.DieRoll(2) + 1;
                        if (characteristics.Attacks > 4 && Game.DieRoll(Constants.WeirdLuck) != 1)
                        {
                            characteristics.Attacks = 4;
                        }
                        if (characteristics.ArtifactBias == null && Game.DieRoll(11) == 1)
                        {
                            characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WarriorArtifactBias));
                        }
                    }
                    break;
            }
        }

        void CurseRandart(EffectiveAttributeSet characteristics)
        {
            if (characteristics.Strength != 0)
            {
                characteristics.Strength = 0 - (characteristics.Strength + Game.DieRoll(4));
            }
            if (characteristics.Intelligence != 0)
            {
                characteristics.Intelligence = 0 - (characteristics.Intelligence + Game.DieRoll(4));
            }
            if (characteristics.Wisdom != 0)
            {
                characteristics.Wisdom = 0 - (characteristics.Wisdom + Game.DieRoll(4));
            }
            if (characteristics.Dexterity != 0)
            {
                characteristics.Dexterity = 0 - (characteristics.Dexterity + Game.DieRoll(4));
            }
            if (characteristics.Constitution != 0)
            {
                characteristics.Constitution = 0 - (characteristics.Constitution + Game.DieRoll(4));
            }
            if (characteristics.Charisma != 0)
            {
                characteristics.Charisma = 0 - (characteristics.Charisma + Game.DieRoll(4));
            }
            if (characteristics.Stealth != 0)
            {
                characteristics.Stealth = 0 - (characteristics.Stealth + Game.DieRoll(4));
            }
            if (characteristics.Search != 0)
            {
                characteristics.Search = 0 - (characteristics.Search + Game.DieRoll(4));
            }
            if (characteristics.Infravision != 0)
            {
                characteristics.Infravision = 0 - (characteristics.Infravision + Game.DieRoll(4));
            }
            if (characteristics.Tunnel != 0)
            {
                characteristics.Tunnel = 0 - (characteristics.Tunnel + Game.DieRoll(4));
            }
            if (characteristics.Attacks != 0)
            {
                characteristics.Attacks = 0 - (characteristics.Attacks + Game.DieRoll(4));
            }
            if (characteristics.Speed != 0)
            {
                characteristics.Speed = 0 - (characteristics.Speed + Game.DieRoll(4));
            }
            if (characteristics.BonusArmorClass != 0)
            {
                characteristics.BonusArmorClass = 0 - (characteristics.BonusArmorClass + Game.DieRoll(4));
            }
            if (characteristics.MeleeToHit != 0)
            {
                characteristics.MeleeToHit = 0 - (characteristics.MeleeToHit + Game.DieRoll(4));
            }
            if (characteristics.ToDamage != 0)
            {
                characteristics.ToDamage = 0 - (characteristics.ToDamage + Game.DieRoll(4));
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
                characteristics.Get<OrEffectiveAttributeValue>(nameof(AggravateAttribute)).Set();
            }
            if (Game.DieRoll(3) == 1)
            {
                characteristics.Get<OrEffectiveAttributeValue>(nameof(DrainExpAttribute)).Set();
            }
            if (Game.DieRoll(2) == 1)
            {
                characteristics.Get<OrEffectiveAttributeValue>(nameof(TeleportAttribute)).Set();
            }
            else if (Game.DieRoll(3) == 1)
            {
                characteristics.NoTele = true;
            }
            if (Game.CharacterClass.NonMagicRandomArtifact1InChance > 0)
            {
                if (Game.DieRoll(Game.CharacterClass.NonMagicRandomArtifact1InChance) == 1)
                {
                    characteristics.NoMagic = true;
                }
            }

            characteristics.IsCursed = true;
        }

        void ApplyMiscPowerForRandomArtifactCreation(EffectiveAttributeSet characteristics)
        {
            if (characteristics.ArtifactBias != null)
            {
                characteristics.ArtifactBias.ApplyMiscPowers(characteristics);
            }
            switch (Game.DieRoll(31))
            {
                case 1:
                    characteristics.Get<OrEffectiveAttributeValue>(nameof(SustStrAttribute)).Set();
                    if (characteristics.ArtifactBias == null)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(StrengthArtifactBias));
                    }
                    break;

                case 2:
                    characteristics.Get<OrEffectiveAttributeValue>(nameof(SustIntAttribute)).Set();
                    if (characteristics.ArtifactBias == null)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(IntelligenceArtifactBias));
                    }
                    break;

                case 3:
                    characteristics.Get<OrEffectiveAttributeValue>(nameof(SustWisAttribute)).Set();
                    if (characteristics.ArtifactBias == null)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(WisdomArtifactBias));
                    }
                    break;

                case 4:
                    characteristics.Get<OrEffectiveAttributeValue>(nameof(SustDexAttribute)).Set();
                    if (characteristics.ArtifactBias == null)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(DexterityArtifactBias));
                    }
                    break;

                case 5:
                    characteristics.Get<OrEffectiveAttributeValue>(nameof(SustConAttribute)).Set();
                    if (characteristics.ArtifactBias == null)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(ConstitutionArtifactBias));
                    }
                    break;

                case 6:
                    characteristics.Get<OrEffectiveAttributeValue>(nameof(SustChaAttribute)).Set();
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
                    characteristics.Get<OrEffectiveAttributeValue>(nameof(SeeInvisAttribute)).Set();
                    break;

                case 18:
                    characteristics.Get<OrEffectiveAttributeValue>(nameof(TelepathyAttribute)).Set();
                    if (characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                    {
                        characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(MageArtifactBias));
                    }
                    break;

                case 19:
                case 20:
                    characteristics.Get<OrEffectiveAttributeValue>(nameof(SlowDigestAttribute)).Set();
                    break;

                case 21:
                case 22:
                    characteristics.Get<BoolSetEffectiveAttributeValue>(nameof(RegenAttribute)).Set();
                    break;

                case 23:
                    characteristics.Get<OrEffectiveAttributeValue>(nameof(TeleportAttribute)).Set();
                    break;

                case 24:
                case 25:
                case 26:
                    if (!characteristics.Get<OrEffectiveAttributeValue>(nameof(CanApplyBonusArmorClassMiscPowerAttribute)).Get())
                    {
                        // This item cannot have misc power, select a different
                        ApplyMiscPowerForRandomArtifactCreation(characteristics);
                    }
                    else
                    {
                        characteristics.Get<OrEffectiveAttributeValue>(nameof(ShowModsAttribute)).Set();
                        characteristics.BonusArmorClass = 4 + Game.DieRoll(11);
                    }
                    break;

                case 27:
                case 28:
                case 29:
                    characteristics.Get<OrEffectiveAttributeValue>(nameof(ShowModsAttribute)).Set();
                    characteristics.MeleeToHit += 4 + Game.DieRoll(11);
                    characteristics.ToDamage += 4 + Game.DieRoll(11);
                    break;

                case 30:
                    characteristics.NoMagic = true;
                    break;

                case 31:
                    characteristics.NoTele = true;
                    break;
            }
        }

        void ApplySlayingForRandomArtifactCreation(Item item, EffectiveAttributeSet characteristics)
        {
            /// <summary>
            /// Apply slaying to the item and returns true, if additional slaying can applied.  By default, no slaying is applied and false is returned.
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            if (characteristics.ArtifactBias != null)
            {
                bool slayingApplied = ApplyTestsAndItemEnhancements(item, characteristics, characteristics.ArtifactBias?.RandomSlayings);

                if (slayingApplied)
                {
                    return;
                }
            }

            // Slaying wasn't applied via artifact bias.  Choose a slaying item enhancement.  If the item enhancement doesn't apply to this item factory, choose another.
            ItemEnhancement? slayingItemEnhancement = null;
            do
            {
                slayingItemEnhancement = SlayingRandomArtifactItemEnhancementWeightedRandom?.ChooseOrDefault();
            } while (slayingItemEnhancement != null && !slayingItemEnhancement.AppliesTo(this));

            // Apply the item enhancement.  This supports a null choice.
            characteristics.MergeAttributeSet(slayingItemEnhancement?.GenerateAttributeSet());
        }

        /// <summary>
        /// Loops through an array of item tests and enhancements and based on the probability of the test, applies its associated item enhancement and returns true, if an enhancement
        /// was applied.  If all of the tests fail, false is returned.
        /// </summary>
        bool ApplyTestsAndItemEnhancements(Item item, EffectiveAttributeSet characteristics, (ItemFilter, ProbabilityExpression, ItemEnhancement, ProbabilityExpression)[]? testsAndItemEnhancements)
        {
            if (testsAndItemEnhancements != null)
            {
                foreach ((ItemFilter itemTest, ProbabilityExpression itemTestProbability, ItemEnhancement itemEnhancement, ProbabilityExpression moreProbability) in testsAndItemEnhancements)
                {
                    // Test the probability and if whether the item test pass.
                    if (itemTestProbability.Test())
                    {
                        // The test only occurs on the effective properties.
                        if (itemTest.Matches(item))
                        {
                            characteristics.MergeAttributeSet(itemEnhancement.GenerateAttributeSet());
                            if (moreProbability.Test())
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        EffectiveAttributeSet characteristics = new EffectiveAttributeSet(Game);
        const int ArtifactCurseChance = 13;
        int powers = Game.DieRoll(5) + 1;
        bool aCursed = false;
        int warriorArtifactBias = 0;
        if (fromScroll && Game.DieRoll(4) == 1)
        {
            characteristics.ArtifactBias = Game.CharacterClass.ArtifactBias;
            warriorArtifactBias = Game.CharacterClass.FromScrollWarriorArtifactBiasPercentageChance;
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
            int maxType = (characteristics.Get<OrEffectiveAttributeValue>(nameof(CanApplySlayingBonusAttribute)).Get() ? 7 : 5);
            switch (Game.DieRoll(maxType))
            {
                case 1:
                case 2:
                    ApplyRandomBonuses(characteristics);
                    break;
                case 3:
                case 4:
                    bool randomResistancesApplied = ApplyTestsAndItemEnhancements(item, characteristics, characteristics.ArtifactBias?.RandomResistances);
                    if (!randomResistancesApplied)
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

                        itemAdditiveBundleWeightedRandom.Add(2 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(SoundResistanceRingItemFactoryItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistShardsItemEnhancement)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 16 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistNetherAndNecromanticBiasItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 32 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistNetherItemEnhancement)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistNexusItemEnhancement)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 24 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistChaosAndChaosBiasItemEnhancement)));
                        itemAdditiveBundleWeightedRandom.Add(2 * 24 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistChaosItemEnhancement)));

                        itemAdditiveBundleWeightedRandom.Add(2 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ResistDisenchantItemEnhancement)));

                        if (characteristics.Get<OrEffectiveAttributeValue>(nameof(CanProvideSheathOfElectricityAttribute)).Get())
                        {
                            itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(SheathOfElectricityAndElectricityBiasItemEnhancement)));
                        }

                        if (characteristics.Get<OrEffectiveAttributeValue>(nameof(CanProvideSheathOfFireAttribute)).Get())
                        {
                            itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(SheathOfFireAndFireBiasItemEnhancement)));
                        }

                        if (characteristics.Get<OrEffectiveAttributeValue>(nameof(ReflectAttribute)).Get())
                        {
                            itemAdditiveBundleWeightedRandom.Add(1 * 48 * 12, Game.SingletonRepository.Get<ItemEnhancement>(nameof(ReflectBoltsAndArrowsItemEnhancement)));
                        }

                        ItemEnhancement? itemAdditiveBundle = itemAdditiveBundleWeightedRandom.ChooseOrDefault();
                        if (itemAdditiveBundle != null)
                        {
                            characteristics.MergeAttributeSet(itemAdditiveBundle.GenerateAttributeSet());
                        }
                    }
                    break;

                case 5:
                    ApplyMiscPowerForRandomArtifactCreation(characteristics);
                    break;

                case 6:
                case 7:
                    ApplySlayingForRandomArtifactCreation(item, characteristics);
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
            characteristics.MeleeToHit += Game.DieRoll(characteristics.MeleeToHit > RandomArtifactBonusHitCeiling.Value ? 1 : RandomArtifactBonusHitCeiling.Value + 1 - characteristics.BonusArmorClass);
        }
        if (RandomArtifactBonusDamageCeiling != null)
        {
            characteristics.ToDamage += Game.DieRoll(characteristics.ToDamage > RandomArtifactBonusDamageCeiling.Value ? 1 : RandomArtifactBonusDamageCeiling.Value + 1 - characteristics.BonusArmorClass);
        }

        characteristics.IgnoreAcid = true;
        characteristics.IgnoreElec = true;
        characteristics.IgnoreFire = true;
        characteristics.IgnoreCold = true;
        characteristics.Get<SumEffectiveAttributeValue>(nameof(TreasureRatingAttribute)).Append(40);

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
        return characteristics.ToReadOnly();
    }
    #endregion

    #region Bound Concrete Properties - API Object Functionality - Set during Bind() - get; private set;
    public FixedArtifact[]? EnhancementFixedArtifactFactories { get; private set; }
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
    private IScriptItem? RefillScript { get; set; }

    /// <summary>
    /// Returns the symbol to use for rendering.  This property is bound from the <see cref="SymbolBindingKey"/> property during the bind phase.
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

    #region Light-Weight and Abstract Properties - Action Hooks and Behavior Modifiers for Game Packs and Generic API Objects
    /// <summary>
    /// Returns the name of the <see cref="ItemFlavor"/> that this item should be assigned.  This assignment overrides the random flavor assignment, when the <see cref="ItemClass"/>
    /// utilizes item flavors.  Returns null, to allow the <see cref="ItemClass"/> to assign a random <see cref="ItemFlavor"/> or when this factory doesn't produce flavored items.
    /// This property is used to bind the <see cref="PreassignedItemFlavor"/> property during the binding phase.
    /// </summary>
    private string? PreassignedItemFlavorBindingKey { get; } = null;

    public bool NegativeBonusDamageRepresentsBroken { get; } = false;
    public bool NegativeBonusArmorClassRepresentsBroken { get; } = false;
    public bool NegativeBonusHitRepresentsBroken { get; } = false;

    private string? SlayingRandomArtifactItemEnhancementWeightedRandomBindingKey { get; } = nameof(SlayingItemEnhancementWeightedRandom);

    /// <summary>
    /// Returns the ceiling value for bonus armor values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    public int? RandomArtifactBonusArmorCeiling { get; } = null;

    /// <summary>
    /// Returns the ceiling value for bonus hit values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    public int? RandomArtifactBonusHitCeiling { get; } = null;

    /// <summary>
    /// Returns the ceiling value for bonus damage values when creating a random artifact, or null, if no bonus should be added.  During the random artifact creation process, this ceiling determines the maximum value of a die roll that will
    /// be added to the bonus.  The die rolls will be provided a maximum value to prevent the bonus from going over the this ceiling value.  If the bonus is already above this ceiling
    /// value, the die roll will only provide an additional bonus value of 1.  Returns a value of null, by default.
    /// </summary>
    public int? RandomArtifactBonusDamageCeiling { get; } = null;

    /// <summary>
    /// Returns the key of the script that is used to refill the item; or null, if the item cannot be refilled.  Returns null, by default.  This property is used to bind the <see cref="RefillScript"/>
    /// property during the binding phase.
    /// </summary>
    private string? RefillScriptBindingKey { get; } = null;

    /// <summary>
    /// Returns the symbol to use for rendering the item.  This symbol will be initially used to set the <see cref="FlavorSymol"/> and item catagories that have flavor may the change the
    /// <see cref="FlavorCharacter"/> based on the flavor.  This property is used to bind the <see cref="Symbol"/> property during the bind phase.
    /// </summary>
    private string SymbolBindingKey { get; }

    public bool CanBeWeaponOfLaw { get; } = false;

    public bool CanBeWeaponOfSharpness { get; } = false;

    public bool CapableOfVorpalSlaying { get; } = false;

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
    private (string UseScriptBindingKey, string InitialChargesRollExpression, int PerChargeValue, int ManaEquivalent)? UseBindingTuple { get; } = null;

    /// <summary>
    /// Returns the name of the noticeable script to run when the player quaffs the potion and the name of the smash script when the player smashes the potion; or null if the potion does
    /// not have a smash effect; if the item can be quaffed; or null, if the item cannot be quaffed.  This property is used to bind the
    /// <see cref="QuaffTuple"/> property during the bind phase.  Returns null, by default.
    /// 
    /// Perform a smash effect on the potion and returns true, if the effect causes pets to become unfriendly; false, otherwise.  Returns false, by default.
    /// 
    /// The amount of mana needed to consume to keep the potion.
    /// </summary>
    private (string QuaffScriptName, string? SmashScriptName, int ManaEquivalent)? QuaffBindingTuple { get; } = null;

    /// <summary>
    /// Returns the name of the <see cref="ItemClass"/> that is used as ammunition for this item; or null, if the item is not a ranged weapon.  This property is used to bind
    /// the <see cref="AmmunitionItemFactories"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    private string[]? AmmunitionItemFactoryBindingKeys { get; } = null;

    /// <summary>
    /// Returns true, if the item can be used to spike a door closed; false, otherwise.  Returns false, by default.
    /// </summary>
    public bool CanSpikeDoorClosed { get; } = false;

    /// <summary>
    /// Returns true, if the item is a bow and can project arrows; false, otherwise.  Returns false, by default.
    /// </summary>
    public bool CanProjectArrows { get; } = false;

    /// <summary>
    /// Returns the maximum number of items that can be enchanted at one time.  A value of 1 is returned, by default.  Ammunition items return 20.  Item counts greater than this value
    /// will have a decreased probability of enchantment.
    /// </summary>
    public int EnchantmentMaximumCount { get; } = 1;

    /// <summary>
    /// Returns true, if the item is magical and is noticed with the detect magical scoll.
    /// </summary>
    public bool IsMagical { get; } = false;

    /// <summary>
    /// Returns the value of each turn of light for light sources.  Returns 0, by default;
    /// </summary>
    public int ValuePerTurnOfLight { get; } = 0;

    /// <summary>
    /// Returns the name of the <see cref="IAimWandScript"/> script for wands when aimed, a roll expression to determine the number of charges to assign to new wands and the value of each charge; or null, if the 
    /// item cannot be aimed.  Returns null, by default.  This property is used to bind the <see cref="AimingTuple"/>  property during the bind phase.
    /// </summary>
    private (string ActivationScriptName, string InitialChargesCountRollExpression, int PerChargeValue, int ManaValue)? AimingBindingTuple { get; } = null;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality that should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.  
    /// Returns false, by default.  Weapons, armor, orbs of light and broken items (items that negatively affect the player) return true.
    /// </summary>
    public bool InitialBrokenStomp { get; } = false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    public bool InitialAverageStomp { get; } = false;

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    public bool InitialGoodStomp { get; } = false;

    public bool IsGood { get; }

    /// <summary>
    /// Returns true, if items of this factory that have a broken quality should default to being stomped; false, otherwise.  This value is used to initially set the stomp type for broken items of this factory.
    /// Returns false, by default.
    /// </summary>
    public bool InitialExcellentStomp { get; } = false;

    private string? RechargeScriptBindingKey { get; } = null;

    /// <summary>
    /// Returns true, if the item is ignored by monsters.  Returns false for all items, except gold.  Gold isn't picked up by monsters.
    /// </summary>
    public bool IsIgnoredByMonsters { get; } = false;

    /// <summary>
    /// Returns true, if the item is a container; false, otherwise.  Containers can be opened (ContainerIsOpen) and trapped (ContainerTraps).
    /// </summary>
    public bool IsContainer { get; } = false;

    /// <summary>
    /// Returns true, if the item is a ranged weapon; false, otherwise.
    /// </summary>
    public bool IsRangedWeapon { get; } = false;

    /// <summary>
    /// Returns a damage multiplier when the missile weapon is used.
    /// </summary>
    public int MissileDamageMultiplier { get; } = 1;

    /// <summary>
    /// Returns the maximum fuel that can be used for phlogiston.  Returns null, by default, meaning that the light source cannot be used to create a phlogiston.
    /// </summary>
    public int? MaxPhlogiston { get; } = null;

    /// <summary>
    /// Returns an array of tuples that define the mass produce for items of this factory.  These tuples define a Roll that is applied for additional items to be produced
    /// for items of a cost value or less; or null, if no additional items should be produced based on any cost.  Returns null, by default.  This property is used
    /// to bind the <see cref="MassProduceTuples"/> property during the bind phase.  The tuples must be sorted by cost and are checked during the bind phase.
    /// </summary>
    private (int count, string rollExpression)[]? MassProduceBindingTuples { get; } = null;

    private string? BreaksDuringEnchantmentProbabilityExpression { get; } = null;

    /// <summary>
    /// Returns the name of the IEnchantmentScript to run for enchanting items depending on the item power and whether the item is being sold in a store.
    /// </summary>
    /// <returns>
    /// Powers - One or more item power levels (-2, -1, 0, 1, 2) the enchantment applies to; or null, if the enchantments apply to all power levels./>
    /// StoreStock - True, when the enchantment applies only to items sold in a store; false, when the enchantment only applies to items not sold in a store; or null, if the enchantment applies regardless of whether the item is being sold in a store or not.;<para />
    /// ScriptNames - The names of one or more scripts that implement the IEnhancementScript interface to be run to enhance the item when the Powers and StoreStock criteria match.  An empty array will throw during binding.
    /// </returns>
    private (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples { get; } = null;

    /// <summary>
    /// Returns the name of the script to run, when the energy of a rechargeable item is consumed; or null, if the item does not have charges that can be consumed or those charges cannot be consumed.
    /// This property is used to bind the <see cref="EatMagicScript"/> property during the bind phase.
    /// </summary>
    private string? EatMagicScriptBindingKey { get; } = null;

    private string? GridProcessWorldScriptBindingKey { get; } = null;
    private string? MonsterProcessWorldScriptBindingKey { get; } = null;
    private string? EquipmentProcessWorldScriptBindingKey { get; } = null;
    private string? PackProcessWorldScriptBindingKey { get; } = null;

    /// <summary>
    /// Returns an expression that represents the chance that an item that is thrown or fired will break.  Returns 10, or 10%, by default.  This
    /// property is used to bind the <see cref="BreakageChanceProbability"/> property during the bind phase.
    /// </summary>
    private string BreakageChanceProbabilityExpression { get; } = "10/100";

    private string MakeObjectCountExpression { get; } = "1";

    /// <summary>
    /// Returns true, if the item multiplies damages against a specific monster race.  Returns false, by default. Shots, arrows, bolts, hafted, polearms, swords and digging all return true.
    /// </summary>
    public bool GetsDamageMultiplier { get; } = false;

    /// <summary>
    /// Returns true, if the item can be sensed; false, otherwise.  Returns false, by default.
    /// </summary>
    public bool IdentityCanBeSensed { get; } = false;

    /// <summary>
    /// Returns true, if the item is armor.
    /// </summary>
    public bool IsArmor { get; } = false;

    /// <summary>
    /// Returns true, if the item is a weapon.
    /// </summary>
    public bool IsWeapon { get; } = false;

    /// <summary>
    /// Returns the number of items contained in the chest; or 0, if the item is not a container.  Returns 0, by default.
    /// </summary>
    public int NumberOfItemsContained { get; } = 0;

    /// <summary>
    /// Returns the name of the item as it applies to the factory class.  In other words, the name does not include the factory class name.  E.g. The factory class of scrolls would
    /// have names like "light", "magic mapping" and "identify".  This name should be able to uniquely identify the item from other items within the same factory class.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Returns the syntax for the description of the item.  The and symbol '&' is used to represent the article (a, an or a number) and the
    /// tilde symbol '~' used to place the 's', 'es', or 'ies' plural form of the noun.
    /// </summary>
    private string? DescriptionSyntax { get; } = null; // TODO: Books use a hard-coded realm name when the realm is set at run-time.

    /// <summary>
    /// Returns an alternate coded name for some character classes for known items; null, if there is no altername name; in which the <see cref="DescriptionSyntax"/> property will
    /// be used.  Returns null, by default.  Spellbooks have a alternate names.  Druid, Fanatic, Monk, Priest and Ranger character classes use alternate names.  Character
    /// classes will use alternate naming conventions when <see cref="CharacterClass.UseAlternateItemNames"/> property returns true.
    /// </summary>
    private string? AlternateDescriptionSyntax { get; } = null; // TODO: This coded divine name has hard-coded realm names when realm is set at run-time.

    private string? FlavorSuppressedDescriptionSyntax { get; } = null;
    private string? AlternateFlavorSuppressedDescriptionSyntax { get; } = null;

    private string? FlavorUnknownDescriptionSyntax { get; } = null;

    private string? AlternateFlavorUnknownDescriptionSyntax { get; } = null;

    /// <summary>
    /// Returns the number of turns an item that can be zapped needs before it is recharged; or null, if the item cannot be zapped.  A value of zero, means the item does not need any turns to
    /// be recharged after it is used.
    /// </summary>
    private (string ScriptName, string TurnsToRecharge, bool RequiresAiming, int ManaEquivalent)? ZapBindingTuple { get; } = null;

    private string ItemClassBindingKey { get; }

    public bool DisableStomp { get; }

    /// <summary>
    /// Returns a sort order index for sorting items in a pack.  Lower numbers show before higher numbers.
    /// </summary>
    public int PackSort { get; }

    /// <summary>
    /// Returns the inventory slot where the item is wielded.  Items will be wielded in the first slot that is available.  Rings use multiple wield slots for left and right hands.
    /// Returns the pack, by default.  This property is used to bind the <see cref="WieldSlots"/>  property during the binding phase.
    /// </summary>
    private string[] WieldSlotBindingKeys { get; } = new string[] { nameof(PackWieldSlot) };

    /// <summary>
    /// Returns true, if the destroy script should ask the player if known items from this factory should be destroyed by setting the applicable 
    /// broken stomp type to true; false, otherwise.  Returns true, by default.  Chests, weapons, armor and orbs of light return false.
    /// </summary>
    public bool AskDestroyAll { get; } = true;

    /// <summary>
    /// Returns true, if the object has different quality ratings; false, if items of the factory all have the same quality rating.  Returns false, by default.  
    /// Armor, weapons and orbs of light return true.  Items without quality ratings will always use the Broken stomp type.  Items with various quality ratings will use various
    /// item properties to determine their quality.
    /// </summary>
    public bool HasQualityRatings { get; } = false;

    /// <summary>
    /// Returns the depth and 1-in probably for where the item can be found; or null, if the item is not found naturally.  Returns null, by default.
    /// </summary>
    public (int level, int chance)[]? DepthsFoundAndChances { get; } = null; // TODO: Convert the chance into a Roll object

    public int LevelNormallyFound { get; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus attacks to be assigned to the item.
    /// </summary>
    public int InitialBonusAttacks { get; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus infravision to be assigned to the item.
    /// </summary>
    public int InitialBonusInfravision { get; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus speed to be assigned to the item.
    /// </summary>
    public int InitialBonusSpeed { get; } = 0;

    /// <summary>
    /// Returns the initial amount of bonus search to be assigned to the item.
    /// </summary>
    private string InitialBonusSearchExpression { get; } = "0";

    /// <summary>
    /// Returns the initial amount of bonus stealth to be assigned to the item.
    /// </summary>
    private string InitialBonusStealthExpression { get; } = "0";

    /// <summary>
    /// Returns the initial amount of bonus tunnel to be assigned to the item.
    /// </summary>
    public int InitialBonusTunnel { get; } = 0;

    /// <summary>
    /// Returns the initial number of turns of light to be assigned to the item.
    /// </summary>
    public int InitialTurnsOfLight { get; } = 0;

    /// <summary>
    /// Returns the initial nutritional value that items of this factory will be given.  0 turns is returns by default.
    /// </summary>
    public int InitialNutritionalValue { get; } = 0;

    /// <summary>
    /// Returns the roll expression to determine the initial gold pieces that are given to the player when the item is picked up.  This property must conform to the <see cref="Roll"/> syntax for parsing.  
    /// See <see cref="Game.ParseNumericExpression"/> for syntax details.  This property is used to bind the <see cref="InitialGoldPiecesRoll"/> property during the bind phase.
    /// </summary>
    private string InitialGoldPiecesRollExpression { get; } = "0";

    /// <summary>
    /// Returns a divisor to be used to compute the amount of experience gained when an applicable character class destroys the book.  Defaults to 4.
    /// </summary>
    public int ExperienceGainDivisorForDestroying { get; } = 0;

    /// <summary>
    /// Returns the names of the spells, in order, that belong to this book; or null, if the item is not a book.  This property is used to bind the Spells property during the binding phase.
    /// </summary>
    private string[]? SpellBindingKeys { get; } = null;

    /// <summary>
    /// Returns whether or not the chest is small.  Small chests have a 75% chance that the items in the chest are gold.  Large chest always return items.
    /// </summary>
    public bool IsSmall { get; } = false; // TODO: This property is only valid when IsContainer.  The data type is horrible.

    /// <summary>
    /// Returns the base value for a non flavor-aware item.  Returns 0, by default.
    /// </summary>
    public int BaseValue { get; } = 0;

    /// <summary>
    /// Returns true, if the item can provide a sheath of electricity.  Returns false, by default.  Cloaks, soft and hard armor return true.
    /// </summary>
    public bool CanProvideSheathOfElectricity { get; } = false;

    /// <summary>
    /// Returns true, if the item can provide a sheath of fire.  Returns false, by default.  Cloaks, soft and hard armor return true.
    /// </summary>
    public bool CanProvideSheathOfFire { get; } = false;

    /// <summary>
    /// Returns a 1-in-chance for a random artifact to have activation applied.  Returns 3 by default.  Armor returns double the default.
    /// </summary>
    public int RandartActivationChance { get; } = 3;

    /// <summary>
    /// Returns true, if the item provides sunlight, which burns certain races.  Returns false, by default.
    /// </summary>
    public bool ProvidesSunlight { get; } = false;

    /// <summary>
    /// Returns true, if an item of this factory can have random resistance bonus applied for biased artifacts.  Returns false for all items except for cloaks, soft armor and hard armor; which return true.
    /// </summary>
    public bool CanApplyArtifactBiasResistance { get; } = true;

    /// <summary>
    /// Returns true, if an item of this factory can be eaten by a monster with the eat food attack effect.  Returns false for all items except food items; which return true.
    /// </summary>
    public bool CanBeEatenByMonsters { get; } = false;

    /// <summary>
    /// Returns the name of the script to be run when an item of this factory is eaten; or null, if items cannot be eaten.  Returns null, by default.  This property
    /// is used to bind the <see cref="EatScript"/> property during the bind phase.
    /// </summary>
    public string? EatScriptBindingKey { get; } = null;

    public bool VanishesWhenEatenBySkeletons { get; } = false;

    /// <summary>
    /// Returns true, if the food item is completely consumed when eaten.  Consumed food items are removed once eaten.  Returns true, by default because 
    /// all food items are consumed except for dwarf bread.  Dwarf bread returns false.
    /// </summary>
    public bool IsConsumedWhenEaten { get; } = true;

    /// <summary>
    /// Returns the name of the activation script for scrolls when read; or null, if the item cannot be read.  Returns null, by default.  This property is used to bind the <see cref="ReadTuple"/> 
    /// property during the bind phase.
    /// </summary>
    /// <returns>
    /// ManaValue:description Returns the amount of mana channelers can substitute instead of the scroll being used up.
    /// </returns>
    private (string ScriptName, int ManaValue)? ReadBindingTuple { get; } = null;

    private string[]? EnhancementFixedArtifactFactoriesBindingKeys { get; } = null;
    #endregion
}
