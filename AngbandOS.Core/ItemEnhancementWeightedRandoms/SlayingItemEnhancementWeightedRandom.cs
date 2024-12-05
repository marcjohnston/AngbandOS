// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemEnhancementWeightedRandoms;

[Serializable]
internal class SlayingItemEnhancementWeightedRandom : ItemEnhancementWeightedRandom
{
    private SlayingItemEnhancementWeightedRandom(Game game) : base(game) { } // This object is a singleton
    protected override (string?, int)[] ItemEnhancementBindingKeyAndWeightTuples => new (string?, int)[]
    {
        (nameof(SlayAnimalItemEnhancement), 2),
        (nameof(SlayEvilAndLawOrPriestlyArtifactBiasItemEnhancement), 2),
        (nameof(SlayUndeadAndPriestlyArtifactBiasItemEnhancement), 2),
        (nameof(SlayDemonAndPriestlyArtifactBiasItemEnhancement), 2),
        (nameof(SlayOrcItemEnhancement), 2),
        (nameof(SlayTrollItemEnhancement), 2),
        (nameof(SlayGiantItemEnhancement), 2),
        (nameof(SlayDragonItemEnhancement), 2),
        (nameof(KillDragonItemEnhancement), 1),
        (nameof(VorpalAndWarriorArtifactBiasItemEnhancement), 2),
        (nameof(ImpactItemEnhancement), 1),
        (nameof(BrandFireAndFireArtifactBiasItemEnhancement), 2),
        (nameof(BrandColdAndColdArtifactBiasItemEnhancement), 2),
        (nameof(BrandElectricityAndElectricityArtifactBiasItemEnhancement), 2),
        (nameof(BrandAcidAndAcidArtifactBiasItemEnhancement), 2),
        (nameof(BrandPoisonAndPoisonNecromanticOrRogueArtifactBiasItemEnhancement), 2),
        (nameof(VampiricAndNecromanticArtifactBiasItemEnhancement), 2),
        (nameof(ChaoticAndChaosArtifactBiasItemEnhancement), 2),
    };
}
