// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NaturalAndPoisonResistanceItemEnhancementWeightedRandom : ItemEnhancementWeightedRandomGameConfiguration
{
    public override (string?, int)[] NameAndWeightBindings => new (string?, int)[]
    {
        (nameof(ResistAcidAndAcidBiasItemEnhancement), 3 * 48),
        (nameof(ResistElectricityAndElectricityBiasItemEnhancement), 3 * 48),
        (nameof(ResistFireAndFireBiasItemEnhancement), 3 * 48),
        (nameof(ResistColdAndColdBiasItemEnhancement), 3 * 48),

        (nameof(ResistPoisonAndPoisonBiasItemEnhancement), 2 * 36), // 12/16
        (nameof(ResistPoisonAndNecromanticBiasItemEnhancement), 2 * 6), // 2/16
        (nameof(ResistPoisonAndRogueBiasItemEnhancement), 2 * 3), // 1/16
        (nameof(ResistPoisonItemEnhancement), 2 * 3), // 1/16
    };
}
