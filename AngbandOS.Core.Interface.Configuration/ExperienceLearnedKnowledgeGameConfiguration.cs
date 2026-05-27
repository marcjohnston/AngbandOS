namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ExperienceLearnedKnowledgeGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual (int? MaxExperienceLevel, string LearnedKnowledgeBindingKey)[] ExperienceLearnedKnowledgeBindingTuples { get; set; }
}