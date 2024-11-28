// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemEnhancements;

/// <summary>
/// Represents a set of item characteristics that can be merged with another other IItemCharacterstics.  These objects are used by <see cref="RareItem"/> objects and the random 
/// artifact creation process.
/// </summary>
[Serializable]
internal abstract class ItemEnhancement : IGetKey
{
    protected readonly Game Game;
    protected ItemEnhancement(Game game)
    {
        Game = game;
    }

    public IItemCharacteristics GenerateItemCharacteristics()
    {
        ItemCharacteristics itemCharacteristics = new ItemCharacteristics();

        itemCharacteristics.BonusStrength = BonusStrengthRoll == null ? 0 : BonusStrengthRoll.Get(Game.UseRandom);
        itemCharacteristics.BonusIntelligence = BonusIntelligenceRoll == null ? 0 : BonusIntelligenceRoll.Get(Game.UseRandom);
        itemCharacteristics.BonusWisdom = BonusWisdomRoll == null ? 0 : BonusWisdomRoll.Get(Game.UseRandom);
        itemCharacteristics.BonusDexterity = BonusDexterityRoll == null ? 0 : BonusDexterityRoll.Get(Game.UseRandom);
        itemCharacteristics.BonusConstitution = BonusConstitutionRoll == null ? 0 : BonusConstitutionRoll.Get(Game.UseRandom);
        itemCharacteristics.BonusCharisma = BonusCharismaRoll == null ? 0 : BonusCharismaRoll.Get(Game.UseRandom);
        itemCharacteristics.BonusStealth = BonusStealthRoll == null ? 0 : BonusStealthRoll.Get(Game.UseRandom);
        itemCharacteristics.BonusSearch = BonusSearchRoll == null ? 0 : BonusSearchRoll.Get(Game.UseRandom);
        itemCharacteristics.BonusInfravision = BonusInfravisionRoll == null ? 0 : BonusInfravisionRoll.Get(Game.UseRandom);
        itemCharacteristics.BonusTunnel = BonusTunnelRoll == null ? 0 : BonusTunnelRoll.Get(Game.UseRandom);
        itemCharacteristics.BonusAttacks = BonusAttacksRoll == null ? 0 : BonusAttacksRoll.Get(Game.UseRandom);
        itemCharacteristics.BonusSpeed = BonusSpeedRoll == null ? 0 : BonusSpeedRoll.Get(Game.UseRandom);


        itemCharacteristics.Activation = Activation;
        itemCharacteristics.Aggravate = Aggravate;
        itemCharacteristics.AntiTheft = AntiTheft;
        itemCharacteristics.ArtifactBias = ArtifactBias;
        itemCharacteristics.Blessed = Blessed;
        itemCharacteristics.Blows = Blows;
        itemCharacteristics.BrandAcid = BrandAcid;
        itemCharacteristics.BrandCold = BrandCold;
        itemCharacteristics.BrandElec = BrandElec;
        itemCharacteristics.BrandFire = BrandFire;
        itemCharacteristics.BrandPois = BrandPois;
        itemCharacteristics.Cha = Cha;
        itemCharacteristics.Chaotic = Chaotic;
        itemCharacteristics.Con = Con;
        itemCharacteristics.IsCursed = IsCursed;
        itemCharacteristics.Dex = Dex;
        itemCharacteristics.DrainExp = DrainExp;
        itemCharacteristics.DreadCurse = DreadCurse;
        itemCharacteristics.EasyKnow = EasyKnow;
        itemCharacteristics.Feather = Feather;
        itemCharacteristics.FreeAct = FreeAct;
        itemCharacteristics.HeavyCurse = HeavyCurse;
        itemCharacteristics.HideType = HideType;
        itemCharacteristics.HoldLife = HoldLife;
        itemCharacteristics.IgnoreAcid = IgnoreAcid;
        itemCharacteristics.IgnoreCold = IgnoreCold;
        itemCharacteristics.IgnoreElec = IgnoreElec;
        itemCharacteristics.IgnoreFire = IgnoreFire;
        itemCharacteristics.ImAcid = ImAcid;
        itemCharacteristics.ImCold = ImCold;
        itemCharacteristics.ImElec = ImElec;
        itemCharacteristics.ImFire = ImFire;
        itemCharacteristics.Impact = Impact;
        itemCharacteristics.Infra = Infra;
        itemCharacteristics.InstaArt = InstaArt;
        itemCharacteristics.Int = Int;
        itemCharacteristics.KillDragon = KillDragon;
        itemCharacteristics.NoMagic = NoMagic;
        itemCharacteristics.NoTele = NoTele;
        itemCharacteristics.PermaCurse = PermaCurse;
        itemCharacteristics.Radius = Radius;
        itemCharacteristics.Reflect = Reflect;
        itemCharacteristics.Regen = Regen;
        itemCharacteristics.ResAcid = ResAcid;
        itemCharacteristics.ResBlind = ResBlind;
        itemCharacteristics.ResChaos = ResChaos;
        itemCharacteristics.ResCold = ResCold;
        itemCharacteristics.ResConf = ResConf;
        itemCharacteristics.ResDark = ResDark;
        itemCharacteristics.ResDisen = ResDisen;
        itemCharacteristics.ResElec = ResElec;
        itemCharacteristics.ResFear = ResFear;
        itemCharacteristics.ResFire = ResFire;
        itemCharacteristics.ResLight = ResLight;
        itemCharacteristics.ResNether = ResNether;
        itemCharacteristics.ResNexus = ResNexus;
        itemCharacteristics.ResPois = ResPois;
        itemCharacteristics.ResShards = ResShards;
        itemCharacteristics.ResSound = ResSound;
        itemCharacteristics.Search = Search;
        itemCharacteristics.SeeInvis = SeeInvis;
        itemCharacteristics.ShElec = ShElec;
        itemCharacteristics.ShFire = ShFire;
        itemCharacteristics.ShowMods = ShowMods;
        itemCharacteristics.SlayAnimal = SlayAnimal;
        itemCharacteristics.SlayDemon = SlayDemon;
        itemCharacteristics.SlayDragon = SlayDragon;
        itemCharacteristics.SlayEvil = SlayEvil;
        itemCharacteristics.SlayGiant = SlayGiant;
        itemCharacteristics.SlayOrc = SlayOrc;
        itemCharacteristics.SlayTroll = SlayTroll;
        itemCharacteristics.SlayUndead = SlayUndead;
        itemCharacteristics.SlowDigest = SlowDigest;
        itemCharacteristics.Speed = Speed;
        itemCharacteristics.Stealth = Stealth;
        itemCharacteristics.Str = Str;
        itemCharacteristics.SustCha = SustCha;
        itemCharacteristics.SustCon = SustCon;
        itemCharacteristics.SustDex = SustDex;
        itemCharacteristics.SustInt = SustInt;
        itemCharacteristics.SustStr = SustStr;
        itemCharacteristics.SustWis = SustWis;
        itemCharacteristics.Telepathy = Telepathy;
        itemCharacteristics.Teleport = Teleport;
        itemCharacteristics.TreasureRating = TreasureRating;
        itemCharacteristics.Tunnel = Tunnel;
        itemCharacteristics.Vampiric = Vampiric;
        itemCharacteristics.Vorpal = Vorpal;
        itemCharacteristics.Wis = Wis;
        itemCharacteristics.Wraith = Wraith;
        itemCharacteristics.XtraMight = XtraMight;
        itemCharacteristics.XtraShots = XtraShots;
        return itemCharacteristics;
    }

    public virtual string Key => GetType().Name;
    public string GetKey => Key;

    public virtual void Bind()
    {
        Activation = Game.SingletonRepository.GetNullable<Activation>(ActivationName);
        BonusStrengthRoll = Game.ParseNullableRollExpression(BonusStrengthRollExpression);
        BonusIntelligenceRoll = Game.ParseNullableRollExpression(BonusIntelligenceRollExpression);
        BonusWisdomRoll = Game.ParseNullableRollExpression(BonusWisdomRollExpression);
        BonusDexterityRoll = Game.ParseNullableRollExpression(BonusDexterityRollExpression);
        BonusConstitutionRoll = Game.ParseNullableRollExpression(BonusConstitutionRollExpression);
        BonusCharismaRoll = Game.ParseNullableRollExpression(BonusCharismaRollExpression);
        BonusStealthRoll = Game.ParseNullableRollExpression(BonusStealthRollExpression);
        BonusSearchRoll = Game.ParseNullableRollExpression(BonusSearchRollExpression);
        BonusInfravisionRoll = Game.ParseNullableRollExpression(BonusInfravisionRollExpression);
        BonusTunnelRoll = Game.ParseNullableRollExpression(BonusTunnelRollExpression);
        BonusAttacksRoll = Game.ParseNullableRollExpression(BonusAttacksRollExpression);
        BonusSpeedRoll = Game.ParseNullableRollExpression(BonusSpeedRollExpression);
    }

    public string ToJson()
    {
        return "";
    }

    public virtual ItemEnhancement? RandomPower => null;

    /// <summary>
    /// Returns the value of the rare item.  When this value is 0, the item is considered worthless regardless of the value of the original item and the
    /// item is considered broken; otherwise this value is added to the value of the original item.
    /// </summary>
    public virtual int? AdditiveBundleValue => null;

    /// <summary>
    /// Returns the name of the rare item characteristics to append to the description of the original item, or null, to not modify the name.  Returns null, by default.
    /// </summary>
    public virtual string? FriendlyName => null;

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

    /// <summary>
    /// Returns a maximum value for a random amount of additional strength when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item.  Returns 0, by default.
    /// </summary>
    public Roll? BonusStrengthRoll { get; private set; } = null;
    public Roll? BonusIntelligenceRoll { get; private set; } = null;
    public Roll? BonusWisdomRoll { get; private set; } = null;
    public Roll? BonusDexterityRoll { get; private set; } = null;
    public Roll? BonusConstitutionRoll { get; private set; } = null;
    public Roll? BonusCharismaRoll { get; private set; } = null;
    public Roll? BonusStealthRoll { get; private set; } = null;
    public Roll? BonusSearchRoll { get; private set; } = null;
    public Roll? BonusInfravisionRoll { get; private set; } = null;
    public Roll? BonusTunnelRoll { get; private set; } = null;
    public Roll? BonusAttacksRoll { get; private set; } = null;
    public Roll? BonusSpeedRoll { get; private set; } = null;

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusArmorClass when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    public virtual int MaxToA => 0;

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusDamage when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    public virtual int MaxToD => 0;

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusToHit when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    public virtual int MaxToH => 0;

    /// <summary>
    /// Returns then name of an <see cref="Activation "/>, if the item can be activated; or null, if the item cannot be activated.  Dragon scale mail, rings of ice, acid and flames, the planar weapon, fixed artifacts and
    /// random artifacts may have an <see cref="Activation"/>.  Returns null, by default.  This property is used to bind the <see cref="Activation"/> property during the bind phase.
    /// </summary>
    /// <inheritdoc />
    protected virtual string? ActivationName { get; }

    /// <inheritdoc />
    public Activation? Activation { get; protected set; }
    
    /// <inheritdoc />
    public virtual bool Aggravate => false;
    
    /// <inheritdoc />
    public virtual bool AntiTheft => false;
    
    /// <inheritdoc />
    public virtual ArtifactBias? ArtifactBias => null;
    
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
}
