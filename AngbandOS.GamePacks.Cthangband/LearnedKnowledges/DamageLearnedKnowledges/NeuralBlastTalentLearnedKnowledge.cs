namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class NeuralBlastTalentLearnedKnowledge : DamageLearnedKnowledgeGameConfiguration
{
    public override string DamageExpressionText => "(3+((X-1)/4))d(3+(X/15))";
}
