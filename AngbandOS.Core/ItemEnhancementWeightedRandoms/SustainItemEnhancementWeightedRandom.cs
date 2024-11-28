// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemEnhancementWeightedRandoms;

[Serializable]
internal class SustainItemEnhancementWeightedRandom : ItemEnhancementWeightedRandom
{
    private SustainItemEnhancementWeightedRandom(Game game) : base(game) { } // This object is a singleton
    protected override (string?, int)[] ItemEnhancementBindingKeyAndWeightTuples => new (string?, int)[]
    {
        (nameof(SustainCharismaItemEnhancement), 1),
        (nameof(SustainConstitutionItemEnhancement), 1),
        (nameof(SustainDexterityItemEnhancement), 1),
        (nameof(SustainIntelligenceItemEnhancement), 1),
        (nameof(SustainStrengthItemEnhancement), 1),
        (nameof(SustainWisdomItemEnhancement), 1)
    };
}
