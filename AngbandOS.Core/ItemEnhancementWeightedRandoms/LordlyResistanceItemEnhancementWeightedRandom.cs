// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemEnhancementWeightedRandoms;

[Serializable]
internal class LordlyResistanceItemEnhancementWeightedRandom : ItemEnhancementWeightedRandom
{
    private LordlyResistanceItemEnhancementWeightedRandom(Game game) : base(game) { } // This object is a singleton
    protected override (string?, int)[] ItemEnhancementBindingKeyAndWeightTuples => new (string?, int)[]
    {
        (nameof(ResistFearAndWarriorBiasItemEnhancement), 2 * 16), // 1/3
        (nameof(ResistFearItemEnhancement), 2 * 32), // 2/3

        (nameof(ResistLightItemEnhancement), 1 * 48),
        (nameof(ResistDarknessItemEnhancement), 1 * 48),
        (nameof(ResistBlindnessItemEnhancement), 1 * 48),
        (nameof(ResistBlindnessItemEnhancement), 1 * 48),

        (nameof(ResistConfusionAndChaosBiasItemEnhancement), 2 * 8), // 1/6
        (nameof(ResistConfusionItemEnhancement), 2 * 40), // 5/6

        (nameof(ResistSoundItemEnhancement), 2 * 48),
        (nameof(ResistShardsItemEnhancement), 2 * 48),

        (nameof(ResistNetherAndNecromanticBiasItemEnhancement), 2 * 16), // 1/3
        (nameof(ResistNetherItemEnhancement), 2 * 32), // 2/3

        (nameof(ResistNexusItemEnhancement), 2 * 48),

        (nameof(ResistChaosAndChaosBiasItemEnhancement), 2 * 24), // 1/2
        (nameof(ResistChaosItemEnhancement), 2 * 24), // 1/2

        (nameof(ResistDisenchantItemEnhancement), 2 * 48),
    };
}
