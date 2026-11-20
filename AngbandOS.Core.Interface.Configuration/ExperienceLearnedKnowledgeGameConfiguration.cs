using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ExperienceLearnedKnowledgeGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty(
        Title = "Experience Learned Knowledge Binding Tuples",
        Summary = "The experience levels and learned knowledge binding keys used to determine which knowledge is learned.",
        DataType = "(int? MaxExperienceLevel, string LearnedKnowledgeBindingKey)[]")]
    [ConfigurationTupleItem(
        "MaxExperienceLevel",
        Title = "Max Experience Level")]
    [ConfigurationTupleItem(
        "LearnedKnowledgeBindingKey",
        Title = "Learned Knowledge Binding Key")]
    public virtual (int? MaxExperienceLevel, string LearnedKnowledgeBindingKey)[] ExperienceLearnedKnowledgeBindingTuples { get; set; }
}