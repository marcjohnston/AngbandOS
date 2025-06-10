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
internal abstract class ItemEnhancement : IGetKey
{
    #region API
    protected readonly Game Game;
    protected ItemEnhancement(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns an immutable and fixed value set of item characteristics specified by this <see cref="ItemEnhancement"/> by computing fixed values from the expressions defined in these enhancements.
    /// </summary>
    /// <returns></returns>
    public RoItemPropertySet GenerateItemCharacteristics()
    {
        RoItemPropertySet itemCharacteristics = new RoItemPropertySet()
        {
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
    public bool AppliesTo(ItemFactory itemFactory)
    {
        if (ApplicableItemFactories == null)
        {
            return true;
        }
        return ApplicableItemFactories.Contains(itemFactory);
    }

    public virtual void Bind()
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

    public virtual string ToJson()
    {
        ItemEnhancementGameConfiguration itemEnhancementDefinition = new()
        {
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

    public ItemFactory[]? ApplicableItemFactories { get; private set; }
    #endregion

    #region Unique ItemEnhancement Light-weight Virtual & Abstract Properties
    public virtual string Key => GetType().Name;

    /// <summary>
    /// Returns the value of the enhancement.
    /// </summary>
    public virtual int? Value => null;

    /// <summary>
    /// Returns the <see cref="ItemFactory"/> objects that this <see cref="ItemEnhancement"/> applies to; or null, if this <see cref="ItemEnhancement"/> can
    /// be applied to all <see cref="ItemFactory"/> objects.  This property is used to bind the <see cref="ApplicableItemFactories"/> property.
    /// </summary>
    protected virtual string[]? ApplicableItemFactoryBindingKeys => null;

    protected virtual string? AdditionalItemEnhancementWeightedRandomBindingKey => null;

    /// <summary>
    /// Returns the name of the rare item characteristics to append to the description of the original item, or null, to not modify the name.  Returns null, by default.
    /// </summary>
    public virtual string? FriendlyName => null;
    #endregion

    #region ItemPropertySet Light-weight Virtual & Abstract Properties
    protected virtual string? BonusStrengthRollExpression => null;
    protected virtual string? BonusIntelligenceRollExpression => null;
    protected virtual string? BonusWisdomRollExpression => null;
    protected virtual string? BonusDexterityRollExpression => null;
    protected virtual string? BonusConstitutionRollExpression => null;
    protected virtual string? BonusCharismaRollExpression => null;
    protected virtual string? BonusStealthRollExpression => null;
    protected virtual string? BonusSearchRollExpression => null;
    protected virtual string? BonusInfravisionRollExpression => null;
    protected virtual string? BonusTunnelRollExpression => null;
    protected virtual string? BonusAttacksRollExpression => null;
    protected virtual string? BonusSpeedRollExpression => null;

    protected virtual string? BonusArmorClassRollExpression => null;

    protected virtual string? BonusHitRollExpression => null;

    protected virtual string? BonusDamageRollExpression => null;

    /// <summary>
    /// Returns then name of an <see cref="Activation "/>, if the item can be activated; or null, if the item cannot be activated.  Dragon scale mail, rings of ice, acid and flames, the planar weapon, fixed artifacts and
    /// random artifacts may have an <see cref="Activation"/>.  Returns null, by default.  This property is used to bind the <see cref="Activation"/> property during the bind phase.
    /// </summary>
    /// <inheritdoc />
    protected virtual string? ActivationName => null;

    /// <inheritdoc />
    public virtual bool Aggravate => false;
    
    /// <inheritdoc />
    public virtual bool AntiTheft => false;

    protected virtual string? ArtifactBiasWeightedRandomBindingKey => null;
    
    /// <inheritdoc />
    public virtual bool Blessed => false;

    /// <inheritdoc/>
    public virtual bool Blows => false;
    
    /// <inheritdoc />
    public virtual bool BrandAcid => false;
    
    /// <inheritdoc />
    public virtual bool BrandCold => false;
    
    /// <inheritdoc />
    public virtual bool BrandElec => false;
    
    /// <inheritdoc />
    public virtual bool BrandFire => false;
    
    /// <inheritdoc />
    public virtual bool BrandPois => false;
    
    /// <inheritdoc />
    public virtual bool Cha => false;
    
    /// <inheritdoc />
    public virtual bool Chaotic => false;
    
    /// <inheritdoc />
    public virtual bool Con => false;
    
    /// <inheritdoc />
    public virtual bool IsCursed => false;
    
    /// <inheritdoc />
    public virtual bool Dex => false;
    
    /// <inheritdoc />
    public virtual bool DrainExp => false;
    
    /// <inheritdoc />
    public virtual bool DreadCurse => false;
    
    /// <inheritdoc />
    public virtual bool EasyKnow => false;
    
    /// <inheritdoc />
    public virtual bool Feather => false;
    
    /// <inheritdoc />
    public virtual bool FreeAct => false;
    
    /// <inheritdoc />
    public virtual bool HeavyCurse => false;
    
    /// <inheritdoc />
    public virtual bool HideType => false;
    
    /// <inheritdoc />
    public virtual bool HoldLife => false;
    
    /// <inheritdoc />
    public virtual bool IgnoreAcid => false;
    
    /// <inheritdoc />
    public virtual bool IgnoreCold => false;
    
    /// <inheritdoc />
    public virtual bool IgnoreElec => false;
    
    /// <inheritdoc />
    public virtual bool IgnoreFire => false;
    
    /// <inheritdoc />
    public virtual bool ImAcid => false;
    
    /// <inheritdoc />
    public virtual bool ImCold => false;
    
    /// <inheritdoc />
    public virtual bool ImElec => false;
    
    /// <inheritdoc />
    public virtual bool ImFire => false;
    
    /// <inheritdoc />
    public virtual bool Impact => false;
    
    /// <inheritdoc />
    public virtual bool Infra => false;
    
    /// <inheritdoc />
    public virtual bool InstaArt => false;
    
    /// <inheritdoc />
    public virtual bool Int => false;
    
    /// <inheritdoc />
    public virtual bool KillDragon => false;
    
    /// <inheritdoc />
    public virtual bool NoMagic => false;
    
    /// <inheritdoc />
    public virtual bool NoTele => false;
    
    /// <inheritdoc />
    public virtual bool PermaCurse => false;
    
    /// <inheritdoc />
    public virtual int Radius => 0;
    
    /// <inheritdoc />
    public virtual bool Reflect => false;
    
    /// <inheritdoc />
    public virtual bool Regen => false;
    
    /// <inheritdoc />
    public virtual bool ResAcid => false;
    
    /// <inheritdoc />
    public virtual bool ResBlind => false;
    
    /// <inheritdoc />
    public virtual bool ResChaos => false;
    
    /// <inheritdoc />
    public virtual bool ResCold => false;
    
    /// <inheritdoc />
    public virtual bool ResConf => false;
    
    /// <inheritdoc />
    public virtual bool ResDark => false;
    
    /// <inheritdoc />
    public virtual bool ResDisen => false;
    
    /// <inheritdoc />
    public virtual bool ResElec => false;
    
    /// <inheritdoc />
    public virtual bool ResFear => false;
    
    /// <inheritdoc />
    public virtual bool ResFire => false;
    
    /// <inheritdoc />
    public virtual bool ResLight => false;
    
    /// <inheritdoc />
    public virtual bool ResNether => false;
    
    /// <inheritdoc />
    public virtual bool ResNexus => false;
    
    /// <inheritdoc />
    public virtual bool ResPois => false;
    
    /// <inheritdoc />
    public virtual bool ResShards => false;
    
    /// <inheritdoc />
    public virtual bool ResSound => false;
    
    /// <inheritdoc />
    public virtual bool Search => false;
    
    /// <inheritdoc />
    public virtual bool SeeInvis => false;
    
    /// <inheritdoc />
    public virtual bool ShElec => false;
    
    /// <inheritdoc />
    public virtual bool ShFire => false;
    
    /// <inheritdoc />
    public virtual bool ShowMods => false;
    
    /// <inheritdoc />
    public virtual bool SlayAnimal => false;
    
    /// <inheritdoc />
    public virtual bool SlayDemon => false;
    
    /// <inheritdoc />
    public virtual bool SlayDragon => false;
    
    /// <inheritdoc />
    public virtual bool SlayEvil => false;
    
    /// <inheritdoc />
    public virtual bool SlayGiant => false;
    
    /// <inheritdoc />
    public virtual bool SlayOrc => false;
    
    /// <inheritdoc />
    public virtual bool SlayTroll => false;
    
    /// <inheritdoc />
    public virtual bool SlayUndead => false;
    
    /// <inheritdoc />
    public virtual bool SlowDigest => false;
    
    /// <inheritdoc />
    public virtual bool Speed => false;
    
    /// <inheritdoc />
    public virtual bool Stealth => false;
    
    /// <inheritdoc />
    public virtual bool Str => false;
    
    /// <inheritdoc />
    public virtual bool SustCha => false;
    
    /// <inheritdoc />
    public virtual bool SustCon => false;
    
    /// <inheritdoc />
    public virtual bool SustDex => false;
    
    /// <inheritdoc />
    public virtual bool SustInt => false;
    
    /// <inheritdoc />
    public virtual bool SustStr => false;
    
    /// <inheritdoc />
    public virtual bool SustWis => false;
    
    /// <inheritdoc />
    public virtual bool Telepathy => false;
    
    /// <inheritdoc />
    public virtual bool Teleport => false;

    /// <inheritdoc />
    public virtual int TreasureRating => 0;

    /// <inheritdoc />
    public virtual bool Tunnel => false;
    
    /// <inheritdoc />
    public virtual bool Vampiric => false;
    
    /// <inheritdoc />
    public virtual bool Vorpal => false;
    
    /// <inheritdoc />
    public virtual bool Wis => false;
    
    /// <inheritdoc />
    public virtual bool Wraith => false;
    
    /// <inheritdoc />
    public virtual bool XtraMight => false;
    
    /// <inheritdoc />
    public virtual bool XtraShots => false;
    #endregion
}
