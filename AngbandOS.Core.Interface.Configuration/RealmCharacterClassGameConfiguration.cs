using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RealmCharacterClassGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { RealmBindingKey, CharacterClassBindingKey }; // CONFIRMED

    [ConfigurationProperty(
        Title = "Character Class Binding Key",
        Summary = "Specifies the binding key for the character class.",
        DataType = "string")]
    public virtual string CharacterClassBindingKey { get; set; }

    [ConfigurationProperty(
        Title = "Realm Binding Key",
        Summary = "Specifies the binding key for the realm.",
        DataType = "string")]
    public virtual string RealmBindingKey { get; set; }

    [ConfigurationProperty(
        Title = "Character Class Title",
        Summary = "Specifies the optional title displayed for the character class.",
        DataType = "string?")]
    public virtual string? CharacterClassTitle { get; set; } = null;

    [ConfigurationProperty(
        Title = "Deity Binding Key",
        Summary = "Specifies the optional binding key for the deity.",
        DataType = "string?")]
    public virtual string? DeityBindingKey { get; set; } = null;
}
