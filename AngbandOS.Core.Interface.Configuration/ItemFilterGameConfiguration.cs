namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ItemFilterGameConfiguration
{
    public virtual string Key { get; set; }
    
    public virtual (string AttributeName, bool DesiredValue)[]? OrAttributeMatchingBindings { get; set; } = null;

    public virtual string[]? AnyMatchingItemClassNames { get; set; } = null;
    public virtual string[]? AllNonMatchingItemClassNames { get; set; } = null;
    public virtual string[]? AnyMatchingItemFactoryNames { get; set; } = null;
    public virtual string[]? AllNonMatchingItemFactoryNames { get; set; } = null;
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
    public virtual bool? IsFuelForTorch { get; set; } = null;
    public virtual bool? IsKnown { get; set; } = null;
    public virtual bool? IsLanternFuel { get; set; } = null;
    public virtual bool? IsOfValue { get; set; } = null;
    public virtual bool? IsTooHeavyToWield { get; set; } = null;
    public virtual bool? IsUsableSpellBook { get; set; } = null;
    public virtual bool? IsWeapon { get; set; } = null;
    public virtual bool? IsWearableOrWieldable { get; set; } = null;
    public virtual bool? CanApplyBlessedArtifactBias { get; set; } = null;
    public virtual bool? ArtifactBiasCanSlay { get; set; } = null;

    public virtual bool? ArtifactBias { get; set; } = null;

    public virtual bool? IsCursed { get; set; } = null;
    public virtual bool? HeavyCurse { get; set; } = null;
}
