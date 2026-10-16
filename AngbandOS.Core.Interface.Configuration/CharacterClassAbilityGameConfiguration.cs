
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntityAttribute(
    Title = "Character Class Ability",
    EntityNoun = "Character Class Ability")]
public class CharacterClassAbilityGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { CharacterClassBindingKey, AbilityBindingKey }; // CONFIRMED

    [ConfigurationMetadataAttribute(
        Title = "Bonus",
        Summary = "The bonus applied to the ability for this character class.",
        DataType = "int")]
    public virtual int Bonus { get; set; } = 0;

    [ConfigurationMetadataAttribute(
        Title = "Character Class Binding Key",
        Summary = "The binding key identifying the character class.",
        DataType = "string")]
    public virtual string CharacterClassBindingKey { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Ability Binding Key",
        Summary = "The binding key identifying the ability.",
        DataType = "string")]
    public virtual string AbilityBindingKey { get; set; }
}