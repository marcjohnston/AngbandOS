namespace AngbandOS.GamePacks.Cthangband;

internal class MinorDisplacementTalentLearnedKnowledge : ExperienceLearnedKnowledgeGameConfiguration
{
    public override (int? MaxExperienceLevel, string LearnedKnowledgeBindingKey)[] ExperienceLearnedKnowledgeBindingTuples => new (int? MaxExperienceLevel, string LearnedKnowledgeBindingKey)[]
    {
        (15, "MinorDisplacementX1TalentLearnedKnowledge"),
        (null, "MinorDisplacementX2TalentLearnedKnowledge")
    };
}
