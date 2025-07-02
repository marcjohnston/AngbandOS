// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FixedArtifactRandomPowerItemEnhancementWeightedRandom : ItemEnhancementWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[]
    {
        (nameof(FeatherFallItemItemEnhancement), 20 * 1),
        (nameof(FreeActionItemEnhancement), 20 * 1),
        (nameof(HoldLifeItemEnhancement), 20 * 1),
        (nameof(LightsourceRadius3ItemEnhancement), 20 * 1),
        (nameof(RegenerationItemEnhancement), 20 * 1),
        (nameof(SeeInvisibleItemEnhancement), 20 * 1),
        (nameof(SlowDigestItemEnhancement), 20 * 1),
        (nameof(TelepathyItemEnhancement), 20 * 1),

        (nameof(ResistPoisonAndPoisonBiasItemEnhancement), 8 * 2 * 36), // 12/16
        (nameof(ResistPoisonAndNecromanticBiasItemEnhancement), 8 * 2 * 6), // 2/16
        (nameof(ResistPoisonAndRogueBiasItemEnhancement), 8 * 2 * 3), // 1/16
        (nameof(ResistPoisonItemEnhancement), 8 * 2 * 3), // 1/16

        (nameof(ResistFearAndWarriorBiasItemEnhancement), 2 * 16), // 1/3
        (nameof(ResistFearItemEnhancement), 8 * 2 * 32), // 2/3

        (nameof(ResistLightItemEnhancement), 8 * 1 * 48),
        (nameof(ResistDarknessItemEnhancement), 8 * 1 * 48),
        (nameof(ResistBlindnessItemEnhancement), 8 * 1 * 48),
        (nameof(ResistBlindnessItemEnhancement), 8 * 1 * 48),

        (nameof(ResistConfusionAndChaosBiasItemEnhancement), 8 * 2 * 8), // 1/6
        (nameof(ResistConfusionItemEnhancement), 8 * 2 * 40), // 5/6

        (nameof(ResistSoundItemEnhancement), 8 * 2 * 48),
        (nameof(ResistShardsItemEnhancement), 8 * 2 * 48),

        (nameof(ResistNetherAndNecromanticBiasItemEnhancement), 8 * 2 * 16), // 1/3
        (nameof(ResistNetherItemEnhancement), 8 * 2 * 32), // 2/3

        (nameof(ResistNexusItemEnhancement), 8 * 2 * 48),

        (nameof(ResistChaosAndChaosBiasItemEnhancement), 8 * 2 * 24), // 1/2
        (nameof(ResistChaosItemEnhancement), 8 * 2 * 24), // 1/2

        (nameof(ResistDisenchantItemEnhancement), 8 * 2 * 48),
    };
}
