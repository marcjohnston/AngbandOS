namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// Represents a singleton for a weighted random of <see cref="ItemEnhancement"/> objects.
/// </summary>
[Serializable]
public class ArtifactBiasWeightedRandomGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual (string?, int)[] ArtifactBiasBindingKeyAndWeightTuples { get; set; }
}
