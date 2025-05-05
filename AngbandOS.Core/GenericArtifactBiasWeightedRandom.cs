// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

/// <summary>
/// Represents a singleton for a weighted random of <see cref="ItemEnhancement"/> objects.
/// </summary>
[Serializable]
internal class GenericArtifactBiasWeightedRandom : ArtifactBiasWeightedRandom
{
    public GenericArtifactBiasWeightedRandom(Game game, ArtifactBiasWeightedRandomGameConfiguration artifactBiasWeightedRandomGameConfiguration) : base(game)
    {
        Key = artifactBiasWeightedRandomGameConfiguration.Key ?? artifactBiasWeightedRandomGameConfiguration.GetType().Name;
        ArtifactBiasBindingKeyAndWeightTuples = artifactBiasWeightedRandomGameConfiguration.ArtifactBiasBindingKeyAndWeightTuples;
    }

    public override string Key { get; }

    protected override (string?, int)[] ArtifactBiasBindingKeyAndWeightTuples { get; }
}

