namespace AngbandOS.GamePacks.Cthangband;

internal class TelekineticWaveTalentLearnedKnowledge : ExperienceLearnedKnowledgeGameConfiguration
{
    public override (int? MaxExperienceLevel, string LearnedKnowledgeBindingKey)[] ExperienceLearnedKnowledgeBindingTuples => new (int? MaxExperienceLevel, string LearnedKnowledgeBindingKey)[]
    {
        (39, nameof(TelekineticWave1TalentLearnedKnowledge)),
        (null, nameof(TelekineticWave2TalentLearnedKnowledge))
    };
}
