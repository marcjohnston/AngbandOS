using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Race Gender",
    EntityNoun = "race gender")]
public class RaceGenderGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { RaceBindingKey, GenderBindingKey }; // CONFIRMED

    public virtual string RaceBindingKey { get; set; }
    public virtual string GenderBindingKey { get; set; }
    public virtual (string PhysicalAttributesBindingKey, int Weight)[] PhysicalAttributesWeightedRandomBindings { get; set; }
}
