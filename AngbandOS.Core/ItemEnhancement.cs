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
internal class ItemEnhancement : IGetKey, IToJson, IItemEnhancement
{
    #region API
    protected readonly Game Game;
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
        BonusHitRollExpression = itemEnhancementGameConfiguration.BonusHitRollExpression;
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
        Cha = itemEnhancementGameConfiguration.Cha;
        Chaotic = itemEnhancementGameConfiguration.Chaotic;
        Con = itemEnhancementGameConfiguration.Con;
        IsCursed = itemEnhancementGameConfiguration.IsCursed;
        Dex = itemEnhancementGameConfiguration.Dex;
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
        Infra = itemEnhancementGameConfiguration.Infra;
        InstaArt = itemEnhancementGameConfiguration.InstaArt;
        Int = itemEnhancementGameConfiguration.Int;
        KillDragon = itemEnhancementGameConfiguration.KillDragon;
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
        Search = itemEnhancementGameConfiguration.Search;
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
        Speed = itemEnhancementGameConfiguration.Speed;
        Stealth = itemEnhancementGameConfiguration.Stealth;
        Str = itemEnhancementGameConfiguration.Str;
        SustCha = itemEnhancementGameConfiguration.SustCha;
        SustCon = itemEnhancementGameConfiguration.SustCon;
        SustDex = itemEnhancementGameConfiguration.SustDex;
        SustInt = itemEnhancementGameConfiguration.SustInt;
        SustStr = itemEnhancementGameConfiguration.SustStr;
        SustWis = itemEnhancementGameConfiguration.SustWis;
        Telepathy = itemEnhancementGameConfiguration.Telepathy;
        Teleport = itemEnhancementGameConfiguration.Teleport;
        TreasureRating = itemEnhancementGameConfiguration.TreasureRating;
        Tunnel = itemEnhancementGameConfiguration.Tunnel;
        Valueless = itemEnhancementGameConfiguration.Valueless;
        Vampiric = itemEnhancementGameConfiguration.Vampiric;
        Vorpal = itemEnhancementGameConfiguration.Vorpal;
        Wis = itemEnhancementGameConfiguration.Wis;
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
    public EffectivePropertySet GenerateItemCharacteristics()
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
            BonusHit = BonusHitRoll == null ? 0 : Game.ComputeIntegerExpression(BonusHitRoll).Value,
            BonusDamage = BonusDamageRoll == null ? 0 : Game.ComputeIntegerExpression(BonusDamageRoll).Value,

            Activation = Activation,
            Aggravate = Aggravate,
            AntiTheft = AntiTheft,
            ArtifactBias = ArtifactBiasWeightedRandom?.ChooseOrDefault(),
            Blessed = Blessed,
            Blows = Blows,
            BrandAcid = BrandAcid,
            BrandCold = BrandCold,
            BrandElec = BrandElec,
            BrandFire = BrandFire,
            BrandPois = BrandPois,
            Cha = Cha,
            Chaotic = Chaotic,
            Con = Con,
            IsCursed = IsCursed,
            Dex = Dex,
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
            Infra = Infra,
            InstaArt = InstaArt,
            Int = Int,
            KillDragon = KillDragon,
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
            Search = Search,
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
            Speed = Speed,
            Stealth = Stealth,
            Str = Str,
            SustCha = SustCha,
            SustCon = SustCon,
            SustDex = SustDex,
            SustInt = SustInt,
            SustStr = SustStr,
            SustWis = SustWis,
            Telepathy = Telepathy,
            Teleport = Teleport,
            TreasureRating = TreasureRating,
            Tunnel = Tunnel,
            Value = Value,
            Valueless = Valueless,
            Vampiric = Vampiric,
            Vorpal = Vorpal,
            Wis = Wis,
            Wraith = Wraith,
            XtraMight = XtraMight,
            XtraShots = XtraShots,
        };
        return itemCharacteristics;
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
        BonusHitRoll = Game.ParseNullableNumericExpression(BonusHitRollExpression);
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
            BonusHitRollExpression = BonusHitRollExpression,
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
            Cha = Cha,
            Chaotic = Chaotic,
            Con = Con,
            IsCursed = IsCursed,
            Dex = Dex,
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
            Infra = Infra,
            InstaArt = InstaArt,
            Int = Int,
            KillDragon = KillDragon,
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
            Search = Search,
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
            Speed = Speed,
            Stealth = Stealth,
            Str = Str,
            SustCha = SustCha,
            SustCon = SustCon,
            SustDex = SustDex,
            SustInt = SustInt,
            SustStr = SustStr,
            SustWis = SustWis,
            Telepathy = Telepathy,
            Teleport = Teleport,
            TreasureRating = TreasureRating,
            Tunnel = Tunnel,
            Valueless = Valueless,
            Vampiric = Vampiric,
            Vorpal = Vorpal,
            Wis = Wis,
            Wraith = Wraith,
            XtraMight = XtraMight,
            XtraShots = XtraShots,
        };
        return JsonSerializer.Serialize(itemEnhancementDefinition, Game.GetJsonSerializerOptions());
    }
    #endregion

    #region Bound Properties
    /// <inheritdoc />
    public Activation? Activation { get; protected set; }

    /// <summary>
    /// Returns a maximum value for a random amount of additional strength when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item.  Returns 0, by default.
    /// </summary>
    public Expression? BonusStrengthRoll { get; private set; } = null;
    public Expression? BonusIntelligenceRoll { get; private set; } = null;
    public Expression? BonusWisdomRoll { get; private set; } = null;
    public Expression? BonusDexterityRoll { get; private set; } = null;
    public Expression? BonusConstitutionRoll { get; private set; } = null;
    public Expression? BonusCharismaRoll { get; private set; } = null;
    public Expression? BonusStealthRoll { get; private set; } = null;
    public Expression? BonusSearchRoll { get; private set; } = null;
    public Expression? BonusInfravisionRoll { get; private set; } = null;
    public Expression? BonusTunnelRoll { get; private set; } = null;
    public Expression? BonusAttacksRoll { get; private set; } = null;
    public Expression? BonusSpeedRoll { get; private set; } = null;

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusArmorClass when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    public Expression? BonusArmorClassRoll { get; private set; }

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusToHit when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    public Expression? BonusHitRoll { get; private set; } 

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusDamage when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    public Expression? BonusDamageRoll { get; private set; }
    
    public ItemEnhancementWeightedRandom? AdditionalItemEnhancementWeightedRandom { get; private set; }

    /// <inheritdoc />
    public ArtifactBiasWeightedRandom? ArtifactBiasWeightedRandom { get; private set; }

    public ItemFactory[]? ApplicableItemFactories { get; private set; } // TODO: This is contrary to the ItemEnhancement for ItemFactories.
    #endregion

    #region Unique ItemEnhancement Light-weight Virtual & Abstract Properties
    public virtual string Key { get; }

    /// <summary>
    /// Returns the value of the enhancement.  Returns 0, by default.
    /// </summary>
    public virtual int Value { get; } = 0;

    /// <summary>
    /// Returns the <see cref="ItemFactory"/> objects that this <see cref="ItemEnhancement"/> applies to; or null, if this <see cref="ItemEnhancement"/> can
    /// be applied to all <see cref="ItemFactory"/> objects.  This property is used to bind the <see cref="ApplicableItemFactories"/> property.
    /// </summary>
    protected virtual string[]? ApplicableItemFactoryBindingKeys { get; } = null;

    protected virtual string? AdditionalItemEnhancementWeightedRandomBindingKey { get; } = null;

    /// <summary>
    /// Returns the name of the rare item characteristics to append to the description of the original item, or null, to not modify the name.  Returns null, by default.
    /// </summary>
    public virtual string? FriendlyName { get; } = null;
    #endregion

    #region ItemPropertySet Light-weight Virtual & Abstract Properties
    /// <summary>
    /// Returns true, if the item can apply a bonus armor class for miscellaneous power.  Only weapons return true.  Returns false, by default.
    /// </summary>
    public virtual bool CanApplyBonusArmorClassMiscPower { get; } = false;

    /// <summary>
    /// Returns true, if the item can reflect bolts and arrows.  Returns false, by default.  Shields, helms, cloaks and hard armor return true.
    /// </summary>
    public virtual bool CanReflectBoltsAndArrows { get; } = false;

    /// <summary>
    /// Returns true, if an item of this factory can have slaying bonus applied for biased artifacts.  Returns true, for all items except bows; which return false.
    /// </summary>
    public virtual bool CanApplyArtifactBiasSlaying { get; } = true;

    /// <summary>
    /// Returns true, if an item of this factory can have be blessed for priestly biased artifacts.  Returns false, for all items except swords and polearms; which return false.
    /// </summary>
    public virtual bool CanApplyBlessedArtifactBias { get; } = false;

    /// <summary>
    /// Returns true, if the item can apply a blows bonus.  Returns false, by default. Bows, return true.
    /// </summary>
    public virtual bool CanApplyBlowsBonus { get; } = false;

    /// <summary>
    /// Returns true, if the item is capable of having slaying bonuses applied.  Only weapons return true.  Returns false by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual bool CanApplySlayingBonus { get; } = false;

    public virtual string? BonusStrengthRollExpression { get; } = null;
    public virtual string? BonusIntelligenceRollExpression { get; } = null;
    public virtual string? BonusWisdomRollExpression { get; } = null;
    public virtual string? BonusDexterityRollExpression { get; } = null;
    public virtual string? BonusConstitutionRollExpression { get; } = null;
    public virtual string? BonusCharismaRollExpression { get; } = null;
    public virtual string? BonusStealthRollExpression { get; } = null;
    public virtual string? BonusSearchRollExpression { get; } = null;
    public virtual string? BonusInfravisionRollExpression { get; } = null;
    public virtual string? BonusTunnelRollExpression { get; } = null;
    public virtual string? BonusAttacksRollExpression { get; } = null;
    public virtual string? BonusSpeedRollExpression { get; } = null;

    public virtual string? BonusArmorClassRollExpression { get; } = null;

    public virtual string? BonusHitRollExpression { get; } = null;

    public virtual string? BonusDamageRollExpression { get; } = null;

    /// <summary>
    /// Returns then name of an <see cref="Activation "/>, if the item can be activated; or null, if the item cannot be activated.  Dragon scale mail, rings of ice, acid and flames, the planar weapon, fixed artifacts and
    /// random artifacts may have an <see cref="Activation"/>.  Returns null, by default.  This property is used to bind the <see cref="Activation"/> property during the bind phase.
    /// </summary>
    /// <inheritdoc />
    protected virtual string? ActivationName { get; } = null;

    /// <inheritdoc />
    public virtual bool Aggravate { get; } = false;
    
    /// <inheritdoc />
    public virtual bool AntiTheft { get; } = false;

    protected virtual string? ArtifactBiasWeightedRandomBindingKey { get; } = null;
    
    /// <inheritdoc />
    public virtual bool Blessed { get; } = false;

    /// <inheritdoc/>
    public virtual bool Blows { get; } = false;
    
    /// <inheritdoc />
    public virtual bool BrandAcid { get; } = false;
    
    /// <inheritdoc />
    public virtual bool BrandCold { get; } = false;
    
    /// <inheritdoc />
    public virtual bool BrandElec { get; } = false;
    
    /// <inheritdoc />
    public virtual bool BrandFire { get; } = false;
    
    /// <inheritdoc />
    public virtual bool BrandPois { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Cha { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Chaotic { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Con { get; } = false;
    
    /// <inheritdoc />
    public virtual bool IsCursed { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Dex { get; } = false;
    
    /// <inheritdoc />
    public virtual bool DrainExp { get; } = false;
    
    /// <inheritdoc />
    public virtual bool DreadCurse { get; } = false;
    
    /// <inheritdoc />
    public virtual bool EasyKnow { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Feather { get; } = false;
    
    /// <inheritdoc />
    public virtual bool FreeAct { get; } = false;
    
    /// <inheritdoc />
    public virtual bool HeavyCurse { get; } = false;
    
    /// <inheritdoc />
    public virtual bool HideType { get; } = false;
    
    /// <inheritdoc />
    public virtual bool HoldLife { get; } = false;
    
    /// <inheritdoc />
    public virtual bool IgnoreAcid { get; } = false;
    
    /// <inheritdoc />
    public virtual bool IgnoreCold { get; } = false;
    
    /// <inheritdoc />
    public virtual bool IgnoreElec { get; } = false;
    
    /// <inheritdoc />
    public virtual bool IgnoreFire { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ImAcid { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ImCold { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ImElec { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ImFire { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Impact { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Infra { get; } = false;
    
    /// <inheritdoc />
    public virtual bool InstaArt { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Int { get; } = false;
    
    /// <inheritdoc />
    public virtual bool KillDragon { get; } = false;
    
    /// <inheritdoc />
    public virtual bool NoMagic { get; } = false;
    
    /// <inheritdoc />
    public virtual bool NoTele { get; } = false;
    
    /// <inheritdoc />
    public virtual bool PermaCurse { get; } = false;
    
    /// <inheritdoc />
    public virtual int Radius { get; } = 0;
    
    /// <inheritdoc />
    public virtual bool Reflect { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Regen { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ResAcid { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ResBlind { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ResChaos { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ResCold { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ResConf { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ResDark { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ResDisen { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ResElec { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ResFear { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ResFire { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ResLight { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ResNether { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ResNexus { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ResPois { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ResShards { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ResSound { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Search { get; } = false;
    
    /// <inheritdoc />
    public virtual bool SeeInvis { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ShElec { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ShFire { get; } = false;
    
    /// <inheritdoc />
    public virtual bool ShowMods { get; } = false;
    
    /// <inheritdoc />
    public virtual bool SlayAnimal { get; } = false;
    
    /// <inheritdoc />
    public virtual bool SlayDemon { get; } = false;
    
    /// <inheritdoc />
    public virtual bool SlayDragon { get; } = false;
    
    /// <inheritdoc />
    public virtual bool SlayEvil { get; } = false;
    
    /// <inheritdoc />
    public virtual bool SlayGiant { get; } = false;
    
    /// <inheritdoc />
    public virtual bool SlayOrc { get; } = false;
    
    /// <inheritdoc />
    public virtual bool SlayTroll { get; } = false;
    
    /// <inheritdoc />
    public virtual bool SlayUndead { get; } = false;
    
    /// <inheritdoc />
    public virtual bool SlowDigest { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Speed { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Stealth { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Str { get; } = false;
    
    /// <inheritdoc />
    public virtual bool SustCha { get; } = false;
    
    /// <inheritdoc />
    public virtual bool SustCon { get; } = false;
    
    /// <inheritdoc />
    public virtual bool SustDex { get; } = false;
    
    /// <inheritdoc />
    public virtual bool SustInt { get; } = false;
    
    /// <inheritdoc />
    public virtual bool SustStr { get; } = false;
    
    /// <inheritdoc />
    public virtual bool SustWis { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Telepathy { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Teleport { get; } = false;

    /// <inheritdoc />
    public virtual int TreasureRating { get; } = 0;

    /// <inheritdoc />
    public virtual bool Tunnel { get; } = false;

    /// <inheritdoc />
    public virtual bool Valueless { get; } = false;

    /// <inheritdoc />
    public virtual bool Vampiric { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Vorpal { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Wis { get; } = false;
    
    /// <inheritdoc />
    public virtual bool Wraith { get; } = false;
    
    /// <inheritdoc />
    public virtual bool XtraMight { get; } = false;
    
    /// <inheritdoc />
    public virtual bool XtraShots { get; } = false;
    #endregion
}
