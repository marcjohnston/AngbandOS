// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemAdditiveBundleWeightedRandoms;

[Serializable]
internal class LordlyResistanceItemAdditiveBundleWeightedRandom : BoundItemAdditiveBundleWeightedRandom
{
    private LordlyResistanceItemAdditiveBundleWeightedRandom(Game game) : base(game) { } // This object is a singleton
    protected override (string, int)[] ItemAdditiveBundleNames => new (string, int)[]
    {
        (nameof(ResistFearAndWarriorBiasItemAdditiveBundle), 2 * 16), // 1/3
        (nameof(ResistFearItemAdditiveBundle), 2 * 32), // 2/3

        (nameof(ResistLightItemAdditiveBundle), 1 * 48),
        (nameof(ResistDarknessItemAdditiveBundle), 1 * 48),
        (nameof(ResistBlindnessItemAdditiveBundle), 1 * 48),
        (nameof(ResistBlindnessItemAdditiveBundle), 1 * 48),

        (nameof(ResistConfusionAndChaosBiasItemAdditiveBundle), 2 * 8), // 1/6
        (nameof(ResistConfusionItemAdditiveBundle), 2 * 40), // 5/6

        (nameof(ResistSoundItemAdditiveBundle), 2 * 48),
        (nameof(ResistShardsItemAdditiveBundle), 2 * 48),

        (nameof(ResistNetherAndNecromanticBiasItemAdditiveBundle), 2 * 16), // 1/3
        (nameof(ResistNetherItemAdditiveBundle), 2 * 32), // 2/3

        (nameof(ResistNexusItemAdditiveBundle), 2 * 48),

        (nameof(ResistChaosAndChaosBiasItemAdditiveBundle), 2 * 24), // 1/2
        (nameof(ResistChaosItemAdditiveBundle), 2 * 24), // 1/2

        (nameof(ResistDisenchantItemAdditiveBundle), 2 * 48),
    };
}
