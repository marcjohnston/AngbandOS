// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistanceItemEnhancementWeightedRandom : ItemEnhancementWeightedRandomGameConfiguration
{
    public override (string?, int)[] NameAndWeightBindings => new (string?, int)[]
    {
        (nameof(ResistAcidItemEnhancement), 1),
        (nameof(ResistBlindnessItemEnhancement), 1),
        (nameof(ResistChaosItemEnhancement), 1),
        (nameof(ResistColdItemEnhancement), 1),
        (nameof(ResistConfusionItemEnhancement), 1),
        (nameof(ResistDarknessItemEnhancement), 1),
        (nameof(ResistDisenchantItemEnhancement), 1),
        (nameof(ResistElectricityItemEnhancement), 1),
        (nameof(ResistFearItemEnhancement), 1),
        (nameof(ResistFireItemEnhancement), 1),
        (nameof(ResistLightItemEnhancement), 1),
        (nameof(ResistNetherItemEnhancement), 1),
        (nameof(ResistNexusItemEnhancement), 1),
        (nameof(ResistPoisonItemEnhancement), 1),
        (nameof(ResistShardsItemEnhancement), 1),
        (nameof(SoundResistanceRingItemFactoryItemEnhancement), 1)
    };
}
