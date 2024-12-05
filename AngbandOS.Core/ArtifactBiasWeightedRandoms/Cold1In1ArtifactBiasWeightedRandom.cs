// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiasWeightedRandoms;

[Serializable]
internal class Cold1In1ArtifactBiasWeightedRandom : ArtifactBiasWeightedRandom
{
    private Cold1In1ArtifactBiasWeightedRandom(Game game) : base(game) { } // This object is a singleton
    protected override (string?, int)[] ArtifactBiasBindingKeyAndWeightTuples => new (string?, int)[]
    {
        (nameof(ColdArtifactBias), 1)
    };
}
