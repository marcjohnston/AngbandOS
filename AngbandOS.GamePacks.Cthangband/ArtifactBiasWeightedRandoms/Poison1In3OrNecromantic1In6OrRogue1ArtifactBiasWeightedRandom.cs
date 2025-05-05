// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Poison1In3OrNecromantic1In6OrRogue1ArtifactBiasWeightedRandom : ArtifactBiasWeightedRandomGameConfiguration
{
    public override (string?, int)[] ArtifactBiasBindingKeyAndWeightTuples => new (string?, int)[]
    {
        (nameof(ArtifactBiasesEnum.PoisonArtifactBias), 3),
        (nameof(ArtifactBiasesEnum.NecromanticArtifactBias), 1),
        (nameof(ArtifactBiasesEnum.RogueArtifactBias), 5)
    };
}
