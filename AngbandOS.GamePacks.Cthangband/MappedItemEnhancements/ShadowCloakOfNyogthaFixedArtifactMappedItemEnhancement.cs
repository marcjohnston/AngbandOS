namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShadowCloakOfNyogthaFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.ShadowCloakOfNyogthaFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(ShadowCloakOfNyogthaFixedArtifactItemEnhancement), nameof(FixedArtifactItemEnhancementWeightedRandom) };
}