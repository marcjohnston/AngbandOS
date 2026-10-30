using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class DamageLearnedKnowledgeGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Damage Expression Text",
        Summary = "The expression that defines the damage value learned from this knowledge.",
        DataType = "string")]
    public virtual string DamageExpressionText { get; set; }
}