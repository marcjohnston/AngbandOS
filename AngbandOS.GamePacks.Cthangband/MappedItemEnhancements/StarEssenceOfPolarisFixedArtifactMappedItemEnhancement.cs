namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StarEssenceOfPolarisFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.StarEssenceOfPolarisFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(StarEssenceOfPolarisFixedArtifactItemEnhancement) };
}