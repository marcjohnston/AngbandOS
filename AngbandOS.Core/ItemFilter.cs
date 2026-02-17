
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents an object that can compare items with some predefined matching criteria.  The predefined matching criteria are bound during the bind phase by adding <see cref="ItemMatch"/> objects
/// to the <see cref="ItemMatches"/> list.  This binding of predefined <see cref="ItemMatch"/> objects allows the matching of items at run-time to be as fast as possible; no unnecessary comparisions
/// are performed.  These <see cref="ItemFilter"/> objects are designed to support configurability.
/// </summary>
[Serializable]
internal sealed class ItemFilter : IGetKey, IItemFilter, IToJson
{
    private readonly Game Game;
    public ItemFilter(Game game, ItemFilterGameConfiguration itemFilterGameConfiguration)
    {
        Game = game;
        Key = itemFilterGameConfiguration.Key ?? itemFilterGameConfiguration.GetType().Name;
        CanBeActivated = itemFilterGameConfiguration.CanBeActivated;
        CanBeAimed = itemFilterGameConfiguration.CanBeAimed;
        CanBeEaten = itemFilterGameConfiguration.CanBeEaten;
        CanBeFired = itemFilterGameConfiguration.CanBeFired;
        CanBeQuaffed = itemFilterGameConfiguration.CanBeQuaffed;
        CanBeRead = itemFilterGameConfiguration.CanBeRead;
        CanBeRecharged = itemFilterGameConfiguration.CanBeRecharged;
        CanBeUsed = itemFilterGameConfiguration.CanBeUsed;
        CanBeUsedToDig = itemFilterGameConfiguration.CanBeUsedToDig;
        CanBeZapped = itemFilterGameConfiguration.CanBeZapped;
        CanProjectArrows = itemFilterGameConfiguration.CanProjectArrows;
        IsArmor = itemFilterGameConfiguration.IsArmor;
        IsBlessed = itemFilterGameConfiguration.IsBlessed;
        IsFuelForTorch = itemFilterGameConfiguration.IsFuelForTorch;
        IsKnown = itemFilterGameConfiguration.IsKnown;
        IsLanternFuel = itemFilterGameConfiguration.IsLanternFuel;
        IsOfValue = itemFilterGameConfiguration.IsOfValue;
        IsTooHeavyToWield = itemFilterGameConfiguration.IsTooHeavyToWield;
        IsUsableSpellBook = itemFilterGameConfiguration.IsUsableSpellBook;
        IsWeapon = itemFilterGameConfiguration.IsWeapon;
        IsWearableOrWieldable = itemFilterGameConfiguration.IsWearableOrWieldable;
        AnyMatchingItemClassNames = itemFilterGameConfiguration.AnyMatchingItemClassNames;
        AllNonMatchingItemClassNames = itemFilterGameConfiguration.AllNonMatchingItemClassNames;
        AnyMatchingItemFactoryNames = itemFilterGameConfiguration.AnyMatchingItemFactoryNames;
        AllNonMatchingItemFactoryNames = itemFilterGameConfiguration.AllNonMatchingItemFactoryNames;

        CanApplyBlessedArtifactBias = itemFilterGameConfiguration.CanApplyBlessedArtifactBias;
        ArtifactBiasCanSlay = itemFilterGameConfiguration.ArtifactBiasCanSlay;
        Aggravate = itemFilterGameConfiguration.Aggravate;
        AntiTheft = itemFilterGameConfiguration.AntiTheft;
        ArtifactBias = itemFilterGameConfiguration.ArtifactBias;
        Blessed = itemFilterGameConfiguration.Blessed;
        BrandAcid = itemFilterGameConfiguration.BrandAcid;
        BrandCold = itemFilterGameConfiguration.BrandCold;
        BrandElec = itemFilterGameConfiguration.BrandElec;
        BrandFire = itemFilterGameConfiguration.BrandFire;
        BrandPois = itemFilterGameConfiguration.BrandPois;
        Chaotic = itemFilterGameConfiguration.Chaotic;
        IsCursed = itemFilterGameConfiguration.IsCursed;
        DrainExp = itemFilterGameConfiguration.DrainExp;
        DreadCurse = itemFilterGameConfiguration.DreadCurse;
        EasyKnow = itemFilterGameConfiguration.EasyKnow;
        Feather = itemFilterGameConfiguration.Feather;
        FreeAct = itemFilterGameConfiguration.FreeAct;
        HeavyCurse = itemFilterGameConfiguration.HeavyCurse;
        HideType = itemFilterGameConfiguration.HideType;
        HoldLife = itemFilterGameConfiguration.HoldLife;
        IgnoreAcid = itemFilterGameConfiguration.IgnoreAcid;
        IgnoreCold = itemFilterGameConfiguration.IgnoreCold;
        IgnoreElec = itemFilterGameConfiguration.IgnoreElec;
        IgnoreFire = itemFilterGameConfiguration.IgnoreFire;
        ImAcid = itemFilterGameConfiguration.ImAcid;
        ImCold = itemFilterGameConfiguration.ImCold;
        ImElec = itemFilterGameConfiguration.ImElec;
        ImFire = itemFilterGameConfiguration.ImFire;
        Impact = itemFilterGameConfiguration.Impact;
        NoMagic = itemFilterGameConfiguration.NoMagic;
        NoTele = itemFilterGameConfiguration.NoTele;
        PermaCurse = itemFilterGameConfiguration.PermaCurse;
        Radius = itemFilterGameConfiguration.Radius;
        Reflect = itemFilterGameConfiguration.Reflect;
        Regen = itemFilterGameConfiguration.Regen;
        ResAcid = itemFilterGameConfiguration.ResAcid;
        ResBlind = itemFilterGameConfiguration.ResBlind;
        ResChaos = itemFilterGameConfiguration.ResChaos;
        ResCold = itemFilterGameConfiguration.ResCold;
        ResConf = itemFilterGameConfiguration.ResConf;
        ResDark = itemFilterGameConfiguration.ResDark;
        ResDisen = itemFilterGameConfiguration.ResDisen;
        ResElec = itemFilterGameConfiguration.ResElec;
        ResFear = itemFilterGameConfiguration.ResFear;
        ResFire = itemFilterGameConfiguration.ResFire;
        ResLight = itemFilterGameConfiguration.ResLight;
        ResNether = itemFilterGameConfiguration.ResNether;
        ResNexus = itemFilterGameConfiguration.ResNexus;
        ResPois = itemFilterGameConfiguration.ResPois;
        ResShards = itemFilterGameConfiguration.ResShards;
        ResSound = itemFilterGameConfiguration.ResSound;
        SeeInvis = itemFilterGameConfiguration.SeeInvis;
        FactoryAllowsShElecricity = itemFilterGameConfiguration.FactoryAllowsShElecricity;
        ShElec = itemFilterGameConfiguration.ShElec;
        FactoryAllowsShFire = itemFilterGameConfiguration.FactoryAllowsShFire;
        ShFire = itemFilterGameConfiguration.ShFire;
        ShowMods = itemFilterGameConfiguration.ShowMods;
        SlayAnimal = itemFilterGameConfiguration.SlayAnimal;
        SlayDemon = itemFilterGameConfiguration.SlayDemon;
        SlayDragon = itemFilterGameConfiguration.SlayDragon;
        SlayEvil = itemFilterGameConfiguration.SlayEvil;
        SlayGiant = itemFilterGameConfiguration.SlayGiant;
        SlayOrc = itemFilterGameConfiguration.SlayOrc;
        SlayTroll = itemFilterGameConfiguration.SlayTroll;
        SlayUndead = itemFilterGameConfiguration.SlayUndead;
        SlowDigest = itemFilterGameConfiguration.SlowDigest;
        SustCha = itemFilterGameConfiguration.SustCha;
        SustCon = itemFilterGameConfiguration.SustCon;
        SustDex = itemFilterGameConfiguration.SustDex;
        SustInt = itemFilterGameConfiguration.SustInt;
        SustStr = itemFilterGameConfiguration.SustStr;
        SustWis = itemFilterGameConfiguration.SustWis;
        Telepathy = itemFilterGameConfiguration.Telepathy;
        Teleport = itemFilterGameConfiguration.Teleport;
        TreasureRating = itemFilterGameConfiguration.TreasureRating;
        Vampiric = itemFilterGameConfiguration.Vampiric;
        Vorpal = itemFilterGameConfiguration.Vorpal;
        Wraith = itemFilterGameConfiguration.Wraith;
        XtraMight = itemFilterGameConfiguration.XtraMight;
        XtraShots = itemFilterGameConfiguration.XtraShots;
    }

    private ItemMatch[] ItemMatches { get; set; }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        ItemFilterGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            CanBeActivated = CanBeActivated,
            CanBeAimed = CanBeAimed,
            CanBeEaten = CanBeEaten,
            CanBeFired = CanBeFired,
            CanBeQuaffed = CanBeQuaffed,
            CanBeRead = CanBeRead,
            CanBeRecharged = CanBeRecharged,
            CanBeUsed = CanBeUsed,
            CanBeUsedToDig = CanBeUsedToDig,
            CanBeZapped = CanBeZapped,
            CanProjectArrows = CanProjectArrows,
            IsArmor = IsArmor,
            IsBlessed = IsBlessed,
            IsFuelForTorch = IsFuelForTorch,
            IsKnown = IsKnown,
            IsLanternFuel = IsLanternFuel,
            IsOfValue = IsOfValue,
            IsTooHeavyToWield = IsTooHeavyToWield,
            IsUsableSpellBook = IsUsableSpellBook,
            IsWeapon = IsWeapon,
            IsWearableOrWieldable = IsWearableOrWieldable,
            AnyMatchingItemClassNames = AnyMatchingItemClassNames,
            AllNonMatchingItemClassNames = AllNonMatchingItemClassNames,
            AnyMatchingItemFactoryNames = AnyMatchingItemFactoryNames,
            AllNonMatchingItemFactoryNames = AllNonMatchingItemFactoryNames,
            CanApplyBlessedArtifactBias = CanApplyBlessedArtifactBias,
            ArtifactBiasCanSlay = ArtifactBiasCanSlay,
            Aggravate = Aggravate,
            AntiTheft = AntiTheft,
            ArtifactBias = ArtifactBias,
            Blessed = Blessed,
            BrandAcid = BrandAcid,
            BrandCold = BrandCold,
            BrandElec = BrandElec,
            BrandFire = BrandFire,
            BrandPois = BrandPois,
            Chaotic = Chaotic,
            IsCursed = IsCursed,
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
            FactoryAllowsShElecricity = FactoryAllowsShElecricity,
            ShElec = ShElec,
            FactoryAllowsShFire = FactoryAllowsShFire,
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
            Vampiric = Vampiric,
            Vorpal = Vorpal,
            Wraith = Wraith,
            XtraMight = XtraMight,
            XtraShots = XtraShots,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }
    public string Key { get; }
    public string GetKey => Key;

    /// <summary>
    /// Adds either or both <see cref="StringsItemMatch"/> objects for positive and negative comparisons using two nullable string array properties.  
    /// </summary>
    /// <param name="title"></param>
    /// <param name="matchingStrings"></param>
    /// <param name="nonmatchingStrings"></param>
    /// <param name="positiveLambdaEvaluation"></param>
    /// <returns></returns>
    private ItemMatch[] AddContainsMatch<T>(T[]? matchingStrings, T[]? nonmatchingStrings, GetItemProperty<T> positiveLambdaEvaluation)
    {
        List<ItemMatch> itemMatchList = new List<ItemMatch>();
        if (matchingStrings != null)
        {
            itemMatchList.Add(new ContainsItemMatch<T>(Game, matchingStrings, true, positiveLambdaEvaluation));
        }
        if (nonmatchingStrings != null)
        {
            itemMatchList.Add(new ContainsItemMatch<T>(Game, nonmatchingStrings, false, positiveLambdaEvaluation));
        }
        return itemMatchList.ToArray();
    }

    /// <summary>
    /// Adds either or both <see cref="BooleanItemMatch"/> objects for positive and negative comparising using a single nullable boolean property.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="boolean"></param>
    /// <param name="positiveLambdaEvaluation"></param>
    /// <returns></returns>
    private ItemMatch[] AddBooleanMatch(bool? boolean, GetItemProperty<bool> positiveLambdaEvaluation)
    {
        if (boolean.HasValue)
        {
            return new ItemMatch[]
            {
                new BooleanItemMatch(Game, boolean.Value, positiveLambdaEvaluation)
            };
        }
        return new ItemMatch[] { };
    }

    public void Bind()
    {
        AnyMatchingItemClasses = Game.SingletonRepository.GetNullable<ItemClass>(AnyMatchingItemClassNames);
        AllNonMatchingItemClasses = Game.SingletonRepository.GetNullable<ItemClass>(AllNonMatchingItemClassNames);
        AnyMatchingItemFactories = Game.SingletonRepository.GetNullable<ItemFactory>(AnyMatchingItemFactoryNames);
        AllNonMatchingItemFactories = Game.SingletonRepository.GetNullable<ItemFactory>(AllNonMatchingItemFactoryNames);

        List<ItemMatch> itemMatchList = new List<ItemMatch>();
        itemMatchList.AddRange(AddBooleanMatch(CanBeActivated, new CanBeActivatedBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeAimed, new CanBeAimedBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeEaten, new CanBeEatenBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeFired, new CanBeFiredBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeQuaffed, new CanBeQuaffedBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeRead, new CanBeReadBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeRecharged, new CanBeReadBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeUsed, new CanBeUsedBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeUsedToDig, new CanTunnelBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeZapped, new CanBeZappedBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanProjectArrows, new CanProjectArrowsBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsArmor, new IsArmorBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsBlessed, new IsBlessedBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsFuelForTorch, new IsFuelForTorchBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsKnown, new IsKnownBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsLanternFuel, new IsLanternFuelBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsOfValue, new IsOfValueBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsTooHeavyToWield, new IsTooHeavyToWieldBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsUsableSpellBook, new IsUsableSpellBookBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsWeapon, new IsWeaponBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsWearableOrWieldable, new IsWearableOrWieldableBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddContainsMatch<ItemClass>(AnyMatchingItemClasses, AllNonMatchingItemClasses, new ItemClassGetItemProperty(Game)));
        itemMatchList.AddRange(AddContainsMatch<ItemFactory>(AnyMatchingItemFactories, AllNonMatchingItemFactories, new ItemFactoryGetItemProperty(Game)));

        itemMatchList.AddRange(AddBooleanMatch(CanApplyBlessedArtifactBias, new CanApplyBlessedArtifactBiasBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ArtifactBiasCanSlay, new ArtifactBiasCanSlayBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(Aggravate, new AggravateBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(AntiTheft, new AntiTheftBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ArtifactBias, new ArtifactBiasBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(Blessed, new BlessedBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(BrandAcid, new BrandAcidBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(BrandCold, new BrandColdBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(BrandElec, new BrandElecBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(BrandFire, new BrandFireBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(BrandPois, new BrandPoisBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(Chaotic, new ChaoticBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsCursed, new IsCursedBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(DrainExp, new DrainExpBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(DreadCurse, new DreadCurseBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(EasyKnow, new EasyKnowBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(Feather, new FeatherBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(FreeAct, new FreeActBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(HeavyCurse, new HeavyCurseBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(HideType, new HideTypeBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(HoldLife, new HoldLifeBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IgnoreAcid, new IgnoreAcidBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IgnoreCold, new IgnoreColdBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IgnoreElec, new IgnoreElecBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IgnoreFire, new IgnoreFireBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ImAcid, new ImAcidBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ImCold, new ImColdBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ImElec, new ImElecBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ImFire, new ImFireBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(Impact, new ImpactBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(NoMagic, new NoMagicBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(NoTele, new NoTeleBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(PermaCurse, new PermaCurseBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(Radius, new RadiusBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(Reflect, new ReflectBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(Regen, new RegenBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ResAcid, new ResAcidBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ResBlind, new ResBlindBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ResChaos, new ResChaosBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ResCold, new ResColdBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ResConf, new ResConfBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ResDark, new ResDarkBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ResDisen, new ResDisenBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ResElec, new ResElecBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ResFear, new ResFearBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ResFire, new ResFireBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ResLight, new ResLightBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ResNether, new ResNetherBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ResNexus, new ResNexusBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ResPois, new ResPoisBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ResShards, new ResShardsBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ResSound, new ResSoundBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(SeeInvis, new SeeInvisBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(FactoryAllowsShElecricity, new FactoryAllowsShElecricityBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ShElec, new ShElecBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(FactoryAllowsShFire, new FactoryAllowsShFireBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ShFire, new ShFireBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(ShowMods, new ShowModsBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(SlayAnimal, new SlayAnimalBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(SlayDemon, new SlayDemonBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(SlayDragon, new SlayDragonBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(SlayEvil, new SlayEvilBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(SlayGiant, new SlayGiantBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(SlayOrc, new SlayOrcBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(SlayTroll, new SlayTrollBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(SlayUndead, new SlayUndeadBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(SlowDigest, new SlowDigestBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(SustCha, new SustChaBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(SustCon, new SustConBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(SustDex, new SustDexBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(SustInt, new SustIntBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(SustStr, new SustStrBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(SustWis, new SustWisBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(Telepathy, new TelepathyBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(Teleport, new TeleportBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(TreasureRating, new TreasureRatingBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(Vampiric, new VampiricBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(Wraith, new WraithBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(XtraMight, new XtraMightBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(XtraShots, new XtraShotsBooleanGetItemProperty(Game)));
        ItemMatches = itemMatchList.ToArray();
    }

    public bool Matches(Item item)
    {
        foreach (ItemMatch itemMatch in ItemMatches)
        {
            if (!itemMatch.Matches(item))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Returns true, if the item must be activatable; false, if the item cannot be activatable; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? CanBeActivated { get; } = null;

    /// <summary>
    /// Returns true, if the item can be aimed; false, if the item cannot be aimed; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? CanBeAimed { get; } = null;

    /// <summary>
    /// Returns true, if the item can be eaten; false, if the item cannot be eaten; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? CanBeEaten { get; } = null;

    /// <summary>
    /// Returns true, if the item can be fired; false, if the item cannot be fired; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? CanBeFired { get; } = null;

    /// <summary>
    /// Returns true, if the item can be quaffed; false, if the item cannot be quaffed; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? CanBeQuaffed { get; } = null;

    /// <summary>
    /// Returns true, if the item can be read; false, if the item cannot be read; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? CanBeRead { get; } = null;

    /// <summary>
    /// Returns true, if the item is rechargable; false, if the item cannot be rechargable; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? CanBeRecharged { get; } = null;

    /// <summary>
    /// Returns true, if the item can be used; false, if the item cannot be used; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? CanBeUsed { get; } = null;

    /// <summary>
    /// Returns true, if the item can be used to dig; false, if the item cannot be used to dig; or null, if indifferent.  Returns null, by default.
    /// </summary>
    [Obsolete("Use ItemClass")]
    public bool? CanBeUsedToDig { get; } = null;

    /// <summary>
    /// Returns true, if the item can be zapped; false, if the item cannot be zapped; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? CanBeZapped { get; } = null;

    /// <summary>
    /// Returns true, if the item must be able to project arrows; false, if the item cannot project arrows; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? CanProjectArrows { get; } = null;

    /// <summary>
    /// Returns true, if the item is armor; false, if the item cannot be armor; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? IsArmor { get; } = null;

    /// <summary>
    /// Returns true, if the item must be blessed; false, if the item cannot be blessed; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? IsBlessed { get; } = null;

    /// <summary>
    /// Returns true, if the item must capable of fueling a torch; false, if the item cannot be fuel for a torch; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? IsFuelForTorch { get; } = null;

    /// <summary>
    /// Returns true, if the item must be known; false, if the item cannot be known; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? IsKnown { get; } = null;

    /// <summary>
    /// Returns true, if the item must capable of fueling a lantern; false, if the item cannot be fuel for a lantern; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? IsLanternFuel { get; } = null;

    /// <summary>
    /// Returns true, if the item must have a value greater than zero (>0); false, if the item must have a value of zero or less (<=0); or null, 
    /// if indifferent.  Returns null, by default.  Stores require their items to have value to be an item in the store.
    /// </summary>
    public bool? IsOfValue { get; } = null;

    /// <summary>
    /// Returns true, if the item must be too heavy to wield; false, if the item cannot be too heavy to wield; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? IsTooHeavyToWield { get; } = null;

    /// <summary>
    /// Returns true, if the item is either the primary or secondary spell book; false, if the item cannot be either the primary or secondary spell book; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? IsUsableSpellBook { get; } = null;

    /// <summary>
    /// Returns true, if the item must a weapon; false, if the item cannot be a weapon; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? IsWeapon { get; } = null;

    /// <summary>
    /// Returns true, if the item is wearable; false, if the item cannot be wearable; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public bool? IsWearableOrWieldable { get; } = null;

    /// <summary>
    /// Returns the key for the ItemClass that the ItemFactory must belong to; or null, if indifferent.  Returns null, by default.
    /// </summary>
    private string[]? AnyMatchingItemClassNames { get; } = null;
    public ItemClass[]? AnyMatchingItemClasses { get; private set; }

    /// <summary>
    /// Returns the key for the ItemClass that the ItemFactory must belong to; or null, if indifferent.  Returns null, by default.
    /// </summary>
    private string[]? AllNonMatchingItemClassNames { get; } = null;
    public ItemClass[]? AllNonMatchingItemClasses { get; private set; }

    /// <summary>
    /// Returns one or more <see cref="ItemFactory"/> keys for item factories that should match; null, if indifferent.  Returns null, by default.
    /// </summary>
    private string[]? AnyMatchingItemFactoryNames { get; } = null;
    public ItemFactory[]? AnyMatchingItemFactories { get; private set; }

    /// <summary>
    /// Returns one or more <see cref="ItemFactory"/> keys for item factories that should not match; null, if indifferent.  Returns null, by default.
    /// </summary>
    private string[]? AllNonMatchingItemFactoryNames { get; } = null;
    public ItemFactory[]? AllNonMatchingItemFactories { get; private set; }

    public bool? CanApplyBlessedArtifactBias { get; } = null;
    public bool? ArtifactBiasCanSlay { get; } = null;
    public bool? Aggravate { get; } = null;

    public bool? AntiTheft { get; } = null;

    public bool? ArtifactBias { get; } = null;

    public bool? Blessed { get; } = null;

    public bool? BrandAcid { get; } = null;

    public bool? BrandCold { get; } = null;

    public bool? BrandElec { get; } = null;

    public bool? BrandFire { get; } = null;

    public bool? BrandPois { get; } = null;

    public bool? Chaotic { get; } = null;

    public bool? IsCursed { get; } = null;

    public bool? DrainExp { get; } = null;

    public bool? DreadCurse { get; } = null;

    public bool? EasyKnow { get; } = null;

    public bool? Feather { get; } = null;

    public bool? FreeAct { get; } = null;

    public bool? HeavyCurse { get; } = null;

    public bool? HideType { get; } = null;

    public bool? HoldLife { get; } = null;

    public bool? IgnoreAcid { get; } = null;

    public bool? IgnoreCold { get; } = null;

    public bool? IgnoreElec { get; } = null;

    public bool? IgnoreFire { get; } = null;

    public bool? ImAcid { get; } = null;

    public bool? ImCold { get; } = null;

    public bool? ImElec { get; } = null;

    public bool? ImFire { get; } = null;

    public bool? Impact { get; } = null;

    public bool? NoMagic { get; } = null;

    public bool? NoTele { get; } = null;

    public bool? PermaCurse { get; } = null;

    public bool? Radius { get; } = null;

    public bool? Reflect { get; } = null;

    public bool? Regen { get; } = null;

    public bool? ResAcid { get; } = null;

    public bool? ResBlind { get; } = null;

    public bool? ResChaos { get; } = null;

    public bool? ResCold { get; } = null;

    public bool? ResConf { get; } = null;

    public bool? ResDark { get; } = null;

    public bool? ResDisen { get; } = null;

    public bool? ResElec { get; } = null;

    public bool? ResFear { get; } = null;

    public bool? ResFire { get; } = null;

    public bool? ResLight { get; } = null;

    public bool? ResNether { get; } = null;

    public bool? ResNexus { get; } = null;

    public bool? ResPois { get; } = null;

    public bool? ResShards { get; } = null;

    public bool? ResSound { get; } = null;

    public bool? SeeInvis { get; } = null;

    public bool? FactoryAllowsShElecricity { get; } = null;

    public bool? ShElec { get; } = null;

    public bool? FactoryAllowsShFire { get; } = null;

    public bool? ShFire { get; } = null;

    public bool? ShowMods { get; } = null;

    public bool? SlayAnimal { get; } = null;

    public bool? SlayDemon { get; } = null;

    public bool? SlayDragon { get; } = null;

    public bool? SlayEvil { get; } = null;

    public bool? SlayGiant { get; } = null;

    public bool? SlayOrc { get; } = null;

    public bool? SlayTroll { get; } = null;

    public bool? SlayUndead { get; } = null;

    public bool? SlowDigest { get; } = null;

    public bool? SustCha { get; } = null;

    public bool? SustCon { get; } = null;

    public bool? SustDex { get; } = null;

    public bool? SustInt { get; } = null;

    public bool? SustStr { get; } = null;

    public bool? SustWis { get; } = null;

    public bool? Telepathy { get; } = null;

    public bool? Teleport { get; } = null;

    public bool? TreasureRating { get; } = null;

    public bool? Vampiric { get; } = null;

    public bool? Vorpal { get; } = null;

    public bool? Wraith { get; } = null;

    public bool? XtraMight { get; } = null;

    public bool? XtraShots { get; } = null;
}
