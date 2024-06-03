// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interfaces;

namespace AngbandOS.Core;

/// <summary>
/// Represents a set of item characteristics.
/// </summary>
[Serializable]
internal class ItemCharacteristics : IItemCharacteristics
{
    public bool Activate { get; set; } = false; // TODO: This should be IActivatible.IsAssignableFrom
    public bool Aggravate { get; set; } = false;
    public bool AntiTheft { get; set; } = false;
    public ArtifactBias? ArtifactBias { get; set; } = null;
    public bool Blessed { get; set; } = false;
    public bool Blows { get; set; } = false;
    public bool BrandAcid { get; set; } = false;
    public bool BrandCold { get; set; } = false;
    public bool BrandElec { get; set; } = false;
    public bool BrandFire { get; set; } = false;
    public bool BrandPois { get; set; } = false;
    public bool Cha { get; set; } = false;
    public bool Chaotic { get; set; } = false;
    public bool Con { get; set; } = false;
    public bool Cursed { get; set; } = false;
    public bool Dex { get; set; } = false;
    public bool DrainExp { get; set; } = false;
    public bool DreadCurse { get; set; } = false;
    public bool EasyKnow { get; set; } = false;
    public bool Feather { get; set; } = false;
    public bool FreeAct { get; set; } = false;
    public bool HeavyCurse { get; set; } = false;
    public bool HideType { get; set; } = false;
    public bool HoldLife { get; set; } = false;
    public bool IgnoreAcid { get; set; } = false;
    public bool IgnoreCold { get; set; } = false;
    public bool IgnoreElec { get; set; } = false;
    public bool IgnoreFire { get; set; } = false;
    public bool ImAcid { get; set; } = false;
    public bool ImCold { get; set; } = false;
    public bool ImElec { get; set; } = false;
    public bool ImFire { get; set; } = false;
    public bool Impact { get; set; } = false;
    public bool Infra { get; set; } = false;
    public bool InstaArt { get; set; } = false;
    public bool Int { get; set; } = false;
    public bool KillDragon { get; set; } = false;
    public bool Lightsource { get; set; } = false;
    public bool NoMagic { get; set; } = false;
    public bool NoTele { get; set; } = false;
    public bool PermaCurse { get; set; } = false;
    public bool Reflect { get; set; } = false;
    public bool Regen { get; set; } = false;
    public bool ResAcid { get; set; } = false;
    public bool ResBlind { get; set; } = false;
    public bool ResChaos { get; set; } = false;
    public bool ResCold { get; set; } = false;
    public bool ResConf { get; set; } = false;
    public bool ResDark { get; set; } = false;
    public bool ResDisen { get; set; } = false;
    public bool ResElec { get; set; } = false;
    public bool ResFear { get; set; } = false;
    public bool ResFire { get; set; } = false;
    public bool ResLight { get; set; } = false;
    public bool ResNether { get; set; } = false;
    public bool ResNexus { get; set; } = false;
    public bool ResPois { get; set; } = false;
    public bool ResShards { get; set; } = false;
    public bool ResSound { get; set; } = false;
    public bool Search { get; set; } = false;
    public bool SeeInvis { get; set; } = false;
    public bool ShElec { get; set; } = false;
    public bool ShFire { get; set; } = false;
    public bool ShowMods { get; set; } = false;
    public bool SlayAnimal { get; set; } = false;
    public bool SlayDemon { get; set; } = false;
    public bool SlayDragon { get; set; } = false;
    public bool SlayEvil { get; set; } = false;
    public bool SlayGiant { get; set; } = false;
    public bool SlayOrc { get; set; } = false;
    public bool SlayTroll { get; set; } = false;
    public bool SlayUndead { get; set; } = false;
    public bool SlowDigest { get; set; } = false;
    public bool Speed { get; set; } = false;
    public bool Stealth { get; set; } = false;
    public bool Str { get; set; } = false;
    public bool SustCha { get; set; } = false;
    public bool SustCon { get; set; } = false;
    public bool SustDex { get; set; } = false;
    public bool SustInt { get; set; } = false;
    public bool SustStr { get; set; } = false;
    public bool SustWis { get; set; } = false;
    public bool Telepathy { get; set; } = false;
    public bool Teleport { get; set; } = false;
    public bool Tunnel { get; set; } = false;
    public bool Vampiric { get; set; } = false;
    public bool Vorpal { get; set; } = false;
    public bool Wis { get; set; } = false;
    public bool Wraith { get; set; } = false;
    public bool XtraMight { get; set; } = false;
    public bool XtraShots { get; set; } = false;

    /// <summary>
    /// Imports the characteristics of another item.
    /// </summary>
    /// <param name="itemCharacteristicsA"></param>
    /// <param name="itemCharacteristicsB"></param>
    public void Copy(IItemCharacteristics itemCharacteristics)
    {
        Activate = itemCharacteristics.Activate;
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
        Lightsource = itemCharacteristics.Lightsource;
        NoMagic = itemCharacteristics.NoMagic;
        NoTele = itemCharacteristics.NoTele;
        PermaCurse = itemCharacteristics.PermaCurse;
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

        Activate |= itemCharacteristics.Activate;
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
        Lightsource |= itemCharacteristics.Lightsource;
        NoMagic |= itemCharacteristics.NoMagic;
        NoTele |= itemCharacteristics.NoTele;
        PermaCurse |= itemCharacteristics.PermaCurse;
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
        Tunnel |= itemCharacteristics.Tunnel;
        Vampiric |= itemCharacteristics.Vampiric;
        Vorpal |= itemCharacteristics.Vorpal;
        Wis |= itemCharacteristics.Wis;
        Wraith |= itemCharacteristics.Wraith;
        XtraMight |= itemCharacteristics.XtraMight;
        XtraShots |= itemCharacteristics.XtraShots;
    }

    /// <summary>
    /// Resets all of the characteristics to false.
    /// </summary>
    public void Clear()
    {
        Activate = false;
        Aggravate = false;
        AntiTheft = false;
        ArtifactBias = null;
        Blessed = false;
        Blows = false;
        BrandAcid = false;
        BrandCold = false;
        BrandElec = false;
        BrandFire = false;
        BrandPois = false;
        Cha = false;
        Chaotic = false;
        Con = false;
        Cursed = false;
        Dex = false;
        DrainExp = false;
        DreadCurse = false;
        EasyKnow = false;
        Feather = false;
        FreeAct = false;
        HeavyCurse = false;
        HideType = false;
        HoldLife = false;
        IgnoreAcid = false;
        IgnoreCold = false;
        IgnoreElec = false;
        IgnoreFire = false;
        ImAcid = false;
        ImCold = false;
        ImElec = false;
        ImFire = false;
        Impact = false;
        Infra = false;
        InstaArt = false;
        Int = false;
        KillDragon = false;
        Lightsource = false;
        NoMagic = false;
        NoTele = false;
        PermaCurse = false;
        Reflect = false;
        Regen = false;
        ResAcid = false;
        ResBlind = false;
        ResChaos = false;
        ResCold = false;
        ResConf = false;
        ResDark = false;
        ResDisen = false;
        ResElec = false;
        ResFear = false;
        ResFire = false;
        ResLight = false;
        ResNether = false;
        ResNexus = false;
        ResPois = false;
        ResShards = false;
        ResSound = false;
        Search = false;
        SeeInvis = false;
        ShElec = false;
        ShFire = false;
        ShowMods = false;
        SlayAnimal = false;
        SlayDemon = false;
        SlayDragon = false;
        SlayEvil = false;
        SlayGiant = false;
        SlayOrc = false;
        SlayTroll = false;
        SlayUndead = false;
        SlowDigest = false;
        Speed = false;
        Stealth = false;
        Str = false;
        SustCha = false;
        SustCon = false;
        SustDex = false;
        SustInt = false;
        SustStr = false;
        SustWis = false;
        Telepathy = false;
        Teleport = false;
        Tunnel = false;
        Vampiric = false;
        Vorpal = false;
        Wis = false;
        Wraith = false;
        XtraMight = false;
        XtraShots = false;
    }

    /// <summary>
    /// Creates a new set of ItemCharacteristics with all false values.
    /// </summary>
    public ItemCharacteristics()
    {
    }
}