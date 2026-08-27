namespace AngbandOS.GamePacks.Cthangband;

internal class PulveriseTalentLearnedKnowledge : DamageLearnedKnowledgeGameConfiguration
{
    public override string DamageExpressionText => "(8+((X-5)/4))d8";
}
