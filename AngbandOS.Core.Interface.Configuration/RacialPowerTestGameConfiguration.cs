using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RacialPowerTestGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty(
        Title = "Minimum Level",
        Summary = "Specifies the minimum level required to use the racial power.",
        DataType = "int")]
    public virtual int MinLevel { get; set; }

    [ConfigurationProperty(
        Title = "Cost Expression",
        Summary = "Specifies the expression used to determine the cost of the racial power.",
        DataType = "string")]
    public virtual string CostExpression { get; set; }

    [ConfigurationProperty(
        Title = "Use Ability Binding Key",
        Summary = "Specifies the binding key of the ability used by the racial power.",
        DataType = "string")]
    public virtual string UseAbilityBindingKey { get; set; }

    [ConfigurationProperty(
        Title = "Difficulty",
        Summary = "Specifies the difficulty of the racial power test.",
        DataType = "int")]
    public virtual int Difficulty { get; set; }
}
