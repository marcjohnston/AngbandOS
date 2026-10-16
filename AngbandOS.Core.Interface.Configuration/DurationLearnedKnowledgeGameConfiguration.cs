using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntityAttribute(
    Title = "Duration Learned Knowledge",
    EntityNoun = "Duration Learned Knowledge")]
public class DurationLearnedKnowledgeGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Duration Expression Text",
        Summary = "The expression that defines the duration value learned from this knowledge.",
        DataType = "string")]
    public virtual string DurationExpressionText { get; set; }
}