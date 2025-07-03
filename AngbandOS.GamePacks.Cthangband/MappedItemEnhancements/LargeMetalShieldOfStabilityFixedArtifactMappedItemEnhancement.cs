namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LargeMetalShieldOfStabilityFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LargeMetalShieldOfStabilityFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(FixedArtifactItemEnhancementWeightedRandom) };
}