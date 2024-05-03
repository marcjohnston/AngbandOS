// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.WeightedRandoms;

[Serializable]
internal class SlimeMoldPotionItemFactoryWeightedRandom : ItemFactoryWeightedRandom
{
    private SlimeMoldPotionItemFactoryWeightedRandom(Game game) : base(game) { } // This object is a singleton.
    protected override (string, int)[] ItemFactoryNamesAndWeights => new (string, int)[]
    {
        (nameof(WaterPotionItemFactory), 1),
        (nameof(AppleJuicePotionItemFactory), 1),
        (nameof(SlownessPotionItemFactory), 1),
        (nameof(SaltWaterPotionItemFactory), 1),
        (nameof(PoisonPotionItemFactory), 1),
        (nameof(BlindnessPotionItemFactory), 1),
        (nameof(BoozePotionItemFactory), 1),
        (nameof(SleepPotionItemFactory), 1),
        (nameof(InfravisionPotionItemFactory), 1),
        (nameof(DetectInvisiblePotionItemFactory), 1),
        (nameof(SlowPoisonPotionItemFactory), 1),
        (nameof(NeutralizePoisonPotionItemFactory), 1),
        (nameof(BoldnessPotionItemFactory), 1),
        (nameof(SpeedPotionItemFactory), 1),
        (nameof(ResistHeatPotionItemFactory), 1),
        (nameof(ResistColdPotionItemFactory), 1),
        (nameof(HeroismPotionItemFactory), 1),
        (nameof(BerserkStrengthPotionItemFactory), 1),
        (nameof(CureLightWoundsPotionItemFactory), 1),
        (nameof(CureSeriousWoundsPotionItemFactory), 1),
        (nameof(CureCriticalWoundsPotionItemFactory), 1),
        (nameof(HealingPotionItemFactory), 1),
        (nameof(SpecialHealingPotionItemFactory), 1),
        (nameof(LifePotionItemFactory), 1),
        (nameof(RestoreManaPotionItemFactory), 1),
        (nameof(RestoreLifeLevelsPotionItemFactory), 1),
        (nameof(RestoreStrengthPotionItemFactory), 1),
        (nameof(RestoreIntelligencePotionItemFactory), 1),
        (nameof(RestoreWisdomPotionItemFactory), 1),
        (nameof(RestoreDexterityPotionItemFactory), 1),
        (nameof(RestoreConstitutionPotionItemFactory), 1),
        (nameof(RestoreCharismaPotionItemFactory), 1),
        (nameof(StrengthPotionItemFactory), 1),
        (nameof(IntelligencePotionItemFactory), 1),
        (nameof(WisdomPotionItemFactory), 1),
        (nameof(DexterityPotionItemFactory), 1),
        (nameof(ConstitutionPotionItemFactory), 1),
        (nameof(CharismaPotionItemFactory), 1),
        (nameof(AugmentationPotionItemFactory), 1),
        (nameof(EnlightenmentPotionItemFactory), 1),
        (nameof(SpecialEnlightenmentPotionItemFactory), 1),
        (nameof(SelfKnowledgePotionItemFactory), 1),
        (nameof(ExperiencePotionItemFactory), 1),
        (nameof(ResistancePotionItemFactory), 1),
        (nameof(CuringPotionItemFactory), 1),
        (nameof(InvulnerabilityPotionItemFactory), 1),
        (nameof(NewLifePotionItemFactory), 1)
    };
}
