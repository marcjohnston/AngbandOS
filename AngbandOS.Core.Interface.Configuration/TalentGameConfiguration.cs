using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class TalentGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Name",
        Summary = "Specifies the name of the talent.")]
    public virtual string Name { get; set; }

    [ConfigurationProperty("int",
        Title = "Level",
        Summary = "Specifies the level required to use the talent.")]
    public virtual int Level { get; set; }

    [ConfigurationProperty("int",
        Title = "Mana Cost",
        Summary = "Specifies the mana cost of using the talent.")]
    public virtual int ManaCost { get; set; }

    [ConfigurationProperty("int",
        Title = "Base Failure",
        Summary = "Specifies the base failure chance of using the talent.")]
    public virtual int BaseFailure { get; set; }

    [ConfigurationProperty("string",
        Title = "Use Script Binding Key",
        Summary = "Specifies the binding key of the script used by the talent.")]
    public virtual string UseScriptBindingKey { get; set; }

    [ConfigurationProperty("string?",
        Title = "Learned Knowledge Binding Key",
        Summary = "Specifies the optional binding key of the knowledge learned from the talent.")]
    public virtual string? LearnedKnowledgeBindingKey { get; set; } = null;
}
