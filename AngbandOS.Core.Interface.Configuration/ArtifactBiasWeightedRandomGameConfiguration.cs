using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// Represents a singleton for a weighted random of <see cref="ItemEnhancement"/> objects.
/// </summary>
public class ArtifactBiasWeightedRandomGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Artifact Bias",
        Summary = "The artifact bias binding keys and their associated weights used to select a weighted random artifact bias.",
        DataType = "(string?, int)[]")]
    [ConfigurationTupleItemAttribute("ArtifactBiasBindingKey",
        Title = "Artifact Bias Binding Key")]
    [ConfigurationTupleItemAttribute("Weight",
        Title = "Weight")]
    public virtual (string?, int)[] ArtifactBiasBindingKeyAndWeightTuples { get; set; }
}