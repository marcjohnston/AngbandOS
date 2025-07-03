namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PikeOfTepesFixedArtifactMappedItemEnhancement : MappedItemEnhancementGameConfiguration
{
    public override string[]? FixedArtifactBindingKeys => new string[] { nameof(FixedArtifactsEnum.PikeOfTepesFixedArtifact) };
    public override string[]? ItemEnhancementBindingKeys => new string[] { nameof(PikeOfTepesFixedArtifactItemEnhancement) };
}