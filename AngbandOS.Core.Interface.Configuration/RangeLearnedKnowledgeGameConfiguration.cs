using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RangeLearnedKnowledgeGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Range Expression Text",
        Description = "The expression that defines the range value learned from this knowledge.")]
    public virtual string RangeExpressionText { get; set; }
}
