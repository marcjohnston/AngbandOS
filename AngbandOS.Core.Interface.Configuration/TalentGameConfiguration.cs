using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Talent",
    EntityNoun = "talent")]
public class TalentGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Name",
        Summary = "Specifies the name of the talent.",
        DataType = "string")]
    public virtual string Name { get; set; }

    [ConfigurationMetadata(
        Title = "Level",
        Summary = "Specifies the level required to use the talent.",
        DataType = "int")]
    public virtual int Level { get; set; }

    [ConfigurationMetadata(
        Title = "Mana Cost",
        Summary = "Specifies the mana cost of using the talent.",
        DataType = "int")]
    public virtual int ManaCost { get; set; }

    [ConfigurationMetadata(
        Title = "Base Failure",
        Summary = "Specifies the base failure chance of using the talent.",
        DataType = "int")]
    public virtual int BaseFailure { get; set; }

    [ConfigurationMetadata(
        Title = "Use Script Binding Key",
        Summary = "Specifies the binding key of the script used by the talent.",
        DataType = "string")]
    public virtual string UseScriptBindingKey { get; set; }

    [ConfigurationMetadata(
        Title = "Learned Knowledge Binding Key",
        Summary = "Specifies the optional binding key of the knowledge learned from the talent.",
        DataType = "string?")]
    public virtual string? LearnedKnowledgeBindingKey { get; set; } = null;
}
