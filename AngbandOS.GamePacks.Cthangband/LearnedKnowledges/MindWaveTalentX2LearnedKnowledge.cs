namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MindWaveTalentX2LearnedKnowledge : DamageLearnedKnowledgeGameConfiguration
{
    public override string DamageExpressionText => "X*(((X-5)/10)+1)";
}
