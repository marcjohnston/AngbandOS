namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class RangeLearnedKnowledgeGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual string RangeExpressionText { get; set; }
}
