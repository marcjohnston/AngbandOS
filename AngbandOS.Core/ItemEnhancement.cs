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

        SumAttributeAndExpressionBindings = itemEnhancementGameConfiguration.SumAttributeAndExpressionBindings;
        BoolAttributeAndExpressionBindings = itemEnhancementGameConfiguration.BoolAttributeAndExpressionBindings;

        ActivationName = itemEnhancementGameConfiguration.ActivationName;
        AdditionalItemEnhancementWeightedRandomBindingKey = itemEnhancementGameConfiguration.AdditionalItemEnhancementWeightedRandomBindingKey;
        Aggravate = itemEnhancementGameConfiguration.Aggravate;
        AntiTheft = itemEnhancementGameConfiguration.AntiTheft;
        ApplicableItemFactoryBindingKeys = itemEnhancementGameConfiguration.ApplicableItemFactoryBindingKeys;
        ArtifactBiasWeightedRandomBindingKey = itemEnhancementGameConfiguration.ArtifactBiasWeightedRandomBindingKey;
        Blessed = itemEnhancementGameConfiguration.Blessed;
        Blows = itemEnhancementGameConfiguration.Blows;
        BrandAcid = itemEnhancementGameConfiguration.BrandAcid;
        BrandCold = itemEnhancementGameConfiguration.BrandCold;
        BrandElec = itemEnhancementGameConfiguration.BrandElec;
        BrandFire = itemEnhancementGameConfiguration.BrandFire;
        BrandPois = itemEnhancementGameConfiguration.BrandPois;
        CanApplyBlessedArtifactBias = itemEnhancementGameConfiguration.CanApplyBlessedArtifactBias;
        ArtifactBiasCanSlay = itemEnhancementGameConfiguration.ArtifactBiasCanSlay;
        CanApplyBlowsBonus = itemEnhancementGameConfiguration.CanApplyBlowsBonus;
        CanApplySlayingBonus = itemEnhancementGameConfiguration.CanApplySlayingBonus;
        CanApplyBonusArmorClassMiscPower = itemEnhancementGameConfiguration.CanApplyBonusArmorClassMiscPower;
        Chaotic = itemEnhancementGameConfiguration.Chaotic;
        Color = itemEnhancementGameConfiguration.Color;
        DrainExp = itemEnhancementGameConfiguration.DrainExp;
        DreadCurse = itemEnhancementGameConfiguration.DreadCurse;
        EasyKnow = itemEnhancementGameConfiguration.EasyKnow;
        Feather = itemEnhancementGameConfiguration.Feather;
        FreeAct = itemEnhancementGameConfiguration.FreeAct;
        FriendlyName = itemEnhancementGameConfiguration.FriendlyName;
        HatesAcid = itemEnhancementGameConfiguration.HatesAcid;
        HatesCold = itemEnhancementGameConfiguration.HatesCold;
        HatesElectricity = itemEnhancementGameConfiguration.HatesElectricity;
        HatesFire = itemEnhancementGameConfiguration.HatesFire;
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
        Valueless = itemEnhancementGameConfiguration.Valueless;
        Vampiric = itemEnhancementGameConfiguration.Vampiric;
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

    private (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings { get; }
    public (Attribute Attribute, Expression Expression)[] SumAttributeAndExpressions { get; private set; }
    private (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings { get; }
    public (Attribute Attribute, Expression BooleanExpression)[] BoolAttributeAndExpressions { get; private set; }

    /// <summary>
    /// Returns an immutable and fixed value set of item characteristics specified by this <see cref="ItemEnhancement"/> by computing fixed values from the expressions defined in these enhancements.
    /// </summary>
    /// <returns></returns>
    public ReadOnlyAttributeSet GenerateAttributeSet()
    {
        // Since we are squashing all of the values into a read-only set, we can use the Set.
        EffectiveAttributeSet itemCharacteristics = new EffectiveAttributeSet(Game);
        foreach ((Attribute attribute, Expression expression) in SumAttributeAndExpressions)
        {
            int appendValue = Game.ComputeIntegerExpression(expression).Value;
            itemCharacteristics.Get<SumEffectiveAttributeValue>(attribute).Append(appendValue);
        }
        foreach ((Attribute attribute, Expression expression) in BoolAttributeAndExpressions)
        {
            bool setValue = Game.ComputeBooleanExpression(expression).Value;
            itemCharacteristics.Get<BoolSetEffectiveAttributeValue>(attribute).Set(setValue);
        }

        itemCharacteristics.ArtifactBias = ArtifactBiasWeightedRandom?.ChooseOrDefault();

        itemCharacteristics.CanApplyBlessedArtifactBias = CanApplyBlessedArtifactBias.HasValue ? CanApplyBlessedArtifactBias.Value : false;
        itemCharacteristics.ArtifactBiasCanSlay = ArtifactBiasCanSlay.HasValue ? ArtifactBiasCanSlay.Value : false;
        itemCharacteristics.CanApplyBlowsBonus = CanApplyBlowsBonus.HasValue ? CanApplyBlowsBonus.Value : false;
        itemCharacteristics.CanApplySlayingBonus = CanApplySlayingBonus.HasValue ? CanApplySlayingBonus.Value : false;
        itemCharacteristics.CanApplyBonusArmorClassMiscPower = CanApplyBonusArmorClassMiscPower.HasValue ? CanApplyBonusArmorClassMiscPower.Value : false;
        if (Activation is not null)
        {
            itemCharacteristics.Activation = Activation;
        }
        itemCharacteristics.Aggravate = Aggravate.HasValue ? Aggravate.Value : false;
        itemCharacteristics.AntiTheft = AntiTheft.HasValue ? AntiTheft.Value : false;
        itemCharacteristics.Blessed = Blessed.HasValue ? Blessed.Value : false;
        itemCharacteristics.BrandAcid = BrandAcid.HasValue ? BrandAcid.Value : false;
        itemCharacteristics.BrandCold = BrandCold.HasValue ? BrandCold.Value : false;
        itemCharacteristics.BrandElec = BrandElec.HasValue ? BrandElec.Value : false;
        itemCharacteristics.BrandFire = BrandFire.HasValue ? BrandFire.Value : false;
        itemCharacteristics.BrandPois = BrandPois.HasValue ? BrandPois.Value : false;
        itemCharacteristics.Chaotic = Chaotic.HasValue ? Chaotic.Value : false;
        if (Color.HasValue)
        {
            itemCharacteristics.Color = Color.Value;
        }
        itemCharacteristics.DrainExp = DrainExp.HasValue ? DrainExp.Value : false;
        itemCharacteristics.DreadCurse = DreadCurse.HasValue ? DreadCurse.Value : false;
        itemCharacteristics.EasyKnow = EasyKnow.HasValue ? EasyKnow.Value : false;
        itemCharacteristics.Feather = Feather.HasValue ? Feather.Value : false;
        itemCharacteristics.FreeAct = FreeAct.HasValue ? FreeAct.Value : false;
        itemCharacteristics.FriendlyName = FriendlyName;
        itemCharacteristics.HatesAcid = HatesAcidExpression == null ? false : Game.ComputeBooleanExpression(HatesAcidExpression).Value;
        itemCharacteristics.HatesCold = HatesColdExpression == null ? false : Game.ComputeBooleanExpression(HatesColdExpression).Value;
        itemCharacteristics.HatesElectricity = HatesElectricityExpression == null ? false : Game.ComputeBooleanExpression(HatesElectricityExpression).Value;
        itemCharacteristics.HatesFire = HatesFireExpression == null ? false : Game.ComputeBooleanExpression(HatesFireExpression).Value;
        itemCharacteristics.HideType = HideType.HasValue ? HideType.Value : false;
        itemCharacteristics.HoldLife = HoldLife.HasValue ? HoldLife.Value : false;
        itemCharacteristics.IgnoreAcid = IgnoreAcid.HasValue ? IgnoreAcid.Value : false;
        itemCharacteristics.IgnoreCold = IgnoreCold.HasValue ? IgnoreCold.Value : false;
        itemCharacteristics.IgnoreElec = IgnoreElec.HasValue ? IgnoreElec.Value : false;
        itemCharacteristics.IgnoreFire = IgnoreFire.HasValue ? IgnoreFire.Value : false;
        itemCharacteristics.ImAcid = ImAcid.HasValue ? ImAcid.Value : false;
        itemCharacteristics.ImCold = ImCold.HasValue ? ImCold.Value : false;
        itemCharacteristics.ImElec = ImElec.HasValue ? ImElec.Value : false;
        itemCharacteristics.ImFire = ImFire.HasValue ? ImFire.Value : false;
        itemCharacteristics.Impact = Impact.HasValue ? Impact.Value : false;
        itemCharacteristics.NoMagic = NoMagic.HasValue ? NoMagic.Value : false;
        itemCharacteristics.NoTele = NoTele.HasValue ? NoTele.Value : false;
        itemCharacteristics.PermaCurse = PermaCurse.HasValue ? PermaCurse.Value : false;
        itemCharacteristics.Reflect = Reflect.HasValue ? Reflect.Value : false;
        itemCharacteristics.Regen = Regen.HasValue ? Regen.Value : false;
        itemCharacteristics.ResAcid = ResAcid.HasValue ? ResAcid.Value : false;
        itemCharacteristics.ResBlind = ResBlind.HasValue ? ResBlind.Value : false;
        itemCharacteristics.ResChaos = ResChaos.HasValue ? ResChaos.Value : false;
        itemCharacteristics.ResCold = ResCold.HasValue ? ResCold.Value : false;
        itemCharacteristics.ResConf = ResConf.HasValue ? ResConf.Value : false;
        itemCharacteristics.ResDark = ResDark.HasValue ? ResDark.Value : false;
        itemCharacteristics.ResDisen = ResDisen.HasValue ? ResDisen.Value : false;
        itemCharacteristics.ResElec = ResElec.HasValue ? ResElec.Value : false;
        itemCharacteristics.ResFear = ResFear.HasValue ? ResFear.Value : false;
        itemCharacteristics.ResFire = ResFire.HasValue ? ResFire.Value : false;
        itemCharacteristics.ResLight = ResLight.HasValue ? ResLight.Value : false;
        itemCharacteristics.ResNether = ResNether.HasValue ? ResNether.Value : false;
        itemCharacteristics.ResNexus = ResNexus.HasValue ? ResNexus.Value : false;
        itemCharacteristics.ResPois = ResPois.HasValue ? ResPois.Value : false;
        itemCharacteristics.ResShards = ResShards.HasValue ? ResShards.Value : false;
        itemCharacteristics.ResSound = ResSound.HasValue ? ResSound.Value : false;
        itemCharacteristics.SeeInvis = SeeInvis.HasValue ? SeeInvis.Value : false;
        itemCharacteristics.ShElec = ShElec.HasValue ? ShElec.Value : false;
        itemCharacteristics.ShFire = ShFire.HasValue ? ShFire.Value : false;
        itemCharacteristics.ShowMods = ShowMods.HasValue ? ShowMods.Value : false;
        itemCharacteristics.SlayAnimal = SlayAnimal.HasValue ? SlayAnimal.Value : false;
        itemCharacteristics.SlayDemon = SlayDemon.HasValue ? SlayDemon.Value : false;
        itemCharacteristics.SlayEvil = SlayEvil.HasValue ? SlayEvil.Value : false;
        itemCharacteristics.SlayGiant = SlayGiant.HasValue ? SlayGiant.Value : false;
        itemCharacteristics.SlayOrc = SlayOrc.HasValue ? SlayOrc.Value : false;
        itemCharacteristics.SlayTroll = SlayTroll.HasValue ? SlayTroll.Value : false;
        itemCharacteristics.SlayUndead = SlayUndead.HasValue ? SlayUndead.Value : false;
        itemCharacteristics.SlowDigest = SlowDigest.HasValue ? SlowDigest.Value : false;
        itemCharacteristics.SustCha = SustCha.HasValue ? SustCha.Value : false;
        itemCharacteristics.SustCon = SustCon.HasValue ? SustCon.Value : false;
        itemCharacteristics.SustDex = SustDex.HasValue ? SustDex.Value : false;
        itemCharacteristics.SustInt = SustInt.HasValue ? SustInt.Value : false;
        itemCharacteristics.SustStr = SustStr.HasValue ? SustStr.Value : false;
        itemCharacteristics.SustWis = SustWis.HasValue ? SustWis.Value : false;
        itemCharacteristics.Telepathy = Telepathy.HasValue ? Telepathy.Value : false;
        itemCharacteristics.Teleport = Teleport.HasValue ? Teleport.Value : false;
        itemCharacteristics.Valueless = Valueless.HasValue ? Valueless.Value : false;
        itemCharacteristics.Vampiric = Vampiric.HasValue ? Vampiric.Value : false;
        itemCharacteristics.Wraith = Wraith.HasValue ? Wraith.Value : false;
        itemCharacteristics.XtraMight = XtraMight.HasValue ? XtraMight.Value : false;
        itemCharacteristics.XtraShots = XtraShots.HasValue ? XtraShots.Value : false;
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
        // We are using a dictionary because we do not want to support duplicate attributes.
        Dictionary<Attribute, Expression> sumAttributeAndExpressionList = new Dictionary<Attribute, Expression>();
        if (SumAttributeAndExpressionBindings is not null)
        {
            foreach ((string attributeName, string expression) in SumAttributeAndExpressionBindings)
            {
                Attribute attribute = Game.SingletonRepository.Get<Attribute>(attributeName);
                Expression numericExpression = Game.ParseNumericExpression(expression);
                sumAttributeAndExpressionList.Add(attribute, numericExpression);
            }
        }
        SumAttributeAndExpressions = sumAttributeAndExpressionList.Select(_attributeAndExpression => (_attributeAndExpression.Key, _attributeAndExpression.Value)).ToArray();

        // We are using a dictionary because we do not want to support duplicate attributes.
        Dictionary<Attribute, Expression> boolAttributeAndExpressionList = new Dictionary<Attribute, Expression>();
        if (BoolAttributeAndExpressionBindings is not null)
        {
            foreach ((string attributeName, string expression) in BoolAttributeAndExpressionBindings)
            {
                Attribute attribute = Game.SingletonRepository.Get<Attribute>(attributeName);
                Expression numericExpression = Game.ParseBooleanExpression(expression);
                boolAttributeAndExpressionList.Add(attribute, numericExpression);
            }
        }
        BoolAttributeAndExpressions = boolAttributeAndExpressionList.Select(_attributeAndExpression => (_attributeAndExpression.Key, _attributeAndExpression.Value)).ToArray();


        Activation = Game.SingletonRepository.GetNullable<Activation>(ActivationName);

        HatesAcidExpression = Game.ParseNullableBooleanExpression(HatesAcid);
        HatesColdExpression = Game.ParseNullableBooleanExpression(HatesCold);
        HatesElectricityExpression = Game.ParseNullableBooleanExpression(HatesElectricity);
        HatesFireExpression = Game.ParseNullableBooleanExpression(HatesFire);

        AdditionalItemEnhancementWeightedRandom = Game.SingletonRepository.GetNullable<ItemEnhancementWeightedRandom>(AdditionalItemEnhancementWeightedRandomBindingKey);
        ArtifactBiasWeightedRandom = Game.SingletonRepository.GetNullable<ArtifactBiasWeightedRandom>(ArtifactBiasWeightedRandomBindingKey);
        ApplicableItemFactories = Game.SingletonRepository.GetNullable<ItemFactory>(ApplicableItemFactoryBindingKeys);
    }

    public string ToJson()
    {
        ItemEnhancementGameConfiguration itemEnhancementDefinition = new()
        {
            Key = Key,

            SumAttributeAndExpressionBindings = SumAttributeAndExpressionBindings,
            BoolAttributeAndExpressionBindings = BoolAttributeAndExpressionBindings,

            ActivationName = ActivationName,
            AdditionalItemEnhancementWeightedRandomBindingKey = AdditionalItemEnhancementWeightedRandomBindingKey,
            Aggravate = Aggravate,
            AntiTheft = AntiTheft,
            ApplicableItemFactoryBindingKeys = ApplicableItemFactoryBindingKeys,
            ArtifactBiasCanSlay = ArtifactBiasCanSlay,
            ArtifactBiasWeightedRandomBindingKey = ArtifactBiasWeightedRandomBindingKey,
            Blessed = Blessed,
            Blows = Blows,
            BrandAcid = BrandAcid,
            BrandCold = BrandCold,
            BrandElec = BrandElec,
            BrandFire = BrandFire,
            BrandPois = BrandPois,
            CanApplyBlessedArtifactBias = CanApplyBlessedArtifactBias,
            CanApplyBlowsBonus = CanApplyBlowsBonus,
            CanApplyBonusArmorClassMiscPower = CanApplyBonusArmorClassMiscPower,
            CanApplySlayingBonus = CanApplySlayingBonus,
            Chaotic = Chaotic,
            Color = Color,
            DrainExp = DrainExp,
            DreadCurse = DreadCurse,
            EasyKnow = EasyKnow,
            Feather = Feather,
            FreeAct = FreeAct,
            FriendlyName = FriendlyName,
            HatesAcid = HatesAcid,
            HatesCold = HatesCold,
            HatesElectricity = HatesElectricity,
            HatesFire = HatesFire,
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
            Valueless = Valueless,
            Vampiric = Vampiric,
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

    private Expression? HatesAcidExpression { get; set; }
    private Expression? HatesFireExpression { get; set; }
    private Expression? HatesColdExpression { get; set; }
    private Expression? HatesElectricityExpression { get; set; }

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
    public string? HatesFire { get; }
    public string? HatesElectricity { get; }

    /// <summary>
    /// Returns true, if the item is susceptible to acid.  Returns false, by default.
    /// </summary>
    public string? HatesAcid { get; }

    /// <summary>
    /// Returns true, if the item is susceptible to cold.  Returns false, by default.
    /// </summary>
    public string? HatesCold { get; }

    /// <summary>
    /// Returns the name of the rare item characteristics to append to the description of the original item, or null, to not modify the name.  Returns null, by default.
    /// </summary>
    private string? FriendlyName { get; }

    /// <summary>
    /// Returns true, if the item can apply a bonus armor class for miscellaneous power.  Only weapons return true.  Returns false, by default.
    /// </summary>
    private bool? CanApplyBonusArmorClassMiscPower { get; }

    /// <summary>
    /// Returns true, if an item of this factory can have slaying bonus applied for biased artifacts.  Returns false, for all items except bows; which return true.
    /// </summary>
    private bool? ArtifactBiasCanSlay { get; }

    /// <summary>
    /// Returns true, if an item of this factory can have be blessed for priestly biased artifacts.  Returns false, for all items except swords and polearms; which return false.
    /// </summary>
    private bool? CanApplyBlessedArtifactBias { get; }

    /// <summary>
    /// Returns true, if the item can apply a blows bonus.  Returns false, by default. Bows, return true.
    /// </summary>
    private bool? CanApplyBlowsBonus { get; }

    /// <summary>
    /// Returns true, if the item is capable of having slaying bonuses applied.  Only weapons return true.  Returns false by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private bool? CanApplySlayingBonus { get; }

    /// <summary>
    /// Returns then name of an <see cref="Activation "/>, if the item can be activated; or null, if the item cannot be activated.  Dragon scale mail, rings of ice, acid and flames, the planar weapon, fixed artifacts and
    /// random artifacts may have an <see cref="Activation"/>.  Returns null, by default.  This property is used to bind the <see cref="Activation"/> property during the bind phase.
    /// </summary>
    /// <inheritdoc />
    private string? ActivationName { get; }

    /// <inheritdoc />
    private bool? Aggravate { get; }
    
    /// <inheritdoc />
    private bool? AntiTheft { get; }

    private string? ArtifactBiasWeightedRandomBindingKey { get; }
    
    /// <inheritdoc />
    private bool? Blessed { get; }

    /// <inheritdoc/>
    private bool? Blows { get; }
    
    /// <inheritdoc />
    private bool? BrandAcid { get; }
    
    /// <inheritdoc />
    private bool? BrandCold { get; }
    
    /// <inheritdoc />
    private bool? BrandElec { get; }
    
    /// <inheritdoc />
    private bool? BrandFire { get; }
    
    /// <inheritdoc />
    private bool? BrandPois { get; }
        
    /// <inheritdoc />
    private bool? Chaotic { get; }

    public ColorEnum? Color { get; }
   
    /// <inheritdoc />
    private bool? DrainExp { get; }
    
    /// <inheritdoc />
    private bool? DreadCurse { get; }
    
    /// <inheritdoc />
    private bool? EasyKnow { get; }
    
    /// <inheritdoc />
    private bool? Feather { get; }
    
    /// <inheritdoc />
    private bool? FreeAct { get; }
    
    /// <inheritdoc />
    private bool? HideType { get; }
    
    /// <inheritdoc />
    private bool? HoldLife { get; }
    
    /// <inheritdoc />
    private bool? IgnoreAcid { get; }
    
    /// <inheritdoc />
    private bool? IgnoreCold { get; }
    
    /// <inheritdoc />
    private bool? IgnoreElec { get; }
    
    /// <inheritdoc />
    private bool? IgnoreFire { get; }
    
    /// <inheritdoc />
    private bool? ImAcid { get; }
    
    /// <inheritdoc />
    private bool? ImCold { get; }
    
    /// <inheritdoc />
    private bool? ImElec { get; }
    
    /// <inheritdoc />
    private bool? ImFire { get; }
    
    /// <inheritdoc />
    private bool? Impact { get; }
        
    /// <inheritdoc />
    private bool? NoMagic { get; }
    
    /// <inheritdoc />
    private bool? NoTele { get; }
    
    /// <inheritdoc />
    private bool? PermaCurse { get; }
    
    /// <inheritdoc />
    private bool? Reflect { get; }
    
    /// <inheritdoc />
    private bool? Regen { get; }
    
    /// <inheritdoc />
    private bool? ResAcid { get; }
    
    /// <inheritdoc />
    private bool? ResBlind { get; }
    
    /// <inheritdoc />
    private bool? ResChaos { get; }
    
    /// <inheritdoc />
    private bool? ResCold { get; }
    
    /// <inheritdoc />
    private bool? ResConf { get; }
    
    /// <inheritdoc />
    private bool? ResDark { get; }
    
    /// <inheritdoc />
    private bool? ResDisen { get; }
    
    /// <inheritdoc />
    private bool? ResElec { get; }
    
    /// <inheritdoc />
    private bool? ResFear { get; }
    
    /// <inheritdoc />
    private bool? ResFire { get; }
    
    /// <inheritdoc />
    private bool? ResLight { get; }
    
    /// <inheritdoc />
    private bool? ResNether { get; }
    
    /// <inheritdoc />
    private bool? ResNexus { get; }
    
    /// <inheritdoc />
    private bool? ResPois { get; }
    
    /// <inheritdoc />
    private bool? ResShards { get; }
    
    /// <inheritdoc />
    private bool? ResSound { get; }
        
    /// <inheritdoc />
    private bool? SeeInvis { get; }
    
    /// <inheritdoc />
    private bool? ShElec { get; }
    
    /// <inheritdoc />
    private bool? ShFire { get; }
    
    /// <inheritdoc />
    private bool? ShowMods { get; }
    
    /// <inheritdoc />
    private bool? SlayAnimal { get; }
    
    /// <inheritdoc />
    private bool? SlayDemon { get; }
     
    /// <inheritdoc />
    private bool? SlayEvil { get; }
    
    /// <inheritdoc />
    private bool? SlayGiant { get; }
    
    /// <inheritdoc />
    private bool? SlayOrc { get; }
    
    /// <inheritdoc />
    private bool? SlayTroll { get; }
    
    /// <inheritdoc />
    private bool? SlayUndead { get; }
    
    /// <inheritdoc />
    private bool? SlowDigest { get; }
        
    /// <inheritdoc />
    private bool? SustCha { get; }
    
    /// <inheritdoc />
    private bool? SustCon { get; }
    
    /// <inheritdoc />
    private bool? SustDex { get; }
    
    /// <inheritdoc />
    private bool? SustInt { get; }
    
    /// <inheritdoc />
    private bool? SustStr { get; }
    
    /// <inheritdoc />
    private bool? SustWis { get; }
    
    /// <inheritdoc />
    private bool? Telepathy { get; }
    
    /// <inheritdoc />
    private bool? Teleport { get; }

    /// <inheritdoc />
    private bool? Valueless { get; }

    /// <inheritdoc />
    private bool? Vampiric { get; }
       
    /// <inheritdoc />
    private bool? Wraith { get; }
    
    /// <inheritdoc />
    private bool? XtraMight { get; }
    
    /// <inheritdoc />
    private bool? XtraShots { get; }
    #endregion
}
