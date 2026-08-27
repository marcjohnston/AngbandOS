namespace AngbandOS.GamePacks.Cthangband;

public class GlaiveOfPainFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.GlaiveOfPainFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(GlaiveOfPainFixedArtifactItemEnhancement) };
}