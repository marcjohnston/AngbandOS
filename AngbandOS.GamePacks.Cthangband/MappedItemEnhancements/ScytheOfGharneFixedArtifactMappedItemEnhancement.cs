namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScytheOfGharneFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.ScytheOfGharneFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(ScytheOfGharneFixedArtifactItemEnhancement) };
}