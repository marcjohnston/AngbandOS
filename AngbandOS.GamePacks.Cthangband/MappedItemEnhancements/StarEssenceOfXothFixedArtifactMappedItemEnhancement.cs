namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StarEssenceOfXothFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.StarEssenceOfXothFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(StarEssenceOfXothFixedArtifactItemEnhancement) };
}