namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerIcicleFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.DaggerIcicleFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(DaggerIcicleFixedArtifactItemEnhancement) };
}