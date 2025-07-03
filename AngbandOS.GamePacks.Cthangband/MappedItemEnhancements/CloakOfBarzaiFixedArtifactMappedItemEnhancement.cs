namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfBarzaiFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.CloakOfBarzaiFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(CloakOfBarzaiFixedArtifactItemEnhancement) };
}