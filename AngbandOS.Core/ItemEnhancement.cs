// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents a set of non-deterministic item characteristics that can be merged with another other IItemCharacterstics.  These objects are used by <see cref="RareItem"/> objects and the random 
/// artifact creation process.
/// </summary>
[Serializable]
internal sealed class ItemEnhancement : IGetKey, IToJson, IItemEnhancement
{
    #region API
    private readonly Game Game;
    public ItemEnhancement(Game game) // Used by ItemFactory and FixedArtifacts // TODO: Delete
    {
        Game = game;
    }

    public ItemEnhancement(Game game, ItemEnhancementGameConfiguration itemEnhancementGameConfiguration)
    {
        Game = game;

        CanApplyBlessedArtifactBias = itemEnhancementGameConfiguration.CanApplyBlessedArtifactBias;
        CanApplyArtifactBiasSlaying = itemEnhancementGameConfiguration.CanApplyArtifactBiasSlaying;
        CanApplyBlowsBonus = itemEnhancementGameConfiguration.CanApplyBlowsBonus;
        CanReflectBoltsAndArrows = itemEnhancementGameConfiguration.CanReflectBoltsAndArrows;
        CanApplySlayingBonus = itemEnhancementGameConfiguration.CanApplySlayingBonus;
        CanApplyBonusArmorClassMiscPower = itemEnhancementGameConfiguration.CanApplyBonusArmorClassMiscPower;

        Key = itemEnhancementGameConfiguration.Key ?? itemEnhancementGameConfiguration.GetType().Name;
        Value = itemEnhancementGameConfiguration.Value;
        ApplicableItemFactoryBindingKeys = itemEnhancementGameConfiguration.ApplicableItemFactoryBindingKeys;
        AdditionalItemEnhancementWeightedRandomBindingKey = itemEnhancementGameConfiguration.AdditionalItemEnhancementWeightedRandomBindingKey;
        FriendlyName = itemEnhancementGameConfiguration.FriendlyName;
        BonusStrengthRollExpression = itemEnhancementGameConfiguration.BonusStrengthRollExpression;
        BonusIntelligenceRollExpression = itemEnhancementGameConfiguration.BonusIntelligenceRollExpression;
        BonusWisdomRollExpression = itemEnhancementGameConfiguration.BonusWisdomRollExpression;
        BonusDexterityRollExpression = itemEnhancementGameConfiguration.BonusDexterityRollExpression;
        BonusConstitutionRollExpression = itemEnhancementGameConfiguration.BonusConstitutionRollExpression;
        BonusCharismaRollExpression = itemEnhancementGameConfiguration.BonusCharismaRollExpression;
        BonusStealthRollExpression = itemEnhancementGameConfiguration.BonusStealthRollExpression;
        BonusSearchRollExpression = itemEnhancementGameConfiguration.BonusSearchRollExpression;
        BonusInfravisionRollExpression = itemEnhancementGameConfiguration.BonusInfravisionRollExpression;
        BonusTunnelRollExpression = itemEnhancementGameConfiguration.BonusTunnelRollExpression;
        BonusAttacksRollExpression = itemEnhancementGameConfiguration.BonusAttacksRollExpression;
        BonusSpeedRollExpression = itemEnhancementGameConfiguration.BonusSpeedRollExpression;
        BonusArmorClassRollExpression = itemEnhancementGameConfiguration.BonusArmorClassRollExpression;
        BonusHitsRollExpression = itemEnhancementGameConfiguration.BonusHitsRollExpression;
        BonusDamageRollExpression = itemEnhancementGameConfiguration.BonusDamageRollExpression;
        ActivationName = itemEnhancementGameConfiguration.ActivationName;
        Aggravate = itemEnhancementGameConfiguration.Aggravate;
        AntiTheft = itemEnhancementGameConfiguration.AntiTheft;
        ArtifactBiasWeightedRandomBindingKey = itemEnhancementGameConfiguration.ArtifactBiasWeightedRandomBindingKey;
        Blessed = itemEnhancementGameConfiguration.Blessed;
        Blows = itemEnhancementGameConfiguration.Blows;
        BrandAcid = itemEnhancementGameConfiguration.BrandAcid;
        BrandCold = itemEnhancementGameConfiguration.BrandCold;
        BrandElec = itemEnhancementGameConfiguration.BrandElec;
        BrandFire = itemEnhancementGameConfiguration.BrandFire;
        BrandPois = itemEnhancementGameConfiguration.BrandPois;
        Chaotic = itemEnhancementGameConfiguration.Chaotic;
        Cost = itemEnhancementGameConfiguration.Cost;
        IsCursed = itemEnhancementGameConfiguration.IsCursed;
        DamageDice = itemEnhancementGameConfiguration.DamageDice;
        DiceSides = itemEnhancementGameConfiguration.DiceSides;
        DrainExp = itemEnhancementGameConfiguration.DrainExp;
        DreadCurse = itemEnhancementGameConfiguration.DreadCurse;
        EasyKnow = itemEnhancementGameConfiguration.EasyKnow;
        Feather = itemEnhancementGameConfiguration.Feather;
        FreeAct = itemEnhancementGameConfiguration.FreeAct;
        HeavyCurse = itemEnhancementGameConfiguration.HeavyCurse;
        HideType = itemEnhancementGameConfiguration.HideType;
        HoldLife = itemEnhancementGameConfiguration.HoldLife;
        IgnoreAcid = itemEnhancementGameConfiguration.IgnoreAcid;
        IgnoreCold = itemEnhancementGameConfiguration.IgnoreCold;
        IgnoreElec = itemEnhancementGameConfiguration.IgnoreElec;
        IgnoreFire = itemEnhancementGameConfiguration.IgnoreFire;
        ImAcid = itemEnhancementGameConfiguration.ImAcid;
        ImCold = itemEnhancementGameConfiguration.ImCold;
        ImElec = itemEnhancementGameConfiguration.ImElec;
        ImFire = itemEnhancementGameConfiguration.ImFire;
        Impact = itemEnhancementGameConfiguration.Impact;
        NoMagic = itemEnhancementGameConfiguration.NoMagic;
        NoTele = itemEnhancementGameConfiguration.NoTele;
        PermaCurse = itemEnhancementGameConfiguration.PermaCurse;
        Radius = itemEnhancementGameConfiguration.Radius;
        Reflect = itemEnhancementGameConfiguration.Reflect;
        Regen = itemEnhancementGameConfiguration.Regen;
        ResAcid = itemEnhancementGameConfiguration.ResAcid;
        ResBlind = itemEnhancementGameConfiguration.ResBlind;
        ResChaos = itemEnhancementGameConfiguration.ResChaos;
        ResCold = itemEnhancementGameConfiguration.ResCold;
        ResConf = itemEnhancementGameConfiguration.ResConf;
        ResDark = itemEnhancementGameConfiguration.ResDark;
        ResDisen = itemEnhancementGameConfiguration.ResDisen;
        ResElec = itemEnhancementGameConfiguration.ResElec;
        ResFear = itemEnhancementGameConfiguration.ResFear;
        ResFire = itemEnhancementGameConfiguration.ResFire;
        ResLight = itemEnhancementGameConfiguration.ResLight;
        ResNether = itemEnhancementGameConfiguration.ResNether;
        ResNexus = itemEnhancementGameConfiguration.ResNexus;
        ResPois = itemEnhancementGameConfiguration.ResPois;
        ResShards = itemEnhancementGameConfiguration.ResShards;
        ResSound = itemEnhancementGameConfiguration.ResSound;
        SeeInvis = itemEnhancementGameConfiguration.SeeInvis;
        ShElec = itemEnhancementGameConfiguration.ShElec;
        ShFire = itemEnhancementGameConfiguration.ShFire;
        ShowMods = itemEnhancementGameConfiguration.ShowMods;
        SlayAnimal = itemEnhancementGameConfiguration.SlayAnimal;
        SlayDemon = itemEnhancementGameConfiguration.SlayDemon;
        SlayDragon = itemEnhancementGameConfiguration.SlayDragon;
        SlayEvil = itemEnhancementGameConfiguration.SlayEvil;
        SlayGiant = itemEnhancementGameConfiguration.SlayGiant;
        SlayOrc = itemEnhancementGameConfiguration.SlayOrc;
        SlayTroll = itemEnhancementGameConfiguration.SlayTroll;
        SlayUndead = itemEnhancementGameConfiguration.SlayUndead;
        SlowDigest = itemEnhancementGameConfiguration.SlowDigest;
        SustCha = itemEnhancementGameConfiguration.SustCha;
        SustCon = itemEnhancementGameConfiguration.SustCon;
        SustDex = itemEnhancementGameConfiguration.SustDex;
        SustInt = itemEnhancementGameConfiguration.SustInt;
        SustStr = itemEnhancementGameConfiguration.SustStr;
        SustWis = itemEnhancementGameConfiguration.SustWis;
        Telepathy = itemEnhancementGameConfiguration.Telepathy;
        Teleport = itemEnhancementGameConfiguration.Teleport;
        TreasureRating = itemEnhancementGameConfiguration.TreasureRating;
        Valueless = itemEnhancementGameConfiguration.Valueless;
        Vampiric = itemEnhancementGameConfiguration.Vampiric;
        Vorpal = itemEnhancementGameConfiguration.Vorpal;
        Weight = itemEnhancementGameConfiguration.Weight;
        Wraith = itemEnhancementGameConfiguration.Wraith;
        XtraMight = itemEnhancementGameConfiguration.XtraMight;
        XtraShots = itemEnhancementGameConfiguration.XtraShots;
    }

    /// <summary>
    /// Returns this <see cref="ItemEnhancement"/> object itself.  This method allows the <see cref="ItemEnhancement"/> and <see cref="ItemEnhancementWeightedRandom"/> to be specified in the <see cref="MappedItemEnhancement.ItemEnhancements"/>.
    /// </summary>
    /// <returns></returns>
    public ItemEnhancement? GetItemEnhancement() => this;

    /// <summary>
    /// Returns an immutable and fixed value set of item characteristics specified by this <see cref="ItemEnhancement"/> by computing fixed values from the expressions defined in these enhancements.
    /// </summary>
    /// <returns></returns>
    public ReadOnlyPropertySet GenerateItemCharacteristics()
    {
        EffectivePropertySet itemCharacteristics = new EffectivePropertySet()
        {
            CanApplyBlessedArtifactBias = CanApplyBlessedArtifactBias,
            CanApplyArtifactBiasSlaying = CanApplyArtifactBiasSlaying,
            CanApplyBlowsBonus = CanApplyBlowsBonus,
            CanReflectBoltsAndArrows = CanReflectBoltsAndArrows,
            CanApplySlayingBonus = CanApplySlayingBonus,
            CanApplyBonusArmorClassMiscPower = CanApplyBonusArmorClassMiscPower,

            BonusStrength = BonusStrengthRoll == null ? 0 : Game.ComputeIntegerExpression(BonusStrengthRoll).Value,
            BonusIntelligence = BonusIntelligenceRoll == null ? 0 : Game.ComputeIntegerExpression(BonusIntelligenceRoll).Value,
            BonusWisdom = BonusWisdomRoll == null ? 0 : Game.ComputeIntegerExpression(BonusWisdomRoll).Value,
            BonusDexterity = BonusDexterityRoll == null ? 0 : Game.ComputeIntegerExpression(BonusDexterityRoll).Value,
            BonusConstitution = BonusConstitutionRoll == null ? 0 : Game.ComputeIntegerExpression(BonusConstitutionRoll).Value,
            BonusCharisma = BonusCharismaRoll == null ? 0 : Game.ComputeIntegerExpression(BonusCharismaRoll).Value,
            BonusStealth = BonusStealthRoll == null ? 0 : Game.ComputeIntegerExpression(BonusStealthRoll).Value,
            BonusSearch = BonusSearchRoll == null ? 0 : Game.ComputeIntegerExpression(BonusSearchRoll).Value,
            BonusInfravision = BonusInfravisionRoll == null ? 0 : Game.ComputeIntegerExpression(BonusInfravisionRoll).Value,
            BonusTunnel = BonusTunnelRoll == null ? 0 : Game.ComputeIntegerExpression(BonusTunnelRoll).Value,
            BonusAttacks = BonusAttacksRoll == null ? 0 : Game.ComputeIntegerExpression(BonusAttacksRoll).Value,
            BonusSpeed = BonusSpeedRoll == null ? 0 : Game.ComputeIntegerExpression(BonusSpeedRoll).Value,

            BonusArmorClass = BonusArmorClassRoll == null ? 0 : Game.ComputeIntegerExpression(BonusArmorClassRoll).Value,
            BonusHits = BonusHitsRoll == null ? 0 : Game.ComputeIntegerExpression(BonusHitsRoll).Value,
            BonusDamage = BonusDamageRoll == null ? 0 : Game.ComputeIntegerExpression(BonusDamageRoll).Value,

            Activation = Activation,
            Aggravate = Aggravate,
            AntiTheft = AntiTheft,
            ArtifactBias = ArtifactBiasWeightedRandom?.ChooseOrDefault(),
            Blessed = Blessed,
            BrandAcid = BrandAcid,
            BrandCold = BrandCold,
            BrandElec = BrandElec,
            BrandFire = BrandFire,
            BrandPois = BrandPois,
            Chaotic = Chaotic,
            Cost = Cost,
            IsCursed = IsCursed,
            DamageDice = DamageDice,
            DiceSides = DiceSides,
            DrainExp = DrainExp,
            DreadCurse = DreadCurse,
            EasyKnow = EasyKnow,
            Feather = Feather,
            FreeAct = FreeAct,
            FriendlyName = FriendlyName,
            HeavyCurse = HeavyCurse,
            HideType = HideType,
            HoldLife = HoldLife,
            IgnoreAcid = IgnoreAcid,
            IgnoreCold = IgnoreCold,
            IgnoreElec = IgnoreElec,
            IgnoreFire = IgnoreFire,
            ImAcid = ImAcid,
            ImCold = ImCold,
            ImElec = ImElec,
            ImFire = ImFire,
            Impact = Impact,
            NoMagic = NoMagic,
            NoTele = NoTele,
            PermaCurse = PermaCurse,
            Radius = Radius,
            Reflect = Reflect,
            Regen = Regen,
            ResAcid = ResAcid,
            ResBlind = ResBlind,
            ResChaos = ResChaos,
            ResCold = ResCold,
            ResConf = ResConf,
            ResDark = ResDark,
            ResDisen = ResDisen,
            ResElec = ResElec,
            ResFear = ResFear,
            ResFire = ResFire,
            ResLight = ResLight,
            ResNether = ResNether,
            ResNexus = ResNexus,
            ResPois = ResPois,
            ResShards = ResShards,
            ResSound = ResSound,
            SeeInvis = SeeInvis,
            ShElec = ShElec,
            ShFire = ShFire,
            ShowMods = ShowMods,
            SlayAnimal = SlayAnimal,
            SlayDemon = SlayDemon,
            SlayDragon = SlayDragon,
            SlayEvil = SlayEvil,
            SlayGiant = SlayGiant,
            SlayOrc = SlayOrc,
            SlayTroll = SlayTroll,
            SlayUndead = SlayUndead,
            SlowDigest = SlowDigest,
            SustCha = SustCha,
            SustCon = SustCon,
            SustDex = SustDex,
            SustInt = SustInt,
            SustStr = SustStr,
            SustWis = SustWis,
            Telepathy = Telepathy,
            Teleport = Teleport,
            TreasureRating = TreasureRating,
            Value = Value,
            Valueless = Valueless,
            Vampiric = Vampiric,
            Vorpal = Vorpal,
            Weight = Weight,
            Wraith = Wraith,
            XtraMight = XtraMight,
            XtraShots = XtraShots,
        };
        return itemCharacteristics.ToReadOnly();
    }

    public string GetKey => Key;
    public bool AppliesTo(ItemFactory itemFactory) // TODO: This is only being used to apply slaying item enhancements.
    {
        if (ApplicableItemFactories == null)
        {
            return true;
        }
        return ApplicableItemFactories.Contains(itemFactory);
    }
    public void Bind()
    {
        Activation = Game.SingletonRepository.GetNullable<Activation>(ActivationName);
        BonusStrengthRoll = Game.ParseNullableNumericExpression(BonusStrengthRollExpression);
        BonusIntelligenceRoll = Game.ParseNullableNumericExpression(BonusIntelligenceRollExpression);
        BonusWisdomRoll = Game.ParseNullableNumericExpression(BonusWisdomRollExpression);
        BonusDexterityRoll = Game.ParseNullableNumericExpression(BonusDexterityRollExpression);
        BonusConstitutionRoll = Game.ParseNullableNumericExpression(BonusConstitutionRollExpression);
        BonusCharismaRoll = Game.ParseNullableNumericExpression(BonusCharismaRollExpression);
        BonusStealthRoll = Game.ParseNullableNumericExpression(BonusStealthRollExpression);
        BonusSearchRoll = Game.ParseNullableNumericExpression(BonusSearchRollExpression);
        BonusInfravisionRoll = Game.ParseNullableNumericExpression(BonusInfravisionRollExpression);
        BonusTunnelRoll = Game.ParseNullableNumericExpression(BonusTunnelRollExpression);
        BonusAttacksRoll = Game.ParseNullableNumericExpression(BonusAttacksRollExpression);
        BonusSpeedRoll = Game.ParseNullableNumericExpression(BonusSpeedRollExpression);

        BonusArmorClassRoll = Game.ParseNullableNumericExpression(BonusArmorClassRollExpression);
        BonusHitsRoll = Game.ParseNullableNumericExpression(BonusHitsRollExpression);
        BonusDamageRoll = Game.ParseNullableNumericExpression(BonusDamageRollExpression);

        AdditionalItemEnhancementWeightedRandom = Game.SingletonRepository.GetNullable<ItemEnhancementWeightedRandom>(AdditionalItemEnhancementWeightedRandomBindingKey);
        ArtifactBiasWeightedRandom = Game.SingletonRepository.GetNullable<ArtifactBiasWeightedRandom>(ArtifactBiasWeightedRandomBindingKey);
        ApplicableItemFactories = Game.SingletonRepository.GetNullable<ItemFactory>(ApplicableItemFactoryBindingKeys);
    }

    public string ToJson()
    {
        ItemEnhancementGameConfiguration itemEnhancementDefinition = new()
        {
            CanApplyBlessedArtifactBias = CanApplyBlessedArtifactBias,
            CanApplyArtifactBiasSlaying = CanApplyArtifactBiasSlaying,
            CanApplyBlowsBonus = CanApplyBlowsBonus,
            CanReflectBoltsAndArrows = CanReflectBoltsAndArrows,
            CanApplySlayingBonus = CanApplySlayingBonus,
            CanApplyBonusArmorClassMiscPower = CanApplyBonusArmorClassMiscPower,

            Key = Key,
            Value = Value,
            ApplicableItemFactoryBindingKeys = ApplicableItemFactoryBindingKeys,
            AdditionalItemEnhancementWeightedRandomBindingKey = AdditionalItemEnhancementWeightedRandomBindingKey,
            FriendlyName = FriendlyName,
            BonusStrengthRollExpression = BonusStrengthRollExpression,
            BonusIntelligenceRollExpression = BonusIntelligenceRollExpression,
            BonusWisdomRollExpression = BonusWisdomRollExpression,
            BonusDexterityRollExpression = BonusDexterityRollExpression,
            BonusConstitutionRollExpression = BonusConstitutionRollExpression,
            BonusCharismaRollExpression = BonusCharismaRollExpression,
            BonusStealthRollExpression = BonusStealthRollExpression,
            BonusSearchRollExpression = BonusSearchRollExpression,
            BonusInfravisionRollExpression = BonusInfravisionRollExpression,
            BonusTunnelRollExpression = BonusTunnelRollExpression,
            BonusAttacksRollExpression = BonusAttacksRollExpression,
            BonusSpeedRollExpression = BonusSpeedRollExpression,
            BonusArmorClassRollExpression = BonusArmorClassRollExpression,
            BonusHitsRollExpression = BonusHitsRollExpression,
            BonusDamageRollExpression = BonusDamageRollExpression,
            ActivationName = ActivationName,
            Aggravate = Aggravate,
            AntiTheft = AntiTheft,
            ArtifactBiasWeightedRandomBindingKey = ArtifactBiasWeightedRandomBindingKey,
            Blessed = Blessed,
            Blows = Blows,
            BrandAcid = BrandAcid,
            BrandCold = BrandCold,
            BrandElec = BrandElec,
            BrandFire = BrandFire,
            BrandPois = BrandPois,
            Chaotic = Chaotic,
            Cost = Cost,
            IsCursed = IsCursed,
            DamageDice = DamageDice,
            DiceSides = DiceSides,
            DrainExp = DrainExp,
            DreadCurse = DreadCurse,
            EasyKnow = EasyKnow,
            Feather = Feather,
            FreeAct = FreeAct,
            HeavyCurse = HeavyCurse,
            HideType = HideType,
            HoldLife = HoldLife,
            IgnoreAcid = IgnoreAcid,
            IgnoreCold = IgnoreCold,
            IgnoreElec = IgnoreElec,
            IgnoreFire = IgnoreFire,
            ImAcid = ImAcid,
            ImCold = ImCold,
            ImElec = ImElec,
            ImFire = ImFire,
            Impact = Impact,
            NoMagic = NoMagic,
            NoTele = NoTele,
            PermaCurse = PermaCurse,
            Radius = Radius,
            Reflect = Reflect,
            Regen = Regen,
            ResAcid = ResAcid,
            ResBlind = ResBlind,
            ResChaos = ResChaos,
            ResCold = ResCold,
            ResConf = ResConf,
            ResDark = ResDark,
            ResDisen = ResDisen,
            ResElec = ResElec,
            ResFear = ResFear,
            ResFire = ResFire,
            ResLight = ResLight,
            ResNether = ResNether,
            ResNexus = ResNexus,
            ResPois = ResPois,
            ResShards = ResShards,
            ResSound = ResSound,
            SeeInvis = SeeInvis,
            ShElec = ShElec,
            ShFire = ShFire,
            ShowMods = ShowMods,
            SlayAnimal = SlayAnimal,
            SlayDemon = SlayDemon,
            SlayDragon = SlayDragon,
            SlayEvil = SlayEvil,
            SlayGiant = SlayGiant,
            SlayOrc = SlayOrc,
            SlayTroll = SlayTroll,
            SlayUndead = SlayUndead,
            SlowDigest = SlowDigest,
            SustCha = SustCha,
            SustCon = SustCon,
            SustDex = SustDex,
            SustInt = SustInt,
            SustStr = SustStr,
            SustWis = SustWis,
            Telepathy = Telepathy,
            Teleport = Teleport,
            TreasureRating = TreasureRating,
            Valueless = Valueless,
            Vampiric = Vampiric,
            Vorpal = Vorpal,
            Weight = Weight,
            Wraith = Wraith,
            XtraMight = XtraMight,
            XtraShots = XtraShots,
        };
        return JsonSerializer.Serialize(itemEnhancementDefinition, Game.GetJsonSerializerOptions());
    }
    #endregion

    #region Bound Properties
    /// <inheritdoc />
    private Activation? Activation { get; set; }

    /// <summary>
    /// Returns a maximum value for a random amount of additional strength when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item.  Returns 0, by default.
    /// </summary>
    private Expression? BonusStrengthRoll { get; set; } = null;
    private Expression? BonusIntelligenceRoll { get; set; } = null;
    private Expression? BonusWisdomRoll { get; set; } = null;
    private Expression? BonusDexterityRoll { get; set; } = null;
    private Expression? BonusConstitutionRoll { get; set; } = null;
    private Expression? BonusCharismaRoll { get; set; } = null;
    private Expression? BonusStealthRoll { get; set; } = null;
    private Expression? BonusSearchRoll { get; set; } = null;
    private Expression? BonusInfravisionRoll { get; set; } = null;
    private Expression? BonusTunnelRoll { get; set; } = null;
    private Expression? BonusAttacksRoll { get; set; } = null;
    private Expression? BonusSpeedRoll { get; set; } = null;

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusArmorClass when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    private Expression? BonusArmorClassRoll { get; set; }

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusToHit when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    private Expression? BonusHitsRoll { get; set; } 

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusDamage when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    private Expression? BonusDamageRoll { get; set; }
    
    private ItemEnhancementWeightedRandom? AdditionalItemEnhancementWeightedRandom { get; set; }

    /// <inheritdoc />
    private ArtifactBiasWeightedRandom? ArtifactBiasWeightedRandom { get; set; }

    private ItemFactory[]? ApplicableItemFactories { get; set; } // TODO: This is contrary to the ItemEnhancement for ItemFactories.
    #endregion

    #region Unique ItemEnhancement Light-weight & Abstract Properties
    private string Key { get; }

    /// <summary>
    /// Returns the value of the enhancement.  Returns 0, by default.
    /// </summary>
    private int Value { get; } = 0;

    /// <summary>
    /// Returns the <see cref="ItemFactory"/> objects that this <see cref="ItemEnhancement"/> applies to; or null, if this <see cref="ItemEnhancement"/> can
    /// be applied to all <see cref="ItemFactory"/> objects.  This property is used to bind the <see cref="ApplicableItemFactories"/> property.
    /// </summary>
    private string[]? ApplicableItemFactoryBindingKeys { get; } = null;

    private string? AdditionalItemEnhancementWeightedRandomBindingKey { get; } = null;

    /// <summary>
    /// Returns the name of the rare item characteristics to append to the description of the original item, or null, to not modify the name.  Returns null, by default.
    /// </summary>
    private string? FriendlyName { get; } = null;
    #endregion

    #region ItemPropertySet Light-weight & Abstract Properties
    /// <summary>
    /// Returns true, if the item can apply a bonus armor class for miscellaneous power.  Only weapons return true.  Returns false, by default.
    /// </summary>
    private bool CanApplyBonusArmorClassMiscPower { get; } = false;

    /// <summary>
    /// Returns true, if the item can reflect bolts and arrows.  Returns false, by default.  Shields, helms, cloaks and hard armor return true.
    /// </summary>
    private bool CanReflectBoltsAndArrows { get; } = false;

    /// <summary>
    /// Returns true, if an item of this factory can have slaying bonus applied for biased artifacts.  Returns true, for all items except bows; which return false.
    /// </summary>
    private bool CanApplyArtifactBiasSlaying { get; } = true;

    /// <summary>
    /// Returns true, if an item of this factory can have be blessed for priestly biased artifacts.  Returns false, for all items except swords and polearms; which return false.
    /// </summary>
    private bool CanApplyBlessedArtifactBias { get; } = false;

    /// <summary>
    /// Returns true, if the item can apply a blows bonus.  Returns false, by default. Bows, return true.
    /// </summary>
    private bool CanApplyBlowsBonus { get; } = false;

    /// <summary>
    /// Returns true, if the item is capable of having slaying bonuses applied.  Only weapons return true.  Returns false by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private bool CanApplySlayingBonus { get; } = false;

    private string? BonusStrengthRollExpression { get; } = null;
    private string? BonusIntelligenceRollExpression { get; } = null;
    private string? BonusWisdomRollExpression { get; } = null;
    private string? BonusDexterityRollExpression { get; } = null;
    private string? BonusConstitutionRollExpression { get; } = null;
    private string? BonusCharismaRollExpression { get; } = null;
    private string? BonusStealthRollExpression { get; } = null;
    private string? BonusSearchRollExpression { get; } = null;
    private string? BonusInfravisionRollExpression { get; } = null;
    private string? BonusTunnelRollExpression { get; } = null;
    private string? BonusAttacksRollExpression { get; } = null;
    private string? BonusSpeedRollExpression { get; } = null;

    private string? BonusArmorClassRollExpression { get; } = null;

    private string? BonusHitsRollExpression { get; } = null;

    public string? BonusDamageRollExpression { get; } = null;

    /// <summary>
    /// Returns then name of an <see cref="Activation "/>, if the item can be activated; or null, if the item cannot be activated.  Dragon scale mail, rings of ice, acid and flames, the planar weapon, fixed artifacts and
    /// random artifacts may have an <see cref="Activation"/>.  Returns null, by default.  This property is used to bind the <see cref="Activation"/> property during the bind phase.
    /// </summary>
    /// <inheritdoc />
    private string? ActivationName { get; } = null;

    /// <inheritdoc />
    private bool Aggravate { get; } = false;
    
    /// <inheritdoc />
    private bool AntiTheft { get; } = false;

    private string? ArtifactBiasWeightedRandomBindingKey { get; } = null;
    
    /// <inheritdoc />
    private bool Blessed { get; } = false;

    /// <inheritdoc/>
    private bool Blows { get; } = false;
    
    /// <inheritdoc />
    private bool BrandAcid { get; } = false;
    
    /// <inheritdoc />
    private bool BrandCold { get; } = false;
    
    /// <inheritdoc />
    private bool BrandElec { get; } = false;
    
    /// <inheritdoc />
    private bool BrandFire { get; } = false;
    
    /// <inheritdoc />
    private bool BrandPois { get; } = false;
        
    /// <inheritdoc />
    private bool Chaotic { get; } = false;
    
    private int Cost { get; } = 0;
    
    /// <inheritdoc />
    private bool IsCursed { get; } = false;

    private int DamageDice { get; } = 0;
    private int DiceSides { get; } = 0;

    /// <inheritdoc />
    private bool DrainExp { get; } = false;
    
    /// <inheritdoc />
    private bool DreadCurse { get; } = false;
    
    /// <inheritdoc />
    private bool EasyKnow { get; } = false;
    
    /// <inheritdoc />
    private bool Feather { get; } = false;
    
    /// <inheritdoc />
    private bool FreeAct { get; } = false;
    
    /// <inheritdoc />
    private bool HeavyCurse { get; } = false;
    
    /// <inheritdoc />
    private bool HideType { get; } = false;
    
    /// <inheritdoc />
    private bool HoldLife { get; } = false;
    
    /// <inheritdoc />
    private bool IgnoreAcid { get; } = false;
    
    /// <inheritdoc />
    private bool IgnoreCold { get; } = false;
    
    /// <inheritdoc />
    private bool IgnoreElec { get; } = false;
    
    /// <inheritdoc />
    private bool IgnoreFire { get; } = false;
    
    /// <inheritdoc />
    private bool ImAcid { get; } = false;
    
    /// <inheritdoc />
    private bool ImCold { get; } = false;
    
    /// <inheritdoc />
    private bool ImElec { get; } = false;
    
    /// <inheritdoc />
    private bool ImFire { get; } = false;
    
    /// <inheritdoc />
    private bool Impact { get; } = false;
        
    /// <inheritdoc />
    private bool NoMagic { get; } = false;
    
    /// <inheritdoc />
    private bool NoTele { get; } = false;
    
    /// <inheritdoc />
    private bool PermaCurse { get; } = false;
    
    /// <inheritdoc />
    private int Radius { get; } = 0;
    
    /// <inheritdoc />
    private bool Reflect { get; } = false;
    
    /// <inheritdoc />
    private bool Regen { get; } = false;
    
    /// <inheritdoc />
    private bool ResAcid { get; } = false;
    
    /// <inheritdoc />
    private bool ResBlind { get; } = false;
    
    /// <inheritdoc />
    private bool ResChaos { get; } = false;
    
    /// <inheritdoc />
    private bool ResCold { get; } = false;
    
    /// <inheritdoc />
    private bool ResConf { get; } = false;
    
    /// <inheritdoc />
    private bool ResDark { get; } = false;
    
    /// <inheritdoc />
    private bool ResDisen { get; } = false;
    
    /// <inheritdoc />
    private bool ResElec { get; } = false;
    
    /// <inheritdoc />
    private bool ResFear { get; } = false;
    
    /// <inheritdoc />
    private bool ResFire { get; } = false;
    
    /// <inheritdoc />
    private bool ResLight { get; } = false;
    
    /// <inheritdoc />
    private bool ResNether { get; } = false;
    
    /// <inheritdoc />
    private bool ResNexus { get; } = false;
    
    /// <inheritdoc />
    private bool ResPois { get; } = false;
    
    /// <inheritdoc />
    private bool ResShards { get; } = false;
    
    /// <inheritdoc />
    private bool ResSound { get; } = false;
        
    /// <inheritdoc />
    private bool SeeInvis { get; } = false;
    
    /// <inheritdoc />
    private bool ShElec { get; } = false;
    
    /// <inheritdoc />
    private bool ShFire { get; } = false;
    
    /// <inheritdoc />
    private bool ShowMods { get; } = false;
    
    /// <inheritdoc />
    private bool SlayAnimal { get; } = false;
    
    /// <inheritdoc />
    private bool SlayDemon { get; } = false;
    
    /// <inheritdoc />
    private int SlayDragon { get; } = 1;
    
    /// <inheritdoc />
    private bool SlayEvil { get; } = false;
    
    /// <inheritdoc />
    private bool SlayGiant { get; } = false;
    
    /// <inheritdoc />
    private bool SlayOrc { get; } = false;
    
    /// <inheritdoc />
    private bool SlayTroll { get; } = false;
    
    /// <inheritdoc />
    private bool SlayUndead { get; } = false;
    
    /// <inheritdoc />
    private bool SlowDigest { get; } = false;
        
    /// <inheritdoc />
    private bool SustCha { get; } = false;
    
    /// <inheritdoc />
    private bool SustCon { get; } = false;
    
    /// <inheritdoc />
    private bool SustDex { get; } = false;
    
    /// <inheritdoc />
    private bool SustInt { get; } = false;
    
    /// <inheritdoc />
    private bool SustStr { get; } = false;
    
    /// <inheritdoc />
    private bool SustWis { get; } = false;
    
    /// <inheritdoc />
    private bool Telepathy { get; } = false;
    
    /// <inheritdoc />
    private bool Teleport { get; } = false;

    /// <inheritdoc />
    public int TreasureRating { get; } = 0;

    /// <inheritdoc />
    private bool Valueless { get; } = false;

    /// <inheritdoc />
    private bool Vampiric { get; } = false;
    
    /// <inheritdoc />
    private bool Vorpal { get; } = false;

    private int Weight { get; } = 0;
    
    /// <inheritdoc />
    private bool Wraith { get; } = false;
    
    /// <inheritdoc />
    private bool XtraMight { get; } = false;
    
    /// <inheritdoc />
    private bool XtraShots { get; } = false;
    #endregion
}
