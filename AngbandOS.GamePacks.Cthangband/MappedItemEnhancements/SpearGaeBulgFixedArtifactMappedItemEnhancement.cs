namespace AngbandOS.GamePacks.Cthangband;

public class SpearGaeBulgFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SpearGaeBulgFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SpearGaeBulgFixedArtifactItemEnhancement) };
}