using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Race Gender",
    EntityNoun = "race gender")]
public class RaceGenderGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { RaceBindingKey, GenderBindingKey }; // CONFIRMED

    [ConfigurationMetadata(
        Title = "Race Binding Key",
        Summary = "Specifies the binding key for the race.",
        DataType = "string")]
    public virtual string RaceBindingKey { get; set; }

    [ConfigurationMetadata(
        Title = "Gender Binding Key",
        Summary = "Specifies the binding key for the gender.",
        DataType = "string")]
    public virtual string GenderBindingKey { get; set; }

    [ConfigurationMetadata(
        Title = "Physical Attributes Weighted Random Bindings",
        Summary = "Specifies the weighted random bindings for the race gender's physical attribute sets.",
        DataType = "(string PhysicalAttributesBindingKey, int Weight)[]")]
    public virtual (string PhysicalAttributesBindingKey, int Weight)[] PhysicalAttributesWeightedRandomBindings { get; set; }
}
