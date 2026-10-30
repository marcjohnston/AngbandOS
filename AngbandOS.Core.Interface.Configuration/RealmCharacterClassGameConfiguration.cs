using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RealmCharacterClassGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { RealmBindingKey, CharacterClassBindingKey }; // CONFIRMED

    [ConfigurationMetadata(
        Title = "Character Class Binding Key",
        Summary = "Specifies the binding key for the character class.",
        DataType = "string")]
    public virtual string CharacterClassBindingKey { get; set; }

    [ConfigurationMetadata(
        Title = "Realm Binding Key",
        Summary = "Specifies the binding key for the realm.",
        DataType = "string")]
    public virtual string RealmBindingKey { get; set; }

    [ConfigurationMetadata(
        Title = "Character Class Title",
        Summary = "Specifies the optional title displayed for the character class.",
        DataType = "string?")]
    public virtual string? CharacterClassTitle { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Deity Binding Key",
        Summary = "Specifies the optional binding key for the deity.",
        DataType = "string?")]
    public virtual string? DeityBindingKey { get; set; } = null;
}
