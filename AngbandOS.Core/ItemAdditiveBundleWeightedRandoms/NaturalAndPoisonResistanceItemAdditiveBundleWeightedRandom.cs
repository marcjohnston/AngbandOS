// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemAdditiveBundleWeightedRandoms;

[Serializable]
internal class NaturalAndPoisonResistanceItemAdditiveBundleWeightedRandom : ItemAdditiveBundleWeightedRandom
{
    private NaturalAndPoisonResistanceItemAdditiveBundleWeightedRandom(Game game) : base(game) { } // This object is a singleton
    protected override (string?, int)[] ItemAdditiveBundleNames => new (string?, int)[]
    {
        (nameof(ResistAcidAndAcidBiasItemAdditiveBundle), 3 * 48),
        (nameof(ResistElectricityAndElectricityBiasItemAdditiveBundle), 3 * 48),
        (nameof(ResistFireAndFireBiasItemAdditiveBundle), 3 * 48),
        (nameof(ResistColdAndColdBiasItemAdditiveBundle), 3 * 48),

        (nameof(ResistPoisonAndPoisonBiasItemAdditiveBundle), 2 * 36), // 12/16
        (nameof(ResistPoisonAndNecromanticBiasItemAdditiveBundle), 2 * 6), // 2/16
        (nameof(ResistPoisonAndRogueBiasItemAdditiveBundle), 2 * 3), // 1/16
        (nameof(ResistPoisonItemAdditiveBundle), 2 * 3), // 1/16
    };
}
