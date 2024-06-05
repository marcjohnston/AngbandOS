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
    /// <summary>
    /// Returns true, if items of this factory can be activated.  Returns true for all dragon scale mail and rings of ice, acid and flames.  Returns false, by default.  Items produced
    /// by this factory will implement the IItemActivatible interface.
    /// </summary>
    public bool Activate { get; set; } = false; // TODO: This should be IActivatible.IsAssignableFrom
    public bool Aggravate { get; set; } = false;
    public bool AntiTheft { get; set; } = false;
    public ArtifactBias? ArtifactBias { get; set; } = null;
    public bool Blessed { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the blows delivered by the player when being worn.
    /// </summary>
    public bool Blows { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item does extra damage from acid when being wielded.
    /// </summary>
    public bool BrandAcid { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item does extra damage from frost when being wielded.
    /// </summary>
    public bool BrandCold { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item does extra damage from electricity when being wielded.
    /// </summary>
    public bool BrandElec { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item does extra damage from fire when being wielded.
    /// </summary>
    public bool BrandFire { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item poisons foes when being wielded.
    /// </summary>
    public bool BrandPois { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the charisma of the player when being worn.
    /// </summary>
    public bool Cha { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item produced chaotic effects when being wielded.
    /// </summary>
    public bool Chaotic { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the constitution of the player when being worn.
    /// </summary>
    public bool Con { get; set; } = false;
    public bool Cursed { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the dexterity of the player when being worn.
    /// </summary>
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

    /// <summary>
    /// Returns whether or not the item causes earthquakes of the player when being worn.
    /// </summary>
    public bool Impact { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the infravision of the player when being worn.
    /// </summary>
    public bool Infra { get; set; } = false;
    public bool InstaArt { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the intelligence of the player when being worn.
    /// </summary>
    public bool Int { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item is a great bane of dragons.
    /// </summary>
    public bool KillDragon { get; set; } = false;
    public bool NoMagic { get; set; } = false;
    public bool NoTele { get; set; } = false;
    public bool PermaCurse { get; set; } = false;

    /// <summary>
    /// Returns the radius of light that the additive bundle adds to the item light source; or 0, if the additive bundle doesn't modify the item light source capabilities.  Returns 0, by default.
    /// </summary>
    public int Radius { get; set; } = 0;

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
    
    /// <summary>
    /// Returns whether or not the item affects the search capabilities of the player when being worn.
    /// </summary>
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

    /// <summary>
    /// Returns whether or not the item affects the attack speed of the player when being worn.
    /// </summary>
    public bool Speed { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the stealth of the player when being worn.
    /// </summary>
    public bool Stealth { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the strength of the player when being worn.
    /// </summary>
    public bool Str { get; set; } = false;

    public bool SustCha { get; set; } = false;
    public bool SustCon { get; set; } = false;
    public bool SustDex { get; set; } = false;
    public bool SustInt { get; set; } = false;
    public bool SustStr { get; set; } = false;
    public bool SustWis { get; set; } = false;
    public bool Telepathy { get; set; } = false;
    public bool Teleport { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the tunneling capabilities of the player when being worn.
    /// </summary>
    public bool Tunnel { get; set; } = false;

    public bool Vampiric { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item is very sharp and cuts foes of the player when being used.
    /// </summary>
    public bool Vorpal { get; set; } = false;

    /// <summary>
    /// Returns whether or not the item affects the wisdom of the player when being worn.
    /// </summary>
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
        Tunnel |= itemCharacteristics.Tunnel;
        Vampiric |= itemCharacteristics.Vampiric;
        Vorpal |= itemCharacteristics.Vorpal;
        Wis |= itemCharacteristics.Wis;
        Wraith |= itemCharacteristics.Wraith;
        XtraMight |= itemCharacteristics.XtraMight;
        XtraShots |= itemCharacteristics.XtraShots;
    }
}