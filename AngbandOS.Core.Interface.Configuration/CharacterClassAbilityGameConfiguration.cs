
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class CharacterClassAbilityGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { CharacterClassBindingKey, AbilityBindingKey }; // CONFIRMED

    public virtual int Bonus { get; set; } = 0;
    public virtual string CharacterClassBindingKey { get; set; }
    public virtual string AbilityBindingKey { get; set; }
}
