
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class CharacterClassAbilityGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { CharacterClassBindingKey, AbilityBindingKey }; // CONFIRMED

    [ConfigurationProperty("int",
        Title = "Bonus",
        Description = "The bonus applied to the ability for this character class.")]
    public virtual int Bonus { get; set; } = 0;

    [ConfigurationProperty("string",
        Title = "Character Class Binding Key",
        Description = "The binding key identifying the character class.")]
    public virtual string CharacterClassBindingKey { get; set; }

    [ConfigurationProperty("string",
        Title = "Ability Binding Key",
        Description = "The binding key identifying the ability.")]
    public virtual string AbilityBindingKey { get; set; }
}