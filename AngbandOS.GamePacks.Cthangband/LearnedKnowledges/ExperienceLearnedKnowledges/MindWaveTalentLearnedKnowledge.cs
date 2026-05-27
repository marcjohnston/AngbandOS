namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MindWaveTalentLearnedKnowledge : ExperienceLearnedKnowledgeGameConfiguration
{
    public override (int?, string)[] ExperienceLearnedKnowledgeBindingTuples => new (int?, string)[]
    {
        (24, nameof(MindWaveTalentX1LearnedKnowledge)),
        (null, nameof(MindWaveTalentX2LearnedKnowledge))
    };
}
