using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Realm Character Class",
    EntityNoun = "realm character class")]
public class RealmCharacterClassGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { RealmBindingKey, CharacterClassBindingKey }; // CONFIRMED

    public virtual string CharacterClassBindingKey { get; set; }
    public virtual string RealmBindingKey { get; set; }
    public virtual string? CharacterClassTitle { get; set; } = null;
    public virtual string? DeityBindingKey { get; set; } = null;
}
