namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerOfThothFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.DaggerOfThothFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(DaggerOfThothFixedArtifactItemEnhancement) };
}