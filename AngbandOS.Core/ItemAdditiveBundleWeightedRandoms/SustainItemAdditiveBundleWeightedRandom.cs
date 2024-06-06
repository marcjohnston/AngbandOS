// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemAdditiveBundleWeightedRandoms;

[Serializable]
internal class SustainItemAdditiveBundleWeightedRandom : BoundItemAdditiveBundleWeightedRandom
{
    private SustainItemAdditiveBundleWeightedRandom(Game game) : base(game) { } // This object is a singleton
    protected override (string, int)[] ItemAdditiveBundleNames => new (string, int)[]
    {
        (nameof(SustainCharismaItemAdditiveBundle), 1),
        (nameof(SustainConstitutionItemAdditiveBundle), 1),
        (nameof(SustainDexterityItemAdditiveBundle), 1),
        (nameof(SustainIntelligenceItemAdditiveBundle), 1),
        (nameof(SustainStrengthItemAdditiveBundle), 1),
        (nameof(SustainWisdomItemAdditiveBundle), 1)
    };
}
