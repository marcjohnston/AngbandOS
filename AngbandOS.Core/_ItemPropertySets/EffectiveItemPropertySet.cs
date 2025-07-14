// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class EffectiveItemPropertySet
{
    private RoItemPropertySet BaseItemPropertySet { get; }
    private OverrideItemPropertySet OverrideItemPropertySet { get; }
    private RwItemPropertySet RwItemPropertySet { get; }
    public EffectiveItemPropertySet(RoItemPropertySet baseItemPropertySet, RwItemPropertySet rwItemPropertySet, OverrideItemPropertySet overrideItemPropertySet)
    {
        BaseItemPropertySet = baseItemPropertySet;
        RwItemPropertySet = rwItemPropertySet;
        OverrideItemPropertySet = overrideItemPropertySet;
    }

    #region Properties
    public bool CanApplyBlessedArtifactBias
    {
        get
        {
            return BaseItemPropertySet.CanApplyBlessedArtifactBias || RwItemPropertySet.CanApplyBlessedArtifactBias;
        }
        set
        {
            RwItemPropertySet.CanApplyBlessedArtifactBias = value;
        }
    }
    public bool CanApplyArtifactBiasSlaying
    {
        get
        {
            return BaseItemPropertySet.CanApplyArtifactBiasSlaying || RwItemPropertySet.CanApplyArtifactBiasSlaying;
        }
        set
        {
            RwItemPropertySet.CanApplyArtifactBiasSlaying = value;
        }
    }
    public bool CanApplyBlowsBonus
    {
        get
        {
            return BaseItemPropertySet.CanApplyBlessedArtifactBias || RwItemPropertySet.CanApplyArtifactBiasSlaying;
        }
        set
        {
            RwItemPropertySet.CanApplyArtifactBiasSlaying = value;
        }
    }
    public bool CanReflectBoltsAndArrows
    {
        get
        {
            return BaseItemPropertySet.CanReflectBoltsAndArrows || RwItemPropertySet.CanReflectBoltsAndArrows;
        }
        set
        {
            RwItemPropertySet.CanReflectBoltsAndArrows = value;
        }
    }
    public bool CanApplySlayingBonus
    {
        get
        {
            return BaseItemPropertySet.CanApplySlayingBonus || RwItemPropertySet.CanApplySlayingBonus;
        }
        set
        {
            RwItemPropertySet.CanApplySlayingBonus = value;
        }
    }
    public bool CanApplyBonusArmorClassMiscPower
    {
        get
        {
            return BaseItemPropertySet.CanApplyBonusArmorClassMiscPower || RwItemPropertySet.CanApplyBonusArmorClassMiscPower;
        }
        set
        {
            RwItemPropertySet.CanApplyBonusArmorClassMiscPower = value;
        }
    }
    public bool CanProvideSheathOfElectricity
    {
        get
        {
            return BaseItemPropertySet.CanProvideSheathOfElectricity || RwItemPropertySet.CanProvideSheathOfElectricity;
        }
        set
        {
            RwItemPropertySet.CanProvideSheathOfElectricity = value;
        }
    }
    public bool CanProvideSheathOfFire
    {
        get
        {
            return BaseItemPropertySet.CanProvideSheathOfFire || RwItemPropertySet.CanProvideSheathOfFire;
        }
        set
        {
            RwItemPropertySet.CanProvideSheathOfElectricity = value;
        }
    }
    public int BonusHit
    {
        get
        {
            return BaseItemPropertySet.BonusHit + RwItemPropertySet.BonusHit;
        }
        set
        {
            RwItemPropertySet.BonusHit = value;
        }
    }
    public int BonusArmorClass
    {
        get
        {
            return BaseItemPropertySet.BonusArmorClass + RwItemPropertySet.BonusArmorClass;
        }
        set
        {
            RwItemPropertySet.BonusArmorClass = value;
        }
    }
    public int BonusDamage
    {
        get
        {
            return BaseItemPropertySet.BonusDamage + RwItemPropertySet.BonusDamage;
        }
        set
        {
            RwItemPropertySet.BonusDamage = value;
        }
    }
    public int BonusStrength
    {
        get
        {
            return BaseItemPropertySet.BonusStrength + RwItemPropertySet.BonusStrength;
        }
        set
        {
            RwItemPropertySet.BonusStrength = value;
        }
    }
    public int BonusIntelligence
    {
        get
        {
            return BaseItemPropertySet.BonusIntelligence + RwItemPropertySet.BonusIntelligence;
        }
        set
        {
            RwItemPropertySet.BonusIntelligence = value;
        }
    }
    public int BonusWisdom
    {
        get
        {
            return BaseItemPropertySet.BonusWisdom + RwItemPropertySet.BonusWisdom;
        }
        set
        {
            RwItemPropertySet.BonusWisdom = value;
        }
    }
    public int BonusDexterity
    {
        get
        {
            return BaseItemPropertySet.BonusDexterity + RwItemPropertySet.BonusDexterity;
        }
        set
        {
            RwItemPropertySet.BonusDexterity = value;
        }
    }
    public int BonusConstitution
    {
        get
        {
            return BaseItemPropertySet.BonusConstitution + RwItemPropertySet.BonusConstitution;
        }
        set
        {
            RwItemPropertySet.BonusConstitution = value;
        }
    }
    public int BonusCharisma
    {
        get
        {
            return BaseItemPropertySet.BonusCharisma + RwItemPropertySet.BonusCharisma;
        }
        set
        {
            RwItemPropertySet.BonusCharisma = value;
        }
    }
    public int BonusStealth
    {
        get
        {
            return BaseItemPropertySet.BonusStealth + RwItemPropertySet.BonusStealth;
        }
        set
        {
            RwItemPropertySet.BonusStealth = value;
        }
    }
    public int BonusSearch
    {
        get
        {
            return BaseItemPropertySet.BonusSearch + RwItemPropertySet.BonusSearch;
        }
        set
        {
            RwItemPropertySet.BonusSearch = value;
        }
    }
    public int BonusInfravision
    {
        get
        {
            return BaseItemPropertySet.BonusInfravision + RwItemPropertySet.BonusInfravision;
        }
        set
        {
            RwItemPropertySet.BonusInfravision = value;
        }
    }
    public int BonusTunnel
    {
        get
        {
            return BaseItemPropertySet.BonusTunnel + RwItemPropertySet.BonusTunnel;
        }
        set
        {
            RwItemPropertySet.BonusTunnel = value;
        }
    }
    public int BonusAttacks
    {
        get
        {
            return BaseItemPropertySet.BonusAttacks + RwItemPropertySet.BonusAttacks;
        }
        set
        {
            RwItemPropertySet.BonusAttacks = value;
        }
    }
    public int BonusSpeed
    {
        get
        {
            return BaseItemPropertySet.BonusSpeed + RwItemPropertySet.BonusSpeed;
        }
        set
        {
            RwItemPropertySet.BonusSpeed = value;
        }
    }
    public Activation? Activation
    {
        get
        {
            return RwItemPropertySet.Activation ?? BaseItemPropertySet.Activation;
        }
        set
        {
            RwItemPropertySet.Activation = value;
        }
    }
    public bool Aggravate
    {
        get
        {
            return BaseItemPropertySet.Aggravate;
        }
        set
        {
            RwItemPropertySet.Aggravate = value;
        }
    }
    public bool AntiTheft
    {
        get
        {
            return BaseItemPropertySet.AntiTheft || RwItemPropertySet.AntiTheft;
        }
        set
        {
            RwItemPropertySet.AntiTheft = value;
        }
    }
    public ArtifactBias? ArtifactBias
    {
        get
        {
            return RwItemPropertySet.ArtifactBias ?? BaseItemPropertySet.ArtifactBias;
        }
        set
        {
            RwItemPropertySet.ArtifactBias = value;
        }
    }
    public bool Blessed
    {
        get
        {
            return BaseItemPropertySet.Blessed || RwItemPropertySet.Blessed;
        }
        set
        {
            RwItemPropertySet.Blessed = value;
        }
    }
    public bool Blows
    {
        get
        {
            return BaseItemPropertySet.Blows || RwItemPropertySet.Blows;
        }
        set
        {
            RwItemPropertySet.Blows = value;
        }
    }
    public bool BrandAcid
    {
        get
        {
            return BaseItemPropertySet.BrandAcid || RwItemPropertySet.BrandAcid;
        }
        set
        {
            RwItemPropertySet.BrandAcid = value;
        }
    }
    public bool BrandCold
    {
        get
        {
            return BaseItemPropertySet.BrandCold || RwItemPropertySet.BrandCold;
        }
        set
        {
            RwItemPropertySet.BrandCold = value;
        }
    }
    public bool BrandElec
    {
        get
        {
            return BaseItemPropertySet.BrandElec || RwItemPropertySet.BrandElec;
        }
        set
        {
            RwItemPropertySet.BrandElec = value;
        }
    }
    public bool BrandFire
    {
        get
        {
            return BaseItemPropertySet.BrandFire || RwItemPropertySet.BrandFire;
        }
        set
        {
            RwItemPropertySet.BrandFire = value;
        }
    }
    public bool BrandPois
    {
        get
        {
            return BaseItemPropertySet.BrandPois || RwItemPropertySet.BrandPois;
        }
        set
        {
            RwItemPropertySet.BrandPois = value;
        }
    }
    public bool Cha
    {
        get
        {
            return BaseItemPropertySet.Cha || RwItemPropertySet.Cha;
        }
        set
        {
            RwItemPropertySet.Cha = value;
        }
    }
    public bool Chaotic
    {
        get
        {
            return BaseItemPropertySet.Chaotic || RwItemPropertySet.Chaotic;
        }
        set
        {
            RwItemPropertySet.Chaotic = value;
        }
    }
    public bool Con
    {
        get
        {
            return BaseItemPropertySet.Con || RwItemPropertySet.Con;
        }
        set
        {
            RwItemPropertySet.Con = value;
        }
    }
    public bool IsCursed
    {
        get
        {
            return OverrideItemPropertySet.IsCursed ?? BaseItemPropertySet.IsCursed || RwItemPropertySet.IsCursed;
        }
        set
        {
            RwItemPropertySet.IsCursed = value;
        }
    }
    public bool Dex
    {
        get
        {
            return BaseItemPropertySet.Dex || RwItemPropertySet.Dex;
        }
        set
        {
            RwItemPropertySet.Dex = value;
        }
    }
    public bool DrainExp
    {
        get
        {
            return BaseItemPropertySet.DrainExp || RwItemPropertySet.DrainExp;
        }
        set
        {
            RwItemPropertySet.DrainExp = value;
        }
    }
    public bool DreadCurse
    {
        get
        {
            return BaseItemPropertySet.DreadCurse || RwItemPropertySet.DreadCurse;
        }
        set
        {
            RwItemPropertySet.DreadCurse = value;
        }
    }
    public bool EasyKnow
    {
        get
        {
            return BaseItemPropertySet.EasyKnow || RwItemPropertySet.EasyKnow;
        }
        set
        {
            RwItemPropertySet.EasyKnow = value;
        }
    }
    public bool Feather
    {
        get
        {
            return BaseItemPropertySet.Feather || RwItemPropertySet.Feather;
        }
        set
        {
            RwItemPropertySet.Feather = value;
        }
    }
    public bool FreeAct
    {
        get
        {
            return BaseItemPropertySet.FreeAct || RwItemPropertySet.FreeAct;
        }
        set
        {
            RwItemPropertySet.FreeAct = value;
        }
    }
    public bool HeavyCurse
    {
        get
        {
            return OverrideItemPropertySet.HeavyCurse ?? BaseItemPropertySet.HeavyCurse || RwItemPropertySet.HeavyCurse;
        }
        set
        {
            RwItemPropertySet.HeavyCurse = value;
        }
    }
    public bool HideType
    {
        get
        {
            return BaseItemPropertySet.HideType || RwItemPropertySet.HideType;
        }
        set
        {
            RwItemPropertySet.HideType = value;
        }
    }
    public bool HoldLife
    {
        get
        {
            return BaseItemPropertySet.HoldLife || RwItemPropertySet.HoldLife;
        }
        set
        {
            RwItemPropertySet.HoldLife = value;
        }
    }
    public bool IgnoreAcid
    {
        get
        {
            return BaseItemPropertySet.IgnoreAcid || RwItemPropertySet.IgnoreAcid;
        }
        set
        {
            RwItemPropertySet.IgnoreAcid = value;
        }
    }
    public bool IgnoreCold
    {
        get
        {
            return BaseItemPropertySet.IgnoreCold || RwItemPropertySet.IgnoreCold;
        }
        set
        {
            RwItemPropertySet.IgnoreCold = value;
        }
    }
    public bool IgnoreElec
    {
        get
        {
            return BaseItemPropertySet.IgnoreElec || RwItemPropertySet.IgnoreElec;
        }
        set
        {
            RwItemPropertySet.IgnoreElec = value;
        }
    }
    public bool IgnoreFire
    {
        get
        {
            return BaseItemPropertySet.IgnoreFire || RwItemPropertySet.IgnoreFire;
        }
        set
        {
            RwItemPropertySet.IgnoreFire = value;
        }
    }
    public bool ImAcid
    {
        get
        {
            return BaseItemPropertySet.ImAcid || RwItemPropertySet.ImAcid;
        }
        set
        {
            RwItemPropertySet.ImAcid = value;
        }
    }
    public bool ImCold
    {
        get
        {
            return BaseItemPropertySet.ImCold || RwItemPropertySet.ImCold;
        }
        set
        {
            RwItemPropertySet.ImCold = value;
        }
    }
    public bool ImElec
    {
        get
        {
            return BaseItemPropertySet.ImElec || RwItemPropertySet.ImElec;
        }
        set
        {
            RwItemPropertySet.ImElec = value;
        }
    }
    public bool ImFire
    {
        get
        {
            return BaseItemPropertySet.ImFire || RwItemPropertySet.ImFire;
        }
        set
        {
            RwItemPropertySet.ImFire = value;
        }
    }
    public bool Impact
    {
        get
        {
            return BaseItemPropertySet.Impact || RwItemPropertySet.Impact;
        }
        set
        {
            RwItemPropertySet.Impact = value;
        }
    }
    public bool Infra
    {
        get
        {
            return BaseItemPropertySet.Infra || RwItemPropertySet.Infra;
        }
        set
        {
            RwItemPropertySet.Infra = value;
        }
    }
    public bool InstaArt
    {
        get
        {
            return BaseItemPropertySet.InstaArt || RwItemPropertySet.InstaArt;
        }
        set
        {
            RwItemPropertySet.InstaArt = value;
        }
    }
    public bool Int
    {
        get
        {
            return BaseItemPropertySet.Int || RwItemPropertySet.Int;
        }
        set
        {
            RwItemPropertySet.Int = value;
        }
    }
    public bool KillDragon
    {
        get
        {
            return BaseItemPropertySet.KillDragon || RwItemPropertySet.KillDragon;
        }
        set
        {
            RwItemPropertySet.KillDragon = value;
        }
    }
    public bool NoMagic
    {
        get
        {
            return BaseItemPropertySet.NoMagic || RwItemPropertySet.NoMagic;
        }
        set
        {
            RwItemPropertySet.NoMagic = value;
        }
    }
    public bool NoTele
    {
        get
        {
            return BaseItemPropertySet.NoTele || RwItemPropertySet.NoTele;
        }
        set
        {
            RwItemPropertySet.NoTele = value;
        }
    }
    public bool PermaCurse
    {
        get
        {
            return BaseItemPropertySet.PermaCurse || RwItemPropertySet.PermaCurse;
        }
        set
        {
            RwItemPropertySet.PermaCurse = value;
        }
    }
    public int Radius
    {
        get
        {
            return BaseItemPropertySet.Radius + RwItemPropertySet.Radius;
        }
        set
        {
            RwItemPropertySet.Radius = value;
        }
    }
    public bool Reflect
    {
        get
        {
            return BaseItemPropertySet.Reflect || RwItemPropertySet.Reflect;
        }
        set
        {
            RwItemPropertySet.Reflect = value;
        }
    }
    public bool Regen
    {
        get
        {
            return BaseItemPropertySet.Regen || RwItemPropertySet.Regen;
        }
        set
        {
            RwItemPropertySet.Regen = value;
        }
    }
    public bool ResAcid
    {
        get
        {
            return BaseItemPropertySet.ResAcid || RwItemPropertySet.ResAcid;
        }
        set
        {
            RwItemPropertySet.ResAcid = value;
        }
    }
    public bool ResBlind
    {
        get
        {
            return BaseItemPropertySet.ResBlind || RwItemPropertySet.ResBlind;
        }
        set
        {
            RwItemPropertySet.ResBlind = value;
        }
    }
    public bool ResChaos
    {
        get
        {
            return BaseItemPropertySet.ResChaos || RwItemPropertySet.ResChaos;
        }
        set
        {
            RwItemPropertySet.ResChaos = value;
        }
    }
    public bool ResCold
    {
        get
        {
            return BaseItemPropertySet.ResCold || RwItemPropertySet.ResCold;
        }
        set
        {
            RwItemPropertySet.ResCold = value;
        }
    }
    public bool ResConf
    {
        get
        {
            return BaseItemPropertySet.ResConf || RwItemPropertySet.ResConf;
        }
        set
        {
            RwItemPropertySet.ResConf = value;
        }
    }
    public bool ResDark
    {
        get
        {
            return BaseItemPropertySet.ResDark || RwItemPropertySet.ResDark;
        }
        set
        {
            RwItemPropertySet.ResDark = value;
        }
    }
    public bool ResDisen
    {
        get
        {
            return BaseItemPropertySet.ResDisen || RwItemPropertySet.ResDisen;
        }
        set
        {
            RwItemPropertySet.ResDisen = value;
        }
    }
    public bool ResElec
    {
        get
        {
            return BaseItemPropertySet.ResElec || RwItemPropertySet.ResElec;
        }
        set
        {
            RwItemPropertySet.ResElec = value;
        }
    }
    public bool ResFear
    {
        get
        {
            return BaseItemPropertySet.ResFear || RwItemPropertySet.ResFear;
        }
        set
        {
            RwItemPropertySet.ResFear = value;
        }
    }
    public bool ResFire
    {
        get
        {
            return BaseItemPropertySet.ResFire || RwItemPropertySet.ResFire;
        }
        set
        {
            RwItemPropertySet.ResFire = value;
        }
    }
    public bool ResLight
    {
        get
        {
            return BaseItemPropertySet.ResLight || RwItemPropertySet.ResLight;
        }
        set
        {
            RwItemPropertySet.ResLight = value;
        }
    }
    public bool ResNether
    {
        get
        {
            return BaseItemPropertySet.ResNether || RwItemPropertySet.ResNether;
        }
        set
        {
            RwItemPropertySet.ResNether = value;
        }
    }
    public bool ResNexus
    {
        get
        {
            return BaseItemPropertySet.ResNexus || RwItemPropertySet.ResNexus;
        }
        set
        {
            RwItemPropertySet.ResNexus = value;
        }
    }
    public bool ResPois
    {
        get
        {
            return BaseItemPropertySet.ResPois || RwItemPropertySet.ResPois;
        }
        set
        {
            RwItemPropertySet.ResPois = value;
        }
    }
    public bool ResShards
    {
        get
        {
            return BaseItemPropertySet.ResShards || RwItemPropertySet.ResShards;
        }
        set
        {
            RwItemPropertySet.ResShards = value;
        }
    }
    public bool ResSound
    {
        get
        {
            return BaseItemPropertySet.ResSound || RwItemPropertySet.ResSound;
        }
        set
        {
            RwItemPropertySet.ResSound = value;
        }
    }
    public bool Search
    {
        get
        {
            return BaseItemPropertySet.Search || RwItemPropertySet.Search;
        }
        set
        {
            RwItemPropertySet.Search = value;
        }
    }
    public bool SeeInvis
    {
        get
        {
            return BaseItemPropertySet.SeeInvis || RwItemPropertySet.SeeInvis;
        }
        set
        {
            RwItemPropertySet.SeeInvis = value;
        }
    }
    public bool ShElec
    {
        get
        {
            return BaseItemPropertySet.ShElec || RwItemPropertySet.ShElec;
        }
        set
        {
            RwItemPropertySet.ShElec = value;
        }
    }
    public bool ShFire
    {
        get
        {
            return BaseItemPropertySet.ShFire || RwItemPropertySet.ShFire;
        }
        set
        {
            RwItemPropertySet.ShFire = value;
        }
    }
    public bool ShowMods
    {
        get
        {
            return BaseItemPropertySet.ShowMods || RwItemPropertySet.ShowMods;
        }
        set
        {
            RwItemPropertySet.ShowMods = value;
        }
    }
    public bool SlayAnimal
    {
        get
        {
            return BaseItemPropertySet.SlayAnimal || RwItemPropertySet.SlayAnimal;
        }
        set
        {
            RwItemPropertySet.SlayAnimal = value;
        }
    }
    public bool SlayDemon
    {
        get
        {
            return BaseItemPropertySet.SlayDemon || RwItemPropertySet.SlayDemon;
        }
        set
        {
            RwItemPropertySet.SlayDemon = value;
        }
    }
    public bool SlayDragon
    {
        get
        {
            return BaseItemPropertySet.SlayDragon || RwItemPropertySet.SlayDragon;
        }
        set
        {
            RwItemPropertySet.SlayDragon = value;
        }
    }
    public bool SlayEvil
    {
        get
        {
            return BaseItemPropertySet.SlayEvil || RwItemPropertySet.SlayEvil;
        }
        set
        {
            RwItemPropertySet.SlayEvil = value;
        }
    }
    public bool SlayGiant
    {
        get
        {
            return BaseItemPropertySet.SlayGiant || RwItemPropertySet.SlayGiant;
        }
        set
        {
            RwItemPropertySet.SlayGiant = value;
        }
    }
    public bool SlayOrc
    {
        get
        {
            return BaseItemPropertySet.SlayOrc || RwItemPropertySet.SlayOrc;
        }
        set
        {
            RwItemPropertySet.SlayOrc = value;
        }
    }
    public bool SlayTroll
    {
        get
        {
            return BaseItemPropertySet.SlayTroll || RwItemPropertySet.SlayTroll;
        }
        set
        {
            RwItemPropertySet.SlayTroll = value;
        }
    }
    public bool SlayUndead
    {
        get
        {
            return BaseItemPropertySet.SlayUndead || RwItemPropertySet.SlayUndead;
        }
        set
        {
            RwItemPropertySet.SlayUndead = value;
        }
    }
    public bool SlowDigest
    {
        get
        {
            return BaseItemPropertySet.SlowDigest || RwItemPropertySet.SlowDigest;
        }
        set
        {
            RwItemPropertySet.SlowDigest = value;
        }
    }
    public bool Speed
    {
        get
        {
            return BaseItemPropertySet.Speed || RwItemPropertySet.Speed;
        }
        set
        {
            RwItemPropertySet.Speed = value;
        }
    }
    public bool Stealth
    {
        get
        {
            return BaseItemPropertySet.Stealth || RwItemPropertySet.Stealth;
        }
        set
        {
            RwItemPropertySet.Stealth = value;
        }
    }
    public bool Str
    {
        get
        {
            return BaseItemPropertySet.Str || RwItemPropertySet.Str;
        }
        set
        {
            RwItemPropertySet.Str = value;
        }
    }
    public bool SustCha
    {
        get
        {
            return BaseItemPropertySet.SustCha || RwItemPropertySet.SustCha;
        }
        set
        {
            RwItemPropertySet.SustCha = value;
        }
    }
    public bool SustCon
    {
        get
        {
            return BaseItemPropertySet.SustCon || RwItemPropertySet.SustCon;
        }
        set
        {
            RwItemPropertySet.SustCon = value;
        }
    }
    public bool SustDex
    {
        get
        {
            return BaseItemPropertySet.SustDex || RwItemPropertySet.SustDex;
        }
        set
        {
            RwItemPropertySet.SustDex = value;
        }
    }
    public bool SustInt
    {
        get
        {
            return BaseItemPropertySet.SustInt || RwItemPropertySet.SustInt;
        }
        set
        {
            RwItemPropertySet.SustInt = value;
        }
    }
    public bool SustStr
    {
        get
        {
            return BaseItemPropertySet.SustStr || RwItemPropertySet.SustStr;
        }
        set
        {
            RwItemPropertySet.SustStr = value;
        }
    }
    public bool SustWis
    {
        get
        {
            return BaseItemPropertySet.SustWis || RwItemPropertySet.SustWis;
        }
        set
        {
            RwItemPropertySet.SustWis = value;
        }
    }
    public bool Telepathy
    {
        get
        {
            return BaseItemPropertySet.Telepathy || RwItemPropertySet.Telepathy;
        }
        set
        {
            RwItemPropertySet.Telepathy = value;
        }
    }
    public bool Teleport
    {
        get
        {
            return BaseItemPropertySet.Teleport || RwItemPropertySet.Teleport;
        }
        set
        {
            RwItemPropertySet.Teleport = value;
        }
    }
    public int TreasureRating
    {
        get
        {
            return BaseItemPropertySet.TreasureRating + RwItemPropertySet.TreasureRating;
        }
        set
        {
            RwItemPropertySet.TreasureRating = value;
        }
    }
    public bool Tunnel
    {
        get
        {
            return BaseItemPropertySet.Tunnel || RwItemPropertySet.Tunnel;
        }
        set
        {
            RwItemPropertySet.Tunnel = value;
        }
    }
    public bool Valueless
    {
        get
        {
            return BaseItemPropertySet.Valueless || RwItemPropertySet.Valueless;
        }
        set
        {
            RwItemPropertySet.Tunnel = Valueless;
        }
    }
    public bool Vampiric
    {
        get
        {
            return BaseItemPropertySet.Vampiric || RwItemPropertySet.Vampiric;
        }
        set
        {
            RwItemPropertySet.Vampiric = value;
        }
    }
    public bool Vorpal
    {
        get
        {
            return BaseItemPropertySet.Vorpal || RwItemPropertySet.Vorpal;
        }
        set
        {
            RwItemPropertySet.Vorpal = value;
        }
    }
    public bool Wis
    {
        get
        {
            return BaseItemPropertySet.Wis || RwItemPropertySet.Wis;
        }
        set
        {
            RwItemPropertySet.Wis = value;
        }
    }
    public bool Wraith
    {
        get
        {
            return BaseItemPropertySet.Wraith || RwItemPropertySet.Wraith;
        }
        set
        {
            RwItemPropertySet.Wraith = value;
        }
    }
    public bool XtraMight
    {
        get
        {
            return BaseItemPropertySet.XtraMight || RwItemPropertySet.XtraMight;
        }
        set
        {
            RwItemPropertySet.XtraMight = value;
        }
    }
    public bool XtraShots
    {
        get
        {
            return BaseItemPropertySet.XtraShots || RwItemPropertySet.XtraShots;
        }
        set
        {
            RwItemPropertySet.XtraShots = value;
        }
    }
    #endregion
}
