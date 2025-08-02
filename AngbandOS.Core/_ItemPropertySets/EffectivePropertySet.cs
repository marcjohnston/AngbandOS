// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class EffectivePropertySet
{
    //public EffectivePropertySet AsReadOnly() => this;
    public EffectivePropertySet Merge(EffectivePropertySet effectivePropertySet2) { throw new Exception("Not implemented"); }
    public EffectivePropertySet Clone() { throw new Exception("Not implemented"); }
    public void Add(EffectivePropertySet effectivePropertySet) { }

    #region Properties
    public bool CanApplyBlessedArtifactBias
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool CanApplyArtifactBiasSlaying
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool CanApplyBlowsBonus
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool CanReflectBoltsAndArrows
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool CanApplySlayingBonus
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool CanApplyBonusArmorClassMiscPower
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool CanProvideSheathOfElectricity
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool CanProvideSheathOfFire
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int BonusHit
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int BonusArmorClass
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int BonusDamage
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int BonusStrength
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int BonusIntelligence
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int BonusWisdom
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int BonusDexterity
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int BonusConstitution
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int BonusCharisma
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int BonusStealth
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int BonusSearch
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int BonusInfravision
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int BonusTunnel
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int BonusAttacks
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int BonusSpeed
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public Activation? Activation
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Aggravate
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool AntiTheft
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public ArtifactBias? ArtifactBias
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Blessed
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Blows
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool BrandAcid
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool BrandCold
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool BrandElec
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool BrandFire
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool BrandPois
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Cha
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Chaotic
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Con
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool IsCursed
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Dex
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool DrainExp
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool DreadCurse
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool EasyKnow
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Feather
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool FreeAct
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool HeavyCurse
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool HideType
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool HoldLife
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool IgnoreAcid
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool IgnoreCold
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool IgnoreElec
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool IgnoreFire
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ImAcid
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ImCold
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ImElec
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ImFire
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Impact
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Infra
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool InstaArt
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Int
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool KillDragon
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool NoMagic
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool NoTele
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool PermaCurse
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int Radius
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Reflect
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Regen
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ResAcid
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ResBlind
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ResChaos
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ResCold
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ResConf
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ResDark
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ResDisen
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ResElec
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ResFear
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ResFire
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ResLight
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ResNether
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ResNexus
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ResPois
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ResShards
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ResSound
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Search
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool SeeInvis
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ShElec
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ShFire
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool ShowMods
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool SlayAnimal
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool SlayDemon
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool SlayDragon
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool SlayEvil
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool SlayGiant
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool SlayOrc
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool SlayTroll
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool SlayUndead
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool SlowDigest
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Speed
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Stealth
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Str
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool SustCha
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool SustCon
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool SustDex
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool SustInt
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool SustStr
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool SustWis
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Telepathy
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Teleport
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int TreasureRating
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Tunnel
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public int Value
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Valueless
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Vampiric
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Vorpal
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Wis
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Wraith
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool XtraMight
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool XtraShots
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    #endregion
}