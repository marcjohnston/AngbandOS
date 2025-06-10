// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Configuration;
namespace AngbandOS.Core;

/// <summary>
/// Represents a set of item characteristics that can be merged with another other IItemCharacterstics.  These objects are used by <see cref="RareItem"/> objects and the random 
/// artifact creation process.
/// </summary>
[Serializable]
internal class GenericItemEnhancement : ItemEnhancement
{
    public GenericItemEnhancement(Game game, ItemEnhancementGameConfiguration itemEnhancementGameConfiguration) : base(game)
    {
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
        Vampiric = itemEnhancementGameConfiguration.Vampiric;
        Vorpal = itemEnhancementGameConfiguration.Vorpal;
        Wis = itemEnhancementGameConfiguration.Wis;
        Wraith = itemEnhancementGameConfiguration.Wraith;
        XtraMight = itemEnhancementGameConfiguration.XtraMight;
        XtraShots = itemEnhancementGameConfiguration.XtraShots;
    }

    public override string Key { get; }

    /// <summary>
    /// Returns the value of the enhancement.
    /// </summary>
    public override int? Value { get; } = null;

    /// <summary>
    /// Returns the <see cref="ItemFactory"/> objects that this <see cref="ItemEnhancement"/> applies to; or null, if this <see cref="ItemEnhancement"/> can
    /// be applied to all <see cref="ItemFactory"/> objects.  This property is used to bind the <see cref="ApplicableItemFactories"/> property.
    /// </summary>
    protected override string[]? ApplicableItemFactoryBindingKeys { get; } = null;

    protected override string? AdditionalItemEnhancementWeightedRandomBindingKey { get; } = null;

    /// <summary>
    /// Returns the name of the rare item characteristics to append to the description of the original item, or null, to not modify the name.  Returns null, by default.
    /// </summary>
    public override string? FriendlyName { get; } = null;

    protected override string? BonusStrengthRollExpression { get; } = null;
    protected override string? BonusIntelligenceRollExpression { get; } = null;
    protected override string? BonusWisdomRollExpression { get; } = null;
    protected override string? BonusDexterityRollExpression { get; } = null;
    protected override string? BonusConstitutionRollExpression { get; } = null;
    protected override string? BonusCharismaRollExpression { get; } = null;
    protected override string? BonusStealthRollExpression { get; } = null;
    protected override string? BonusSearchRollExpression { get; } = null;
    protected override string? BonusInfravisionRollExpression { get; } = null;
    protected override string? BonusTunnelRollExpression { get; } = null;
    protected override string? BonusAttacksRollExpression { get; } = null;
    protected override string? BonusSpeedRollExpression { get; } = null;
    protected override string? BonusArmorClassRollExpression { get; } = null;
    protected override string? BonusHitRollExpression { get; } = null;
    protected override string? BonusDamageRollExpression { get; } = null;

    /// <summary>
    /// Returns then name of an <see cref="Activation "/>, if the item can be activated; or null, if the item cannot be activated.  Dragon scale mail, rings of ice, acid and flames, the planar weapon, fixed artifacts and
    /// random artifacts may have an <see cref="Activation"/>.  Returns null, by default.  This property is used to bind the <see cref="Activation"/> property during the bind phase.
    /// </summary>
    /// <inheritdoc />
    protected override string? ActivationName { get; }
    public override bool Aggravate { get; } = false;
    public override bool AntiTheft { get; } = false;
    protected override string? ArtifactBiasWeightedRandomBindingKey { get; } = null;
    public override bool Blessed { get; } = false;
    public override bool Blows { get; } = false;
    public override bool BrandAcid { get; } = false;
    public override bool BrandCold { get; } = false;
    public override bool BrandElec { get; } = false;
    public override bool BrandFire { get; } = false;
    public override bool BrandPois { get; } = false;
    public override bool Cha { get; } = false;
    public override bool Chaotic { get; } = false;
    public override bool Con { get; } = false;
    public override bool IsCursed { get; } = false;
    public override bool Dex { get; } = false;
    public override bool DrainExp { get; } = false;
    public override bool DreadCurse { get; } = false;
    public override bool EasyKnow { get; } = false;
    public override bool Feather { get; } = false;
    public override bool FreeAct { get; } = false;
    public override bool HeavyCurse { get; } = false;
    public override bool HideType { get; } = false;
    public override bool HoldLife { get; } = false;
    public override bool IgnoreAcid { get; } = false;
    public override bool IgnoreCold { get; } = false;
    public override bool IgnoreElec { get; } = false;
    public override bool IgnoreFire { get; } = false;
    public override bool ImAcid { get; } = false;
    public override bool ImCold { get; } = false;
    public override bool ImElec { get; } = false;
    public override bool ImFire { get; } = false;
    public override bool Impact { get; } = false;
    public override bool Infra { get; } = false;
    public override bool InstaArt { get; } = false;
    public override bool Int { get; } = false;
    public override bool KillDragon { get; } = false;
    public override bool NoMagic { get; } = false;
    public override bool NoTele { get; } = false;
    public override bool PermaCurse { get; } = false;
    public override int Radius { get; } = 0;
    public override bool Reflect { get; } = false;
    public override bool Regen { get; } = false;
    public override bool ResAcid { get; } = false;
    public override bool ResBlind { get; } = false;
    public override bool ResChaos { get; } = false;
    public override bool ResCold { get; } = false;
    public override bool ResConf { get; } = false;
    public override bool ResDark { get; } = false;
    public override bool ResDisen { get; } = false;
    public override bool ResElec { get; } = false;
    public override bool ResFear { get; } = false;
    public override bool ResFire { get; } = false;
    public override bool ResLight { get; } = false;
    public override bool ResNether { get; } = false;
    public override bool ResNexus { get; } = false;
    public override bool ResPois { get; } = false;
    public override bool ResShards { get; } = false;
    public override bool ResSound { get; } = false;
    public override bool Search { get; } = false;
    public override bool SeeInvis { get; } = false;
    public override bool ShElec { get; } = false;
    public override bool ShFire { get; } = false;
    public override bool ShowMods { get; } = false;
    public override bool SlayAnimal { get; } = false;
    public override bool SlayDemon { get; } = false;
    public override bool SlayDragon { get; } = false;
    public override bool SlayEvil { get; } = false;
    public override bool SlayGiant { get; } = false;
    public override bool SlayOrc { get; } = false;
    public override bool SlayTroll { get; } = false;
    public override bool SlayUndead { get; } = false;
    public override bool SlowDigest { get; } = false;
    public override bool Speed { get; } = false;
    public override bool Stealth { get; } = false;
    public override bool Str { get; } = false;
    public override bool SustCha { get; } = false;
    public override bool SustCon { get; } = false;
    public override bool SustDex { get; } = false;
    public override bool SustInt { get; } = false;
    public override bool SustStr { get; } = false;
    public override bool SustWis { get; } = false;
    public override bool Telepathy { get; } = false;
    public override bool Teleport { get; } = false;
    public override int TreasureRating { get; } = 0;
    public override bool Tunnel { get; } = false;
    public override bool Vampiric { get; } = false;
    public override bool Vorpal { get; } = false;
    public override bool Wis { get; } = false;
    public override bool Wraith { get; } = false;
    public override bool XtraMight { get; } = false;
    public override bool XtraShots { get; } = false;
}
