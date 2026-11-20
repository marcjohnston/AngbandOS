using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RacialPowerTestGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("int",
        Title = "Minimum Level",
        Summary = "Specifies the minimum level required to use the racial power.")]
    public virtual int MinLevel { get; set; }

    [ConfigurationProperty("string",
        Title = "Cost Expression",
        Summary = "Specifies the expression used to determine the cost of the racial power.")]
    public virtual string CostExpression { get; set; }

    [ConfigurationProperty("string",
        Title = "Use Ability Binding Key",
        Summary = "Specifies the binding key of the ability used by the racial power.")]
    public virtual string UseAbilityBindingKey { get; set; }

    [ConfigurationProperty("int",
        Title = "Difficulty",
        Summary = "Specifies the difficulty of the racial power test.")]
    public virtual int Difficulty { get; set; }
}
