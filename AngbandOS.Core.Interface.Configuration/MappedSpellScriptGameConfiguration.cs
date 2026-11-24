using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class MappedSpellScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string?",
        Title = "Realm Binding Key",
        Description = "Returns the binding key of the realm associated with this mapped spell script.")]
    public virtual string? RealmBindingKey { get; set; }

    [ConfigurationProperty("string?",
        Title = "Character Class Binding Key",
        Description = "Returns the binding key of the character class associated with this mapped spell script.")]
    public virtual string? CharacterClassBindingKey { get; set; }

    [ConfigurationProperty("string?",
        Title = "Spell Binding Key",
        Description = "Returns the binding key of the spell associated with this mapped spell script.")]
    public virtual string? SpellBindingKey { get; set; }

    [ConfigurationProperty("bool",
        Title = "Success",
        Description = "Indicates whether the mapped spell script represents a successful spell cast.")]
    public virtual bool Success { get; set; } = true;

    [ConfigurationProperty("string[]?",
        Title = "Cast Spell Script Binding Keys",
        Description = "Returns the binding keys of the cast spell scripts to run when the spell is cast, or null if the spell does nothing when cast.")]
    public virtual string[]? CastSpellScriptBindingKeys { get; set; }

    [ConfigurationProperty("int?",
        Title = "Minimum Experience Level",
        Description = "Returns the minimum experience level required for this mapped spell script, or null if there is no minimum.")]
    public virtual int? MinimumExperienceLevel { get; set; } = null;

    [ConfigurationProperty("int?",
        Title = "Maximum Experience Level",
        Description = "Returns the maximum experience level allowed for this mapped spell script, or null if there is no maximum.")]
    public virtual int? MaximumExperienceLevel { get; set; } = null;
}
