
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class RaceAbilityGameConfiguration
{
    public virtual int Bonus { get; set; } = 0;
    public virtual string RaceBindingKey { get; set; }
    public virtual string AbilityBindingKey { get; set; }
}

