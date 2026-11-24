using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class DurationLearnedKnowledgeGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Duration Expression Text",
        Description = "The expression that defines the duration value learned from this knowledge.")]
    public virtual string DurationExpressionText { get; set; }
}