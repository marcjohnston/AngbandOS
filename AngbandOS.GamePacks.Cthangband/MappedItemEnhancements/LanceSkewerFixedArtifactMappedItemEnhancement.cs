namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LanceSkewerFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.LanceSkewerFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(LanceSkewerFixedArtifactItemEnhancement) };
}