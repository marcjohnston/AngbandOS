using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ItemFilterGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string?",
        Title = "Attribute Filter Binding Key",
        Description = "Specifies the binding key for the attribute filter to apply.")]
    public virtual string? AttributeFilterBindingKey { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "Any Matching Item Class Names",
        Description = "Specifies item class names where an item matches if it belongs to any of the specified classes.")]
    public virtual string[]? AnyMatchingItemClassNames { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "All Non-Matching Item Class Names",
        Description = "Specifies item class names that an item must not belong to for the filter to match.")]
    public virtual string[]? AllNonMatchingItemClassNames { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "Any Matching Item Factory Names",
        Description = "Specifies item factory names where an item matches if it was created by any of the specified factories.")]
    public virtual string[]? AnyMatchingItemFactoryNames { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "All Non-Matching Item Factory Names",
        Description = "Specifies item factory names that an item must not have been created by for the filter to match.")]
    public virtual string[]? AllNonMatchingItemFactoryNames { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Can Be Activated",
        Description = "Specifies whether the item must be capable of being activated.")]
    public virtual bool? CanBeActivated { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Can Be Aimed",
        Description = "Specifies whether the item must be capable of being aimed.")]
    public virtual bool? CanBeAimed { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Can Be Fired",
        Description = "Specifies whether the item must be capable of being fired.")]
    public virtual bool? CanBeFired { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Can Be Quaffed",
        Description = "Specifies whether the item must be capable of being quaffed.")]
    public virtual bool? CanBeQuaffed { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Can Be Read",
        Description = "Specifies whether the item must be capable of being read.")]
    public virtual bool? CanBeRead { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Can Be Recharged",
        Description = "Specifies whether the item must be capable of being recharged.")]
    public virtual bool? CanBeRecharged { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Can Be Used",
        Description = "Specifies whether the item must be capable of being used.")]
    public virtual bool? CanBeUsed { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Can Be Zapped",
        Description = "Specifies whether the item must be capable of being zapped.")]
    public virtual bool? CanBeZapped { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Can Project Arrows",
        Description = "Specifies whether the item must be capable of projecting arrows.")]
    public virtual bool? CanProjectArrows { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Is Known",
        Description = "Specifies whether the item must be known.")]
    public virtual bool? IsKnown { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Is Of Value",
        Description = "Specifies whether the item must be considered valuable.")]
    public virtual bool? IsOfValue { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Is Too Heavy To Wield",
        Description = "Specifies whether the item must be too heavy for the player to wield.")]
    public virtual bool? IsTooHeavyToWield { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Is Usable Spell Book",
        Description = "Specifies whether the item must be a usable spell book.")]
    public virtual bool? IsUsableSpellBook { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Artifact Bias Can Slay",
        Description = "Specifies whether the item's artifact bias must be capable of slaying a target.")]
    public virtual bool? ArtifactBiasCanSlay { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Artifact Bias",
        Description = "Specifies whether the item must have an artifact bias.")]
    public virtual bool? ArtifactBias { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Is Cursed",
        Description = "Specifies whether the item must be cursed.")]
    public virtual bool? IsCursed { get; set; } = null;

    [ConfigurationProperty("bool?",
        Title = "Heavy Curse",
        Description = "Specifies whether the item must have a heavy curse.")]
    public virtual bool? HeavyCurse { get; set; } = null;
}