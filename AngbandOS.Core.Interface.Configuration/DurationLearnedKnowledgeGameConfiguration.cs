namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class DurationLearnedKnowledgeGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual string DurationExpressionText { get; set; }
}
