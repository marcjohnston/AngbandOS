
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class PatronGameConfiguration
{
    public virtual string Key { get; set; }
    public virtual string LongName { get; set; }
    public virtual string? PreferredAbilityBindingKey { get; set; }
    public virtual string[] RewardBindingKeys { get; set; }
    public virtual string ShortName { get; set; }
}
