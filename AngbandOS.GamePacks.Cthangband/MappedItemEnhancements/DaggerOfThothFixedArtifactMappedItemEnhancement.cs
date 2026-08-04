namespace AngbandOS.GamePacks.Cthangband;

public class DaggerOfThothFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.DaggerOfThothFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(DaggerOfThothFixedArtifactItemEnhancement) };
}