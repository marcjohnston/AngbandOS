using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Patron",
    EntityNoun = "patron")]
public class PatronGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Long Name",
        Summary = "Specifies the long name of the patron.",
        DataType = "string")]
    public virtual string LongName { get; set; }

    [ConfigurationMetadata(
        Title = "Preferred Ability Binding Key",
        Summary = "Specifies the optional binding key of the patron's preferred ability.",
        DataType = "string?")]
    public virtual string? PreferredAbilityBindingKey { get; set; }

    [ConfigurationMetadata(
        Title = "Reward Binding Keys",
        Summary = "Specifies the binding keys of the rewards granted by the patron.",
        DataType = "string[]")]
    public virtual string[] RewardBindingKeys { get; set; }

    [ConfigurationMetadata(
        Title = "Short Name",
        Summary = "Specifies the short name of the patron.",
        DataType = "string")]
    public virtual string ShortName { get; set; }
}
