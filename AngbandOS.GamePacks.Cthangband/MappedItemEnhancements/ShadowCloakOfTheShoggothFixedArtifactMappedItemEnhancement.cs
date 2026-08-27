namespace AngbandOS.GamePacks.Cthangband;

public class ShadowCloakOfTheShoggothFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.ShadowCloakOfTheShoggothFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(ShadowCloakOfTheShoggothFixedArtifactItemEnhancement) };
}