using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RaceAbilityGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { RaceBindingKey, AbilityBindingKey }; // CONFIRMED

    [ConfigurationProperty(
        Title = "Bonus",
        Summary = "Specifies the bonus applied to the race ability.",
        DataType = "int")]
    public virtual int Bonus { get; set; } = 0;

    [ConfigurationProperty(
        Title = "Race Binding Key",
        Summary = "Specifies the binding key of the associated race.",
        DataType = "string")]
    public virtual string RaceBindingKey { get; set; }

    [ConfigurationProperty(
        Title = "Ability Binding Key",
        Summary = "Specifies the binding key of the associated ability.",
        DataType = "string")]
    public virtual string AbilityBindingKey { get; set; }
}

