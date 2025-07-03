namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FlailTotilaFixedArtifactappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.FlailTotilaFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(FlailTotilaFixedArtifactItemEnhancement) };
}