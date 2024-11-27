// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemAdditiveBundleWeightedRandoms;

[Serializable]
internal class NaturalResistanceItemEnhancementWeightedRandom : ItemEnhancementWeightedRandom
{
    private NaturalResistanceItemEnhancementWeightedRandom(Game game) : base(game) { } // This object is a singleton
    protected override (string?, int)[] ItemAdditiveBundleNames => new (string?, int)[]
    {
        (nameof(ResistAcidAndAcidBiasItemEnhancement), 3 * 48),
        (nameof(ResistElectricityAndElectricityBiasItemEnhancement), 3 * 48),
        (nameof(ResistFireAndFireBiasItemEnhancement), 3 * 48),
        (nameof(ResistColdAndColdBiasItemEnhancement), 3 * 48),
    };
}
