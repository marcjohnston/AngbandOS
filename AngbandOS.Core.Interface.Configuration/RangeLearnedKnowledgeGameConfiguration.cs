using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RangeLearnedKnowledgeGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Range Expression Text",
        Summary = "The expression that defines the range value learned from this knowledge.",
        DataType = "string")]
    public virtual string RangeExpressionText { get; set; }
}
