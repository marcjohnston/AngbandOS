namespace AngbandOS.GamePacks.Cthangband;

public class CutlassOfBlackbeardFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.CutlassOfBlackbeardFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(CutlassOfBlackbeardFixedArtifactItemEnhancement) };
}