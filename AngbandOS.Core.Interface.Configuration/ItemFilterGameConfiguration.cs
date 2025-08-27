namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ItemFilterGameConfiguration
{
    public virtual string Key { get; set; }
    public virtual bool? CanBeActivated { get; set; } = null;
    public virtual bool? CanBeAimed { get; set; } = null;
    public virtual bool? CanBeEaten { get; set; } = null;
    public virtual bool? CanBeFired { get; set; } = null;
    public virtual bool? CanBeQuaffed { get; set; } = null;
    public virtual bool? CanBeRead { get; set; } = null;
    public virtual bool? CanBeRecharged { get; set; } = null;
    public virtual bool? CanBeUsed { get; set; } = null;
    public virtual bool? CanBeUsedToDig { get; set; } = null;
    public virtual bool? CanBeZapped { get; set; } = null;
    public virtual bool? CanProjectArrows { get; set; } = null;
    public virtual bool? IsArmor { get; set; } = null;
    public virtual bool? IsBlessed { get; set; } = null;
    public virtual bool? IsFuelForTorch { get; set; } = null;
    public virtual bool? IsKnown { get; set; } = null;
    public virtual bool? IsLanternFuel { get; set; } = null;
    public virtual bool? IsOfValue { get; set; } = null;
    public virtual bool? IsTooHeavyToWield { get; set; } = null;
    public virtual bool? IsUsableSpellBook { get; set; } = null;
    public virtual bool? IsWeapon { get; set; } = null;
    public virtual bool? IsWearableOrWieldable { get; set; } = null;
    public virtual string[]? AnyMatchingItemClassNames { get; set; } = null;
    public virtual string[]? AllNonMatchingItemClassNames { get; set; } = null;
    public virtual string[]? AnyMatchingItemFactoryNames { get; set; } = null;
    public virtual string[]? AllNonMatchingItemFactoryNames { get; set; } = null;
    public virtual bool? CanApplyBlessedArtifactBias { get; set; } = null;
    public virtual bool? ArtifactBiasSlayingDisabled { get; set; } = null;

    public virtual bool? Aggravate { get; set; } = null;

    public virtual bool? AntiTheft { get; set; } = null;

    public virtual bool? ArtifactBias { get; set; } = null;

    public virtual bool? Blessed { get; set; } = null;

    public virtual bool? BrandAcid { get; set; } = null;

    public virtual bool? BrandCold { get; set; } = null;

    public virtual bool? BrandElec { get; set; } = null;

    public virtual bool? BrandFire { get; set; } = null;

    public virtual bool? BrandPois { get; set; } = null;

    public virtual bool? Chaotic { get; set; } = null;

    public virtual bool? IsCursed { get; set; } = null;

    public virtual bool? DrainExp { get; set; } = null;

    public virtual bool? DreadCurse { get; set; } = null;

    public virtual bool? EasyKnow { get; set; } = null;

    public virtual bool? Feather { get; set; } = null;

    public virtual bool? FreeAct { get; set; } = null;

    public virtual bool? HeavyCurse { get; set; } = null;

    public virtual bool? HideType { get; set; } = null;

    public virtual bool? HoldLife { get; set; } = null;

    public virtual bool? IgnoreAcid { get; set; } = null;

    public virtual bool? IgnoreCold { get; set; } = null;

    public virtual bool? IgnoreElec { get; set; } = null;

    public virtual bool? IgnoreFire { get; set; } = null;

    public virtual bool? ImAcid { get; set; } = null;

    public virtual bool? ImCold { get; set; } = null;

    public virtual bool? ImElec { get; set; } = null;

    public virtual bool? ImFire { get; set; } = null;

    public virtual bool? Impact { get; set; } = null;

    public virtual bool? NoMagic { get; set; } = null;

    public virtual bool? NoTele { get; set; } = null;

    public virtual bool? PermaCurse { get; set; } = null;

    public virtual bool? Radius { get; set; } = null;

    public virtual bool? Reflect { get; set; } = null;

    public virtual bool? Regen { get; set; } = null;

    public virtual bool? ResAcid { get; set; } = null;

    public virtual bool? ResBlind { get; set; } = null;

    public virtual bool? ResChaos { get; set; } = null;

    public virtual bool? ResCold { get; set; } = null;

    public virtual bool? ResConf { get; set; } = null;

    public virtual bool? ResDark { get; set; } = null;

    public virtual bool? ResDisen { get; set; } = null;

    public virtual bool? ResElec { get; set; } = null;

    public virtual bool? ResFear { get; set; } = null;

    public virtual bool? ResFire { get; set; } = null;

    public virtual bool? ResLight { get; set; } = null;

    public virtual bool? ResNether { get; set; } = null;

    public virtual bool? ResNexus { get; set; } = null;

    public virtual bool? ResPois { get; set; } = null;

    public virtual bool? ResShards { get; set; } = null;

    public virtual bool? ResSound { get; set; } = null;

    public virtual bool? SeeInvis { get; set; } = null;

    public virtual bool? FactoryAllowsShElecricity { get; set; } = null;

    public virtual bool? ShElec { get; set; } = null;

    public virtual bool? FactoryAllowsShFire { get; set; } = null;

    public virtual bool? ShFire { get; set; } = null;

    public virtual bool? ShowMods { get; set; } = null;

    public virtual bool? SlayAnimal { get; set; } = null;

    public virtual bool? SlayDemon { get; set; } = null;

    public virtual bool? SlayDragon { get; set; } = null;

    public virtual bool? SlayEvil { get; set; } = null;

    public virtual bool? SlayGiant { get; set; } = null;

    public virtual bool? SlayOrc { get; set; } = null;

    public virtual bool? SlayTroll { get; set; } = null;

    public virtual bool? SlayUndead { get; set; } = null;

    public virtual bool? SlowDigest { get; set; } = null;

    public virtual bool? SustCha { get; set; } = null;

    public virtual bool? SustCon { get; set; } = null;

    public virtual bool? SustDex { get; set; } = null;

    public virtual bool? SustInt { get; set; } = null;

    public virtual bool? SustStr { get; set; } = null;

    public virtual bool? SustWis { get; set; } = null;

    public virtual bool? Telepathy { get; set; } = null;

    public virtual bool? Teleport { get; set; } = null;

    public virtual bool? TreasureRating { get; set; } = null;

    public virtual bool? Vampiric { get; set; } = null;

    public virtual bool? Vorpal { get; set; } = null;

    public virtual bool? Wraith { get; set; } = null;

    public virtual bool? XtraMight { get; set; } = null;

    public virtual bool? XtraShots { get; set; } = null;
}
