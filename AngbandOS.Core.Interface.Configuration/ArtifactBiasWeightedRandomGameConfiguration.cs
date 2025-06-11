namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// Represents a singleton for a weighted random of <see cref="ItemEnhancement"/> objects.
/// </summary>
[Serializable]
public class ArtifactBiasWeightedRandomGameConfiguration
{
    public virtual string? Key { get; set; } = null;

    public virtual (string?, int)[] ArtifactBiasBindingKeyAndWeightTuples { get; set; }
}
