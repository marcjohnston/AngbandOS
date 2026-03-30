
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class RaceAbilityGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { RaceBindingKey, AbilityBindingKey }; // CONFIRMED

    public virtual int Bonus { get; set; } = 0;
    public virtual string RaceBindingKey { get; set; }
    public virtual string AbilityBindingKey { get; set; }
}

