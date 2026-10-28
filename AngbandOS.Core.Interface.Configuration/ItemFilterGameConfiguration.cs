using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(Title = "Item Filter", EntityNoun = "item filter")]
public class ItemFilterGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Attribute Filter Binding Key",
        Summary = "Specifies the binding key for the attribute filter to apply.",
        DataType = "string?")]
    public virtual string? AttributeFilterBindingKey { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Any Matching Item Class Names",
        Summary = "Specifies item class names where an item matches if it belongs to any of the specified classes.",
        DataType = "string[]?")]
    public virtual string[]? AnyMatchingItemClassNames { get; set; } = null;

    [ConfigurationMetadata(
        Title = "All Non-Matching Item Class Names",
        Summary = "Specifies item class names that an item must not belong to for the filter to match.",
        DataType = "string[]?")]
    public virtual string[]? AllNonMatchingItemClassNames { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Any Matching Item Factory Names",
        Summary = "Specifies item factory names where an item matches if it was created by any of the specified factories.",
        DataType = "string[]?")]
    public virtual string[]? AnyMatchingItemFactoryNames { get; set; } = null;

    [ConfigurationMetadata(
        Title = "All Non-Matching Item Factory Names",
        Summary = "Specifies item factory names that an item must not have been created by for the filter to match.",
        DataType = "string[]?")]
    public virtual string[]? AllNonMatchingItemFactoryNames { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Can Be Activated",
        Summary = "Specifies whether the item must be capable of being activated.",
        DataType = "bool?")]
    public virtual bool? CanBeActivated { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Can Be Aimed",
        Summary = "Specifies whether the item must be capable of being aimed.",
        DataType = "bool?")]
    public virtual bool? CanBeAimed { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Can Be Fired",
        Summary = "Specifies whether the item must be capable of being fired.",
        DataType = "bool?")]
    public virtual bool? CanBeFired { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Can Be Quaffed",
        Summary = "Specifies whether the item must be capable of being quaffed.",
        DataType = "bool?")]
    public virtual bool? CanBeQuaffed { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Can Be Read",
        Summary = "Specifies whether the item must be capable of being read.",
        DataType = "bool?")]
    public virtual bool? CanBeRead { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Can Be Recharged",
        Summary = "Specifies whether the item must be capable of being recharged.",
        DataType = "bool?")]
    public virtual bool? CanBeRecharged { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Can Be Used",
        Summary = "Specifies whether the item must be capable of being used.",
        DataType = "bool?")]
    public virtual bool? CanBeUsed { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Can Be Zapped",
        Summary = "Specifies whether the item must be capable of being zapped.",
        DataType = "bool?")]
    public virtual bool? CanBeZapped { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Can Project Arrows",
        Summary = "Specifies whether the item must be capable of projecting arrows.",
        DataType = "bool?")]
    public virtual bool? CanProjectArrows { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Is Known",
        Summary = "Specifies whether the item must be known.",
        DataType = "bool?")]
    public virtual bool? IsKnown { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Is Of Value",
        Summary = "Specifies whether the item must be considered valuable.",
        DataType = "bool?")]
    public virtual bool? IsOfValue { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Is Too Heavy To Wield",
        Summary = "Specifies whether the item must be too heavy for the player to wield.",
        DataType = "bool?")]
    public virtual bool? IsTooHeavyToWield { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Is Usable Spell Book",
        Summary = "Specifies whether the item must be a usable spell book.",
        DataType = "bool?")]
    public virtual bool? IsUsableSpellBook { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Artifact Bias Can Slay",
        Summary = "Specifies whether the item's artifact bias must be capable of slaying a target.",
        DataType = "bool?")]
    public virtual bool? ArtifactBiasCanSlay { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Artifact Bias",
        Summary = "Specifies whether the item must have an artifact bias.",
        DataType = "bool?")]
    public virtual bool? ArtifactBias { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Is Cursed",
        Summary = "Specifies whether the item must be cursed.",
        DataType = "bool?")]
    public virtual bool? IsCursed { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Heavy Curse",
        Summary = "Specifies whether the item must have a heavy curse.",
        DataType = "bool?")]
    public virtual bool? HeavyCurse { get; set; } = null;
}