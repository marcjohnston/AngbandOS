
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class RacialPowerTestGameConfiguration
{
    public virtual string Key { get; set; }
    public virtual int MinLevel { get; set; }
    public virtual string CostExpression { get; set; }
    public virtual string UseAbilityBindingKey { get; set; }
    public virtual int Difficulty { get; set; }
}
