// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

/// <summary>
/// Represents a set of read and write item characteristics that are used as the storage for one or more merged <see cref="ItemAdditiveBundle"/> objects.
/// </summary>
[Serializable]
internal class ItemCharacteristics : IItemCharacteristics
{
    /// <inheritdoc/>
    public Activation? Activation { get; set; } = null;

    /// <inheritdoc/>
    public bool Aggravate { get; set; } = false;

    /// <inheritdoc/>
    public bool AntiTheft { get; set; } = false;

    /// <inheritdoc/>
    public ArtifactBias? ArtifactBias { get; set; } = null;

    /// <inheritdoc/>
    public bool Blessed { get; set; } = false;

    /// <inheritdoc/>
    public bool Blows { get; set; } = false;

    /// <inheritdoc/>
    public bool BrandAcid { get; set; } = false;

    /// <inheritdoc/>
    public bool BrandCold { get; set; } = false;

    /// <inheritdoc/>
    public bool BrandElec { get; set; } = false;

    /// <inheritdoc/>
    public bool BrandFire { get; set; } = false;

    /// <inheritdoc/>
    public bool BrandPois { get; set; } = false;

    /// <inheritdoc/>
    public bool Cha { get; set; } = false;

    /// <inheritdoc/>
    public bool Chaotic { get; set; } = false;

    /// <inheritdoc/>
    public bool Con { get; set; } = false;

    /// <inheritdoc/>
    public bool Cursed { get; set; } = false;

    /// <inheritdoc/>
    public bool Dex { get; set; } = false;

    /// <inheritdoc/>
    public bool DrainExp { get; set; } = false;

    /// <inheritdoc/>
    public bool DreadCurse { get; set; } = false;

    /// <inheritdoc/>
    public bool EasyKnow { get; set; } = false;

    /// <inheritdoc/>
    public bool Feather { get; set; } = false;

    /// <inheritdoc/>
    public bool FreeAct { get; set; } = false;

    /// <inheritdoc/>
    public bool HeavyCurse { get; set; } = false;

    /// <inheritdoc/>
    public bool HideType { get; set; } = false;

    /// <inheritdoc/>
    public bool HoldLife { get; set; } = false;

    /// <inheritdoc/>
    public bool IgnoreAcid { get; set; } = false;

    /// <inheritdoc/>
    public bool IgnoreCold { get; set; } = false;

    /// <inheritdoc/>
    public bool IgnoreElec { get; set; } = false;

    /// <inheritdoc/>
    public bool IgnoreFire { get; set; } = false;

    /// <inheritdoc/>
    public bool ImAcid { get; set; } = false;

    /// <inheritdoc/>
    public bool ImCold { get; set; } = false;

    /// <inheritdoc/>
    public bool ImElec { get; set; } = false;

    /// <inheritdoc/>
    public bool ImFire { get; set; } = false;

    /// <inheritdoc/>
    public bool Impact { get; set; } = false;

    /// <inheritdoc/>
    public bool Infra { get; set; } = false;

    /// <inheritdoc/>
    public bool InstaArt { get; set; } = false;

    /// <inheritdoc/>
    public bool Int { get; set; } = false;

    /// <inheritdoc/>
    public bool KillDragon { get; set; } = false;

    /// <inheritdoc/>
    public bool NoMagic { get; set; } = false;

    /// <inheritdoc/>
    public bool NoTele { get; set; } = false;

    /// <inheritdoc/>
    public bool PermaCurse { get; set; } = false;

    /// <inheritdoc/>
    public int Radius { get; set; } = 0;

    /// <inheritdoc/>
    public bool Reflect { get; set; } = false;

    /// <inheritdoc/>
    public bool Regen { get; set; } = false;

    /// <inheritdoc/>
    public bool ResAcid { get; set; } = false;

    /// <inheritdoc/>
    public bool ResBlind { get; set; } = false;

    /// <inheritdoc/>
    public bool ResChaos { get; set; } = false;

    /// <inheritdoc/>
    public bool ResCold { get; set; } = false;

    /// <inheritdoc/>
    public bool ResConf { get; set; } = false;

    /// <inheritdoc/>
    public bool ResDark { get; set; } = false;

    /// <inheritdoc/>
    public bool ResDisen { get; set; } = false;

    /// <inheritdoc/>
    public bool ResElec { get; set; } = false;

    /// <inheritdoc/>
    public bool ResFear { get; set; } = false;

    /// <inheritdoc/>
    public bool ResFire { get; set; } = false;

    /// <inheritdoc/>
    public bool ResLight { get; set; } = false;

    /// <inheritdoc/>
    public bool ResNether { get; set; } = false;

    /// <inheritdoc/>
    public bool ResNexus { get; set; } = false;

    /// <inheritdoc/>
    public bool ResPois { get; set; } = false;

    /// <inheritdoc/>
    public bool ResShards { get; set; } = false;

    /// <inheritdoc/>
    public bool ResSound { get; set; } = false;

    /// <inheritdoc/>
    public bool Search { get; set; } = false;

    /// <inheritdoc/>
    public bool SeeInvis { get; set; } = false;

    /// <inheritdoc/>
    public bool ShElec { get; set; } = false;

    /// <inheritdoc/>
    public bool ShFire { get; set; } = false;

    /// <inheritdoc/>
    public bool ShowMods { get; set; } = false;

    /// <inheritdoc/>
    public bool SlayAnimal { get; set; } = false;

    /// <inheritdoc/>
    public bool SlayDemon { get; set; } = false;

    /// <inheritdoc/>
    public bool SlayDragon { get; set; } = false;

    /// <inheritdoc/>
    public bool SlayEvil { get; set; } = false;

    /// <inheritdoc/>
    public bool SlayGiant { get; set; } = false;

    /// <inheritdoc/>
    public bool SlayOrc { get; set; } = false;

    /// <inheritdoc/>
    public bool SlayTroll { get; set; } = false;

    /// <inheritdoc/>
    public bool SlayUndead { get; set; } = false;

    /// <inheritdoc/>
    public bool SlowDigest { get; set; } = false;

    /// <inheritdoc/>
    public bool Speed { get; set; } = false;

    /// <inheritdoc/>
    public bool Stealth { get; set; } = false;

    /// <inheritdoc/>
    public bool Str { get; set; } = false;

    /// <inheritdoc/>
    public bool SustCha { get; set; } = false;

    /// <inheritdoc/>
    public bool SustCon { get; set; } = false;

    /// <inheritdoc/>
    public bool SustDex { get; set; } = false;

    /// <inheritdoc/>
    public bool SustInt { get; set; } = false;

    /// <inheritdoc/>
    public bool SustStr { get; set; } = false;

    /// <inheritdoc/>
    public bool SustWis { get; set; } = false;

    /// <inheritdoc/>
    public bool Telepathy { get; set; } = false;

    /// <inheritdoc/>
    public bool Teleport { get; set; } = false;

    /// <inheritdoc/>
    public int TreasureRating { get; set; } = 0;

    /// <inheritdoc/>
    public bool Tunnel { get; set; } = false;

    /// <inheritdoc/>
    public bool Vampiric { get; set; } = false;

    /// <inheritdoc/>
    public bool Vorpal { get; set; } = false;

    /// <inheritdoc/>
    public bool Wis { get; set; } = false;

    /// <inheritdoc/>
    public bool Wraith { get; set; } = false;

    /// <inheritdoc/>
    public bool XtraMight { get; set; } = false;

    /// <inheritdoc/>
    public bool XtraShots { get; set; } = false;

    /// <summary>
    /// Imports the characteristics of another item.  This is only needed for the <see cref="Item.Clone"/> method.
    /// </summary>
    /// <param name="itemCharacteristicsA"></param>
    /// <param name="itemCharacteristicsB"></param>
    public void Copy(IItemCharacteristics itemCharacteristics)
    {
        Activation = itemCharacteristics.Activation;
        Aggravate = itemCharacteristics.Aggravate;
        AntiTheft = itemCharacteristics.AntiTheft;
        ArtifactBias = itemCharacteristics.ArtifactBias;
        Blessed = itemCharacteristics.Blessed;
        Blows = itemCharacteristics.Blows;
        BrandAcid = itemCharacteristics.BrandAcid;
        BrandCold = itemCharacteristics.BrandCold;
        BrandElec = itemCharacteristics.BrandElec;
        BrandFire = itemCharacteristics.BrandFire;
        BrandPois = itemCharacteristics.BrandPois;
        Cha = itemCharacteristics.Cha;
        Chaotic = itemCharacteristics.Chaotic;
        Con = itemCharacteristics.Con;
        Cursed = itemCharacteristics.Cursed;
        Dex = itemCharacteristics.Dex;
        DrainExp = itemCharacteristics.DrainExp;
        DreadCurse = itemCharacteristics.DreadCurse;
        EasyKnow = itemCharacteristics.EasyKnow;
        Feather = itemCharacteristics.Feather;
        FreeAct = itemCharacteristics.FreeAct;
        HeavyCurse = itemCharacteristics.HeavyCurse;
        HideType = itemCharacteristics.HideType;
        HoldLife = itemCharacteristics.HoldLife;
        IgnoreAcid = itemCharacteristics.IgnoreAcid;
        IgnoreCold = itemCharacteristics.IgnoreCold;
        IgnoreElec = itemCharacteristics.IgnoreElec;
        IgnoreFire = itemCharacteristics.IgnoreFire;
        ImAcid = itemCharacteristics.ImAcid;
        ImCold = itemCharacteristics.ImCold;
        ImElec = itemCharacteristics.ImElec;
        ImFire = itemCharacteristics.ImFire;
        Impact = itemCharacteristics.Impact;
        Infra = itemCharacteristics.Infra;
        InstaArt = itemCharacteristics.InstaArt;
        Int = itemCharacteristics.Int;
        KillDragon = itemCharacteristics.KillDragon;
        NoMagic = itemCharacteristics.NoMagic;
        NoTele = itemCharacteristics.NoTele;
        PermaCurse = itemCharacteristics.PermaCurse;
        Radius = itemCharacteristics.Radius;
        Reflect = itemCharacteristics.Reflect;
        Regen = itemCharacteristics.Regen;
        ResAcid = itemCharacteristics.ResAcid;
        ResBlind = itemCharacteristics.ResBlind;
        ResChaos = itemCharacteristics.ResChaos;
        ResCold = itemCharacteristics.ResCold;
        ResConf = itemCharacteristics.ResConf;
        ResDark = itemCharacteristics.ResDark;
        ResDisen = itemCharacteristics.ResDisen;
        ResElec = itemCharacteristics.ResElec;
        ResFear = itemCharacteristics.ResFear;
        ResFire = itemCharacteristics.ResFire;
        ResLight = itemCharacteristics.ResLight;
        ResNether = itemCharacteristics.ResNether;
        ResNexus = itemCharacteristics.ResNexus;
        ResPois = itemCharacteristics.ResPois;
        ResShards = itemCharacteristics.ResShards;
        ResSound = itemCharacteristics.ResSound;
        Search = itemCharacteristics.Search;
        SeeInvis = itemCharacteristics.SeeInvis;
        ShElec = itemCharacteristics.ShElec;
        ShFire = itemCharacteristics.ShFire;
        ShowMods = itemCharacteristics.ShowMods;
        SlayAnimal = itemCharacteristics.SlayAnimal;
        SlayDemon = itemCharacteristics.SlayDemon;
        SlayDragon = itemCharacteristics.SlayDragon;
        SlayEvil = itemCharacteristics.SlayEvil;
        SlayGiant = itemCharacteristics.SlayGiant;
        SlayOrc = itemCharacteristics.SlayOrc;
        SlayTroll = itemCharacteristics.SlayTroll;
        SlayUndead = itemCharacteristics.SlayUndead;
        SlowDigest = itemCharacteristics.SlowDigest;
        Speed = itemCharacteristics.Speed;
        Stealth = itemCharacteristics.Stealth;
        Str = itemCharacteristics.Str;
        SustCha = itemCharacteristics.SustCha;
        SustCon = itemCharacteristics.SustCon;
        SustDex = itemCharacteristics.SustDex;
        SustInt = itemCharacteristics.SustInt;
        SustStr = itemCharacteristics.SustStr;
        SustWis = itemCharacteristics.SustWis;
        Telepathy = itemCharacteristics.Telepathy;
        Teleport = itemCharacteristics.Teleport;
        TreasureRating = itemCharacteristics.TreasureRating;
        Tunnel = itemCharacteristics.Tunnel;
        Vampiric = itemCharacteristics.Vampiric;
        Vorpal = itemCharacteristics.Vorpal;
        Wis = itemCharacteristics.Wis;
        Wraith = itemCharacteristics.Wraith;
        XtraMight = itemCharacteristics.XtraMight;
        XtraShots = itemCharacteristics.XtraShots;
    }

    /// <summary>
    /// Merge two sets of item characteristics.  Characteristics are typically merged by using an OR operation.
    /// </summary>
    /// <param name="itemCharacteristics"></param>
    public void Merge(IItemCharacteristics itemCharacteristics)
    {
        if (ArtifactBias == null)
        {
            ArtifactBias = itemCharacteristics.ArtifactBias;
        }

        if (Activation == null)
        {
            Activation = itemCharacteristics.Activation;
        }

        Aggravate |= itemCharacteristics.Aggravate;
        AntiTheft |= itemCharacteristics.AntiTheft;
        Blessed |= itemCharacteristics.Blessed;
        Blows |= itemCharacteristics.Blows;
        BrandAcid |= itemCharacteristics.BrandAcid;
        BrandCold |= itemCharacteristics.BrandCold;
        BrandElec |= itemCharacteristics.BrandElec;
        BrandFire |= itemCharacteristics.BrandFire;
        BrandPois |= itemCharacteristics.BrandPois;
        Cha |= itemCharacteristics.Cha;
        Chaotic |= itemCharacteristics.Chaotic;
        Con |= itemCharacteristics.Con;
        Cursed |= itemCharacteristics.Cursed;
        Dex |= itemCharacteristics.Dex;
        DrainExp |= itemCharacteristics.DrainExp;
        DreadCurse |= itemCharacteristics.DreadCurse;
        EasyKnow |= itemCharacteristics.EasyKnow;
        Feather |= itemCharacteristics.Feather;
        FreeAct |= itemCharacteristics.FreeAct;
        HeavyCurse |= itemCharacteristics.HeavyCurse;
        HideType |= itemCharacteristics.HideType;
        HoldLife |= itemCharacteristics.HoldLife;
        IgnoreAcid |= itemCharacteristics.IgnoreAcid;
        IgnoreCold |= itemCharacteristics.IgnoreCold;
        IgnoreElec |= itemCharacteristics.IgnoreElec;
        IgnoreFire |= itemCharacteristics.IgnoreFire;
        ImAcid |= itemCharacteristics.ImAcid;
        ImCold |= itemCharacteristics.ImCold;
        ImElec |= itemCharacteristics.ImElec;
        ImFire |= itemCharacteristics.ImFire;
        Impact |= itemCharacteristics.Impact;
        Infra |= itemCharacteristics.Infra;
        InstaArt |= itemCharacteristics.InstaArt;
        Int |= itemCharacteristics.Int;
        KillDragon |= itemCharacteristics.KillDragon;
        NoMagic |= itemCharacteristics.NoMagic;
        NoTele |= itemCharacteristics.NoTele;
        PermaCurse |= itemCharacteristics.PermaCurse;

        Radius += itemCharacteristics.Radius;

        Reflect |= itemCharacteristics.Reflect;
        Regen |= itemCharacteristics.Regen;
        ResAcid |= itemCharacteristics.ResAcid;
        ResBlind |= itemCharacteristics.ResBlind;
        ResChaos |= itemCharacteristics.ResChaos;
        ResCold |= itemCharacteristics.ResCold;
        ResConf |= itemCharacteristics.ResConf;
        ResDark |= itemCharacteristics.ResDark;
        ResDisen |= itemCharacteristics.ResDisen;
        ResElec |= itemCharacteristics.ResElec;
        ResFear |= itemCharacteristics.ResFear;
        ResFire |= itemCharacteristics.ResFire;
        ResLight |= itemCharacteristics.ResLight;
        ResNether |= itemCharacteristics.ResNether;
        ResNexus |= itemCharacteristics.ResNexus;
        ResPois |= itemCharacteristics.ResPois;
        ResShards |= itemCharacteristics.ResShards;
        ResSound |= itemCharacteristics.ResSound;
        Search |= itemCharacteristics.Search;
        SeeInvis |= itemCharacteristics.SeeInvis;
        ShElec |= itemCharacteristics.ShElec;
        ShFire |= itemCharacteristics.ShFire;
        ShowMods |= itemCharacteristics.ShowMods;
        SlayAnimal |= itemCharacteristics.SlayAnimal;
        SlayDemon |= itemCharacteristics.SlayDemon;
        SlayDragon |= itemCharacteristics.SlayDragon;
        SlayEvil |= itemCharacteristics.SlayEvil;
        SlayGiant |= itemCharacteristics.SlayGiant;
        SlayOrc |= itemCharacteristics.SlayOrc;
        SlayTroll |= itemCharacteristics.SlayTroll;
        SlayUndead |= itemCharacteristics.SlayUndead;
        SlowDigest |= itemCharacteristics.SlowDigest;
        Speed |= itemCharacteristics.Speed;
        Stealth |= itemCharacteristics.Stealth;
        Str |= itemCharacteristics.Str;
        SustCha |= itemCharacteristics.SustCha;
        SustCon |= itemCharacteristics.SustCon;
        SustDex |= itemCharacteristics.SustDex;
        SustInt |= itemCharacteristics.SustInt;
        SustStr |= itemCharacteristics.SustStr;
        SustWis |= itemCharacteristics.SustWis;
        Telepathy |= itemCharacteristics.Telepathy;
        Teleport |= itemCharacteristics.Teleport;

        TreasureRating += itemCharacteristics.TreasureRating;

        Tunnel |= itemCharacteristics.Tunnel;
        Vampiric |= itemCharacteristics.Vampiric;
        Vorpal |= itemCharacteristics.Vorpal;
        Wis |= itemCharacteristics.Wis;
        Wraith |= itemCharacteristics.Wraith;
        XtraMight |= itemCharacteristics.XtraMight;
        XtraShots |= itemCharacteristics.XtraShots;
    }
}