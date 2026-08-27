namespace AngbandOS.GamePacks.Cthangband;

public class CloakShadeFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.CloakShadeFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(CloakShadeFixedArtifactItemEnhancement) };
}