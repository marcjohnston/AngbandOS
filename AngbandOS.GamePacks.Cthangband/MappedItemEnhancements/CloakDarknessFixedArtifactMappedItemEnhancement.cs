namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakDarknessFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.CloakDarknessFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(CloakDarknessFixedArtifactItemEnhancement) };
}