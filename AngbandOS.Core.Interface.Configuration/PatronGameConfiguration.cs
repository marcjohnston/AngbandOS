using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class PatronGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Long Name",
        Description = "Specifies the long name of the patron.")]
    public virtual string LongName { get; set; }

    [ConfigurationProperty("string?",
        Title = "Preferred Ability Binding Key",
        Description = "Specifies the optional binding key of the patron's preferred ability.")]
    public virtual string? PreferredAbilityBindingKey { get; set; }

    [ConfigurationProperty("string[]",
        Title = "Reward Binding Keys",
        Description = "Specifies the binding keys of the rewards granted by the patron.")]
    public virtual string[] RewardBindingKeys { get; set; }

    [ConfigurationProperty("string",
        Title = "Short Name",
        Description = "Specifies the short name of the patron.")]
    public virtual string ShortName { get; set; }
}
