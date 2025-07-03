namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalCapOfHolinessFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.MetalCapOfHolinessFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(MetalCapOfHolinessFixedArtifactItemEnhancement) };
}