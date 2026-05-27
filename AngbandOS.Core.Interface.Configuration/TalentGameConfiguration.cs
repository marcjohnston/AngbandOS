namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class TalentGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual string Name { get; set; }
    public virtual int Level { get; set; }
    public virtual int ManaCost { get; set; }
    public virtual int BaseFailure { get; set; }

    public virtual string UseScriptBindingKey { get; set; }

    public virtual string? LearnedKnowledgeBindingKey { get; set; } = null;
}
