﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiasWeightedRandoms;

[Serializable]
internal class Poison1In3OrNecromantic1In6OrRogue1ArtifactBiasWeightedRandom : ArtifactBiasWeightedRandom
{
    private Poison1In3OrNecromantic1In6OrRogue1ArtifactBiasWeightedRandom(Game game) : base(game) { } // This object is a singleton
    protected override (string?, int)[] ArtifactBiasBindingKeyAndWeightTuples => new (string?, int)[]
    {
        (nameof(PoisonArtifactBias), 3),
        (nameof(NecromanticArtifactBias), 1),
        (nameof(RogueArtifactBias), 5)
    };
}