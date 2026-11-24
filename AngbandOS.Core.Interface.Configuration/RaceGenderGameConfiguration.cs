using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RaceGenderGameConfiguration : CompositeSingletonGameConfiguration
{
    public sealed override string?[] CompositeKeys => new string?[] { RaceBindingKey, GenderBindingKey }; // CONFIRMED

    [ConfigurationProperty("string",
        Title = "Race Binding Key",
        Description = "Specifies the binding key for the race.")]
    public virtual string RaceBindingKey { get; set; }

    [ConfigurationProperty("string",
        Title = "Gender Binding Key",
        Description = "Specifies the binding key for the gender.")]
    [ConfigurationForeignKey("Genders", Inline = false)]
    public virtual string GenderBindingKey { get; set; }

    [ConfigurationTupleItem(
        "PhysicalAttributesBindingKey",
        Title = "Physical Attributes Binding Key",
        ForeignCollectionName = "PhysicalAttributeSets",
        Inline = false)]
    [ConfigurationTupleItem(
        "Weight",
        Title = "Weight")]
    [ConfigurationProperty("(string PhysicalAttributesBindingKey, int Weight)[]",
        Title = "Physical Attributes Weighted Random Bindings",
        Description = "Specifies the weighted random bindings for the race gender's physical attribute sets.")]
    public virtual (string PhysicalAttributesBindingKey, int Weight)[] PhysicalAttributesWeightedRandomBindings { get; set; }
}
