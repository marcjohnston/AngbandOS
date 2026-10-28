using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Summation Attribute",
    EntityNoun = "summation attribute")]
public class SummationAttributeGameConfiguration : NonCompositeSingletonGameConfiguration
{
}
