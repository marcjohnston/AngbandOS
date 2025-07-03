namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SabreOfXuraFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SabreOfXuraFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SabreOfXuraFixedArtifactItemEnhancement) };
}