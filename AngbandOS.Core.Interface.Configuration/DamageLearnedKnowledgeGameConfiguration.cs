namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class DamageLearnedKnowledgeGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual string DamageExpressionText { get; set; }
}
