using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RealmCharacterClassGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { RealmBindingKey, CharacterClassBindingKey }; // CONFIRMED

    [ConfigurationProperty("string",
        Title = "Character Class Binding Key",
        Summary = "Specifies the binding key for the character class.")]
    public virtual string CharacterClassBindingKey { get; set; }

    [ConfigurationProperty("string",
        Title = "Realm Binding Key",
        Summary = "Specifies the binding key for the realm.")]
    public virtual string RealmBindingKey { get; set; }

    [ConfigurationProperty("string?",
        Title = "Character Class Title",
        Summary = "Specifies the optional title displayed for the character class.")]
    public virtual string? CharacterClassTitle { get; set; } = null;

    [ConfigurationProperty("string?",
        Title = "Deity Binding Key",
        Summary = "Specifies the optional binding key for the deity.")]
    public virtual string? DeityBindingKey { get; set; } = null;
}
