// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

/// <summary>
/// Represents a set of deterministic read and write item characteristics that are used as the storage for one or more merged <see cref="ItemEnhancement"/> objects.
/// </summary>
[Serializable]
internal class ItemCharacteristics : IItemCharacteristics
{
    public bool CanApplyBlessedArtifactBias { get; set; }
    public bool CanApplyArtifactBiasSlaying { get; set; }
    public bool CanApplyBlowsBonus { get; set; }
    public bool CanReflectBoltsAndArrows { get; set; }
    public bool CanApplySlayingBonus { get; set; }
    public bool CanApplyBonusArmorClassMiscPower { get; set; }
    public bool CanProvideSheathOfElectricity { get; set; }
    public bool CanProvideSheathOfFire { get; set; }

    public int BonusHit { get; set; }
    public int BonusArmorClass { get; set; }
    public int BonusDamage { get; set; }
    public int BonusStrength { get; set; }
    public int BonusIntelligence { get; set; }
    public int BonusWisdom { get; set; }
    public int BonusDexterity { get; set; }
    public int BonusConstitution { get; set; }
    public int BonusCharisma { get; set; }
    public int BonusStealth { get; set; }
    public int BonusSearch { get; set; }
    public int BonusInfravision { get; set; }
    public int BonusTunnel { get; set; }
    public int BonusAttacks { get; set; }
    public int BonusSpeed { get; set; }

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
    public bool IsCursed { get; set; } = false;

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
        CanApplyBlessedArtifactBias = itemCharacteristics.CanApplyBlessedArtifactBias;
        CanApplyArtifactBiasSlaying = itemCharacteristics.CanApplyArtifactBiasSlaying;
        CanApplyBlowsBonus = itemCharacteristics.CanApplyBlowsBonus;
        CanReflectBoltsAndArrows = itemCharacteristics.CanReflectBoltsAndArrows;
        CanApplySlayingBonus = itemCharacteristics.CanApplySlayingBonus;
        CanApplyBonusArmorClassMiscPower = itemCharacteristics.CanApplyBonusArmorClassMiscPower;
        CanProvideSheathOfElectricity = itemCharacteristics.CanProvideSheathOfElectricity;
        CanProvideSheathOfFire = itemCharacteristics.CanProvideSheathOfFire;
        BonusHit = itemCharacteristics.BonusHit;
        BonusArmorClass = itemCharacteristics.BonusArmorClass;
        BonusDamage = itemCharacteristics.BonusDamage;
        BonusStrength = itemCharacteristics.BonusStrength;
        BonusIntelligence = itemCharacteristics.BonusIntelligence;
        BonusWisdom = itemCharacteristics.BonusWisdom;
        BonusDexterity = itemCharacteristics.BonusDexterity;
        BonusConstitution = itemCharacteristics.BonusConstitution;
        BonusCharisma = itemCharacteristics.BonusCharisma;
        BonusStealth = itemCharacteristics.BonusStealth;
        BonusSearch = itemCharacteristics.BonusSearch;
        BonusInfravision = itemCharacteristics.BonusInfravision;
        BonusTunnel = itemCharacteristics.BonusTunnel;
        BonusAttacks = itemCharacteristics.BonusAttacks;
        BonusSpeed = itemCharacteristics.BonusSpeed;

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
        IsCursed = itemCharacteristics.IsCursed;
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
    public void Merge(IItemCharacteristics? itemCharacteristics)
    {
        if (itemCharacteristics == null)
        {
            return;
        }

        CanApplyBlessedArtifactBias |= itemCharacteristics.CanApplyBlessedArtifactBias;
        CanApplyArtifactBiasSlaying |= itemCharacteristics.CanApplyArtifactBiasSlaying;
        CanApplyBlowsBonus |= itemCharacteristics.CanApplyBlowsBonus;
        CanReflectBoltsAndArrows |= itemCharacteristics.CanReflectBoltsAndArrows;
        CanApplySlayingBonus |= itemCharacteristics.CanApplySlayingBonus;
        CanApplyBonusArmorClassMiscPower |= itemCharacteristics.CanApplyBonusArmorClassMiscPower;
        CanProvideSheathOfElectricity |= itemCharacteristics.CanProvideSheathOfElectricity;
        CanProvideSheathOfFire |= itemCharacteristics.CanProvideSheathOfFire;

        BonusHit += itemCharacteristics.BonusHit;
        BonusArmorClass += itemCharacteristics.BonusArmorClass;
        BonusDamage += itemCharacteristics.BonusDamage;
        BonusStrength += itemCharacteristics.BonusStrength;
        BonusIntelligence += itemCharacteristics.BonusIntelligence;
        BonusWisdom += itemCharacteristics.BonusWisdom;
        BonusDexterity += itemCharacteristics.BonusDexterity;
        BonusConstitution += itemCharacteristics.BonusConstitution;
        BonusCharisma += itemCharacteristics.BonusCharisma;
        BonusStealth += itemCharacteristics.BonusStealth;
        BonusSearch += itemCharacteristics.BonusSearch;
        BonusInfravision += itemCharacteristics.BonusInfravision;
        BonusTunnel += itemCharacteristics.BonusTunnel;
        BonusAttacks += itemCharacteristics.BonusAttacks;
        BonusSpeed += itemCharacteristics.BonusSpeed;

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
        IsCursed |= itemCharacteristics.IsCursed;
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

    /// <summary>
    /// Returns true, if all of the characteristics between two objects are the same.  This is used to determine if two items can be merged or absorbed.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }
        if (obj is not ItemCharacteristics)
        {
            return false;
        }
        ItemCharacteristics other = (ItemCharacteristics)obj;

        if (CanApplyBlessedArtifactBias != other.CanApplyBlessedArtifactBias)
        {
            return false;
        }
        if (CanApplyArtifactBiasSlaying != other.CanApplyArtifactBiasSlaying)
        {
            return false;
        }
        if (CanApplyBlowsBonus != other.CanApplyBlowsBonus)
        {
            return false;
        }
        if (CanReflectBoltsAndArrows != other.CanReflectBoltsAndArrows)
        {
            return false;
        }
        if (CanApplySlayingBonus != other.CanApplySlayingBonus)
        {
            return false;
        }
        if (CanApplyBonusArmorClassMiscPower != other.CanApplyBonusArmorClassMiscPower)
        {
            return false;
        }
        if (CanProvideSheathOfElectricity != other.CanProvideSheathOfElectricity)
        {
            return false;
        }
        if (CanProvideSheathOfFire != other.CanProvideSheathOfFire)
        {
            return false;
        }

        if (BonusHit != other.BonusHit)
        {
            return false;
        }
        if (BonusArmorClass != other.BonusArmorClass)
        {
            return false;
        }
        if (BonusDamage != other.BonusDamage)
        {
            return false;
        }
        if (BonusStrength != other.BonusStrength)
        {
            return false;
        }
        if (BonusIntelligence != other.BonusIntelligence)
        {
            return false;
        }
        if (BonusWisdom != other.BonusWisdom)
        {
            return false;
        }
        if (BonusDexterity != other.BonusDexterity)
        {
            return false;
        }
        if (BonusConstitution != other.BonusConstitution)
        {
            return false;
        }
        if (BonusCharisma != other.BonusCharisma)
        {
            return false;
        }
        if (BonusStealth != other.BonusStealth)
        {
            return false;
        }
        if (BonusSearch != other.BonusSearch)
        {
            return false;
        }
        if (BonusInfravision != other.BonusInfravision)
        {
            return false;
        }
        if (BonusTunnel != other.BonusTunnel)
        {
            return false;
        }
        if (BonusAttacks != other.BonusAttacks)
        {
            return false;
        }
        if (BonusSpeed != other.BonusSpeed)
        {
            return false;
        }

        if (Activation != other.Activation)
        {
            return false;
        }
        if (Aggravate != other.Aggravate)
        {
            return false;
        }
        if (AntiTheft != other.AntiTheft)
        {
            return false;
        }
        if (ArtifactBias != other.ArtifactBias)
        {
            return false;
        }
        if (Blessed != other.Blessed)
        {
            return false;
        }
        if (Blows != other.Blows)
        {
            return false;
        }
        if (BrandAcid != other.BrandAcid)
        {
            return false;
        }
        if (BrandCold != other.BrandCold)
        {
            return false;
        }
        if (BrandElec != other.BrandElec)
        {
            return false;
        }
        if (BrandFire != other.BrandFire)
        {
            return false;
        }
        if (BrandPois != other.BrandPois)
        {
            return false;
        }
        if (Cha != other.Cha)
        {
            return false;
        }
        if (Chaotic != other.Chaotic)
        {
            return false;
        }
        if (Con != other.Con)
        {
            return false;
        }
        if (IsCursed != other.IsCursed)
        {
            return false;
        }
        if (Dex != other.Dex)
        {
            return false;
        }
        if (DrainExp != other.DrainExp)
        {
            return false;
        }
        if (DreadCurse != other.DreadCurse)
        {
            return false;
        }
        if (EasyKnow != other.EasyKnow)
        {
            return false;
        }
        if (Feather != other.Feather)
        {
            return false;
        }
        if (FreeAct != other.FreeAct)
        {
            return false;
        }
        if (HeavyCurse != other.HeavyCurse)
        {
            return false;
        }
        if (HideType != other.HideType)
        {
            return false;
        }
        if (HoldLife != other.HoldLife)
        {
            return false;
        }
        if (IgnoreAcid != other.IgnoreAcid)
        {
            return false;
        }
        if (IgnoreCold != other.IgnoreCold)
        {
            return false;
        }
        if (IgnoreElec != other.IgnoreElec)
        {
            return false;
        }
        if (IgnoreFire != other.IgnoreFire)
        {
            return false;
        }
        if (ImAcid != other.ImAcid)
        {
            return false;
        }
        if (ImCold != other.ImCold)
        {
            return false;
        }
        if (ImElec != other.ImElec)
        {
            return false;
        }
        if (ImFire != other.ImFire)
        {
            return false;
        }
        if (Impact != other.Impact)
        {
            return false;
        }
        if (Infra != other.Infra)
        {
            return false;
        }
        if (InstaArt != other.InstaArt)
        {
            return false;
        }
        if (Int != other.Int)
        {
            return false;
        }
        if (KillDragon != other.KillDragon)
        {
            return false;
        }
        if (NoMagic != other.NoMagic)
        {
            return false;
        }
        if (NoTele != other.NoTele)
        {
            return false;
        }
        if (PermaCurse != other.PermaCurse)
        {
            return false;
        }
        if (Radius != other.Radius)
        {
            return false;
        }
        if (Reflect != other.Reflect)
        {
            return false;
        }
        if (Regen != other.Regen)
        {
            return false;
        }
        if (ResAcid != other.ResAcid)
        {
            return false;
        }
        if (ResBlind != other.ResBlind)
        {
            return false;
        }
        if (ResChaos != other.ResChaos)
        {
            return false;
        }
        if (ResCold != other.ResCold)
        {
            return false;
        }
        if (ResConf != other.ResConf)
        {
            return false;
        }
        if (ResDark != other.ResDark)
        {
            return false;
        }
        if (ResDisen != other.ResDisen)
        {
            return false;
        }
        if (ResElec != other.ResElec)
        {
            return false;
        }
        if (ResFear != other.ResFear)
        {
            return false;
        }
        if (ResFire != other.ResFire)
        {
            return false;
        }
        if (ResLight != other.ResLight)
        {
            return false;
        }
        if (ResNether != other.ResNether)
        {
            return false;
        }
        if (ResNexus != other.ResNexus)
        {
            return false;
        }
        if (ResPois != other.ResPois)
        {
            return false;
        }
        if (ResShards != other.ResShards)
        {
            return false;
        }
        if (ResSound != other.ResSound)
        {
            return false;
        }
        if (Search != other.Search)
        {
            return false;
        }
        if (SeeInvis != other.SeeInvis)
        {
            return false;
        }
        if (ShElec != other.ShElec)
        {
            return false;
        }
        if (ShFire != other.ShFire)
        {
            return false;
        }
        if (ShowMods != other.ShowMods)
        {
            return false;
        }
        if (SlayAnimal != other.SlayAnimal)
        {
            return false;
        }
        if (SlayDemon != other.SlayDemon)
        {
            return false;
        }
        if (SlayDragon != other.SlayDragon)
        {
            return false;
        }
        if (SlayEvil != other.SlayEvil)
        {
            return false;
        }
        if (SlayGiant != other.SlayGiant)
        {
            return false;
        }
        if (SlayOrc != other.SlayOrc)
        {
            return false;
        }
        if (SlayTroll != other.SlayTroll)
        {
            return false;
        }
        if (SlayUndead != other.SlayUndead)
        {
            return false;
        }
        if (SlowDigest != other.SlowDigest)
        {
            return false;
        }
        if (Speed != other.Speed)
        {
            return false;
        }
        if (Stealth != other.Stealth)
        {
            return false;
        }
        if (Str != other.Str)
        {
            return false;
        }
        if (SustCha != other.SustCha)
        {
            return false;
        }
        if (SustCon != other.SustCon)
        {
            return false;
        }
        if (SustDex != other.SustDex)
        {
            return false;
        }
        if (SustInt != other.SustInt)
        {
            return false;
        }
        if (SustStr != other.SustStr)
        {
            return false;
        }
        if (SustWis != other.SustWis)
        {
            return false;
        }
        if (Telepathy != other.Telepathy)
        {
            return false;
        }
        if (Teleport != other.Teleport)
        {
            return false;
        }
        if (TreasureRating != other.TreasureRating)
        {
            return false;
        }
        if (Tunnel != other.Tunnel)
        {
            return false;
        }
        if (Vampiric != other.Vampiric)
        {
            return false;
        }
        if (Vorpal != other.Vorpal)
        {
            return false;
        }
        if (Wis != other.Wis)
        {
            return false;
        }
        if (Wraith != other.Wraith)
        {
            return false;
        }
        if (XtraMight != other.XtraMight)
        {
            return false;
        }
        if (XtraShots != other.XtraShots)
        {
            return false;
        }
        return true;
    }
    public static bool operator ==(ItemCharacteristics obj1, ItemCharacteristics obj2)
    {
        return obj1.Equals(obj2);
    }

    public static bool operator !=(ItemCharacteristics obj1, ItemCharacteristics obj2)
    {
        return !obj1.Equals(obj2);
    }
}