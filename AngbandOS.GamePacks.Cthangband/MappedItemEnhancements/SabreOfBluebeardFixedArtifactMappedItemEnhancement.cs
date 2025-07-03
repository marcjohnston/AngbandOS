namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SabreOfBluebeardFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.SabreOfBluebeardFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(SabreOfBluebeardFixedArtifactItemEnhancement) };
}