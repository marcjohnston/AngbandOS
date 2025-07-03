namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GoldenCrownOfTheSunFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.GoldenCrownOfTheSunFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(GoldenCrownOfTheSunFixedArtifactItemEnhancement), nameof(FixedArtifactRandomPowerItemEnhancementWeightedRandom), nameof(AbilityItemEnhancementWeightedRandom) };
}