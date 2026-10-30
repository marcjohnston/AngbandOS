using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class MappedSpellScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Realm Binding Key",
        Summary = "Returns the binding key of the realm associated with this mapped spell script.",
        DataType = "string?")]
    public virtual string? RealmBindingKey { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Character Class Binding Key",
        Summary = "Returns the binding key of the character class associated with this mapped spell script.",
        DataType = "string?")]
    public virtual string? CharacterClassBindingKey { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Spell Binding Key",
        Summary = "Returns the binding key of the spell associated with this mapped spell script.",
        DataType = "string?")]
    public virtual string? SpellBindingKey { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Success",
        Summary = "Indicates whether the mapped spell script represents a successful spell cast.",
        DataType = "bool")]
    public virtual bool Success { get; set; } = true;

    [ConfigurationMetadataAttribute(
        Title = "Cast Spell Script Binding Keys",
        Summary = "Returns the binding keys of the cast spell scripts to run when the spell is cast, or null if the spell does nothing when cast.",
        DataType = "string[]?")]
    public virtual string[]? CastSpellScriptBindingKeys { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Minimum Experience Level",
        Summary = "Returns the minimum experience level required for this mapped spell script, or null if there is no minimum.",
        DataType = "int?")]
    public virtual int? MinimumExperienceLevel { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Maximum Experience Level",
        Summary = "Returns the maximum experience level allowed for this mapped spell script, or null if there is no maximum.",
        DataType = "int?")]
    public virtual int? MaximumExperienceLevel { get; set; } = null;
}
