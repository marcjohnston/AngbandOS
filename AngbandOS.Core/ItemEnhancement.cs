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
    #region Constructors
    public ItemEnhancement(Game game, ItemEnhancementGameConfiguration itemEnhancementGameConfiguration)
    {
        Game = game;
        Key = itemEnhancementGameConfiguration.Key ?? itemEnhancementGameConfiguration.GetType().Name;

        ActivationName = itemEnhancementGameConfiguration.ActivationName;
        AdditionalItemEnhancementWeightedRandomBindingKey = itemEnhancementGameConfiguration.AdditionalItemEnhancementWeightedRandomBindingKey;
        Aggravate = itemEnhancementGameConfiguration.Aggravate;
        AntiTheft = itemEnhancementGameConfiguration.AntiTheft;
        ApplicableItemFactoryBindingKeys = itemEnhancementGameConfiguration.ApplicableItemFactoryBindingKeys;
        ArtifactBiasWeightedRandomBindingKey = itemEnhancementGameConfiguration.ArtifactBiasWeightedRandomBindingKey;
        Blessed = itemEnhancementGameConfiguration.Blessed;
        Blows = itemEnhancementGameConfiguration.Blows;
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
        BrandAcid = itemEnhancementGameConfiguration.BrandAcid;
        BrandCold = itemEnhancementGameConfiguration.BrandCold;
        BrandElec = itemEnhancementGameConfiguration.BrandElec;
        BrandFire = itemEnhancementGameConfiguration.BrandFire;
        BrandPois = itemEnhancementGameConfiguration.BrandPois;
        CanApplyBlessedArtifactBias = itemEnhancementGameConfiguration.CanApplyBlessedArtifactBias;
        CanApplyArtifactBiasSlaying = itemEnhancementGameConfiguration.CanApplyArtifactBiasSlaying;
        CanApplyBlowsBonus = itemEnhancementGameConfiguration.CanApplyBlowsBonus;
        CanReflectBoltsAndArrows = itemEnhancementGameConfiguration.CanReflectBoltsAndArrows;
        CanApplySlayingBonus = itemEnhancementGameConfiguration.CanApplySlayingBonus;
        CanApplyBonusArmorClassMiscPower = itemEnhancementGameConfiguration.CanApplyBonusArmorClassMiscPower;
        Chaotic = itemEnhancementGameConfiguration.Chaotic;
        Color = itemEnhancementGameConfiguration.Color;
        DamageDice = itemEnhancementGameConfiguration.DamageDice;
        DiceSides = itemEnhancementGameConfiguration.DiceSides;
        DrainExp = itemEnhancementGameConfiguration.DrainExp;
        DreadCurse = itemEnhancementGameConfiguration.DreadCurse;
        EasyKnow = itemEnhancementGameConfiguration.EasyKnow;
        Feather = itemEnhancementGameConfiguration.Feather;
        FreeAct = itemEnhancementGameConfiguration.FreeAct;
        FriendlyName = itemEnhancementGameConfiguration.FriendlyName;
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
        IsCursed = itemEnhancementGameConfiguration.IsCursed;
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
        Value = itemEnhancementGameConfiguration.Value;
        Valueless = itemEnhancementGameConfiguration.Valueless;
        Vampiric = itemEnhancementGameConfiguration.Vampiric;
        Vorpal1InChance = itemEnhancementGameConfiguration.Vorpal1InChance;
        Weight = itemEnhancementGameConfiguration.Weight;
        Wraith = itemEnhancementGameConfiguration.Wraith;
        XtraMight = itemEnhancementGameConfiguration.XtraMight;
        XtraShots = itemEnhancementGameConfiguration.XtraShots;
    }
    #endregion

    #region API
    private readonly Game Game;

    /// <summary>
    /// Returns this <see cref="ItemEnhancement"/> object itself.  This method allows the <see cref="ItemEnhancement"/> and <see cref="ItemEnhancementWeightedRandom"/> to be specified in the <see cref="MappedItemEnhancement.ItemEnhancements"/>.
    /// </summary>
    /// <returns></returns>
    public ItemEnhancement? GetItemEnhancement() => this;

    /// <summary>
    /// Returns an immutable and fixed value set of item characteristics specified by this <see cref="ItemEnhancement"/> by computing fixed values from the expressions defined in these enhancements.
    /// </summary>
    /// <returns></returns>
    public ReadOnlyAttributeSet GenerateItemCharacteristics()
    {
        EffectiveAttributeSet itemCharacteristics = new EffectiveAttributeSet();
        itemCharacteristics.SetIntValue(AttributeEnum.BonusStrength, BonusStrengthRoll == null ? 0 : Game.ComputeIntegerExpression(BonusStrengthRoll).Value);
        itemCharacteristics.SetIntValue(AttributeEnum.BonusIntelligence, BonusIntelligenceRoll == null ? 0 : Game.ComputeIntegerExpression(BonusIntelligenceRoll).Value);
        itemCharacteristics.SetIntValue(AttributeEnum.BonusWisdom, BonusWisdomRoll == null ? 0 : Game.ComputeIntegerExpression(BonusWisdomRoll).Value);
        itemCharacteristics.SetIntValue(AttributeEnum.BonusDexterity, BonusDexterityRoll == null ? 0 : Game.ComputeIntegerExpression(BonusDexterityRoll).Value);
        itemCharacteristics.SetIntValue(AttributeEnum.BonusConstitution, BonusConstitutionRoll == null ? 0 : Game.ComputeIntegerExpression(BonusConstitutionRoll).Value);
        itemCharacteristics.SetIntValue(AttributeEnum.BonusCharisma, BonusCharismaRoll == null ? 0 : Game.ComputeIntegerExpression(BonusCharismaRoll).Value);
        itemCharacteristics.SetIntValue(AttributeEnum.BonusStealth, BonusStealthRoll == null ? 0 : Game.ComputeIntegerExpression(BonusStealthRoll).Value);
        itemCharacteristics.SetIntValue(AttributeEnum.BonusSearch, BonusSearchRoll == null ? 0 : Game.ComputeIntegerExpression(BonusSearchRoll).Value);
        itemCharacteristics.SetIntValue(AttributeEnum.BonusInfravision, BonusInfravisionRoll == null ? 0 : Game.ComputeIntegerExpression(BonusInfravisionRoll).Value);
        itemCharacteristics.SetIntValue(AttributeEnum.BonusTunnel, BonusTunnelRoll == null ? 0 : Game.ComputeIntegerExpression(BonusTunnelRoll).Value);
        itemCharacteristics.SetIntValue(AttributeEnum.BonusAttacks, BonusAttacksRoll == null ? 0 : Game.ComputeIntegerExpression(BonusAttacksRoll).Value);
        itemCharacteristics.SetIntValue(AttributeEnum.BonusSpeed, BonusSpeedRoll == null ? 0 : Game.ComputeIntegerExpression(BonusSpeedRoll).Value);
        itemCharacteristics.SetIntValue(AttributeEnum.BonusArmorClass, BonusArmorClassRoll == null ? 0 : Game.ComputeIntegerExpression(BonusArmorClassRoll).Value);
        itemCharacteristics.SetIntValue(AttributeEnum.BonusHits, BonusHitsRoll == null ? 0 : Game.ComputeIntegerExpression(BonusHitsRoll).Value);
        itemCharacteristics.SetIntValue(AttributeEnum.BonusDamage, BonusDamageRoll == null ? 0 : Game.ComputeIntegerExpression(BonusDamageRoll).Value);
        itemCharacteristics.SetReferenceValue(AttributeEnum.ArtifactBias, ArtifactBiasWeightedRandom?.ChooseOrDefault());

        itemCharacteristics.SetBoolValue(AttributeEnum.CanApplyBlessedArtifactBias, CanApplyBlessedArtifactBias);
        itemCharacteristics.SetBoolValue(AttributeEnum.CanApplyArtifactBiasSlaying, CanApplyArtifactBiasSlaying);
        itemCharacteristics.SetBoolValue(AttributeEnum.CanApplyBlowsBonus, CanApplyBlowsBonus);
        itemCharacteristics.SetBoolValue(AttributeEnum.CanReflectBoltsAndArrows, CanReflectBoltsAndArrows);
        itemCharacteristics.SetBoolValue(AttributeEnum.CanApplySlayingBonus, CanApplySlayingBonus);
        itemCharacteristics.SetBoolValue(AttributeEnum.CanApplyBonusArmorClassMiscPower, CanApplyBonusArmorClassMiscPower);
        itemCharacteristics.SetReferenceValue(AttributeEnum.Activation, Activation);
        itemCharacteristics.SetBoolValue(AttributeEnum.Aggravate, Aggravate);
        itemCharacteristics.SetBoolValue(AttributeEnum.AntiTheft, AntiTheft);
        itemCharacteristics.SetBoolValue(AttributeEnum.Blessed, Blessed);
        itemCharacteristics.SetBoolValue(AttributeEnum.BrandAcid, BrandAcid);
        itemCharacteristics.SetBoolValue(AttributeEnum.BrandCold, BrandCold);
        itemCharacteristics.SetBoolValue(AttributeEnum.BrandElec, BrandElec);
        itemCharacteristics.SetBoolValue(AttributeEnum.BrandFire, BrandFire);
        itemCharacteristics.SetBoolValue(AttributeEnum.BrandPois, BrandPois);
        itemCharacteristics.SetBoolValue(AttributeEnum.Chaotic, Chaotic);
        itemCharacteristics.SetColorValue(AttributeEnum.Color, Color);
        itemCharacteristics.SetBoolValue(AttributeEnum.IsCursed, IsCursed);
        itemCharacteristics.SetIntValue(AttributeEnum.DamageDice, DamageDice);
        itemCharacteristics.SetIntValue(AttributeEnum.DiceSides, DiceSides);
        itemCharacteristics.SetBoolValue(AttributeEnum.DrainExp, DrainExp);
        itemCharacteristics.SetBoolValue(AttributeEnum.DreadCurse, DreadCurse);
        itemCharacteristics.SetBoolValue(AttributeEnum.EasyKnow, EasyKnow);
        itemCharacteristics.SetBoolValue(AttributeEnum.Feather, Feather);
        itemCharacteristics.SetBoolValue(AttributeEnum.FreeAct, FreeAct);
        itemCharacteristics.SetReferenceValue(AttributeEnum.FriendlyName, FriendlyName);
        itemCharacteristics.SetBoolValue(AttributeEnum.HeavyCurse, HeavyCurse);
        itemCharacteristics.SetBoolValue(AttributeEnum.HideType, HideType);
        itemCharacteristics.SetBoolValue(AttributeEnum.HoldLife, HoldLife);
        itemCharacteristics.SetBoolValue(AttributeEnum.IgnoreAcid, IgnoreAcid);
        itemCharacteristics.SetBoolValue(AttributeEnum.IgnoreCold, IgnoreCold);
        itemCharacteristics.SetBoolValue(AttributeEnum.IgnoreElec, IgnoreElec);
        itemCharacteristics.SetBoolValue(AttributeEnum.IgnoreFire, IgnoreFire);
        itemCharacteristics.SetBoolValue(AttributeEnum.ImAcid, ImAcid);
        itemCharacteristics.SetBoolValue(AttributeEnum.ImCold, ImCold);
        itemCharacteristics.SetBoolValue(AttributeEnum.ImElec, ImElec);
        itemCharacteristics.SetBoolValue(AttributeEnum.ImFire, ImFire);
        itemCharacteristics.SetBoolValue(AttributeEnum.Impact, Impact);
        itemCharacteristics.SetBoolValue(AttributeEnum.NoMagic, NoMagic);
        itemCharacteristics.SetBoolValue(AttributeEnum.NoTele, NoTele);
        itemCharacteristics.SetBoolValue(AttributeEnum.PermaCurse, PermaCurse);
        itemCharacteristics.SetIntValue(AttributeEnum.Radius, Radius);
        itemCharacteristics.SetBoolValue(AttributeEnum.Reflect, Reflect);
        itemCharacteristics.SetBoolValue(AttributeEnum.Regen, Regen);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResAcid, ResAcid);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResBlind, ResBlind);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResChaos, ResChaos);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResCold, ResCold);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResConf, ResConf);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResDark, ResDark);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResDisen, ResDisen);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResElec, ResElec);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResFear, ResFear);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResFire, ResFire);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResLight, ResLight);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResNether, ResNether);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResNexus, ResNexus);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResPois, ResPois);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResShards, ResShards);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResSound, ResSound);
        itemCharacteristics.SetBoolValue(AttributeEnum.SeeInvis, SeeInvis);
        itemCharacteristics.SetBoolValue(AttributeEnum.ShElec, ShElec);
        itemCharacteristics.SetBoolValue(AttributeEnum.ShFire, ShFire);
        itemCharacteristics.SetBoolValue(AttributeEnum.ShowMods, ShowMods);
        itemCharacteristics.SetBoolValue(AttributeEnum.SlayAnimal, SlayAnimal);
        itemCharacteristics.SetBoolValue(AttributeEnum.SlayDemon, SlayDemon);
        itemCharacteristics.SetIntValue(AttributeEnum.SlayDragon, SlayDragon);
        itemCharacteristics.SetBoolValue(AttributeEnum.SlayEvil, SlayEvil);
        itemCharacteristics.SetBoolValue(AttributeEnum.SlayGiant, SlayGiant);
        itemCharacteristics.SetBoolValue(AttributeEnum.SlayOrc, SlayOrc);
        itemCharacteristics.SetBoolValue(AttributeEnum.SlayTroll, SlayTroll);
        itemCharacteristics.SetBoolValue(AttributeEnum.SlayUndead, SlayUndead);
        itemCharacteristics.SetBoolValue(AttributeEnum.SlowDigest, SlowDigest);
        itemCharacteristics.SetBoolValue(AttributeEnum.SustCha, SustCha);
        itemCharacteristics.SetBoolValue(AttributeEnum.SustCon, SustCon);
        itemCharacteristics.SetBoolValue(AttributeEnum.SustDex, SustDex);
        itemCharacteristics.SetBoolValue(AttributeEnum.SustInt, SustInt);
        itemCharacteristics.SetBoolValue(AttributeEnum.SustStr, SustStr);
        itemCharacteristics.SetBoolValue(AttributeEnum.SustWis, SustWis);
        itemCharacteristics.SetBoolValue(AttributeEnum.Telepathy, Telepathy);
        itemCharacteristics.SetBoolValue(AttributeEnum.Teleport, Teleport);
        itemCharacteristics.SetIntValue(AttributeEnum.TreasureRating, TreasureRating);
        itemCharacteristics.SetIntValue(AttributeEnum.Value, Value);
        itemCharacteristics.SetBoolValue(AttributeEnum.Valueless, Valueless);
        itemCharacteristics.SetBoolValue(AttributeEnum.Vampiric, Vampiric);
        itemCharacteristics.SetIntValue(AttributeEnum.Vorpal1InChance, Vorpal1InChance);
        itemCharacteristics.SetIntValue(AttributeEnum.VorpalExtraAttacks1InChance, VorpalExtraAttacks1InChance);
        itemCharacteristics.SetIntValue(AttributeEnum.Weight, Weight);
        itemCharacteristics.SetBoolValue(AttributeEnum.Wraith, Wraith);
        itemCharacteristics.SetBoolValue(AttributeEnum.XtraMight, XtraMight);
        itemCharacteristics.SetBoolValue(AttributeEnum.XtraShots, XtraShots);
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
            Color = Color,
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
            Value = Value,
            Valueless = Valueless,
            Vampiric = Vampiric,
            Vorpal1InChance = Vorpal1InChance,
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
    /// Returns the <see cref="ItemFactory"/> objects that this <see cref="ItemEnhancement"/> applies to; or null, if this <see cref="ItemEnhancement"/> can
    /// be applied to all <see cref="ItemFactory"/> objects.  This property is used to bind the <see cref="ApplicableItemFactories"/> property.
    /// </summary>
    private string[]? ApplicableItemFactoryBindingKeys { get; } = null;

    private string? AdditionalItemEnhancementWeightedRandomBindingKey { get; } = null;
    #endregion

    #region ItemPropertySet Light-weight & Abstract Properties
    /// <summary>
    /// Returns the value of the enhancement.  Returns 0, by default.
    /// </summary>
    private int Value { get; }

    /// <summary>
    /// Returns the name of the rare item characteristics to append to the description of the original item, or null, to not modify the name.  Returns null, by default.
    /// </summary>
    private string? FriendlyName { get; }

    /// <summary>
    /// Returns true, if the item can apply a bonus armor class for miscellaneous power.  Only weapons return true.  Returns false, by default.
    /// </summary>
    private bool CanApplyBonusArmorClassMiscPower { get; }

    /// <summary>
    /// Returns true, if the item can reflect bolts and arrows.  Returns false, by default.  Shields, helms, cloaks and hard armor return true.
    /// </summary>
    private bool CanReflectBoltsAndArrows { get; }

    /// <summary>
    /// Returns true, if an item of this factory can have slaying bonus applied for biased artifacts.  Returns true, for all items except bows; which return false.
    /// </summary>
    private bool CanApplyArtifactBiasSlaying { get; }

    /// <summary>
    /// Returns true, if an item of this factory can have be blessed for priestly biased artifacts.  Returns false, for all items except swords and polearms; which return false.
    /// </summary>
    private bool CanApplyBlessedArtifactBias { get; }

    /// <summary>
    /// Returns true, if the item can apply a blows bonus.  Returns false, by default. Bows, return true.
    /// </summary>
    private bool CanApplyBlowsBonus { get; }

    /// <summary>
    /// Returns true, if the item is capable of having slaying bonuses applied.  Only weapons return true.  Returns false by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private bool CanApplySlayingBonus { get; }

    private string? BonusStrengthRollExpression { get; }
    private string? BonusIntelligenceRollExpression { get; }
    private string? BonusWisdomRollExpression { get; }
    private string? BonusDexterityRollExpression { get; }
    private string? BonusConstitutionRollExpression { get; }
    private string? BonusCharismaRollExpression { get; }
    private string? BonusStealthRollExpression { get; }
    private string? BonusSearchRollExpression { get; }
    private string? BonusInfravisionRollExpression { get; }
    private string? BonusTunnelRollExpression { get; }
    private string? BonusAttacksRollExpression { get; }
    private string? BonusSpeedRollExpression { get; }

    private string? BonusArmorClassRollExpression { get; } 

    private string? BonusHitsRollExpression { get; }

    private string? BonusDamageRollExpression { get; }

    /// <summary>
    /// Returns then name of an <see cref="Activation "/>, if the item can be activated; or null, if the item cannot be activated.  Dragon scale mail, rings of ice, acid and flames, the planar weapon, fixed artifacts and
    /// random artifacts may have an <see cref="Activation"/>.  Returns null, by default.  This property is used to bind the <see cref="Activation"/> property during the bind phase.
    /// </summary>
    /// <inheritdoc />
    private string? ActivationName { get; }

    /// <inheritdoc />
    private bool Aggravate { get; }
    
    /// <inheritdoc />
    private bool AntiTheft { get; }

    private string? ArtifactBiasWeightedRandomBindingKey { get; }
    
    /// <inheritdoc />
    private bool Blessed { get; }

    /// <inheritdoc/>
    private bool Blows { get; }
    
    /// <inheritdoc />
    private bool BrandAcid { get; }
    
    /// <inheritdoc />
    private bool BrandCold { get; }
    
    /// <inheritdoc />
    private bool BrandElec { get; }
    
    /// <inheritdoc />
    private bool BrandFire { get; }
    
    /// <inheritdoc />
    private bool BrandPois { get; }
        
    /// <inheritdoc />
    private bool Chaotic { get; }

    public ColorEnum Color { get; }
   
    /// <inheritdoc />
    private bool IsCursed { get; }

    private int DamageDice { get; }

    private int DiceSides { get; }

    /// <inheritdoc />
    private bool DrainExp { get; }
    
    /// <inheritdoc />
    private bool DreadCurse { get; }
    
    /// <inheritdoc />
    private bool EasyKnow { get; }
    
    /// <inheritdoc />
    private bool Feather { get; }
    
    /// <inheritdoc />
    private bool FreeAct { get; }
    
    /// <inheritdoc />
    private bool HeavyCurse { get; }
    
    /// <inheritdoc />
    private bool HideType { get; }
    
    /// <inheritdoc />
    private bool HoldLife { get; }
    
    /// <inheritdoc />
    private bool IgnoreAcid { get; }
    
    /// <inheritdoc />
    private bool IgnoreCold { get; }
    
    /// <inheritdoc />
    private bool IgnoreElec { get; }
    
    /// <inheritdoc />
    private bool IgnoreFire { get; }
    
    /// <inheritdoc />
    private bool ImAcid { get; }
    
    /// <inheritdoc />
    private bool ImCold { get; }
    
    /// <inheritdoc />
    private bool ImElec { get; }
    
    /// <inheritdoc />
    private bool ImFire { get; }
    
    /// <inheritdoc />
    private bool Impact { get; }
        
    /// <inheritdoc />
    private bool NoMagic { get; }
    
    /// <inheritdoc />
    private bool NoTele { get; }
    
    /// <inheritdoc />
    private bool PermaCurse { get; }
    
    /// <inheritdoc />
    private int Radius { get; }
    
    /// <inheritdoc />
    private bool Reflect { get; }
    
    /// <inheritdoc />
    private bool Regen { get; }
    
    /// <inheritdoc />
    private bool ResAcid { get; }
    
    /// <inheritdoc />
    private bool ResBlind { get; }
    
    /// <inheritdoc />
    private bool ResChaos { get; }
    
    /// <inheritdoc />
    private bool ResCold { get; }
    
    /// <inheritdoc />
    private bool ResConf { get; }
    
    /// <inheritdoc />
    private bool ResDark { get; }
    
    /// <inheritdoc />
    private bool ResDisen { get; }
    
    /// <inheritdoc />
    private bool ResElec { get; }
    
    /// <inheritdoc />
    private bool ResFear { get; }
    
    /// <inheritdoc />
    private bool ResFire { get; }
    
    /// <inheritdoc />
    private bool ResLight { get; }
    
    /// <inheritdoc />
    private bool ResNether { get; }
    
    /// <inheritdoc />
    private bool ResNexus { get; }
    
    /// <inheritdoc />
    private bool ResPois { get; }
    
    /// <inheritdoc />
    private bool ResShards { get; }
    
    /// <inheritdoc />
    private bool ResSound { get; }
        
    /// <inheritdoc />
    private bool SeeInvis { get; }
    
    /// <inheritdoc />
    private bool ShElec { get; }
    
    /// <inheritdoc />
    private bool ShFire { get; }
    
    /// <inheritdoc />
    private bool ShowMods { get; }
    
    /// <inheritdoc />
    private bool SlayAnimal { get; }
    
    /// <inheritdoc />
    private bool SlayDemon { get; }
    
    /// <inheritdoc />
    private int SlayDragon { get; }
    
    /// <inheritdoc />
    private bool SlayEvil { get; }
    
    /// <inheritdoc />
    private bool SlayGiant { get; }
    
    /// <inheritdoc />
    private bool SlayOrc { get; }
    
    /// <inheritdoc />
    private bool SlayTroll { get; }
    
    /// <inheritdoc />
    private bool SlayUndead { get; }
    
    /// <inheritdoc />
    private bool SlowDigest { get; }
        
    /// <inheritdoc />
    private bool SustCha { get; }
    
    /// <inheritdoc />
    private bool SustCon { get; }
    
    /// <inheritdoc />
    private bool SustDex { get; }
    
    /// <inheritdoc />
    private bool SustInt { get; }
    
    /// <inheritdoc />
    private bool SustStr { get; }
    
    /// <inheritdoc />
    private bool SustWis { get; }
    
    /// <inheritdoc />
    private bool Telepathy { get; }
    
    /// <inheritdoc />
    private bool Teleport { get; }

    /// <inheritdoc />
    private int TreasureRating { get; }

    /// <inheritdoc />
    private bool Valueless { get; }

    /// <inheritdoc />
    private bool Vampiric { get; }
    
    /// <inheritdoc />
    private int Vorpal1InChance { get; }

    private int VorpalExtraAttacks1InChance { get; }

    private int Weight { get; } = 0;
    
    /// <inheritdoc />
    private bool Wraith { get; }
    
    /// <inheritdoc />
    private bool XtraMight { get; }
    
    /// <inheritdoc />
    private bool XtraShots { get; }
    #endregion
}
