// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemAdditiveBundleWeightedRandoms;

[Serializable]
internal class ResistanceItemAdditiveBundleWeightedRandom : ItemAdditiveBundleWeightedRandom
{
    private ResistanceItemAdditiveBundleWeightedRandom(Game game) : base(game) { } // This object is a singleton
    protected override (string?, int)[] ItemAdditiveBundleNames => new (string?, int)[]
    {
        (nameof(ResistAcidItemAdditiveBundle), 1),
        (nameof(ResistBlindnessItemAdditiveBundle), 1),
        (nameof(ResistChaosItemAdditiveBundle), 1),
        (nameof(ResistColdItemAdditiveBundle), 1),
        (nameof(ResistConfusionItemAdditiveBundle), 1),
        (nameof(ResistDarknessItemAdditiveBundle), 1),
        (nameof(ResistDisenchantItemAdditiveBundle), 1),
        (nameof(ResistElectricityItemAdditiveBundle), 1),
        (nameof(ResistFearItemAdditiveBundle), 1),
        (nameof(ResistFireItemAdditiveBundle), 1),
        (nameof(ResistLightItemAdditiveBundle), 1),
        (nameof(ResistNetherItemAdditiveBundle), 1),
        (nameof(ResistNexusItemAdditiveBundle), 1),
        (nameof(ResistPoisonItemAdditiveBundle), 1),
        (nameof(ResistShardsItemAdditiveBundle), 1),
        (nameof(ResistSoundItemAdditiveBundle), 1)
    };
}
