namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class AdrenalineChannelingTalentLearnedKnowledge : DurationLearnedKnowledgeGameConfiguration
{
    public override string DurationExpressionText => "10+1d(X*3/2)";
}