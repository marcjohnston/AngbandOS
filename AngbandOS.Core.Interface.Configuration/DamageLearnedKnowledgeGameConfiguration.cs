using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class DamageLearnedKnowledgeGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Damage Expression Text",
        Summary = "The expression that defines the damage value learned from this knowledge.")]
    public virtual string DamageExpressionText { get; set; }
}