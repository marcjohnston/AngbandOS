namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class MappedSpellScriptGameConfiguration
{
    public virtual string? Key { get; set; } = null;
    public virtual string? RealmBindingKey { get; set; }
    public virtual string? CharacterClassBindingKey { get; set; }
    public virtual string? SpellBindingKey { get; set; }
    public virtual bool Success { get; set; } = true;

    /// <summary>
    /// Returns the name of an <see cref="ICastSpellScript"/> script to be run, when the spell is cast; or null, if the spell does nothing when cast.  This
    /// property is used to bind the <see cref="CastSpellScripts"/> property during the bind phase.
    /// </summary>
    public virtual string[]? CastSpellScriptBindingKeys { get; set; }
    public virtual int? MinimumExperienceLevel { get; set; } = null;
}
