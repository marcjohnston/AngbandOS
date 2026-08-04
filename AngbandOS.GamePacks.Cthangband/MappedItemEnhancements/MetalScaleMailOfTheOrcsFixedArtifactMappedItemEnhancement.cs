namespace AngbandOS.GamePacks.Cthangband;

public class MetalScaleMailOfTheOrcsFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.MetalScaleMailOfTheOrcsFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(MetalScaleMailOfTheOrcsFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}