using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RaceAbilityGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { RaceBindingKey, AbilityBindingKey }; // CONFIRMED

    [ConfigurationProperty("int",
        Title = "Bonus",
        Summary = "Specifies the bonus applied to the race ability.")]
    public virtual int Bonus { get; set; } = 0;

    [ConfigurationProperty("string",
        Title = "Race Binding Key",
        Summary = "Specifies the binding key of the associated race.")]
    public virtual string RaceBindingKey { get; set; }

    [ConfigurationProperty("string",
        Title = "Ability Binding Key",
        Summary = "Specifies the binding key of the associated ability.")]
    public virtual string AbilityBindingKey { get; set; }
}

